using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PhotoManager
{
    public partial class PhotoManager : Form
    {
        private const string RAW_EXTENTION_CANON_CR2 = "*.CR2";

        public PhotoManager()
        {
            InitializeComponent();
        }

        private void BtnFromOpen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbFrom = new FolderBrowserDialog())
            {
                fbFrom.Description = "rawファイルが配置されてるフォルダを選択してください。";


                if(fbFrom.ShowDialog() == DialogResult.OK) 
                {
                    // テキストエリアにパスを表示
                    txtSaveFrom.Text = fbFrom.SelectedPath;
                }
            }

            SwitchEnableSaveButton();
        }

        private void BtnToOpen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbTo = new FolderBrowserDialog())
            {
                fbTo.Description = "保存先フォルダを選択してください。";
                fbTo.ShowNewFolderButton = true;

                if (fbTo.ShowDialog() == DialogResult.OK)
                {
                    // テキストエリアにパスを表示
                    txtSaveTo.Text = fbTo.SelectedPath;
                }
            }

            SwitchEnableSaveButton();
        }

        /// <summary>
        /// 「保存」ボタンの活性状態切り替え
        /// </summary>
        private void SwitchEnableSaveButton() 
        {
            if (!string.IsNullOrEmpty(txtSaveFrom.Text) && !string.IsNullOrEmpty(txtSaveTo.Text))
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // rawデータの拡張子設定
                string[] rawExtentions = { RAW_EXTENTION_CANON_CR2 };

                int saveFileCount = Directory.EnumerateFiles(txtSaveFrom.Text, RAW_EXTENTION_CANON_CR2).Count();

                if(saveFileCount == 0)
                {
                    MessageBox.Show("保存元にrawデータが存在しません。",
                                    "！",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else 
                {
                    // プログレスバー最大値設定
                    pgBar.Maximum = Directory.EnumerateFiles(txtSaveFrom.Text, RAW_EXTENTION_CANON_CR2).Count();

                    foreach (string imageFilePath in Directory.EnumerateFiles(txtSaveFrom.Text, RAW_EXTENTION_CANON_CR2))
                    {
                        // 保存元フォルダよりrawデータをループ
                        // 処理対象rawデータファイル名取得
                        string fileNm = Path.GetFileName(imageFilePath);

                        // 「指定した保存先\yyyy(rawデータの作成年)\yyyyMMdd(rawデータの作成年月日)」でフォルダ作成
                        string[] paths = { txtSaveTo.Text, File.GetCreationTime(imageFilePath).ToString("yyyy"), File.GetCreationTime(imageFilePath).ToString("yyyyMMdd") };
                        string savePath = Path.Combine(paths);

                        // 保存先フォルダが存在しなければ作成
                        if (!string.IsNullOrEmpty(savePath))
                        {
                            Directory.CreateDirectory(savePath);
                        }

                        // コピー
                        File.Copy(imageFilePath, Path.Combine(savePath, fileNm));

                        // プログレスバー加算
                        pgBar.Value += 1;
                    }

                    DialogResult rs =  MessageBox.Show("コピーが完了しました。",
                                                       "完了",
                                                       MessageBoxButtons.OK,
                                                       MessageBoxIcon.Information);

                    if(rs.Equals(DialogResult.OK))
                    {
                        // プログレスバーのリセット
                        pgBar.Maximum = 100;
                        pgBar.Value = 0;
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("エラーが発生しました。" + ex.ToString(), 
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}