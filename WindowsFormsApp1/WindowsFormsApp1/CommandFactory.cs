using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dsnt
{
    public enum EnumInsertMode{
        文本,
        二维码,
        Code128A,
        Code128B,
        Code128C,
        ENA13
    }
    /// <summary>
    /// 写打印缓冲的数据
    /// </summary>
    public class BufferImageData
    {
        /// <summary>
        /// x开始
        /// </summary>
        public UInt16 X;
        /// <summary>
        /// y开始点
        /// </summary>
        public UInt16 Y;
        /// <summary>
        /// 宽度
        /// </summary>
        public UInt16 Width;
        /// <summary>
        /// 高度
        /// </summary>
        public UInt16 Height;
        /// <summary>
        /// 点阵数据
        /// </summary>
        public byte[] Data;

        public override string ToString()
        {
            return $"X:{X} Y:{Y} Width:{Width} Height:{Height} Data.Length:{Data.Length}"; 
        }




        public byte[] GetContentData()
        {
            var header = new byte[]{0x12,0x00};
            var dataLength = BitConverter.GetBytes((UInt16) Data.Length);
            var xBytes = BitConverter.GetBytes(X);
            var widthBytes = BitConverter.GetBytes(Width);
            var yBytes = BitConverter.GetBytes(Y);
            var heightBytes = BitConverter.GetBytes(Height);
            //反色2B
            var fanByte = BitConverter.GetBytes((UInt16) 00);
            return header.Concat(dataLength).Concat(xBytes).Concat(widthBytes).Concat(yBytes).Concat(heightBytes)
                .Concat(fanByte).Concat(Data).ToArray();
        }
    }

    public class CommandFactory
    {
       

        

       

      

        

        public void Test1()
        {
            
        }


       

        public void Test2()
        {
          
        }

      
       

        



       

        

       
        

        public static void PrintBytes(byte[] dataList)
        {
            if(null == dataList || dataList.Count() == 0)
            {
                
                return;
            }
            var sb = new StringBuilder();
            foreach(var item in dataList)
            {
                sb.Append($"{item:X2} ");
            }
            Console.WriteLine(sb.ToString());
        }

       
        /// <summary>
        /// 获取下载的位置信息
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private static byte[] GetLocationBytes(ushort left, ushort top,ushort width,ushort height)
        {
            //X起点
            var xBegin = BitConverter.GetBytes(left);
            //x宽度
            var xWidth = BitConverter.GetBytes(width);
            //y起点
            var yBegin = BitConverter.GetBytes(top);
            //y宽度
            var yHeight = BitConverter.GetBytes(height);
            //反色
            var fan = BitConverter.GetBytes((ushort)0);
            return xBegin.Concat(xWidth).Concat(yBegin).Concat(yHeight).Concat(fan).ToArray();
        }

       
        /// <summary>
        /// 根据内容获取消息的头部，如果插入的是文本，头部就是0x74，0x00
        /// </summary>
        /// <param name="functionId"></param>
        /// <returns></returns>
        private static byte[] GetContentHeader(byte functionId)
        {
            //插入消息文本
            if(functionId == 0x0b)
            {
                return new byte[] { 0x74, 0x00 };
            }
            return new byte[] { 0x00, 0x00 };
        }

       

        public byte[] GetMyTest()
        {
            var header = new byte[] { 0x7a };

            var list = new byte[] { 0x42};
            return list;
        }


        /// <summary>
        /// 检测接收到的数据是否合法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool ValidateData(byte[] data)
        {
            //如果长度不对就抛弃
            if (data.Length < 6)
            {
                return false;
            }
            //如果首字母不是0xFA就抛弃
            if (data[0] != 0xFA)
            {
                return false;
            }
            //获取数据的长度(这儿先不做校验，因为比较混乱)
            var dataLength = BitConverter.ToUInt16(data.Skip(1).Take(2).ToArray(),0);
            //if (dataLength != data.Length - 1)
            //{
            //    return false;
            //}

            return true;
        }

        public void Test()
        {
            short content = 1;
            byte[] list = BitConverter.GetBytes(content);
            foreach (var b in list)
            {
                Console.WriteLine("{0:X2}",b);
            }
        }
    }
}
