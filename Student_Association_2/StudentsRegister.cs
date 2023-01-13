using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Student_Association_2
{
    class StudentsRegister
    {
        private List<Students> AllStudents;
        public DateTime date { get; private set; }
        /// <summary>
        /// This is a constructor that creates an emty register for the use of creating new objects of the register./// </summary>
        public StudentsRegister()
        {
            AllStudents = new List<Students>();
        }
        /// <summary>
        /// This is a constructor that creates a data format for the first line of data, which in this case is the date.
        /// </summary>
        /// <param name="date">a variable that that displays the date that's given in the first data line</param>
        public StudentsRegister(DateTime date)
        {
            List<Students> AllStudents = new List<Students>();
            this.date = date;
        }
        /// <summary>
        /// This is a constructor that adds elements to the register from the Students class./// </summary>
        /// <param name="allStudents">a register of the referenced students</param>
        public StudentsRegister(List<Students> allStudents)
        {
            AllStudents = new List<Students>();
            foreach (Students student in allStudents)
            {
                this.AllStudents.Add(student);
            }
        }
        /// <summary>
        /// This is a method that adds elements of the Students class to the register
        /// </summary>
        /// <param name="student">an object of the Students class</param>
        public void Add(Students student)
        {
            this.AllStudents.Add(student);
        }
        /// <summary>
        /// This is a method that displays the amount of students in the register.
        /// </summary>
        /// <returns>the amount of students in the register</returns>
        public int StudentCount()
        {
            return this.AllStudents.Count();
        }
        /// <summary>
        /// This is a method that returns a Students' class value from the register based on the index.
        /// </summary>
        /// <param name="index">an index that displays which element of the register is needed</param>
        /// <returns>Students' class value from the register based on the index</returns>
        public Students ReturnIndexValue(int index)
        {
            return this.AllStudents[index];
        }
        /// <summary>
        /// This method checks if an element of the Students' class is inside the register.
        /// </summary>
        /// <param name="Info">an object of the Students class</param>
        /// <returns>returns either true if it contains the value or false if it doesn't</returns>
        public bool Contains(Students Info)
        {
            return this.AllStudents.Contains(Info);
        }
        /// <summary>
        /// This method checks for students who left student embassy after the first year of university.
        /// </summary>
        /// <param name="FirstRegister">a register of the first data file</param>
        /// <param name="SecondRegister">a register of the second data file</param>
        /// <returns>returns the register of students who left student embassy after the first year of university</returns>
        public StudentsRegister ReturnStudentsWhoLeftAfterFirstYear(StudentsRegister
       FirstRegister, StudentsRegister SecondRegister)
        {
            StudentsRegister filtered = new StudentsRegister();
            for (int i = 0; i < FirstRegister.StudentCount(); i++)
            {
                Students first = FirstRegister.ReturnIndexValue(i);
                for (int j = i; j < SecondRegister.StudentCount(); j++)
                {
                    Students second = SecondRegister.ReturnIndexValue(j);
                    if (!filtered.Contains(second) && second == 1 &&
                    !FirstRegister.Contains(second))
                    {
                        filtered.Add(second);
                    }
                }
            }
            return filtered;
        }
        /// <summary>
        /// This method searches for the first student who left the university.
        /// </summary>
        /// <param name="FirstRegister">a register of the first data file</param>
        /// <param name="SecondRegister">a register of the second data file</param>
        /// <returns>returns the first student who left the university</returns>
        public Students ReturnFirstExStudent(StudentsRegister FirstRegister,
       StudentsRegister SecondRegister)
        {
            Students result = SecondRegister.ReturnIndexValue(0);
            for (int j = 0; j < SecondRegister.StudentCount(); j++)
            {
                Students second = SecondRegister.ReturnIndexValue(j);
                if (!FirstRegister.Contains(second))
                {
                    result = second;
                }
            }
            return result;
        }
        /// <summary>
        /// This method returns the oldest member from the register who has already left the student embassy.
        /// </summary>
        /// <param name="FirstRegister">a register of the first data file</param>
        /// <param name="SecondRegister">a register of the second data file</param>
        /// <returns>returns the oldest member from the register who has already left the student embassy</returns>
        public Students ReturnOldestExMember(StudentsRegister FirstRegister,
       StudentsRegister SecondRegister)
        {
            Students oldest = ReturnFirstExStudent(FirstRegister, SecondRegister);
            for (int i = 0; i < FirstRegister.StudentCount(); i++)
            {
                Students first = FirstRegister.ReturnIndexValue(i);
                for (int j = i; j < SecondRegister.StudentCount(); j++)
                {
                    Students second = SecondRegister.ReturnIndexValue(j);
                    if (!FirstRegister.Contains(second) &&
                   DateTime.Compare(oldest.BirthDate, second.BirthDate) > 0)
                    {
                        oldest = second;
                    }
                }
            }
            return oldest;
        }
        /// <summary>
        /// This method returns all the oldest students, whose age matches with the oldest student's.
        /// </summary>
        /// <param name="FirstRegister">a register of the first data file</param>
        /// <param name="SecondRegister">a register of the second data file</param>
        /// <returns>returns all the oldest students, whose age matches with the oldest student's</returns>
        public StudentsRegister ReturnAllOldestExMembers(StudentsRegister FirstRegister,
       StudentsRegister SecondRegister)
        {
            StudentsRegister AllOldest = new StudentsRegister();
            Students oldest = ReturnOldestExMember(FirstRegister, SecondRegister);
            for (int i = 0; i < FirstRegister.StudentCount(); i++)
            {
                Students first = FirstRegister.ReturnIndexValue(i);
                for (int j = i; j < SecondRegister.StudentCount(); j++)
                {
                    Students second = SecondRegister.ReturnIndexValue(j);
                    if (!AllOldest.Contains(second) && !FirstRegister.Contains(second) &&
                   DateTime.Compare(oldest.BirthDate, second.BirthDate) == 0)
                    {
                        AllOldest.Add(second);
                    }
                }
            }
            return AllOldest;
        }
        /// <summary>
        /// This method returns a register of students whose data is displayed in both the data files.
        /// </summary>
        /// <param name="FirstRegister">a register of the first data file</param>
        /// <param name="SecondRegister">a register of the second data file</param>
        /// <returns>returns a register of students whose data is displayed in both the data files</returns>
        public StudentsRegister ReturnStudentsWhoStudiedBothYears(StudentsRegister
       FirstRegister, StudentsRegister SecondRegister)
        {
            StudentsRegister Found = new StudentsRegister();
            for (int i = 0; i < SecondRegister.StudentCount(); i++)
            {
                Students second = SecondRegister.ReturnIndexValue(i);
                for (int j = i; j < FirstRegister.StudentCount(); j++)
                {
                    Students first = FirstRegister.ReturnIndexValue(j);
                    if (!Found.Contains(first) && SecondRegister.Contains(first))
                    {
                        Found.Add(first);
                    }
                }
            }
            return Found;
        }
    }
}
