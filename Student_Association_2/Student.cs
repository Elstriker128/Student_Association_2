using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Association_2
{
    public class Students
    {
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string StudentID { get; private set; }
        public int Course { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Status { get; private set; }
        public int Age { get; private set; }
        public Students(string surname, string name, DateTime birthdate, string studentid,
       int course, string phonenumber, string status)
        {
            this.Surname = surname;
            this.Name = name;
            this.BirthDate = birthdate;
            this.StudentID = studentid;
            this.Course = course;
            this.PhoneNumber = phonenumber;
            this.Status = status;
        }
        /// <summary>
        /// This method finds the students age.
        /// </summary>
        /// <returns>returns the students age</returns>
        public int FindAge()
        {
            return Age = (Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) -
           Convert.ToInt32(BirthDate.ToString("yyyyMMdd"))) / 10000;
        }
        /// <summary>
        /// This is a modified version of the Equals method.
        /// </summary>
        /// <param name="obj">an object for the Equals method</param>
        /// <returns>returns a modified version of the Equals method</returns>
        public override bool Equals(object obj)
        {
            return obj is Students students &&
            StudentID == students.StudentID;
        }
        /// <summary>
        /// This is a modified version of the GetHashCode method.
        /// </summary>
        /// <returns>returns a modified version of the GetHashCode method</returns>
        public override int GetHashCode()
        {
            return -284491835 + EqualityComparer<string>.Default.GetHashCode(StudentID);
        }
        /// <summary>
        /// This method returns a modified version of the ToString method.
        /// </summary>
        /// <returns>returns a modified version of the ToString method</returns>
        public override string ToString()
        {
            string info;
            info = string.Format("| {0,-15} | {1,-15} | {2,-10:yyyy-MM-dd} | {3,-15} | { 4,-6} | { 5,-15} | { 6,-7} | ", Surname, Name, BirthDate,
        StudentID, Course, PhoneNumber, Status);
            return info;
        }
        /// <summary>
        /// This method displays the overlay of operator ==
        /// </summary>
        /// <param name="student">an object of the Students' class</param>
        /// <param name="i">a numberic value</param>
        /// <returns>either true or false depending if the equality is real</returns>
        public static bool operator ==(Students student, int i)
        {
            return student.Course == i;
        }
        /// <summary>
        /// This method displays the overlay of operator !=
        /// </summary>
        /// <param name="student">an object of the Students' class</param>
        /// <param name="i">a numberic value</param>
        /// <returns>either true or false depending if the inequality is real</returns>
        public static bool operator !=(Students student, int i)
        {
            return student.Course != i;
        }
    }
}
