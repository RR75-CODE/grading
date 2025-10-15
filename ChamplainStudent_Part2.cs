using System;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace grading
{
    public partial class ChamplainStudent
    {
        public double CalculateAverage()
        {
            if (Courses == null || Courses.Count == 0) return 0.0;
            return Courses.Average(c => c.Score);
        }

        public double CalculateGPA()
        {
            double avg = CalculateAverage();
            double gpa = (avg / 100.0) * 4.0;
            return Math.Round(gpa, 2);
        }

        public double CalculateRScore()
        {
            if (Courses == null || Courses.Count == 0) return 0.0;
            double irgAvg = Courses.Average(c => c.IRG);
            double rawR = (ZScore * 5.0) + irgAvg + 35.0;
            double scaled = (rawR / 60.0) * 20.0;
            return Math.Round(scaled, 2);
        }

        public override void DisplayInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Student ID : {StudentId}");
            sb.AppendLine($"Name       : {Name}");
            sb.AppendLine($"Age        : {Age}");
            sb.AppendLine($"DOB        : {DateOfBirth:yyyy-MM-dd}");
            sb.AppendLine($"Gender     : {Gender}");
            sb.AppendLine($"YearReg    : {YearOfRegister}");
            sb.AppendLine($"Z-Score    : {ZScore}");
            sb.AppendLine();
            sb.AppendLine("Courses:");
            foreach (var c in Courses)
            {
                sb.AppendLine($"  {c.CourseId,-8} {c.CourseName,-20} Score:{c.Score,5}  Group:{c.GroupId}  IRG:{c.IRG}");
            }
            sb.AppendLine();
            double avg = CalculateAverage();
            double gpa = CalculateGPA();
            double irgAvg = (Courses.Count > 0) ? Math.Round(Courses.Average(c => c.IRG), 2) : 0.0;
            double rScore = CalculateRScore();

            sb.AppendLine($"Average Score : {Math.Round(avg, 2)}");
            sb.AppendLine($"GPA (0-4.0)   : {gpa}");
            sb.AppendLine($"Avg IRG       : {irgAvg}");
            sb.AppendLine($"R-Score (0-20): {rScore}");
            sb.AppendLine(new string('-', 60));

            Console.WriteLine(sb.ToString());
        }
    }
}
