using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleA
{
    public class ModuleAProfile : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        /// <summary>
        /// 依賴注入
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注入導航
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();

            // 注入對話框
            containerRegistry.RegisterDialog<ViewC, ViewCViewModel>();
        }
    }
}
