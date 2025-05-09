using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CameraClient;
using CameraClient.Attributes;
using CameraClient.Settings;

namespace BallDetectionClient
{
    public partial class CameraForm : Form
    {
        public Camera Camera;
        public CameraForm()
        {
            InitializeComponent();
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
            foreach (PropertyInfo prop in Camera.Settings.GetType().GetProperties(BindingFlags.Public))
            {
                prop.CustomAttributes.ToList().ForEach(attr =>
                {
                    if (attr.AttributeType == typeof(CameraSettingAttribute))
                    {
                        CameraSettingAttribute attrSetting =
                            (CameraSettingAttribute)attr.AttributeType.GetCustomAttribute(
                                typeof(CameraSettingAttribute));
                        SettingFrame settingFrame = new SettingFrame
                        {
                            SettingName = prop.Name,
                            SettingMinValue = (int)attrSetting.MinValue,
                            SettingMaxValue = (int)attrSetting.MaxValue,
                            SettingValue = (int)prop.GetValue(Camera.Settings)
                        };
                        settingFrame.OnValueChangedEventHandler += (s, e) =>
                        {
                            prop.SetValue(Camera.Settings, e);
                        };
                        flowLayoutPanel1.Controls.Add(settingFrame);
                    }
                });
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (CameraNamesComboBox.SelectedIndex > -1)
            {
                Camera.OpenCamera(CameraNamesComboBox.Text);
            }
            else
            {
                MessageBox.Show("Please select a Camera from the list.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var definitions = Camera.FindCameraDefinitions();
            foreach (var definition in definitions)
            {
                CameraNamesComboBox.Items.Add(definition.Name);
            }
        }
    }
}
