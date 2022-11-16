using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement2021
{
    public partial class FormDivision : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース部署テーブルアクセス用クラスのインスタンス化
        DivisionDataAccess divisionDataAccess = new DivisionDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の部署データ
        private static List<M_Division> Division;

        public FormDivision()
        {
            InitializeComponent();
        }
        private void FormDivision_Load(object sender, EventArgs e)
        {
            //ログイン名の表示
            labelLoginName.Text = FormMenu.loginName;

            // データグリッドビューの表示
            SetFormDataGridView();

        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            // 8.1.1.1 妥当な部署データ取得
            if (!GetValidDataAtRegistration())
                return;

            // 8.1.1.2 部署情報作成
            var regDivision = GenerateDataAtRegistration();

            // 8.1.1.3 部署情報登録
            RegistrationDivision(regDivision);

        }

        ///////////////////////////////
        //　8.1.1.1 妥当な部署データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {

            // 部署CDの適否
            if (!String.IsNullOrEmpty(textBoxDivisionCD.Text.Trim()))
            {
                // 部署CDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxDivisionCD.Text.Trim()))
                {
                    //MessageBox.Show("部署CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M1001");
                    textBoxDivisionCD.Focus();
                    return false;
                }
                // 部署CDの文字数チェック
                if (textBoxDivisionCD.TextLength != 5)
                {
                    //MessageBox.Show("部署CDは5文字です");
                    messageDsp.DspMsg("M1002");
                    textBoxDivisionCD.Focus();
                    return false;
                }
                // 部署CDの重複チェック
                if (divisionDataAccess.CheckDivisionCDExistence(textBoxDivisionCD.Text.Trim()))
                {
                    //MessageBox.Show("入力された部署CDは既に存在します");
                    messageDsp.DspMsg("M1003");
                    textBoxDivisionCD.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("部署CDが入力されていません");
                messageDsp.DspMsg("M1004");
                textBoxDivisionCD.Focus();
                return false;
            }

            
            // 部署名の適否
            if (!String.IsNullOrEmpty(textBoxDivisionName.Text.Trim()))
            {
                // 部署名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxDivisionName.Text.Trim()))
                {
                    //MessageBox.Show("部署名は全て全角入力です");
                    messageDsp.DspMsg("M1005");
                    textBoxDivisionName.Focus();
                    return false;
                }
                // 部署名の文字数チェック
                if (textBoxDivisionName.TextLength > 25)
                {
                    //MessageBox.Show("部署名は25文字以下です");
                    messageDsp.DspMsg("M1006");
                    textBoxDivisionName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("部署名が入力されていません");
                messageDsp.DspMsg("M1007");
                textBoxDivisionName.Focus();
                return false;
            }

            // 削除フラグの適否
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("削除フラグが不確定の状態です");
                messageDsp.DspMsg("M1008");
                checkBoxDeleteFlg.Focus();
                return false;
            }

            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if (textBoxComments.TextLength > 80)
                {
                    //MessageBox.Show("備考は80文字以下です");
                    messageDsp.DspMsg("M1009");
                    textBoxComments.Focus();
                    return false;
                }
            }

            return true;
        }

        ///////////////////////////////
        //　8.1.1.2 部署情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：部署登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_Division GenerateDataAtRegistration()
        {
            return new M_Division
            {
                DivisionCD = textBoxDivisionCD.Text.Trim(),
                DivisionName = textBoxDivisionName.Text.Trim(),
                DeleteFlg = checkBoxDeleteFlg.Checked,
                Comments = textBoxComments.Text.Trim(),
            };
        }

        ///////////////////////////////
        //　8.1.1.3 部署情報登録
        //メソッド名：RegistrationDivision()
        //引　数   ：部署情報
        //戻り値   ：なし
        //機　能   ：部署データの登録

        ///////////////////////////////
        private void RegistrationDivision(M_Division regDivision)
        {
            // 登録確認メッセージ
            DialogResult result = messageDsp.DspMsg("M1010");
            
            if (result == DialogResult.Cancel)
                return;

            // 部署情報の登録
            bool flg = divisionDataAccess.AddDivisionData(regDivision);
            if (flg == true)
                //MessageBox.Show("データを登録しました。");
                messageDsp.DspMsg("M1011");
            else
                //MessageBox.Show("データの登録に失敗しました。");
                messageDsp.DspMsg("M1012");

            textBoxDivisionCD.Focus();

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

            // 部署データの取得
            Division = divisionDataAccess.GetDivisionData();

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
            dataGridViewDsp.DataSource = Division.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGridViewDsp.Columns[0].Width = 100;
            dataGridViewDsp.Columns[1].Width = 200;
            dataGridViewDsp.Columns[2].Width = 100;
            dataGridViewDsp.Columns[3].Width = 400;

            //各列の文字位置の指定
            dataGridViewDsp.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Division.Count / (double)pageSize)) + "ページ";

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
            dataGridViewDsp.DataSource = Division.Take(pageSize).ToList();

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
            dataGridViewDsp.DataSource = Division.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            int lastNo = (int)Math.Ceiling(Division.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewDsp.DataSource = Division.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewDsp.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Division.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(Division.Count / (double)pageSize) - 1;
            dataGridViewDsp.DataSource = Division.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            dataGridViewPrinter.Preview("部署管理");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 8.1.2.1 妥当な部署データ取得
            if (!GetValidDataAtUpdate())
                return;

            // 8.1.2.2 部署情報作成
            var updDivision = GenerateDataAtUpdate();

            // 8.1.2.3 部署情報更新
            UpdateDivision(updDivision);

        }

        ///////////////////////////////
        //　8.1.2.1 妥当な部署データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {

            // 部署CDの適否
            if (!String.IsNullOrEmpty(textBoxDivisionCD.Text.Trim()))
            {
                // 部署CDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxDivisionCD.Text.Trim()))
                {
                    //MessageBox.Show("部署CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M1001");
                    textBoxDivisionCD.Focus();
                    return false;
                }
                // 部署CDの文字数チェック
                if (textBoxDivisionCD.TextLength != 5)
                {
                    //MessageBox.Show("部署CDは5文字です");
                    messageDsp.DspMsg("M1002");
                    textBoxDivisionCD.Focus();
                    return false;
                }
                // 部署CDの存在チェック
                if (!divisionDataAccess.CheckDivisionCDExistence(textBoxDivisionCD.Text.Trim()))
                {
                    //MessageBox.Show("入力された部署CDは存在しません");
                    messageDsp.DspMsg("M1013");
                    textBoxDivisionCD.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("部署CDが入力されていません");
                messageDsp.DspMsg("M1004");
                textBoxDivisionCD.Focus();
                return false;
            }
            

            // 部署名の適否
            if (!String.IsNullOrEmpty(textBoxDivisionName.Text.Trim()))
            {
                // 部署名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxDivisionName.Text.Trim()))
                {
                    //MessageBox.Show("部署名は全て全角入力です");
                    messageDsp.DspMsg("M1005");
                    textBoxDivisionName.Focus();
                    return false;
                }
                // 部署名の文字数チェック
                if (textBoxDivisionName.TextLength > 25)
                {
                    //MessageBox.Show("部署名は25文字以下です");
                    messageDsp.DspMsg("M1006");
                    textBoxDivisionName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("部署名が入力されていません");
                messageDsp.DspMsg("M1007");
                textBoxDivisionName.Focus();
                return false;
            }

            

            // 削除フラグの適否
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("削除フラグが不確定の状態です");
                messageDsp.DspMsg("M1008");
                checkBoxDeleteFlg.Focus();
                return false;
            }

            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if (textBoxComments.TextLength > 80)
                {
                    //MessageBox.Show("備考は80文字以下です");
                    messageDsp.DspMsg("M1009");
                    textBoxComments.Focus();
                    return false;
                }
            }
            return true;
        }

        ///////////////////////////////
        //　8.1.2.2 部署情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：部署更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_Division GenerateDataAtUpdate()
        {
            return new M_Division
            {
                DivisionCD = textBoxDivisionCD.Text.Trim(),
                DivisionName = textBoxDivisionName.Text.Trim(),
                DeleteFlg = checkBoxDeleteFlg.Checked,
                Comments = textBoxComments.Text.Trim()
            };
        }

        ///////////////////////////////
        //　8.1.2.3 部署情報更新
        //メソッド名：UpdateDivision()
        //引　数   ：部署情報
        //戻り値   ：なし
        //機　能   ：部署情報の更新
        ///////////////////////////////
        private void UpdateDivision(M_Division updDivision)
        {
            // 更新確認メッセージ
            DialogResult result = messageDsp.DspMsg("M1014");
            
            if (result == DialogResult.Cancel)
                return;

            // 部署情報の更新
            bool flg = divisionDataAccess.UpdateDivisionData(updDivision);
            if (flg == true)
                //MessageBox.Show("データを更新しました。");
                messageDsp.DspMsg("M1015");
            else
                //MessageBox.Show("データの更新に失敗しました。");
                messageDsp.DspMsg("M1016");

            textBoxDivisionCD.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
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
            textBoxDivisionCD.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxDivisionName.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[1].Value.ToString();
            checkBoxDeleteFlg.Checked = bool.Parse(dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[2].Value.ToString());
            textBoxComments.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[3].Value.ToString();
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
            textBoxDivisionCD.Text = "";
            textBoxDivisionName.Text = "";
            textBoxComments.Text = "";
            checkBoxDeleteFlg.Checked = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // 8.1.3.1 妥当な部署データ取得
            if (!GetValidDataAtDelete())
                return;

            // 8.1.3.2 部署情報削除
            DeleteDivision();
        }

        ///////////////////////////////
        //　8.1.3.1 妥当な部署データ取得
        //メソッド名：GetValidDataAtDelete()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtDelete()
        {

            // 部署CDの適否
            if (!String.IsNullOrEmpty(textBoxDivisionCD.Text.Trim()))
            {
                // 部署CDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxDivisionCD.Text.Trim()))
                {
                    //MessageBox.Show("部署CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M1001");
                    textBoxDivisionCD.Focus();
                    return false;
                }
                // 部署CDの文字数チェック
                if (textBoxDivisionCD.TextLength != 5)
                {
                    //MessageBox.Show("部署CDは5文字です");
                    messageDsp.DspMsg("M1002");
                    textBoxDivisionCD.Focus();
                    return false;
                }
                // 部署CDの存在チェック
                if (!divisionDataAccess.CheckDivisionCDExistence(textBoxDivisionCD.Text.Trim()))
                {
                    //MessageBox.Show("入力された部署CDは存在しません");
                    messageDsp.DspMsg("M1013");
                    textBoxDivisionCD.Focus();
                    return false;
                }
                // 部署CDのスタッフマスタカスケードチェック
                if (divisionDataAccess.CheckCascadeStaff(textBoxDivisionCD.Text))
                {
                    //MessageBox.Show("入力された部署CDは他で利用されているため削除できません");
                    messageDsp.DspMsg("M1017");
                    textBoxDivisionCD.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("部署CDが入力されていません");
                messageDsp.DspMsg("M1004");
                textBoxDivisionCD.Focus();
                return false;
            }
            return true;
        }

        ///////////////////////////////
        //　8.1.3.2 部署情報削除
        //メソッド名：DeleteDavision()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：部署情報の削除
        ///////////////////////////////
        private void DeleteDivision()
        {
            // 削除確認メッセージ
            DialogResult result = messageDsp.DspMsg("M1018");
            
            if (result == DialogResult.Cancel)
                return;

            // 部署情報の削除
            bool flg = divisionDataAccess.DeleteDivisionData(textBoxDivisionCD.Text.Trim());
            if (flg == true)
                //MessageBox.Show("データを削除しました。");
                messageDsp.DspMsg("M1019");
            else
                //MessageBox.Show("データの削除に失敗しました。");
                messageDsp.DspMsg("M1020");

            textBoxDivisionCD.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 8.1.4.1 妥当な部署データ取得
            if (!GetValidDataAtSelect())
                return;

            // 8.1.4.2 部署情報抽出
           GenerateDataAtSelect();

            // 8.1.4.3 部署抽出結果表示
            SetSelectData();
                       
        }
        ///////////////////////////////
        //　8.1.4.1 部署情報検証
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {

            // 部署CD入力時チェック
            if (!String.IsNullOrEmpty(textBoxDivisionCD.Text.Trim()))
            {
                // 部署CDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxDivisionCD.Text.Trim()))
                {
                    //MessageBox.Show("部署CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M1001");
                    textBoxDivisionCD.Focus();
                    return false;
                }
                // 部署CDの文字数チェック
                if (textBoxDivisionCD.TextLength > 5)
                {
                    //MessageBox.Show("部署CDは5文字までです");
                    messageDsp.DspMsg("M1021");
                    textBoxDivisionCD.Focus();
                    return false;
                }

            }
            // 部署名入力時チェック
            if (!String.IsNullOrEmpty(textBoxDivisionName.Text.Trim()))
            {
                // 部署名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxDivisionName.Text.Trim()))
                {
                    //MessageBox.Show("部署名は全て全角入力です");
                    messageDsp.DspMsg("M1005");
                    textBoxDivisionName.Focus();
                    return false;
                }
                // 部署名の文字数チェック
                if (textBoxDivisionName.TextLength > 25)
                {
                    //MessageBox.Show("部署名は25文字以下です");
                    messageDsp.DspMsg("M1006");
                    textBoxDivisionName.Focus();
                    return false;
                }
            }

            return true;

        }
        ///////////////////////////////
        //　8.1.4.2 部署情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：部署情報の取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            // 検索条件のセット
            M_Division selectCondition = new M_Division()
            {
                DivisionCD = textBoxDivisionCD.Text.Trim(),
                DivisionName = textBoxDivisionName.Text.Trim()
            };
            // 部署データの抽出
            Division = divisionDataAccess.GetDivisionData(selectCondition);

        }
        ///////////////////////////////
        //　8.1.4.3 部署部署抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：部署情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPageNo.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewDsp.DataSource = Division;

            labelPage.Text = "/" + ((int)Math.Ceiling(Division.Count / (double)pageSize)) + "ページ";
            dataGridViewDsp.Refresh();
        }
    }
}
