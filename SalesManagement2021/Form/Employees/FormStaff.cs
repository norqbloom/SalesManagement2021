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
    public partial class FormStaff : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベーススタッフテーブルアクセス用クラスのインスタンス化
        StaffDataAccess staffDataAccess = new StaffDataAccess();
        //データベース部署テーブルアクセス用クラスのインスタンス化
        DivisionDataAccess divisionDataAccess = new DivisionDataAccess();
        //データベース役職テーブルアクセス用クラスのインスタンス化
        PositionDataAccess positionDataAccess = new PositionDataAccess();
        //データベース店舗テーブルアクセス用クラスのインスタンス化
        StoreDataAccess storeDataAccess = new StoreDataAccess();
        //データベース権限テーブルアクセス用クラスのインスタンス化
        AuthorityDataAccess authorityDataAccess = new AuthorityDataAccess();
        //パスワードハッシュ用クラスのインスタンス化
        PasswordHash passwordHash = new PasswordHash();

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用のスタッフデータ
        private static List<M_StaffDsp> Staff;
        //コンボボックス用の部署データ
        private static List<M_Division> Division;
        //コンボボックス用の役職データ
        private static List<M_Position> Position;
        //コンボボックス用の店舗データ
        private static List<M_Store> Store;
        //コンボボックス用の権限データ
        private static List<M_Authority> Authority;

       
    public FormStaff()
        {
            InitializeComponent();
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            //ログイン名の表示
            labelLoginName.Text = FormMenu.loginName;

            //デートタイムピッカの設定
            SetFormDateTimePiker();

            // コンボボックスの設定
            SetFormComboBox();

            // データグリッドビューの表示
            SetFormDataGridView();
        }
        ///////////////////////////////
        //メソッド名：SetFormDateTimePiker()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：デートタイムピッカの初期設定
        ///////////////////////////////
        private void SetFormDateTimePiker()
        {
            dateTimePickerBirthday.Value = DateTime.Now;
            dateTimePickerBirthday.Checked = false;
            dateTimePickerJoinDate.Value = DateTime.Now;
            dateTimePickerJoinDate.Checked = false;
        }

        ///////////////////////////////
        //メソッド名：SetFormComboBox()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：コンボボックスのデータ設定
        ///////////////////////////////
        private void SetFormComboBox()
        {
            // 店舗データの取得
            Store = storeDataAccess.GetStoreDspData();
            comboBoxStore.DataSource = Store;
            comboBoxStore.DisplayMember = "StoreName";
            comboBoxStore.ValueMember = "StoreCD";
            // コンボボックスを読み取り専用
            comboBoxStore.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStore.SelectedIndex = -1;

            // 役職データの取得
            Position = positionDataAccess.GetPositionDspData();
            comboBoxPosition.DataSource = Position;
            comboBoxPosition.DisplayMember = "PositionName";
            comboBoxPosition.ValueMember = "PositionCD";
            // コンボボックスを読み取り専用
            comboBoxPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPosition.SelectedIndex = -1;

            // 部署データの取得
            Division = divisionDataAccess.GetDivisionDspData();
            comboBoxDivision.DataSource = Division;
            comboBoxDivision.DisplayMember = "DivisionName";
            comboBoxDivision.ValueMember = "DivisionCD";
            // コンボボックスを読み取り専用
            comboBoxDivision.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDivision.SelectedIndex = -1;

            // 権限データの取得
            Authority = authorityDataAccess.GetAuthorityDspData();
            comboBoxAuthority.DataSource = Authority;
            comboBoxAuthority.DisplayMember = "AuthorityName";
            comboBoxAuthority.ValueMember = "AuthorityCD";
            // コンボボックスを読み取り専用
            comboBoxAuthority.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAuthority.SelectedIndex = -1;
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            // 8.3.1.1 妥当なスタッフデータ取得
            if (!GetValidDataAtRegistration())
                return;

            // 8.3.1.2 スタッフ情報作成
            var regStaff = GenerateDataAtRegistration();

            // 8.3.1.3 スタッフ情報登録
            RegistrationStaff(regStaff);
        }

        ///////////////////////////////
        //　8.3.1.1 妥当なスタッフデータ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {

            // スタッフCDの適否
            if (!String.IsNullOrEmpty(textBoxStaffCD.Text.Trim()))
            {
                // スタッフCDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxStaffCD.Text.Trim()))
                {
                    //MessageBox.Show("スタッフCDは全て半角英数字入力です");
                    messageDsp.DspMsg("M3001");
                    textBoxStaffCD.Focus();
                    return false;
                }
                // スタッフCDの文字数チェック
                if (textBoxStaffCD.TextLength != 5)
                {
                    //MessageBox.Show("スタッフCDは5文字です");
                    messageDsp.DspMsg("M3002");
                    textBoxStaffCD.Focus();
                    return false;
                }
               
                // スタッフCDの重複チェック
                if (staffDataAccess.CheckStaffCDExistence(textBoxStaffCD.Text.Trim()))
                {
                    //MessageBox.Show("入力されたスタッフCDは既に存在します");
                    messageDsp.DspMsg("M3003");
                    textBoxStaffCD.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("スタッフCDが入力されていません");
                messageDsp.DspMsg("M3004");
                textBoxStaffCD.Focus();
                return false;
            }
            
            // スタッフ名の適否
            if (!String.IsNullOrEmpty(textBoxStaffName.Text.Trim()))
            {
                // スタッフ名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxStaffName.Text.Trim()))
                {
                    //MessageBox.Show("スタッフ名は全て全角入力です");
                    messageDsp.DspMsg("M3005");
                    textBoxStaffName.Focus();
                    return false;
                }
                // スタッフ名の文字数チェック
                if (textBoxStaffName.TextLength > 20)
                {
                    //MessageBox.Show("スタッフ名は20文字以下です");
                    messageDsp.DspMsg("M3006");
                    textBoxStaffName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("スタッフ名が入力されていません");
                messageDsp.DspMsg("M3007");
                textBoxStaffName.Focus();
                return false;
            }

            // スタッフ名カナの適否
            if (!String.IsNullOrEmpty(textBoxStaffNameKana.Text.Trim()))
            {
                // スタッフ名カナの半角カナチェック
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxStaffNameKana.Text.Trim()))
                {
                    //MessageBox.Show("スタッフ名カナは半角カナ入力です");
                    messageDsp.DspMsg("M3022");
                    textBoxStaffNameKana.Focus();
                    return false;
                }
                // スタッフ名カナの文字数チェック
                if (textBoxStaffNameKana.TextLength > 40)
                {
                    //MessageBox.Show("スタッフ名カナは40文字以下です");
                    messageDsp.DspMsg("M3023");
                    textBoxStaffNameKana.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("スタッフ名カナが入力されていません");
                messageDsp.DspMsg("M3024");
                textBoxStaffNameKana.Focus();
                return false;
            }
            // 郵便番号の数値チェック
            if (!String.IsNullOrEmpty(textBoxPostal.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxPostal.Text.Trim()))
                {
                    //MessageBox.Show("郵便番号は半角数値です");
                    messageDsp.DspMsg("M3025");
                    textBoxPostal.Focus();
                    return false;
                }
                // 郵便番号の文字数チェック
                if (textBoxPostal.TextLength != 7)
                {
                    //MessageBox.Show("郵便番号は7文字です");
                    messageDsp.DspMsg("M3026");
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
                    messageDsp.DspMsg("M3027");
                    textBoxAddress.Focus();
                    return false;
                }
            }
            // 住所カナの半角カナチェック
            if (!String.IsNullOrEmpty(textBoxAddressKana.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxAddressKana.Text.Trim()))
                {
                    //MessageBox.Show("住所カナは半角カタカナです");
                    messageDsp.DspMsg("M3028");
                    textBoxAddressKana.Focus();
                    return false;
                }
                // 住所カナの文字数チェック
                if (textBoxAddressKana.TextLength > 100)
                {
                    //MessageBox.Show("住所カナは100文字以下です");
                    messageDsp.DspMsg("M3029");
                    textBoxAddressKana.Focus();
                    return false;
                }
            }

            // 電話番号の半角数値チェック
            if (!String.IsNullOrEmpty(textBoxTel.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxTel.Text.Trim()))
                {
                    //MessageBox.Show("電話番号は半角数値です");
                    messageDsp.DspMsg("M3030");
                    textBoxTel.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxTel.TextLength > 12)
                {
                    //MessageBox.Show("電話番号は12文字以下です");
                    messageDsp.DspMsg("M3031");
                    textBoxTel.Focus();
                    return false;
                }
            }
            // 携帯番号の半角数値チェック
            if (!String.IsNullOrEmpty(textBoxMobileTel.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxMobileTel.Text.Trim()))
                {
                    //MessageBox.Show("携帯番号は半角数値です");
                    messageDsp.DspMsg("M3032");
                    textBoxMobileTel.Focus();
                    return false;
                }
                // 携帯番号の文字数チェック
                if (textBoxMobileTel.TextLength > 12)
                {
                    //MessageBox.Show("携帯番号は12文字以下です");
                    messageDsp.DspMsg("M3033");
                    textBoxMobileTel.Focus();
                    return false;
                }
            }

            // メールアドレスの入力形式チェック
            if (!String.IsNullOrEmpty(textBoxMail.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckMailAddress(textBoxMail.Text.Trim()))
                {
                    //MessageBox.Show("メールアドレスの入力形式が不正です");
                    messageDsp.DspMsg("M3034");
                    textBoxAddress.Focus();
                    return false;
                }
                // メールアドレスの文字数チェック
                if (textBoxMail.TextLength > 30)
                {
                    //MessageBox.Show("メールアドレスは30文字以下です");
                    messageDsp.DspMsg("M3035");
                    textBoxAddress.Focus();
                    return false;
                }
            }

            // 店舗名の選択チェック
            if (comboBoxStore.SelectedIndex == -1)
            {
                //MessageBox.Show("店舗名が選択されていません");
                messageDsp.DspMsg("M3036");
                comboBoxStore.Focus();
                return false;
            }

            // 役職名の選択チェック
            if (comboBoxPosition.SelectedIndex == -1)
            {
                //MessageBox.Show("役職名が選択されていません");
                messageDsp.DspMsg("M3037");
                comboBoxPosition.Focus();
                return false;
            }

            // 部署名の選択チェック
            if (comboBoxDivision.SelectedIndex == -1)
            {
                //MessageBox.Show("部署名が選択されていません");
                messageDsp.DspMsg("M3038");
                comboBoxDivision.Focus();
                return false;
            }

            // 権限の選択チェック
            if (comboBoxAuthority.SelectedIndex == -1)
            {
                //MessageBox.Show("権限が選択されていません");
                messageDsp.DspMsg("M3039");
                comboBoxAuthority.Focus();
                return false;
            }

            // ログインIDの未入力チェック
            if (!String.IsNullOrEmpty(textBoxLoginID.Text.Trim()))
            {
                // ログインIDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxLoginID.Text.Trim()))
                {
                    //MessageBox.Show("ログインIDは全て半角英数字入力です");
                    messageDsp.DspMsg("M3040");
                    textBoxLoginID.Focus();
                    return false;
                }
                // ログインIDの文字数チェック
                if (textBoxLoginID.TextLength > 18)
                {
                    //MessageBox.Show("ログインIDは18文字以下です");
                    messageDsp.DspMsg("M3041");
                    textBoxLoginID.Focus();
                    return false;
                }
                // ログインIDの重複チェック
                if (staffDataAccess.CheckUserIDExistenceCount(textBoxLoginID.Text.Trim()))
                {
                    //MessageBox.Show("入力されたログインIDは既に存在します");
                    messageDsp.DspMsg("M3042");
                    textBoxLoginID.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("ログインIDが入力されていません");
                messageDsp.DspMsg("M3043");
                textBoxLoginID.Focus();
                return false;
            }

            // ログインPWの未入力チェック
            if (!String.IsNullOrEmpty(textBoxLoginPW.Text.Trim()))
            {
                // ログインPWの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxLoginPW.Text.Trim()))
                {
                    //MessageBox.Show("ログインPWは全て半角英数字入力です");
                    messageDsp.DspMsg("M3044");
                    textBoxLoginPW.Focus();
                    return false;
                }
                // ログインPWの文字数チェック
                if (textBoxLoginPW.TextLength > 18)
                {
                    //MessageBox.Show("ログインPWは18文字以下です");
                    messageDsp.DspMsg("M3045");
                    textBoxLoginPW.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("ログインPWが入力されていません");
                messageDsp.DspMsg("M3046");
                textBoxLoginPW.Focus();
                return false;
            }

            // 削除フラグの適否
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("削除フラグが不確定の状態です");
                messageDsp.DspMsg("M3008");
                checkBoxDeleteFlg.Focus();
                return false;
            }

            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if (textBoxComments.TextLength > 80)
                {
                    //MessageBox.Show("備考は80文字以下です");
                    messageDsp.DspMsg("M3009");
                    textBoxComments.Focus();
                    return false;
                }
            }
            return true;
        }
        ///////////////////////////////
        //　8.3.1.2 スタッフ情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：スタッフ登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_Staff GenerateDataAtRegistration()
        {
            DateTime? mBirthday;
            if (dateTimePickerBirthday.Checked == false)
                mBirthday = null;
            else
                mBirthday = DateTime.Parse(dateTimePickerBirthday.Text);

            DateTime? mJoinDate;
            if (dateTimePickerJoinDate.Checked == false)
                mJoinDate = null;
            else
                mJoinDate = DateTime.Parse(dateTimePickerJoinDate.Text);

            // パスワードハッシュ化
            string pw = passwordHash.CreatePasswordHash(textBoxLoginPW.Text.Trim());

            return new M_Staff
            {
                StaffCD = textBoxStaffCD.Text.Trim(),
                StaffName = textBoxStaffName.Text.Trim(),
                StaffNameKana = textBoxStaffNameKana.Text.Trim(),
                StaffPostal = textBoxPostal.Text.Trim(),
                StaffAddress = textBoxAddress.Text.Trim(),
                StaffAddressKana = textBoxAddressKana.Text.Trim(),
                StaffTel = textBoxTel.Text.Trim(),
                StaffMobileTel = textBoxMobileTel.Text.Trim(),
                StaffMail = textBoxMail.Text.Trim(),
                StaffBirthday = mBirthday,
                StaffJoinDate = mJoinDate,
                StoreCD = comboBoxStore.SelectedValue.ToString(),
                PositionCD = comboBoxPosition.SelectedValue.ToString(),
                DivisionCD = comboBoxDivision.SelectedValue.ToString(),
                AuthorityCD = comboBoxAuthority.SelectedValue.ToString(),
                StaffUserID = textBoxLoginID.Text.Trim(),
                StaffPassword = pw,
                DeleteFlg = checkBoxDeleteFlg.Checked,
                Comments = textBoxComments.Text.Trim()

            };
        }
        ///////////////////////////////
        //　8.3.1.3 スタッフ情報登録
        //メソッド名：RegistrationStaff()
        //引　数   ：スタッフ情報
        //戻り値   ：なし
        //機　能   ：スタッフ情報の登録
        ///////////////////////////////
        private void RegistrationStaff(M_Staff regStaff)
        {
            // 登録確認メッセージ
            DialogResult result = messageDsp.DspMsg("M3010");
            if (result == DialogResult.Cancel)
                return;

            // スタッフ情報の登録
            bool flg = staffDataAccess.AddStaffData(regStaff);
            if (flg == true)
                //MessageBox.Show("データを登録しました。");
                messageDsp.DspMsg("M3011");
            else
                //MessageBox.Show("データの登録に失敗しました。");
                messageDsp.DspMsg("M3012");

            textBoxStaffCD.Focus();

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

            // スタッフデータの取得
            Staff = staffDataAccess.GetStaffData();

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
            dataGridViewDsp.DataSource = Staff.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGridViewDsp.Columns[0].Width = 80;
            dataGridViewDsp.Columns[1].Width = 130;
            dataGridViewDsp.Columns[2].Width = 130;
            dataGridViewDsp.Columns[3].Width = 70;
            dataGridViewDsp.Columns[3].Visible = false;
            dataGridViewDsp.Columns[4].Width = 130;
            dataGridViewDsp.Columns[4].Visible = false;
            dataGridViewDsp.Columns[5].Width = 130;
            dataGridViewDsp.Columns[5].Visible = false;
            dataGridViewDsp.Columns[6].Width = 130;
            dataGridViewDsp.Columns[6].Visible = false;
            dataGridViewDsp.Columns[7].Width = 130;
            dataGridViewDsp.Columns[7].Visible = false;
            dataGridViewDsp.Columns[8].Width = 130;
            dataGridViewDsp.Columns[8].Visible = false;
            dataGridViewDsp.Columns[9].Width = 130;
            dataGridViewDsp.Columns[9].Visible = false;
            dataGridViewDsp.Columns[10].Width = 130;
            dataGridViewDsp.Columns[10].Visible = false;
            dataGridViewDsp.Columns[11].Width = 50;
            dataGridViewDsp.Columns[11].Visible = false;
            dataGridViewDsp.Columns[12].Width = 100;
            dataGridViewDsp.Columns[13].Width = 50;
            dataGridViewDsp.Columns[13].Visible = false;
            dataGridViewDsp.Columns[14].Width = 100;
            dataGridViewDsp.Columns[15].Width = 50;
            dataGridViewDsp.Columns[15].Visible = false;
            dataGridViewDsp.Columns[16].Width = 100;
            dataGridViewDsp.Columns[17].Width = 50;
            dataGridViewDsp.Columns[17].Visible = false;
            dataGridViewDsp.Columns[18].Width = 100;
            dataGridViewDsp.Columns[19].Width = 100;
            dataGridViewDsp.Columns[20].Width = 130;
            dataGridViewDsp.Columns[20].Visible = false;
            dataGridViewDsp.Columns[21].Width = 80;
            dataGridViewDsp.Columns[22].Width = 250;

            //各列の文字位置の指定
            dataGridViewDsp.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDsp.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDsp.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Staff.Count / (double)pageSize)) + "ページ";

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
            dataGridViewDsp.DataSource = Staff.Take(pageSize).ToList();

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
            dataGridViewDsp.DataSource = Staff.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            int lastNo = (int)Math.Ceiling(Staff.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewDsp.DataSource = Staff.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewDsp.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Staff.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(Staff.Count / (double)pageSize) - 1;
            dataGridViewDsp.DataSource = Staff.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            dataGridViewPrinter.Preview("スタッフ管理");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 8.3.2.1 妥当なスタッフデータ取得
            if (!GetValidDataAtUpdate())
                return;

            // 8.3.2.2 スタッフ情報作成
            var updStaff = GenerateDataAtUpdate();

            // 8.3.2.3 スタッフ情報更新
            UpdateStaff(updStaff);
        }
        ///////////////////////////////
        //8.3.2.1 妥当なスタッフデータ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {

            // スタッフCDの適否
            if (!String.IsNullOrEmpty(textBoxStaffCD.Text.Trim()))
            {
                // スタッフCDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxStaffCD.Text.Trim()))
                {
                    //MessageBox.Show("スタッフCDは全て半角英数字入力です");
                    messageDsp.DspMsg("M3001");
                    textBoxStaffCD.Focus();
                    return false;
                }
                // スタッフCDの文字数チェック
                if (textBoxStaffCD.TextLength != 5)
                {
                    //MessageBox.Show("スタッフCDは5文字です");
                    messageDsp.DspMsg("M3002");
                    textBoxStaffCD.Focus();
                    return false;
                }
                // スタッフCDの重複チェック
                if (!staffDataAccess.CheckStaffCDExistence(textBoxStaffCD.Text.Trim()))
                {
                    //MessageBox.Show("入力されたスタッフCDは存在しません");
                    messageDsp.DspMsg("M3013");
                    textBoxStaffCD.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("スタッフCDが入力されていません");
                messageDsp.DspMsg("M3004");
                textBoxStaffCD.Focus();
                return false;
            }
            
            // スタッフ名の未入力チェック
            if (!String.IsNullOrEmpty(textBoxStaffName.Text.Trim()))
            {
                // スタッフ名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxStaffName.Text.Trim()))
                {
                    //MessageBox.Show("スタッフ名は全て全角入力です");
                    messageDsp.DspMsg("M3005");
                    textBoxStaffName.Focus();
                    return false;
                }
                // スタッフ名の文字数チェック
                if (textBoxStaffName.TextLength > 20)
                {
                    //MessageBox.Show("スタッフ名は20文字以下です");
                    messageDsp.DspMsg("M3006");
                    textBoxStaffName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("スタッフ名が入力されていません");
                messageDsp.DspMsg("M3007");
                textBoxStaffName.Focus();
                return false;
            }

            // スタッフ名カナの適否
            if (!String.IsNullOrEmpty(textBoxStaffNameKana.Text.Trim()))
            {
                // スタッフ名の半角カナチェック
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxStaffNameKana.Text.Trim()))
                {
                    //MessageBox.Show("スタッフ名カナは半角カナ入力です");
                    messageDsp.DspMsg("M3022");
                    textBoxStaffNameKana.Focus();
                    return false;
                }
                // スタッフ名カナの文字数チェック
                if (textBoxStaffNameKana.TextLength > 40)
                {
                    //MessageBox.Show("スタッフ名カナは40文字以下です");
                    messageDsp.DspMsg("M3023");
                    textBoxStaffNameKana.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("スタッフ名カナが入力されていません");
                messageDsp.DspMsg("M3024");
                textBoxStaffNameKana.Focus();
                return false;
            }
            // 郵便番号の数値チェック
            if (!String.IsNullOrEmpty(textBoxPostal.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxPostal.Text.Trim()))
                {
                    //MessageBox.Show("郵便番号は半角数値です");
                    messageDsp.DspMsg("M3025");
                    textBoxPostal.Focus();
                    return false;
                }
                // 郵便番号の文字数チェック
                if (textBoxPostal.TextLength != 7)
                {
                    //MessageBox.Show("郵便番号は7文字です");
                    messageDsp.DspMsg("M3026");
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
                    messageDsp.DspMsg("M3027");
                    textBoxAddress.Focus();
                    return false;
                }
            }
            // 住所カナの半角カナチェック
            if (!String.IsNullOrEmpty(textBoxAddressKana.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxAddressKana.Text.Trim()))
                {
                    //MessageBox.Show("住所カナは半角カタカナです");
                    messageDsp.DspMsg("M3028");
                    textBoxAddressKana.Focus();
                    return false;
                }
                // 住所カナの文字数チェック
                if (textBoxAddressKana.TextLength > 100)
                {
                    //MessageBox.Show("住所カナは100文字以下です");
                    messageDsp.DspMsg("M3029");
                    textBoxAddressKana.Focus();
                    return false;
                }
            }
           
            // 電話番号の半角数値チェック
            if (!String.IsNullOrEmpty(textBoxTel.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxTel.Text.Trim()))
                {
                    //MessageBox.Show("電話番号は半角数値です");
                    messageDsp.DspMsg("M3030");
                    textBoxTel.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxTel.TextLength > 12)
                {
                    //MessageBox.Show("電話番号は12文字以下です");
                    messageDsp.DspMsg("M3031");
                    textBoxTel.Focus();
                    return false;
                }
            }

            // 携帯番号の半角数値チェック
            if (!String.IsNullOrEmpty(textBoxMobileTel.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxMobileTel.Text.Trim()))
                {
                    //MessageBox.Show("携帯番号は半角数値です");
                    messageDsp.DspMsg("M3032");
                    textBoxMobileTel.Focus();
                    return false;
                }
                // 携帯番号の文字数チェック
                if (textBoxMobileTel.TextLength > 12)
                {
                    //MessageBox.Show("携帯番号は12文字以下です");
                    messageDsp.DspMsg("M3033");
                    textBoxMobileTel.Focus();
                    return false;
                }
            }
            
            // メールアドレスの入力形式チェック
            if (!String.IsNullOrEmpty(textBoxMail.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckMailAddress(textBoxMail.Text.Trim()))
                {
                    //MessageBox.Show("メールアドレスの入力形式が不正です");
                    messageDsp.DspMsg("M3034");
                    textBoxAddress.Focus();
                    return false;
                }
                // メールアドレスの文字数チェック
                if (textBoxMail.TextLength > 30)
                {
                    //MessageBox.Show("メールアドレスは30文字以下です");
                    messageDsp.DspMsg("M3035");
                    textBoxAddress.Focus();
                    return false;
                }
            }

            // 店舗名の選択チェック
            if (comboBoxStore.SelectedIndex == -1)
            {
                //MessageBox.Show("店舗名が選択されていません");
                messageDsp.DspMsg("M3036");
                comboBoxStore.Focus();
                return false;
            }

            // 役職名の選択チェック
            if (comboBoxPosition.SelectedIndex == -1)
            {
                //MessageBox.Show("役職名が選択されていません");
                messageDsp.DspMsg("M3037");
                comboBoxPosition.Focus();
                return false;
            }

            // 部署名の選択チェック
            if (comboBoxDivision.SelectedIndex == -1)
            {
                //MessageBox.Show("部署名が選択されていません");
                messageDsp.DspMsg("M3038");
                comboBoxDivision.Focus();
                return false;
            }

            // 権限の選択チェック
            if (comboBoxAuthority.SelectedIndex == -1)
            {
                //MessageBox.Show("権限が選択されていません");
                messageDsp.DspMsg("M3039");
                comboBoxAuthority.Focus();
                return false;
            }

            // ログインIDの適否
            if (!String.IsNullOrEmpty(textBoxLoginID.Text.Trim()))
            {
                // ログインIDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxLoginID.Text.Trim()))
                {
                    //MessageBox.Show("ログインIDは全て半角英数字入力です");
                    messageDsp.DspMsg("M3040");
                    textBoxLoginID.Focus();
                    return false;
                }
                // ログインIDの文字数チェック
                if (textBoxLoginID.TextLength > 18)
                {
                    //MessageBox.Show("ログインIDは18文字以下です");
                    messageDsp.DspMsg("M3041");
                    textBoxLoginID.Focus();
                    return false;
                }
                
                // ログインIDが変更されているかListデータと比較
                var loginData = Staff.Single(x => x.StaffCD == textBoxStaffCD.Text);
                if (loginData.StaffUserID.ToString() != textBoxLoginID.Text)
                {
                    // ログインIDの重複チェック
                    if (staffDataAccess.CheckUserIDExistenceCount(textBoxLoginID.Text.Trim()))
                    {
                        //MessageBox.Show("入力されたログインIDは既に使われています");
                        messageDsp.DspMsg("M3042");
                        textBoxLoginID.Focus();
                        return false;
                    }
                }
            }
            else
            {
                //MessageBox.Show("ログインIDが入力されていません");
                messageDsp.DspMsg("M3043");
                textBoxLoginID.Focus();
                return false;
            }

            // ログインPW入力時のログインPWの半角英数字チェック
            if (!String.IsNullOrEmpty(textBoxLoginPW.Text.Trim()))
            {
                if(!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxLoginPW.Text.Trim()))
                {
                    //MessageBox.Show("ログインPWは半角英数字入力です");
                    messageDsp.DspMsg("M3044");
                    textBoxLoginPW.Focus();
                    return false;
                }
                // ログインPWの文字数チェック
                if (textBoxLoginPW.TextLength > 18)
                {
                    //MessageBox.Show("ログインPWは18文字以下です");
                    messageDsp.DspMsg("M3045");
                    textBoxLoginPW.Focus();
                    return false;
                }
            }

            // 削除フラグの適否
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("削除フラグが不確定の状態です");
                messageDsp.DspMsg("M3008");
                checkBoxDeleteFlg.Focus();
                return false;
            }

            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if (textBoxComments.TextLength > 80)
                {
                    //MessageBox.Show("備考は80文字以下です");
                    messageDsp.DspMsg("M3009");
                    textBoxComments.Focus();
                    return false;
                }
            }
            return true;
        }
        ///////////////////////////////
        //　8.3.2.2 スタッフ情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：スタッフ更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_Staff GenerateDataAtUpdate()
        {
            DateTime? mBirthday;
            if (dateTimePickerBirthday.Checked == false)
                mBirthday = null;
            else
                mBirthday = DateTime.Parse(dateTimePickerBirthday.Text);

            DateTime? mJoinDate;
            if (dateTimePickerJoinDate.Checked == false)
                mJoinDate = null;
            else
                mJoinDate = DateTime.Parse(dateTimePickerJoinDate.Text);

            // パスワード入力時、パスワードハッシュ化
            string pw = "";
            if (!String.IsNullOrEmpty(textBoxLoginPW.Text.Trim()))
                pw = passwordHash.CreatePasswordHash(textBoxLoginPW.Text.Trim());


            // 更新データのセット
            return new M_Staff
            {
                StaffCD = textBoxStaffCD.Text.Trim(),
                StaffName = textBoxStaffName.Text.Trim(),
                StaffNameKana = textBoxStaffNameKana.Text.Trim(),
                StaffPostal = textBoxPostal.Text.Trim(),
                StaffAddress = textBoxAddress.Text.Trim(),
                StaffAddressKana = textBoxAddressKana.Text.Trim(),
                StaffTel = textBoxTel.Text.Trim(),
                StaffMobileTel = textBoxMobileTel.Text.Trim(),
                StaffMail = textBoxMail.Text.Trim(),
                StaffBirthday = mBirthday,
                StaffJoinDate = mJoinDate,
                StoreCD = comboBoxStore.SelectedValue.ToString(),
                PositionCD = comboBoxPosition.SelectedValue.ToString(),
                DivisionCD = comboBoxDivision.SelectedValue.ToString(),
                AuthorityCD = comboBoxAuthority.SelectedValue.ToString(),
                StaffUserID = textBoxLoginID.Text.Trim(),
                StaffPassword = pw,
                DeleteFlg = checkBoxDeleteFlg.Checked,
                Comments = textBoxComments.Text.Trim()

            };
        }
        ///////////////////////////////
        //　8.3.2.3 スタッフ情報更新
        //メソッド名：UpdateStaff()
        //引　数   ：スタッフ情報
        //戻り値   ：なし
        //機　能   ：スタッフ情報の更新
        ///////////////////////////////
        private void UpdateStaff(M_Staff updStaff)
        {
            // 更新確認メッセージ
            DialogResult result = messageDsp.DspMsg("M3014");
            if (result == DialogResult.Cancel)
                return;

            // スタッフ情報の更新
            bool flg = staffDataAccess.UpdateStaffData(updStaff);
            if (flg == true)
                //MessageBox.Show("データを更新しました。");
                messageDsp.DspMsg("M3015");
            else
                //MessageBox.Show("データの更新に失敗しました。");
                messageDsp.DspMsg("M3016");

            textBoxStaffCD.Focus();

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
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxStaffCD.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxStaffName.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[1].Value.ToString();
            textBoxStaffNameKana.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[2].Value.ToString();
            textBoxPostal.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[3].Value.ToString();
            textBoxAddress.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[4].Value.ToString();
            textBoxAddressKana.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[5].Value.ToString();
            textBoxTel.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[6].Value.ToString();
            textBoxMobileTel.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[7].Value.ToString();
            textBoxMail.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[8].Value.ToString();
            //日付が設定されていない場合、初期値として現在の日付を設定
            if (dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[9].Value == null)
            {
                dateTimePickerBirthday.Value = DateTime.Now;
                dateTimePickerBirthday.Checked = false;
            }
            else
                dateTimePickerBirthday.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[9].Value.ToString();

            if (dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[10].Value == null)
            {
                dateTimePickerJoinDate.Value = DateTime.Now;
                dateTimePickerJoinDate.Checked = false;
            }
            else
                dateTimePickerJoinDate.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[10].Value.ToString();

            comboBoxStore.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[12].Value.ToString();
            comboBoxPosition.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[14].Value.ToString();
            comboBoxDivision.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[16].Value.ToString();
            comboBoxAuthority.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[18].Value.ToString();
            textBoxLoginID.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[19].Value.ToString();
            checkBoxDeleteFlg.Checked = (bool)dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[21].Value;
            textBoxComments.Text = dataGridViewDsp.Rows[dataGridViewDsp.CurrentRow.Index].Cells[22].Value.ToString();
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
            textBoxStaffCD.Text = "";
            textBoxStaffName.Text = "";
            textBoxStaffNameKana.Text = "";
            textBoxPostal.Text = "";
            textBoxAddress.Text = "";
            textBoxAddressKana.Text = "";
            textBoxTel.Text = "";
            textBoxMobileTel.Text = "";
            textBoxMail.Text = "";
            // デートタイムピッカの設定
            SetFormDateTimePiker();

            dateTimePickerJoinDate.Checked = false;
            comboBoxStore.SelectedIndex = -1;
            comboBoxPosition.SelectedIndex = -1;
            comboBoxDivision.SelectedIndex = -1;
            comboBoxAuthority.SelectedIndex = -1;
            textBoxLoginID.Text = "";
            textBoxLoginPW.Text = "";
            checkBoxDeleteFlg.Checked = false;
            textBoxComments.Text = "";

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // 8.3.3.1 妥当なスタッフデータ取得
            if (!GetValidDataAtDelete())
                return;

            // 8.3.3.2 スタッフ情報削除
            DeleteStaff();
        }
        ///////////////////////////////
        //　8.3.3.1 妥当なスタッフデータ取得
        //メソッド名：GetValidDataAtDelete()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtDelete()
        {

            // スタッフCDの適否
            if (!String.IsNullOrEmpty(textBoxStaffCD.Text.Trim()))
            {
                // スタッフCDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxStaffCD.Text.Trim()))
                {
                    //MessageBox.Show("スタッフCDは全て半角英数字入力です");
                    messageDsp.DspMsg("M3001");
                    textBoxStaffCD.Focus();
                    return false;
                }
                // スタッフCDの文字数チェック
                if (textBoxStaffCD.TextLength != 5)
                {
                    //MessageBox.Show("スタッフCDは5文字です");
                    messageDsp.DspMsg("M3002");
                    textBoxStaffCD.Focus();
                    return false;
                }
                // スタッフCDの存在チェック
                if (!staffDataAccess.CheckStaffCDExistence(textBoxStaffCD.Text.Trim()))
                {
                    //MessageBox.Show("入力されたスタッフCDは存在しません");
                    messageDsp.DspMsg("M3013");
                    textBoxStaffCD.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("スタッフCDが入力されていません");
                messageDsp.DspMsg("M3004");
                textBoxStaffCD.Focus();
                return false;
            }
            return true;
        }

        ///////////////////////////////
        //　8.3.3.2 スタッフ情報削除
        //メソッド名：DeleteDavision()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：スタッフ情報の削除
        ///////////////////////////////
        private void DeleteStaff()
        {
            // 削除確認メッセージ
            DialogResult result = messageDsp.DspMsg("M3018");
            if (result == DialogResult.Cancel)
                return;

            // スタッフ情報の削除
            bool flg = staffDataAccess.DeleteStaffData(textBoxStaffCD.Text);
            if (flg == true)
                //MessageBox.Show("データを削除しました。");
                messageDsp.DspMsg("M3019");
            else
                //MessageBox.Show("データの削除に失敗しました。");
                messageDsp.DspMsg("M3020");

            textBoxStaffCD.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 8.3.4.1 妥当なスタッフデータ取得
            if (!GetValidDataAtSelect())
                return;

            // 8.3.4.2 スタッフ情報抽出
            GenerateDataAtSelect();

            // 8.3.4.3 スタッフ抽出結果表示
            SetSelectData();

        }

        ///////////////////////////////
        //　8.3.4.1 妥当なスタッフデータ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {

            // スタッフCD入力時チェック
            if (!String.IsNullOrEmpty(textBoxStaffCD.Text.Trim()))
            {
                // スタッフCDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxStaffCD.Text.Trim()))
                {
                    //MessageBox.Show("スタッフCDは全て半角英数字入力です");
                    messageDsp.DspMsg("M3001");
                    textBoxStaffCD.Focus();
                    return false;
                }
                // スタッフCDの文字数チェック
                if (textBoxStaffCD.TextLength > 5)
                {
                    //MessageBox.Show("スタッフCDは5文字までです");
                    messageDsp.DspMsg("M3002");
                    textBoxStaffCD.Focus();
                    return false;
                }
            }

            //スタッフ名入力時のチェック
            if(!String.IsNullOrEmpty(textBoxStaffName.Text.Trim()))
            {
                // スタッフ名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxStaffName.Text.Trim()))
                {
                    //MessageBox.Show("スタッフ名は全て全角入力です");
                    messageDsp.DspMsg("M3005");
                    textBoxStaffName.Focus();
                    return false;
                }
                // スタッフ名の文字数チェック
                if (textBoxStaffName.TextLength > 20)
                {
                    //MessageBox.Show("スタッフ名は20文字以下です");
                    messageDsp.DspMsg("M3006");
                    textBoxStaffName.Focus();
                    return false;
                }
            }

            //スタッフ名カナ入力時のチェック
            if (!String.IsNullOrEmpty(textBoxStaffNameKana.Text.Trim()))
            {
                // スタッフ名の半角カナチェック
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxStaffNameKana.Text.Trim()))
                {
                    //MessageBox.Show("スタッフ名カナは全て半角カナ入力です");
                    messageDsp.DspMsg("M3022");
                    textBoxStaffNameKana.Focus();
                    return false;
                }
                // スタッフ名カナの文字数チェック
                if (textBoxStaffNameKana.TextLength > 40)
                {
                    //MessageBox.Show("スタッフ名カナは40文字以下です");
                    messageDsp.DspMsg("M3023");
                    textBoxStaffNameKana.Focus();
                    return false;
                }
            }

            //住所入力時のチェック
            if (!String.IsNullOrEmpty(textBoxAddress.Text.Trim()))
            {
                if (textBoxAddress.TextLength > 50)
                {
                    //MessageBox.Show("住所は50文字以下です");
                    messageDsp.DspMsg("M3027");
                    textBoxAddress.Focus();
                    return false;
                }
            }

            // 住所カナの半角カナチェック
            if (!String.IsNullOrEmpty(textBoxAddressKana.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfWidthKatakana(textBoxAddressKana.Text.Trim()))
                {
                    //MessageBox.Show("住所カナは半角カタカナです");
                    messageDsp.DspMsg("M3028");
                    textBoxAddressKana.Focus();
                    return false;
                }
                // 住所カナの文字数チェック
                if (textBoxAddressKana.TextLength > 100)
                {
                    //MessageBox.Show("住所カナは100文字以下です");
                    messageDsp.DspMsg("M3029");
                    textBoxAddressKana.Focus();
                    return false;
                }
            }

            //ログインID入力時のチェック
            if (!String.IsNullOrEmpty(textBoxLoginID.Text.Trim()))
            {
                // ログインIDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxLoginID.Text.Trim()))
                {
                    //MessageBox.Show("ログインIDは全て半角英数字入力です");
                    messageDsp.DspMsg("M3040");
                    textBoxLoginID.Focus();
                    return false;
                }
                // ログインIDの文字数チェック
                if (textBoxLoginID.TextLength > 18)
                {
                    //MessageBox.Show("ログインIDは18文字以下です");
                    messageDsp.DspMsg("M3041");
                    textBoxLoginID.Focus();
                    return false;
                }
            }
            return true;
        }

        ///////////////////////////////
        //　8.3.4.2 スタッフ情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            // コンボボックスが未選択の場合Emptyを設定
            string cStore = "";
            string cPosition = "";
            string cDivision = "";
            string cAuthority = "";
            if (comboBoxStore.SelectedIndex != -1)
                cStore = comboBoxStore.SelectedValue.ToString();
            if (comboBoxPosition.SelectedIndex != -1)
                cPosition = comboBoxPosition.SelectedValue.ToString();
            if (comboBoxDivision.SelectedIndex != -1)
                cDivision = comboBoxDivision.SelectedValue.ToString();
            if (comboBoxAuthority.SelectedIndex != -1)
                cAuthority = comboBoxAuthority.SelectedValue.ToString();

            // 検索条件のセット
            M_StaffDsp selectCondition = new M_StaffDsp()
            {
                StaffCD = textBoxStaffCD.Text,
                StaffName = textBoxStaffName.Text,
                StaffNameKana = textBoxStaffNameKana.Text,
                StaffAddress = textBoxAddress.Text,
                StaffAddressKana = textBoxAddressKana.Text,
                StoreCD = cStore,
                PositionCD = cPosition,
                DivisionCD = cDivision,
                AuthorityCD = cAuthority,
                StaffUserID = textBoxLoginID.Text
            };
            // スタッフデータの抽出
            Staff = staffDataAccess.GetStaffData(selectCondition);

        }

        ///////////////////////////////
        //　8.3.4.3 スタッフ抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：スタッフ情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPageNo.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewDsp.DataSource = Staff;

            labelPage.Text = "/" + ((int)Math.Ceiling(Staff.Count / (double)pageSize)) + "ページ";
            dataGridViewDsp.Refresh();
        }

    }
}
