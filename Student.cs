using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonNameSpace;
using System.Collections;
using System.Windows.Forms;


namespace CalculateStudentsAverage
{
    public class Student:Person
    {
        private string lastName;
        private string firstName;
        public ArrayList coursesTaken;
        public ArrayList marks;
        public ArrayList gradesLetters;
        public ArrayList award;
        private string  studentId;

        public Student():
            base()
        {

        }
        public Student(string lN, string fN, string  sID):
            base(lN, fN)

        {
            lastName = lN;
            firstName = fN;
            coursesTaken = new ArrayList();
            marks = new ArrayList();
            gradesLetters = new ArrayList();
            award = new ArrayList();
            studentId = sID;
        }
        public string  SID
        {
            get
            {
                return studentId;
            }
            set
            {
                studentId = value;
            }
        }
      
        public override double Award()
        {
            double scholarShip;

            if (CalculateAverage() > 85)
                scholarShip = 1000;
            else
            {
                scholarShip = 0;
            }
            return scholarShip;
        }
        public double CalculateAverage()

        {
            double result = 0;
            double avg;
            string tempString;
            double temp;
            if(marks.Count < 1)
            {
                return 0;
            }
            else
            {
                for(int i = 0; i < marks.Count; i++)
                {
                    tempString = (string)marks[i];
                    if(double.TryParse(tempString, out temp) == false)
                    {
                        MessageBox.Show("Input is not correct: ");
                    }
                    else
                    {
                        result = result + temp;
                    }
                }
            }
            avg = result / marks.Count;
            return avg;
        }
        public string ConvertToGrade()
        {
            string grade;
            double avg = CalculateAverage();
            if((avg <= 100.00) && (avg >= 95.00))
            {
                grade = "A+";
            }
            else if((avg < 95.00) && (avg >= 90.00))
            {
                grade = "A";
            }
            else if((avg < 90.00) && (avg >= 85.00))
            {
                grade = "A-";
            }
            else if((avg < 85.00) && (avg >= 80.00))
            {
                grade = "B+";
            }
            else if((avg < 80.00) && (avg >= 75.00))
            {
                grade = "B";
            }
            else if((avg < 75.00) && (avg >= 70.00))
            {
                grade = "B-";
            }
            else if((avg < 70.00) && (avg >= 65.00))
            {
                grade = "C+";
            }
            else if((avg < 65.00) && (avg >= 60.00))
            {
                grade = "C";
            }
            else if((avg < 60.00) && (avg >=55.00))
            {
                grade = "C-";
            }
            else if((avg < 55.00) && (avg >= 50.00))
            {
                grade = "P";
            }
            else
            {
                grade = "F";
            }
            return grade;

        }
        public string StudentRecord
        {
            get
            {
                string rec = "StudentID" + "      " + "Grade" + "      " + "Award" + "\n";
               
                for (int i = 0; i < 6; i++)
                {
                    rec = rec + coursesTaken[i] + "      " + gradesLetters[i] + "      " + award[i] + "\n";
                }
                
                return rec;
            }
        }
        

    }
}
