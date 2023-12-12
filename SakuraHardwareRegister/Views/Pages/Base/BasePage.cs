using MahApps.Metro.Controls.Dialogs;
using System.Windows;
using System.Windows.Controls;

namespace SakuraHardwareRegister.Views.Pages.Base
{
    public class BasePage : Page
    {
        // サイドバーメニュー表示切り替え
        protected void ParentSetSideBarMenuVisible(bool is_visible)
        {
            // 親ウィンドウ取得
            MainWindow parent = (MainWindow)Window.GetWindow(this);
            parent.SetSideBarMenuVisible(is_visible);
        }

        // 非同期メッセージ表示
        protected async void ParentShowMessage(string title, string message)
        {
            // 親ウィンドウ取得
            MainWindow parent = (MainWindow)Window.GetWindow(this);
            await parent.ShowMessageAsync(title, message);
        }

        // 同期確認メッセージ表示
        protected MessageDialogResult ParentShowDialogMessage(string title, string message)
        {
            // 親ウィンドウ取得
            MainWindow parent = (MainWindow)Window.GetWindow(this);
            // 戻り値ありのメッセージ表示
            return parent.ShowModalMessageExternal(
                title, message, MessageDialogStyle.AffirmativeAndNegative,
                new MetroDialogSettings { AffirmativeButtonText = "はい", NegativeButtonText = "いいえ", });
        }
    }
}
