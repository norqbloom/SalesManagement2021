using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement2021
{
    public partial class FormMenu : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();

        //他のフォームから変数の内容を共有できるように宣言
        internal static string loginName = "";
        internal static string loginStore = "";
        internal static string loginAuthoritys = "";
        internal static DateTime? loginTime = null;

        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            
        }
       
        private void buttonItem_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void buttonMaker_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void buttonCategory_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void buttonTax_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void buttonStaff_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void buttonPosition_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void buttonShop_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void buttonTransaction_Click(object sender, EventArgs e)
        {
            //OpenForm(((Button)sender).Text);
        }

        private void buttonSupplier_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void FormMenu_Activated(object sender, EventArgs e)
        {
            labelLogonUser.Text = "ログオンユーザー：" + loginName;
            labelBelongingShop.Text = "所属店舗：" + loginStore;
            labelAccessAuth.Text = "権限：" + loginAuthoritys;
            labelLogonTime.Text = "ログオン日時：" + loginTime;
            //メニュー、ボタンEnable設定
            if (loginName != "" && loginName != null)
            {
                SetEnable(true);
            }
            else
            {
                SetEnable(false);
            }
            if (Opacity == 0)
            {
                Opacity = 1;
            }
        }



        private void buttonLogon_Click(object sender, EventArgs e)
        {
            if (buttonLogon.Text == "ログオン")
                OpenForm(((Button)sender).Text);
            else
            {
                //ログアウト確認メッセージ
                DialogResult result = messageDsp.DspMsg("M0005");

                if (result == DialogResult.OK)
                {

                    SetEnable(false);

                }
            }
        }

        private void ToolStripMenuItemEnd_Click(object sender, EventArgs e)
        {
            // フォームを閉じる確認メッセージの表示
            DialogResult result = messageDsp.DspMsg("M0001");

            if (result == DialogResult.OK)
            {
                // OKの時の処理
                this.Close();
            }
            else
            {
                // キャンセルの時の処理
            }
        }

        ///////////////////////////////
        //メソッド名：SetEnable()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：ログオン状態でメニューのEnable設定
        //          ：ログオン中は、メニュー利用可
        //          ：ログアウト中は、メニュー利用不可
        ///////////////////////////////
        private void SetEnable(bool flg)
        {
            //メニューのEnable設定
            ToolStripMenuItemStock.Enabled = flg;
            ToolStripMenuItemOrder.Enabled = flg;
            ToolStripMenuItemItemM.Enabled = flg;
            ToolStripMenuItemStaffM.Enabled = flg;
            ToolStripMenuItemStoreM.Enabled = flg;
            if (loginAuthoritys == "管理者権限" || loginAuthoritys == "一般社員権限")
                ToolStripMenuItemSales.Enabled = flg;


            //ボタンのEnable設定
            buttonItem.Enabled = flg;
            buttonMaker.Enabled = flg;
            buttonCategory.Enabled = flg;
            buttonTax.Enabled = flg;
            buttonDivision.Enabled = flg;
            buttonPosition.Enabled = flg;
            buttonStaff.Enabled = flg;
            buttonShop.Enabled = flg;
            buttonTransaction.Enabled = flg;
            buttonSupplier.Enabled = flg;
            buttonStock.Enabled = flg;
            buttonOrder.Enabled = flg;
            if (loginAuthoritys == "管理者権限")
                buttonSystem.Enabled = flg;
            if (loginAuthoritys == "管理者権限" || loginAuthoritys == "一般社員権限")
                buttonSales.Enabled = flg;

            if (flg == true)
            {
                buttonLogon.Text = "ログアウト";
            }
            else
            {
                loginName = "";
                buttonLogon.Text = "ログオン";
                labelLogonUser.Text = "ログオンユーザー：";
                labelBelongingShop.Text = "所属店舗：";
                labelAccessAuth.Text = "権限：";
                labelLogonTime.Text = "ログオン日時：";

            }
        }

        ////////////////////////////////
        //メソッド名：OpenForm()
        //引　数   ：フォーム名称を示す値
        //戻り値   ：なし
        //機　能   ：メニューを透明化しフォームを開く
        ///////////////////////////////
        private void OpenForm(string formName)
        {
            Form frm = new Form();
            //引数より、開くフォームを設定
            switch (formName)
            {
                case "ログオン":
                    frm = new FormLogon();
                    break;
                case "商品マスター管理":
                    frm = new FormItem();
                    break;
                case "商品メーカマスター管理":
                    frm = new FormMaker();
                    break;
                case "商品カテゴリマスター管理":
                    frm = new FormCategory();
                    break;
                case "消費税マスター管理":
                    frm = new FormTax();
                    break;
                case "スタッフマスター管理":
                    frm = new FormStaff();
                    break;
                case "部署マスター管理":
                    frm = new FormDivision();
                    break;
                case "役職マスター管理":
                    frm = new FormPosition();
                    break;
                case "店舗マスター管理":
                    frm = new FormStore();
                    break;

            }

            //フォームを透明化
            Opacity = 0;

            //選択されたフォームを開く
            frm.ShowDialog();

            //開いたフォームから戻ってきたら
            //メモリを解放する
            frm.Dispose();
        }

        private void ToolStripMenuItemStore_Click(object sender, EventArgs e)
        {
            OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void ToolStripMenuItemTransaction_Click(object sender, EventArgs e)
        {
            //OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void ToolStripMenuItemSupplier_Click(object sender, EventArgs e)
        {
            //OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void ToolStripMenuItemStaff_Click(object sender, EventArgs e)
        {
            OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void ToolStripMenuItemDivision_Click(object sender, EventArgs e)
        {
            OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void ToolStripMenuItemPosition_Click(object sender, EventArgs e)
        {
            OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void ToolStripMenuItemItem_Click(object sender, EventArgs e)
        {
            OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void ToolStripMenuItemMaker_Click(object sender, EventArgs e)
        {
            OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void ToolStripMenuItemCategory_Click(object sender, EventArgs e)
        {
            OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void ToolStripMenuItemTax_Click(object sender, EventArgs e)
        {
            OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void ToolStripMenuItemOrder_Click(object sender, EventArgs e)
        {
            //OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void ToolStripMenuItemStock_Click(object sender, EventArgs e)
        {
            //OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void ToolStripMenuItemSales_Click(object sender, EventArgs e)
        {
            //OpenForm(((ToolStripMenuItem)sender).Text);
        }

        private void buttonSales_Click(object sender, EventArgs e)
        {
            //OpenForm(((Button)sender).Text);
        }

        private void buttonStock_Click(object sender, EventArgs e)
        {
            //OpenForm(((Button)sender).Text);
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            //OpenForm(((Button)sender).Text);
        }

        private void buttonSystem_Click(object sender, EventArgs e)
        {
            //OpenForm(((Button)sender).Text);
        }

        private void buttonShop_Click_1(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }
    }
}
