using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware
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
