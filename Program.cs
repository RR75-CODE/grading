using grading;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Lab4_grading
{
    class Program
    {
        
        const string StudentsFile = "students.txt";
        const string CoursesFile = "courses.txt";

        static void Main(string[] args)
        {
            try
            {
                var students = LoadStudents(StudentsFile);
                LoadCourses(CoursesFile, students);

                Console.WriteLine("Champlain College - Grading Report");
                Console.WriteLine("Generated: " + DateTime.Now);
                Console.WriteLine(new string('=', 60));

                foreach (var s in students.Values)
                {
                    s.DisplayInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static Dictionary<int, ChamplainStudent> LoadStudents(string path)
        {
            var dict = new Dictionary<int, ChamplainStudent>();

            foreach (var line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(',');
                if (parts.Length < 7) continue;

                int id = int.Parse(parts[0].Trim());
                string name = parts[1].Trim();
                int age = int.Parse(parts[2].Trim());
                DateTime dob = DateTime.Parse(parts[3].Trim(), CultureInfo.InvariantCulture);
                string gender = parts[4].Trim();
                int yearReg = int.Parse(parts[5].Trim());
                double z = double.Parse(parts[6].Trim(), CultureInfo.InvariantCulture);

                var student = new ChamplainStudent(id, name, age, dob, gender, yearReg, z);
                dict[id] = student;
            }

            return dict;
        }

        static void LoadCourses(string path, Dictionary<int, ChamplainStudent> students)
        {
            foreach (var line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(',');
                if (parts.Length < 6) continue;

                int id = int.Parse(parts[0].Trim());
                string courseId = parts[1].Trim();
                string courseName = parts[2].Trim();
                double score = double.Parse(parts[3].Trim(), CultureInfo.InvariantCulture);
                string groupId = parts[4].Trim();
                double irg = double.Parse(parts[5].Trim(), CultureInfo.InvariantCulture);

                if (!students.ContainsKey(id))
                {
                    Console.WriteLine($"Course for unknown student {id} skipped.");
                    continue;
                }

                var cr = new ChamplainStudent.CourseResult
                {
                    CourseId = courseId,
                    CourseName = courseName,
                    Score = score,
                    GroupId = groupId,
                    IRG = irg
                };

                students[id].AddCourse(cr);
            }
        }
    }
}
