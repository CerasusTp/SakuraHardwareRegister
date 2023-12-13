using SakuraHardwareRegister.Common;
using SakuraHardwareRegister.Models;
using SakuraHardwareRegister.Views.Pages.Base;
using System.Windows;

namespace SakuraHardwareRegister.Views.Pages
{
    /// <summary>
    /// EditLocation.xaml の相互作用ロジック
    /// </summary>
    public partial class EditLocation : BasePage
    {
        public EditLocation()
        {
            InitializeComponent();
        }

        private void CreateLocation(object sender, RoutedEventArgs e)
        {
            // エラーチェック
            CheckErrorItem error = new();
            if (string.IsNullOrEmpty(txtLocation.Text)) error.AddError("拠点名は必須です");

            // エラーがある場合は終了
            if (error.HasError())
            {
                ParentShowMessage("エラー", error.GetError());
                return;
            }

            // 拠点情報保存
            new Locations { Name = txtLocation.Text, Active_Flag = true }.Insert();

            // サイドバーメニュー表示
            ParentSetSideBarMenuVisible(true);

            // 画面遷移
            NavigationService.Navigate(new TopMenu());
        }
    }
}
