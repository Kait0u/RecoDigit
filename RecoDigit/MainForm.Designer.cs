namespace RecoDigit
{
    partial class MainForm
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
            this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingHistoryPanel = new System.Windows.Forms.Panel();
            this.drawingHistoryRemoveButton = new System.Windows.Forms.Button();
            this.drawingHistoryCopyButton = new System.Windows.Forms.Button();
            this.drawingHistoryClearButton = new System.Windows.Forms.Button();
            this.drawingHistoryDataGrid = new System.Windows.Forms.DataGridView();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.Prediction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drawingGroupBox = new System.Windows.Forms.GroupBox();
            this.imageOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.imageOptionsExportButton = new System.Windows.Forms.Button();
            this.imageOptionsClearButton = new System.Windows.Forms.Button();
            this.penGroupBox = new System.Windows.Forms.GroupBox();
            this.penSizeLabel = new System.Windows.Forms.Label();
            this.penSizeMinusButton = new System.Windows.Forms.Button();
            this.penSizePlusButton = new System.Windows.Forms.Button();
            this.recognizeButton = new System.Windows.Forms.Button();
            this.drawingPictureBox = new System.Windows.Forms.PictureBox();
            this.predictionGroupBox = new System.Windows.Forms.GroupBox();
            this.predictionTextBox = new System.Windows.Forms.TextBox();
            this.mainMenuStrip.SuspendLayout();
            this.drawingHistoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingHistoryDataGrid)).BeginInit();
            this.drawingGroupBox.SuspendLayout();
            this.imageOptionsGroupBox.SuspendLayout();
            this.penGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingPictureBox)).BeginInit();
            this.predictionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // networkToolStripMenuItem
            // 
            this.networkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            this.networkToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.networkToolStripMenuItem.Text = "Network";
            // 
            // trainToolStripMenuItem
            // 
            this.trainToolStripMenuItem.Name = "trainToolStripMenuItem";
            this.trainToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.trainToolStripMenuItem.Text = "Train";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.networkToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(937, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // drawingHistoryPanel
            // 
            this.drawingHistoryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.drawingHistoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingHistoryPanel.Controls.Add(this.drawingHistoryRemoveButton);
            this.drawingHistoryPanel.Controls.Add(this.drawingHistoryCopyButton);
            this.drawingHistoryPanel.Controls.Add(this.drawingHistoryClearButton);
            this.drawingHistoryPanel.Controls.Add(this.drawingHistoryDataGrid);
            this.drawingHistoryPanel.Location = new System.Drawing.Point(13, 28);
            this.drawingHistoryPanel.Name = "drawingHistoryPanel";
            this.drawingHistoryPanel.Size = new System.Drawing.Size(255, 529);
            this.drawingHistoryPanel.TabIndex = 1;
            // 
            // drawingHistoryRemoveButton
            // 
            this.drawingHistoryRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingHistoryRemoveButton.Location = new System.Drawing.Point(-2, 451);
            this.drawingHistoryRemoveButton.Name = "drawingHistoryRemoveButton";
            this.drawingHistoryRemoveButton.Size = new System.Drawing.Size(125, 35);
            this.drawingHistoryRemoveButton.TabIndex = 3;
            this.drawingHistoryRemoveButton.Text = "Remove selected";
            this.drawingHistoryRemoveButton.UseVisualStyleBackColor = true;
            // 
            // drawingHistoryCopyButton
            // 
            this.drawingHistoryCopyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingHistoryCopyButton.Location = new System.Drawing.Point(129, 451);
            this.drawingHistoryCopyButton.Name = "drawingHistoryCopyButton";
            this.drawingHistoryCopyButton.Size = new System.Drawing.Size(125, 35);
            this.drawingHistoryCopyButton.TabIndex = 2;
            this.drawingHistoryCopyButton.Text = "Copy selected";
            this.drawingHistoryCopyButton.UseVisualStyleBackColor = true;
            // 
            // drawingHistoryClearButton
            // 
            this.drawingHistoryClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingHistoryClearButton.Location = new System.Drawing.Point(-2, 492);
            this.drawingHistoryClearButton.Name = "drawingHistoryClearButton";
            this.drawingHistoryClearButton.Size = new System.Drawing.Size(256, 36);
            this.drawingHistoryClearButton.TabIndex = 1;
            this.drawingHistoryClearButton.Text = "Clear History";
            this.drawingHistoryClearButton.UseVisualStyleBackColor = true;
            // 
            // drawingHistoryDataGrid
            // 
            this.drawingHistoryDataGrid.AllowUserToAddRows = false;
            this.drawingHistoryDataGrid.AllowUserToDeleteRows = false;
            this.drawingHistoryDataGrid.AllowUserToResizeColumns = false;
            this.drawingHistoryDataGrid.AllowUserToResizeRows = false;
            this.drawingHistoryDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingHistoryDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.drawingHistoryDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drawingHistoryDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Image,
            this.Prediction});
            this.drawingHistoryDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.drawingHistoryDataGrid.Location = new System.Drawing.Point(0, 0);
            this.drawingHistoryDataGrid.MultiSelect = false;
            this.drawingHistoryDataGrid.Name = "drawingHistoryDataGrid";
            this.drawingHistoryDataGrid.ReadOnly = true;
            this.drawingHistoryDataGrid.RowHeadersVisible = false;
            this.drawingHistoryDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.drawingHistoryDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drawingHistoryDataGrid.ShowEditingIcon = false;
            this.drawingHistoryDataGrid.Size = new System.Drawing.Size(254, 445);
            this.drawingHistoryDataGrid.TabIndex = 0;
            // 
            // Image
            // 
            this.Image.HeaderText = "Image";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Prediction
            // 
            this.Prediction.HeaderText = "Prediction";
            this.Prediction.Name = "Prediction";
            this.Prediction.ReadOnly = true;
            this.Prediction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // drawingGroupBox
            // 
            this.drawingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingGroupBox.Controls.Add(this.imageOptionsGroupBox);
            this.drawingGroupBox.Controls.Add(this.penGroupBox);
            this.drawingGroupBox.Controls.Add(this.recognizeButton);
            this.drawingGroupBox.Controls.Add(this.drawingPictureBox);
            this.drawingGroupBox.Location = new System.Drawing.Point(275, 28);
            this.drawingGroupBox.Name = "drawingGroupBox";
            this.drawingGroupBox.Size = new System.Drawing.Size(650, 365);
            this.drawingGroupBox.TabIndex = 2;
            this.drawingGroupBox.TabStop = false;
            this.drawingGroupBox.Text = "Draw a number!";
            // 
            // imageOptionsGroupBox
            // 
            this.imageOptionsGroupBox.Controls.Add(this.imageOptionsExportButton);
            this.imageOptionsGroupBox.Controls.Add(this.imageOptionsClearButton);
            this.imageOptionsGroupBox.Location = new System.Drawing.Point(348, 153);
            this.imageOptionsGroupBox.Name = "imageOptionsGroupBox";
            this.imageOptionsGroupBox.Size = new System.Drawing.Size(296, 127);
            this.imageOptionsGroupBox.TabIndex = 3;
            this.imageOptionsGroupBox.TabStop = false;
            this.imageOptionsGroupBox.Text = "Image Options";
            // 
            // imageOptionsExportButton
            // 
            this.imageOptionsExportButton.Location = new System.Drawing.Point(7, 67);
            this.imageOptionsExportButton.Name = "imageOptionsExportButton";
            this.imageOptionsExportButton.Size = new System.Drawing.Size(283, 41);
            this.imageOptionsExportButton.TabIndex = 1;
            this.imageOptionsExportButton.Text = "Export (28x28)";
            this.imageOptionsExportButton.UseVisualStyleBackColor = true;
            this.imageOptionsExportButton.Click += new System.EventHandler(this.imageOptionsExportButton_Click);
            // 
            // imageOptionsClearButton
            // 
            this.imageOptionsClearButton.Location = new System.Drawing.Point(7, 20);
            this.imageOptionsClearButton.Name = "imageOptionsClearButton";
            this.imageOptionsClearButton.Size = new System.Drawing.Size(283, 41);
            this.imageOptionsClearButton.TabIndex = 0;
            this.imageOptionsClearButton.Text = "Clear";
            this.imageOptionsClearButton.UseVisualStyleBackColor = true;
            this.imageOptionsClearButton.Click += new System.EventHandler(this.imageOptionsClearButton_Click);
            // 
            // penGroupBox
            // 
            this.penGroupBox.Controls.Add(this.penSizeLabel);
            this.penGroupBox.Controls.Add(this.penSizeMinusButton);
            this.penGroupBox.Controls.Add(this.penSizePlusButton);
            this.penGroupBox.Location = new System.Drawing.Point(349, 20);
            this.penGroupBox.Name = "penGroupBox";
            this.penGroupBox.Size = new System.Drawing.Size(295, 108);
            this.penGroupBox.TabIndex = 2;
            this.penGroupBox.TabStop = false;
            this.penGroupBox.Text = "Pen Size";
            // 
            // penSizeLabel
            // 
            this.penSizeLabel.AutoSize = true;
            this.penSizeLabel.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.penSizeLabel.Location = new System.Drawing.Point(129, 48);
            this.penSizeLabel.Name = "penSizeLabel";
            this.penSizeLabel.Size = new System.Drawing.Size(36, 26);
            this.penSizeLabel.TabIndex = 2;
            this.penSizeLabel.Text = "10";
            this.penSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // penSizeMinusButton
            // 
            this.penSizeMinusButton.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.penSizeMinusButton.Location = new System.Drawing.Point(6, 19);
            this.penSizeMinusButton.Name = "penSizeMinusButton";
            this.penSizeMinusButton.Size = new System.Drawing.Size(84, 84);
            this.penSizeMinusButton.TabIndex = 1;
            this.penSizeMinusButton.Text = "-";
            this.penSizeMinusButton.UseVisualStyleBackColor = true;
            this.penSizeMinusButton.Click += new System.EventHandler(this.penSizeMinusButton_Click);
            // 
            // penSizePlusButton
            // 
            this.penSizePlusButton.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.penSizePlusButton.Location = new System.Drawing.Point(205, 18);
            this.penSizePlusButton.Name = "penSizePlusButton";
            this.penSizePlusButton.Size = new System.Drawing.Size(84, 84);
            this.penSizePlusButton.TabIndex = 0;
            this.penSizePlusButton.Text = "+";
            this.penSizePlusButton.UseVisualStyleBackColor = true;
            this.penSizePlusButton.Click += new System.EventHandler(this.penSizePlusButton_Click);
            // 
            // recognizeButton
            // 
            this.recognizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recognizeButton.Location = new System.Drawing.Point(348, 309);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(296, 46);
            this.recognizeButton.TabIndex = 1;
            this.recognizeButton.Text = "RECOGNIZE";
            this.recognizeButton.UseVisualStyleBackColor = true;
            this.recognizeButton.Click += new System.EventHandler(this.recognizeButton_Click);
            // 
            // drawingPictureBox
            // 
            this.drawingPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.drawingPictureBox.BackColor = System.Drawing.Color.Black;
            this.drawingPictureBox.Location = new System.Drawing.Point(6, 19);
            this.drawingPictureBox.Name = "drawingPictureBox";
            this.drawingPictureBox.Size = new System.Drawing.Size(336, 336);
            this.drawingPictureBox.TabIndex = 0;
            this.drawingPictureBox.TabStop = false;
            this.drawingPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPictureBox_MouseDown);
            this.drawingPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPictureBox_MouseMove);
            this.drawingPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPictureBox_MouseUp);
            // 
            // predictionGroupBox
            // 
            this.predictionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.predictionGroupBox.Controls.Add(this.predictionTextBox);
            this.predictionGroupBox.Location = new System.Drawing.Point(275, 400);
            this.predictionGroupBox.Name = "predictionGroupBox";
            this.predictionGroupBox.Size = new System.Drawing.Size(650, 157);
            this.predictionGroupBox.TabIndex = 3;
            this.predictionGroupBox.TabStop = false;
            this.predictionGroupBox.Text = "Prediction";
            // 
            // predictionTextBox
            // 
            this.predictionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.predictionTextBox.BackColor = System.Drawing.Color.Black;
            this.predictionTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictionTextBox.ForeColor = System.Drawing.Color.White;
            this.predictionTextBox.Location = new System.Drawing.Point(7, 20);
            this.predictionTextBox.Multiline = true;
            this.predictionTextBox.Name = "predictionTextBox";
            this.predictionTextBox.ReadOnly = true;
            this.predictionTextBox.Size = new System.Drawing.Size(637, 131);
            this.predictionTextBox.TabIndex = 0;
            this.predictionTextBox.Text = "Nothing to output...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 569);
            this.Controls.Add(this.predictionGroupBox);
            this.Controls.Add(this.drawingGroupBox);
            this.Controls.Add(this.drawingHistoryPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecoDigit";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.drawingHistoryPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawingHistoryDataGrid)).EndInit();
            this.drawingGroupBox.ResumeLayout(false);
            this.imageOptionsGroupBox.ResumeLayout(false);
            this.penGroupBox.ResumeLayout(false);
            this.penGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingPictureBox)).EndInit();
            this.predictionGroupBox.ResumeLayout(false);
            this.predictionGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem networkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel drawingHistoryPanel;
        private System.Windows.Forms.DataGridView drawingHistoryDataGrid;
        private System.Windows.Forms.Button drawingHistoryClearButton;
        private System.Windows.Forms.Button drawingHistoryRemoveButton;
        private System.Windows.Forms.Button drawingHistoryCopyButton;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prediction;
        private System.Windows.Forms.GroupBox drawingGroupBox;
        private System.Windows.Forms.PictureBox drawingPictureBox;
        private System.Windows.Forms.GroupBox predictionGroupBox;
        private System.Windows.Forms.TextBox predictionTextBox;
        private System.Windows.Forms.Button recognizeButton;
        private System.Windows.Forms.GroupBox penGroupBox;
        private System.Windows.Forms.Button penSizePlusButton;
        private System.Windows.Forms.Button penSizeMinusButton;
        private System.Windows.Forms.Label penSizeLabel;
        private System.Windows.Forms.GroupBox imageOptionsGroupBox;
        private System.Windows.Forms.Button imageOptionsExportButton;
        private System.Windows.Forms.Button imageOptionsClearButton;
    }
}

