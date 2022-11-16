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
    public partial class FormCategory : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース商品カテゴリテーブルアクセス用クラスのインスタンス化
        CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の商品カテゴリデータ
        private static List<M_Category> Category;
        //コンボボックス用の商品カテゴリデータ
        private static List<M_Category> CategoryDsp;

        public FormCategory()
        {
            InitializeComponent();
        }
        private void FormCategory_Load(object sender, EventArgs e)
        {
            //ログイン名の表示
            labelLoginName.Text = FormMenu.loginName;

            // コンボボックスの設定
            SetFormComboBox();

            // データグリッドビューの表示
            SetFormDataGridView();
        }

        ///////////////////////////////
        //メソッド名：SetFormComboBox()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：コンボボックスのデータ設定
        ///////////////////////////////
        private void SetFormComboBox()
        {
            // カテゴリデータの取得
            CategoryDsp = categoryDataAccess.GetParentCategoryDspData();
            comboBoxParentCategorys.DataSource = CategoryDsp;
            comboBoxParentCategorys.DisplayMember = "CategoryName";
            comboBoxParentCategorys.ValueMember = "CategoryCD";
            // コンボボックスを読み取り専用
            comboBoxParentCategorys.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxParentCategorys.SelectedIndex = -1;
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            // 5.2.1.1 妥当な商品カテゴリデータ取得
            if (!GetValidDataAtRegistration())
            {
                return;
            }

            // 5.2.1.2 商品カテゴリ情報作成
            var regCategory = GenerateDataAtRegistration();

            // 5.2.1.3 商品カテゴリ情報登録
            RegistrationCategory(regCategory);
        }

        ///////////////////////////////
        //　5.2.1.1 妥当な商品カテゴリデータ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //商品カテゴリCDの適否
            if (!String.IsNullOrEmpty(textBoxCategoryCD.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxCategoryCD.Text.Trim())){
                    messageDsp.DspMsg("M4001"); //商品カテゴリCDは全て半角英数字入力です
                    textBoxCategoryCD.Focus();
                    return false;
                }
                //文字数
                if(textBoxCategoryCD.TextLength != 5)
                {
                    messageDsp.DspMsg("M4002"); //商品カテゴリCDは5文字です
                    textBoxCategoryCD.Focus();
                    return false;
                }
                //存在なしチェック
                if (categoryDataAccess.CheckCategoryCDExistence(textBoxCategoryCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M4013"); //入力された商品カテゴリCDは既に存在しています
                    textBoxCategoryCD.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M4004"); //商品カテゴリCDが入力されていません
                textBoxCategoryCD.Focus();
                return false;
            }
            //商品カテゴリ名の適否
            if (!String.IsNullOrEmpty(textBoxCategoryName.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckFullWidth(textBoxCategoryName.Text.Trim()))
                {
                    messageDsp.DspMsg("M4005"); //商品カテゴリ名は全角入力です
                    textBoxCategoryName.Focus();
                    return false;
                }
                //文字数
                if(textBoxCategoryName.TextLength > 25)
                {
                    messageDsp.DspMsg("M4006"); //商品カテゴリ名は25文字以下です
                    textBoxCategoryName.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M4007"); //商品カテゴリ名が入力されていません
                textBoxCategoryName.Focus();
                return false;
            }
            //商品カテゴリ名かなの適否
            if (!String.IsNullOrEmpty(textBoxCategoryKana.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxCategoryKana.Text.Trim()))
                {
                    messageDsp.DspMsg("M4022"); //商品カテゴリ名カナは半角カナ入力です
                    textBoxCategoryKana.Focus();
                    return false;
                }
                //文字数
                if(textBoxCategoryKana.TextLength > 50)
                {
                    messageDsp.DspMsg("M4023"); //商品カテゴリ名カナは50文字以下です
                    textBoxCategoryKana.Focus();
                    return false;
                }
            }
            //削除フラグの適否
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                messageDsp.DspMsg("M4008");//削除フラグが不確定の状態です
                checkBoxDeleteFlg.Focus();
                return false;
            }
            //備考の適否
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if(textBoxCategoryCD.TextLength > 80)
                {
                    messageDsp.DspMsg("M4009"); //備考は80文字以下です
                    textBoxComments.Focus();
                    return false;
                }
            }
            //親カテゴリの確認
            if(comboBoxParentCategorys.SelectedIndex == -1)
            {
                DialogResult result = messageDsp.DspMsg("M4025");

                if(result == DialogResult.Cancel)
                {
                    comboBoxParentCategorys.Focus();
                    return false;
                }
            }
            return true;
        }

        ///////////////////////////////
        //　5.2.1.2 商品カテゴリ情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：商品カテゴリ登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_Category GenerateDataAtRegistration()
        {
            // コンボボックスが未選択の場合
            String cParentCategory = "";
            if(comboBoxParentCategorys.SelectedIndex != -1)
            {
                cParentCategory = comboBoxParentCategorys.SelectedValue.ToString();
            }

            // 商品カテゴリ情報の作成
            return new M_Category
            {
                ParentCategory = cParentCategory,
                CategoryCD = textBoxCategoryCD.Text.Trim(),
                CategoryName = textBoxCategoryName.Text.Trim(),
                CategoryKana = textBoxCategoryKana.Text.Trim(),
                DeleteFlg = checkBoxDeleteFlg.Checked,
                Comments = textBoxComments.Text.Trim()
            };
        }

        ///////////////////////////////
        //　5.2.1.3 商品カテゴリ情報登録
        //メソッド名：RegistrationCategory()
        //引　数   ：商品カテゴリ情報
        //戻り値   ：なし
        //機　能   ：商品カテゴリデータの登録

        ///////////////////////////////
        private void RegistrationCategory(M_Category regCategory)
        {
            //登録確認メッセージ
            DialogResult result = messageDsp.DspMsg("M4010");

            if(result == DialogResult.Cancel)
            {
                return;
            }
            //商品カテゴリ情報の登録
            bool flg = categoryDataAccess.AddCategoryData(regCategory);
            if(flg == true)
            {
                messageDsp.DspMsg("M4011");//データを登録しました
            }
            else
            {
                messageDsp.DspMsg("M4012");//データの登録に失敗しました
            }
            textBoxCategoryCD.Focus();
            //入力エリアのクリア
            ClearInput();
            //親カテゴリコンボボックスの再設定
            SetFormComboBox();
            //データグリッドビューの表示
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

            // 商品カテゴリデータの取得
            Category = categoryDataAccess.GetCategoryData();

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
            dataGridViewDsp.DataSource = Category.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGridViewDsp.Columns[0].Width = 100;
            dataGridViewDsp.Columns[1].Width = 100;
            dataGridViewDsp.Columns[2].Width = 200;
            dataGridViewDsp.Columns[3].Width = 200;
            dataGridViewDsp.Columns[4].Width = 100;
            dataGridViewDsp.Columns[5].Width = 400;

            //各列の文字位置の指定
            dataGridViewDsp.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Category.Count / (double)pageSize)) + "ページ";

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
            dataGridViewDsp.DataSource = Category.Take(pageSize).ToList();

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
            dataGridViewDsp.DataSource = Category.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            int lastNo = (int)Math.Ceiling(Category.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewDsp.DataSource = Category.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewDsp.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Category.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(Category.Count / (double)pageSize) - 1;
            dataGridViewDsp.DataSource = Category.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            dataGridViewPrinter.Preview("商品カテゴリ管理");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 5.2.2.1 妥当な商品カテゴリデータ取得
            if (!GetValidDataAtUpdate())
            {
                return;
            }

            // 5.2.2.2 商品カテゴリ情報作成
            var updCategory = GenerateDataAtUpdate();

            // 5.2.2.3 商品カテゴリ情報更新
            UpdateCategory(updCategory);
        }
        ///////////////////////////////
        //　5.2.2.1 妥当な商品カテゴリデータ取得
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
            if (!String.IsNullOrEmpty(textBoxCategoryCD.Text.Trim()))
            {
                //文字種//
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxCategoryCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M4001");
                    textBoxCategoryCD.Focus();
                    return false;
                }
                //文字数//
                if (textBoxCategoryCD.TextLength != 5)
                {
                    messageDsp.DspMsg("M4002");
                    textBoxCategoryCD.Focus();
                    return false;
                }
                //存在なしチェック//
                if (!categoryDataAccess.CheckCategoryCDExistence(textBoxCategoryCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M4013");
                    textBoxCategoryCD.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M4004");
                textBoxCategoryCD.Focus();
                return false;
            }
            //商品メーカーCDの適否の終了//

            //商品メーカー名の適否の開始//
            if (!String.IsNullOrEmpty(textBoxCategoryName.Text.Trim()))
            {
                //文字種//
                if (!dataInputFormCheck.CheckFullWidth(textBoxCategoryName.Text))
                {
                    messageDsp.DspMsg("M4005");
                    textBoxCategoryName.Focus();
                    return false;
                }
                //文字数//
                if (textBoxCategoryName.TextLength > 25)
                {
                    messageDsp.DspMsg("M4006");
                    textBoxCategoryName.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M4007");
                textBoxCategoryName.Focus();
                return false;
            }
            //商品メーカー名の適否の終了//

            //商品メーカカナ名の適否の開始//
            if (!String.IsNullOrEmpty(textBoxCategoryKana.Text.Trim()))
            {
                //文字種//
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxCategoryKana.Text))
                {
                    messageDsp.DspMsg("4022");
                    textBoxCategoryKana.Focus();
                    return false;
                }
                //文字数//
                if (textBoxCategoryKana.TextLength > 50)
                {
                    messageDsp.DspMsg("M4023");
                    textBoxCategoryKana.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M4024");
                textBoxCategoryKana.Focus();
                return false;
            }
            //商品メーカカナ名の適否の終了//

            //削除フラグの適否の開始//
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                messageDsp.DspMsg("M4008");
                textBoxCategoryName.Focus();
                return false;
            }
            //削除フラグの適否の終了//

            //備考の適否の開始//
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if (textBoxComments.TextLength > 80)
                {
                    messageDsp.DspMsg("M4009");
                    textBoxComments.Focus();
                    return false;
                }
            }
            //備考の適否の終了//
            return true;
        }

        ///////////////////////////////
        //　5.2.2.2 商品カテゴリ情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：商品カテゴリ更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_Category GenerateDataAtUpdate()
        {
            // コンボボックスが未選択の場合
            String cParentCategory = "";
            if(comboBoxParentCategorys.SelectedIndex != -1)
            {
                cParentCategory = comboBoxParentCategorys.SelectedValue.ToString();
            }

            return new M_Category
            {
                ParentCategory = cParentCategory,
                CategoryCD = textBoxCategoryCD.Text.Trim(),
                CategoryName = textBoxCategoryName.Text.Trim(),
                CategoryKana = textBoxCategoryKana.Text.Trim(),
                Comments = textBoxComments.Text.Trim(),
            };
        }

        ///////////////////////////////
        //　5.2.2.3 商品カテゴリ情報更新
        //メソッド名：UpdateCategory()
        //引　数   ：商品カテゴリ情報
        //戻り値   ：なし
        //機　能   ：商品カテゴリ情報の更新
        ///////////////////////////////
        private void UpdateCategory(M_Category updCategory)
        {
            DialogResult result = messageDsp.DspMsg("M4014");

            if (result == DialogResult.Cancel)
            {
                return;
            }

            bool flg = categoryDataAccess.UpdateCategoryData(updCategory);
            if (flg == true)
            {
                messageDsp.DspMsg("M4015");
            }
            else
            {
                messageDsp.DspMsg("M4016");
            }
            textBoxCategoryCD.Focus();
            ClearInput();
            GetDataGridView();
        }

        private void dataGridViewDsp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            if (!String.IsNullOrEmpty(dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[1].Value.ToString()))
            {
                //selectedValueからdisplaymemberの取得
                string cValue = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[1].Value.ToString();
                comboBoxParentCategorys.Text = categoryDataAccess.GetComboboxText(cValue);
            }
            else
            {
                comboBoxParentCategorys.SelectedIndex = -1;
            }

            textBoxCategoryCD.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxCategoryName.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[2].Value.ToString();
            textBoxCategoryKana.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[3].Value.ToString();
            checkBoxDeleteFlg.Checked = bool.Parse(dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[4].Value.ToString());
            textBoxComments.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[5].Value.ToString();
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
            comboBoxParentCategorys.SelectedIndex = -1;
            textBoxCategoryCD.Text = "";
            textBoxCategoryName.Text = "";
            textBoxCategoryKana.Text = "";
            textBoxComments.Text = "";
            checkBoxDeleteFlg.Checked = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // 5.2.3.1 妥当な商品カテゴリデータ取得
            if (!GetValidDataAtDelete())
            {
                return;
            }

            // 5.2.3.2 商品カテゴリ情報削除
            DeleteCategory();
        }
        ///////////////////////////////
        //　5.2.3.1 妥当な商品カテゴリデータ取得
        //メソッド名：GetValidDataAtDelete()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtDelete()
        {
            if (!String.IsNullOrEmpty(textBoxCategoryCD.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxCategoryCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M4001");
                    textBoxCategoryCD.Focus();
                    return false;
                }
                if (textBoxCategoryCD.TextLength > 5)
                {
                    messageDsp.DspMsg("M4021");
                    textBoxCategoryCD.Focus();
                    return false;
                }
                if (!categoryDataAccess.CheckCategoryCDExistence(textBoxCategoryCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M4013");
                    textBoxCategoryCD.Focus();
                    return false;
                }
                if (categoryDataAccess.CheckCascadeItem(textBoxCategoryCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M4017");
                    textBoxCategoryCD.Focus();
                    return false;
                }
                if (categoryDataAccess.CheckCascadeParentCategory(textBoxCategoryCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M4026");
                    textBoxCategoryCD.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M4004");
                textBoxCategoryCD.Focus();
                return false;
            }
            return true;
        }

        ///////////////////////////////
        //　5.2.3.2 商品カテゴリ情報削除
        //メソッド名：DeleteDavision()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品カテゴリ情報の削除
        ///////////////////////////////
        private void DeleteCategory()
        {
            DialogResult result = messageDsp.DspMsg("M4018");

            if (result == DialogResult.Cancel)
            {
                return;
            }

            bool flg = categoryDataAccess.DeleteCategoryData(textBoxCategoryCD.Text.Trim());

            if (flg == true)
            {
                messageDsp.DspMsg("M4019");
            }
            else
            {
                messageDsp.DspMsg("M4020");
            }
            textBoxCategoryCD.Focus();
            ClearInput();
            GetDataGridView();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 5.2.4.1 妥当な商品カテゴリデータ取得
            if(!GetValidDataAtSelect())
            {
                return;
            }
            // 5.2.4.2 商品カテゴリ情報抽出
            GenerateDataAtSelect();

            // 5.2.4.3 商品カテゴリ抽出結果表示
            SetSelectData();
        }
        ///////////////////////////////
        //　5.2.4.1 妥当な商品カテゴリデータ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            //商品カテゴリCDのチェック//
            if (!String.IsNullOrEmpty(textBoxCategoryCD.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxCategoryCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M4001");//商品カテゴリCDは半角英数字入力です
                    textBoxCategoryCD.Focus();
                    return false;
                }
                if (textBoxCategoryCD.TextLength > 5)
                {
                    messageDsp.DspMsg("M4021");//商品カテゴリCDは5文字までです
                    textBoxCategoryCD.Focus();
                    return false;
                }
            }
            //商品カテゴリCDのチェック//
            //商品カテゴリ名のチェック//
            if (!String.IsNullOrEmpty(textBoxCategoryName.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckFullWidth(textBoxCategoryName.Text.Trim()))
                {
                    messageDsp.DspMsg("M4005");//商品カテゴリ名は全角入力です
                    textBoxCategoryName.Focus();
                    return false;
                }
                if (textBoxCategoryName.TextLength > 25)
                {
                    messageDsp.DspMsg("M4006"); //商品カテゴリ名は25文字以下です
                    textBoxCategoryName.Focus();
                    return false;
                }
            }
            //商品カテゴリ名のチェック//
            //商品カテゴリ名カナのチェック//
            if (String.IsNullOrEmpty(textBoxCategoryKana.Text.Trim()))
            {
                if (dataInputFormCheck.CheckHalfWidthKatakana(textBoxCategoryKana.Text))
                {
                    messageDsp.DspMsg("M4022"); //商品カテゴリ名カナは半角カナ入力です
                    textBoxCategoryKana.Focus();
                    return false;
                }
                if (textBoxCategoryKana.TextLength > 50)
                {
                    messageDsp.DspMsg("M4023");//商品カテゴリ名カナは50文字以下です
                    textBoxCategoryKana.Focus();
                    return false;
                }
            }
            //商品カテゴリ名カナのチェック//
            return true;
        }
        ///////////////////////////////
        //　5.2.4.2 商品カテゴリ情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品カテゴリ情報の取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            // コンボボックスが未選択の場合
            string cParentCategory = "";
            if(comboBoxParentCategorys.SelectedIndex != -1)
            {
                cParentCategory = comboBoxParentCategorys.SelectedValue.ToString();
            }
            // 検索条件のセット
            M_Category selectCondition = new M_Category()
            {
                ParentCategory = cParentCategory,
                CategoryCD = textBoxCategoryCD.Text.Trim(),
                CategoryName = textBoxCategoryName.Text.Trim(),
                CategoryKana = textBoxCategoryKana.Text.Trim()
            };
            // 商品カテゴリデータの抽出
            Category = categoryDataAccess.GetCategoryData(selectCondition);
        }
        ///////////////////////////////
        //　5.2.4.3 商品カテゴリ抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品カテゴリ情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPageNo.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewDsp.DataSource = Category;

            labelPage.Text = "/" + ((int)Math.Ceiling(Category.Count / (double)pageSize)) + "ページ";
            dataGridViewDsp.Refresh();
        }
    }
}
