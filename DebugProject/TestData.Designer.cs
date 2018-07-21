namespace DebugProject
{
    partial class TestData
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lbInput = new System.Windows.Forms.Label();
            this.btnInput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lbOutput = new System.Windows.Forms.Label();
            this.btnOutput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtInput.Enabled = false;
            this.txtInput.Location = new System.Drawing.Point(142, 44);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(282, 24);
            this.txtInput.TabIndex = 9;
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Location = new System.Drawing.Point(24, 47);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(71, 17);
            this.lbInput.TabIndex = 11;
            this.lbInput.Text = "Test Input";
            // 
            // btnInput
            // 
            this.btnInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInput.Location = new System.Drawing.Point(430, 44);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(72, 24);
            this.btnInput.TabIndex = 10;
            this.btnInput.Text = "<<";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtOutput.Enabled = false;
            this.txtOutput.Location = new System.Drawing.Point(142, 110);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(282, 24);
            this.txtOutput.TabIndex = 12;
            // 
            // lbOutput
            // 
            this.lbOutput.AutoSize = true;
            this.lbOutput.Location = new System.Drawing.Point(24, 113);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(83, 17);
            this.lbOutput.TabIndex = 14;
            this.lbOutput.Text = "Test Output";
            // 
            // btnOutput
            // 
            this.btnOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutput.Location = new System.Drawing.Point(430, 110);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(72, 24);
            this.btnOutput.TabIndex = 13;
            this.btnOutput.Text = "<<";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // TestData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 182);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lbInput);
            this.Controls.Add(this.btnInput);
            this.Name = "TestData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TestData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.Button btnOutput;
    }
}