using System;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace Lab_8_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string path = @"D:\";
        public string filter = "Example.txt";

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
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;


            /*using (FileStream myStream = File.Open(@"D:\Example.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                StreamReader myReader = new StreamReader(myStream);
                //myReader.Flush();
                myStream.Position = 0;
                string fileText = myReader.ReadToEnd();
                textBox1.Text = fileText;
            }*/


            using (var sr = new StreamReader(@"D:\Example.txt"))
            {
                // Read the stream as a string, and write the string to the console.
                string fileText = sr.ReadToEnd();
                textBox1.Text = fileText;
                sr.Close();
            }



            /*
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = File.ReadAllText(filename);
            textBox1.Text = fileText;
            //MessageBox.Show("Файл открыт");*/



            //string path = @"D:\\";
            //string filter = "Example.txt";

            /*using (FileStream fstream = File.OpenRead($"{path}"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);

            }*/

            //filename = path + filter;

            //fsw.Changed += new FileSystemEventHandler(fsw_Changed);
            fileSystemWatcher1.Changed += fsw_Changed;
            fileSystemWatcher1.Path= path;
            fileSystemWatcher1.Filter=filter;
            fileSystemWatcher1.NotifyFilter= NotifyFilters.LastWrite;
            /*fsw.Changed += fsw_Changed;
            fsw.Path = path;
            fsw.Filter = filter;
            fsw.NotifyFilter = NotifyFilters.Size;*/
        }

        /* private FileSystemWatcher _watcher;
         private bool _enabled = true;

         public void Logger()
         {
             _watcher = new FileSystemWatcher("D:\\");
             _watcher.Filter = "Example.txt";
             _watcher.Changed += fsw_Changed;
         }

         public void Start()
         {
             _watcher.EnableRaisingEvents = true;
         }

         public void Stop()
         {
             _watcher.EnableRaisingEvents = false;
             _enabled = false;
         }

         private void fsw_Changed(object sender, FileSystemEventArgs e)
         {
             try
             {
                 RecordEntry();
                 _watcher.EnableRaisingEvents = false; //отключаем слежение
             }

             finally
             {
                 _watcher.EnableRaisingEvents = true; //переподключаем слежение
             }
         }

         private void RecordEntry()
         {
             textBox1.Text = "1";
         }*/

        private void fsw_Changed(object sender, FileSystemEventArgs e)
        {

            try
            {
                //var Reader = new System.IO.StreamReader(fileSystemWatcher1.Path + "\\" + fileSystemWatcher1.Filter, Encoding.GetEncoding(1251));
                var Reader = new StreamReader(@"D:\\Example.txt");
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





















            /*using (FileStream fstream = File.OpenRead($"{fileSystemWatcher1.Filter}"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);

            }*/



            /*string filename = path + filter;
            // читаем файл в строку
            string fileText = File.ReadAllText(filename);
            textBox1.Text = fileText;*/


            /*string filename = path + filter;
            StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default);
            string fileText = sr.ReadToEnd();
            textBox1.Text = fileText;*/


            //Stream myStream;

            /*using (myStream = File.Open(@"D:\Example.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter myWriter = new StreamWriter(myStream);
                myWriter.WriteLine("test");
            }*/

            /*using (FileStream myStream = File.Open(@"D:\Example.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                myStream.Position = 0;
                StreamReader myReader = new StreamReader(myStream);
                string fileText = myReader.ReadToEnd();
                textBox1.Text = fileText;
            }*/

            /*textBox1.Text = "";

            using (var sr = new StreamReader(@"D:\Example.txt"))
            {
                // Read the stream as a string, and write the string to the console.
                string fileText = sr.ReadToEnd();
                textBox1.Text = fileText;
            }*/


            /*using (FileStream myStream = File.Open(@"D:\Example.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                StreamReader myReader = new StreamReader(myStream);
                //myReader.Flush();
                myStream.Position = 0;
                string fileText = myReader.ReadToEnd();
                textBox1.Text = fileText;
            }*/


            //textBox1.Text = Convert.ToString('i');
        }
    }
}
