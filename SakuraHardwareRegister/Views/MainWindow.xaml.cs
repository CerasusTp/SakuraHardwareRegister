using MahApps.Metro.Controls;
using System.Collections.ObjectModel;
using MahApps.Metro.IconPacks;
using System.Windows;
using SakuraHardwareRegister.Common;
using SakuraHardwareRegister.Views.Pages;
using SakuraHardwareRegister.Models;
using MahApps.Metro.Controls.Dialogs;

namespace SakuraHardwareRegister.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // ユーザー情報保持
        public Users? LoginUser {  get; private set; }

        // サイドバーメニューの項目
        private ObservableCollection<HamburgerMenuItem> SideBarMenuItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // サイドメニュー項目の指定
            SideBarMenuItems = new ObservableCollection<HamburgerMenuItem> 
            {
                new SideBarMenuItem("トップ", PackIconMaterialKind.Home),
                new SideBarMenuItem("SSH", PackIconMaterialKind.Ssh)
            };
            // ログイン前はすべて非表示
            SetSideBarMenuVisible(false);
            // 関連付け
            SideBarMenu.ItemsSource = SideBarMenuItems;

            // 初期ページ
            MainFrame.Navigate(new Login());
        }

        // イベント
        // 戻るボタンで戻れないように履歴情報削除
        private void RemoveNavigationBackEntry(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (MainFrame.CanGoBack) { MainFrame.RemoveBackEntry(); }
        }

        // タイトルバーのログアウトボタン
        private void Click_TitleBtnLogout(object sender, RoutedEventArgs e)
        {
            // ログイン状態判定
            if (LoginUser is null)
            {
                this.ShowModalMessageExternal("ログアウト", "ログインしていません");
                return;
            }
            // メッセージ表示
            MessageDialogResult　resutl = this.ShowModalMessageExternal(
                                            "ログアウト", "ログアウトしてもよろしいでしょうか", 
                                            MessageDialogStyle.AffirmativeAndNegative,
                                            new MetroDialogSettings { 
                                                AffirmativeButtonText = "はい", 
                                                NegativeButtonText = "いいえ", });
            if (resutl.Equals(MessageDialogResult.Affirmative))
            {
                ExecuteLogout();
            }
        }

        // 専用メソッド
        // サイドバーメニュー切り替え
        internal void SetSideBarMenuVisible(bool is_visible)
        {
            foreach (HamburgerMenuItem items in SideBarMenuItems) 
            {
                items.IsVisible = is_visible;
            }
        }

        // ログイン
        internal void ExecuteLogin(Users user)
        {
            // ログイン情報保持
            LoginUser = user;
            // 画面遷移
            MainFrame.Navigate(new TopMenu());
            // サイドバーメニュー表示
            SetSideBarMenuVisible(true);
        }

        // ログアウト
        internal void ExecuteLogout()
        {
            // ログイン情報破棄
            LoginUser = null;
            // サイドバーメニュー非表示
            SetSideBarMenuVisible(false);
            // 画面遷移（ログインページ）
            MainFrame.Navigate(new Login());
        }
    }
}
