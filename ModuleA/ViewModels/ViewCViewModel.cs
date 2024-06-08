using Prism.Commands;
using Prism.Services.Dialogs;

namespace ModuleA.ViewModels
{
    public class ViewCViewModel : IDialogAware
    {
        public string Title { get; set; } = "這裡是預設標題";

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand ConfirmCmm { get; set; }
        public DelegateCommand CancelCmm { get; set; }

        public ViewCViewModel()
        {
            ConfirmCmm = new DelegateCommand(Confirm);
            CancelCmm = new DelegateCommand(Cancel);
        }

        /// <summary>
        /// 確定
        /// </summary>
        private void Confirm()
        {
            DialogParameters parameters = new DialogParameters();
            parameters.Add("result1", "返回的結果1");
            RequestClose?.Invoke(new DialogResult(ButtonResult.Yes, parameters));
        }

        /// <summary>
        /// 取消
        /// </summary>
        private void Cancel()
        {
            this.OnDialogClosed();
        }

        /// <summary>
        /// 是否能關閉對話框
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// 關閉對話框
        /// </summary>
        public void OnDialogClosed()
        {
            // 寫法1
            //if (RequestClose != null)
            //{
            //    RequestClose(new DialogResult(ButtonResult.No));
            //}

            // 寫法2+傳參數
            //DialogParameters parameters = new DialogParameters();
            //parameters.Add("result1", "返回的結果1");
            //parameters.Add("result2", "返回的結果2");

            //RequestClose?.Invoke(new DialogResult(ButtonResult.No, parameters));

            // 寫法2
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        /// <summary>
        /// 打開對話框
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("title"))
            {
                this.Title = parameters.GetValue<string>("title");
            }

            string p1 = parameters.GetValue<string>("para1");
            string p2 = parameters.GetValue<string>("para2");

            Console.WriteLine($"p1:{p1},p2:{p2}");
        }
    }
}