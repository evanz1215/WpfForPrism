using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfForPrism.Views
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEventAggregator _eventAggregator;

        public MainWindow(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            _eventAggregator = eventAggregator;
        }

        /// <summary>
        /// 發佈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPubClick(object sender, RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<MsgEvent>().Publish("Hello World!");
        }

        /// <summary>
        /// 訂閱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubClick(object sender, RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<MsgEvent>().Subscribe(Sub);
        }

        /// <summary>
        /// 訂閱
        /// </summary>
        /// <param name="msg"></param>
        private void Sub(string msg)
        {
            MessageBox.Show($"我收到訂閱的訊息:{msg}");
        }

        private void BtnCancelSubClick(object sender, RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<MsgEvent>().Unsubscribe(Sub);
        }
    }
}