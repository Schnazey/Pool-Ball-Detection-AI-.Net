using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallDetectionClient
{
    public partial class SettingFrame : UserControl
    {
        private string _settingName;
        private int _settingValue;
        private int _settingMinValue;
        private int _settingMaxValue;
        
        public EventHandler<int> OnValueChangedEventHandler;
        
        public SettingFrame()
        {
            InitializeComponent();
            _settingName = this.Name;
            tbValue.Minimum = 0;
            tbValue.Maximum = 100;
            tbValue.ValueChanged += TbValue_ValueChanged;
        }

        private void TbValue_ValueChanged(object? sender, EventArgs e)
        {
            _settingValue = tbValue.Value;
            OnValueChangedEventHandler?.Invoke(this, _settingValue);
        }

        public int SettingMinValue
        {
            get { return _settingMinValue; }
            set
            {
                _settingMinValue = value; 
                tbValue.Minimum = value;
            }
        }

        public int SettingMaxValue
        {
            get { return _settingMaxValue; }
            set
            {
                _settingMaxValue = value; 
                tbValue.Maximum = value;
            }
        }
        public string SettingName
        {
            get
            {
                return _settingName;
            }
            set
            {
                _settingName = value;
                lblSettingName.Text = value; 
                
            }
        }
        public int SettingValue
        {
            get
            {
                return _settingValue;
            }
            set
            {
                _settingValue = value;
                lblValue.Text = value.ToString();
                tbValue.Value = value;
            }
        }
    }
}
