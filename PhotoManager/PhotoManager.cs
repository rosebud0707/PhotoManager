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
                fbFrom.Description = "raw�t�@�C�����z�u����Ă�t�H���_��I�����Ă��������B";


                if(fbFrom.ShowDialog() == DialogResult.OK) 
                {
                    // �e�L�X�g�G���A�Ƀp�X��\��
                    txtSaveFrom.Text = fbFrom.SelectedPath;
                }
            }

            SwitchEnableSaveButton();
        }

        private void BtnToOpen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbTo = new FolderBrowserDialog())
            {
                fbTo.Description = "�ۑ���t�H���_��I�����Ă��������B";
                fbTo.ShowNewFolderButton = true;

                if (fbTo.ShowDialog() == DialogResult.OK)
                {
                    // �e�L�X�g�G���A�Ƀp�X��\��
                    txtSaveTo.Text = fbTo.SelectedPath;
                }
            }

            SwitchEnableSaveButton();
        }

        /// <summary>
        /// �u�ۑ��v�{�^���̊�����Ԑ؂�ւ�
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
                // raw�f�[�^�̊g���q�ݒ�
                string[] rawExtentions = { RAW_EXTENTION_CANON_CR2 };

                int saveFileCount = Directory.EnumerateFiles(txtSaveFrom.Text, RAW_EXTENTION_CANON_CR2).Count();

                if(saveFileCount == 0)
                {
                    MessageBox.Show("�ۑ�����raw�f�[�^�����݂��܂���B",
                                    "�I",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else 
                {
                    // �v���O���X�o�[�ő�l�ݒ�
                    pgBar.Maximum = Directory.EnumerateFiles(txtSaveFrom.Text, RAW_EXTENTION_CANON_CR2).Count();

                    foreach (string imageFilePath in Directory.EnumerateFiles(txtSaveFrom.Text, RAW_EXTENTION_CANON_CR2))
                    {
                        // �ۑ����t�H���_���raw�f�[�^�����[�v
                        // �����Ώ�raw�f�[�^�t�@�C�����擾
                        string fileNm = Path.GetFileName(imageFilePath);

                        // �u�w�肵���ۑ���\yyyy(raw�f�[�^�̍쐬�N)\yyyyMMdd(raw�f�[�^�̍쐬�N����)�v�Ńt�H���_�쐬
                        string[] paths = { txtSaveTo.Text, File.GetCreationTime(imageFilePath).ToString("yyyy"), File.GetCreationTime(imageFilePath).ToString("yyyyMMdd") };
                        string savePath = Path.Combine(paths);

                        // �ۑ���t�H���_�����݂��Ȃ���΍쐬
                        if (!string.IsNullOrEmpty(savePath))
                        {
                            Directory.CreateDirectory(savePath);
                        }

                        // �R�s�[
                        File.Copy(imageFilePath, Path.Combine(savePath, fileNm));

                        // �v���O���X�o�[���Z
                        pgBar.Value += 1;
                    }

                    DialogResult rs =  MessageBox.Show("�R�s�[���������܂����B",
                                                       "����",
                                                       MessageBoxButtons.OK,
                                                       MessageBoxIcon.Information);

                    if(rs.Equals(DialogResult.OK))
                    {
                        // �v���O���X�o�[�̃��Z�b�g
                        pgBar.Maximum = 100;
                        pgBar.Value = 0;
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("�G���[���������܂����B" + ex.ToString(), 
                                "�G���[",
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