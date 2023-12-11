using SakuraHardwareRegister.Common;
using SakuraHardwareRegister.Models;
using SakuraHardwareRegister.Views.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SakuraHardwareRegister.Views.Pages
{
    /// <summary>
    /// Login.xaml の相互作用ロジック
    /// </summary>
    public partial class Login : BasePage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ExecuteLogin(object sender, RoutedEventArgs e)
        {
            // 入力チェック
            CheckErrorItem error = new();
            if (string.IsNullOrEmpty(txtId.Text)) { error.AddError("IDは必須です"); }
            if (string.IsNullOrEmpty(txtPw.Password)) { error.AddError("PWは必須です"); }

            // ログインチェック（入力チェックでエラーの場合は処理しない）
            if (!error.HasError())
            {
                var user = Users.GetUser(txtId.Text, txtPw.Password);
                if (user is null) { error.AddError("IDまたはPWが異なります"); }
                else if (!user.Active_Flag) { error.AddError("ユーザーが削除されています"); }
            }

            // メッセージ表示
            if (error.HasError())
            {
                ParentShowMessage("エラー", error.GetError());
                return;
            }
            else
            {
                // サイドバーメニュー表示
                ParentSetSideBarMenuVisible(true);
                // メインページへ遷移
                NavigationService.Navigate(new TopMenu());
            }
        }
    }
}
