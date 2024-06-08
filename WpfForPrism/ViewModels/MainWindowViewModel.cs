using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfForPrism.Views;

namespace WpfForPrism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<string> ShowContentCmm { get; set; }

        public MainWindowViewModel()
        {
            ShowContentCmm = new DelegateCommand<string>(ShowContentFunc);
        }

        /// <summary>
        /// 改變顯示用戶控件
        /// </summary>
        /// <param name="viewName"></param>
        private void ShowContentFunc(string viewName)
        {
            if (viewName == "UCA")
            {
                this.ShowContent = new UCA();
            }
            else if (viewName == "UCB")
            {
                this.ShowContent = new UCB();
            }
            else
            {
                this.ShowContent = new UCC();
            }
        }

        /// <summary>
        /// 顯示的內容
        /// </summary>
        private UserControl _showContent;

        /// <summary>
        /// 顯示的內容
        /// </summary>
        public UserControl ShowContent
        {
            get { return _showContent; }
            set
            {
                _showContent = value;
                RaisePropertyChanged();
            }
        }


    }
}