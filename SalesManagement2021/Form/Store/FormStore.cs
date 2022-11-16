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
    public partial class FormStore : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース店舗テーブルアクセス用クラスのインスタンス化
        StoreDataAccess storeDataAccess = new StoreDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の店舗データ
        private static List<M_Store> Store;

        public FormStore()
        {
            InitializeComponent();
        }

        private void FormStore_Load(object sender, EventArgs e)
        {
            //ログイン名の表示
            labelLoginName.Text = FormMenu.loginName;

            // データグリッドビューの表示
            SetFormDataGridView();
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            // 7.1.1.1 妥当な店舗データ取得
            if (!GetValidDataAtRegistration())
                return;

            // 7.1.1.2 店舗情報作成
            var regStore = GenerateDataAtRegistration();

            // 7.1.1.3 店舗情報登録
            RegistrationStore(regStore);
        }
        ///////////////////////////////
        //　7.1.1.1 妥当な店舗データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {

            // 店舗CDの適否
            if (!String.IsNullOrEmpty(textBoxStoreCD.Text.Trim()))
            {
                // 店舗CDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxStoreCD.Text.Trim()))
                {
                    //MessageBox.Show("店舗CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M8001");
                    textBoxStoreCD.Focus();
                    return false;
                }
                // 店舗CDの文字数チェック
                if (textBoxStoreCD.TextLength != 5)
                {
                    //MessageBox.Show("店舗CDは5文字です");
                    messageDsp.DspMsg("M8002");
                    textBoxStoreCD.Focus();
                    return false;
                }
                
                // 店舗CDの重複チェック
                if (storeDataAccess.CheckStoreCDExistence(textBoxStoreCD.Text.Trim()))
                {
                    //MessageBox.Show("入力された店舗CDは既に存在します");
                    messageDsp.DspMsg("M8003");
                    textBoxStoreCD.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("店舗CDが入力されていません");
                messageDsp.DspMsg("M8004");
                textBoxStoreCD.Focus();
                return false;
            }
           
            // 店舗名の適否
            if (!String.IsNullOrEmpty(textBoxStoreName.Text.Trim()))
            {
                // 店舗名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxStoreName.Text.Trim()))
                {
                    //MessageBox.Show("店舗名は全て全角入力です");
                    messageDsp.DspMsg("M8005");
                    textBoxStoreName.Focus();
                    return false;
                }

                // 店舗名の文字数チェック
                if (textBoxStoreName.TextLength > 25)
                {
                    //MessageBox.Show("店舗名は25文字以下です");
                    messageDsp.DspMsg("M8006");
                    textBoxStoreName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("店舗名が入力されていません");
                messageDsp.DspMsg("M8007");
                textBoxStoreName.Focus();
                return false;
            }
            // 店舗名カナの適否
            if (!String.IsNullOrEmpty(textBoxStoreNameKana.Text.Trim()))
            {
                // 店舗名カナの全角チェック
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxStoreNameKana.Text.Trim()))
                {
                    //MessageBox.Show("店舗名カナは半角カタカナ入力です");
                    messageDsp.DspMsg("M8022");
                    textBoxStoreNameKana.Focus();
                    return false;
                }

                // 店舗名カナの文字数チェック
                if (textBoxStoreNameKana.TextLength > 50)
                {
                    //MessageBox.Show("店舗名カナは50文字以下です");
                    messageDsp.DspMsg("M8023");
                    textBoxStoreNameKana.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("店舗名カナが入力されていません");
                messageDsp.DspMsg("M8024");
                textBoxStoreNameKana.Focus();
                return false;
            }

            // 郵便番号の半角数値チェック
            if (!String.IsNullOrEmpty(textBoxPostal.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxPostal.Text.Trim()))
                {
                    //MessageBox.Show("郵便番号は半角数値です");
                    messageDsp.DspMsg("M8025");
                    textBoxPostal.Focus();
                    return false;
                }
                // 郵便番号の文字数チェック
                if (textBoxPostal.TextLength != 7)
                {
                    //MessageBox.Show("郵便番号は7文字です");
                    messageDsp.DspMsg("M8026");
                    textBoxPostal.Focus();
                    return false;
                }
            }

            // 住所の文字数チェック
            if (!String.IsNullOrEmpty(textBoxAddress.Text.Trim()))
            {
                if (textBoxAddress.TextLength > 50)
                {
                    //MessageBox.Show("住所は50文字以下です");
                    messageDsp.DspMsg("M8027");
                    textBoxAddress.Focus();
                    return false;
                }
            }
            // 住所カナの適否
            if (!String.IsNullOrEmpty(textBoxAddressKana.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxAddressKana.Text.Trim()))
                {
                    //MessageBox.Show("住所カナは半角カナ入力です");
                    messageDsp.DspMsg("M8028");
                    textBoxAddressKana.Focus();
                    return false;
                }
                // 住所カナの文字数チェック
                if (textBoxAddressKana.TextLength > 100)
                {
                    //MessageBox.Show("住所カナは半角で100文字以下です");
                    messageDsp.DspMsg("M8029");
                    textBoxAddressKana.Focus();
                    return false;
                }
            }
            
            // 電話番号の適否
            if(!String.IsNullOrEmpty(textBoxTel.Text.Trim()))
            {
                // 電話番号の数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxTel.Text.Trim()))
                {
                    //MessageBox.Show("電話番号は半角数値です");
                    messageDsp.DspMsg("M8030");
                    textBoxTel.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxTel.TextLength > 12)
                {
                    //MessageBox.Show("電話番号は12文字以下です");
                    messageDsp.DspMsg("M8031");
                    textBoxTel.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("電話番号が入力されていません");
                messageDsp.DspMsg("M8032");
                textBoxTel.Focus();
                return false;
            }
            

            // FAX番号の半角数値チェック
            if (!String.IsNullOrEmpty(textBoxFaxTel.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxFaxTel.Text.Trim()))
                {
                    //MessageBox.Show("FAX番号は半角数値です");
                    messageDsp.DspMsg("M8033");
                    textBoxFaxTel.Focus();
                    return false;
                }
                // FAX番号の文字数チェック
                if (textBoxFaxTel.TextLength > 12)
                {
                    //MessageBox.Show("FAX番号は12文字以下です");
                    messageDsp.DspMsg("M8034");
                    textBoxFaxTel.Focus();
                    return false;
                }
            }
            

            // メールアドレスの入力形式チェック
            if (!String.IsNullOrEmpty(textBoxMail.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckMailAddress(textBoxMail.Text.Trim()))
                {
                    //MessageBox.Show("メールアドレスの入力形式が不正です");
                    messageDsp.DspMsg("M8035");
                    textBoxMail.Focus();
                    return false;
                }
                // メールアドレスの文字数チェック
                if (textBoxMail.TextLength > 30)
                {
                    //MessageBox.Show("メールアドレスは30文字以下です");
                    messageDsp.DspMsg("M8036");
                    textBoxMail.Focus();
                    return false;
                }
            }
            
            // 削除フラグの適否
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("削除フラグが不確定の状態です");
                messageDsp.DspMsg("M8008");
                checkBoxDeleteFlg.Focus();
                return false;
            }

            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if (textBoxComments.TextLength > 80)
                {
                    //MessageBox.Show("備考は80文字以下です");
                    messageDsp.DspMsg("M8009");
                    textBoxComments.Focus();
                    return false;
                }
            }
            return true;
        }

        ///////////////////////////////
        //　7.1.1.2 店舗情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：店舗登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_Store GenerateDataAtRegistration()
        {
            return new M_Store
            {
                StoreCD = textBoxStoreCD.Text.Trim(),
                StoreName = textBoxStoreName.Text.Trim(),
                StoreNameKana = textBoxStoreNameKana.Text.Trim(),
                StorePostal = textBoxPostal.Text.Trim(),
                StoreAddress = textBoxAddress.Text.Trim(),
                StoreAddressKana = textBoxAddressKana.Text.Trim(),
                StoreTel = textBoxTel.Text.Trim(),
                StoreFax = textBoxFaxTel.Text.Trim(),
                StoreMail = textBoxMail.Text.Trim(),
                DeleteFlg = checkBoxDeleteFlg.Checked,
                Comments = textBoxComments.Text.Trim()
            };
        }

        ///////////////////////////////
        //　7.1.1.3 店舗情報登録
        //メソッド名：RegistrationStore()
        //引　数   ：店舗情報
        //戻り値   ：なし
        //機　能   ：店舗データの登録

        ///////////////////////////////
        private void RegistrationStore(M_Store regStore)
        {
            // 登録確認メッセージ
            DialogResult result = messageDsp.DspMsg("M8010");

            if (result == DialogResult.Cancel)
                return;

            // 店舗情報の登録
            bool flg = storeDataAccess.AddStoreData(regStore);
            if (flg == true)
                //MessageBox.Show("データを登録しました。");
                messageDsp.DspMsg("M8011");
            else
                //MessageBox.Show("データの登録に失敗しました。");
                messageDsp.DspMsg("M8012");

            textBoxStoreCD.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        ///////////////////////////////
        //メソッド名：SetFormDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの設定
        ///////////////////////////////
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

            // 店舗データの取得
            Store = storeDataAccess.GetStoreData();

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
            dataGridViewDsp.DataSource = Store.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGridViewDsp.Columns[0].Width = 100;
            dataGridViewDsp.Columns[1].Width = 100;
            dataGridViewDsp.Columns[2].Width = 100;
            dataGridViewDsp.Columns[3].Width = 100;
            dataGridViewDsp.Columns[3].Visible = false;
            dataGridViewDsp.Columns[4].Width = 150;
            dataGridViewDsp.Columns[4].Visible = false;
            dataGridViewDsp.Columns[5].Width = 150;
            dataGridViewDsp.Columns[5].Visible = false;
            dataGridViewDsp.Columns[6].Width = 150;
            dataGridViewDsp.Columns[7].Width = 150;
            dataGridViewDsp.Columns[8].Width = 150;
            dataGridViewDsp.Columns[9].Width = 100;
            dataGridViewDsp.Columns[10].Width = 400;

            //各列の文字位置の指定
            dataGridViewDsp.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Store.Count / (double)pageSize)) + "ページ";

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
            dataGridViewDsp.DataSource = Store.Take(pageSize).ToList();

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
            dataGridViewDsp.DataSource = Store.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            int lastNo = (int)Math.Ceiling(Store.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewDsp.DataSource = Store.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewDsp.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Store.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(Store.Count / (double)pageSize) - 1;
            dataGridViewDsp.DataSource = Store.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            dataGridViewPrinter.Preview("店舗管理");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 7.1.2.1 妥当な店舗データ取得
            if (!GetValidDataAtUpdate())
                return;

            // 7.1.2.2 店舗情報作成
            var updStore = GenerateDataAtUpdate();

            // 7.1.2.3 店舗情報更新
            UpdateStore(updStore);
        }
        ///////////////////////////////
        //　7.1.2.1 妥当な店舗データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {

            // 店舗CDの適否
            if (!String.IsNullOrEmpty(textBoxStoreCD.Text.Trim()))
            {
                // 店舗CDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxStoreCD.Text.Trim()))
                {
                    //MessageBox.Show("店舗CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M8001");
                    textBoxStoreCD.Focus();
                    return false;
                }
                // 店舗CDの文字数チェック
                if (textBoxStoreCD.TextLength != 5)
                {
                    //MessageBox.Show("店舗CDは5文字です");
                    messageDsp.DspMsg("M8002");
                    textBoxStoreCD.Focus();
                    return false;
                }

                // 店舗CDの重複チェック
                if (!storeDataAccess.CheckStoreCDExistence(textBoxStoreCD.Text.Trim()))
                {
                    //MessageBox.Show("入力された店舗CDは存在しません");
                    messageDsp.DspMsg("M8013");
                    textBoxStoreCD.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("店舗CDが入力されていません");
                messageDsp.DspMsg("M8004");
                textBoxStoreCD.Focus();
                return false;
            }

            // 店舗名の適否
            if (!String.IsNullOrEmpty(textBoxStoreName.Text.Trim()))
            {
                // 店舗名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxStoreName.Text.Trim()))
                {
                    //MessageBox.Show("店舗名は全て全角入力です");
                    messageDsp.DspMsg("M8005");
                    textBoxStoreName.Focus();
                    return false;
                }

                // 店舗名の文字数チェック
                if (textBoxStoreName.TextLength > 25)
                {
                    //MessageBox.Show("店舗名は25文字以下です");
                    messageDsp.DspMsg("M8006");
                    textBoxStoreName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("店舗名が入力されていません");
                messageDsp.DspMsg("M8007");
                textBoxStoreName.Focus();
                return false;
            }
            // 店舗名カナの適否
            if (!String.IsNullOrEmpty(textBoxStoreNameKana.Text.Trim()))
            {
                // 店舗名カナの半角カタカナチェック
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxStoreNameKana.Text.Trim()))
                {
                    //MessageBox.Show("店舗名カナは半角カタカナ入力です");
                    messageDsp.DspMsg("M8022");
                    textBoxStoreNameKana.Focus();
                    return false;
                }

                // 店舗名カナの文字数チェック
                if (textBoxStoreNameKana.TextLength > 50)
                {
                    //MessageBox.Show("店舗名カナは50文字以下です");
                    messageDsp.DspMsg("M8023");
                    textBoxStoreNameKana.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("店舗名カナが入力されていません");
                messageDsp.DspMsg("M8024");
                textBoxStoreNameKana.Focus();
                return false;
            }

            // 郵便番号の半角数値チェック
            if (!String.IsNullOrEmpty(textBoxPostal.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxPostal.Text.Trim()))
                {
                    //MessageBox.Show("郵便番号は半角数値です");
                    messageDsp.DspMsg("M8025");
                    textBoxPostal.Focus();
                    return false;
                }
                // 郵便番号の文字数チェック
                if (textBoxPostal.TextLength != 7)
                {
                    //MessageBox.Show("郵便番号は7文字です");
                    messageDsp.DspMsg("M8026");
                    textBoxPostal.Focus();
                    return false;
                }
            }

            // 住所の文字数チェック
            if (!String.IsNullOrEmpty(textBoxAddress.Text.Trim()))
            { 
                if (textBoxAddress.TextLength > 50)
                {
                    //MessageBox.Show("住所は50文字以下です");
                    messageDsp.DspMsg("M8027");
                    textBoxAddress.Focus();
                    return false;
                }
            }

            // 住所カナの半角カナチェック
            if (!String.IsNullOrEmpty(textBoxAddressKana.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxAddressKana.Text.Trim()))
                {
                    //MessageBox.Show("住所カナは半角カナ入力です");
                    messageDsp.DspMsg("M8028");
                    textBoxAddressKana.Focus();
                    return false;
                }
                // 住所カナの文字数チェック
                if (textBoxAddressKana.TextLength > 100)
                {
                    //MessageBox.Show("住所カナは半角で100文字以下です");
                    messageDsp.DspMsg("M8029");
                    textBoxAddressKana.Focus();
                    return false;
                }
            }

            // 電話番号の適否
            if (!String.IsNullOrEmpty(textBoxTel.Text.Trim()))
            {
                // 電話番号の数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxTel.Text.Trim()))
                {
                    //MessageBox.Show("電話番号は半角数値です");
                    messageDsp.DspMsg("M8030");
                    textBoxTel.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxTel.TextLength > 12)
                {
                    //MessageBox.Show("電話番号は12文字以下です");
                    messageDsp.DspMsg("M8031");
                    textBoxTel.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("電話番号が入力されていません");
                messageDsp.DspMsg("M8032");
                textBoxTel.Focus();
                return false;
            }
            
            // FAX番号の適否
            if (!String.IsNullOrEmpty(textBoxFaxTel.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxFaxTel.Text.Trim()))
                {
                    //MessageBox.Show("FAX番号は半角数値です");
                    messageDsp.DspMsg("M8033");
                    textBoxFaxTel.Focus();
                    return false;
                }
                // FAX番号の文字数チェック
                if (textBoxFaxTel.TextLength > 12)
                {
                    //MessageBox.Show("FAX番号は12文字以下です");
                    messageDsp.DspMsg("M8034");
                    textBoxFaxTel.Focus();
                    return false;
                }
            }

            // メールアドレスの適否
            if (!String.IsNullOrEmpty(textBoxMail.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckMailAddress(textBoxMail.Text.Trim()))
                {
                    //MessageBox.Show("メールアドレスの入力形式が不正です");
                    messageDsp.DspMsg("M8035");
                    textBoxMail.Focus();
                    return false;
                }
                // メールアドレスの文字数チェック
                if (textBoxMail.TextLength > 30)
                {
                    //MessageBox.Show("メールアドレスは30文字以下です");
                    messageDsp.DspMsg("M8036");
                    textBoxMail.Focus();
                    return false;
                }
            }
            // 削除フラグの適否
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("削除フラグが不確定の状態です");
                messageDsp.DspMsg("M8008");
                checkBoxDeleteFlg.Focus();
                return false;
            }

            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if (textBoxComments.TextLength > 80)
                {
                    //MessageBox.Show("備考は80文字以下です");
                    messageDsp.DspMsg("M8009");
                    textBoxComments.Focus();
                    return false;
                }
            }

            return true;
        }

        ///////////////////////////////
        //　7.1.2.2 店舗情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：店舗更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_Store GenerateDataAtUpdate()
        {
            return new M_Store
            {
                StoreCD = textBoxStoreCD.Text.Trim(),
                StoreName = textBoxStoreName.Text.Trim(),
                StoreNameKana = textBoxStoreNameKana.Text.Trim(),
                StorePostal = textBoxPostal.Text.Trim(),
                StoreAddress = textBoxAddress.Text.Trim(),
                StoreAddressKana = textBoxAddressKana.Text.Trim(),
                StoreTel = textBoxTel.Text.Trim(),
                StoreFax = textBoxFaxTel.Text.Trim(),
                StoreMail = textBoxMail.Text.Trim(),
                DeleteFlg = checkBoxDeleteFlg.Checked,
                Comments = textBoxComments.Text.Trim()
            };
        }

        ///////////////////////////////
        //　7.1.2.3 店舗情報更新
        //メソッド名：UpdateStore()
        //引　数   ：店舗情報
        //戻り値   ：なし
        //機　能   ：店舗情報の更新
        ///////////////////////////////
        private void UpdateStore(M_Store updStore)
        {
            // 更新確認メッセージ
            DialogResult result = messageDsp.DspMsg("M8014");

            if (result == DialogResult.Cancel)
                return;

            // 店舗情報の更新
            bool flg = storeDataAccess.UpdateStoreData(updStore);
            if (flg == true)
                //MessageBox.Show("データを更新しました。");
                messageDsp.DspMsg("M8015");
            else
                //MessageBox.Show("データの更新に失敗しました。");
                messageDsp.DspMsg("M8016");

            textBoxStoreCD.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

            return;

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
            textBoxStoreCD.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxStoreName.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[1].Value.ToString();
            textBoxStoreNameKana.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[2].Value.ToString();
            textBoxPostal.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[3].Value.ToString();
            textBoxAddress.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[4].Value.ToString();
            textBoxAddressKana.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[5].Value.ToString();
            textBoxTel.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[6].Value.ToString();
            textBoxFaxTel.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[7].Value.ToString();
            textBoxMail.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[8].Value.ToString();
            checkBoxDeleteFlg.Checked = bool.Parse(dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[9].Value.ToString());
            textBoxComments.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[10].Value.ToString();


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
            textBoxStoreCD.Text = "";
            textBoxStoreName.Text = "";
            textBoxStoreNameKana.Text = "";
            textBoxPostal.Text = "";
            textBoxAddress.Text = "";
            textBoxAddressKana.Text = "";
            textBoxTel.Text = "";
            textBoxFaxTel.Text = "";
            textBoxMail.Text = "";
            checkBoxDeleteFlg.Checked = false;
            textBoxComments.Text = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // 7.1.3.1 妥当な店舗データ取得
            if (!GetValidDataAtDelete())
                return;

            // 7.1.3.2 店舗情報削除
            DeleteStore();
        }
        ///////////////////////////////
        //　7.1.3.1 妥当な店舗データ取得
        //メソッド名：GetValidDataAtDelete()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtDelete()
        {

            // 店舗CDの適否
            if (!String.IsNullOrEmpty(textBoxStoreCD.Text.Trim()))
            {
                // 店舗CDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxStoreCD.Text.Trim()))
                {
                    //MessageBox.Show("店舗CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M8001");
                    textBoxStoreCD.Focus();
                    return false;
                }
                // 店舗CDの文字数チェック
                if (textBoxStoreCD.TextLength != 5)
                {
                    //MessageBox.Show("店舗CDは5文字です");
                    messageDsp.DspMsg("M8002");
                    textBoxStoreCD.Focus();
                    return false;
                }
                
                // 店舗CDの存在チェック
                if (!storeDataAccess.CheckStoreCDExistence(textBoxStoreCD.Text.Trim()))
                {
                    //MessageBox.Show("入力された店舗CDは存在しません");
                    messageDsp.DspMsg("M8013");
                    textBoxStoreCD.Focus();
                    return false;
                }

                // 店舗CDのスタッフマスタカスケードチェック
                if (storeDataAccess.CheckCascadeStaff(textBoxStoreCD.Text))
                {
                    //MessageBox.Show("入力された店舗CDは他で利用されているため削除できません");
                    messageDsp.DspMsg("M8017");
                    textBoxStoreCD.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("店舗CDが入力されていません");
                messageDsp.DspMsg("M8004");
                textBoxStoreCD.Focus();
                return false;
            }

            return true;
        }

        ///////////////////////////////
        //　7.1.3.2 店舗情報削除
        //メソッド名：DeleteDavision()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：店舗情報の削除
        ///////////////////////////////
        private void DeleteStore()
        {
            // 削除確認メッセージ
            DialogResult result = messageDsp.DspMsg("M8018");

            if (result == DialogResult.Cancel)
                return;

            // 店舗情報の更新
            bool flg = storeDataAccess.DeleteStoreData(textBoxStoreCD.Text);
            if (flg == true)
                //MessageBox.Show("データを削除しました。");
                messageDsp.DspMsg("M8019");
            else
                //MessageBox.Show("データの削除に失敗しました。");
                messageDsp.DspMsg("M8020");

            textBoxStoreCD.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 7.1.4.1 妥当な店舗データ取得
            if (!GetValidDataAtSelect())
                return;

            // 7.1.4.2 店舗情報抽出
            GenerateDataAtSelect();

            // 7.1.4.3 店舗抽出結果表示
            SetSelectData();
        }
        ///////////////////////////////
        //　7.1.4.1 妥当な店舗データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {

            // 店舗CD入力時チェック
            if (!String.IsNullOrEmpty(textBoxStoreCD.Text.Trim()))
            {
                // 店舗CDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxStoreCD.Text.Trim()))
                {
                    //MessageBox.Show("店舗CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M8001");
                    textBoxStoreCD.Focus();
                    return false;
                }
                // 店舗CDの文字数チェック
                if (textBoxStoreCD.TextLength > 5)
                {
                    //MessageBox.Show("店舗CDは5文字までです");
                    messageDsp.DspMsg("M8002");
                    textBoxStoreCD.Focus();
                    return false;
                }
                
            }
            // 店舗名入力時チェック
            if (!String.IsNullOrEmpty(textBoxStoreName.Text.Trim()))
            {
                // 店舗名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxStoreName.Text.Trim()))
                {
                    //MessageBox.Show("店舗名は全て全角入力です");
                    messageDsp.DspMsg("M8005");
                    textBoxStoreName.Focus();
                    return false;
                }

                // 店舗名の文字数チェック
                if (textBoxStoreName.TextLength > 25)
                {
                    //MessageBox.Show("店舗名は25文字以下です");
                    messageDsp.DspMsg("M8006");
                    textBoxStoreName.Focus();
                    return false;
                }

            }
            //店舗名カナ入力時のチェック
            if (!String.IsNullOrEmpty(textBoxStoreNameKana.Text.Trim()))
            {
                // 店舗名の半角カナチェック
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxStoreNameKana.Text.Trim()))
                {
                    //MessageBox.Show("店舗名カナは全て半角カナ入力です");
                    messageDsp.DspMsg("M8022");
                    textBoxStoreNameKana.Focus();
                    return false;
                }
                // 店舗名カナの文字数チェック
                if (textBoxStoreNameKana.TextLength > 50)
                {
                    //MessageBox.Show("店舗名カナは50文字以下です");
                    messageDsp.DspMsg("M8023");
                    textBoxStoreNameKana.Focus();
                    return false;
                }
            }

            //住所入力時のチェック
            if (!String.IsNullOrEmpty(textBoxAddress.Text.Trim()))
            {
                // 住所の文字数チェック
                if (textBoxAddress.TextLength > 50)
                {
                    //MessageBox.Show("住所は50文字以下です");
                    messageDsp.DspMsg("M8027");
                    textBoxAddress.Focus();
                    return false;
                }
            }

            //住所カナ入力時のチェック
            if (!String.IsNullOrEmpty(textBoxAddressKana.Text.Trim()))
            {
                // 住所カナの半角文字数チェック
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxAddressKana.Text.Trim()))
                {
                    //MessageBox.Show("住所カナは半角カナ入力です");
                    messageDsp.DspMsg("M8028");
                    textBoxAddressKana.Focus();
                    return false;
                }
                // 住所カナの文字数チェック
                if (textBoxAddressKana.TextLength > 100)
                {
                    //MessageBox.Show("住所カナは半角で100文字以下です");
                    messageDsp.DspMsg("M8029");
                    textBoxAddressKana.Focus();
                    return false;
                }
            }

            return true;

        }
        ///////////////////////////////
        //　7.1.4.2 店舗情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：店舗情報の取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            // 検索条件のセット
            M_Store selectCondition = new M_Store()
            {
                StoreCD = textBoxStoreCD.Text.Trim(),
                StoreName = textBoxStoreName.Text.Trim(),
                StoreNameKana = textBoxStoreNameKana.Text.Trim(),
                StoreAddress = textBoxAddress.Text.Trim(),
                StoreAddressKana = textBoxAddressKana.Text.Trim()
            };
            // 店舗データの抽出
            Store = storeDataAccess.GetStoreData(selectCondition);

        }
        ///////////////////////////////
        //　7.1.4.3 店舗抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：店舗情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPageNo.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewDsp.DataSource = Store;

            labelPage.Text = "/" + ((int)Math.Ceiling(Store.Count / (double)pageSize)) + "ページ";
            dataGridViewDsp.Refresh();
        }
    }
}
