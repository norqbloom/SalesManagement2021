namespace SalesManagement2021
{
    partial class FormPosition
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
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.labelComments = new System.Windows.Forms.Label();
            this.textBoxPositionName = new System.Windows.Forms.TextBox();
            this.labelDivisionName = new System.Windows.Forms.Label();
            this.textBoxPositionCD = new System.Windows.Forms.TextBox();
            this.labelDivisionID = new System.Windows.Forms.Label();
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
            this.labelDeleteFlg = new System.Windows.Forms.Label();
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
            this.labelFormTitle.Size = new System.Drawing.Size(151, 19);
            this.labelFormTitle.TabIndex = 0;
            this.labelFormTitle.Text = "役職マスター管理";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.textBoxComments);
            this.panel5.Controls.Add(this.labelComments);
            this.panel5.Controls.Add(this.textBoxPositionName);
            this.panel5.Controls.Add(this.labelDivisionName);
            this.panel5.Controls.Add(this.textBoxPositionCD);
            this.panel5.Controls.Add(this.labelDivisionID);
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
            // textBoxComments
            // 
            this.textBoxComments.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxComments.Location = new System.Drawing.Point(94, 69);
            this.textBoxComments.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxComments.Multiline = true;
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.Size = new System.Drawing.Size(757, 77);
            this.textBoxComments.TabIndex = 2;
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(33, 69);
            this.labelComments.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(29, 12);
            this.labelComments.TabIndex = 1291;
            this.labelComments.Text = "備考";
            // 
            // textBoxPositionName
            // 
            this.textBoxPositionName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxPositionName.Location = new System.Drawing.Point(94, 37);
            this.textBoxPositionName.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxPositionName.Name = "textBoxPositionName";
            this.textBoxPositionName.Size = new System.Drawing.Size(757, 19);
            this.textBoxPositionName.TabIndex = 1;
            // 
            // labelDivisionName
            // 
            this.labelDivisionName.AutoSize = true;
            this.labelDivisionName.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDivisionName.ForeColor = System.Drawing.Color.Red;
            this.labelDivisionName.Location = new System.Drawing.Point(33, 37);
            this.labelDivisionName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelDivisionName.Name = "labelDivisionName";
            this.labelDivisionName.Size = new System.Drawing.Size(44, 12);
            this.labelDivisionName.TabIndex = 1292;
            this.labelDivisionName.Text = "役職名";
            // 
            // textBoxPositionCD
            // 
            this.textBoxPositionCD.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxPositionCD.Location = new System.Drawing.Point(94, 9);
            this.textBoxPositionCD.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBoxPositionCD.Name = "textBoxPositionCD";
            this.textBoxPositionCD.Size = new System.Drawing.Size(112, 19);
            this.textBoxPositionCD.TabIndex = 0;
            // 
            // labelDivisionID
            // 
            this.labelDivisionID.AutoSize = true;
            this.labelDivisionID.Font = new System.Drawing.Font("MS UI Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDivisionID.ForeColor = System.Drawing.Color.Red;
            this.labelDivisionID.Location = new System.Drawing.Point(33, 9);
            this.labelDivisionID.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelDivisionID.Name = "labelDivisionID";
            this.labelDivisionID.Size = new System.Drawing.Size(49, 12);
            this.labelDivisionID.TabIndex = 1290;
            this.labelDivisionID.Text = "役職CD";
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Location = new System.Drawing.Point(33, 610);
            this.labelPageSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(65, 12);
            this.labelPageSize.TabIndex = 5;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Location = new System.Drawing.Point(165, 605);
            this.buttonPageSizeChange.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(75, 23);
            this.buttonPageSizeChange.TabIndex = 7;
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
            this.textBoxPageSize.TabIndex = 6;
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
            this.textBoxPageNo.TabIndex = 8;
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Location = new System.Drawing.Point(1251, 605);
            this.buttonLastPage.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(23, 22);
            this.buttonLastPage.TabIndex = 12;
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
            this.buttonNextPage.TabIndex = 11;
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
            this.buttonPreviousPage.TabIndex = 10;
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
            this.buttonFirstPage.TabIndex = 9;
            this.buttonFirstPage.Text = "|◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.buttonFirstPage_Click);
            // 
            // dataGridViewDsp
            // 
            this.dataGridViewDsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDsp.Location = new System.Drawing.Point(35, 186);
            this.dataGridViewDsp.Name = "dataGridViewDsp";
            this.dataGridViewDsp.RowTemplate.Height = 21;
            this.dataGridViewDsp.Size = new System.Drawing.Size(1259, 409);
            this.dataGridViewDsp.TabIndex = 4;
            this.dataGridViewDsp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDsp_CellClick);
            // 
            // checkBoxDeleteFlg
            // 
            this.checkBoxDeleteFlg.AutoSize = true;
            this.checkBoxDeleteFlg.Location = new System.Drawing.Point(91, 156);
            this.checkBoxDeleteFlg.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.checkBoxDeleteFlg.Name = "checkBoxDeleteFlg";
            this.checkBoxDeleteFlg.Size = new System.Drawing.Size(96, 16);
            this.checkBoxDeleteFlg.TabIndex = 3;
            this.checkBoxDeleteFlg.Text = "（非表示対象）";
            this.checkBoxDeleteFlg.UseVisualStyleBackColor = true;
            // 
            // labelDeleteFlg
            // 
            this.labelDeleteFlg.AutoSize = true;
            this.labelDeleteFlg.Location = new System.Drawing.Point(33, 156);
            this.labelDeleteFlg.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelDeleteFlg.Name = "labelDeleteFlg";
            this.labelDeleteFlg.Size = new System.Drawing.Size(54, 12);
            this.labelDeleteFlg.TabIndex = 1274;
            this.labelDeleteFlg.Text = "削除フラグ";
            // 
            // FormPosition
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
            this.Name = "FormPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "販売管理システム－従業員管理";
            this.Load += new System.EventHandler(this.FormPosition_Load);
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
        private System.Windows.Forms.Label labelDeleteFlg;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.TextBox textBoxPositionName;
        private System.Windows.Forms.Label labelDivisionName;
        private System.Windows.Forms.TextBox textBoxPositionCD;
        private System.Windows.Forms.Label labelDivisionID;
    }
}