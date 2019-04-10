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
            

            //// If directory does not exist, create it. 
            //if (!Directory.Exists(target))
            //{
            //    Directory.CreateDirectory(target);
            //}
            
            //Get directories
            string[] files = Directory.GetFiles(source);

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
                    string destFile = Path.Combine(source, newFileName);
                    File.Copy(sourceFile, destFile, true);
                }
            }
        }
    }
}
