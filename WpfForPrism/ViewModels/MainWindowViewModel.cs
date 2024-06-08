using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
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

        public DelegateCommand<string> DialogCmm { get; set; }

        // 區域管理
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// 導航紀錄
        /// </summary>
        private IRegionNavigationJournal _journal;

        /// <summary>
        /// 對話框服務
        /// </summary>
        private readonly IDialogService _dialogService;

        public MainWindowViewModel(IRegionManager regionManager, IRegionNavigationJournal journal, IDialogService dialogService)
        {
            _regionManager = regionManager;
            ShowContentCmm = new DelegateCommand<string>(ShowContentFunc);
            BackCmm = new DelegateCommand(Back);
            DialogCmm = new DelegateCommand<string>(ShowDialogFunc);
            _journal = journal;
            _dialogService = dialogService;
        }

        private void Back()
        {
            if (_journal != null && _journal.CanGoBack)
            {
                _journal.GoBack();
            }
        }

        private void ShowDialogFunc(string viewName)
        {
            DialogParameters parameters = new DialogParameters();
            parameters.Add("title", "動態傳入的標題");
            parameters.Add("para1", "傳入的參數1");
            parameters.Add("para2", "傳入的參數2");

            _dialogService.ShowDialog(viewName, parameters, callback =>
            {
                if (callback.Result == ButtonResult.Yes)
                {
                    string r1 = callback.Parameters.GetValue<string>("result1");
                    Console.WriteLine();
                }
            });
        }

        /// <summary>
        /// 改變顯示用戶控件
        /// </summary>
        /// <param name="viewName">用戶控件名稱</param>
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