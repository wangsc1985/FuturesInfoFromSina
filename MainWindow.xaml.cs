using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FuturesInfoFromSina
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer timer = new Timer();
        private delegate void FormControlInvoker();
        private string futures = "AG1512";
        private double preClose;
        private string RegKey = "FuturesInfo";
        private string RegNameName = "Futures";
        private string RegNameLeft = "Left";
        private string RegNameTop = "Top";
        
        public MainWindow()
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
                this.Left = Convert.ToDouble(left);
            }
            var top = this.getValue(RegKey, RegNameTop);
            if (top != null)
            {
                this.Top = Convert.ToDouble(top);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string url = string.Concat("http://hq.sinajs.cn/list=", futures);
            CookieContainer cookie = new CookieContainer();
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "Get";
            request.CookieContainer = cookie;
            request.Timeout = 5000;

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
                this.Dispatcher.Invoke(new FormControlInvoker(() =>
                {
                    this._name.Text = "不存在！";
                }));
                return;
            }
            name = name.Substring(name.IndexOf("\"") + 1);
            double close = Convert.ToDouble(futuresInfo[8]);
            double diff = preClose != 0 ? close - preClose : 0;
            preClose = close;
            double open = Convert.ToDouble(futuresInfo[2]);
            double increase = close - open;

            this.Dispatcher.Invoke(new FormControlInvoker(() =>
            {
                this._name.Text = name;
                this._price.Text = close.ToString();
                this._increase.Text = string.Concat(increase.ToString());

                if (diff > 0)
                {
                    this.up.Visibility = System.Windows.Visibility.Visible;
                    this.down.Visibility = System.Windows.Visibility.Hidden;
                }
                else if (diff == 0)
                {
                    this.up.Visibility = System.Windows.Visibility.Hidden;
                    this.down.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    this.up.Visibility = System.Windows.Visibility.Hidden;
                    this.down.Visibility = System.Windows.Visibility.Visible;
                }

                if (increase > 0)
                {
                    this._price.Foreground = this._increase.Foreground = new SolidColorBrush(Colors.Red);
                }
                else if (increase == 0)
                {
                    this._price.Foreground = this._increase.Foreground = new SolidColorBrush(Colors.White);
                }
                else
                {
                    this._price.Foreground = this._increase.Foreground = new SolidColorBrush(Colors.Green);
                }
            }));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
        }

        private bool move = false;
        private int MouseX, MouseY;
        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.move = true;
            }
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.move = false;
            this.setValue(RegKey, RegNameLeft, this.Left.ToString());
            this.setValue(RegKey, RegNameTop, this.Top.ToString());
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

        private void _menuItem退出_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _menuItem期货_Click(object sender, RoutedEventArgs e)
        {
            this._textboxStock.Text = futures;
            this._spSetting.Visibility = System.Windows.Visibility.Visible;
        }

        private void _buttonOk_Click(object sender, RoutedEventArgs e)
        {
        }

        private void _textboxStock_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.futures = this._textboxStock.Text.Trim();
                this.setValue(RegKey, RegNameName, futures);
                this._spSetting.Visibility = System.Windows.Visibility.Hidden;
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
    }
}
/**
 Sina股票数据接口
以大秦铁路（股票代码：601006）为例，如果要获取它的最新行情，只需访问新浪的股票数据
接口：http://hq.sinajs.cn/list=sh601006这个url会返回一串文本，例如：

var hq_str_sh601006="大秦铁路, 27.55, 27.25, 26.91, 27.55, 26.20, 26.91, 26.92,
22114263, 589824680, 4695, 26.91, 57590, 26.90, 14700, 26.89, 14300,
26.88, 15100, 26.87, 3100, 26.92, 8900, 26.93, 14230, 26.94, 25150, 26.95, 15220, 26.96, 2008-01-11, 15:05:32";

这个字符串由许多数据拼接在一起，不同含义的数据用逗号隔开了，按照程序员的思路，顺序号从0开始。
0：”大秦铁路”，股票名字；
1：”27.55″，今日开盘价；
2：”27.25″，昨日收盘价；
3：”26.91″，当前价格；
4：”27.55″，今日最高价；
5：”26.20″，今日最低价；
6：”26.91″，竞买价，即“买一”报价；
7：”26.92″，竞卖价，即“卖一”报价；
8：”22114263″，成交的股票数，由于股票交易以一百股为基本单位，所以在使用时，通常把该值除以一百；
9：”589824680″，成交金额，单位为“元”，为了一目了然，通常以“万元”为成交金额的单位，所以通常把该值除以一万；
10：”4695″，“买一”申请4695股，即47手；
11：”26.91″，“买一”报价；
12：”57590″，“买二”
13：”26.90″，“买二”
14：”14700″，“买三”
15：”26.89″，“买三”
16：”14300″，“买四”
17：”26.88″，“买四”
18：”15100″，“买五”
19：”26.87″，“买五”
20：”3100″，“卖一”申报3100股，即31手；
21：”26.92″，“卖一”报价
(22, 23), (24, 25), (26,27), (28, 29)分别为“卖二”至“卖四的情况”
30：”2008-01-11″，日期；
31：”15:05:32″，时间；
 * */
