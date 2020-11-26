using System;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Text;

namespace Lab_8_1
{
    public partial class Form1 : Form
    {
        //public string path = @"C:\\Users\\Professional";
        public string path = @"D:\\";
 

        public Form1()
        {
            InitializeComponent();
            fileSystemWatcher1.Path = path;
            
            fileSystemWatcher1.Changed += fsw_Changed;
            fileSystemWatcher1.Filter = "*.txt";
            fileSystemWatcher1.NotifyFilter = NotifyFilters.LastWrite;

        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            File.WriteAllText(filename, textBox1.Text);
            //MessageBox.Show("Файл сохранен");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;
            // Чтение текстового файла
            try
            {
                var Reader = new System.IO.StreamReader(
                openFileDialog1.FileName, Encoding.GetEncoding(1251)
                );
                textBox1.Text = Reader.ReadToEnd();
                Reader.Close();
                string fileName = Path.GetFileName(openFileDialog1.FileName);

                fileSystemWatcher1.Filter = fileName;
                fileSystemWatcher1.EnableRaisingEvents = true;
              
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + "\nНет такого файла",
                         "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            { // отчет о других ошибках
                MessageBox.Show(ex.Message,
                     "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           
           
           
        }

        private void fsw_Changed(object sender, FileSystemEventArgs e)
        {

            try
            {
                //твое
               // var Reader = new System.IO.StreamReader(fileSystemWatcher1.Path + "\\" + fileSystemWatcher1.Filter, Encoding.GetEncoding(1251));
                //моё
                var Reader = new System.IO.StreamReader(
                openFileDialog1.FileName, Encoding.GetEncoding(1251));
                var result = Reader.ReadToEnd();
                Reader.Close();
                textBox1.Text = result;
                //SetResult(result);
            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + "\nНет такого файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
