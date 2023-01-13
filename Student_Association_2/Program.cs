using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Student_Association_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime Date1, Date2;
            Console.OutputEncoding = Encoding.UTF8;
            StudentsRegister CurStudents = InOutUtils.ReadStudents(@"Students.csv", out Date1);
            StudentsRegister PastStudents = InOutUtils.ReadStudents(@"PastStudents.csv",out Date2);
            StudentsRegister Filtered = new StudentsRegister();
            StudentsRegister Final =
            Filtered.ReturnStudentsWhoLeftAfterFirstYear(CurStudents, PastStudents);
            Console.WriteLine(new string('-', 105));
            Console.WriteLine("Information about who left after first year student: ");
            Console.WriteLine(new string('-', 105));
            InOutUtils.PrintStudents(Final, Date2);
            Console.WriteLine();
            StudentsRegister Oldest =
            Filtered.ReturnAllOldestExMembers(CurStudents, PastStudents);
            Console.WriteLine(new string('-', 105));
            Console.WriteLine("Information about oldest student(-s): ");
            Console.WriteLine(new string('-', 105));
            InOutUtils.PrintStudents(Oldest, Date2);
            Console.WriteLine();
            string filename = "Seniai.csv";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            StudentsRegister Both =
            Filtered.ReturnStudentsWhoStudiedBothYears(CurStudents, PastStudents);
            InOutUtils.PrintToCSVFile(filename, Both);
            Console.WriteLine();
            string filename2 = "Output_Students.txt";
            if (File.Exists(filename2))
            {
                File.Delete(filename2);
            }
            InOutUtils.PrintToTXTFile(filename2, CurStudents, Date1);
            InOutUtils.PrintToTXTFile(filename2, PastStudents, Date2);
            Console.ReadKey();
        }
    }

}
