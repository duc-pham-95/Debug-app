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
        private static string InputFolder;
        private static string OutputFolder;
        public Main()
        {
            InitializeComponent();
            DisableText();
            Model.Directories.CreateAll();//tao tat ca folder can thiet
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            ResetInfomation();
            Model.Directories.ClearAll(); //clear all files in Base folders
            if(isSourceCodeExisted() && isInputPathExisted())
            {
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
                string[] InputFilePaths = Model.Files.GetInputFilePaths(InputFolder);// tap hop paths cua tung file input dau vao
                string[] OutputFilePaths = Model.Files.GetOutputFilePaths(InputFolder);//tap hop paths cua tung file output dau ra            
                int i = 1;
                foreach (string InputFilePath in InputFilePaths)
                {
                    string[] FileInputContent = Model.Files.GetFileContent(InputFilePath);// lay noi dung cua 1 file input
                    Invoke((MethodInvoker)delegate
                    {
                        lbState.Text = "Running Test " + i+"...";
                    });
                    Model.Result result = Model.Commands.ProcessRunJava(FileInputContent);//run 
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
                    File.WriteAllText(OutputFilePaths[i - 1], result.Output); //ghi ket qua xuong tung file output
                    i++;
                }
                          
            }
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(Error.Equals(""))
            {
                lbMessage.Text = "Successful";
                OpenOutputFolder();
            }
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
            btnSeeDetail.Location = new System.Drawing.Point(620, 230);
            btnSeeDetail.Size = new System.Drawing.Size(134, 33);
            btnSeeDetail.TabIndex = 13;
            btnSeeDetail.Text = "See detail error >>";
            btnSeeDetail.UseVisualStyleBackColor = true;
            this.Controls.Add(btnSeeDetail);      
        }

        private void SeeDetailError(object sender, EventArgs e)
        {
            ErrorForm er = new ErrorForm(Error);
            er.ShowDialog(); 
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            GetIOExample(true); //true stands for getting Input
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            GetIOExample(false); //false stands for getting Output
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
                        if(I)
                        {
                            txtInput.Text = path;
                            InputFolder = path;
                        }
                        else
                        {
                            txtOutput.Text = path;
                            OutputFolder = path;
                        }                      
                        FolderChooser.Dispose();
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
        }
        private void OpenOutputFolder()
        {
            Model.Commands.OpenFolder(Model.Directories.GetOutDir());
        }
        private void DisableText()
        {
            txtInput.Enabled = false;
            txtOutput.Enabled = false;
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
            if (txtInput.Text == "")
            {
                MessageBox.Show("Input folders must be given before running code !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }
    }
}
