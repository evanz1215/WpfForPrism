using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase, IConfirmNavigationRequest // INavigationAware
    {
        /// <summary>
        /// 綁定的內容
        /// </summary>
        private string _msg;

        /// <summary>
        /// 綁定的內容
        /// </summary>
        public string Msg
        {
            get { return _msg; }
            set
            {
                _msg = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 離開頁面時確認
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <param name="continuationCallback"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;
            if (MessageBox.Show("確認切換嗎?", "溫馨提示", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                result = false;
            }

            continuationCallback(result);
        }

        /// <summary>
        /// 是否重用實例
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("MsgA"))
            {
                Msg = navigationContext.Parameters.GetValue<string>("MsgA");
            }
        }
    }
}