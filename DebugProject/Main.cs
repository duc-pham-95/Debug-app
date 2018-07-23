using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugProject
{
    public partial class Main : Form
    {
        private string Error;
        public Main()
        {
            InitializeComponent();
            Model.Directories.CreateAll();//tao tat ca folder can thiet
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            ResetInfomation();
            Model.Directories.ClearAll(); //clear all files in Base folders
            if(isSourceCodeExisted() && isInputPathExisted() && isTestOutputPathExisted())
            {
                DisableBtn();
                TransformToFileCode(GetRawSourceCode());//convert text to java file
                backgroundWorker.RunWorkerAsync();// run
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                lbState.Text = "Compiling...";
            });
            Error = Model.Commands.ProcessCompileJava(); //compile
            if(Error.Length > 0)//neu loi trong qua trinh compile
            {
                Invoke((MethodInvoker)delegate
                {
                    lbMessage.Text = Model.Messages.GetErrorType(Error);//xac dinh loi gi
                    InitButtonSeeDetailError(); //the hien loi chi tiet
                });     
            }
            else
            {
                //string[] InputFilePaths = Model.Files.GetInputFilePaths(Model.Directories.InputDir);// tap hop paths cua tung file input dau vao
                //string[] OutputFilePaths = Model.Files.GetOutputFilePaths(Model.Directories.InputDir);//tap hop paths cua tung file output dau ra    
                string[] Commands = Model.Files.GetRunJavaCommands(Model.Directories.InputDir);        
                int i = 1;
                foreach (string command in Commands)
                {
                    //string FileInputContent = Model.Files.GetFileContentText(InputFilePath);// lay noi dung cua 1 file input
                    Invoke((MethodInvoker)delegate
                    {
                        lbState.Text = "Running Test " + i+"...";
                    });
                    //Model.Result result = Model.Commands.ProcessRunJava(FileInputContent);//run 
                    Model.Result result = Model.Commands.ProcessRunJava(command);
                    if (result.Error != "")
                    {
                        Error = result.Error;
                        Invoke((MethodInvoker)delegate
                        {
                            lbMessage.Text = Model.Messages.GetErrorType(result.Error);
                            InitButtonSeeDetailError();
                        });
                        break;
                    }
                    //File.WriteAllText(OutputFilePaths[i - 1], result.Output); //ghi ket qua xuong tung file output
                    i++;
                }
                          
            }
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(Error.Equals(""))
            {
                lbMessage.Text = "Successful";
                string[] wrongAnswers = Model.Compare.Diff(Model.Directories.GetOutDir(), Model.Directories.TestOutputDir);   
                if(wrongAnswers != null)
                {
                    Wrong wrong = new Wrong(wrongAnswers);
                    wrong.ShowDialog();
                }
                else
                {
                    Passed pass = new Passed();
                    pass.ShowDialog();
                }
            }
            EnableBtn();
            lbState.Text = "Completed";
        }   
        private void TransformToFileCode(string[] text)
        {
            Model.Files.WriteTextToFile(Model.Files.GetJavaFilePath(), text);
        }
        private string[] GetRawSourceCode()
        {
            int n = txtRawSourceCode.Lines.Length;
            string[] text = new string[n];
            for (int i = 0; i < n; i++)
            {
                text[i] = txtRawSourceCode.Lines[i];
            }
            return text;
        }
        private void InitButtonSeeDetailError()
        {
            Button btnSeeDetail = new Button();
            btnSeeDetail.Click += SeeDetailError;
            btnSeeDetail.Location = new Point(17, 80);
            btnSeeDetail.Size = new System.Drawing.Size(130, 25);
            btnSeeDetail.TabIndex = 13;
            btnSeeDetail.Text = "See detail error >>";
            btnSeeDetail.UseVisualStyleBackColor = true;
            grbxRunningInfo.Controls.Add(btnSeeDetail);  
        }

        private void SeeDetailError(object sender, EventArgs e)
        {
            ErrorForm er = new ErrorForm(Error);
            er.ShowDialog(); 
        }
        private void ResetInfomation()
        {
            Error = "";
            lbMessage.Text = "";
            lbState.Text = "";
        }
        private Boolean isSourceCodeExisted()
        {
            if (txtRawSourceCode.Lines.Length == 0)
            {
                MessageBox.Show("Source code is empty, please insert !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private Boolean isInputPathExisted()
        {
            if (Model.Directories.InputDir == null)
            {
                MessageBox.Show("Test Input folders must be given before running code !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private Boolean isTestOutputPathExisted()
        {
            if (Model.Directories.TestOutputDir == null)
            {
                MessageBox.Show("Test Output folders must be given before running code !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestData test = new TestData();
            test.ShowDialog();
        }

        private void btnInstruction_Click(object sender, EventArgs e)
        {
            Instruction instruction = new Instruction();
            instruction.ShowDialog();
        }
        public void DisableBtn()
        {
            btnSetting.Enabled = false;
            btnStart.Enabled = false;
            btnTest.Enabled = false;
        }
        public void EnableBtn()
        {
            btnSetting.Enabled = true;
            btnStart.Enabled = true;
            btnTest.Enabled = true;
        }
    }
}
