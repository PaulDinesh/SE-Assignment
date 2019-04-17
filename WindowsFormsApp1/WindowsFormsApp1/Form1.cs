﻿using System;
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
        string[] targetfolder = { "Please Select a file", "Please Select a file", "Please Select a file" };
        private void button1_Click(object sender, EventArgs e)
        {
            //Folder Browser Dialog Box
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            string source = fbd.SelectedPath;
            string target = @"\sortedFiles";
            //Formatting the target folder name
            target = string.Format("{0}{1}", source, target);
            i = i + 1;
            targetfolder[i] = target;
            // If directory does not exist, create it. 
            if (!Directory.Exists(target))
            {
                Directory.CreateDirectory(target);
            }

            string str, destFile = "";
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', ';' };
            string[] List;
            int j;

            //Get all files in directories
            string[] files = Directory.GetFiles(source);
            foreach (string file in files)
            {//extracts the extension
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
                    
                    StreamReader sr = new StreamReader(file);
                    StreamWriter sw = new StreamWriter(destFile);
                    str = sr.ReadToEnd();
                    //Spliting of line into words
                    List = str.Split(delimiterChars);
                    
                    //Sorting of the array
                    Array.Sort(List);
                    //No. of occurence
                    for (int i = 0; i < List.Length; i = j)
                    {
                        string num = List[i];
                        int counter = 1;
                        for (j = i + 1; j < List.Length; j++)
                        {
                            if (List[j] != num)
                                break;
                            else
                                counter++;
                        }
                        if (counter == 1)
                        {
                            sw.WriteLine(num);
                        }
                        else
                        {
                            sw.WriteLine("{0},{1} ", num, counter);
                        }
                    }

                    sr.Close();
                    sw.Close();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            for (int j = 0; j < targetfolder.Length; j++)
            {
                if (targetfolder[j] != "Please Select a file")
                {
                    //Add target folder to the listbox1
                    listBox1.Items.Add(targetfolder[j].ToString());
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            
            for (int j = 0; j < targetfolder.Length; j++)
            {
                if (targetfolder[j] != "Please Select a file")
                {
                    string[] files = Directory.GetFiles(targetfolder[j]);
                    //Adding sorted files to the listbox
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

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e){}

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
             f2.ShowDialog();*/
            string source = @"C:\Users\paul dinesh\Desktop\Calculator";

            //Folder Browser Dialog Box
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Please select a directory";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                source = fbd.SelectedPath;
                MessageBox.Show(source);


                //Get directories
                string[] files = Directory.GetFiles(source);

                string answerfile = DateTime.Now.ToString("HH.mm.ss dddd, dd-MMMM-yyyy ");
                answerfile = string.Format("{0}\\{1}.answ", source, answerfile);

                string str = " ";
                string[] List = { "" };
                decimal result = 1;
                using (StreamWriter sw = File.CreateText(answerfile))
                {
                    sw.WriteLine("---------------------------------------");
                    sw.WriteLine("            AnswerFile");
                }
                foreach (string file in files)
                {
                    string ext = Path.GetExtension(file);
                    //Checks for .calc file
                    if (ext == ".calc")
                    {

                        StreamReader sr = new StreamReader(file);
                        string Cname = Path.GetFileName(file);
                        //     answerfile = string.Format("{0}-{1}",Cname,answerfile);

                        // StreamWriter sw = new StreamWriter(answerfile);
                        using (StreamWriter sw = new StreamWriter(answerfile, true))
                        {
                            sw.WriteLine("---------------------------------------");
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
                                            result = Convert.ToDecimal(List[j]) + Convert.ToDecimal(List[k]);
                                            //Console.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], result[0]);
                                            sw.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], Math.Round(result, 2));
                                            break;
                                        case "-":
                                            j = i - 1;
                                            k = i + 1;
                                            result = Convert.ToDecimal(List[j]) - Convert.ToDecimal(List[k]);
                                            //Console.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], result[0]);
                                            sw.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], Math.Round(result, 2));
                                            break;
                                        case "*":
                                            j = i - 1;
                                            k = i + 1;
                                            result = Convert.ToDecimal(List[j]) * Convert.ToDecimal(List[k]);
                                            // Console.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], result);
                                            sw.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], Math.Round(result, 2));
                                            break;
                                        case "/":
                                            j = i - 1;
                                            k = i + 1;
                                            result = Convert.ToDecimal(List[j]) / Convert.ToDecimal(List[k]);
                                            //Console.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], result);
                                            sw.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], Math.Round(result, 2));
                                            break;
                                        case "%":
                                            j = i - 1;
                                            k = i + 1;
                                            result = Convert.ToDecimal(List[j]) % Convert.ToDecimal(List[k]);
                                            //  Console.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], result);
                                            sw.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], Math.Round(result, 2));
                                            break;
                                        case "^":
                                            j = i - 1;
                                            k = i + 1;
                                            double resul = Math.Pow(Convert.ToDouble(List[j]), Convert.ToDouble(List[k]));
                                            // Console.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], resul);
                                            sw.WriteLine("{0}{1}{2}={3}", List[j], List[i], List[k], Math.Round(resul, 2));
                                            break;

                                    }

                                }
                            }

                            sr.Close();
                            sw.Close();
                        }
                    }
                }
                MessageBox.Show("Calculations are Completed");

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}