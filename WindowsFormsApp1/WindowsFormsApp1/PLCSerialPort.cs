﻿using dsnt;
using GodSharp.SerialPort;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IDataRecvPort
    {
        void DealData(byte[] dataList);
    }


    public class PLCSerialPort
    {
        private GodSerialPort _port = null;
        private string _portName;
        private IDataRecvPort _dataRecvPort;
        private readonly int _rate;

        //接受到的数据
        private byte[] _dataRecv;

        public PLCSerialPort(string portName,int rate, IDataRecvPort dataRecvPort)
        {
            this._portName = portName;
            this._dataRecvPort = dataRecvPort;
            this._rate = rate;
        }



        /// <summary>
        /// 设置命令
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetBitValue(int address, int value)
        {
            //获取设置的命令
            var command = PLCCommandFactory.SetBitCommand(address, value != 1);
            return WriteDatas(command, 3000);
        }

        /// <summary>
        /// 获取D10的状态
        /// </summary>
        /// <returns></returns>
        public byte GetD10Status()
        {
            var bytes = ReadDataFromPLC(10, 1, 3000);
            return bytes[0];
        }

        /// <summary>
        /// 读取一个字节的数据，根据地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public byte[] GetByteStatus(int address, int length)
        {
            var bytes = ReadDataFromPLC(address, length, 3000);
            return bytes;
        }

        public GodSerialPort GetSerialPort()
        {
            return _port;
        }


        public bool WriteDatasEx(int address, byte[] bytes, int timeOut)
        {
            try
            {
                if(timeOut < 3000)
                {
                    timeOut = 3000;
                }
                _dataRecv = null;
                if (null != _port && _port.IsOpen)
                {
                    var command = PLCCommandFactory.GetWriteCommand(address, bytes);
                    _port.Write(command);
                    Console.WriteLine($"向PLC发送数据");
                    CommandFactory.PrintBytes(command);
                }
                else
                {
                    throw new Exception("请先打开串口");
                }

                var index = 1;
                while (index < timeOut)
                {
                    Thread.Sleep(100);
                    index += 100;
                    if (null != _dataRecv && _dataRecv.Length > 0)
                    {
                       
                            var newBuffer = new byte[_dataRecv.Length];
                            Array.Copy(_dataRecv, 0, newBuffer, 0, _dataRecv.Length);
                            //接受到应答数据
                            Console.WriteLine($"接受到PLC应答数据 0x06--true 0x15---false :{GetHexString(newBuffer)}");

                            if (newBuffer[0] == 0x06)
                            {
                                return true;
                            }

                            return false;
                       

                    }
                }

                throw new Exception("执行命令超时");
            }
            finally
            {
                _dataRecv = null;
            }
           
        }



        /// <summary>
        /// 是否已经打开
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            if (null == _port)
            {
                return false;
            }
            return _port.IsOpen;
        }

        /// <summary>
        /// 获取串口的名称
        /// </summary>
        /// <returns></returns>
        public string GetPortName()
        {
            return _portName;
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        public bool Open()
        {
            if (null == _port)
            {
                _port = new GodSerialPort(this._portName, this._rate, Parity.Even, 7, StopBits.One, Handshake.None);
                _port.UseDataReceived(true, (sp, bytes) =>
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var b in bytes)
                    {
                        sb.Append($"{b:X2} ");
                    }
                    Console.WriteLine($"recv data from plc:{sb.ToString()}");
                    //如果接受到数据,就提交给接口处理
                    if(_dataRecv == null)
                    {
                        _dataRecv = bytes;
                    }
                    else
                    {
                        _dataRecv = _dataRecv.Concat(bytes).ToArray();
                        Console.Write($"拼接后数据:");
                        CommandFactory.PrintBytes(_dataRecv);
                    }
                   
                    _dataRecvPort?.DealData(bytes);
                });
            }
            if (_port.IsOpen)
            {
                return true;
            }
            //打开串口,并进行监听
            return _port.Open();

        }

        /// <summary>
        /// 关闭串口通讯
        /// </summary>
        internal void Close()
        {
            _port?.Close();
        }

        

        public bool WriteDatas(byte[] command, int timeOut)
        {
            try
            {
                if(timeOut < 3000)
                {
                    timeOut = 3000;
                }
                _dataRecv = null;
                if (null != _port && _port.IsOpen)
                {
                    _port.Write(command);
                    Console.WriteLine($"向PLC发送数据");
                    CommandFactory.PrintBytes(command);
                }
                else
                {
                    throw new Exception("请先打开串口");
                }

                var index = 1;
                while (index < timeOut)
                {
                    Thread.Sleep(100);
                    index += 100;
                    if (null != _dataRecv && _dataRecv.Length > 0)
                    {

                        var newBuffer = new byte[_dataRecv.Length];
                        Array.Copy(_dataRecv, 0, newBuffer, 0, _dataRecv.Length);
                        //接受到应答数据
                        Console.WriteLine($"接受到PLC应答数据 0x06--true 0x15---false :{GetHexString(newBuffer)}");

                        if (newBuffer[0] == 0x06)
                        {
                            return true;
                        }

                        return false;


                    }
                }

                throw new Exception("执行命令超时");
            }
            finally
            {
                _dataRecv = null;
            }
           
        }

        /// 读取测试的电压
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public List<decimal> GetTestVList(int length,Main main)
        {
            if (length > 1000)
            {
                throw new Exception("超出读取范围");
            }

            var list = new List<decimal>();
            var readNumber = 10;
          
            for (var i = 0; i < length; i+=readNumber)
            {
                byte[] datas = ReadDataFromPLC(100 + i, 2*readNumber, 3000);
                for(var j = 0; j < readNumber; j++)
                {
                    if ((i + j) >= length)
                    {
                        break;
                    }
                    var value = (decimal)(BitConverter.ToInt16(datas, 2*j) / 100.0f);
                    Console.WriteLine($"读取到电压：{i}---{value}");
                    list.Add(Math.Round(value, 2));
                }
               
                main.Invoke(new Action(() =>
                {
                    main.GetProgressBar().Value = (int)(((i / (length*1m)) * 100));
                }));
                Thread.Sleep(10);
            }
            main.Invoke(new Action(() =>
            {
                main.GetProgressBar().Value=100;
            }));
            return list;
        }

        /// <summary>
        /// 读取数据的长度
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>

        public byte[] ReadDataFromPLC(int address, int length, int timeOut)
        {
            if(timeOut < 3000)
            {
                timeOut = 3000;
            }
            //if (!Monitor.TryEnter(_flag))
            //{
            //    throw new Exception("串口正在执行命令,请稍后");
            //}
            try
            {
                _dataRecv = null;
                if (null != _port && _port.IsOpen)
                {
                    var command = PLCCommandFactory.GetReadCommand(address, length);
                    _port.Write(command);
                    Console.WriteLine($"向PLC发送数据");
                    CommandFactory.PrintBytes(command);
                }
                else
                {
                    throw new Exception("请先打开串口");
                }

                var index = 1;
                while (index < timeOut)
                {
                    Thread.Sleep(100);
                    index+=100;
                    if (null != _dataRecv && _dataRecv.Length > 1)
                    {
                        
                            Console.WriteLine("接受到数据长度:" + _dataRecv.Length);
                            var newBuffer = new byte[_dataRecv.Length];
                            Array.Copy(_dataRecv, 0, newBuffer, 0, _dataRecv.Length);
                            //接受到应答数据
                            Console.WriteLine($"接受到PLC应答数据:{GetHexString(newBuffer)}");
                            if ((length * 2) + 4 != newBuffer.Length)
                            {
                                Thread.Sleep(100);
                                Console.WriteLine("接受数据长度不对，继续等待");
                                continue;
                            }
                            //对接受到的数据进行解析
                            //if (!PLCCommandFactory.ValidateData(newBuffer))
                            //{
                            //    throw new Exception("接受到的数据校验失败");
                            //}

                            var datas = new byte[newBuffer.Length - 4];
                            Array.Copy(newBuffer, 1, datas, 0, datas.Length);
                            return HexStrToByteArray(Encoding.ASCII.GetString(datas));
                       
                    }
                }

                throw new Exception($"等待时长{timeOut}超时，执行命令超时");
            }
            finally
            {
                _dataRecv = null;
            }

        }

        private static byte[] HexStrToByteArray(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                throw new ArgumentException("十六进制字符串长度不对");
            byte[] buffer = new byte[hexString.Length / 2];
            for (int i = 0; i < buffer.Length; i++)

            {
                buffer[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Trim(), 0x10);
            }
            return buffer;
        }



        public static string GetHexString(byte[] dataList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in dataList)
            {
                sb.Append($"{item:X2} ");
            }
            return sb.ToString();
        }
    }
}
