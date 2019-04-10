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
    public partial class Listing_of_Directories_and_files : Form
    {
        public Listing_of_Directories_and_files()
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
                str = sr.ReadLine();
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
                    {
                        Console.WriteLine(num);
                        sw.WriteLine(num);
                    }
                    else
                    {
                        Console.WriteLine("{0},{1} ", num, c);
                        sw.WriteLine("{0},{1} ", num, c);
                    }
                }

                sr.Close();
                sw.Close();
            }

            //Console.WriteLine(File.ReadAllText(@"C:\Users\paul dinesh\Desktop\Data\Sort\sorted.txt"));

        }
    }
}
