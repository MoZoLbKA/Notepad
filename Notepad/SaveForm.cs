using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class SaveForm : Form
    {
        public enum SaveStatus
        {
            Empty,
            Save,
            NotSave,
            Cancel
        }
        public SaveForm()
        {
            InitializeComponent();
            Status = SaveStatus.Empty;
            
        }
        public SaveForm(string filePath)
        {
            InitializeComponent();
            textBox1.Text =  $"Сохранить файл {filePath}?";
        }
        public SaveStatus Status { get; private set; }
        DialogResult result;

        private void Save(object sender,EventArgs e)
        {
            Status = SaveStatus.Save;
            Close();
            

        }
        private void NotSave(object sender, EventArgs e)
        {
            Status = SaveStatus.NotSave;
            Close();

        }
        private void Cansel(object sender, EventArgs e)
        {
            Status = SaveStatus.Cancel;
            Close();
        }


    }
}
