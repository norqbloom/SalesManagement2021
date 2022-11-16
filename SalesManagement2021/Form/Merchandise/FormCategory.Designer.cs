namespace SalesManagement2021
{
    partial class FormCategory
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
            this.labelDeleteFlg = new System.Windows.Forms.Label();
            this.checkBoxDeleteFlg = new System.Windows.Forms.CheckBox();
            this.dataGridViewDsp = new System.Windows.Forms.DataGridView();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.textBoxPageNo = new System.Windows.Forms.TextBox();
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.buttonPageSizeChange = new System.Windows.Forms.Button();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelParentCategory = new System.Windows.Forms.Label();
            this.comboBoxParentCategorys = new System.Windows.Forms.ComboBox();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.labelComments = new System.Windows.Forms.Label();
            this.labelCategoryCD = new System.Windows.Forms.Label();
            this.textBoxCategoryCD = new System.Windows.Forms.TextBox();
            this.labelCategoryKana = new System.Windows.Forms.Label();
            this.textBoxCategoryKana = new System.Windows.Forms.TextBox();
            this.labeCategoryName = new System.Windows.Forms.Label();
            this.textBoxCategoryName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDsp)).BeginInit();
            this.panel5.SuspendLayout();
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
            this.buttonExport.TabIndex = 8;
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
            this.buttonImport.TabIndex = 8;
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
            this.buttonRegist.TabIndex = 0;
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
            this.buttonUpdate.TabIndex = 1;
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
            this.buttonDelete.TabIndex = 2;
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
            this.panel1.TabIndex = 1272;
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
            this.panel2.TabIndex = 1;
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
            this.panel3.TabIndex = 2;
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
            this.panel4.TabIndex = 3;
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
            this.labelFormTitle.Size = new System.Drawing.Size(210, 19);
            this.labelFormTitle.TabIndex = 0;
            this.labelFormTitle.Text = "商品カテゴリマスター管理";
            // 
            // labelDeleteFlg
            // 
            this.labelDeleteFlg.AutoSize = true;
            this.labelDeleteFlg.Location = new System.Drawing.Point(33, 171);
            this.labelDeleteFlg.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelDeleteFlg.Name = "labelDeleteFlg";
            this.labelDeleteFlg.Size = new System.Drawing.Size(54, 12);
            this.labelDeleteFlg.TabIndex = 1274;
            this.labelDeleteFlg.Text = "削除フラグ";
            // 
            // checkBoxDeleteFlg
            // 
            this.checkBoxDeleteFlg.AutoSize = true;
            this.checkBoxDeleteFlg.Location = new System.Drawing.Point(91, 171);
            this.checkBoxDeleteFlg.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.checkBoxDeleteFlg.Name = "checkBoxDeleteFlg";
            this.checkBoxDeleteFlg.Size = new System.Drawing.Size(96, 16);
            this.checkBoxDeleteFlg.TabIndex = 5;
            this.checkBoxDeleteFlg.Text = "（非表示対象）";
            this.checkBoxDeleteFlg.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDsp
            // 
            this.dataGridViewDsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDsp.Location = new System.Drawing.Point(35, 202);
            this.dataGridViewDsp.Name = "dataGridViewDsp";
            this.dataGridViewDsp.RowTemplate.Height = 21;
            this.dataGridViewDsp.Size = new System.Drawing.Size(1259, 393);
            this.dataGridViewDsp.TabIndex = 6;
            this.dataGridViewDsp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDsp_CellClick);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Location = new System.Drawing.Point(1172, 605);
            this.buttonFirstPage.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(23, 22);
            this.buttonFirstPage.TabIndex = 11;
            this.buttonFirstPage.Text = "|◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.buttonFirstPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Location = new System.Drawing.Point(1199, 605);
            this.buttonPreviousPage.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(23, 22);
            this.buttonPreviousPage.TabIndex = 12;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.buttonPreviousPage_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Location = new System.Drawing.Point(1225, 605);
            this.buttonNextPage.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(23, 22);
            this.buttonNextPage.TabIndex = 13;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Location = new System.Drawing.Point(1251, 605);
            this.buttonLastPage.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(23, 22);
            this.buttonLastPage.TabIndex = 14;
            this.buttonLastPage.Text = "▶|";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.buttonLastPage_Click);
            // 
            // textBoxPageNo
            // 
            this.textBoxPageNo.Location = new System.Drawing.Point(1058, 607);
            this.textBoxPageNo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPageNo.Name = "textBoxPageNo";
            this.textBoxPageNo.Size = new System.Drawing.Size(46, 19);
            this.textBoxPageNo.TabIndex = 9;
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(1116, 610);
            this.labelPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(35, 12);
            this.labelPage.TabIndex = 10;
            this.labelPage.Text = "ページ";
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Location = new System.Drawing.Point(102, 608);
            this.textBoxPageSize.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(46, 19);
            this.textBoxPageSize.TabIndex = 7;
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Location = new System.Drawing.Point(165, 605);
            this.buttonPageSizeChange.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(75, 23);
            this.buttonPageSizeChange.TabIndex = 8;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            this.buttonPageSizeChange.Click += new System.EventHandler(this.buttonPageSizeChange_Click);
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
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.labelParentCategory);
            this.panel5.Controls.Add(this.comboBoxParentCategorys);
            this.panel5.Controls.Add(this.textBoxComments);
            this.panel5.Controls.Add(this.labelComments);
            this.panel5.Controls.Add(this.labelCategoryCD);
            this.panel5.Controls.Add(this.textBoxCategoryCD);
            this.panel5.Controls.Add(this.labelCategoryKana);
            this.panel5.Controls.Add(this.textBoxCategoryKana);
            this.panel5.Controls.Add(this.labeCategoryName);
            this.panel5.Controls.Add(this.textBoxCategoryName);
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
            this.panel5.Controls.Add(this.labelDeleteFlg);
            this.panel5.Location = new System.Drawing.Point(12, 83);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1326, 634);
            this.panel5.TabIndex = 0;
            // 
            // labelParentCategory
            // 
            this.labelParentCategory.AutoSize = true;
            this.labelParentCategory.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelParentCategory.Location = new System.Drawing.Point(32, 7);
            this.labelParentCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelParentCategory.Name = "labelParentCategory";
            this.labelParentCategory.Size = new System.Drawing.Size(51, 12);
            this.labelParentCategory.TabIndex = 1347;
            this.labelParentCategory.Text = "親カテゴリ";
            // 
            // comboBoxParentCategorys
            // 
            this.comboBoxParentCategorys.FormattingEnabled = true;
            this.comboBoxParentCategorys.Location = new System.Drawing.Point(146, 6);
            this.comboBoxParentCategorys.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxParentCategorys.Name = "comboBoxParentCategorys";
            this.comboBoxParentCategorys.Size = new System.Drawing.Size(155, 20);
            this.comboBoxParentCategorys.TabIndex = 0;
            // 
            // textBoxComments
            // 
            this.textBoxComments.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxComments.Location = new System.Drawing.Point(144, 118);
            this.textBoxComments.Multiline = true;
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.Size = new System.Drawing.Size(711, 45);
            this.textBoxComments.TabIndex = 4;
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(33, 121);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(29, 12);
            this.labelComments.TabIndex = 1345;
            this.labelComments.Text = "備考";
            // 
            // labelCategoryCD
            // 
            this.labelCategoryCD.AutoSize = true;
            this.labelCategoryCD.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelCategoryCD.ForeColor = System.Drawing.Color.Red;
            this.labelCategoryCD.Location = new System.Drawing.Point(32, 39);
            this.labelCategoryCD.Name = "labelCategoryCD";
            this.labelCategoryCD.Size = new System.Drawing.Size(61, 12);
            this.labelCategoryCD.TabIndex = 1346;
            this.labelCategoryCD.Text = "カテゴリCD";
            // 
            // textBoxCategoryCD
            // 
            this.textBoxCategoryCD.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxCategoryCD.Location = new System.Drawing.Point(145, 34);
            this.textBoxCategoryCD.Name = "textBoxCategoryCD";
            this.textBoxCategoryCD.Size = new System.Drawing.Size(156, 19);
            this.textBoxCategoryCD.TabIndex = 1;
            // 
            // labelCategoryKana
            // 
            this.labelCategoryKana.AutoSize = true;
            this.labelCategoryKana.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelCategoryKana.ForeColor = System.Drawing.Color.Red;
            this.labelCategoryKana.Location = new System.Drawing.Point(32, 94);
            this.labelCategoryKana.Name = "labelCategoryKana";
            this.labelCategoryKana.Size = new System.Drawing.Size(77, 12);
            this.labelCategoryKana.TabIndex = 1344;
            this.labelCategoryKana.Text = "カテゴリカナ名";
            // 
            // textBoxCategoryKana
            // 
            this.textBoxCategoryKana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.textBoxCategoryKana.Location = new System.Drawing.Point(145, 89);
            this.textBoxCategoryKana.Name = "textBoxCategoryKana";
            this.textBoxCategoryKana.Size = new System.Drawing.Size(710, 19);
            this.textBoxCategoryKana.TabIndex = 3;
            // 
            // labeCategoryName
            // 
            this.labeCategoryName.AutoSize = true;
            this.labeCategoryName.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labeCategoryName.ForeColor = System.Drawing.Color.Red;
            this.labeCategoryName.Location = new System.Drawing.Point(32, 65);
            this.labeCategoryName.Name = "labeCategoryName";
            this.labeCategoryName.Size = new System.Drawing.Size(56, 12);
            this.labeCategoryName.TabIndex = 1343;
            this.labeCategoryName.Text = "カテゴリ名";
            // 
            // textBoxCategoryName
            // 
            this.textBoxCategoryName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxCategoryName.Location = new System.Drawing.Point(145, 61);
            this.textBoxCategoryName.Name = "textBoxCategoryName";
            this.textBoxCategoryName.Size = new System.Drawing.Size(710, 19);
            this.textBoxCategoryName.TabIndex = 2;
            // 
            // FormCategory
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
            this.Name = "FormCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "販売管理システム－商品管理";
            this.Load += new System.EventHandler(this.FormCategory_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDsp)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.Label labelDeleteFlg;
        private System.Windows.Forms.CheckBox checkBoxDeleteFlg;
        private System.Windows.Forms.DataGridView dataGridViewDsp;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.TextBox textBoxPageNo;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelParentCategory;
        private System.Windows.Forms.ComboBox comboBoxParentCategorys;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.Label labelCategoryCD;
        private System.Windows.Forms.TextBox textBoxCategoryCD;
        private System.Windows.Forms.Label labelCategoryKana;
        private System.Windows.Forms.TextBox textBoxCategoryKana;
        private System.Windows.Forms.Label labeCategoryName;
        private System.Windows.Forms.TextBox textBoxCategoryName;
    }
}