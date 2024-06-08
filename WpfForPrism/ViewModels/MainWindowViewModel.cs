using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Controls;

namespace WpfForPrism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<string> ShowContentCmm { get; set; }

        /// <summary>
        /// 後退
        /// </summary>
        public DelegateCommand BackCmm { get; set; }

        // 區域管理
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// 導航紀錄
        /// </summary>
        private IRegionNavigationJournal _journal;

        public MainWindowViewModel(IRegionManager regionManager, IRegionNavigationJournal journal)
        {
            _regionManager = regionManager;
            ShowContentCmm = new DelegateCommand<string>(ShowContentFunc);
            BackCmm = new DelegateCommand(Back);
            _journal = journal;
        }

        private void Back()
        {
            if (_journal != null && _journal.CanGoBack)
            {
                _journal.GoBack();
            }
        }

        /// <summary>
        /// 改變顯示用戶控件
        /// </summary>
        /// <param name="viewName"></param>
        private void ShowContentFunc(string viewName)
        {
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add("MsgA", "大家好，我是A");

            _regionManager.Regions["ContentRegion"].RequestNavigate(viewName, callback =>
            {
                _journal = callback.Context.NavigationService.Journal;
            }, parameters);
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