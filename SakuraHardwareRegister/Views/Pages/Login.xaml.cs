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
            // ユーザー情報保持（ログインセッションの間のみ）
            Users? user;
            // 入力チェック
            CheckErrorItem error = new();
            if (string.IsNullOrEmpty(txtId.Text)) { error.AddError("IDは必須です"); }
            if (string.IsNullOrEmpty(txtPw.Password)) { error.AddError("PWは必須です"); }

            // 入力チェックのメッセージ表示
            if (error.HasError())
            {
                ParentShowMessage("エラー", error.GetError());
                return;
            }

            // ログインチェック
            user = Users.SingleSelect(txtId.Text, txtPw.Password);
            if (user is null)
            {
                // ユーザー情報がないとき
                ParentShowMessage("エラー", "IDまたはPWが異なります");
            } else if (!user.Active_Flag)
            {
                // ユーザーが削除されている場合のみ別のメッセージ表示
                ParentShowMessage("エラー", "ユーザーが削除されています");
            } else
            {
                // 親ウィンドウ取得
                MainWindow parent = (MainWindow)Window.GetWindow(this);
                // ログイン
                parent.ExecuteLogin(user);
            }
        }
    }
}
