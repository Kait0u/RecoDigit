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
            networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            trainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            drawingHistoryPanel = new System.Windows.Forms.Panel();
            drawingHistoryRemoveButton = new System.Windows.Forms.Button();
            drawingHistoryCopyButton = new System.Windows.Forms.Button();
            drawingHistoryClearButton = new System.Windows.Forms.Button();
            drawingHistoryDataGrid = new System.Windows.Forms.DataGridView();
            Image = new System.Windows.Forms.DataGridViewImageColumn();
            Prediction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            drawingGroupBox = new System.Windows.Forms.GroupBox();
            imageOptionsGroupBox = new System.Windows.Forms.GroupBox();
            imageOptionsExportButton = new System.Windows.Forms.Button();
            imageOptionsClearButton = new System.Windows.Forms.Button();
            penGroupBox = new System.Windows.Forms.GroupBox();
            penSizeLabel = new System.Windows.Forms.Label();
            penSizeMinusButton = new System.Windows.Forms.Button();
            penSizePlusButton = new System.Windows.Forms.Button();
            recognizeButton = new System.Windows.Forms.Button();
            drawingPictureBox = new System.Windows.Forms.PictureBox();
            predictionGroupBox = new System.Windows.Forms.GroupBox();
            predictionTextBox = new System.Windows.Forms.TextBox();
            mainMenuStrip.SuspendLayout();
            drawingHistoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)drawingHistoryDataGrid).BeginInit();
            drawingGroupBox.SuspendLayout();
            imageOptionsGroupBox.SuspendLayout();
            penGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)drawingPictureBox).BeginInit();
            predictionGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // networkToolStripMenuItem
            // 
            networkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { trainToolStripMenuItem, loadToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            networkToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            networkToolStripMenuItem.Text = "Network";
            // 
            // trainToolStripMenuItem
            // 
            trainToolStripMenuItem.Name = "trainToolStripMenuItem";
            trainToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            trainToolStripMenuItem.Text = "Train";
            trainToolStripMenuItem.Click += trainToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { networkToolStripMenuItem, aboutToolStripMenuItem });
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            mainMenuStrip.Size = new System.Drawing.Size(1093, 24);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // drawingHistoryPanel
            // 
            drawingHistoryPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            drawingHistoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            drawingHistoryPanel.Controls.Add(drawingHistoryRemoveButton);
            drawingHistoryPanel.Controls.Add(drawingHistoryCopyButton);
            drawingHistoryPanel.Controls.Add(drawingHistoryClearButton);
            drawingHistoryPanel.Controls.Add(drawingHistoryDataGrid);
            drawingHistoryPanel.Location = new System.Drawing.Point(15, 32);
            drawingHistoryPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            drawingHistoryPanel.Name = "drawingHistoryPanel";
            drawingHistoryPanel.Size = new System.Drawing.Size(297, 610);
            drawingHistoryPanel.TabIndex = 1;
            // 
            // drawingHistoryRemoveButton
            // 
            drawingHistoryRemoveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            drawingHistoryRemoveButton.Location = new System.Drawing.Point(-2, 520);
            drawingHistoryRemoveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            drawingHistoryRemoveButton.Name = "drawingHistoryRemoveButton";
            drawingHistoryRemoveButton.Size = new System.Drawing.Size(146, 40);
            drawingHistoryRemoveButton.TabIndex = 3;
            drawingHistoryRemoveButton.Text = "Remove selected";
            drawingHistoryRemoveButton.UseVisualStyleBackColor = true;
            drawingHistoryRemoveButton.Click += drawingHistoryRemoveButton_Click;
            // 
            // drawingHistoryCopyButton
            // 
            drawingHistoryCopyButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            drawingHistoryCopyButton.Location = new System.Drawing.Point(150, 520);
            drawingHistoryCopyButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            drawingHistoryCopyButton.Name = "drawingHistoryCopyButton";
            drawingHistoryCopyButton.Size = new System.Drawing.Size(146, 40);
            drawingHistoryCopyButton.TabIndex = 2;
            drawingHistoryCopyButton.Text = "Copy selected";
            drawingHistoryCopyButton.UseVisualStyleBackColor = true;
            drawingHistoryCopyButton.Click += drawingHistoryCopyButton_Click;
            // 
            // drawingHistoryClearButton
            // 
            drawingHistoryClearButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            drawingHistoryClearButton.Location = new System.Drawing.Point(-2, 568);
            drawingHistoryClearButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            drawingHistoryClearButton.Name = "drawingHistoryClearButton";
            drawingHistoryClearButton.Size = new System.Drawing.Size(299, 42);
            drawingHistoryClearButton.TabIndex = 1;
            drawingHistoryClearButton.Text = "Clear History";
            drawingHistoryClearButton.UseVisualStyleBackColor = true;
            drawingHistoryClearButton.Click += drawingHistoryClearButton_Click;
            // 
            // drawingHistoryDataGrid
            // 
            drawingHistoryDataGrid.AllowUserToAddRows = false;
            drawingHistoryDataGrid.AllowUserToDeleteRows = false;
            drawingHistoryDataGrid.AllowUserToResizeColumns = false;
            drawingHistoryDataGrid.AllowUserToResizeRows = false;
            drawingHistoryDataGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            drawingHistoryDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            drawingHistoryDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            drawingHistoryDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Image, Prediction });
            drawingHistoryDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            drawingHistoryDataGrid.Location = new System.Drawing.Point(0, 0);
            drawingHistoryDataGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            drawingHistoryDataGrid.MultiSelect = false;
            drawingHistoryDataGrid.Name = "drawingHistoryDataGrid";
            drawingHistoryDataGrid.ReadOnly = true;
            drawingHistoryDataGrid.RowHeadersVisible = false;
            drawingHistoryDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            drawingHistoryDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            drawingHistoryDataGrid.ShowEditingIcon = false;
            drawingHistoryDataGrid.Size = new System.Drawing.Size(296, 513);
            drawingHistoryDataGrid.TabIndex = 0;
            // 
            // Image
            // 
            Image.FillWeight = 32.48731F;
            Image.HeaderText = "Image";
            Image.Name = "Image";
            Image.ReadOnly = true;
            Image.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Prediction
            // 
            Prediction.FillWeight = 167.5127F;
            Prediction.HeaderText = "Prediction";
            Prediction.Name = "Prediction";
            Prediction.ReadOnly = true;
            Prediction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // drawingGroupBox
            // 
            drawingGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            drawingGroupBox.Controls.Add(imageOptionsGroupBox);
            drawingGroupBox.Controls.Add(penGroupBox);
            drawingGroupBox.Controls.Add(recognizeButton);
            drawingGroupBox.Controls.Add(drawingPictureBox);
            drawingGroupBox.Location = new System.Drawing.Point(321, 32);
            drawingGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            drawingGroupBox.Name = "drawingGroupBox";
            drawingGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            drawingGroupBox.Size = new System.Drawing.Size(758, 421);
            drawingGroupBox.TabIndex = 2;
            drawingGroupBox.TabStop = false;
            drawingGroupBox.Text = "Draw a number!";
            // 
            // imageOptionsGroupBox
            // 
            imageOptionsGroupBox.Controls.Add(imageOptionsExportButton);
            imageOptionsGroupBox.Controls.Add(imageOptionsClearButton);
            imageOptionsGroupBox.Location = new System.Drawing.Point(406, 177);
            imageOptionsGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            imageOptionsGroupBox.Name = "imageOptionsGroupBox";
            imageOptionsGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            imageOptionsGroupBox.Size = new System.Drawing.Size(345, 147);
            imageOptionsGroupBox.TabIndex = 3;
            imageOptionsGroupBox.TabStop = false;
            imageOptionsGroupBox.Text = "Image Options";
            // 
            // imageOptionsExportButton
            // 
            imageOptionsExportButton.Location = new System.Drawing.Point(8, 77);
            imageOptionsExportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            imageOptionsExportButton.Name = "imageOptionsExportButton";
            imageOptionsExportButton.Size = new System.Drawing.Size(330, 47);
            imageOptionsExportButton.TabIndex = 1;
            imageOptionsExportButton.Text = "Export (28x28)";
            imageOptionsExportButton.UseVisualStyleBackColor = true;
            imageOptionsExportButton.Click += imageOptionsExportButton_Click;
            // 
            // imageOptionsClearButton
            // 
            imageOptionsClearButton.Location = new System.Drawing.Point(8, 23);
            imageOptionsClearButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            imageOptionsClearButton.Name = "imageOptionsClearButton";
            imageOptionsClearButton.Size = new System.Drawing.Size(330, 47);
            imageOptionsClearButton.TabIndex = 0;
            imageOptionsClearButton.Text = "Clear";
            imageOptionsClearButton.UseVisualStyleBackColor = true;
            imageOptionsClearButton.Click += imageOptionsClearButton_Click;
            // 
            // penGroupBox
            // 
            penGroupBox.Controls.Add(penSizeLabel);
            penGroupBox.Controls.Add(penSizeMinusButton);
            penGroupBox.Controls.Add(penSizePlusButton);
            penGroupBox.Location = new System.Drawing.Point(407, 23);
            penGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            penGroupBox.Name = "penGroupBox";
            penGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            penGroupBox.Size = new System.Drawing.Size(344, 125);
            penGroupBox.TabIndex = 2;
            penGroupBox.TabStop = false;
            penGroupBox.Text = "Pen Size";
            // 
            // penSizeLabel
            // 
            penSizeLabel.AutoSize = true;
            penSizeLabel.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 254);
            penSizeLabel.Location = new System.Drawing.Point(150, 55);
            penSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            penSizeLabel.Name = "penSizeLabel";
            penSizeLabel.Size = new System.Drawing.Size(36, 26);
            penSizeLabel.TabIndex = 2;
            penSizeLabel.Text = "10";
            penSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // penSizeMinusButton
            // 
            penSizeMinusButton.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 254);
            penSizeMinusButton.Location = new System.Drawing.Point(7, 22);
            penSizeMinusButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            penSizeMinusButton.Name = "penSizeMinusButton";
            penSizeMinusButton.Size = new System.Drawing.Size(98, 97);
            penSizeMinusButton.TabIndex = 1;
            penSizeMinusButton.Text = "-";
            penSizeMinusButton.UseVisualStyleBackColor = true;
            penSizeMinusButton.Click += penSizeMinusButton_Click;
            // 
            // penSizePlusButton
            // 
            penSizePlusButton.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 254);
            penSizePlusButton.Location = new System.Drawing.Point(239, 21);
            penSizePlusButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            penSizePlusButton.Name = "penSizePlusButton";
            penSizePlusButton.Size = new System.Drawing.Size(98, 97);
            penSizePlusButton.TabIndex = 0;
            penSizePlusButton.Text = "+";
            penSizePlusButton.UseVisualStyleBackColor = true;
            penSizePlusButton.Click += penSizePlusButton_Click;
            // 
            // recognizeButton
            // 
            recognizeButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            recognizeButton.Location = new System.Drawing.Point(406, 357);
            recognizeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            recognizeButton.Name = "recognizeButton";
            recognizeButton.Size = new System.Drawing.Size(345, 53);
            recognizeButton.TabIndex = 1;
            recognizeButton.Text = "RECOGNIZE";
            recognizeButton.UseVisualStyleBackColor = true;
            recognizeButton.Click += recognizeButton_Click;
            // 
            // drawingPictureBox
            // 
            drawingPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            drawingPictureBox.BackColor = System.Drawing.Color.Black;
            drawingPictureBox.Location = new System.Drawing.Point(7, 22);
            drawingPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            drawingPictureBox.Name = "drawingPictureBox";
            drawingPictureBox.Size = new System.Drawing.Size(392, 388);
            drawingPictureBox.TabIndex = 0;
            drawingPictureBox.TabStop = false;
            drawingPictureBox.MouseDown += drawingPictureBox_MouseDown;
            drawingPictureBox.MouseMove += drawingPictureBox_MouseMove;
            drawingPictureBox.MouseUp += drawingPictureBox_MouseUp;
            // 
            // predictionGroupBox
            // 
            predictionGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            predictionGroupBox.Controls.Add(predictionTextBox);
            predictionGroupBox.Location = new System.Drawing.Point(321, 462);
            predictionGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            predictionGroupBox.Name = "predictionGroupBox";
            predictionGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            predictionGroupBox.Size = new System.Drawing.Size(758, 181);
            predictionGroupBox.TabIndex = 3;
            predictionGroupBox.TabStop = false;
            predictionGroupBox.Text = "Prediction";
            // 
            // predictionTextBox
            // 
            predictionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            predictionTextBox.BackColor = System.Drawing.Color.Black;
            predictionTextBox.Font = new System.Drawing.Font("Consolas", 12F);
            predictionTextBox.ForeColor = System.Drawing.Color.White;
            predictionTextBox.Location = new System.Drawing.Point(8, 23);
            predictionTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            predictionTextBox.Multiline = true;
            predictionTextBox.Name = "predictionTextBox";
            predictionTextBox.ReadOnly = true;
            predictionTextBox.Size = new System.Drawing.Size(742, 151);
            predictionTextBox.TabIndex = 0;
            predictionTextBox.Text = "Nothing to output...";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1093, 657);
            Controls.Add(predictionGroupBox);
            Controls.Add(drawingGroupBox);
            Controls.Add(drawingHistoryPanel);
            Controls.Add(mainMenuStrip);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            MainMenuStrip = mainMenuStrip;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "RecoDigit";
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            drawingHistoryPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)drawingHistoryDataGrid).EndInit();
            drawingGroupBox.ResumeLayout(false);
            imageOptionsGroupBox.ResumeLayout(false);
            penGroupBox.ResumeLayout(false);
            penGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)drawingPictureBox).EndInit();
            predictionGroupBox.ResumeLayout(false);
            predictionGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prediction;
    }
}

