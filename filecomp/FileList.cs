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
using System.Reflection;
using FileListLibrary;

using System.Xml.Linq;

namespace filecomp
{
    public partial class FileList : Form
    {
        FileListLibrary.FileListClass filelistclass = new FileListLibrary.FileListClass();

        //FolderBrowserDialogクラスのインスタンスを作成
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        Encoding SJIS = Encoding.GetEncoding("Shift_JIS");
        string WorkFolder;
        string Excludefilename;
        string Selectfilename;
        string BeforeFolder;
        string AfterFolder;
        string StartSelectFolder;
        string SetFolderName;

        public FileList()
        {
            InitializeComponent();
            Initial_processing();
        }

        /// <summary>
        /// XMLFile(setlist.xml)の読み込み・設定
        /// </summary>
        private void XMLread()
        {
            string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "setlist.xml");//実行ファイルと同じフォルダ
            if (File.Exists(fileName))
            {
                //xmlファイルを指定する
                XElement xml = XElement.Load(fileName);
                //メンバー情報のタグ内の情報を取得する
                IEnumerable<XElement> infos = from item in xml.Elements("設定内容") select item;
                WorkFolder        = infos.Select(c => c.Element("WorkFolder").Value).FirstOrDefault()        ?? @"C:\FileList";
                Excludefilename   = infos.Select(c => c.Element("Excludefilename").Value).FirstOrDefault()   ?? "exclude.txt";
                Selectfilename    = infos.Select(c => c.Element("Selectfilename").Value).FirstOrDefault()    ?? "SelectFile.txt";
                BeforeFolder      = infos.Select(c => c.Element("BeforeFolder").Value).FirstOrDefault()      ?? @"\変更前\";
                AfterFolder       = infos.Select(c => c.Element("AfterFolder").Value).FirstOrDefault()       ?? @"\変更後\";
                StartSelectFolder = infos.Select(c => c.Element("StartSelectFolder").Value).FirstOrDefault() ?? @"C:\";
            }
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        private void Initial_processing()
        {
            XMLread();

            if (Directory.Exists(WorkFolder))//前回分のフォルダーが存在したら削除する
            {
                Directory.Delete(WorkFolder, true);
            }
            Directory.CreateDirectory(WorkFolder);//作業用フォルダ作成

            //プロパテイに固定値代入
            filelistclass.workfolder = WorkFolder;
            filelistclass.excludefilename = Excludefilename;
            filelistclass.selectfilename = Selectfilename;
            filelistclass.beforeFolder = BeforeFolder;
            filelistclass.afterFolder = AfterFolder;

            filelistclass.fileCopy(WorkFolder, Excludefilename);
            filelistclass.fileCopy(WorkFolder, Selectfilename);
            DataClear();
        }

        /// <summary>
        /// データクリア
        /// </summary>
        private void DataClear()
        {
            textBox1.Text = null;
            SetFolderName = null;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }

        /// <summary>
        /// フォルダーを指定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void FoldeOpen_Click(object sender, EventArgs e)
        {
            DataClear();
            fbd.SelectedPath = StartSelectFolder;
            SetFolderName = FolderSelect();
            textBox1.Text  = SetFolderName; // 表示用
            filelistclass.setfoldername = SetFolderName;
            if ((!String.IsNullOrEmpty(SetFolderName)) && (Directory.Exists(SetFolderName)))
            {
               filelistclass.FolderCopy(
                   filelistclass.CopyFileListCreate(
                   filelistclass.ListOfFiles(), radioButton1.Checked), 
                   WorkFolder, radioButton1.Checked);
            }
            

            // 作業前/作業後切り替え
            if (radioButton1.Checked)

            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }

            MessageBox.Show("コピー完了");
        }

        /// <summary>
        /// フォルダを設定
        /// </summary>
        /// <returns>フォルダ名</returns>
        private string FolderSelect()
        {
            string SelectFolderName = null;
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
                SelectFolderName = fbd.SelectedPath;
            }
            return SelectFolderName;
        }

        /// <summary>
        /// 終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


