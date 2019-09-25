using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            CefSettings settings = new CefSettings();
            settings.Locale = "zh-CN";
            settings.CefCommandLineArgs.Add("--disable-web-security", "1");//关闭同源策略,允许跨域
            settings.AcceptLanguageList = "zh-CN";
            settings.UserAgent = "LuCien App";
            settings.CefCommandLineArgs.Add("--enable-system-flash", "1");//使用系统flash
            Cef.Initialize(settings);
            InitializeComponent();
            web.KeyboardHandler = new CEFKeyBoardHander();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class CEFKeyBoardHander : IKeyboardHandler
    {
        public bool OnKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            //throw new NotImplementedException();
            if (type == KeyType.KeyUp && Enum.IsDefined(typeof(Keys), windowsKeyCode))
            {
                var key = (Keys)windowsKeyCode;
                switch (key)
                {
                    case Keys.F12:
                        browser.ShowDevTools();
                        break;

                    case Keys.F5:

                        if (modifiers == CefEventFlags.ControlDown)
                        {
                            //MessageBox.Show("ctrl+f5");
                            browser.Reload(true); //强制忽略缓存

                        }
                        else
                        {
                            //MessageBox.Show("f5");
                            browser.Reload();
                        }
                        break;
                }
            }
            return false;
        }

        public bool OnPreKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            //throw new NotImplementedException();
            return false;
        }
    }
}
