using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using System.IO;
using System.Text.RegularExpressions;

namespace PluginLib
{
    /// <summary>
    /// 遍历控件所有子控件并初始化或保存其值
    /// </summary>
    public class FormHelper
    {
        private static string Path
        {
            get
            {
                return Plugin.Path + "\\BufferFile.ini";
            }
        }
        static IniFile iniFile = null;

        /// <summary>
        /// 保存控件值
        /// </summary>
        /// <param name="control"></param>
        public static void SaveControl(Control control)
        {
            FileStream fs;
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
            fs = File.Create(Path);
            fs.Close();
            iniFile = new IniFile(Path);
            GetControlValue(control);
            iniFile = null;
        }
        private static void GetControlValue(Control control)
        {
            foreach (Control ctl in control.Controls)
            {
                if (!ctl.HasChildren)
                {
                    if (ctl.Parent is System.Windows.Forms.NumericUpDown)
                    {
                        NumericUpDown tempNumberic = ctl.Parent as NumericUpDown;
                        iniFile.IniWriteValue("NumericUpDown", tempNumberic.Name, tempNumberic.Value.ToString());
                    }
                    else if (ctl is CheckBox)
                    {
                        iniFile.IniWriteValue("CheckBox", ctl.Name, ((CheckBox)ctl).Checked.ToString());
                    }
                    else if (ctl is RadioButton)
                    {
                        iniFile.IniWriteValue("RadioButton", ctl.Name, ((RadioButton)ctl).Checked.ToString());
                    }
                    else if (ctl is TextBox)
                    {
                        iniFile.IniWriteValue("TextBox", ctl.Name, ((TextBox)ctl).Text);
                    }
                    else if (ctl is ComboBox)
                    {
                        iniFile.IniWriteValue("ComboBox", ctl.Name, ((ComboBox)ctl).Text);
                    }
                    else if (ctl is TrackBar)
                    {
                        iniFile.IniWriteValue("TrackBar", ctl.Name, ((TrackBar)ctl).Value.ToString());
                    }
                    else if (ctl is CheckBoxX)
                    {
                        iniFile.IniWriteValue("CheckBoxX", ctl.Name, ((CheckBoxX)ctl).Checked.ToString());
                    }
                    else if (ctl is TextBoxX)
                    {
                        iniFile.IniWriteValue("TextBoxX", ctl.Name, ((TextBoxX)ctl).Text.ToString());
                    }
                    else if (ctl is RichTextBox)
                    {
                      
                        string[] strs = Regex.Split(((RichTextBox)ctl).Text.Trim(),"\n");
                        int i = 0;
                        foreach (string str in strs)
                        {
                            iniFile.IniWriteValue("RichTextBox="+ctl.Name, "row" + i, str);
                            i++;
                        }
                       
                    }

                }
                else
                {
                    GetControlValue(ctl);
                }

            }
        }
        /// <summary>
        /// 加载控件值
        /// </summary>
        /// <param name="control"></param>
        public static void LoadControl(Control control)
        {
            iniFile = new IniFile(Path);
            ForeachControl(control);
            iniFile = null;
        }
        private static void ForeachControl(Control control)
        {
            foreach (Control ctl in control.Controls)
            {
                if (!ctl.HasChildren)
                {
                    if (ctl.Parent is System.Windows.Forms.NumericUpDown)
                    {
                        NumericUpDown tempNumberic = ctl.Parent as NumericUpDown;
                        if (!string.IsNullOrEmpty(iniFile.IniReadValue("NumericUpDown", tempNumberic.Name)))
                        {
                            tempNumberic.Value = Convert.ToDecimal(iniFile.IniReadValue("NumericUpDown", tempNumberic.Name));
                        }
                    }
                    else if (ctl is CheckBox)
                    {
                        if (!string.IsNullOrEmpty(iniFile.IniReadValue("CheckBox", ctl.Name)))
                            ((CheckBox)ctl).Checked = Convert.ToBoolean(iniFile.IniReadValue("CheckBox", ctl.Name));
                    }
                    else if (ctl is RadioButton)
                    {
                        if (!string.IsNullOrEmpty(iniFile.IniReadValue("RadioButton", ctl.Name)))
                            ((RadioButton)ctl).Checked = Convert.ToBoolean(iniFile.IniReadValue("RadioButton", ctl.Name));
                    }
                    else if (ctl is TextBox)
                    {
                        if (!string.IsNullOrEmpty(iniFile.IniReadValue("TextBox", ctl.Name)))
                            ((TextBox)ctl).Text = iniFile.IniReadValue("TextBox", ctl.Name);
                    }
                    else if (ctl is ComboBox)
                    {
                        if (!string.IsNullOrEmpty(iniFile.IniReadValue("ComboBox", ctl.Name)))
                            ((ComboBox)ctl).Text = iniFile.IniReadValue("ComboBox", ctl.Name);
                    }

                    else if (ctl is TrackBar)
                    {
                        if (!string.IsNullOrEmpty(iniFile.IniReadValue("TrackBar", ctl.Name)))
                            ((TrackBar)ctl).Value = Convert.ToInt32(iniFile.IniReadValue("TrackBar", ctl.Name));
                    }
                    else if (ctl is CheckBoxX)
                    {
                        if (!string.IsNullOrEmpty(iniFile.IniReadValue("CheckBoxX", ctl.Name)))
                            ((CheckBoxX)ctl).Checked = Convert.ToBoolean(iniFile.IniReadValue("CheckBoxX", ctl.Name));
                    }
                    else if (ctl is TextBoxX)
                    {
                        if (!string.IsNullOrEmpty(iniFile.IniReadValue("TextBoxX", ctl.Name)))
                            ((TextBoxX)ctl).Text = iniFile.IniReadValue("TextBoxX", ctl.Name);
                    }
                    else if (ctl is RichTextBox)
                    {
                        int i = 0;
                        while(!string.IsNullOrEmpty(iniFile.IniReadValue("RichTextBox=" + ctl.Name, "row"+i)))
                        {
                            ((RichTextBox)ctl).Text += iniFile.IniReadValue("RichTextBox=" + ctl.Name, "row"+i)+"\n";
                            i++;
                        }
                      
                        
                           
                    }
                }
                else
                {
                    ForeachControl(ctl);
                }
            }
        }
    }
}
