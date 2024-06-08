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
        //containerRegistry.RegisterForNavigation<UCA>("AAA"); // 這樣註冊的話，就需要在MainWindow.xaml中的Button的Command參數中填入"AAA"

        containerRegistry.RegisterForNavigation<UCA>();
        containerRegistry.RegisterForNavigation<UCB>();
        containerRegistry.RegisterForNavigation<UCC>();
    }
}