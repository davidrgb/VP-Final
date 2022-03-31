using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Decompress : Form
    {

        private Home home;
        private List<Node> nodes;
        private int remainderBits;
        private int totalCharacters;

        private string filePath;
        public Decompress(Home home)
        {
            this.home = home;
            InitializeComponent();
        }

        public void decompress()
        {
            //StreamWriter outputFile = File.CreateText(outputTextBox.Text);

            byte[] input = File.ReadAllBytes(filePath);
            string decompressedString = "";
            string tree = "";
            byte newlineByte = (byte)'\n';

            int i = 0;
            byte current = (byte)(char)0;
            while ((current = input[i]) != newlineByte)
            {
                char character = (char)current;
                tree += character;
                i++;
            }
            i++;

            Node head = readTree(tree);
            string byteString = "";

            i++;

            int bitPosition = 0;
            string currentBut = "";
            while (i < input.Length)
            {
                current = input[i++];
                int currentInt = (int)current;
                if (currentInt == 0)
                {
                    if (input[i++] == 1) byteString += "10000000";
                    else byteString += "00000000";
                    continue;
                }
                bool negative = false;
                if (currentInt < 0)
                {
                    negative = true;
                    currentInt *= -1;
                }
                string temp = "";
                int quotient = currentInt;
                int remainder = 0;
                do
                {
                    remainder = quotient % 2;
                    quotient = quotient / 2;
                    if (remainder == 1) temp = '1' + temp;
                    else temp = '0' + temp;
                }
                while (quotient != 0);
                while (temp.Length < 7)
                {
                    temp = '0' + temp;
                }
                if (negative) byteString += '1';
                else byteString += '0';
                byteString += temp;
            }

            while (byteString.Length > 0 && totalCharacters > 0)
            {
                string temp = "";
                char decompressedCharacter = (char)0;
                temp = head.find(byteString);
                decompressedString += temp[0];
                if (temp.Length - 1 + remainderBits == byteString.Length && byteString.Length <= 8) byteString = "";
                else if (temp.Length > 1)
                {
                    byteString = temp.Substring(1);
                }
                totalCharacters--;
            }

            decompressedTextBox.Text = decompressedString;
        }

        public Node readTree(string data)
        {
            Node head = null;
            nodes = new List<Node>();
            string code = "";
            char character = (char)0;
            int frequency = 0;
            int decode_step = 0;
            int i = 0;
            bool cont = true;

            while (cont)
            {
                if (data[i] == '_')
                {
                    i++;
                    cont = false;
                    int.TryParse(data.Substring(i), out remainderBits);
                    continue;
                }
                switch (decode_step)
                {
                    case 0:
                        int indexDot = data.IndexOf('.');
                        code = data.Substring(i, indexDot);
                        i = indexDot;
                        decode_step++;
                        break;
                    case 1:
                        character = data[i];
                        if (character == '/' && data[i + 1] == 'n')
                        {
                            character = '\n';
                            i++;
                        }
                        decode_step++;
                        break;
                    case 2:
                        int indexScore = data.IndexOf('_');
                        int.TryParse(data.Substring(i, indexScore - i), out frequency);
                        Node node = new Node(frequency, character, null, null);
                        node.code = code + "";
                        nodes.Add(node);
                        totalCharacters += frequency;
                        decode_step = 0;
                        data = data.Substring(indexScore + 1);
                        i = -1;
                        break;
                }
                i++;
            }

            nodes.Sort((x, y) => x.frequency.CompareTo(y.frequency));

            List<Node> copy = new List<Node>();
            for (int n = 0; n < nodes.Count; n++)
            {
                copy.Insert(n, nodes.ElementAt(n));
            }

            while (copy.Count > 1)
            {
                Node nodeA = copy.ElementAt(0);
                copy.RemoveAt(0);
                Node nodeB = copy.ElementAt(0);
                copy.RemoveAt(0);
                Node empty = new Node(nodeA.frequency + nodeB.frequency, (char)0, nodeA, nodeB);
                empty.code = nodeA.code.Substring(0, nodeA.code.Length - 1);
                copy.Insert(0, empty);
                List<Node> sorted = copy.OrderBy(x => x.frequency)
                                        .ThenBy(x => x.code)
                                        .ToList();
                copy = sorted;
                head = empty;
            }

            return head;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Hide();
            home.Show();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
        }

        private void decompressButton_Click(object sender, EventArgs e)
        {
            decompress();
        }
    }
}
