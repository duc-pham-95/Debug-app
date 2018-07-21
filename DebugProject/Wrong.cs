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
    public partial class Wrong : Form
    {
        private string[] WrongAnswers;
        public Wrong(string[] WrongAnswers)
        {
            InitializeComponent();
            this.WrongAnswers = WrongAnswers;
            InitWrongInfo();
        }
        private void InitWrongInfo()
        {
            lbShowResult.Text = "Wrong Answer";
            lbShowTest.Text = WrongAnswers[2];
        }

        private void btnOpenYour_Click(object sender, EventArgs e)
        {
            Model.Commands.OpenFile(WrongAnswers[0]);
        }

        private void btnOpenCorrect_Click(object sender, EventArgs e)
        {
            Model.Commands.OpenFile(WrongAnswers[1]);
        }

        private void btnAllOut_Click(object sender, EventArgs e)
        {
            Model.Commands.OpenFolder(Model.Directories.GetOutDir());
        }

        private void btnOpenInput_Click(object sender, EventArgs e)
        {
            Model.Commands.OpenFile(WrongAnswers[3]);
        }
    }
}
