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
            this.Filter = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FileCopyBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // FoldeOpen
            // 
            this.FoldeOpen.Location = new System.Drawing.Point(19, 12);
            this.FoldeOpen.Name = "FoldeOpen";
            this.FoldeOpen.Size = new System.Drawing.Size(107, 35);
            this.FoldeOpen.TabIndex = 17;
            this.FoldeOpen.Text = "フォルダを開く";
            this.FoldeOpen.UseVisualStyleBackColor = true;
            this.FoldeOpen.Click += new System.EventHandler(this.FoldeOpen_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 53);
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
            this.Close_Btn.Location = new System.Drawing.Point(19, 343);
            this.Close_Btn.Name = "Close_Btn";
            this.Close_Btn.Size = new System.Drawing.Size(138, 58);
            this.Close_Btn.TabIndex = 32;
            this.Close_Btn.Text = "終了";
            this.Close_Btn.UseVisualStyleBackColor = true;
            this.Close_Btn.Click += new System.EventHandler(this.Close_Btn_Click);
            // 
            // Filter
            // 
            this.Filter.Location = new System.Drawing.Point(19, 106);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(85, 19);
            this.Filter.TabIndex = 41;
            this.Filter.Text = "*.*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(19, 158);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(138, 52);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "フォルダ選択";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(13, 33);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "変更後";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 13);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "変更前";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 12);
            this.label1.TabIndex = 50;
            this.label1.Text = "フィルター";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 236);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(320, 19);
            this.textBox2.TabIndex = 51;
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
            // FileCopyBtn
            // 
            this.FileCopyBtn.Location = new System.Drawing.Point(170, 158);
            this.FileCopyBtn.Name = "FileCopyBtn";
            this.FileCopyBtn.Size = new System.Drawing.Size(138, 58);
            this.FileCopyBtn.TabIndex = 48;
            this.FileCopyBtn.Text = "ファイルコピー";
            this.FileCopyBtn.UseVisualStyleBackColor = true;
            this.FileCopyBtn.Click += new System.EventHandler(this.FileCopyBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(405, 360);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 58);
            this.button3.TabIndex = 53;
            this.button3.Text = "ファイル一覧";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 430);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FileCopyBtn);
            this.Controls.Add(this.Filter);
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
        private System.Windows.Forms.TextBox Filter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button FileCopyBtn;
        private System.Windows.Forms.Button button3;
    }
}

