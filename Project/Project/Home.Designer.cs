
namespace Project
{
    partial class Home
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
            this.TItle = new System.Windows.Forms.Label();
            this.compressButton = new System.Windows.Forms.Button();
            this.decompressButton = new System.Windows.Forms.Button();
            this.treeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TItle
            // 
            this.TItle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TItle.Location = new System.Drawing.Point(12, 9);
            this.TItle.Name = "TItle";
            this.TItle.Size = new System.Drawing.Size(776, 55);
            this.TItle.TabIndex = 0;
            this.TItle.Text = "Huffman Coder";
            this.TItle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(343, 181);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(121, 35);
            this.compressButton.TabIndex = 1;
            this.compressButton.Text = "Compress";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // decompressButton
            // 
            this.decompressButton.Location = new System.Drawing.Point(343, 222);
            this.decompressButton.Name = "decompressButton";
            this.decompressButton.Size = new System.Drawing.Size(121, 35);
            this.decompressButton.TabIndex = 2;
            this.decompressButton.Text = "Decompress";
            this.decompressButton.UseVisualStyleBackColor = true;
            this.decompressButton.Click += new System.EventHandler(this.decompressButton_Click);
            // 
            // treeButton
            // 
            this.treeButton.Location = new System.Drawing.Point(343, 263);
            this.treeButton.Name = "treeButton";
            this.treeButton.Size = new System.Drawing.Size(121, 35);
            this.treeButton.TabIndex = 3;
            this.treeButton.Text = "View Tree";
            this.treeButton.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeButton);
            this.Controls.Add(this.decompressButton);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.TItle);
            this.Name = "Home";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TItle;
        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.Button decompressButton;
        private System.Windows.Forms.Button treeButton;
    }
}

