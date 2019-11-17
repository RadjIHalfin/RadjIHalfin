namespace _4936U_XmlCheck
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.XmlFileFullPathTextBox = new System.Windows.Forms.TextBox();
            this.FileOpenBtn = new System.Windows.Forms.Button();
            this.FileTypeCBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckXmlBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "XML файлы|*.xml";
            // 
            // XmlFileFullPathTextBox
            // 
            this.XmlFileFullPathTextBox.Location = new System.Drawing.Point(13, 13);
            this.XmlFileFullPathTextBox.Name = "XmlFileFullPathTextBox";
            this.XmlFileFullPathTextBox.ReadOnly = true;
            this.XmlFileFullPathTextBox.Size = new System.Drawing.Size(616, 20);
            this.XmlFileFullPathTextBox.TabIndex = 0;
            // 
            // FileOpenBtn
            // 
            this.FileOpenBtn.Location = new System.Drawing.Point(635, 10);
            this.FileOpenBtn.Name = "FileOpenBtn";
            this.FileOpenBtn.Size = new System.Drawing.Size(75, 23);
            this.FileOpenBtn.TabIndex = 1;
            this.FileOpenBtn.Text = "Выбрать...";
            this.FileOpenBtn.UseVisualStyleBackColor = true;
            this.FileOpenBtn.Click += new System.EventHandler(this.FileOpenBtn_Click);
            // 
            // FileTypeCBox
            // 
            this.FileTypeCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FileTypeCBox.FormattingEnabled = true;
            this.FileTypeCBox.Items.AddRange(new object[] {
            "(не известно)",
            "01-Сообщение об операциях",
            "03-Сообщение о принятых мерах",
            "04-Сообщения о результатах проверки"});
            this.FileTypeCBox.Location = new System.Drawing.Point(80, 43);
            this.FileTypeCBox.Name = "FileTypeCBox";
            this.FileTypeCBox.Size = new System.Drawing.Size(241, 21);
            this.FileTypeCBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Тип файла";
            // 
            // CheckXmlBtn
            // 
            this.CheckXmlBtn.Location = new System.Drawing.Point(327, 42);
            this.CheckXmlBtn.Name = "CheckXmlBtn";
            this.CheckXmlBtn.Size = new System.Drawing.Size(111, 23);
            this.CheckXmlBtn.TabIndex = 4;
            this.CheckXmlBtn.Text = "Проверить файл";
            this.CheckXmlBtn.UseVisualStyleBackColor = true;
            this.CheckXmlBtn.Click += new System.EventHandler(this.CheckXmlBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Результат проверки:";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(563, 43);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(147, 20);
            this.ResultTextBox.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 84);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CheckXmlBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileTypeCBox);
            this.Controls.Add(this.FileOpenBtn);
            this.Controls.Add(this.XmlFileFullPathTextBox);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "4936-У. Проверка XML";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.TextBox XmlFileFullPathTextBox;
        private System.Windows.Forms.Button FileOpenBtn;
        private System.Windows.Forms.ComboBox FileTypeCBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CheckXmlBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ResultTextBox;
    }
}

