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
    public partial class FormItem : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース商品マスタテーブルアクセス用クラスのインスタンス化
        ItemDataAccess itemDataAccess = new ItemDataAccess();
        //データベース商品カテゴリテーブルアクセス用クラスのインスタンス化
        CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
        //データベース商品メーカテーブルアクセス用クラスのインスタンス化
        MakerDataAccess makerDataAccess = new MakerDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();

        //データグリッドビュー用のスタッフデータ
        private static List<M_ItemDsp> Item;
        //コンボボックス用の商品カテゴリデータ
        private static List<M_Category> Category;
        //コンボボックス用の商品メーカデータ
        private static List<M_Maker> Maker;
  
        public FormItem()
        {
            InitializeComponent();
        }

        private void FormItem_Load(object sender, EventArgs e)
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
            // 商品親カテゴリデータの取得
            Category = categoryDataAccess.GetParentCategoryDspData();
            comboBoxParentCategory.DataSource = Category;
            comboBoxParentCategory.DisplayMember = "CategoryName";
            comboBoxParentCategory.ValueMember = "CategoryCD";
            // 商品親カテゴリコンボボックスを読み取り専用
            comboBoxParentCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxParentCategory.SelectedIndex = -1;
            // 商品カテゴリコンボボックスを読み取り専用
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.SelectedIndex = -1;
            // 商品メーカデータの取得
            Maker = makerDataAccess.GetMakerDspData();
            comboBoxMaker.DataSource = Maker;
            comboBoxMaker.DisplayMember = "MakerName";
            comboBoxMaker.ValueMember = "MakerCD";
            // 商品メーカコンボボックスを読み取り専用
            comboBoxMaker.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMaker.SelectedIndex = -1;
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

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            
            // 5.3.1.1 妥当な商品データ取得
            if (!GetValidDataAtRegistration())
            {
                return;
            }
            // 5.3.1.2 商品情報作成
            var regItem = GenerateDataAtRegistration();
            // 5.3.1.3 商品情報登録
            RegistrationItem(regItem);
        }

        ///////////////////////////////
        //　5.3.1.1 妥当な商品データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //商品データの適否
            if (!String.IsNullOrEmpty(textBoxItemCD.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxItemCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M5001");//商品CDは半角英数字入力です
                    textBoxItemCD.Focus();
                    return false;
                }
                //文字数
                if (textBoxItemCD.TextLength != 8)
                {
                    messageDsp.DspMsg("M5002");//商品CDは8文字です
                    textBoxItemCD.Focus();
                    return false;
                }
                //存在なしチェック
                if (itemDataAccess.CheckItemCDExistence(textBoxItemCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M5003");//入力された商品CDは既に存在しています
                    textBoxItemCD.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M5004");//商品CDが入力されていません 
                textBoxItemCD.Focus();
                return false;
            }
            //商品名の適否
            if (!String.IsNullOrEmpty(textBoxItemName.Text.Trim()))
            {
                //文字数
                if (textBoxItemName.TextLength > 25)
                {
                    messageDsp.DspMsg("M5006");//商品名は25文字以下です
                    textBoxItemName.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M5007");//商品名が入力されていません
                textBoxItemName.Focus();
                return false;
            }
            //商品名カナの適否
            if (!String.IsNullOrEmpty(textBoxItemKana.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxItemKana.Text.Trim()))
                {
                    messageDsp.DspMsg("M5022");//商品名カナは半角カナ入力です
                    textBoxItemKana.Focus();
                    return false;
                }
                //文字数
                if (textBoxItemKana.TextLength > 50)
                {
                    messageDsp.DspMsg("M5023");//商品名カナは50文字以下です
                    textBoxItemKana.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M5024");//商品名カナが入力されていません
                textBoxItemKana.Focus();
                return false;
            }
            //親カテゴリ名の適否
            if (comboBoxParentCategory.SelectedIndex == -1)
            {
                messageDsp.DspMsg("M5025");//親カテゴリ名が選択されていません
                comboBoxParentCategory.Focus();
                return false;
            }
            //カテゴリ名の適否
            if (comboBoxCategory.SelectedIndex == -1)
            {
                messageDsp.DspMsg("M5026");//カテゴリ名が選択されていません
                comboBoxCategory.Focus();
                return false;
            }
            //Janコードの適否
            if (!String.IsNullOrEmpty(textBoxJanCD.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckNumeric(textBoxJanCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M5027");//JanCDは半角数値入力です
                    textBoxJanCD.Focus();
                    return false;
                }
                //文字数
                if (textBoxJanCD.TextLength != 13)
                {
                    messageDsp.DspMsg("M5028");//JanCDは13文字です
                    textBoxJanCD.Focus();
                    return false;
                }
            }
            //メーカー名の適否
            if (comboBoxMaker.SelectedIndex == -1)
            {
                DialogResult result = messageDsp.DspMsg("M5029");//メーカ名が選択されていません
                if (result == DialogResult.Cancel)
                {
                    comboBoxMaker.Focus();
                    return false;
                }
            }
            //型番の適否
            if (!String.IsNullOrEmpty(textBoxModelNo.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckHalfChar(textBoxModelNo.Text.Trim()))
                {
                    messageDsp.DspMsg("M5030"); //型番は半角入力です
                    textBoxModelNo.Focus();
                    return false;
                }
                //文字数
                if (textBoxModelNo.TextLength > 30)
                {
                    messageDsp.DspMsg("M5031");//型番は30文字以下です
                    textBoxModelNo.Focus();
                    return false;
                }
            }
            //定価の適否
            if (!String.IsNullOrEmpty(textBoxListPrice.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckNumeric(textBoxListPrice.Text.Trim()))
                {
                    messageDsp.DspMsg("M5032");//定価は半角数値入力です
                    textBoxListPrice.Focus();
                    return false;
                }
            }
            //店頭飯場価格の適否
            if (!String.IsNullOrEmpty(textBoxSellingPrice.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckNumeric(textBoxSellingPrice.Text.Trim()))
                {
                    messageDsp.DspMsg("M5033");//店頭販売価格は半角数値入力です
                    textBoxSellingPrice.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M5034");//店頭販売価格が入力されていません
                textBoxSellingPrice.Focus();
                return false;
            }
            //削除フラグの適否
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                messageDsp.DspMsg("M5008");//削除フラグが不確定の状態です
                checkBoxDeleteFlg.Focus();
                return false;
            }
            //備考の適否
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                //文字数
                if(textBoxComments.TextLength > 80)
                {
                    messageDsp.DspMsg("M5009");//備考は80文字以下です
                    textBoxComments.Focus();
                    return false;
                }
            }
            return true;
        }

        ///////////////////////////////
        //　5.3.1.2 商品情報情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：商品登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_Item GenerateDataAtRegistration()
        {
            // 定価がnullの場合
            string cListPrice = textBoxListPrice.Text.Trim();
            if (!String.IsNullOrEmpty(cListPrice))
            {
                cListPrice = textBoxListPrice.Text.Trim();
            }
            else
            {
                cListPrice = null;
            }
            // 登録情報のセット
            return new M_Item
            {
                ItemCD = textBoxItemCD.Text.Trim(),
                ItemName = textBoxItemName.Text.Trim(),
                ItemKana = textBoxItemKana.Text.Trim(),
                CategoryCD = comboBoxCategory.SelectedValue.ToString(),
                JanCD = textBoxJanCD.Text.Trim(),
                MakerCD = comboBoxMaker.SelectedValue.ToString(),
                ModelNo = textBoxModelNo.Text.Trim(),
                ListPrice = int.Parse(cListPrice),
                SellingPrice = int.Parse(textBoxSellingPrice.Text.Trim()),
                DeleteFlg = checkBoxDeleteFlg.Checked,
                Comments = textBoxComments.Text.Trim()
            };
        }

        ///////////////////////////////
        //　5.3.1.3 商品情報登録
        //メソッド名：RegistrationItem()
        //引　数   ：商品情報
        //戻り値   ：なし
        //機　能   ：商品情報の登録
        ///////////////////////////////
        private void RegistrationItem(M_Item regItem)
        {
            //登録確認メッセージ
            DialogResult result = messageDsp.DspMsg("M5010");//商品データを登録してよろしいですか？
            if(result == DialogResult.Cancel)
            {
                return;
            }
            //商品情報の登録
            bool flg = itemDataAccess.AddItemData(regItem);
            if(flg == true)
            {
                messageDsp.DspMsg("M5011");//商品データを登録しました
            }
            else
            {
                messageDsp.DspMsg("M5012");//商品データ登録に失敗しました
            }
            textBoxItemCD.Focus();
            //入力エリアのクリア
            ClearInput();
            //画面更新
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

            // 商品データの取得
            Item =  itemDataAccess.GetItemData();

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
            dataGridViewDsp.DataSource = Item.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGridViewDsp.Columns[0].Width = 80;
            dataGridViewDsp.Columns[1].Width = 200;
            dataGridViewDsp.Columns[2].Width = 200;
            dataGridViewDsp.Columns[3].Width = 100;
            dataGridViewDsp.Columns[3].Visible = false;
            dataGridViewDsp.Columns[4].Width = 90;
            dataGridViewDsp.Columns[5].Width = 100;
            dataGridViewDsp.Columns[5].Visible = false;
            dataGridViewDsp.Columns[6].Width = 90;
            dataGridViewDsp.Columns[7].Width = 150;
            dataGridViewDsp.Columns[7].Visible = false;
            dataGridViewDsp.Columns[8].Width = 150;
            dataGridViewDsp.Columns[8].Visible = false;
            dataGridViewDsp.Columns[9].Width = 100;
            dataGridViewDsp.Columns[10].Width = 100;
            dataGridViewDsp.Columns[10].Visible = false;
            dataGridViewDsp.Columns[11].Width = 80;
            dataGridViewDsp.Columns[12].Width = 80;
            dataGridViewDsp.Columns[13].Width = 80;
            dataGridViewDsp.Columns[14].Width = 200;

            //各列の文字位置の指定
            dataGridViewDsp.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewDsp.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewDsp.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Item.Count / (double)pageSize)) + "ページ";

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
            dataGridViewDsp.DataSource = Item.Take(pageSize).ToList();

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
            dataGridViewDsp.DataSource = Item.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            int lastNo = (int)Math.Ceiling(Item.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewDsp.DataSource = Item.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewDsp.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Item.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(Item.Count / (double)pageSize) - 1;
            dataGridViewDsp.DataSource = Item.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewDsp.Refresh();
            //ページ番号の設定
            textBoxPageNo.Text = (pageNo + 1).ToString();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            // 印刷設定クラスのインスタンス化
            DataGridViewPrinter dataGridViewPrinter = new DataGridViewPrinter(dataGridViewDsp);
            // 印刷ドキュメント名を指定して、印刷プレビュー
            dataGridViewPrinter.Preview("商品マスタ―管理");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 5.3.2.1 妥当な商品データ取得
            if (!GetValidDataAtUpdate())
            {
                return;
            }

            // 5.3.2.2 スタッフ情報作成
            var updItem = GenerateDataAtUpdate();

            // 5.3.2.3 スタッフ情報更新
            UpdateItem(updItem);
        }
        ///////////////////////////////
        //5.3.2.1 妥当な商品データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {
            //商品データの適否
            if (!String.IsNullOrEmpty(textBoxItemCD.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxItemCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M5001");//商品CDは半角英数字入力です
                    textBoxItemCD.Focus();
                    return false;
                }
                //文字数
                if (textBoxItemCD.TextLength != 8)
                {
                    messageDsp.DspMsg("M5002");//商品CDは8文字です
                    textBoxItemCD.Focus();
                    return false;
                }
                //存在ありチェック
                if (!itemDataAccess.CheckItemCDExistence(textBoxItemCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M5003");//入力された商品CDは既に存在しています
                    textBoxItemCD.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M5004");//商品CDが入力されていません 
                textBoxItemCD.Focus();
                return false;
            }
            //商品名の適否
            if (!String.IsNullOrEmpty(textBoxItemName.Text.Trim()))
            {
                //文字数
                if (textBoxItemName.TextLength > 25)
                {
                    messageDsp.DspMsg("M5006");//商品名は25文字以下です
                    textBoxItemName.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M5007");//商品名が入力されていません
                textBoxItemName.Focus();
                return false;
            }
            //商品名カナの適否
            if (!String.IsNullOrEmpty(textBoxItemKana.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxItemKana.Text.Trim()))
                {
                    messageDsp.DspMsg("M5022");//商品名カナは半角カナ入力です
                    textBoxItemKana.Focus();
                    return false;
                }
                //文字数
                if (textBoxItemKana.TextLength > 50)
                {
                    messageDsp.DspMsg("M5023");//商品名カナは50文字以下です
                    textBoxItemKana.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M5024");//商品名カナが入力されていません
                textBoxItemKana.Focus();
                return false;
            }
            //親カテゴリ名の適否
            if (comboBoxParentCategory.SelectedIndex == -1)
            {
                messageDsp.DspMsg("M5025");//親カテゴリ名が選択されていません
                comboBoxParentCategory.Focus();
                return false;
            }
            //カテゴリ名の適否
            if (comboBoxCategory.SelectedIndex == -1)
            {
                messageDsp.DspMsg("M5026");//カテゴリ名が選択されていません
                comboBoxCategory.Focus();
                return false;
            }
            //Janコードの適否
            if (!String.IsNullOrEmpty(textBoxJanCD.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckNumeric(textBoxJanCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M5027");//JanCDは半角数値入力です
                    textBoxJanCD.Focus();
                    return false;
                }
                //文字数
                if (textBoxJanCD.TextLength != 13)
                {
                    messageDsp.DspMsg("M5028");//JanCDは13文字です
                    textBoxJanCD.Focus();
                    return false;
                }
            }
            //メーカー名の適否
            if (comboBoxMaker.SelectedIndex == -1)
            {
                DialogResult result = messageDsp.DspMsg("M5029");//メーカ名が選択されていません
                if (result == DialogResult.Cancel)
                {
                    comboBoxMaker.Focus();
                    return false;
                }
            }
            //型番の適否
            if (!String.IsNullOrEmpty(textBoxModelNo.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckHalfChar(textBoxModelNo.Text.Trim()))
                {
                    messageDsp.DspMsg("M5030"); //型番は半角入力です
                    textBoxModelNo.Focus();
                    return false;
                }
                //文字数
                if (textBoxModelNo.TextLength > 30)
                {
                    messageDsp.DspMsg("M5031");//型番は30文字以下です
                    textBoxModelNo.Focus();
                    return false;
                }
            }
            //定価の適否
            if (!String.IsNullOrEmpty(textBoxListPrice.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckNumeric(textBoxListPrice.Text.Trim()))
                {
                    messageDsp.DspMsg("M5032");//定価は半角数値入力です
                    textBoxListPrice.Focus();
                    return false;
                }
            }
            //店頭飯場価格の適否
            if (!String.IsNullOrEmpty(textBoxSellingPrice.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckNumeric(textBoxSellingPrice.Text.Trim()))
                {
                    messageDsp.DspMsg("M5033");//店頭販売価格は半角数値入力です
                    textBoxSellingPrice.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M5034");//店頭販売価格が入力されていません
                textBoxSellingPrice.Focus();
                return false;
            }
            //削除フラグの適否
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                messageDsp.DspMsg("M5008");//削除フラグが不確定の状態です
                checkBoxDeleteFlg.Focus();
                return false;
            }
            //備考の適否
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                //文字数
                if (textBoxComments.TextLength > 80)
                {
                    messageDsp.DspMsg("M5009");//備考は80文字以下です
                    textBoxComments.Focus();
                    return false;
                }
            }

            return true;
        }
        ///////////////////////////////
        //　5.3.2.2 商品情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：商品更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_Item GenerateDataAtUpdate()
        {
            // 定価がnullの場合
            string cListPrice = textBoxListPrice.Text.Trim();
            if (!String.IsNullOrEmpty(cListPrice))
            {
                cListPrice = textBoxListPrice.Text.Trim();
            }
            else
            {
                cListPrice = null;
            }
            // 更新データのセット
            return new M_Item
            {
                ItemCD = textBoxItemCD.Text.Trim(),
                ItemName = textBoxItemName.Text.Trim(),
                ItemKana = textBoxItemKana.Text.Trim(),
                CategoryCD = comboBoxCategory.SelectedValue.ToString(),
                JanCD = textBoxJanCD.Text.Trim(),
                MakerCD = comboBoxMaker.SelectedValue.ToString(),
                ModelNo = textBoxModelNo.Text.Trim(),
                ListPrice = int.Parse(cListPrice),
                SellingPrice = int.Parse(textBoxSellingPrice.Text.Trim()),
                DeleteFlg = checkBoxDeleteFlg.Checked,
                Comments = textBoxComments.Text.Trim()
            };
        }
        ///////////////////////////////
        //　5.3.2.3 商品情報更新
        //メソッド名：UpdateItem()
        //引　数   ：商品情報
        //戻り値   ：なし
        //機　能   ：商品情報の更新
        ///////////////////////////////
        private void UpdateItem(M_Item updItem)
        {
            //更新確認メッセージ
            DialogResult result = messageDsp.DspMsg("M5014");//商品データを更新してよろしいですか？
            if (result == DialogResult.Cancel)
            {
                return;
            }
            //商品情報の更新
            bool flg = itemDataAccess.UpdateItemData(updItem);
            if (flg == true)
            {
                messageDsp.DspMsg("M5015");//商品データを更新しました
            }
            else
            {
                messageDsp.DspMsg("M5016");//商品データ更新に失敗しました
            }
            textBoxItemCD.Focus();
            //入力エリアのクリア
            ClearInput();
            //画面更新
            GetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            textBoxItemCD.Text = "";
            textBoxItemName.Text = "";
            textBoxItemKana.Text = "";
            textBoxJanCD.Text = "";
            textBoxModelNo.Text = "";
            textBoxListPrice.Text = "";
            textBoxSellingPrice.Text = "";
            textBoxComments.Text = "";
            checkBoxDeleteFlg.Checked = false;
            comboBoxParentCategory.SelectedIndex = -1;
            comboBoxCategory.SelectedIndex = -1;
            comboBoxMaker.SelectedIndex = -1;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // 5.3.3.1 妥当な商品データ取得
            if (!GetValidDataAtDelete())
            {
                return;
            }
            // 5.3.3.2 商品情報削除
            DeleteItem();
            return;
        }

        ///////////////////////////////
        //　5.3.3.1 妥当な商品データ取得
        //メソッド名：GetValidDataAtDelete()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtDelete()
        {
            //商品CDの適否
            if (!String.IsNullOrEmpty(textBoxItemCD.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxItemCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M5001");//商品CDは半角英数字入力です
                    textBoxItemCD.Focus();
                    return false;
                }
                //文字数
                if (textBoxItemCD.TextLength != 8)
                {
                    messageDsp.DspMsg("M5002");//商品CDは8文字です
                    textBoxItemCD.Focus();
                    return false;
                }
                //存在ありチェック
                if (!itemDataAccess.CheckItemCDExistence(textBoxItemCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M5003");//入力された商品CDは既に存在しています
                    textBoxItemCD.Focus();
                    return false;
                }
            }
            else
            {
                messageDsp.DspMsg("M5004");//商品CDが入力されていません 
                textBoxItemCD.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //　5.3.3.2 商品情報削除
        //メソッド名：DeleteItem()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品情報の削除
        ///////////////////////////////
        private void DeleteItem()
        {
            DialogResult result = messageDsp.DspMsg("M5018");//商品データを削除してよろしいですか？

            if (result == DialogResult.Cancel)
            {
                return;
            }
            //商品情報の削除
            bool flg = itemDataAccess.DeleteItemData(textBoxItemCD.Text.Trim());

            if(flg == true)
            {
                messageDsp.DspMsg("M5019");//商品データを削除しました
            }
            else
            {
                messageDsp.DspMsg("M5020");//商品データ削除に失敗しました
            }
            textBoxItemCD.Focus();
            ClearInput();
            GetDataGridView();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 5.3.4.1 妥当な商品データ取得
            if (!GetValidDataAtSelect())
            {
                return;
            }
            // 5.3.4.2 商品情報抽出
            GenerateDataAtSelect();
            // 5.3.4.3 商品抽出結果表示
            SetSelectData();
        }
        ///////////////////////////////
        //　5.3.4.1 妥当な商品データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            //商品CDの適否
            if (!String.IsNullOrEmpty(textBoxItemCD.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxItemCD.Text.Trim()))
                {
                    messageDsp.DspMsg("M5001");//商品CDは半角英数字入力です
                    textBoxItemCD.Focus();
                    return false;
                }
                //文字数
                if (textBoxItemCD.TextLength != 8)
                {
                    messageDsp.DspMsg("M5002");//商品CDは8文字です
                    textBoxItemCD.Focus();
                    return false;
                }
            }
            //商品名の適否
            if (!String.IsNullOrEmpty(textBoxItemName.Text.Trim()))
            {
                //文字数
                if (textBoxItemName.TextLength > 25)
                {
                    messageDsp.DspMsg("M5006");//商品名は25文字以下です
                    textBoxItemName.Focus();
                    return false;
                }
            }
            //商品名カナの適否
            if (!String.IsNullOrEmpty(textBoxItemKana.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxItemKana.Text.Trim()))
                {
                    messageDsp.DspMsg("M5022");//商品名カナは半角カナ入力です
                    textBoxItemKana.Focus();
                    return false;
                }
                //文字数
                if (textBoxItemKana.TextLength > 50)
                {
                    messageDsp.DspMsg("M5023");//商品名カナは50文字以下です
                    textBoxItemKana.Focus();
                    return false;
                }
            }
            //型番の適否
            if (!String.IsNullOrEmpty(textBoxModelNo.Text.Trim()))
            {
                //文字種
                if (!dataInputFormCheck.CheckHalfChar(textBoxModelNo.Text.Trim()))
                {
                    messageDsp.DspMsg("M5030"); //型番は半角入力です
                    textBoxModelNo.Focus();
                    return false;
                }
                //文字数
                if (textBoxModelNo.TextLength > 30)
                {
                    messageDsp.DspMsg("M5031");//型番は30文字以下です
                    textBoxModelNo.Focus();
                    return false;
                }
            }
            return true;
        }
        ///////////////////////////////
        //　5.3.4.2 商品情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            // コンボボックスが未選択の場合Emptyを設定
            string cCategory = string.Empty;
            string cMaker = string.Empty;

            if(comboBoxCategory.SelectedIndex != -1)
            {
                cCategory = comboBoxCategory.SelectedValue.ToString();
            }
            if (comboBoxMaker.SelectedIndex != -1)
            {
                cMaker = comboBoxMaker.SelectedValue.ToString();
            }
            // 検索条件のセット
            M_ItemDsp selectCondition = new M_ItemDsp()
            {
                ItemCD = textBoxItemCD.Text.Trim(),
                ItemName = textBoxItemName.Text.Trim(),
                ItemKana = textBoxItemKana.Text.Trim(),
                ModelNo = textBoxModelNo.Text.Trim(),
                CategoryCD = cCategory,
                MakerCD = cMaker
            };
            // 商品データの抽出
            Item = itemDataAccess.GetItemData(selectCondition);
        }
        ///////////////////////////////
        //　5.3.4.3 商品抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPageNo.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewDsp.DataSource = Item;

            labelPage.Text = "/" + ((int)Math.Ceiling(Item.Count / (double)pageSize)) + "ページ";
            dataGridViewDsp.Refresh();
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
            //if (!String.IsNullOrEmpty(dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[1].Value.ToString()))
            //{
                    //selectedValueからdisplaymemberの取得
            //    string cValue = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[1].Value.ToString();
            //    comboBoxParentCategory.Text = categoryDataAccess.GetComboboxText(cValue);
            //}
            //else
            //{
            //    comboBoxParentCategory.SelectedIndex = -1;
            //}

            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxItemCD.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxItemName.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[1].Value.ToString();
            textBoxItemKana.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[2].Value.ToString();
            comboBoxParentCategory.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[4].Value.ToString();
            comboBoxCategory.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[6].Value.ToString();
            textBoxJanCD.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[7].Value.ToString();
            comboBoxMaker.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[9].Value.ToString();
            textBoxModelNo.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[10].Value.ToString();
            // 定価が設定されていない場合、テキストボックスにnullを設定
            if (!(dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[11].Value == null))
                textBoxListPrice.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[11].Value.ToString();
            else
                textBoxListPrice.Text = "";
            textBoxSellingPrice.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[12].Value.ToString();
            checkBoxDeleteFlg.Checked = (bool)dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[13].Value;
            textBoxComments.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[14].Value.ToString();
        }

        private void comboBoxParentCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 親カテゴリが選択されていない場合
            if(comboBoxParentCategory.SelectedIndex == -1)
            {
                return;
            }

            // 商品カテゴリデータの取得
            Category = categoryDataAccess.GetCategoryDspData(comboBoxParentCategory.SelectedValue.ToString());
            comboBoxCategory.DataSource = Category;
            comboBoxCategory.DisplayMember = "CategoryName";
            comboBoxCategory.ValueMember = "CategoryCD";
            comboBoxCategory.SelectedIndex = -1;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            SetFormDataGridView();
        }
    }
}
