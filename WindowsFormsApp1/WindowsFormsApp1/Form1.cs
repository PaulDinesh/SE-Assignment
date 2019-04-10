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

        private void button1_Click(object sender, EventArgs e)
        {
            //Folder Browser Dialog Box
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            string source = fbd.SelectedPath;
            string target = @"\sortedFiles";
            target = string.Format("{0}{1}", source, target);

            // If directory does not exist, create it. 
            if (!Directory.Exists(target))
            {
                Directory.CreateDirectory(target);
            }

            //Get directories
            string[] files = Directory.GetFiles(source);
            string str;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', ';' };
            string[] List;
            int j;

            // string path = @"C:\Users\paul dinesh\Desktop\Data\data.txt";
            StreamWriter sw = new StreamWriter(@"C:\Users\paul dinesh\Desktop\Data\Sort\sorted.txt");

            foreach (string file in files)
            {
                StreamReader sr = new StreamReader(file);

                //for (int i = 0; i < 2; i++)
                // {
                str = sr.ReadLine();
                //     Console.WriteLine(Regex.Match(str, @"\d+.+\d").Value);
                //     Console.WriteLine( "--------------");

                //Spliting of line into words
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
                        //Console.WriteLine(num);
                        sw.WriteLine(num);
                    else
                        //Console.WriteLine("{0},{1} ", num, c);
                        sw.WriteLine("{0},{1} ", num, c);



                }

                sr.Close();



            }
            sw.Close();
            Console.WriteLine(File.ReadAllText(@"C:\Users\paul dinesh\Desktop\Data\Sort\sorted.txt"));
            // FileInfo f1 = new FileInfo(source);

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
                    string destFile = Path.Combine(target, newFileName);
                    File.Copy(sourceFile, destFile, true);
                }
            }

        }
    }
}
