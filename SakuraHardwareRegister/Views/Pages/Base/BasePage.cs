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
            MainWindow parent = (MainWindow)Window.GetWindow(this);
            parent.SetSideBarMenuVisible(is_visible);
        }

        // 非同期メッセージ表示
        protected async void ParentShowMessage(string title, string message)
        {
            MainWindow parent = (MainWindow)Window.GetWindow(this);
            await parent.ShowMessageAsync(title, message);
        }
    }
}
