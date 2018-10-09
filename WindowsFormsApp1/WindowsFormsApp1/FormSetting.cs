using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private ISetting _iSetting;

        private void nameInput_ValueChanged(object sender, EventArgs e)
        {

        }

        public NumericUpDown GetInputTextBox()
        {
            return this.nameInput;
        }

        public void SetValue(string value,ISetting iSetting)
        {
            this.nameInput.Text = value;
            this._iSetting = iSetting;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            return;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //获取数据进行处理
            var value = this.nameInput.Text;
            if (null != _iSetting)
            {
                _iSetting.DealData(value);
            }
            this.Dispose();
        }




    }
}
