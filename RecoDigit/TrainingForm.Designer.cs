namespace RecoDigit
{
    partial class TrainingForm
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
            learningParametersGroupBox = new System.Windows.Forms.GroupBox();
            learningRateLabel = new System.Windows.Forms.Label();
            learningRateTextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            sampleCountLabel = new System.Windows.Forms.Label();
            iterationsCountTextBox = new System.Windows.Forms.TextBox();
            sampleCountTextBox = new System.Windows.Forms.TextBox();
            learningDatasetPathLabel = new System.Windows.Forms.Label();
            learningDatasetPathButton = new System.Windows.Forms.Button();
            learningDatasetPathTextBox = new System.Windows.Forms.TextBox();
            outputModelPathLabel = new System.Windows.Forms.Label();
            outputModelPathButton = new System.Windows.Forms.Button();
            outputModelPathTextBox = new System.Windows.Forms.TextBox();
            autoLoadCheckbox = new System.Windows.Forms.CheckBox();
            trainButton = new System.Windows.Forms.Button();
            outputLogGroupBox = new System.Windows.Forms.GroupBox();
            outputLogTextBox = new System.Windows.Forms.TextBox();
            trainingProgressBar = new System.Windows.Forms.ProgressBar();
            learningParametersGroupBox.SuspendLayout();
            outputLogGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // learningParametersGroupBox
            // 
            learningParametersGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            learningParametersGroupBox.Controls.Add(learningRateLabel);
            learningParametersGroupBox.Controls.Add(learningRateTextBox);
            learningParametersGroupBox.Controls.Add(label1);
            learningParametersGroupBox.Controls.Add(sampleCountLabel);
            learningParametersGroupBox.Controls.Add(iterationsCountTextBox);
            learningParametersGroupBox.Controls.Add(sampleCountTextBox);
            learningParametersGroupBox.Controls.Add(learningDatasetPathLabel);
            learningParametersGroupBox.Controls.Add(learningDatasetPathButton);
            learningParametersGroupBox.Controls.Add(learningDatasetPathTextBox);
            learningParametersGroupBox.Location = new System.Drawing.Point(12, 12);
            learningParametersGroupBox.Name = "learningParametersGroupBox";
            learningParametersGroupBox.Size = new System.Drawing.Size(524, 167);
            learningParametersGroupBox.TabIndex = 0;
            learningParametersGroupBox.TabStop = false;
            learningParametersGroupBox.Text = "Learning Parameters";
            // 
            // learningRateLabel
            // 
            learningRateLabel.AutoSize = true;
            learningRateLabel.Location = new System.Drawing.Point(282, 86);
            learningRateLabel.Name = "learningRateLabel";
            learningRateLabel.Size = new System.Drawing.Size(82, 15);
            learningRateLabel.TabIndex = 8;
            learningRateLabel.Text = "Learning rate: ";
            learningRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // learningRateTextBox
            // 
            learningRateTextBox.Location = new System.Drawing.Point(374, 83);
            learningRateTextBox.Name = "learningRateTextBox";
            learningRateTextBox.Size = new System.Drawing.Size(144, 23);
            learningRateTextBox.TabIndex = 7;
            learningRateTextBox.Text = "0.15";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 126);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 15);
            label1.TabIndex = 6;
            label1.Text = "Iterations: ";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sampleCountLabel
            // 
            sampleCountLabel.AutoSize = true;
            sampleCountLabel.Location = new System.Drawing.Point(6, 86);
            sampleCountLabel.Name = "sampleCountLabel";
            sampleCountLabel.Size = new System.Drawing.Size(86, 15);
            sampleCountLabel.TabIndex = 5;
            sampleCountLabel.Text = "Sample count: ";
            sampleCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iterationsCountTextBox
            // 
            iterationsCountTextBox.Location = new System.Drawing.Point(98, 123);
            iterationsCountTextBox.Name = "iterationsCountTextBox";
            iterationsCountTextBox.Size = new System.Drawing.Size(144, 23);
            iterationsCountTextBox.TabIndex = 4;
            iterationsCountTextBox.Text = "200";
            // 
            // sampleCountTextBox
            // 
            sampleCountTextBox.Location = new System.Drawing.Point(98, 83);
            sampleCountTextBox.Name = "sampleCountTextBox";
            sampleCountTextBox.Size = new System.Drawing.Size(144, 23);
            sampleCountTextBox.TabIndex = 3;
            // 
            // learningDatasetPathLabel
            // 
            learningDatasetPathLabel.AutoSize = true;
            learningDatasetPathLabel.Location = new System.Drawing.Point(6, 21);
            learningDatasetPathLabel.Name = "learningDatasetPathLabel";
            learningDatasetPathLabel.Size = new System.Drawing.Size(119, 15);
            learningDatasetPathLabel.TabIndex = 2;
            learningDatasetPathLabel.Text = "CSV Dataset Location";
            // 
            // learningDatasetPathButton
            // 
            learningDatasetPathButton.Location = new System.Drawing.Point(435, 39);
            learningDatasetPathButton.Name = "learningDatasetPathButton";
            learningDatasetPathButton.Size = new System.Drawing.Size(83, 23);
            learningDatasetPathButton.TabIndex = 1;
            learningDatasetPathButton.Text = "Browse";
            learningDatasetPathButton.UseVisualStyleBackColor = true;
            learningDatasetPathButton.Click += learningDatasetPathButton_Click;
            // 
            // learningDatasetPathTextBox
            // 
            learningDatasetPathTextBox.Location = new System.Drawing.Point(6, 39);
            learningDatasetPathTextBox.Name = "learningDatasetPathTextBox";
            learningDatasetPathTextBox.Size = new System.Drawing.Size(423, 23);
            learningDatasetPathTextBox.TabIndex = 0;
            // 
            // outputModelPathLabel
            // 
            outputModelPathLabel.AutoSize = true;
            outputModelPathLabel.Location = new System.Drawing.Point(12, 192);
            outputModelPathLabel.Name = "outputModelPathLabel";
            outputModelPathLabel.Size = new System.Drawing.Size(131, 15);
            outputModelPathLabel.TabIndex = 1;
            outputModelPathLabel.Text = "Model Output Location";
            // 
            // outputModelPathButton
            // 
            outputModelPathButton.Location = new System.Drawing.Point(441, 210);
            outputModelPathButton.Name = "outputModelPathButton";
            outputModelPathButton.Size = new System.Drawing.Size(95, 23);
            outputModelPathButton.TabIndex = 3;
            outputModelPathButton.Text = "Browse";
            outputModelPathButton.UseVisualStyleBackColor = true;
            outputModelPathButton.Click += outputModelPathButton_Click;
            // 
            // outputModelPathTextBox
            // 
            outputModelPathTextBox.Location = new System.Drawing.Point(12, 210);
            outputModelPathTextBox.Name = "outputModelPathTextBox";
            outputModelPathTextBox.Size = new System.Drawing.Size(423, 23);
            outputModelPathTextBox.TabIndex = 2;
            // 
            // autoLoadCheckbox
            // 
            autoLoadCheckbox.AutoSize = true;
            autoLoadCheckbox.Location = new System.Drawing.Point(12, 239);
            autoLoadCheckbox.Name = "autoLoadCheckbox";
            autoLoadCheckbox.Size = new System.Drawing.Size(263, 19);
            autoLoadCheckbox.TabIndex = 4;
            autoLoadCheckbox.Text = "Automatically load the network after training";
            autoLoadCheckbox.UseVisualStyleBackColor = true;
            // 
            // trainButton
            // 
            trainButton.Location = new System.Drawing.Point(12, 264);
            trainButton.Name = "trainButton";
            trainButton.Size = new System.Drawing.Size(524, 58);
            trainButton.TabIndex = 5;
            trainButton.Text = "TRAIN";
            trainButton.UseVisualStyleBackColor = true;
            trainButton.Click += trainButton_Click;
            // 
            // outputLogGroupBox
            // 
            outputLogGroupBox.Controls.Add(outputLogTextBox);
            outputLogGroupBox.Location = new System.Drawing.Point(12, 361);
            outputLogGroupBox.Name = "outputLogGroupBox";
            outputLogGroupBox.Size = new System.Drawing.Size(524, 284);
            outputLogGroupBox.TabIndex = 6;
            outputLogGroupBox.TabStop = false;
            outputLogGroupBox.Text = "Output Log";
            // 
            // outputLogTextBox
            // 
            outputLogTextBox.BackColor = System.Drawing.Color.Black;
            outputLogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            outputLogTextBox.Font = new System.Drawing.Font("Consolas", 12F);
            outputLogTextBox.ForeColor = System.Drawing.Color.White;
            outputLogTextBox.Location = new System.Drawing.Point(3, 19);
            outputLogTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            outputLogTextBox.Multiline = true;
            outputLogTextBox.Name = "outputLogTextBox";
            outputLogTextBox.ReadOnly = true;
            outputLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            outputLogTextBox.Size = new System.Drawing.Size(518, 262);
            outputLogTextBox.TabIndex = 1;
            outputLogTextBox.Text = "Nothing to output...";
            // 
            // trainingProgressBar
            // 
            trainingProgressBar.ForeColor = System.Drawing.Color.Lime;
            trainingProgressBar.Location = new System.Drawing.Point(12, 331);
            trainingProgressBar.Name = "trainingProgressBar";
            trainingProgressBar.Size = new System.Drawing.Size(524, 23);
            trainingProgressBar.TabIndex = 7;
            // 
            // TrainingForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(548, 657);
            Controls.Add(trainingProgressBar);
            Controls.Add(outputLogGroupBox);
            Controls.Add(trainButton);
            Controls.Add(autoLoadCheckbox);
            Controls.Add(outputModelPathButton);
            Controls.Add(outputModelPathTextBox);
            Controls.Add(outputModelPathLabel);
            Controls.Add(learningParametersGroupBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "TrainingForm";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "RecoDigit: Training Form";
            learningParametersGroupBox.ResumeLayout(false);
            learningParametersGroupBox.PerformLayout();
            outputLogGroupBox.ResumeLayout(false);
            outputLogGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox learningParametersGroupBox;
        private System.Windows.Forms.TextBox learningDatasetPathTextBox;
        private System.Windows.Forms.Label learningDatasetPathLabel;
        private System.Windows.Forms.Button learningDatasetPathButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sampleCountLabel;
        private System.Windows.Forms.TextBox iterationsCountTextBox;
        private System.Windows.Forms.TextBox sampleCountTextBox;
        private System.Windows.Forms.Label outputModelPathLabel;
        private System.Windows.Forms.Button outputModelPathButton;
        private System.Windows.Forms.TextBox outputModelPathTextBox;
        private System.Windows.Forms.CheckBox autoLoadCheckbox;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.GroupBox outputLogGroupBox;
        private System.Windows.Forms.TextBox outputLogTextBox;
        private System.Windows.Forms.Label learningRateLabel;
        private System.Windows.Forms.TextBox learningRateTextBox;
        private System.Windows.Forms.ProgressBar trainingProgressBar;
    }
}