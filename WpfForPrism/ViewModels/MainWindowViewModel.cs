using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
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

        // 區域管理
        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            ShowContentCmm = new DelegateCommand<string>(ShowContentFunc);
        }

        /// <summary>
        /// 改變顯示用戶控件
        /// </summary>
        /// <param name="viewName"></param>
        private void ShowContentFunc(string viewName)
        {
            _regionManager.Regions["ContentRegion"].RequestNavigate(viewName);
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