
namespace Project
{
    partial class Decompress
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
            this.outputLabel = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.decompressButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.inputLabel = new System.Windows.Forms.Label();
            this.decompressedTextBox = new System.Windows.Forms.TextBox();
            this.TItle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outputLabel
            // 
            this.outputLabel.Location = new System.Drawing.Point(275, 325);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(252, 17);
            this.outputLabel.TabIndex = 16;
            this.outputLabel.Text = "Output Filename";
            this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(275, 345);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(252, 29);
            this.outputTextBox.TabIndex = 15;
            this.outputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // decompressButton
            // 
            this.decompressButton.Location = new System.Drawing.Point(332, 381);
            this.decompressButton.Name = "decompressButton";
            this.decompressButton.Size = new System.Drawing.Size(140, 27);
            this.decompressButton.TabIndex = 14;
            this.decompressButton.Text = "Decompress";
            this.decompressButton.UseVisualStyleBackColor = true;
            this.decompressButton.Click += new System.EventHandler(this.decompressButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(634, 381);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(140, 27);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(31, 381);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(140, 27);
            this.loadButton.TabIndex = 12;
            this.loadButton.Text = "Load Input File";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Location = new System.Drawing.Point(28, 101);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(134, 17);
            this.inputLabel.TabIndex = 11;
            this.inputLabel.Text = "Decompressed Text";
            // 
            // decompressedTextBox
            // 
            this.decompressedTextBox.Location = new System.Drawing.Point(20, 121);
            this.decompressedTextBox.Multiline = true;
            this.decompressedTextBox.Name = "decompressedTextBox";
            this.decompressedTextBox.Size = new System.Drawing.Size(768, 193);
            this.decompressedTextBox.TabIndex = 10;
            // 
            // TItle
            // 
            this.TItle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TItle.Location = new System.Drawing.Point(12, 9);
            this.TItle.Name = "TItle";
            this.TItle.Size = new System.Drawing.Size(776, 55);
            this.TItle.TabIndex = 9;
            this.TItle.Text = "Decompress";
            this.TItle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Decompress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.decompressButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.decompressedTextBox);
            this.Controls.Add(this.TItle);
            this.Name = "Decompress";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button decompressButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.TextBox decompressedTextBox;
        private System.Windows.Forms.Label TItle;
    }
}