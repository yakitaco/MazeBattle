namespace mazeBattle {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GoalX = new System.Windows.Forms.NumericUpDown();
            this.GoalY = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.StartY = new System.Windows.Forms.NumericUpDown();
            this.StartX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoalX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoalY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartX)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(730, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // GoalX
            // 
            this.GoalX.Location = new System.Drawing.Point(736, 128);
            this.GoalX.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.GoalX.Name = "GoalX";
            this.GoalX.Size = new System.Drawing.Size(66, 23);
            this.GoalX.TabIndex = 1;
            this.GoalX.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // GoalY
            // 
            this.GoalY.Location = new System.Drawing.Point(736, 157);
            this.GoalY.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.GoalY.Name = "GoalY";
            this.GoalY.Size = new System.Drawing.Size(66, 23);
            this.GoalY.TabIndex = 2;
            this.GoalY.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(727, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartY
            // 
            this.StartY.Location = new System.Drawing.Point(736, 99);
            this.StartY.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.StartY.Name = "StartY";
            this.StartY.Size = new System.Drawing.Size(66, 23);
            this.StartY.TabIndex = 5;
            // 
            // StartX
            // 
            this.StartX.Location = new System.Drawing.Point(736, 70);
            this.StartX.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.StartX.Name = "StartX";
            this.StartX.Size = new System.Drawing.Size(66, 23);
            this.StartX.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(750, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartY);
            this.Controls.Add(this.StartX);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GoalY);
            this.Controls.Add(this.GoalX);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoalX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoalY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private NumericUpDown GoalX;
        private NumericUpDown GoalY;
        private Button button1;
        private NumericUpDown StartY;
        private NumericUpDown StartX;
        private Label label1;
    }
}