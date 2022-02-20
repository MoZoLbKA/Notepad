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
            isChanged = false;



        }
        private string filePath;
        private bool isChanged;

        private void CreateDocumentClick(object sender, EventArgs e)
        {
            
            Save(sender, e);           
            textBox1.Text = "";           
        }
        private void OpenDocumentClick(object sender,EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using(StreamReader reader = new StreamReader(openFileDialog1.FileName))
                    {
                        textBox1.Text = reader.ReadToEnd();
                        reader.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось открыть файл");
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
                    File.WriteAllText(filePath,textBox1.Text);
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
                    
                    File.WriteAllText(filePath, textBox1.Text);
                }
                else                    
                {
                    if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog1.FileName;
                        File.WriteAllText(filePath, textBox1.Text);
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
                textBox1.Font = fontDialog1.Font;
            }
        }
        private void Close(object sender,EventArgs e)
        {
            if (textBox1.Text != "")
            {

            }
            
            
        }

        
    }
}
