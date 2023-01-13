using Microsoft.Win32;
using Student_Association_2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Student_Association_2
{
    class InOutUtils
    {
        /// <summary>
        /// This method reads all the input data from a file.
        /// </summary>
        /// <param name="filename">a filename from which the data is read</param>
        /// <param name="date">a variable that that displays the date that's given in the first data line</param>
        /// <returns>returns a register of all the read data</returns>
        public static StudentsRegister ReadStudents(string filename, out DateTime date)
        {
            StudentsRegister register = new StudentsRegister();
            date = DateTime.Now;
            string[] Lines = File.ReadAllLines(filename, Encoding.UTF8);
            if (new FileInfo(filename).Length == 0)
            {
                Console.WriteLine("Error: no data input");
            }
            else
            {
                date = DateTime.Parse(Lines[0]);
                foreach (string Line in Lines.Skip(1))
                {
                    string[] Values = Line.Split(',');
                    string surname = Values[0];
                    string name = Values[1];
                    DateTime birthdate = DateTime.Parse(Values[2]);
                    string studentid = Values[3];
                    int course = int.Parse(Values[4]);
                    string phonenumber = Values[5];
                    string status = Values[6];
                    Students student = new Students(surname, name, birthdate, studentid,
                   course, phonenumber, status);
                    if (!register.Contains(student))
                    {
                        register.Add(student);
                    }
                }
            }
            return register;
        }
        /// <summary>
        /// This method prints all the necessary information about the students from the register.
        /// </summary>
        /// <param name="AllStudents">a register of the referenced students</param>
        /// <param name="Date">a variable that that displays the date that's given in the first data line</param>
        /// <returns>returns a register of all the read data onto the console</returns>
        public static void PrintStudents(StudentsRegister AllStudents, DateTime date)
        {
            if (AllStudents.StudentCount() > 0)
            {
                Console.WriteLine(new string('-', 105));

                Console.WriteLine("Date");
                Console.WriteLine(new string('-', 105));
                Console.WriteLine("{0}", date.Year);
                Console.WriteLine(new string('-', 105));
                Console.WriteLine();
                Console.WriteLine(new string('-', 105));
                Console.WriteLine("| {0,-15} | {1,-15} | {2,-10:yyyy-MM-dd} | {3,-15} | { 4,-2} | { 5,-15} | { 6,-7} | ", "Surname", "Name", "BirthDate",
            "StudentID", "Course", "PhoneNumber", "Status");
                Console.WriteLine(new string('-', 105));
                for (int i = 0; i < AllStudents.StudentCount(); i++)
                {
                    Students info = AllStudents.ReturnIndexValue(i);
                    Console.WriteLine(info.ToString());
                }
                Console.WriteLine(new string('-', 105));
            }
            else
            {
                Console.WriteLine("No output data:");
            }
        }
        /// <summary>
        /// This method prints all the required data from a register onto a CSV file.
        /// The distribution between cells in the CSV file depends on the simbol the system uses.
        /// My system uses the ',' simbol but other systems may use the ';' simbol.
        /// </summary>
        /// <param name="filename">a filename from which the data is printed</param>
        /// <param name="Found">a register of the referenced students</param>
        /// <returns>returns a register of all the read data onto the CSV file</returns>
        public static void PrintToCSVFile(string filename, StudentsRegister Found)
        {
            if (Found.StudentCount() > 0)
            {
                string[] lines = new string[Found.StudentCount() + 1];
                lines[0] = String.Format(" {0,-15} ; {1,-15} ; {2,-10:yyyy-MM-dd} ; {3,-15} ; { 4,-6} ; { 5,-15} ; { 6,-7}", "Surname", "Name", "BirthDate", "StudentID", "Course", "PhoneNumber", "Status");
                for (int i = 0; i < Found.StudentCount(); i++)
                {
                    Students item = Found.ReturnIndexValue(i);
                    lines[i + 1] = item.ToString();
                }
                File.WriteAllLines(filename, lines, Encoding.UTF8);
            }
            else
            {
                Console.WriteLine(new string('-', 105));
                Console.WriteLine("Error: no students who studied both years!");
                Console.WriteLine(new string('-', 105));
            }
        }
        /// <summary>
        /// This method prints all the primary data onto a .txt file.
        /// </summary>
        /// <param name="filename">a filename from which the data is printed</param>
        /// <param name="All">a register of the referenced students</param>
        /// <returns>returns a register of all the read data onto the .txt file</returns>
        public static void PrintToTXTFile(string filename, StudentsRegister All, DateTime date)
        {
            if (All.StudentCount() > 0)
            {
                string[] lines = new string[All.StudentCount() + 4];
                lines[0] = String.Format(" {0,-5}", date.Year);
                lines[1] = String.Format(" {0,-15} {1,-15} {2,-10:yyyy-MM-dd} {3,-15} {4,-6} { 5,-15} { 6,-7}", "Surname", "Name", "BirthDate", "StudentID", "Course", "PhoneNumber", "Status");
                for (int i = 0; i < All.StudentCount(); i++)
                {
                    Students item = All.ReturnIndexValue(i);
                    lines[i + 2] = String.Format(" {0,-15} {1,-15} {2,-10:yyyy-MM-dd} { 3,-15} { 4,-6} { 5,-15} { 6,-7}", item.Surname, item.Name, item.BirthDate,
                 item.StudentID, item.Course, item.PhoneNumber, item.Status);
                }
                File.AppendAllLines(filename, lines, Encoding.UTF8);
            }
            else
            {
                Console.WriteLine(new string('-', 105));
                Console.WriteLine("Error: no students in the input");
                Console.WriteLine(new string('-', 105));
            }
        }
    }

}
