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


namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            filePath = "";
            
            
            uTF8ToolStripMenuItem.Checked = false;
            aSCIIToolStripMenuItem.Checked = false;
            win1251ToolStripMenuItem.Checked = true;
            toolStripStatusLabel1.Text = "Win-1251";

            symbols = richTextBox1.Text.Length;




        }
        private string filePath;        
        private int symbols;
       

        private static readonly Encoding utf = Encoding.UTF8;
        private static readonly Encoding ascii = Encoding.ASCII;
        private static readonly Encoding win1251 = Encoding.GetEncoding(1251);


        private void CreateDocumentClick(object sender, EventArgs e)
        {
            
            Save(sender, e);           
            richTextBox1.Text = "";           
        }
        private void OpenDocumentClick(object sender,EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    richTextBox1.LoadFile(openFileDialog1.FileName);


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
                    Update(sender,e);
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
            if (richTextBox1.Text != "")
            {
                Save(sender, e);
                Close();
            }
            Close();                 
        }
        private void UpView(object sender,EventArgs e)
        {
            Font font = new Font(richTextBox1.Font.Name, richTextBox1.Font.Size+4);
            richTextBox1.Font = font;
        }
        private void DownView(object sender, EventArgs e)
        {
            if (richTextBox1.Font.Size >= 8)
            {
                Font font = new Font(richTextBox1.Font.Name, richTextBox1.Font.Size - 4);
                richTextBox1.Font = font;
            }
        }
        private void MakeDefaultView(object sender, EventArgs e)
        {
                
                Font font = new Font(richTextBox1.Font.Name,DefaultFont.Size);
                richTextBox1.Font = font;
            
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
            Update(sender, e);

        }
        private void LoadForm(object sender,EventArgs e)
        {
            Update(sender, e);
        }
        private void Update(object sender, EventArgs e)
        {
            symbols = richTextBox1.Text.Length;
            toolStripStatusLabel2.Text = $"Кол-во символов: {symbols}";
        }



    }
}
