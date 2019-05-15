namespace FourInRow
{
    partial class StartForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.blackText = new System.Windows.Forms.TextBox();
            this.redText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Black\'s name:";
            // 
            // blackText
            // 
            this.blackText.Location = new System.Drawing.Point(296, 99);
            this.blackText.Name = "blackText";
            this.blackText.Size = new System.Drawing.Size(356, 44);
            this.blackText.TabIndex = 1;
            this.blackText.Text = "Black";
            // 
            // redText
            // 
            this.redText.Location = new System.Drawing.Point(1068, 99);
            this.redText.Name = "redText";
            this.redText.Size = new System.Drawing.Size(356, 44);
            this.redText.TabIndex = 3;
            this.redText.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(846, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reds\'s name:";
            // 
            // startB
            // 
            this.startB.Location = new System.Drawing.Point(581, 299);
            this.startB.Name = "startB";
            this.startB.Size = new System.Drawing.Size(391, 177);
            this.startB.TabIndex = 4;
            this.startB.Text = "Start!";
            this.startB.UseVisualStyleBackColor = true;
            this.startB.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1086, 619);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(351, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "Created by R&&U© 2019";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1612, 699);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startB);
            this.Controls.Add(this.redText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.blackText);
            this.Controls.Add(this.label1);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox blackText;
        private System.Windows.Forms.TextBox redText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button startB;
        private System.Windows.Forms.Label label3;
    }
}