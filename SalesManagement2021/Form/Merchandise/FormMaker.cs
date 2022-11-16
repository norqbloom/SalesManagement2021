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
    public partial class FormMaker : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース商品メーカテーブルアクセス用クラスのインスタンス化
        MakerDataAccess makerDataAccess = new MakerDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の商品メーカデータ
        private static List<M_Maker> Maker;

        public FormMaker()
        {
            InitializeComponent();
        }

        private void FormMaker_Load(object sender, EventArgs e)
        {
            //ログイン名の表示
            labelLoginName.Text = FormMenu.loginName;

            // データグリッドビューの表示
            SetFormDataGridView();
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            // 5.1.1.1 妥当な商品メーカデータ取得
            if (!GetValidDataAtRegistration())
            {
                return;
            }

            // 5.1.1.2 商品メーカ情報作成
            var regMaker = GenerateDataAtRegistration();

            // 5.1.1.3 商品メーカ情報登録
            RegistrationMaker(regMaker);
        }
        ///////////////////////////////
        //　5.1.1.1 妥当な商品メーカデータ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //商品メーカーCDの適否の開始//
            if (!String.IsNullOrEmpty(textBoxMakerCD.Text.Trim()))
            {
                //文字種//
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxMakerCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M6001");
                    textBoxMakerCD.Focus();
                    return false;
                }
                //文字数//
                if (textBoxMakerCD.TextLength != 5)
                {
                    messageDsp.DspMsg("M6002");
                    textBoxMakerCD.Focus();
                    return false;
                }
                //存在なしチェック//
                if (makerDataAccess.CheckMakerCDExistence(textBoxMakerCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M6003");
                    textBoxMakerCD.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M6004");
                textBoxMakerCD.Focus();
                return false;
            }
            //商品メーカーCDの適否の終了//

            //商品メーカー名の適否の開始//
            if (!String.IsNullOrEmpty(textBoxMakerName.Text.Trim()))
            {
                //文字種//
                if (!dataInputFormCheck.CheckFullWidth(textBoxMakerName.Text))
                {
                    messageDsp.DspMsg("M6005");
                    textBoxMakerName.Focus();
                    return false;
                }
                //文字数//
                if (textBoxMakerName.TextLength > 25)
                {
                    messageDsp.DspMsg("M6006");
                    textBoxMakerName.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M6007");
                textBoxMakerName.Focus();
                return false;
            }
            //商品メーカー名の適否の終了//

            //商品メーカカナ名の適否の開始//
            if (!String.IsNullOrEmpty(textBoxMakerKana.Text.Trim()))
            {
                //文字種//
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxMakerKana.Text))
                {
                    messageDsp.DspMsg("M6022");
                    textBoxMakerKana.Focus();
                    return false;
                }
                //文字数//
                if (textBoxMakerKana.TextLength > 50)
                {
                    messageDsp.DspMsg("M6023");
                    textBoxMakerKana.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M6024");
                textBoxMakerKana.Focus();
                return false;
            }
            //商品メーカカナ名の適否の終了//

            //削除フラグの適否の開始//
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                messageDsp.DspMsg("M6008");
                textBoxMakerName.Focus();
                return false;
            }
            //削除フラグの適否の終了//

            //備考の適否の開始//
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if(textBoxComments.TextLength > 80)
                {
                    messageDsp.DspMsg("M6009");
                    textBoxComments.Focus();
                    return false;
                }
            }
            //備考の適否の終了//
            return true;
        }

    ///////////////////////////////
    //　5.1.1.2 商品メーカ情報作成
    //メソッド名：GenerateDataAtRegistration()
    //引　数   ：なし
    //戻り値   ：商品メーカ登録情報
    //機　能   ：登録データのセット
    ///////////////////////////////
    private M_Maker GenerateDataAtRegistration()
        {
            return new M_Maker
            {
              MakerCD = textBoxMakerCD.Text.Trim(),
              MakerName = textBoxMakerName.Text.Trim(),
              MakerKana = textBoxMakerKana.Text.Trim(),
              Comments = textBoxComments.Text.Trim(),
            };
        }

        ///////////////////////////////
        //　5.1.1.3 商品メーカ情報登録
        //メソッド名：RegistrationMaker()
        //引　数   ：商品メーカ情報
        //戻り値   ：なし
        //機　能   ：商品メーカデータの登録

        ///////////////////////////////
        private void RegistrationMaker(M_Maker regMaker)
        {
            DialogResult result = messageDsp.DspMsg("M6010");
            
            if(result == DialogResult.Cancel)
            {
                return;
            }

            bool flg = makerDataAccess.AddMakerData(regMaker);
            if(flg == true)
            {
                messageDsp.DspMsg("M6011");
            }
            else
            {
                messageDsp.DspMsg("M6012");
            }
            textBoxMakerCD.Focus();
            ClearInput();
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

            // 商品メーカデータの取得
            Maker = makerDataAccess.GetMakerData();

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
            dataGridViewDsp.DataSource = Maker.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGridViewDsp.Columns[0].Width = 100;
            dataGridViewDsp.Columns[1].Width = 200;
            dataGridViewDsp.Columns[2].Width = 200;
            dataGridViewDsp.Columns[3].Width = 100;
            dataGridViewDsp.Columns[4].Width = 400;

            //各列の文字位置の指定
            dataGridViewDsp.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Maker.Count / (double)pageSize)) + "ページ";

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
            dataGridViewDsp.DataSource = Maker.Take(pageSize).ToList();

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
            dataGridViewDsp.DataSource = Maker.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            int lastNo = (int)Math.Ceiling(Maker.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewDsp.DataSource = Maker.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewDsp.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Maker.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(Maker.Count / (double)pageSize) - 1;
            dataGridViewDsp.DataSource = Maker.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            dataGridViewPrinter.Preview("商品メーカ管理");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 5.1.2.1 妥当な商品メーカデータ取得
            if (!GetValidDataAtUpdate())
            {
                return;
            }

            // 5.1.2.2 商品メーカ情報作成
            var updMaker = GenerateDataAtUpdate();

            // 5.1.2.3 商品メーカ情報更新
            UpdateMaker(updMaker);
        }
        ///////////////////////////////
        //　5.1.2.1 妥当な商品メーカデータ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {
            //商品メーカーCDの適否の開始//
            if (!String.IsNullOrEmpty(textBoxMakerCD.Text.Trim()))
            {
                //文字種//
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxMakerCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M6001");
                    textBoxMakerCD.Focus();
                    return false;
                }
                //文字数//
                if (textBoxMakerCD.TextLength != 5)
                {
                    messageDsp.DspMsg("M6002");
                    textBoxMakerCD.Focus();
                    return false;
                }
                //存在なしチェック//
                if (!makerDataAccess.CheckMakerCDExistence(textBoxMakerCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M6013");
                    textBoxMakerCD.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M6004");
                textBoxMakerCD.Focus();
                return false;
            }
            //商品メーカーCDの適否の終了//

            //商品メーカー名の適否の開始//
            if (!String.IsNullOrEmpty(textBoxMakerName.Text.Trim()))
            {
                //文字種//
                if (!dataInputFormCheck.CheckFullWidth(textBoxMakerName.Text))
                {
                    messageDsp.DspMsg("M6005");
                    textBoxMakerName.Focus();
                    return false;
                }
                //文字数//
                if (textBoxMakerName.TextLength > 25)
                {
                    messageDsp.DspMsg("M6006");
                    textBoxMakerName.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M6007");
                textBoxMakerName.Focus();
                return false;
            }
            //商品メーカー名の適否の終了//

            //商品メーカカナ名の適否の開始//
            if (!String.IsNullOrEmpty(textBoxMakerKana.Text.Trim()))
            {
                //文字種//
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxMakerKana.Text))
                {
                    messageDsp.DspMsg("M6022");
                    textBoxMakerKana.Focus();
                    return false;
                }
                //文字数//
                if (textBoxMakerKana.TextLength > 50)
                {
                    messageDsp.DspMsg("M6023");
                    textBoxMakerKana.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M6024");
                textBoxMakerKana.Focus();
                return false;
            }
            //商品メーカカナ名の適否の終了//

            //削除フラグの適否の開始//
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                messageDsp.DspMsg("M6008");
                textBoxMakerName.Focus();
                return false;
            }
            //削除フラグの適否の終了//

            //備考の適否の開始//
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if (textBoxComments.TextLength > 80)
                {
                    messageDsp.DspMsg("M6009");
                    textBoxComments.Focus();
                    return false;
                }
            }
            //備考の適否の終了//
            return true;
        }

        ///////////////////////////////
        //　5.1.2.2 商品メーカ情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：商品メーカ更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_Maker GenerateDataAtUpdate()
        {
            return new M_Maker
            {
               MakerCD = textBoxMakerCD.Text.Trim(),
               MakerName = textBoxMakerName.Text.Trim(),
               MakerKana = textBoxMakerKana.Text.Trim(),
               DeleteFlg = checkBoxDeleteFlg.Checked,
               Comments = textBoxComments.Text.Trim()
            };
        }

        ///////////////////////////////
        //　5.1.2.3 商品メーカ情報更新
        //メソッド名：UpdateMaker()
        //引　数   ：商品メーカ情報
        //戻り値   ：なし
        //機　能   ：商品メーカ情報の更新
        ///////////////////////////////
        private void UpdateMaker(M_Maker updMaker)
        {
            DialogResult result = messageDsp.DspMsg("M6014");

            if (result == DialogResult.Cancel)
            {
                return;
            }

            bool flg = makerDataAccess.UpdateMakerData(updMaker);
            if (flg == true)
            {
                messageDsp.DspMsg("M6015");
            }
            else
            {
                messageDsp.DspMsg("M6016");
            }
            textBoxMakerCD.Focus();
            ClearInput();
            GetDataGridView();

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
            textBoxMakerCD.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxMakerName.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[1].Value.ToString();
            textBoxMakerKana.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[2].Value.ToString();
            checkBoxDeleteFlg.Checked = bool.Parse(dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[3].Value.ToString());
            textBoxComments.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[4].Value.ToString();
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
            textBoxMakerCD.Text = "";
            textBoxMakerName.Text = "";
            textBoxMakerKana.Text = "";
            textBoxComments.Text = "";
            checkBoxDeleteFlg.Checked = false;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // 5.1.3.1 妥当な商品メーカデータ取得
            if (!GetValidDataAtDelete())
            {
                return;
            }

            // 5.1.3.2 商品メーカ情報削除
            DeleteMaker();
        }
        ///////////////////////////////
        //　5.1.3.1 妥当な商品メーカデータ取得
        //メソッド名：GetValidDataAtDelete()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtDelete()
        {
            if (!String.IsNullOrEmpty(textBoxMakerCD.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxMakerCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M6001");
                    textBoxMakerCD.Focus();
                    return false;
                }
                if(textBoxMakerCD.TextLength != 5)
                {
                    messageDsp.DspMsg("M6002");
                    textBoxMakerCD.Focus();
                    return false;
                }
                if (!makerDataAccess.CheckMakerCDExistence(textBoxMakerCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M6013");
                    textBoxMakerCD.Focus();
                    return false;
                }
                if (makerDataAccess.CheckCascadeItem(textBoxMakerCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M6017");
                    textBoxMakerCD.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M6004");
                textBoxMakerCD.Focus();
                return false;
            }
            return true;
        }

        ///////////////////////////////
        //　5.1.3.2 商品メーカ情報削除
        //メソッド名：DeleteDavision()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品メーカ情報の削除
        ///////////////////////////////
        private void DeleteMaker()
        {
            DialogResult result = messageDsp.DspMsg("M6018");

            if(result == DialogResult.Cancel)
            {
                return;
            }

            bool flg = makerDataAccess.DeleteMakerData(textBoxMakerCD.Text.Trim());

            if (flg == true) 
            {
                messageDsp.DspMsg("M6019");
            }
            else
            {
                messageDsp.DspMsg("M6020");
            }
            textBoxMakerCD.Focus();
            ClearInput();
            GetDataGridView();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 5.1.4.1 妥当な商品メーカデータ取得
            if (!GetValidDataAtSelect())
            {
                return;
            }

            // 5.1.4.2 商品メーカ情報抽出
            GenerateDataAtSelect();

            // 5.1.4.3 商品メーカ抽出結果表示
            SetSelectData();
        }
        ///////////////////////////////
        //　5.1.4.1 妥当な商品メーカデータ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            if (!String.IsNullOrEmpty(textBoxMakerCD.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxMakerCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M6001");
                    textBoxMakerCD.Focus();
                    return false;
                }
                if(textBoxMakerCD.TextLength > 5)
                {
                    messageDsp.DspMsg("M6021");
                    textBoxMakerCD.Focus();
                    return false;
                }
            }

            if (!String.IsNullOrEmpty(textBoxMakerCD.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckFullWidth(textBoxMakerName.Text.Trim()))
                {
                    messageDsp.DspMsg("M6005");
                    textBoxMakerName.Focus();
                    return false;
                }
                if(textBoxMakerName.TextLength > 25)
                {
                    messageDsp.DspMsg("M6006");
                    textBoxMakerName.Focus();
                    return false;
                }
            }

            if (String.IsNullOrEmpty(textBoxMakerKana.Text.Trim()))
            {
                if (dataInputFormCheck.CheckHalfWidthKatakana(textBoxMakerKana.Text))
                {
                    messageDsp.DspMsg("M6022");
                    textBoxMakerKana.Focus();
                    return false;
                }
                if (textBoxMakerKana.TextLength > 50)
                {
                    messageDsp.DspMsg("M6023");
                    textBoxMakerKana.Focus();
                    return false;
                }
            }
            return true;

        }
        ///////////////////////////////
        //　5.1.4.2 商品メーカ情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品メーカ情報の取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            // 検索条件のセット
            M_Maker selectCondition = new M_Maker()
            {
                MakerCD = textBoxMakerCD.Text.Trim(),
                MakerName = textBoxMakerName.Text.Trim(),
                MakerKana = textBoxMakerKana.Text.Trim()
            };

            // 商品メーカデータの抽出
            Maker = makerDataAccess.GetMakerData(selectCondition);
        }
        ///////////////////////////////
        //　5.1.4.3 商品メーカ抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品メーカ情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPageNo.Text = "1";
            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewDsp.DataSource = Maker;
            labelPage.Text = "/" + ((int)Math.Ceiling(Maker.Count / (double)pageSize)) + "ページ";
            dataGridViewDsp.Refresh();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
