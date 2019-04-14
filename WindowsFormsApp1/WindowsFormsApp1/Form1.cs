using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        int i = -1;
        string[] a = { "Please Select a file", "Please Select a file", "Please Select a file" };
        private void button1_Click(object sender, EventArgs e)
        {
            //Folder Browser Dialog Box
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            i = i + 1;
            string source = fbd.SelectedPath;
            Console.WriteLine(a[i]);
            string target = @"\sortedFiles";
            target = string.Format("{0}{1}", source, target);
            a[i] = target;
            // If directory does not exist, create it. 
            if (!Directory.Exists(target))
            {
                Directory.CreateDirectory(target);
            }
            string str, destFile = "";
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', ';' };
            string[] List;
            int j;

            //Get directories
            string[] files = Directory.GetFiles(source);
            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);
                //Checks for text file
                if (ext == ".txt")
                {
                    //Assign the file name of that instance
                    string name = Path.GetFileName(file);
                    string newFileName = "sorted";
                    //Asigning new name 
                    newFileName = string.Format("{0}{1}", newFileName, name);

                    //File copy 
                    string sourceFile = Path.Combine(source, name);
                    destFile = Path.Combine(target, newFileName);
                    File.Copy(sourceFile, destFile, true);
                }
                StreamReader sr = new StreamReader(file);
                StreamWriter sw = new StreamWriter(destFile);
                str = sr.ReadToEnd();
                //Spliting of line into w   ords
                List = str.Split(delimiterChars);
                // }
                //Sorting of the array
                Array.Sort(List);
                //No. of occurence
                for (int i = 0; i < List.Length; i = j)
                {
                    string num = List[i];
                    int c = 1;
                    for (j = i + 1; j < List.Length; j++)
                    {
                        if (List[j] != num)
                            break;
                        else
                            c++;
                    }
                    if (c == 1)
                    {
                        // Console.WriteLine(num);
                        sw.WriteLine(num);
                    }
                    else
                    {
                        //Console.WriteLine("{0},{1} ", num, c);
                        sw.WriteLine("{0},{1} ", num, c);
                    }
                }

                sr.Close();
                sw.Close();
            }

            




        }

        private void button2_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            for (int j = 0; j < a.Length; j++)
            {
                if (a[j] != "Please Select a file")
                {

                    listBox1.Items.Add(a[j].ToString());
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

            for (int j = 0; j < a.Length; j++)
            {
                if (a[j] != "Please Select a file")
                {
                    string[] files = Directory.GetFiles(a[j]);
                    foreach (string file2 in files)
                    {
                        string name2 = Path.GetFileName(file2);
                        listBox3.Items.Add(name2.ToString());
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Folder = listBox1.SelectedItem.ToString();
            string[] Files1 = Directory.GetFiles(Folder);
            listBox2.Items.Clear();
            foreach (string file in Files1)
            {
                string name1 = Path.GetFileName(file);
                listBox2.Items.Add(name1.ToString());
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*
            string search = textBox1.Text;
            for (int j = 0; j < a.Length; j++)
            {
                string searchfile = Path.GetFileName(a[j]);
                string[] linesArr = File.ReadAllLines(searchfile);
                foreach (string s in linesArr)
                {
                    if (s.Contains(search))
                    {
                        listBox4.Items.Add(s.ToString());
                    }
                }
            }
*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /* Calculator f2 = new Calculator();
             f2.ShowDialog();*///Folder Browser Dialog Box
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            string source = fbd.SelectedPath;
            //Get directories
            string[] files = Directory.GetFiles(source);
            //var numbers = new List<string>();
            string str = " ";
            string[] List = { "" };
            decimal[] result = { 1 };
            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);
                //Checks for text file
                if (ext == ".calc")
                {

                    StreamReader sr = new StreamReader(file);
                    while (sr.Peek() > 0)
                    {
                        str = sr.ReadLine();
                        List = str.Split(' ');

                        for (int i = 0; i < List.Length; i++)
                        {
                            int j, k;
                            switch (List[i])
                            {
                                case "+":
                                    j = i - 1;
                                    k = i + 1;
                                    //  Console.WriteLine(Convert.ToDecimal(List[j]));
                                    result[0] = Convert.ToDecimal(List[j]) + Convert.ToDecimal(List[k]);
                                    Console.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], result[0]);
                                    break;
                                case "-":
                                    j = i - 1;
                                    k = i + 1;
                                    //  Console.WriteLine(Convert.ToDecimal(List[j]));
                                    result[0] = Convert.ToDecimal(List[j]) - Convert.ToDecimal(List[k]);
                                    Console.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], result[0]);
                                    break;
                                case "*":
                                    j = i - 1;
                                    k = i + 1;
                                    //  Console.WriteLine(Convert.ToDecimal(List[j]));
                                    result[0] = Convert.ToDecimal(List[j]) * Convert.ToDecimal(List[k]);
                                    Console.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], result[0]);
                                    break;
                                case "/":
                                    j = i - 1;
                                    k = i + 1;
                                    //  Console.WriteLine(Convert.ToDecimal(List[j]));
                                    result[0] = Convert.ToDecimal(List[j]) / Convert.ToDecimal(List[k]);
                                    Console.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], result[0]);
                                    break;
                                case "%":
                                    j = i - 1;
                                    k = i + 1;
                                    //  Console.WriteLine(Convert.ToDecimal(List[j]));
                                    result[0] = Convert.ToDecimal(List[j]) % Convert.ToDecimal(List[k]);
                                    Console.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], result[0]);
                                    break;
                                case "^":
                                    j = i - 1;
                                    k = i + 1;
                                    //  Console.WriteLine(Convert.ToDecimal(List[j]));
                                    double resul = Math.Pow(Convert.ToDouble(List[j]), Convert.ToDouble(List[k]));
                                    Console.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], resul);
                                    break;

                            }

                        }
                    }
                }
            }

        }
    }
}
