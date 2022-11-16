namespace SalesManagement2021
{
    partial class FormStaff
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonRegist = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelLoginName = new System.Windows.Forms.Label();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelPwPoint = new System.Windows.Forms.Label();
            this.dateTimePickerJoinDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBirthday = new System.Windows.Forms.DateTimePicker();
            this.textBoxLoginPW = new System.Windows.Forms.TextBox();
            this.labelLoginPW = new System.Windows.Forms.Label();
            this.textBoxLoginID = new System.Windows.Forms.TextBox();
            this.labelLoginID = new System.Windows.Forms.Label();
            this.comboBoxAuthority = new System.Windows.Forms.ComboBox();
            this.labelAuthority = new System.Windows.Forms.Label();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.labelDivision = new System.Windows.Forms.Label();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.comboBoxStore = new System.Windows.Forms.ComboBox();
            this.labelStore = new System.Windows.Forms.Label();
            this.labelJoinDate = new System.Windows.Forms.Label();
            this.labelBirthday = new System.Windows.Forms.Label();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.labelMail = new System.Windows.Forms.Label();
            this.textBoxMobileTel = new System.Windows.Forms.TextBox();
            this.labelMobileTel = new System.Windows.Forms.Label();
            this.textBoxTel = new System.Windows.Forms.TextBox();
            this.labelTel = new System.Windows.Forms.Label();
            this.textBoxAddressKana = new System.Windows.Forms.TextBox();
            this.labelAddressKana = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxPostal = new System.Windows.Forms.TextBox();
            this.labelPostal = new System.Windows.Forms.Label();
            this.textBoxStaffNameKana = new System.Windows.Forms.TextBox();
            this.labelStaffNameKana = new System.Windows.Forms.Label();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.labelComments = new System.Windows.Forms.Label();
            this.textBoxStaffName = new System.Windows.Forms.TextBox();
            this.labelStaffName = new System.Windows.Forms.Label();
            this.textBoxStaffCD = new System.Windows.Forms.TextBox();
            this.labeStaffCD = new System.Windows.Forms.Label();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.buttonPageSizeChange = new System.Windows.Forms.Button();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxPageNo = new System.Windows.Forms.TextBox();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.dataGridViewDsp = new System.Windows.Forms.DataGridView();
            this.checkBoxDeleteFlg = new System.Windows.Forms.CheckBox();
            this.labelDispFLG = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDsp)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(1238, 5);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(66, 25);
            this.buttonLogout.TabIndex = 0;
            this.buttonLogout.Text = "ログアウト";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.ForeColor = System.Drawing.Color.White;
            this.labelLogin.Location = new System.Drawing.Point(1078, 11);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(47, 12);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "ユーザ名";
            // 
            // buttonExport
            // 
            this.buttonExport.Enabled = false;
            this.buttonExport.Location = new System.Drawing.Point(98, 4);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(67, 24);
            this.buttonExport.TabIndex = 1;
            this.buttonExport.Text = "エクスポート";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // buttonImport
            // 
            this.buttonImport.Enabled = false;
            this.buttonImport.Location = new System.Drawing.Point(10, 4);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(67, 24);
            this.buttonImport.TabIndex = 0;
            this.buttonImport.Text = "インポート";
            this.buttonImport.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(25, 4);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(73, 24);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "検索";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonRegist
            // 
            this.buttonRegist.Location = new System.Drawing.Point(125, 4);
            this.buttonRegist.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonRegist.Name = "buttonRegist";
            this.buttonRegist.Size = new System.Drawing.Size(74, 24);
            this.buttonRegist.TabIndex = 1;
            this.buttonRegist.Text = "登録";
            this.buttonRegist.UseVisualStyleBackColor = true;
            this.buttonRegist.Click += new System.EventHandler(this.buttonRegist_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(230, 4);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 24);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "更新";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(335, 4);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(81, 24);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "削除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(97, 4);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(65, 24);
            this.buttonPrint.TabIndex = 1;
            this.buttonPrint.Text = "印刷";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(367, 4);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(66, 24);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "閉じる";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(8, 4);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(65, 24);
            this.buttonClear.TabIndex = 0;
            this.buttonClear.Text = "入力クリア";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.buttonExport);
            this.panel1.Controls.Add(this.buttonImport);
            this.panel1.Location = new System.Drawing.Point(7, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 33);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.buttonDelete);
            this.panel2.Controls.Add(this.buttonSearch);
            this.panel2.Controls.Add(this.buttonUpdate);
            this.panel2.Controls.Add(this.buttonRegist);
            this.panel2.Location = new System.Drawing.Point(232, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(637, 33);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.buttonClose);
            this.panel3.Controls.Add(this.buttonPrint);
            this.panel3.Controls.Add(this.buttonClear);
            this.panel3.Location = new System.Drawing.Point(875, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(468, 33);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.labelLoginName);
            this.panel4.Controls.Add(this.labelFormTitle);
            this.panel4.Controls.Add(this.labelLogin);
            this.panel4.Controls.Add(this.buttonLogout);
            this.panel4.Location = new System.Drawing.Point(6, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1337, 37);
            this.panel4.TabIndex = 4;
            // 
            // labelLoginName
            // 
            this.labelLoginName.AutoSize = true;
            this.labelLoginName.ForeColor = System.Drawing.Color.White;
            this.labelLoginName.Location = new System.Drawing.Point(1129, 11);
            this.labelLoginName.Name = "labelLoginName";
            this.labelLoginName.Size = new System.Drawing.Size(35, 12);
            this.labelLoginName.TabIndex = 2;
            this.labelLoginName.Text = "label2";
            // 
            // labelFormTitle
            // 
            this.labelFormTitle.AutoSize = true;
            this.labelFormTitle.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelFormTitle.ForeColor = System.Drawing.Color.White;
            this.labelFormTitle.Location = new System.Drawing.Point(9, 11);
            this.labelFormTitle.Name = "labelFormTitle";
            this.labelFormTitle.Size = new System.Drawing.Size(167, 19);
            this.labelFormTitle.TabIndex = 0;
            this.labelFormTitle.Text = "スタッフマスター管理";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.labelPwPoint);
            this.panel5.Controls.Add(this.dateTimePickerJoinDate);
            this.panel5.Controls.Add(this.dateTimePickerBirthday);
            this.panel5.Controls.Add(this.textBoxLoginPW);
            this.panel5.Controls.Add(this.labelLoginPW);
            this.panel5.Controls.Add(this.textBoxLoginID);
            this.panel5.Controls.Add(this.labelLoginID);
            this.panel5.Controls.Add(this.comboBoxAuthority);
            this.panel5.Controls.Add(this.labelAuthority);
            this.panel5.Controls.Add(this.comboBoxDivision);
            this.panel5.Controls.Add(this.labelDivision);
            this.panel5.Controls.Add(this.comboBoxPosition);
            this.panel5.Controls.Add(this.labelPosition);
            this.panel5.Controls.Add(this.comboBoxStore);
            this.panel5.Controls.Add(this.labelStore);
            this.panel5.Controls.Add(this.labelJoinDate);
            this.panel5.Controls.Add(this.labelBirthday);
            this.panel5.Controls.Add(this.textBoxMail);
            this.panel5.Controls.Add(this.labelMail);
            this.panel5.Controls.Add(this.textBoxMobileTel);
            this.panel5.Controls.Add(this.labelMobileTel);
            this.panel5.Controls.Add(this.textBoxTel);
            this.panel5.Controls.Add(this.labelTel);
            this.panel5.Controls.Add(this.textBoxAddressKana);
            this.panel5.Controls.Add(this.labelAddressKana);
            this.panel5.Controls.Add(this.textBoxAddress);
            this.panel5.Controls.Add(this.labelAddress);
            this.panel5.Controls.Add(this.textBoxPostal);
            this.panel5.Controls.Add(this.labelPostal);
            this.panel5.Controls.Add(this.textBoxStaffNameKana);
            this.panel5.Controls.Add(this.labelStaffNameKana);
            this.panel5.Controls.Add(this.textBoxComments);
            this.panel5.Controls.Add(this.labelComments);
            this.panel5.Controls.Add(this.textBoxStaffName);
            this.panel5.Controls.Add(this.labelStaffName);
            this.panel5.Controls.Add(this.textBoxStaffCD);
            this.panel5.Controls.Add(this.labeStaffCD);
            this.panel5.Controls.Add(this.labelPageSize);
            this.panel5.Controls.Add(this.buttonPageSizeChange);
            this.panel5.Controls.Add(this.textBoxPageSize);
            this.panel5.Controls.Add(this.labelPage);
            this.panel5.Controls.Add(this.textBoxPageNo);
            this.panel5.Controls.Add(this.buttonLastPage);
            this.panel5.Controls.Add(this.buttonNextPage);
            this.panel5.Controls.Add(this.buttonPreviousPage);
            this.panel5.Controls.Add(this.buttonFirstPage);
            this.panel5.Controls.Add(this.dataGridViewDsp);
            this.panel5.Controls.Add(this.checkBoxDeleteFlg);
            this.panel5.Controls.Add(this.labelDispFLG);
            this.panel5.Location = new System.Drawing.Point(12, 83);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1326, 634);
            this.panel5.TabIndex = 0;
            // 
            // labelPwPoint
            // 
            this.labelPwPoint.AutoSize = true;
            this.labelPwPoint.Location = new System.Drawing.Point(1082, 264);
            this.labelPwPoint.Name = "labelPwPoint";
            this.labelPwPoint.Size = new System.Drawing.Size(154, 12);
            this.labelPwPoint.TabIndex = 1328;
            this.labelPwPoint.Text = "※新規登録、変更時のみ入力";
            // 
            // dateTimePickerJoinDate
            // 
            this.dateTimePickerJoinDate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dateTimePickerJoinDate.Location = new System.Drawing.Point(536, 195);
            this.dateTimePickerJoinDate.Name = "dateTimePickerJoinDate";
            this.dateTimePickerJoinDate.ShowCheckBox = true;
            this.dateTimePickerJoinDate.Size = new System.Drawing.Size(200, 19);
            this.dateTimePickerJoinDate.TabIndex = 10;
            // 
            // dateTimePickerBirthday
            // 
            this.dateTimePickerBirthday.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dateTimePickerBirthday.Location = new System.Drawing.Point(191, 195);
            this.dateTimePickerBirthday.Name = "dateTimePickerBirthday";
            this.dateTimePickerBirthday.ShowCheckBox = true;
            this.dateTimePickerBirthday.Size = new System.Drawing.Size(200, 19);
            this.dateTimePickerBirthday.TabIndex = 9;
            // 
            // textBoxLoginPW
            // 
            this.textBoxLoginPW.BackColor = System.Drawing.Color.Silver;
            this.textBoxLoginPW.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxLoginPW.ForeColor = System.Drawing.Color.Yellow;
            this.textBoxLoginPW.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxLoginPW.Location = new System.Drawing.Point(891, 259);
            this.textBoxLoginPW.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxLoginPW.Name = "textBoxLoginPW";
            this.textBoxLoginPW.PasswordChar = '*';
            this.textBoxLoginPW.Size = new System.Drawing.Size(187, 19);
            this.textBoxLoginPW.TabIndex = 16;
            // 
            // labelLoginPW
            // 
            this.labelLoginPW.AutoSize = true;
            this.labelLoginPW.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelLoginPW.ForeColor = System.Drawing.Color.Red;
            this.labelLoginPW.Location = new System.Drawing.Point(822, 259);
            this.labelLoginPW.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelLoginPW.Name = "labelLoginPW";
            this.labelLoginPW.Size = new System.Drawing.Size(63, 12);
            this.labelLoginPW.TabIndex = 1324;
            this.labelLoginPW.Text = "ログインPW";
            // 
            // textBoxLoginID
            // 
            this.textBoxLoginID.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxLoginID.Location = new System.Drawing.Point(536, 259);
            this.textBoxLoginID.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxLoginID.Name = "textBoxLoginID";
            this.textBoxLoginID.Size = new System.Drawing.Size(187, 19);
            this.textBoxLoginID.TabIndex = 15;
            // 
            // labelLoginID
            // 
            this.labelLoginID.AutoSize = true;
            this.labelLoginID.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelLoginID.ForeColor = System.Drawing.Color.Red;
            this.labelLoginID.Location = new System.Drawing.Point(478, 259);
            this.labelLoginID.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelLoginID.Name = "labelLoginID";
            this.labelLoginID.Size = new System.Drawing.Size(58, 12);
            this.labelLoginID.TabIndex = 1322;
            this.labelLoginID.Text = "ログインID";
            // 
            // comboBoxAuthority
            // 
            this.comboBoxAuthority.FormattingEnabled = true;
            this.comboBoxAuthority.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBoxAuthority.Location = new System.Drawing.Point(192, 256);
            this.comboBoxAuthority.Name = "comboBoxAuthority";
            this.comboBoxAuthority.Size = new System.Drawing.Size(187, 20);
            this.comboBoxAuthority.TabIndex = 14;
            // 
            // labelAuthority
            // 
            this.labelAuthority.AutoSize = true;
            this.labelAuthority.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelAuthority.ForeColor = System.Drawing.Color.Red;
            this.labelAuthority.Location = new System.Drawing.Point(150, 256);
            this.labelAuthority.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelAuthority.Name = "labelAuthority";
            this.labelAuthority.Size = new System.Drawing.Size(31, 12);
            this.labelAuthority.TabIndex = 1320;
            this.labelAuthority.Text = "権限";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBoxDivision.Location = new System.Drawing.Point(892, 224);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(186, 20);
            this.comboBoxDivision.TabIndex = 13;
            // 
            // labelDivision
            // 
            this.labelDivision.AutoSize = true;
            this.labelDivision.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDivision.ForeColor = System.Drawing.Color.Red;
            this.labelDivision.Location = new System.Drawing.Point(823, 224);
            this.labelDivision.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelDivision.Name = "labelDivision";
            this.labelDivision.Size = new System.Drawing.Size(44, 12);
            this.labelDivision.TabIndex = 1318;
            this.labelDivision.Text = "部署名";
            // 
            // comboBoxPosition
            // 
            this.comboBoxPosition.FormattingEnabled = true;
            this.comboBoxPosition.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBoxPosition.Location = new System.Drawing.Point(536, 224);
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(187, 20);
            this.comboBoxPosition.TabIndex = 12;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPosition.ForeColor = System.Drawing.Color.Red;
            this.labelPosition.Location = new System.Drawing.Point(478, 224);
            this.labelPosition.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(44, 12);
            this.labelPosition.TabIndex = 1316;
            this.labelPosition.Text = "役職名";
            // 
            // comboBoxStore
            // 
            this.comboBoxStore.FormattingEnabled = true;
            this.comboBoxStore.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBoxStore.Location = new System.Drawing.Point(192, 224);
            this.comboBoxStore.Name = "comboBoxStore";
            this.comboBoxStore.Size = new System.Drawing.Size(187, 20);
            this.comboBoxStore.TabIndex = 11;
            // 
            // labelStore
            // 
            this.labelStore.AutoSize = true;
            this.labelStore.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelStore.ForeColor = System.Drawing.Color.Red;
            this.labelStore.Location = new System.Drawing.Point(134, 224);
            this.labelStore.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelStore.Name = "labelStore";
            this.labelStore.Size = new System.Drawing.Size(44, 12);
            this.labelStore.TabIndex = 1314;
            this.labelStore.Text = "店舗名";
            // 
            // labelJoinDate
            // 
            this.labelJoinDate.AutoSize = true;
            this.labelJoinDate.Location = new System.Drawing.Point(478, 195);
            this.labelJoinDate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelJoinDate.Name = "labelJoinDate";
            this.labelJoinDate.Size = new System.Drawing.Size(41, 12);
            this.labelJoinDate.TabIndex = 1313;
            this.labelJoinDate.Text = "入社日";
            // 
            // labelBirthday
            // 
            this.labelBirthday.AutoSize = true;
            this.labelBirthday.Location = new System.Drawing.Point(134, 195);
            this.labelBirthday.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelBirthday.Name = "labelBirthday";
            this.labelBirthday.Size = new System.Drawing.Size(53, 12);
            this.labelBirthday.TabIndex = 1312;
            this.labelBirthday.Text = "生年月日";
            // 
            // textBoxMail
            // 
            this.textBoxMail.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxMail.Location = new System.Drawing.Point(891, 164);
            this.textBoxMail.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(187, 19);
            this.textBoxMail.TabIndex = 8;
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Location = new System.Drawing.Point(820, 167);
            this.labelMail.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(69, 12);
            this.labelMail.TabIndex = 1310;
            this.labelMail.Text = "メールアドレス";
            // 
            // textBoxMobileTel
            // 
            this.textBoxMobileTel.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxMobileTel.Location = new System.Drawing.Point(536, 164);
            this.textBoxMobileTel.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxMobileTel.Name = "textBoxMobileTel";
            this.textBoxMobileTel.Size = new System.Drawing.Size(187, 19);
            this.textBoxMobileTel.TabIndex = 7;
            // 
            // labelMobileTel
            // 
            this.labelMobileTel.AutoSize = true;
            this.labelMobileTel.Location = new System.Drawing.Point(478, 164);
            this.labelMobileTel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelMobileTel.Name = "labelMobileTel";
            this.labelMobileTel.Size = new System.Drawing.Size(53, 12);
            this.labelMobileTel.TabIndex = 1308;
            this.labelMobileTel.Text = "携帯番号";
            // 
            // textBoxTel
            // 
            this.textBoxTel.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxTel.Location = new System.Drawing.Point(192, 161);
            this.textBoxTel.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxTel.Name = "textBoxTel";
            this.textBoxTel.Size = new System.Drawing.Size(187, 19);
            this.textBoxTel.TabIndex = 6;
            // 
            // labelTel
            // 
            this.labelTel.AutoSize = true;
            this.labelTel.Location = new System.Drawing.Point(134, 164);
            this.labelTel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelTel.Name = "labelTel";
            this.labelTel.Size = new System.Drawing.Size(53, 12);
            this.labelTel.TabIndex = 1306;
            this.labelTel.Text = "電話番号";
            // 
            // textBoxAddressKana
            // 
            this.textBoxAddressKana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.textBoxAddressKana.Location = new System.Drawing.Point(192, 131);
            this.textBoxAddressKana.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxAddressKana.Name = "textBoxAddressKana";
            this.textBoxAddressKana.Size = new System.Drawing.Size(694, 19);
            this.textBoxAddressKana.TabIndex = 5;
            // 
            // labelAddressKana
            // 
            this.labelAddressKana.AutoSize = true;
            this.labelAddressKana.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelAddressKana.Location = new System.Drawing.Point(144, 134);
            this.labelAddressKana.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelAddressKana.Name = "labelAddressKana";
            this.labelAddressKana.Size = new System.Drawing.Size(48, 12);
            this.labelAddressKana.TabIndex = 1304;
            this.labelAddressKana.Text = "住所カナ";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxAddress.Location = new System.Drawing.Point(192, 101);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(694, 19);
            this.textBoxAddress.TabIndex = 4;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelAddress.Location = new System.Drawing.Point(144, 104);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(29, 12);
            this.labelAddress.TabIndex = 1302;
            this.labelAddress.Text = "住所";
            // 
            // textBoxPostal
            // 
            this.textBoxPostal.Location = new System.Drawing.Point(139, 66);
            this.textBoxPostal.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxPostal.Name = "textBoxPostal";
            this.textBoxPostal.Size = new System.Drawing.Size(112, 19);
            this.textBoxPostal.TabIndex = 3;
            // 
            // labelPostal
            // 
            this.labelPostal.AutoSize = true;
            this.labelPostal.Location = new System.Drawing.Point(81, 66);
            this.labelPostal.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelPostal.Name = "labelPostal";
            this.labelPostal.Size = new System.Drawing.Size(53, 12);
            this.labelPostal.TabIndex = 1300;
            this.labelPostal.Text = "郵便番号";
            // 
            // textBoxStaffNameKana
            // 
            this.textBoxStaffNameKana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.textBoxStaffNameKana.Location = new System.Drawing.Point(430, 36);
            this.textBoxStaffNameKana.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxStaffNameKana.Name = "textBoxStaffNameKana";
            this.textBoxStaffNameKana.Size = new System.Drawing.Size(187, 19);
            this.textBoxStaffNameKana.TabIndex = 2;
            // 
            // labelStaffNameKana
            // 
            this.labelStaffNameKana.AutoSize = true;
            this.labelStaffNameKana.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelStaffNameKana.ForeColor = System.Drawing.Color.Red;
            this.labelStaffNameKana.Location = new System.Drawing.Point(360, 36);
            this.labelStaffNameKana.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelStaffNameKana.Name = "labelStaffNameKana";
            this.labelStaffNameKana.Size = new System.Drawing.Size(75, 12);
            this.labelStaffNameKana.TabIndex = 1298;
            this.labelStaffNameKana.Text = "スタッフ名カナ";
            // 
            // textBoxComments
            // 
            this.textBoxComments.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxComments.Location = new System.Drawing.Point(139, 291);
            this.textBoxComments.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxComments.Multiline = true;
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.Size = new System.Drawing.Size(939, 77);
            this.textBoxComments.TabIndex = 17;
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(81, 291);
            this.labelComments.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(29, 12);
            this.labelComments.TabIndex = 1293;
            this.labelComments.Text = "備考";
            // 
            // textBoxStaffName
            // 
            this.textBoxStaffName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxStaffName.Location = new System.Drawing.Point(101, 36);
            this.textBoxStaffName.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxStaffName.Name = "textBoxStaffName";
            this.textBoxStaffName.Size = new System.Drawing.Size(187, 19);
            this.textBoxStaffName.TabIndex = 1;
            // 
            // labelStaffName
            // 
            this.labelStaffName.AutoSize = true;
            this.labelStaffName.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelStaffName.ForeColor = System.Drawing.Color.Red;
            this.labelStaffName.Location = new System.Drawing.Point(28, 36);
            this.labelStaffName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelStaffName.Name = "labelStaffName";
            this.labelStaffName.Size = new System.Drawing.Size(54, 12);
            this.labelStaffName.TabIndex = 1294;
            this.labelStaffName.Text = "スタッフ名";
            // 
            // textBoxStaffCD
            // 
            this.textBoxStaffCD.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxStaffCD.Location = new System.Drawing.Point(101, 8);
            this.textBoxStaffCD.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxStaffCD.Name = "textBoxStaffCD";
            this.textBoxStaffCD.Size = new System.Drawing.Size(112, 19);
            this.textBoxStaffCD.TabIndex = 0;
            // 
            // labeStaffCD
            // 
            this.labeStaffCD.AutoSize = true;
            this.labeStaffCD.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labeStaffCD.ForeColor = System.Drawing.Color.Red;
            this.labeStaffCD.Location = new System.Drawing.Point(28, 8);
            this.labeStaffCD.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labeStaffCD.Name = "labeStaffCD";
            this.labeStaffCD.Size = new System.Drawing.Size(59, 12);
            this.labeStaffCD.TabIndex = 1290;
            this.labeStaffCD.Text = "スタッフCD";
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Location = new System.Drawing.Point(33, 610);
            this.labelPageSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(65, 12);
            this.labelPageSize.TabIndex = 1281;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Location = new System.Drawing.Point(165, 605);
            this.buttonPageSizeChange.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(75, 23);
            this.buttonPageSizeChange.TabIndex = 21;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            this.buttonPageSizeChange.Click += new System.EventHandler(this.buttonPageSizeChange_Click);
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxPageSize.Location = new System.Drawing.Point(102, 608);
            this.textBoxPageSize.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(46, 19);
            this.textBoxPageSize.TabIndex = 20;
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(1116, 610);
            this.labelPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(35, 12);
            this.labelPage.TabIndex = 1282;
            this.labelPage.Text = "ページ";
            // 
            // textBoxPageNo
            // 
            this.textBoxPageNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxPageNo.Location = new System.Drawing.Point(1058, 607);
            this.textBoxPageNo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPageNo.Name = "textBoxPageNo";
            this.textBoxPageNo.Size = new System.Drawing.Size(46, 19);
            this.textBoxPageNo.TabIndex = 22;
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Location = new System.Drawing.Point(1251, 605);
            this.buttonLastPage.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(23, 22);
            this.buttonLastPage.TabIndex = 26;
            this.buttonLastPage.Text = "▶|";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.buttonLastPage_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Location = new System.Drawing.Point(1225, 605);
            this.buttonNextPage.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(23, 22);
            this.buttonNextPage.TabIndex = 25;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Location = new System.Drawing.Point(1199, 605);
            this.buttonPreviousPage.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(23, 22);
            this.buttonPreviousPage.TabIndex = 24;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.buttonPreviousPage_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Location = new System.Drawing.Point(1172, 605);
            this.buttonFirstPage.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(23, 22);
            this.buttonFirstPage.TabIndex = 23;
            this.buttonFirstPage.Text = "|◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.buttonFirstPage_Click);
            // 
            // dataGridViewDsp
            // 
            this.dataGridViewDsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDsp.Location = new System.Drawing.Point(35, 399);
            this.dataGridViewDsp.Name = "dataGridViewDsp";
            this.dataGridViewDsp.RowTemplate.Height = 21;
            this.dataGridViewDsp.Size = new System.Drawing.Size(1259, 196);
            this.dataGridViewDsp.TabIndex = 19;
            this.dataGridViewDsp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDsp_CellClick);
            // 
            // checkBoxDeleteFlg
            // 
            this.checkBoxDeleteFlg.AutoSize = true;
            this.checkBoxDeleteFlg.Location = new System.Drawing.Point(93, 372);
            this.checkBoxDeleteFlg.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.checkBoxDeleteFlg.Name = "checkBoxDeleteFlg";
            this.checkBoxDeleteFlg.Size = new System.Drawing.Size(96, 16);
            this.checkBoxDeleteFlg.TabIndex = 18;
            this.checkBoxDeleteFlg.Text = "（非表示対象）";
            this.checkBoxDeleteFlg.UseVisualStyleBackColor = true;
            // 
            // labelDispFLG
            // 
            this.labelDispFLG.AutoSize = true;
            this.labelDispFLG.Location = new System.Drawing.Point(35, 372);
            this.labelDispFLG.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelDispFLG.Name = "labelDispFLG";
            this.labelDispFLG.Size = new System.Drawing.Size(54, 12);
            this.labelDispFLG.TabIndex = 1274;
            this.labelDispFLG.Text = "削除フラグ";
            // 
            // FormStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "販売管理システム－従業員管理";
            this.Load += new System.EventHandler(this.FormStaff_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDsp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonRegist;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelLoginName;
        private System.Windows.Forms.Label labelFormTitle;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxPageNo;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.DataGridView dataGridViewDsp;
        private System.Windows.Forms.CheckBox checkBoxDeleteFlg;
        private System.Windows.Forms.Label labelDispFLG;
        private System.Windows.Forms.DateTimePicker dateTimePickerJoinDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthday;
        private System.Windows.Forms.TextBox textBoxLoginPW;
        private System.Windows.Forms.Label labelLoginPW;
        private System.Windows.Forms.TextBox textBoxLoginID;
        private System.Windows.Forms.Label labelLoginID;
        private System.Windows.Forms.ComboBox comboBoxAuthority;
        private System.Windows.Forms.Label labelAuthority;
        private System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.Label labelDivision;
        private System.Windows.Forms.ComboBox comboBoxPosition;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.ComboBox comboBoxStore;
        private System.Windows.Forms.Label labelStore;
        private System.Windows.Forms.Label labelJoinDate;
        private System.Windows.Forms.Label labelBirthday;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.TextBox textBoxMobileTel;
        private System.Windows.Forms.Label labelMobileTel;
        private System.Windows.Forms.TextBox textBoxTel;
        private System.Windows.Forms.Label labelTel;
        private System.Windows.Forms.TextBox textBoxAddressKana;
        private System.Windows.Forms.Label labelAddressKana;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxPostal;
        private System.Windows.Forms.Label labelPostal;
        private System.Windows.Forms.TextBox textBoxStaffNameKana;
        private System.Windows.Forms.Label labelStaffNameKana;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.TextBox textBoxStaffName;
        private System.Windows.Forms.Label labelStaffName;
        private System.Windows.Forms.TextBox textBoxStaffCD;
        private System.Windows.Forms.Label labeStaffCD;
        private System.Windows.Forms.Label labelPwPoint;
    }
}