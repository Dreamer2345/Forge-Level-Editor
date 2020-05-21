namespace RogueboyLevelEditor.Forms
{
    partial class NewMapForm
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
            this.components = new System.ComponentModel.Container();
            this.mapWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mapHeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.createButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.mapTimerUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mapWidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTimerUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapWidthUpDown
            // 
            this.mapWidthUpDown.Location = new System.Drawing.Point(190, 63);
            this.mapWidthUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mapWidthUpDown.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.mapWidthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mapWidthUpDown.Name = "mapWidthUpDown";
            this.mapWidthUpDown.Size = new System.Drawing.Size(180, 26);
            this.mapWidthUpDown.TabIndex = 3;
            this.mapWidthUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Map &Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Map &Height";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // mapHeightUpDown
            // 
            this.mapHeightUpDown.Location = new System.Drawing.Point(190, 106);
            this.mapHeightUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mapHeightUpDown.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.mapHeightUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mapHeightUpDown.Name = "mapHeightUpDown";
            this.mapHeightUpDown.Size = new System.Drawing.Size(180, 26);
            this.mapHeightUpDown.TabIndex = 5;
            this.mapHeightUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(139, 211);
            this.createButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(112, 35);
            this.createButton.TabIndex = 8;
            this.createButton.Text = "&Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(190, 23);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Map";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Name";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(259, 211);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 35);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // mapTimerUpDown
            // 
            this.mapTimerUpDown.Location = new System.Drawing.Point(191, 149);
            this.mapTimerUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mapTimerUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.mapTimerUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mapTimerUpDown.Name = "mapTimerUpDown";
            this.mapTimerUpDown.Size = new System.Drawing.Size(180, 26);
            this.mapTimerUpDown.TabIndex = 7;
            this.mapTimerUpDown.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 151);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Timer";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // NewMapForm
            // 
            this.AcceptButton = this.createButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(429, 277);
            this.ControlBox = false;
            this.Controls.Add(this.mapTimerUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.mapHeightUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mapWidthUpDown);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewMapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Map";
            ((System.ComponentModel.ISupportInitialize)(this.mapWidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTimerUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown mapWidthUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown mapHeightUpDown;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.NumericUpDown mapTimerUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}