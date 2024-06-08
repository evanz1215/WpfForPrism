using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;
using WpfForPrism.Views;

namespace WpfForPrism;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    /// <summary>
    /// 設置啟動頁
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    /// <summary>
    /// 注入服務
    /// </summary>
    /// <param name="containerRegistry"></param>
    /// <exception cref="NotImplementedException"></exception>
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
}