using MahApps.Metro.Controls;
using SakuraHardwareRegister.Views.Pages.Base;
using System.Collections.ObjectModel;
using MahApps.Metro.IconPacks;
using System.Windows;
using SakuraHardwareRegister.Common;
using SakuraHardwareRegister.Views.Pages;

namespace SakuraHardwareRegister.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
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

        public void SetSideBarMenuVisible(bool is_visible)
        {
            foreach (HamburgerMenuItem items in SideBarMenuItems) 
            {
                items.IsVisible = is_visible;
            }
        }

        // 戻るボタンで戻れないように履歴情報削除
        private void RemoveNavigationBackEntry(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (MainFrame.CanGoBack) { MainFrame.RemoveBackEntry(); }
        }

        // タイトルバーボタン（ログアウト）
        private void ExecuteLogout(object sender, RoutedEventArgs e)
        {
            SetSideBarMenuVisible(false);
            // ログインページ
            MainFrame.Navigate(new Login());
        }
    }
}
