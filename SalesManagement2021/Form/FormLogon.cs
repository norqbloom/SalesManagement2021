using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace SalesManagement2021
{
    public partial class FormLogon : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //パスワードハッシュ用クラスのインスタンス化
        PasswordHash passwordHash = new PasswordHash();

        public FormLogon()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            // フォームを閉じる確認メッセージの表示
            DialogResult result = messageDsp.DspMsg("M0004");

            if (result == DialogResult.OK)
            {
                // OKの時の処理
                this.Close();
            }
            else
            {
                FormMenu.loginName = "";
            }
        }

        private void buttonLogon_Click(object sender, EventArgs e)
        {
            string logonID = textBoxUserID.Text;
            string logonPass = textBoxPassword.Text;
            bool flg;
            //ユーザID・PWの入力状況チェック
            if (logonID.Trim() == "" || logonID == null || logonPass.Trim() == "" || logonPass == null)
            {
                //ID・PW未入力メッセージ
                messageDsp.DspMsg("M0002");
                return;
            }
            try
            {
                var pw = passwordHash.CreatePasswordHash(textBoxPassword.Text.Trim());

                //ユーザID・PWチェック
                var context = new SalesManagementDbContext();
                //ユーザID・PWが存在するか
                flg = context.M_Staffs.Any(x => x.StaffUserID == logonID && x.StaffPassword == pw && x.DeleteFlg == false);
                if (flg == true)
                {
                    //「M_Staff」テーブルから「M_Store」「M_Position」「M_Division]「M_Authority」参照
                    //スタッフCD、スタッフ名、スタッフ名カナ、店舗名で部分一致
                    //部分一致が未入力のの場合、全件表示
                    var tb = from t1 in context.M_Staffs
                             join t2 in context.M_Stores
                             on t1.StoreCD equals t2.StoreCD
                             join t3 in context.M_Authoritys
                             on t1.AuthorityCD equals t3.AuthorityCD
                             where t1.StaffUserID == logonID && t1.StaffPassword == pw
                             select new
                             {
                                 t1.StaffName,
                                 t2.StoreName,
                                 t3.AuthorityName,
                             };
                    foreach (var p in tb)
                    {
                        FormMenu.loginName = p.StaffName;
                        FormMenu.loginStore = p.StoreName;
                        FormMenu.loginAuthoritys = p.AuthorityName;
                        FormMenu.loginTime = DateTime.Now;
                    }
                    context.Dispose();
                    this.Close();

                }
                else
                {
                    //ID・PW不一致メッセージ
                    messageDsp.DspMsg("M0003");
                    return;
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormLogon_Load(object sender, EventArgs e)
        {

        }
    }
}
