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
using static System.Console;

namespace CalculateStudentsAverage
{
    public partial class Form1 : Form
    {
        private StreamReader inFile;
        private StreamWriter outFile;
        Student aStudent;
        public Form1()
        
        {
            aStudent = new Student("Bedoya", "Daniel","300319236");
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string inValue;
            string filename = textBoxFileName.Text ;
            

            if (File.Exists(filename))
            {
                try
                {
                    inFile = new StreamReader(filename);

                    while ((inValue = inFile.ReadLine()) != null)
                    {
                        this.listBoxAverage.Items.Add(inValue);
                    }
                }

                catch (System.IO.IOException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }

            else
            {
                MessageBox.Show("File unavailable");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists("300319236.txt"))
            {
                MessageBox.Show("File - {0} already exists!");
            }
            else
            {
                try
                {

                     outFile = new StreamWriter("300319236.txt");
                     outFile.Write(aStudent.StudentRecord);
                    
                }
                catch (IOException exc)
                {
                    WriteLine(exc);
                }
                outFile.Close();

            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            
            StreamReader inputFile;
            string nwline;
            string fileName = textBoxFileName.Text;
            string[] grades;
            string[] studentID;
            string avg;
            string firstListBoxString;
            string secondListBoxString;
            string grade;
            string award;
            string head = "StudentID" + "       " + "average";
            string heading2 = "StudentID" + "    " + "Grade" + "       " + "Award"; 
            
            if (File.Exists(fileName))
            {
                try
                {
                    inputFile = new StreamReader(fileName);
                    listBoxAverage.Items.Clear();
                    listBoxAverage.Items.Add(head);
                    listBoxAwardGrade.Items.Add(heading2);
                    while ((nwline = inputFile.ReadLine()) != null)
                    {
                        grades = nwline.Split(' ');
                        studentID = nwline.Split(' ');
                        for (int i = 1; i < grades.Length - 1; i++)
                        {
                            
                            aStudent.marks.Add((grades[i]));
                        }

                        aStudent.coursesTaken.Add(studentID[0]);
                        
                        //listBoxAverage.Items.Add(studentID[0]);
                        avg = aStudent.CalculateAverage().ToString("F2");
                        firstListBoxString = studentID[0] + "    " + avg;
                        listBoxAverage.Items.Add(firstListBoxString);
                        grade = aStudent.ConvertToGrade();
                        aStudent.gradesLetters.Add(grade);
                        award = aStudent.Award().ToString("F2");
                        aStudent.award.Add(award);
                        secondListBoxString = studentID[0] + "      " + grade + "     " + award;
                        listBoxAwardGrade.Items.Add(secondListBoxString);
                    }


                    
                }
                catch (IOException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                MessageBox.Show("File name doesnt exists");
            }
        }
    }
}
