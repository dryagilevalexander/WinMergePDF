using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;

namespace WinMergePDF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            filesGridView = new DataGridView();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)filesGridView).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            button1.Location = new Point(190, 12);
            button1.Name = "button1";
            button1.Size = new Size(133, 23);
            button1.TabIndex = 0;
            button1.Text = "Выберите файлы";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(223, 50);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 53);
            label1.Name = "label1";
            label1.Size = new Size(205, 15);
            label1.TabIndex = 2;
            label1.Text = "Введите количество листов в файле";
            // 
            // button2
            // 
            button2.Location = new Point(149, 125);
            button2.Name = "button2";
            button2.Size = new Size(174, 23);
            button2.TabIndex = 3;
            button2.Text = "Ok";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 89);
            label2.Name = "label2";
            label2.Size = new Size(182, 15);
            label2.TabIndex = 5;
            label2.Text = "Введите шаблон наименования";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(223, 86);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            // 
            // button3
            // 
            button3.Location = new Point(149, 183);
            button3.Name = "button3";
            button3.Size = new Size(174, 23);
            button3.TabIndex = 6;
            button3.Text = "Обработать";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(149, 154);
            button4.Name = "button4";
            button4.Size = new Size(174, 23);
            button4.TabIndex = 7;
            button4.Text = "Папка для сохранения";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // filesGridView
            // 
            filesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            filesGridView.Location = new Point(382, 19);
            filesGridView.Name = "filesGridView";
            filesGridView.RowTemplate.Height = 25;
            filesGridView.Size = new Size(391, 187);
            filesGridView.TabIndex = 8;
            // 
            // button5
            // 
            button5.Location = new Point(636, 218);
            button5.Name = "button5";
            button5.Size = new Size(137, 23);
            button5.TabIndex = 9;
            button5.Text = "Открыть папку";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Controls.Add(filesGridView);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Работа с PDF";
            ((System.ComponentModel.ISupportInitialize)filesGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Button button2;
        private Label label2;
        private TextBox textBox2;
        private Button button3;
        private Button button4;
        private FolderBrowserDialog folderBrowserDialog1;
        private DataGridView filesGridView;
        private Button button5;
    }
}