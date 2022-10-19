using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public Classroom(int capacity)
        {
            Capacity = capacity;
            Students = new List<Student>();
        }

        public int Capacity { get; set; }
        public List<Student> Students { get; set; }
        public int Count { get { return Students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (Capacity>Students.Count)
            { 
                Students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (Students.FirstOrDefault(x=>x.FirstName == firstName && x.LastName == lastName) !=null)
            {
                Students.Remove(Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName));
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsWithTheSubject =  Students.Where(x => x.Subject == subject).ToList();
            StringBuilder sb = new StringBuilder();

            if (studentsWithTheSubject.Count>0)
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");

                foreach (Student student in studentsWithTheSubject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

               return sb.ToString().TrimEnd();
            }         
            
                return "No students enrolled for the subject";                          
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
