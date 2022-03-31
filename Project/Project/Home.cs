using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Home : Form
    {
        private Compress compress;
        private Decompress decompress;
        public Home()
        {
            InitializeComponent();
        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            Hide();
            if (compress == null)
            {
                compress = new Compress(this);
                compress.FormClosed += (s, args) => this.Close();
            }
            compress.Show();
            
        }

        private void decompressButton_Click(object sender, EventArgs e)
        {
            Hide();
            if (decompress == null)
            {
                decompress = new Decompress(this);
                decompress.FormClosed += (s, args) => this.Close();
            }
            decompress.Show();
        }
    }
}
