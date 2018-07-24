using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugProject
{
    public partial class TestData : Form
    {
        public TestData()
        {
            InitializeComponent();
            init();
           
        }
        private void init()
        {
            txtOutput.Enabled = false;
            txtInput.Enabled = false;
            if(Model.Directories.InputDir != null)
            {
                txtInput.Text = Model.Directories.InputDir;
            }
            if (Model.Directories.TestOutputDir != null)
            {
                txtOutput.Text = Model.Directories.TestOutputDir;
            }
        }
        private void btnInput_Click(object sender, EventArgs e)
        {
            GetIOExample(true);
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            GetIOExample(false);
        }
        public void GetIOExample(Boolean I)
        {
            FolderBrowserDialog FolderChooser = new FolderBrowserDialog();
            if (FolderChooser.ShowDialog() == DialogResult.OK)
            {
                string path = FolderChooser.SelectedPath;
                if (path.Length > 0)
                {

                    if (Model.Directories.isDirEmpty(path) == false)
                    {
                        if (I)
                        {
                            txtInput.Text = path;
                        }
                        else
                        {
                            txtOutput.Text = path;
                        }
                        FolderChooser.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("the folder is empty ! no data found !");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtInput.Text == "" )
            {
                MessageBox.Show("Input folder not found !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(txtOutput.Text == "")
            {
                MessageBox.Show("Output folder not found !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Model.Directories.TestOutputDir = txtOutput.Text;
                Model.Directories.InputDir = txtInput.Text;
                Dispose();
            }
        }
    }
}
