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
    public partial class FormPosition : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース役職テーブルアクセス用クラスのインスタンス化
        PositionDataAccess positionDataAccess = new PositionDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の役職データ
        private static List<M_Position> Position;

        public FormPosition()
        {
            InitializeComponent();
        }

        private void FormPosition_Load(object sender, EventArgs e)
        {
            //ログイン名の表示
            labelLoginName.Text = FormMenu.loginName;

            // データグリッドビューの表示
            SetFormDataGridView();
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            // 8.2.1.1 妥当な役職データ取得
            if (!GetValidDataAtRegistration())
                return;

            // 8.2.1.2 役職情報作成
            var regPosition = GenerateDataAtRegistration();

            // 8.2.1.3 役職情報登録
            RegistrationPosition(regPosition);
        }
        ///////////////////////////////
        //　8.2.1.1 妥当な役職データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {

            // 役職CDの適否
            if (!String.IsNullOrEmpty(textBoxPositionCD.Text.Trim()))
            {
                // 役職CDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxPositionCD.Text.Trim()))
                {
                    //MessageBox.Show("役職CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M2001");
                    textBoxPositionCD.Focus();
                    return false;
                }
                // 役職CDの文字数チェック
                if (textBoxPositionCD.TextLength != 5)
                {
                    //MessageBox.Show("役職CDは5文字です");
                    messageDsp.DspMsg("M2002");
                    textBoxPositionCD.Focus();
                    return false;
                }
                // 役職CDの重複チェック
                if (positionDataAccess.CheckPositionCDExistence(textBoxPositionCD.Text.Trim()))
                {
                    //MessageBox.Show("入力された役職CDは既に存在します");
                    messageDsp.DspMsg("M2003");
                    textBoxPositionCD.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("役職CDが入力されていません");
                messageDsp.DspMsg("M2004");
                textBoxPositionCD.Focus();
                return false;
            }
            
            // 役職名の適否
            if (!String.IsNullOrEmpty(textBoxPositionName.Text.Trim()))
            {
                // 役職名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxPositionName.Text.Trim()))
                {
                    //MessageBox.Show("役職名は全て全角入力です");
                    messageDsp.DspMsg("M2005");
                    textBoxPositionName.Focus();
                    return false;
                }
                // 役職名の文字数チェック
                if (textBoxPositionName.TextLength > 25)
                {
                    //MessageBox.Show("役職名は25文字以下です");
                    messageDsp.DspMsg("M2006");
                    textBoxPositionName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("役職名が入力されていません");
                messageDsp.DspMsg("M2007");
                textBoxPositionName.Focus();
                return false;
            }

            // 削除フラグの適否
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("削除フラグが不確定の状態です");
                messageDsp.DspMsg("M2008");
                checkBoxDeleteFlg.Focus();
                return false;
            }

            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if (textBoxComments.TextLength > 80)
                {
                    //MessageBox.Show("備考は80文字以下です");
                    messageDsp.DspMsg("M2009");
                    textBoxComments.Focus();
                    return false;
                }
            }
            return true;
        }
        ///////////////////////////////
        //　8.2.1.2 役職情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：役職登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_Position GenerateDataAtRegistration()
        {
            return new M_Position
            {
                PositionCD = textBoxPositionCD.Text.Trim(),
                PositionName = textBoxPositionName.Text.Trim(),
                DeleteFlg = checkBoxDeleteFlg.Checked,
                Comments = textBoxComments.Text.Trim(),
            };
        }
        ///////////////////////////////
        //　8.2.1.3 役職情報登録
        //メソッド名：RegistrationPosition()
        //引　数   ：役職情報
        //戻り値   ：なし
        //機　能   ：役職データの登録
        ///////////////////////////////
        private void RegistrationPosition(M_Position regPosition)
        {
            // 登録確認メッセージ
            DialogResult result = messageDsp.DspMsg("M2010");
            if (result == DialogResult.Cancel)
                return;

            // 役職情報の登録
            bool flg = positionDataAccess.AddPositionData(regPosition);
            if (flg == true)
                //MessageBox.Show("データを登録しました。");
                messageDsp.DspMsg("M2011");
            else
                //MessageBox.Show("データの登録に失敗しました。");
                messageDsp.DspMsg("M2012");

            textBoxPositionCD.Focus();

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

            // 役職データの取得
            Position = positionDataAccess.GetPositionData();

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
            dataGridViewDsp.DataSource = Position.Skip(pageSize * pageNo).Take(pageSize).ToList();
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
            labelPage.Text = "/" + ((int)Math.Ceiling(Position.Count / (double)pageSize)) + "ページ";

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
            dataGridViewDsp.DataSource = Position.Take(pageSize).ToList();

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
            dataGridViewDsp.DataSource = Position.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            int lastNo = (int)Math.Ceiling(Position.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewDsp.DataSource = Position.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewDsp.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Position.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(Position.Count / (double)pageSize) - 1;
            dataGridViewDsp.DataSource = Position.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            dataGridViewPrinter.Preview("役職管理");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 8.2.2.1 妥当な役職データ取得
            if (!GetValidDataAtUpdate())
                return;

            // 8.2.2.2 役職情報作成
            var updPosition = GenerateDataAtUpdate();

            // 8.2.2.3 役職情報更新
            UpdatePosition(updPosition);
        }
        ///////////////////////////////
        //　8.2.2.1 妥当な役職データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {

            // 役職CDの未入力チェック
            if (!String.IsNullOrEmpty(textBoxPositionCD.Text.Trim()))
            {
                // 役職CDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxPositionCD.Text.Trim()))
                {
                    //MessageBox.Show("役職CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M2001");
                    textBoxPositionCD.Focus();
                    return false;
                }
                // 役職CDの文字数チェック
                if (textBoxPositionCD.TextLength != 5)
                {
                    //MessageBox.Show("役職CDは5文字です");
                    messageDsp.DspMsg("M2002");
                    textBoxPositionCD.Focus();
                    return false;
                }
                // 役職CDの存在チェック
                if (!positionDataAccess.CheckPositionCDExistence(textBoxPositionCD.Text.Trim()))
                {
                    //MessageBox.Show("入力された役職CDは存在しません");
                    messageDsp.DspMsg("M2013");
                    textBoxPositionCD.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("役職CDが入力されていません");
                messageDsp.DspMsg("M2004");
                textBoxPositionCD.Focus();
                return false;
            }
            

            // 役職名の適否
            if (!String.IsNullOrEmpty(textBoxPositionName.Text.Trim()))
            {
                // 役職名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxPositionName.Text.Trim()))
                {
                    //MessageBox.Show("役職名は全て全角入力です");
                    messageDsp.DspMsg("M2005");
                    textBoxPositionName.Focus();
                    return false;
                }
                // 役職名の文字数チェック
                if (textBoxPositionName.TextLength > 25)
                {
                    //MessageBox.Show("役職名は25文字以下です");
                    messageDsp.DspMsg("M2006");
                    textBoxPositionName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("役職名が入力されていません");
                messageDsp.DspMsg("M2007");
                textBoxPositionName.Focus();
                return false;
            }

            

            // 削除フラグの適否
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("削除フラグが不確定の状態です");
                messageDsp.DspMsg("M2008");
                checkBoxDeleteFlg.Focus();
                return false;
            }

            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if (textBoxComments.TextLength > 80)
                {
                    //MessageBox.Show("備考は80文字以下です");
                    messageDsp.DspMsg("M2009");
                    textBoxComments.Focus();
                    return false;
                }
            }
            return true;
        }
        ///////////////////////////////
        //　8.2.2.2 役職情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：役職更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_Position GenerateDataAtUpdate()
        {
            return new M_Position
            {
                PositionCD = textBoxPositionCD.Text.Trim(),
                PositionName = textBoxPositionName.Text.Trim(),
                DeleteFlg = checkBoxDeleteFlg.Checked,
                Comments = textBoxComments.Text.Trim()
            };
        }
        ///////////////////////////////
        //　8.2.2.3 役職情報更新
        //メソッド名：UpdatePosition()
        //引　数   ：役職情報
        //戻り値   ：なし
        //機　能   ：役職情報の更新
        ///////////////////////////////
        private void UpdatePosition(M_Position updPosition)
        {
            // 更新確認メッセージ
            DialogResult result = messageDsp.DspMsg("M2014");
            if (result == DialogResult.Cancel)
                return;

            // 役職情報の更新
            bool flg = positionDataAccess.UpdatePositionData(updPosition);
            if (flg == true)
                //MessageBox.Show("データを更新しました。");
                messageDsp.DspMsg("M2015");
            else
                //MessageBox.Show("データの更新に失敗しました。");
                messageDsp.DspMsg("M2016");

            textBoxPositionCD.Focus();

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
            textBoxPositionCD.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxPositionName.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[1].Value.ToString();
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
            textBoxPositionCD.Text = "";
            textBoxPositionName.Text = "";
            textBoxComments.Text = "";
            checkBoxDeleteFlg.Checked = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // 8.2.3.1 妥当な役職データ取得
            if (!GetValidDataAtDelete())
                return;

            // 8.2.3.2 役職情報削除
            DeletePosition();
        }
        ///////////////////////////////
        //　8.2.3.1 妥当な役職データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtDelete()
        {

            // 役職CDの適否
            if (!String.IsNullOrEmpty(textBoxPositionCD.Text.Trim()))
            {
                // 役職CDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxPositionCD.Text.Trim()))
                {
                    //MessageBox.Show("役職CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M2001");
                    textBoxPositionCD.Focus();
                    return false;
                }
                // 役職CDの文字数チェック
                if (textBoxPositionCD.TextLength != 5)
                {
                    //MessageBox.Show("役職CDは5文字です");
                    messageDsp.DspMsg("M2002");
                    textBoxPositionCD.Focus();
                    return false;
                }
                
                // 役職CDの存在チェック
                if (!positionDataAccess.CheckPositionCDExistence(textBoxPositionCD.Text.Trim()))
                {
                    //MessageBox.Show("入力された役職CDは存在しません");
                    messageDsp.DspMsg("M2013");
                    textBoxPositionCD.Focus();
                    return false;
                }

                // 役職CDのスタッフマスタカスケードチェック
                if (positionDataAccess.CheckCascadeStaff(textBoxPositionCD.Text))
                {
                    //MessageBox.Show("入力された役職CDは既に利用されているため削除できません");
                    messageDsp.DspMsg("M2017");
                    textBoxPositionCD.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("役職CDが入力されていません");
                messageDsp.DspMsg("M2004");
                textBoxPositionCD.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //　8.2.3.2 役職情報削除
        //メソッド名：DeleteDavision()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：役職情報の削除
        ///////////////////////////////
        private void DeletePosition()
        {
            // 削除確認メッセージ
            DialogResult result = messageDsp.DspMsg("M2018");

            if (result == DialogResult.Cancel)
                return;

            // 役職情報の削除
            bool flg = positionDataAccess.DeletePositionData(textBoxPositionCD.Text);
            if (flg == true)
                //MessageBox.Show("データを削除しました。");
                messageDsp.DspMsg("M2019");
            else
                //MessageBox.Show("データの削除に失敗しました。");
                messageDsp.DspMsg("M2020");

            textBoxPositionCD.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 8.2.4.1 妥当な役職データ取得
            if (!GetValidDataAtSelect())
                return;

            // 8.2.4.2 役職情報抽出
            GenerateDataAtSelect();

            // 8.2.4.3 役職抽出結果表示
            SetSelectData();

        }
        ///////////////////////////////
        //　8.2.4.1 妥当な役職データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {

            // 役職CD入力時チェック
            if (!String.IsNullOrEmpty(textBoxPositionCD.Text.Trim()))
            {
                // 役職CDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxPositionCD.Text.Trim()))
                {
                    //MessageBox.Show("役職CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M2001");
                    textBoxPositionCD.Focus();
                    return false;
                }
                // 役職CDの文字数チェック
                if (textBoxPositionCD.TextLength > 5)
                {
                    //MessageBox.Show("役職CDは5文字までです");
                    messageDsp.DspMsg("M2002");
                    textBoxPositionCD.Focus();
                    return false;
                }
            }
            // 役職名入力時チェック
            if (!String.IsNullOrEmpty(textBoxPositionName.Text.Trim()))
            {
                // 役職名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxPositionName.Text.Trim()))
                {
                    //MessageBox.Show("役職名は全て全角入力です");
                    messageDsp.DspMsg("M2005");
                    textBoxPositionName.Focus();
                    return false;
                }
                // 役職名の文字数チェック
                if (textBoxPositionName.TextLength > 25)
                {
                    //MessageBox.Show("役職名は25文字以下です");
                    messageDsp.DspMsg("M2006");
                    textBoxPositionName.Focus();
                    return false;
                }
            }

            return true;

        }
        ///////////////////////////////
        //　8.2.4.2 役職情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：役職情報の取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            // 検索条件のセット
            M_Position selectCondition = new M_Position()
            {
                PositionCD = textBoxPositionCD.Text.Trim(),
                PositionName = textBoxPositionName.Text.Trim()
            };
            // 役職データの抽出
            Position = positionDataAccess.GetPositionData(selectCondition);

        }
        ///////////////////////////////
        //　8.2.4.3 役職抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：役職情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPageNo.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewDsp.DataSource = Position;

            labelPage.Text = "/" + ((int)Math.Ceiling(Position.Count / (double)pageSize)) + "ページ";
            dataGridViewDsp.Refresh();
        }
    }
}
