using grading;
using System;

namespace grading
{

    public partial class ChamplainStudent : Person, IGrading
    {
        public int StudentId { get; private set; }
        public int YearOfRegister { get; private set; }
        public double ZScore { get; private set; }

        public class CourseResult
        {
            public string CourseId { get; set; } = string.Empty;
            public string CourseName { get; set; } = string.Empty;
            public double Score { get; set; }
            public string GroupId { get; set; } = string.Empty;
            public double IRG { get; set; }

            public override string ToString()
            {
                return $"{CourseId} - {CourseName}: Score={Score}, Group={GroupId}, IRG={IRG}";
            }
        }

        public List<CourseResult> Courses { get; private set; } = new List<CourseResult>();

        public ChamplainStudent(int studentId, string name, int age, DateTime dob, string gender,
                                int yearOfRegister, double zScore)
            : base(name, age, dob, gender)
        {
            StudentId = studentId;
            YearOfRegister = yearOfRegister;
            ZScore = zScore;
        }

        public void AddCourse(CourseResult course)
        {
            Courses.Add(course);
        }
    }
}
