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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.label1 = new System.Windows.Forms.Label();
            this.BlackText = new System.Windows.Forms.TextBox();
            this.RedText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.switchB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Black\'s name:";
            // 
            // BlackText
            // 
            this.BlackText.Location = new System.Drawing.Point(93, 35);
            this.BlackText.Margin = new System.Windows.Forms.Padding(1);
            this.BlackText.Name = "BlackText";
            this.BlackText.Size = new System.Drawing.Size(115, 20);
            this.BlackText.TabIndex = 1;
            this.BlackText.Click += new System.EventHandler(this.TextBox_Click);
            this.BlackText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.BlackText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyUp);
            this.BlackText.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // RedText
            // 
            this.RedText.Location = new System.Drawing.Point(337, 35);
            this.RedText.Margin = new System.Windows.Forms.Padding(1);
            this.RedText.Name = "RedText";
            this.RedText.Size = new System.Drawing.Size(115, 20);
            this.RedText.TabIndex = 3;
            this.RedText.Click += new System.EventHandler(this.TextBox_Click);
            this.RedText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.RedText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyUp);
            this.RedText.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Reds\'s name:";
            // 
            // startB
            // 
            this.startB.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.startB.Location = new System.Drawing.Point(183, 105);
            this.startB.Margin = new System.Windows.Forms.Padding(1);
            this.startB.Name = "startB";
            this.startB.Size = new System.Drawing.Size(123, 62);
            this.startB.TabIndex = 4;
            this.startB.Text = "Start!";
            this.startB.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 217);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Created by R&&U© 2019";
            // 
            // switchB
            // 
            this.switchB.Location = new System.Drawing.Point(212, 33);
            this.switchB.Name = "switchB";
            this.switchB.Size = new System.Drawing.Size(51, 23);
            this.switchB.TabIndex = 2;
            this.switchB.Text = "<->";
            this.switchB.UseVisualStyleBackColor = true;
            this.switchB.Click += new System.EventHandler(this.SwitchB_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 246);
            this.Controls.Add(this.switchB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startB);
            this.Controls.Add(this.RedText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BlackText);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.Text = "Start";
            this.Click += new System.EventHandler(this.StartForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BlackText;
        private System.Windows.Forms.TextBox RedText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button startB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button switchB;
    }
}