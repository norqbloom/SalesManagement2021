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
    public partial class FormStart : Form
    {
        public FormStart()
        {
            try
            {
                //DBの作成
                var context = new SalesManagementDbContext();
                context.M_Authoritys.Create();
                context.M_Categorys.Create();
                context.M_Divisions.Create();
                context.M_Positions.Create();
                context.M_Stores.Create();
                context.M_Taxs.Create();
                context.M_Items.Create();
                context.M_Staffs.Create();
                context.M_Messages.Create();
                context.SaveChanges();

                context.Dispose();

                //データインポート
                ImportData("M_Authority");
                ImportData("M_Category");
                ImportData("M_Division");
                ImportData("M_Position");
                ImportData("M_Maker");
                ImportData("M_Store");
                ImportData("M_Tax");
                ImportData("M_Item");
                ImportData("M_Staff");
                ImportData("M_Message");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            // フォームの境界線、タイトルバーを無しに設定
            this.FormBorderStyle = FormBorderStyle.None;

            // フォームの背景を黒に設定
            this.BackColor = Color.Black;

            // フォームの不透明度を設定（半透明化）
            this.Opacity = 0.8;
            // 丸み値
            int radius = 50;
            int diameter = radius * 2;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

            // 左上
            gp.AddPie(0, 0, diameter, diameter, 180, 90);
            // 右上
            gp.AddPie(this.Width - diameter, 0, diameter, diameter, 270, 90);
            // 左下
            gp.AddPie(0, this.Height - diameter, diameter, diameter, 90, 90);
            // 右下
            gp.AddPie(this.Width - diameter, this.Height - diameter, diameter, diameter, 0, 90);
            // 中央
            gp.AddRectangle(new Rectangle(radius, 0, this.Width - diameter, this.Height));
            // 左
            gp.AddRectangle(new Rectangle(0, radius, radius, this.Height - diameter));
            // 右
            gp.AddRectangle(new Rectangle(this.Width - radius, radius, radius, this.Height - diameter));

            this.Region = new Region(gp);

            //スプラッシュウィンドウの表示時間
            timer1.Interval = 3000;
        }
        ///////////////////////////////
        //メソッド名：ImportData()
        //引　数   ：ファイル名
        //戻り値   ：なし
        //機　能   ：メッセージテーブルを確認しデータが
        //          ：存在していなければインポート
        ///////////////////////////////
        private void ImportData(string strTbl)
        {
            try
            {
                var context = new SalesManagementDbContext();
                //DBのM_Messageテーブルデータ有無チェック
                //データが存在していなけばデータをインポート
                int cntMsg = context.Database.SqlQuery<int>("SELECT count(*) FROM [dbo].[" + strTbl + "]").First();
                context.Dispose();
                if (cntMsg > 0)
                    return;
                ImportData TblImport = new ImportData();
                TblImport.DataImport(strTbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
