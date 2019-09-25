using CefSharp;
using CefSharp.Wpf;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            CefSettings settings = new CefSettings();
            settings.Locale = "zh-CN";
            settings.AcceptLanguageList = "zh-CN";
            settings.UserAgent = "LuCien App";
            Cef.Initialize(settings);
            InitializeComponent();

            
        }
    }
}
