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

namespace WindowsFormsAppHW2_1
{
    public partial class Form2 : Form
    {
        Form1 parentForm = null;

        public Form2()
        {
            InitializeComponent();
        }

        public void Show(Form1 parent)
        {
            parentForm = parent;
            base.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.opened -= 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> vs = new List<string>();
            try
            {
                string[] filePaths = Directory.GetFiles(textBox1.Text, textBox2.Text);
                foreach (var item in filePaths)
                {
                    vs.Add(Path.GetFileName(item));
                }
            }
            catch (Exception)
            {
                vs.Clear();
                vs.Add("Error");
            }
            if(vs.Count == 0)
            {
                vs.Add("No items");
            }
            parentForm.listBox1.Items.Clear();
            foreach (var item in vs)
            {
                parentForm.listBox1.Items.Add(item);
            }
        }
    }
}
