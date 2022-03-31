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
    public partial class Compress : Form
    {

        private Home home;

        private List<Node> nodes;

        private int remainderBits;
        private int totalCharacters;
        public Compress(Home home)
        {
            this.home = home;
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Hide();
            home.Show();
        }

        private void compress()
        {
            string data = inputTextBox.Text;
            Node head = createTree(data);
            head.traverse("");

            string tree = returnTree(head);

            string compressedData = "";

            StreamWriter outputFile = File.CreateText(outputTextBox.Text);
            outputFile.Close();

            int i = 0;
            while (i < data.Length)
            {
                char current = data[i];
                for (int n = 0; n < nodes.Count; n++)
                {
                    if (nodes.ElementAt(n).character == current) 
                    {
                        compressedData += nodes.ElementAt(n).code;
                        n = nodes.Count;
                    }
                }
                i++;
            }

            /*int totalBytes = (int)Math.Ceiling(compressedData.Length / 8m);
            byte[] compressedBytes = new byte[totalBytes];
            int chunk = 8;

            for (int j = 1; j <= totalBytes; j++)
            {
                int start = compressedData.Length - 8 * j;
                if (start < 0)
                {
                    chunk = 8 + start;
                    start = 0;
                }
                compressedBytes[totalBytes - 1] = Convert.ToByte(compressedData.Substring(start, chunk), 2);
            }*/

            List<byte> bytes = new List<byte>();

            /*for (int j = 0; j < compressedBytes.Length; j++)
            {
                bytes.Add(compressedBytes[j]);
            }*/

            byte bit = 0;
            bool negative = false;
            i = 0;
            int remainingBits = 0;

            while (i < compressedData.Length) {
                if (i % 8 == 0 && i > 0)
                {
                    /*if (negative)
                    {
                        int offset = 128 - bit;
                        int flippedBit = bit + offset * 2;
                        bit = (byte)flippedBit;
                    }*/
                    bytes.Add(bit);
                    if (bit == 0) bytes.Add(negative ? (byte)1 : (byte)0);
                    if (compressedData.Length - i >= 8) bit = 0;
                    else
                    {
                        remainingBits = compressedData.Length - i;
                        i = compressedData.Length;
                        continue;
                    }
                }
                int bitPosition = 8 - (i % 8);
                int currentBit = compressedData[i] == '1' ? (int)Math.Pow(2, 8 - (i % 8) - 1) + bit : 0 + bit;

                //int currentBit = (int)Math.Pow(2, 8 - (i % 8) - 1) * (int)(compressedData[i]) + bit;
                //if (bitPosition == 8) negative = currentBit == 128;
                //else bit = (byte)currentBit;
                bit = (byte)currentBit;
                i++;
            }
            tree += remainingBits;
            i = 0;
            bit = 0;
            while (remainingBits > 0)
            {
                int bitPosition = 8 - (i % 8);
                //int currentBit = (int)Math.Pow(2, 8 - (i % 8) - 1) * (int)(compressedData[compressedData.Length - remainingBits]) + bit;
                int currentBit = compressedData[compressedData.Length - remainingBits] == '1' ? (int)Math.Pow(2, 8 - (i % 8) - 1) + bit : 0 + bit;
                //if (bitPosition == 8) negative = currentBit == 128;
                //else bit = (byte)currentBit;
                bit = (byte)currentBit;
                remainingBits--;
                i++;
                if (remainingBits == 0)
                {
                    /*if (negative)
                    {
                        int offset = 128 - bit;
                        int flippedBit = bit + offset * 2;
                        bit = (byte)flippedBit;
                    }*/
                    bytes.Add(bit);
                    //if (bit == 0) bytes.Add(negative ? (byte)1 : (byte)0);
                }
            }

            List<byte> bytesToPrint = new List<byte>();

            byte[] treeBytes = Encoding.ASCII.GetBytes(tree);
            for (int t = 0; t < tree.Length; t++)
            {
                bytesToPrint.Add(treeBytes[t]);
            }

            byte[] newlineBytes = Encoding.ASCII.GetBytes("\n\n");
            for (int l = 0; l < "\n\n".Length; l++)
            {
                bytesToPrint.Add(newlineBytes[l]);
            }

            for (int b = 0; b < bytes.Count; b++)
            {
                bytesToPrint.Add(bytes[b]);
            }

            byte[] byteArray = new byte[bytesToPrint.Count];
            for (int b = 0; b < bytesToPrint.Count; b++)
            {
                byteArray[b] = bytesToPrint[b];
            }

            File.WriteAllBytes(outputTextBox.Text, byteArray);
        }

        private Node createTree (string data)
        {
            Node head = null;
            nodes = new List<Node>();
            while (data.Length > 0)
            {
                char current = data[0];
                for (int n = 0; n <= nodes.Count; n++)
                {
                    if (n == nodes.Count)
                    {
                        nodes.Add(new Node(1, current, null, null));
                        n++;
                    }
                    else
                    {
                        Node currentNode = nodes.ElementAt(n);
                        if (currentNode.character == current)
                        {
                            currentNode.frequency++;
                            n = nodes.Count;
                            continue;
                        }
                    }
                }
                if (data.Length > 1) data = data.Substring(1);
                else data = "";
            }

            nodes.Sort((x, y) => x.frequency.CompareTo(y.frequency));

            List<Node> copy = new List<Node>();
            for (int i = 0; i < nodes.Count; i++)
            {
                copy.Insert(i, nodes.ElementAt(i));
            }

            while (copy.Count > 1)
            {
                Node nodeA = copy.ElementAt(0);
                copy.RemoveAt(0);
                Node nodeB = copy.ElementAt(0);
                copy.RemoveAt(0);
                Node empty = new Node(nodeA.frequency + nodeB.frequency, (char)0, nodeA, nodeB);
                copy.Add(empty);
                copy.Sort((x, y) => x.frequency.CompareTo(y.frequency));
                head = empty;
            }

            return head;
        }

        public string returnTree(Node head)
        {
            String tree = "";
            foreach (Node n in nodes)
            {
                head.find(n);
                String character = n.character + "";
                if (n.character == '\n') character = "/n";
                tree += n.code + "." + character + n.frequency + "_";
            }
            return tree + "_";
        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            compress();
        }
    }

    public class Node
    {
        public Node left;
        public Node right;
        public char character;
        public int frequency;
        public string code;

        public Node(int frequency, char character, Node left, Node right)
        {
            this.frequency = frequency;
            this.character = character;
            this.left = left;
            this.right = right;
            code = "";
        }

        public void traverse(string code)
        {
            this.code = code;
            if (left != null) left.traverse(code + "0");
            if (right != null) right.traverse(code + "1");
        }

        public string find(string code)
        {
            if (character != (char)0) return character + code;
            else if (code[0] == '0') return left.find(code = code.Substring(1));
            else return right.find(code = code.Substring(1));
        }

        public void find(Node n)
        {
            if (left != null && left.character > (char)0 && n.character == left.character)
            {
                n.code = left.code;
                return;
            }
            if (right != null && right.character > (char)0 && n.character == right.character)
            {
                n.code = right.code;
                return;
            }
            if (left != null) left.find(n);
            if (right != null) right.find(n);
        }
    }
}
