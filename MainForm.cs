using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuturesInfoFromSina
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var value = this.getValue(RegKey, RegNameName);
            if (value != null)
            {
                futures = value;
            }
            var left = this.getValue(RegKey, RegNameLeft);
            if (left != null)
            {
                this.Left = Convert.ToInt32(left);
            }
            var top = this.getValue(RegKey, RegNameTop);
            if (top != null)
            {
                this.Top = Convert.ToInt32(top);
            }
            var accuracy = this.getValue(RegKey, RegNameAccuracy);
            if (accuracy != null)
            {
                this.accuracy = Convert.ToInt32( accuracy);
            }
            var concise = this.getValue(RegKey, RegNameConcise);
            if (concise != null)
            {
                this.isConcise = Convert.ToBoolean(concise);
            }
        }
        private Timer timer = new Timer();
        private delegate void FormControlInvoker();
        private string futures = "AG1512";
        private double preClose;
        private string RegKey = "FuturesInfo";
        private string RegNameName = "Futures";
        private string RegNameLeft = "Left";
        private string RegNameTop = "Top";
        private string RegNameAccuracy = "Accuracy";
        private string RegNameConcise = "Concise";
        private bool isConcise = false;
        private int accuracy = 0;


        private void Window_Loaded(object sender, EventArgs e)
        {
            this.ToolStripMenuItem界面.Text = this.isConcise ? "完整版" : "简洁版";
            this._name.Visible = !this.isConcise;
            this.flowLayoutPanel2.Visible = !this.isConcise;


            timer_Tick(null, null);
            timer.Interval = 500;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                string url = string.Concat("http://hq.sinajs.cn/list=", futures);
                CookieContainer cookie = new CookieContainer();
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "Get";
                request.CookieContainer = cookie;
                request.Timeout = 2000;

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream s = response.GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.GetEncoding("gb2312"));
                string result = sr.ReadToEnd();
                sr.Dispose();
                sr.Close();
                s.Dispose();
                s.Close();

                var futuresInfo = result.Split(',');

                string name = futuresInfo[0];
                try
                {
                    string test = futuresInfo[3];
                }
                catch (Exception)
                {
                    this.Invoke(new FormControlInvoker(() =>
                    {
                        this._name.Text = "不存在！";
                    }));
                    return;
                }
                name = name.Substring(name.IndexOf("\"") + 1);
                double close = Convert.ToDouble(futuresInfo[8]);
                double priceSale = Convert.ToDouble(futuresInfo[7]);
                double volumeSale = Convert.ToDouble(futuresInfo[12]);
                double priceBuy = Convert.ToDouble(futuresInfo[6]);
                double volumeBuy = Convert.ToDouble(futuresInfo[11]);
                double yestodayClose = Convert.ToDouble(futuresInfo[5]);
                //double diff = preClose != 0 ? close - preClose : 0;
                preClose = close;
                double open = Convert.ToDouble(futuresInfo[2]);
                double increase = close - yestodayClose;
                string fm = "F"+ this.accuracy;

                this.Invoke(new FormControlInvoker(() =>
                {
                    if (increase > 0)
                    {
                        this._priceSale.ForeColor = this._volumeSale.ForeColor = this._priceBuy.ForeColor = this._volumeBuy.ForeColor = Color.Red;
                    } 
                    else if (increase == 0)
                    {
                        this._priceSale.ForeColor = this._volumeSale.ForeColor = this._priceBuy.ForeColor = this._volumeBuy.ForeColor = Color.White;
                    }
                    else
                    {
                        this._priceSale.ForeColor = this._volumeSale.ForeColor = this._priceBuy.ForeColor = this._volumeBuy.ForeColor = Color.Green;
                    }
                    if (!this.isConcise) {
                    this._name.Text = name;
                    this._priceSale.Text = priceSale.ToString(fm);
                    this._volumeSale.Text = volumeSale.ToString(fm);
                    this._priceBuy.Text = priceBuy.ToString(fm);
                    this._volumeBuy.Text = volumeBuy.ToString(fm);
                    

                    //if (diff > 0)
                    //{
                    //    this._priceSale.Text += " ↑";
                    //}
                    //else if (diff == 0)
                    //{
                    //    //this._price.Text += " -"; 
                    //}
                    //else
                    //{
                    //    this._priceSale.Text += " ↓";
                    //}


                    if (close == priceBuy)
                    {
                        this._priceBuy.Text = "·" + this._priceBuy.Text;
                        //this._priceBuy.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        //this._priceSale.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    }
                    else
                    {
                        this._priceSale.Text = "·" + this._priceSale.Text;
                            //this._priceBuy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                            //this._priceSale.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        }
                    }
                    else
                    {
                        this._priceSale.Text = close.ToString(fm);
                        this._volumeSale.Text = increase.ToString(fm);
                    }
                }));
            }
            catch (ProtocolViolationException pvex)
            {
                this._priceSale.Text = pvex.Message;
                this._priceSale.Text = "";
                this._volumeSale.Text = "";
                this._priceBuy.Text = "";
                this._volumeBuy.Text = "";
            }
            catch (WebException wbex)
            {
                this._name.Text = "联网失败";
                this._priceSale.Text = "";
                this._volumeSale.Text = "";
                this._priceBuy.Text = "";
                this._volumeBuy.Text = "";
            }
            catch (InvalidOperationException ioex)
            {
                this._name.Text = ioex.Message;
                this._priceSale.Text = "";
                this._volumeSale.Text = "";
                this._priceBuy.Text = "";
                this._volumeBuy.Text = "";
            }
            catch (NotSupportedException nsex)
            {
                this._name.Text = nsex.Message;
                this._priceSale.Text = "";
                this._volumeSale.Text = "";
                this._priceBuy.Text = "";
                this._volumeBuy.Text = "";
            }
            catch (Exception ex)
            {
                this._name.Text = ex.Message;
                this._priceSale.Text = "";
                this._volumeSale.Text = "";
                this._priceBuy.Text = "";
                this._volumeBuy.Text = "";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private bool move = false;
        private int MouseX, MouseY;

        private void StackPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Cursor = Cursors.SizeAll;
                this.move = true;
            }
        }

        private void StackPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.move = false;
        }

        private void StackPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.move)
            {
                this.Left += System.Windows.Forms.Control.MousePosition.X - this.MouseX;
                this.Top += System.Windows.Forms.Control.MousePosition.Y - this.MouseY;
            }
            this.MouseX = System.Windows.Forms.Control.MousePosition.X;
            this.MouseY = System.Windows.Forms.Control.MousePosition.Y;
        }

        private void 期货代码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._textboxStock.Text = futures;
            this._panelSetting.Visible = true;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.setValue(RegKey, RegNameLeft, this.Left.ToString());
            this.setValue(RegKey, RegNameTop, this.Top.ToString());
            this.Close();
        }

        private void _textboxStock_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.futures = this._textboxStock.Text.Trim();
                this.setValue(RegKey, RegNameName, futures);
                this._panelSetting.Visible = false;
            }
        }

        /// <summary>
        /// 写入注册表,如果指定项已经存在,则修改指定项的值
        /// </summary>
        /// <param name="keytype">注册表基项枚举</param>
        /// <param name="key">注册表项,不包括基项</param>
        /// <param name="name">值名称</param>
        /// <param name="values">值</param>
        /// <returns>返回布尔值,指定操作是否成功</returns>
        public void setValue(string key, string name, string value)
        {
            try
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.CreateSubKey(key);
                aimdir.SetValue(name, value);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 读取注册表
        /// </summary>
        /// <param name="keytype">注册表基项枚举</param>
        /// <param name="key">注册表项,不包括基项</param>
        /// <param name="name">值名称</param>
        /// <returns>返回字符串</returns>
        public string getValue(string key, string name)
        {
            try
            {
                string registData = null;
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.OpenSubKey(key, true);
                if (aimdir != null)
                {
                    var obj = aimdir.GetValue(name);
                    registData = obj == null ? null : obj.ToString();
                }
                return registData;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void MainForm_MouseEnter(object sender, EventArgs e)
        { 
            this._name.Visible = true;
        }

        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            this._name.Visible = false;
        }

        private void 简洁版ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isConcise = !this.isConcise;
            this._name.Visible = !this.isConcise;
            this.flowLayoutPanel2.Visible = !this.isConcise;

            this.ToolStripMenuItem界面.Text =this.isConcise? "完整版":"简洁版";
            this.setValue(RegKey, RegNameConcise, ""+ this.isConcise);
        }

        private void 整数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.accuracy = 0;
            this.setValue(RegKey, RegNameAccuracy, "0");
        }

        private void 单精度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.accuracy = 1;
            this.setValue(RegKey, RegNameAccuracy, "1");
        }

        private void 双精度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.accuracy = 2;
            this.setValue(RegKey, RegNameAccuracy, "2");
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                this.isConcise = !this.isConcise;
                this._name.Visible = !this.isConcise;
                this.flowLayoutPanel2.Visible = !this.isConcise;

                this.ToolStripMenuItem界面.Text = this.isConcise ? "完整版" : "简洁版";
                this.setValue(RegKey, RegNameConcise, "" + this.isConcise);
            }
        }

    }
}
