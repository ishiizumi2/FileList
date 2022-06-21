namespace filecomp
{
    partial class FileList
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.FoldeOpen = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Close_Btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AfterButton = new System.Windows.Forms.RadioButton();
            this.BeforeButton = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // FoldeOpen
            // 
            this.FoldeOpen.BackColor = System.Drawing.Color.Aqua;
            this.FoldeOpen.Location = new System.Drawing.Point(19, 37);
            this.FoldeOpen.Name = "FoldeOpen";
            this.FoldeOpen.Size = new System.Drawing.Size(107, 52);
            this.FoldeOpen.TabIndex = 17;
            this.FoldeOpen.Text = "フォルダを開く";
            this.FoldeOpen.UseVisualStyleBackColor = false;
            this.FoldeOpen.Click += new System.EventHandler(this.FoldeOpen_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 128);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(320, 19);
            this.textBox1.TabIndex = 19;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "CSV";
            this.saveFileDialog1.Filter = "CSVファイル(*.CSV)|*.CSV;|すべてのファイル(*.*)|*.*";
            // 
            // Close_Btn
            // 
            this.Close_Btn.BackColor = System.Drawing.Color.Yellow;
            this.Close_Btn.Location = new System.Drawing.Point(19, 343);
            this.Close_Btn.Name = "Close_Btn";
            this.Close_Btn.Size = new System.Drawing.Size(107, 58);
            this.Close_Btn.TabIndex = 32;
            this.Close_Btn.Text = "終了";
            this.Close_Btn.UseVisualStyleBackColor = false;
            this.Close_Btn.Click += new System.EventHandler(this.Close_Btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AfterButton);
            this.groupBox1.Controls.Add(this.BeforeButton);
            this.groupBox1.Location = new System.Drawing.Point(194, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(138, 52);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "フォルダ選択";
            // 
            // AfterButton
            // 
            this.AfterButton.AutoSize = true;
            this.AfterButton.Location = new System.Drawing.Point(13, 33);
            this.AfterButton.Margin = new System.Windows.Forms.Padding(2);
            this.AfterButton.Name = "AfterButton";
            this.AfterButton.Size = new System.Drawing.Size(49, 16);
            this.AfterButton.TabIndex = 1;
            this.AfterButton.Text = "After";
            this.AfterButton.UseVisualStyleBackColor = true;
            // 
            // BeforeButton
            // 
            this.BeforeButton.AutoSize = true;
            this.BeforeButton.Checked = true;
            this.BeforeButton.Location = new System.Drawing.Point(13, 13);
            this.BeforeButton.Margin = new System.Windows.Forms.Padding(2);
            this.BeforeButton.Name = "BeforeButton";
            this.BeforeButton.Size = new System.Drawing.Size(57, 16);
            this.BeforeButton.TabIndex = 0;
            this.BeforeButton.TabStop = true;
            this.BeforeButton.Text = "Before";
            this.BeforeButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(405, 37);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(350, 317);
            this.dataGridView1.TabIndex = 52;
            // 
            // FileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 430);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Close_Btn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.FoldeOpen);
            this.Name = "FileList";
            this.Text = "FileList";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button FoldeOpen;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Close_Btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton AfterButton;
        private System.Windows.Forms.RadioButton BeforeButton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

