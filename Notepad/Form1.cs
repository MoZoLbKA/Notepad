using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            filePath = "";                      
            uTF8ToolStripMenuItem.Checked = false;
            mainColor = Color.DarkTurquoise;
            secondColor = Color.White;
            aSCIIToolStripMenuItem.Checked = false;
            win1251ToolStripMenuItem.Checked = true;
            toolStripStatusLabel1.Text = "Win-1251";
            isChanged = false;
            symbols = richTextBox1.Text.Length;


        }
        public Form1(SaveForm saveForm)
        {
            InitializeComponent();
            filePath = "";
            uTF8ToolStripMenuItem.Checked = false;
            aSCIIToolStripMenuItem.Checked = false;
            win1251ToolStripMenuItem.Checked = true;
            toolStripStatusLabel1.Text = "Win-1251";
            isChanged = false;
            symbols = richTextBox1.Text.Length;
            

        }
        static public Color mainColor;
        static public Color secondColor;
        static public Color fontColor;
        private string filePath;        
        private int symbols;
        private bool isChanged;
        private Stack<string> undoList = new Stack<string>();


        private static readonly Encoding utf = Encoding.UTF8;
        private static readonly Encoding ascii = Encoding.ASCII;
        private static readonly Encoding win1251 = Encoding.GetEncoding(1251);


        private void CreateDocumentClick(object sender, EventArgs e)
        {
            SaveForm saveForm = new SaveForm(filePath);
            if (richTextBox1.Text != "")
            {
                saveForm.ShowDialog();
                if ((saveForm.Status == SaveForm.SaveStatus.Save))
                {

                    try
                    {
                        if (filePath != "")
                        {
                            richTextBox1.SaveFile(filePath);
                        }
                        else
                        {
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                filePath = saveFileDialog1.FileName;
                                richTextBox1.SaveFile(filePath);
                                richTextBox1.Text = "";
                                filePath = "";
                            }

                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Не удалось сохранить");
                    }
                }
                else if(saveForm.Status == SaveForm.SaveStatus.NotSave)
                {
                    richTextBox1.Text = "";
                    filePath = "";
                }
            }
            
            
            
            
            
            


        }
        private void OpenDocumentClick(object sender,EventArgs e)
        {
            SaveForm saveForm = new SaveForm(filePath);
            
            if(richTextBox1.Text != "")
            {
                saveForm.ShowDialog();
                if ((saveForm.Status == SaveForm.SaveStatus.Save))
                {
                    Save(sender, e);
                    ShowOpenDocDial(sender, e);

                }
                else if (saveForm.Status == SaveForm.SaveStatus.NotSave)
                {
                    ShowOpenDocDial(sender, e);
                }
            }
            else
            {
                ShowOpenDocDial(sender, e);
                
            }
            
            
            
        }
        private void ShowOpenDocDial(object sender,EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filePath = openFileDialog1.FileName;
                    richTextBox1.LoadFile(filePath);


                }

                catch (ArgumentException)
                {
                    richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не получилось открыть файл");
                }
                finally
                {

                    Update(sender, e);
                }
            }
        }
        private void SaveAs(object sender,EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filePath = saveFileDialog1.FileName;
                    richTextBox1.SaveFile(filePath);
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось сохранить");
                }
                
            }
            
        }
        private void Save(object sender,EventArgs e)
        {

            try
            {
                if (filePath != "")
                {

                    richTextBox1.SaveFile(filePath);
                }
                else                    
                {
                    if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog1.FileName;
                        richTextBox1.SaveFile(filePath);
                    }
                    
                }
               

            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось сохранить");
            }
            
            
        }
        private void Print(object sender,EventArgs e)
        {
            printDialog1.ShowDialog();
            
        }
        private void ChangeFont(object sender,EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = new Font(fontDialog1.Font, fontDialog1.Font.Style);
            }
        }
        private void Close(object sender,EventArgs e)
        {
            SaveForm saveForm = new SaveForm(filePath);
            saveForm.ShowDialog();

            if ((saveForm.Status == SaveForm.SaveStatus.Save) && richTextBox1.Text != "")
            {
                Save(sender, e);
                Close();
            }
            else if(saveForm.Status == SaveForm.SaveStatus.NotSave)
            {
                Close(); 
            }
            
            
                            
        }
        private void UpView(object sender,EventArgs e)
        {
            
            richTextBox1.ZoomFactor+=2;
        }
        private void DownView(object sender, EventArgs e)
        {
            if (richTextBox1.ZoomFactor >= 2.5)
            {
                richTextBox1.ZoomFactor -= 2;
            }
                     
        }
        private void MakeDefaultView(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor = 1;
        }

        private void ShowInfo(object sender,EventArgs e)
        {
            MessageBox.Show("Программа была создана Никитой Макуриным(университет КФУ,направление Прикладная Математика,отдельное спасибо преподавателям: Дине Латыповой Сергеевне, Екатерине Фадеевой Владимировне, Дмитрию Тумакову Николаевичу");
        }
        private void MakeStripString(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked)
            {
                richTextBox1.WordWrap = false;
                wordWrapToolStripMenuItem.Checked = false;
            }
            else
            {
                richTextBox1.WordWrap = true;
                wordWrapToolStripMenuItem.Checked = true;
            }
        }
        private void ChangeCoddingToUtf(object sender,EventArgs e)
        {
            if (!uTF8ToolStripMenuItem.Checked)
            {
                byte[] sourceBytes = ascii.GetBytes(richTextBox1.Text);
                richTextBox1.Text = utf.GetString(sourceBytes);
                uTF8ToolStripMenuItem.Checked = true;
                aSCIIToolStripMenuItem.Checked = false;
                win1251ToolStripMenuItem.Checked = false;
                toolStripStatusLabel1.Text = "UTF-8";

            }

        }
        private void ChangeCoddingToAscii(object sender, EventArgs e)
        {
            if (!aSCIIToolStripMenuItem.Checked)
            {
                byte[] sourceBytes = utf.GetBytes(richTextBox1.Text);
                richTextBox1.Text = ascii.GetString(sourceBytes);
                uTF8ToolStripMenuItem.Checked = false;
                aSCIIToolStripMenuItem.Checked = true;
                win1251ToolStripMenuItem.Checked = false;
                toolStripStatusLabel1.Text = "ASCII";
            }

        }
        private void ChangeCoddingToWin1251(object sender, EventArgs e)
        {
            if (!win1251ToolStripMenuItem.Checked)
            {
                byte[] sourceBytes = utf.GetBytes(richTextBox1.Text);
                richTextBox1.Text = win1251.GetString(sourceBytes);
                uTF8ToolStripMenuItem.Checked = false;
                aSCIIToolStripMenuItem.Checked = false;
                win1251ToolStripMenuItem.Checked = true;
                toolStripStatusLabel1.Text = "Win-1251";
            }

        }
        private void ChangeToolBar(object sender,EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked)
            {
                statusStrip1.Visible = false;
                richTextBox1.Dock = DockStyle.Fill;
                statusBarToolStripMenuItem.Checked = false;
            }
            else
            {
                statusStrip1.Visible = true;
                richTextBox1.Dock = DockStyle.Fill;                                                            
                statusBarToolStripMenuItem.Checked = true;
            }
        }
        private void ChangeSymbols(object sender,EventArgs e)
        {
            symbols++;
            undoList.Push(richTextBox1.Text);
            isChanged = true;
            Update(sender, e);

        }
        private void LoadForm(object sender,EventArgs e)
        {
            Update(sender, e);

            if (Clipboard.ContainsText())
            {
                pasteToolStripMenuItem.Enabled = true;
            }
        }
        private void Update(object sender, EventArgs e)
        {
            symbols = richTextBox1.Text.Length;
            toolStripStatusLabel2.Text = $"Кол-во символов: {symbols}";
            menuStrip1.BackColor = mainColor;
            
            /*richTextBox1.BackColor = secondColor;
            statusStrip1.BackColor = secondColor;
            menuStrip1.ForeColor = fontColor;
            menuStrip1.BackColor = mainColor;
            statusStrip1.BackColor = secondColor;
            statusStrip1.ForeColor = fontColor;*/
        }
        private void Paste(object sender,EventArgs e)
        {
            richTextBox1.Paste();
            
        }
        private void Copy(object sender,EventArgs e)
        {            
            Clipboard.SetText(richTextBox1.SelectedText);
        }
        /// <summary>
        /// Включение и отключение кнопок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectText(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                copyToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
                findInGoogleToolStripMenuItem.Enabled = true;
            }
            else
            {
                copyToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                findInGoogleToolStripMenuItem.Enabled = false;
            }
            
        }
        private void Cut(object sender,EventArgs e)
        {
            richTextBox1.Cut();
        }
        private void Delete(object sender, EventArgs e)
        {
            
            int StartPosDel = richTextBox1.SelectionStart;
            int LenSelection = richTextBox1.SelectionLength;
            richTextBox1.Text = richTextBox1.Text.Remove(StartPosDel, LenSelection);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveForm saveForm = new SaveForm(filePath);
            saveForm.ShowDialog();

            if ((saveForm.Status == SaveForm.SaveStatus.Save) && richTextBox1.Text != "")
            {
                Save(sender, e);               
                e.Cancel = false;
            }
            else if (saveForm.Status == SaveForm.SaveStatus.NotSave)
            {
                e.Cancel = false;             
            }
            else
            {
                e.Cancel = true;
            }

        }
        private void Cancel(object sender,EventArgs e)
        {
            richTextBox1.Undo();
        }
        private void KeyDownForTextBox(object sender, KeyEventArgs e)
        {                    
            if (e.KeyCode == Keys.Space)
            {
                SuspendLayout();
                richTextBox1.Undo();
                richTextBox1.Redo();
                ResumeLayout();
            }
            
        }
        private void SearchInGoogle(object sender,EventArgs e)
        {
            if (findInGoogleToolStripMenuItem.Enabled)
            {              
                Process.Start($"https://www.google.com/search?q= {richTextBox1.SelectedText}");           
            }
        }
        private void ChangeThemeToDefault(object sender,EventArgs e)
        {
            mainColor =Color.DarkTurquoise;
            secondColor = Color.White;
            fontColor = Color.Black;
            Update(sender, e);
            
        }
        private void ChangeThemeToForest(object sender, EventArgs e)
        {
            mainColor = Color.LightGreen;
            secondColor = Color.White;
            fontColor = Color.Black;
            Update(sender, e);
        }
       
        /* private void ChangeToDarkTheme(object sender,EventArgs e)
        {
            mainColor = Color.Black;
            secondColor = Color.White;
            Update(sender, e);

        }*/

    }
}
