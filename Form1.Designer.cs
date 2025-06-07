namespace DisplayOrientation
{
    partial class Form1
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
            this.exitBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.result = new System.Windows.Forms.Label();
            this.portraidradioBtn = new System.Windows.Forms.RadioButton();
            this.landscapeinvertedRadioBtn = new System.Windows.Forms.RadioButton();
            this.portraitinvertedRadioBtn = new System.Windows.Forms.RadioButton();
            this.height_value = new System.Windows.Forms.Label();
            this.landscapeRadioBtn = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.width_value = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(177, 213);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 0;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.result);
            this.groupBox1.Controls.Add(this.portraidradioBtn);
            this.groupBox1.Controls.Add(this.landscapeinvertedRadioBtn);
            this.groupBox1.Controls.Add(this.portraitinvertedRadioBtn);
            this.groupBox1.Controls.Add(this.height_value);
            this.groupBox1.Controls.Add(this.landscapeRadioBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.width_value);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(23, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 165);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orientation, width, height";
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(132, 146);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(27, 16);
            this.result.TabIndex = 7;
            this.result.Text = "----";
            // 
            // portraidradioBtn
            // 
            this.portraidradioBtn.AutoSize = true;
            this.portraidradioBtn.Location = new System.Drawing.Point(11, 130);
            this.portraidradioBtn.Name = "portraidradioBtn";
            this.portraidradioBtn.Size = new System.Drawing.Size(102, 20);
            this.portraidradioBtn.TabIndex = 6;
            this.portraidradioBtn.Text = "270 portrait";
            this.portraidradioBtn.UseVisualStyleBackColor = true;
            this.portraidradioBtn.Click += new System.EventHandler(this.portraidradioBtn_Click);
            // 
            // landscapeinvertedRadioBtn
            // 
            this.landscapeinvertedRadioBtn.AutoSize = true;
            this.landscapeinvertedRadioBtn.Location = new System.Drawing.Point(11, 104);
            this.landscapeinvertedRadioBtn.Name = "landscapeinvertedRadioBtn";
            this.landscapeinvertedRadioBtn.Size = new System.Drawing.Size(186, 20);
            this.landscapeinvertedRadioBtn.TabIndex = 5;
            this.landscapeinvertedRadioBtn.Text = "180 landscape inverted";
            this.landscapeinvertedRadioBtn.UseVisualStyleBackColor = true;
            this.landscapeinvertedRadioBtn.Click += new System.EventHandler(this.landscapeinvertedRadioBtn_Click);
            // 
            // portraitinvertedRadioBtn
            // 
            this.portraitinvertedRadioBtn.AutoSize = true;
            this.portraitinvertedRadioBtn.Location = new System.Drawing.Point(11, 78);
            this.portraitinvertedRadioBtn.Name = "portraitinvertedRadioBtn";
            this.portraitinvertedRadioBtn.Size = new System.Drawing.Size(154, 20);
            this.portraitinvertedRadioBtn.TabIndex = 3;
            this.portraitinvertedRadioBtn.Text = "90 portrait inverted";
            this.portraitinvertedRadioBtn.UseVisualStyleBackColor = true;
            this.portraitinvertedRadioBtn.Click += new System.EventHandler(this.portraitinvertedRadioBtn_Click);
            // 
            // height_value
            // 
            this.height_value.AutoSize = true;
            this.height_value.ForeColor = System.Drawing.Color.Red;
            this.height_value.Location = new System.Drawing.Point(175, 18);
            this.height_value.Name = "height_value";
            this.height_value.Size = new System.Drawing.Size(15, 16);
            this.height_value.TabIndex = 4;
            this.height_value.Text = "0";
            // 
            // landscapeRadioBtn
            // 
            this.landscapeRadioBtn.AutoSize = true;
            this.landscapeRadioBtn.Checked = true;
            this.landscapeRadioBtn.Location = new System.Drawing.Point(11, 52);
            this.landscapeRadioBtn.Name = "landscapeRadioBtn";
            this.landscapeRadioBtn.Size = new System.Drawing.Size(149, 20);
            this.landscapeRadioBtn.TabIndex = 2;
            this.landscapeRadioBtn.TabStop = true;
            this.landscapeRadioBtn.Text = "default landscape";
            this.landscapeRadioBtn.UseVisualStyleBackColor = true;
            this.landscapeRadioBtn.Click += new System.EventHandler(this.landscapeRadioBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "height:";
            // 
            // width_value
            // 
            this.width_value.AutoSize = true;
            this.width_value.ForeColor = System.Drawing.Color.Red;
            this.width_value.Location = new System.Drawing.Point(60, 18);
            this.width_value.Name = "width_value";
            this.width_value.Size = new System.Drawing.Size(15, 16);
            this.width_value.TabIndex = 2;
            this.width_value.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "width:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 254);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exitBtn);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Display Orientation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label width_value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label height_value;
        private System.Windows.Forms.RadioButton landscapeRadioBtn;
        private System.Windows.Forms.RadioButton portraitinvertedRadioBtn;
        private System.Windows.Forms.RadioButton portraidradioBtn;
        private System.Windows.Forms.RadioButton landscapeinvertedRadioBtn;
        private System.Windows.Forms.Label result;
    }
}

