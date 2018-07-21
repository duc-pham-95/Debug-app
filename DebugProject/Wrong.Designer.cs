﻿namespace DebugProject
{
    partial class Wrong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbxInfo = new System.Windows.Forms.GroupBox();
            this.lbShowTest = new System.Windows.Forms.Label();
            this.lbShowResult = new System.Windows.Forms.Label();
            this.lbTest = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.lbCorrectOut = new System.Windows.Forms.Label();
            this.lbYourOut = new System.Windows.Forms.Label();
            this.lbInput = new System.Windows.Forms.Label();
            this.grbxWrongData = new System.Windows.Forms.GroupBox();
            this.btnOpenCorrect = new System.Windows.Forms.Button();
            this.btnOpenYour = new System.Windows.Forms.Button();
            this.btnOpenInput = new System.Windows.Forms.Button();
            this.btnAllOut = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grbxInfo.SuspendLayout();
            this.grbxWrongData.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbxInfo
            // 
            this.grbxInfo.Controls.Add(this.lbShowTest);
            this.grbxInfo.Controls.Add(this.lbShowResult);
            this.grbxInfo.Controls.Add(this.lbTest);
            this.grbxInfo.Controls.Add(this.lbResult);
            this.grbxInfo.Location = new System.Drawing.Point(12, 12);
            this.grbxInfo.Name = "grbxInfo";
            this.grbxInfo.Size = new System.Drawing.Size(334, 120);
            this.grbxInfo.TabIndex = 0;
            this.grbxInfo.TabStop = false;
            this.grbxInfo.Text = "Information";
            // 
            // lbShowTest
            // 
            this.lbShowTest.AutoSize = true;
            this.lbShowTest.Location = new System.Drawing.Point(148, 71);
            this.lbShowTest.Name = "lbShowTest";
            this.lbShowTest.Size = new System.Drawing.Size(0, 17);
            this.lbShowTest.TabIndex = 3;
            // 
            // lbShowResult
            // 
            this.lbShowResult.AutoSize = true;
            this.lbShowResult.Location = new System.Drawing.Point(148, 35);
            this.lbShowResult.Name = "lbShowResult";
            this.lbShowResult.Size = new System.Drawing.Size(0, 17);
            this.lbShowResult.TabIndex = 2;
            // 
            // lbTest
            // 
            this.lbTest.AutoSize = true;
            this.lbTest.Location = new System.Drawing.Point(37, 71);
            this.lbTest.Name = "lbTest";
            this.lbTest.Size = new System.Drawing.Size(44, 17);
            this.lbTest.TabIndex = 1;
            this.lbTest.Text = "Test :";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(37, 35);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(56, 17);
            this.lbResult.TabIndex = 0;
            this.lbResult.Text = "Result :";
            // 
            // lbCorrectOut
            // 
            this.lbCorrectOut.AutoSize = true;
            this.lbCorrectOut.Location = new System.Drawing.Point(37, 145);
            this.lbCorrectOut.Name = "lbCorrectOut";
            this.lbCorrectOut.Size = new System.Drawing.Size(101, 17);
            this.lbCorrectOut.TabIndex = 2;
            this.lbCorrectOut.Text = "Correct Output";
            // 
            // lbYourOut
            // 
            this.lbYourOut.AutoSize = true;
            this.lbYourOut.Location = new System.Drawing.Point(37, 89);
            this.lbYourOut.Name = "lbYourOut";
            this.lbYourOut.Size = new System.Drawing.Size(89, 17);
            this.lbYourOut.TabIndex = 3;
            this.lbYourOut.Text = "Your Output ";
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Location = new System.Drawing.Point(37, 34);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(39, 17);
            this.lbInput.TabIndex = 4;
            this.lbInput.Text = "Input";
            // 
            // grbxWrongData
            // 
            this.grbxWrongData.Controls.Add(this.btnOpenCorrect);
            this.grbxWrongData.Controls.Add(this.btnOpenYour);
            this.grbxWrongData.Controls.Add(this.btnOpenInput);
            this.grbxWrongData.Controls.Add(this.lbInput);
            this.grbxWrongData.Controls.Add(this.lbYourOut);
            this.grbxWrongData.Controls.Add(this.lbCorrectOut);
            this.grbxWrongData.Location = new System.Drawing.Point(12, 149);
            this.grbxWrongData.Name = "grbxWrongData";
            this.grbxWrongData.Size = new System.Drawing.Size(334, 195);
            this.grbxWrongData.TabIndex = 1;
            this.grbxWrongData.TabStop = false;
            this.grbxWrongData.Text = "Wrong Data";
            // 
            // btnOpenCorrect
            // 
            this.btnOpenCorrect.Location = new System.Drawing.Point(183, 142);
            this.btnOpenCorrect.Name = "btnOpenCorrect";
            this.btnOpenCorrect.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCorrect.TabIndex = 7;
            this.btnOpenCorrect.Text = "Open";
            this.btnOpenCorrect.UseVisualStyleBackColor = true;
            this.btnOpenCorrect.Click += new System.EventHandler(this.btnOpenCorrect_Click);
            // 
            // btnOpenYour
            // 
            this.btnOpenYour.Location = new System.Drawing.Point(183, 86);
            this.btnOpenYour.Name = "btnOpenYour";
            this.btnOpenYour.Size = new System.Drawing.Size(75, 23);
            this.btnOpenYour.TabIndex = 6;
            this.btnOpenYour.Text = "Open";
            this.btnOpenYour.UseVisualStyleBackColor = true;
            this.btnOpenYour.Click += new System.EventHandler(this.btnOpenYour_Click);
            // 
            // btnOpenInput
            // 
            this.btnOpenInput.Location = new System.Drawing.Point(183, 31);
            this.btnOpenInput.Name = "btnOpenInput";
            this.btnOpenInput.Size = new System.Drawing.Size(75, 23);
            this.btnOpenInput.TabIndex = 5;
            this.btnOpenInput.Text = "Open";
            this.btnOpenInput.UseVisualStyleBackColor = true;
            this.btnOpenInput.Click += new System.EventHandler(this.btnOpenInput_Click);
            // 
            // btnAllOut
            // 
            this.btnAllOut.Location = new System.Drawing.Point(12, 362);
            this.btnAllOut.Name = "btnAllOut";
            this.btnAllOut.Size = new System.Drawing.Size(334, 43);
            this.btnAllOut.TabIndex = 2;
            this.btnAllOut.Text = ">>  See All Your Output Here  <<";
            this.btnAllOut.UseVisualStyleBackColor = true;
            this.btnAllOut.Click += new System.EventHandler(this.btnAllOut_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(366, 62);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(371, 343);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(754, 62);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(371, 343);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Your Answer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(751, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Correct Answer";
            // 
            // Wrong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 421);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnAllOut);
            this.Controls.Add(this.grbxWrongData);
            this.Controls.Add(this.grbxInfo);
            this.Name = "Wrong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wrong";
            this.grbxInfo.ResumeLayout(false);
            this.grbxInfo.PerformLayout();
            this.grbxWrongData.ResumeLayout(false);
            this.grbxWrongData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbxInfo;
        private System.Windows.Forms.Label lbTest;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Label lbCorrectOut;
        private System.Windows.Forms.Label lbYourOut;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.GroupBox grbxWrongData;
        private System.Windows.Forms.Button btnOpenCorrect;
        private System.Windows.Forms.Button btnOpenYour;
        private System.Windows.Forms.Button btnOpenInput;
        private System.Windows.Forms.Button btnAllOut;
        private System.Windows.Forms.Label lbShowTest;
        private System.Windows.Forms.Label lbShowResult;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}