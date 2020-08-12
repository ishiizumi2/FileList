using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.Util;

namespace filecomp
{
    public partial class FolderCompForm : Form
    {
        List<string> FolderList1 = new List<string>();
        List<FileSetdata> FileSetDatas = new List<FileSetdata>();

        //FolderBrowserDialogクラスのインスタンスを作成
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        Encoding SJIS = Encoding.GetEncoding("Shift_JIS");

        public FolderCompForm()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// フォルダ1を指定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            fbd.SelectedPath = @"C:\Windows";
            textBox1.Text = FolderSelect();
            if(Directory.Exists(textBox1.Text))
            {
                await Task.Run(() =>
                {
                    FolderList1 = Directory.EnumerateFiles(@textBox1.Text, Filter.Text, SearchOption.AllDirectories).ToList(); // サブ・ディレクトも含める
                });
            }
        }

        /// <summary>
        /// フォルダを指定する
        /// </summary>
        /// <returns>フォルダ名</returns>
        private string FolderSelect()
        {
            string folderName = "";
            //上部に表示する説明テキストを指定する
            fbd.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            //fbd.SelectedPath = @"C:\Windows";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = false;
            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                folderName = fbd.SelectedPath;
            }
            return folderName;
        }

        /// <summary>
        /// ファイル一覧を取得
        /// <list>FileSetDatasにデータを追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var sdata in FolderList1.Select(c => c.Substring(textBox1.Text.Length)))
            {
                FileSetDatas.Add(new FileSetdata(
                   Path.GetFileName(sdata),
                   Path.GetDirectoryName(sdata),
                   Path.GetExtension(sdata)
                   ));
            }
            dataGridView1.DataSource = FileSetDatas;//List<>をDataGridViewにバインドする
        }

        /// <summary>
        /// Listtから比較対象外のファイルを削除する        /// 
        /// </summary>
        private void get_ready_list()
        {
            List<string> extension = new List<string>();//管理しない拡張子
            List<string> unnecessary = new List<string>();//管理しないファイル

            string fileName = Directory.GetCurrentDirectory() + @"\exclude.txt";//除外設定ファイル
            if (File.Exists(fileName))
            {
                IEnumerable<string> lines = File.ReadLines(fileName, SJIS);
                foreach (var line in lines.Where(c => c.Length > 2).Where(c => c.Substring(0, 2) == "*."))
                {
                    extension.Add(line);
                }

                foreach (var line in lines.Where(c => c.Length > 2).Where(c => c.Substring(0, 2) == "$$"))
                {
                    unnecessary.Add(line.Substring(2));
                }
            }

            foreach (var sdat in extension) //指定された拡張子のファイルを削除する
            {
                FolderList1.RemoveAll(c => Path.GetExtension(c).ToLower() == sdat.Substring(1).TrimEnd().ToLower());
            }

            foreach (var sdat in unnecessary) //管理しないファイルを削除する
            {
                FolderList1.RemoveAll(c => Path.GetFileName(c).ToLower() == sdat.ToLower());
            }

            FolderList1.RemoveAll(c => c.IndexOf("workarea", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        /// <summary>
        /// CSVファイル書き込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            string strFileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strFileName = saveFileDialog1.FileName;
            }
            else
            {
                return;
            }
            // CSVファイルオープン
            StreamWriter sw =
                new StreamWriter(strFileName, false, SJIS);

            foreach (var (item, index) in FileSetDatas.Select((item, index) => (item, index)))
            {
                string str = "";
                string no = (index + 1).ToString();
                string name = textBox4.Text + item.Foldername + "\\" + item.Filename;
                str = no + "," + name;
                sw.WriteLine(str);
            }
            // CSVファイルクローズ
            sw.Close();
        }

        /// <summary>
        /// 終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    class FileSetdata
    {
        public string Filename { get; private set; }
        public string Foldername { get; private set; }
        public string Extension { get; private set; }

        public FileSetdata() { }
        public FileSetdata(string filename, string foldername, string extension)
        {
            Filename = filename;
            Foldername = foldername;
            Extension = extension;
        }
    }
}
