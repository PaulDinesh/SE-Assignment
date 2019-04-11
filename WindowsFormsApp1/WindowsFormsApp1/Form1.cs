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
            //Get Files stores the path of all files in the selected path
            //C:\Users\paul dinesh\Desktop\Data\data.txt
            //C:\Users\paul dinesh\Desktop\Data\asdf.txt
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
         //   Listing_of_Directories_and_files f2 = new Listing_of_Directories_and_files();
           // f2.ShowDialog();
        }
    }
}
