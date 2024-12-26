using System.Security.Cryptography;

namespace Bai_4
{
    public partial class Form1 : Form
    {
        bool isOpen = false;
        string textFile = "";

        public Form1()
        {
            InitializeComponent();
            InitializeFont();
        }


        //Menu event
        private void saveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Document file (*.doc)|*.doc|Document file (NEW) (*.docx)|*.docx|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(textSpace.Text);
                writer.Close();
                stream.Close();
            }
        }

        //Format tool
        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            fontDialog.ShowEffects = true;
            fontDialog.ShowHelp = true;
            fontDialog.ShowApply = true;

            if(fontDialog.ShowDialog() == DialogResult.OK)
            {
                textSpace.Font= fontDialog.Font;
                fontTool.Text = textSpace.SelectionFont.Name.ToString();
                sizeTool.Text = ((int)Math.Round(textSpace.Font.Size)).ToString();
            }
        }

        //Font,font size initialize
        private void InitializeFont()
        {
            foreach(FontFamily font in System.Drawing.FontFamily.Families)
            {
                fontTool.Items.Add(font.Name);
            }
            for (int i = 5; i <= 71; i++)
                sizeTool.Items.Add(i.ToString());
        }

        private void changeFont(object sender, EventArgs e)
        {
            // Check if fontTool or sizeTool is null or has no selection
            if (fontTool?.SelectedItem == null || sizeTool?.SelectedItem == null)
            {
                MessageBox.Show("Please select both a font and a size.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Apply the new font to textSpace
            try
            {
                textSpace.Font = new Font(fontTool.SelectedItem.ToString(), float.Parse(sizeTool.SelectedItem.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying font: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            if (textSpace.Text != "")
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn lưu các thay đổi?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (isOpen)
                    {
                        saveTool_Click(sender, e);
                    }
                    else saveAs();
                }
            }
            this.Text = "Untittled.txt";
            textSpace.Text = "";
            fontTool.Text = "Arial";
            sizeTool.Text = "12";
            isOpen = false;
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".doc";
            openFileDialog.Filter = "Document file | *.txt; *.doc; *.docx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (textSpace.Text != "")
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn lưu các thay đổi?", "", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        if (isOpen)
                        {
                            saveTool_Click(sender, e);
                        }
                        else saveAs();
                    }
                }
            }
            this.Text = openFileDialog.FileName;
            textFile = openFileDialog.FileName;
            textSpace.Text = File.ReadAllText(textFile);
            isOpen = true;
        }



        private void saveMenu_Click(object sender, EventArgs e)
        {
            if (textFile == "")
                saveAs();
            else
                using (StreamWriter sw = new StreamWriter(textFile))
                    sw.WriteLine(textSpace.Text);
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            if (isOpen)
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn lưu các thay đổi?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    saveTool_Click(sender, e);
                    Application.Exit();
                }
                else
                    Application.Exit();
            }
            else if (!isOpen && textSpace.Text == "")
            {
                Application.Exit();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn lưu các thay đổi?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    saveAs();
                    Application.Exit();
                }
                else
                    Application.Exit();
            }
        }


        //Tool event
        private void saveTool_Click(object sender, EventArgs e)
        {
            saveMenu_Click(sender, e);
        }
        private void addTool_Click(object sender, EventArgs e)
        {
            addMenu_Click(sender, e);
        }
        private void boldTool_Click(object sender, EventArgs e)
        {
            if (textSpace.Font != null)
            {
                Font font = textSpace.SelectionFont;
                FontStyle fs;
                if (font.Bold)
                    fs = FontStyle.Regular;
                else
                    fs = FontStyle.Bold;
                if (font.Underline)
                {
                    fs = (FontStyle)(fs | FontStyle.Underline);
                }
                if (font.Italic)
                {
                    fs = (FontStyle)(fs | FontStyle.Italic);
                }
                textSpace.SelectionFont = new Font(font.FontFamily, font.Size, fs);
            }
        }

        private void italicTool_Click(object sender, EventArgs e)
        {
            if (textSpace.Font != null)
            {
                Font font = textSpace.SelectionFont;
                FontStyle fs;
                if (font.Italic)
                    fs = FontStyle.Regular;
                else
                    fs = FontStyle.Italic;
                if (font.Underline)
                {
                    fs = (FontStyle)(fs | FontStyle.Underline);
                }
                if (font.Bold)
                {
                    fs = (FontStyle)(fs | FontStyle.Bold);
                }
                textSpace.SelectionFont = new Font(font.FontFamily, font.Size, fs);
            }
        }

        private void underlineTool_Click(object sender, EventArgs e)
        {
            if (textSpace.Font != null)
            {
                Font font = textSpace.SelectionFont;
                FontStyle fs;
                if (font.Underline)
                    fs = FontStyle.Regular;
                else
                    fs = FontStyle.Underline;
                if (font.Italic)
                {
                    fs = (FontStyle)(fs | FontStyle.Italic);
                }
                if (font.Bold)
                {
                    fs = (FontStyle)(fs | FontStyle.Bold);
                }
                textSpace.SelectionFont = new Font(font.FontFamily, font.Size, fs);
            }
        }

        
    }
}
