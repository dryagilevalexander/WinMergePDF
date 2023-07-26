using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using System.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Metadata;
using System.Diagnostics;

namespace WinMergePDF
{
    public partial class Form1 : Form
    {
        public class FilesInfo
        {
            private static FilesInfo instance;
            public string NameOfDocument { get; set; }
            public int CountOfPages { get; set; }
            public string PathToSave { get; set; }
            public List<string> Files { get; set; }

            private FilesInfo()
            { }

            public static FilesInfo getInstance()
            {
                if (instance == null)
                    instance = new FilesInfo();
                return instance;
            }

        }

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Pdf Files|*.pdf";
            openFileDialog1.Multiselect = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            filesGridView.Visible = false;
        }


        public class FileInfo
        {
            public int Id { get; set; }
            public string fileName { get; set; }
            public int? CountOfPages { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            DialogResult dr = openFileDialog1.ShowDialog();
            FilesInfo filesInfo = FilesInfo.getInstance();
            List<FileInfo> filesData = new List<FileInfo>();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = openFileDialog1.FileNames.ToArray();
                var sortedFiles = files.OrderBy(p => p).OrderBy(p => p.Length);
                filesInfo.Files = sortedFiles.ToList();
                button2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;

                int i = 0;
                foreach (string file in filesInfo.Files)
                {
                    PdfDocument document = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                    FileInfo fileInfo = new();
                    fileInfo.Id = i;
                    fileInfo.fileName = Path.GetFileName(file);
                    fileInfo.CountOfPages = document.PageCount;
                    filesData.Add(fileInfo);
                    i++;
                    document.Close();
                }
                filesGridView.DataSource = filesData;
                filesGridView.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilesInfo filesInfo = FilesInfo.getInstance();
            filesInfo.CountOfPages = Convert.ToInt32(textBox1.Text);
            filesInfo.NameOfDocument = textBox2.Text;
            button4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PdfDocument mergedDocument = new PdfDocument();
            FilesInfo filesInfo = FilesInfo.getInstance();
            List<FileInfo> files = new List<FileInfo>();

            int currentCount = 1;
            int documentCount = 0;
            PdfDocument tempDocument = new PdfDocument();
            foreach (string file in filesInfo.Files)
            {
                if (Path.GetExtension(file) == ".pdf")
                {
                    PdfDocument document = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                    for (int i = 0; i < document.PageCount; i++)
                    {
                        tempDocument.AddPage(document.Pages[i]);
                    }
                }
            }

            tempDocument.Save(filesInfo.PathToSave + "\\temp.pdf");
            tempDocument = PdfReader.Open(filesInfo.PathToSave + "\\temp.pdf", PdfDocumentOpenMode.Import);

            for (int i = 0; i < tempDocument.PageCount; i++)
            {
                mergedDocument.AddPage(tempDocument.Pages[i]);

                if (currentCount == filesInfo.CountOfPages)
                {
                    documentCount++;
                    mergedDocument.Save(filesInfo.PathToSave + "\\" + filesInfo.NameOfDocument + " " + documentCount + ".pdf");
                    int pageCount = mergedDocument.PageCount;
                    for (int r = 0; r < pageCount; r++)
                    {
                        mergedDocument.Pages.RemoveAt(0);
                    }
                    currentCount = 1;

                    FileInfo fileInfo = new();
                    fileInfo.Id = documentCount;
                    fileInfo.fileName = filesInfo.NameOfDocument + " " + documentCount + ".pdf";
                    fileInfo.CountOfPages = pageCount;
                    files.Add(fileInfo);
                }
                else
                {
                    currentCount++;
                }
            }

            if (mergedDocument.PageCount > 0)
            {
                documentCount++;
                mergedDocument.Save(filesInfo.PathToSave + "\\" + filesInfo.NameOfDocument + " " + documentCount + ".pdf");
                FileInfo fileInfo = new();
                fileInfo.Id = documentCount;
                fileInfo.fileName = filesInfo.NameOfDocument;
                fileInfo.CountOfPages = mergedDocument.PageCount;
                files.Add(fileInfo);
            }
            MessageBox.Show("Обработка завершена");
            File.Delete(filesInfo.PathToSave + "\\temp.pdf");
            filesGridView.DataSource = files;
            button5.Visible = true;

            textBox1.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FilesInfo filesInfo = FilesInfo.getInstance();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                filesInfo.PathToSave = folderBrowserDialog1.SelectedPath;
            }
            button3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FilesInfo filesInfo = FilesInfo.getInstance();
            Process.Start("explorer.exe", filesInfo.PathToSave);
        }
    }
}