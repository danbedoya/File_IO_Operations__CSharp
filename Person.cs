using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonNameSpace
{
    public abstract class Person
    {
         
            private string lastName;
            private string firstName;
            private int age;
            private int hourlyRate;
            private int hoursWork;

            public Person()//Default Constructor
            {

            }
            //Constructor with four arguments
            public Person(string lname, string fname, int anAge, int hrsRate, int hrsWork)
            {
                
                lastName = lname;
                firstName = fname;
                age = anAge;
                hourlyRate = hrsRate;
                hoursWork = hrsWork;


            }
            //Cosntructor with three arguments
            public Person(string lname, string fname)
            {
                lastName = lname;
                firstName = fname;
            }
           
            public string FirstName
            {
                get
                {
                    return firstName;
                }
            }
            //Property for last name
            public string LastName
            {
                get
                {
                    return lastName;
                }
                set
                {
                    lastName = value;
                }
            }
            public int Age
            {
                get
                {
                    return age;
                }
                set
                {
                    age = value;
                }
            }
            public int HourlyRate
            {
                get
                {
                return hourlyRate;
                }
                set
                {
                hourlyRate = value;
                }
            }
            public int HoursWorked
            {
                get
                {
                return hoursWork;
                }
                set
                {
                hoursWork = value;
                }
            }
            public virtual double Award()
            {
            double grossIncome = 0;
            double bonus = 0;
                if(hoursWork > 40)
            {
                bonus = grossIncome * 0.4;
            }
            return bonus;
            }

     
    }
}
