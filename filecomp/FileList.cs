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

namespace filecomp
{
    public partial class FileList : Form
    {
        List<string> FolderList1 = new List<string>();
        List<FileSetdata> FileSetDatas = new List<FileSetdata>();
        List<FileSetdata> CopyFileList = new List<FileSetdata>();//コピー対象ファイル
        List<string> quele1 = new List<string>();
 
        //FolderBrowserDialogクラスのインスタンスを作成
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        Encoding SJIS = Encoding.GetEncoding("Shift_JIS");
        string WorkFolder = @"C:\FileList";

        public FileList()
        {
            InitializeComponent();
            Initial_processing();
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        private void Initial_processing()
        {
            
            Directory.CreateDirectory(WorkFolder);//作業用フォルダ作成
            fileCopy("exclude.txt");
            fileCopy("SelectFile.txt");
        }

        private void fileCopy(string fname)
        {
            string fromfname = Path.Combine(Directory.GetCurrentDirectory(), fname);
            if (File.Exists(fromfname))
            {
                File.Copy(fromfname, Path.Combine(WorkFolder, fname), true);
            }
        }

        /// <summary>
        /// フォルダ1を指定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            fbd.SelectedPath = @"C:\";
            textBox1.Text = FolderSelect();
            if (Directory.Exists(textBox1.Text))
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
            if (!(FolderList1?.Count > 0))
            {
                return; //空なら抜ける
            }

            get_ready_list(FolderList1);//不要なファイルを削除する

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
        /// Listから比較対象外のファイルを削除する
        /// 設定ファイル exclude.txt
        /// </summary>
        private void get_ready_list(List<String> FolderList)
        {
            List<string> extension = new List<string>();//管理しない拡張子
            List<string> unnecessary = new List<string>();//管理しないファイル

            string FileName = Path.Combine( Directory.GetCurrentDirectory() , @"exclude.txt");//除外設定ファイル
            if (File.Exists(FileName))
            {
                IEnumerable<string> lines = File.ReadLines(FileName, SJIS);
                foreach (var line in lines.Where(c => c.Length > 2).Where(c => c.Substring(0, 2) == "*."))
                {
                    extension.Add(line);
                }

                foreach (var line in lines.Where(c => c.Length > 2).Where(c => c.Substring(0, 2) == "$$"))
                {
                    unnecessary.Add(line.Substring(2));
                }
            }
            else
            {
                return;
            }

            foreach (var sdat in extension) //指定された拡張子のファイルを削除する
            {
                FolderList.RemoveAll(c => Path.GetExtension(c).ToLower() == sdat.Substring(1).TrimEnd().ToLower());
            }

            foreach (var sdat in unnecessary) //管理しないファイルを削除する
            {
                FolderList.RemoveAll(c => Path.GetFileName(c).ToLower() == sdat.ToLower());
            }
            FolderList.RemoveAll(c => c.IndexOf("workarea", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        /// <summary>
        /// CSVファイル書き込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (!(FileSetDatas?.Count > 0))
            {
                return; //空なら抜ける
            }

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
                string name =  textBox4.Text + item.FolderName + item.FileName;
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

        
        private void button7_Click(object sender, EventArgs e)
        {
            CopyFileList.Clear();
            foreach (var SelectData in File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), "SelectFile.txt"), SJIS))
            {
                foreach (var sdata in FileSetDatas)
                {
                    string filename = sdata.FolderName + @"\" + sdata.FileName;
                    if (SelectData == filename.Substring(1))
                    {
                        listBox1.Items.Add(filename);
                        CopyFileList.Add(sdata);
                    }
                }
            }
            FolderCopy(CopyFileList, WorkFolder);
        }

       /// <summary>
       /// フォルダ作成・ファイルコピー
       /// </summary>
       /// <param name="list"></param>コピー元List
       /// <param name="dest_str"></param>コピー先フォルダ
        private void FolderCopy(List<FileSetdata>list, string dest_str)
        {
            string folde1 = null;
            // コピー先のフォルダ作成
            if (radioButton1.Checked)
            {
                folde1 = @"変更前\";
            }
            else
            {
                folde1 = @"変更後\";
            }
            dest_str = dest_str + folde1;
            Directory.CreateDirectory(dest_str);
            //コピー先のフォルダをカレントに指定する
            Directory.SetCurrentDirectory(dest_str);
           
            foreach (var sdata in list)
            {
                Directory.CreateDirectory(textBox4.Text + sdata.FolderName);
                string fromfname = textBox1.Text  + Path.Combine(sdata.FolderName, sdata.FileName);
                string tofname =  dest_str +  textBox4.Text  + Path.Combine(dest_str, sdata.FolderName, sdata.FileName);
                if (File.Exists(fromfname))
                {
                    File.Copy(fromfname, tofname, true);
                }
            }
        }
    }

    class FileSetdata
    {
        public string FileName { get; private set; }
        public string FolderName { get; private set; }
        public string Extension { get; private set; }

        public FileSetdata() { }
        public FileSetdata(string filename, string foldername, string extension)
        {
            FileName = filename;
            FolderName = foldername;
            Extension = extension;
        }
    }
}


