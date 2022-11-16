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
    public partial class FormTax : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース消費税テーブルアクセス用クラスのインスタンス化
        TaxDataAccess taxDataAccess = new TaxDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の消費税データ
        private static List<M_Tax> Tax;

        public FormTax()
        {
            InitializeComponent();
        }

        private void FormTax_Load(object sender, EventArgs e)
        {
            //ログイン名の表示
            labelLoginName.Text = FormMenu.loginName;

            // データグリッドビューの表示
            SetFormDataGridView();
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            // 5.4.1.1 妥当な消費税データ取得


            // 5.4.1.2 消費税情報作成


            // 5.4.1.3 消費税情報登録

        }
        ///////////////////////////////
        //　5.4.1.1 妥当な消費税データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {

            
            return true;
        }

        ///////////////////////////////
        //　5.4.1.2 消費税情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：消費税登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_Tax GenerateDataAtRegistration()
        {
            return new M_Tax
            {
                
            };
        }

        ///////////////////////////////
        //　5.4.1.3 消費税情報登録
        //メソッド名：RegistrationTax()
        //引　数   ：消費税情報
        //戻り値   ：なし
        //機　能   ：消費税データの登録

        ///////////////////////////////
        private void RegistrationTax(M_Tax regTax)
        {
           

        }
        ///////////////////////////////
        //メソッド名：SetFormDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの設定
        //////////////////////////////
        private void SetFormDataGridView()
        {
            //dataGridViewのページサイズ指定
            textBoxPageSize.Text = "10";
            //dataGridViewのページ番号指定
            textBoxPageNo.Text = "1";
            //読み取り専用に指定
            dataGridViewDsp.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGridViewDsp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGridViewDsp.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            GetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetDataGridView()
        {

            // 消費税データの取得
            Tax = taxDataAccess.GetTaxData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }

        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューへの表示
        ///////////////////////////////
        private void SetDataGridView()
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPageNo.Text) - 1;
            dataGridViewDsp.DataSource = Tax.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGridViewDsp.Columns[0].Width = 100;
            dataGridViewDsp.Columns[1].Width = 100;
            dataGridViewDsp.Columns[2].Width = 200;
            dataGridViewDsp.Columns[3].Width = 100;
            dataGridViewDsp.Columns[4].Width = 400;


            //各列の文字位置の指定
            dataGridViewDsp.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewDsp.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Tax.Count / (double)pageSize)) + "ページ";

            dataGridViewDsp.Refresh();

        }
        ///////////////////////////////
        //メソッド名：buttonPageSizeChange_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：buttonFirstPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの先頭ページ表示
        ///////////////////////////////
        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewDsp.DataSource = Tax.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewDsp.Refresh();
            //ページ番号の設定
            textBoxPageNo.Text = "1";
        }
        ///////////////////////////////
        //メソッド名：buttonPreviousPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの前ページ表示
        ///////////////////////////////
        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPageNo.Text) - 2;
            dataGridViewDsp.DataSource = Tax.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewDsp.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                textBoxPageNo.Text = (pageNo + 1).ToString();
            else
                textBoxPageNo.Text = "1";
        }
        ///////////////////////////////
        //メソッド名：buttonNextPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの次ページ表示
        ///////////////////////////////
        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPageNo.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Tax.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewDsp.DataSource = Tax.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewDsp.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Tax.Count / (double)pageSize);
            if (pageNo >= lastPage)
                textBoxPageNo.Text = lastPage.ToString();
            else
                textBoxPageNo.Text = (pageNo + 1).ToString();
        }
        ///////////////////////////////
        //メソッド名：buttonLastPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの最終ページ表示
        ///////////////////////////////
        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Tax.Count / (double)pageSize) - 1;
            dataGridViewDsp.DataSource = Tax.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewDsp.Refresh();
            //ページ番号の設定
            textBoxPageNo.Text = (pageNo + 1).ToString();
        }
        ///////////////////////////////
        //メソッド名：buttonPrint_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示データを印刷
        ///////////////////////////////
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            // 印刷設定クラスのインスタンス化
            DataGridViewPrinter dataGridViewPrinter = new DataGridViewPrinter(dataGridViewDsp);
            // 印刷ドキュメント名を指定して、印刷プレビュー
            dataGridViewPrinter.Preview("消費税管理");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 5.4.2.1 妥当な消費税データ取得


            // 5.4.2.2 消費税情報作成


            // 5.4.2.3 消費税情報更新

        }
        ///////////////////////////////
        //　5.4.2.1 妥当な消費税データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {

            
            return true;
        }

        ///////////////////////////////
        //　5.4.2.2 消費税情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：消費税更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_Tax GenerateDataAtUpdate()
        {
            return new M_Tax
            {

            };
        }

        ///////////////////////////////
        //　5.4.2.3 消費税情報更新
        //メソッド名：UpdateTax()
        //引　数   ：消費税情報
        //戻り値   ：なし
        //機　能   ：消費税情報の更新
        ///////////////////////////////
        private void UpdateTax(M_Tax updTax)
        {
            

        }
        ///////////////////////////////
        //メソッド名：dataGridViewDsp_CellClick()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューから選択された情報を各入力エリアにセット
        ///////////////////////////////
        private void dataGridViewDsp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            // 画面を閉じ、メモリを解放する
            Dispose();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            // ログアウト確認メッセージ
            DialogResult result = messageDsp.DspMsg("M0005");
            
            if (result == DialogResult.OK)
            {
                // OKの時の処理
                FormMenu.loginName = "";
                Dispose();
            }
            else
            {
                // キャンセルの時の処理
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            SetFormDataGridView();
        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // 5.4.3.1 妥当な消費税データ取得


            // 5.4.3.2 消費税情報削除

        }
        ///////////////////////////////
        //　5.4.3.1 妥当な消費税データ取得
        //メソッド名：GetValidDataAtDelete()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtDelete()
        {

          
            return true;
        }

        ///////////////////////////////
        //　5.4.3.2 消費税情報削除
        //メソッド名：DeleteDavision()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：消費税情報の削除
        ///////////////////////////////
        private void DeleteTax()
        {
           

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 5.4.4.1 妥当な消費税データ取得


            // 5.4.4.2 消費税情報抽出


            // 5.4.4.3 消費税抽出結果表示

        }
        ///////////////////////////////
        //　5.4.4.1 妥当な消費税データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
           
            return true;

        }
        ///////////////////////////////
        //　5.4.4.2 消費税情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：消費税情報の取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            // 検索条件のセット


            // 消費税データの抽出


        }
        ///////////////////////////////
        //　5.4.4.3 消費税抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：消費税情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPageNo.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewDsp.DataSource = Tax;

            labelPage.Text = "/" + ((int)Math.Ceiling(Tax.Count / (double)pageSize)) + "ページ";
            dataGridViewDsp.Refresh();
        }
    }
}
