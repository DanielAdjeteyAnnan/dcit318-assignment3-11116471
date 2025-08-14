using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class StudentResultProcessor
{
    public List<Student> ReadStudentsFromFile(string inputFilePath)
    {
        var students = new List<Student>();

        using (var reader = new StreamReader(inputFilePath))
        {
            string? line; // nullable string to avoid CS8600 warning
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length != 3)
                    throw new MissingFieldException($"Missing required fields in line: {line}");

                if (!int.TryParse(parts[0].Trim(), out int id))
                    throw new FormatException($"Invalid student ID format in line: {line}");

                string fullName = parts[1].Trim();

                if (!int.TryParse(parts[2].Trim(), out int score))
                    throw new InvalidScoreFormatException($"Invalid score format in line: {line}");

                students.Add(new Student(id, fullName, score));
            }
        }

        return students;
    }

    public void WriteReportToFile(List<Student> students, string outputFilePath)
    {
        using (var writer = new StreamWriter(outputFilePath))
        {
            // Header
            writer.WriteLine("================== STUDENT REPORT ==================");
            writer.WriteLine($"{"ID",-6} {"Name",-20} {"Score",-6} {"Grade",-6} {"Status",-6}");
            writer.WriteLine(new string('-', 54));

            // Sort by score descending
            var sortedStudents = students.OrderByDescending(s => s.Score).ToList();

            foreach (var student in sortedStudents)
            {
                string status = student.Score >= 50 ? "Pass" : "Fail";
                writer.WriteLine($"{student.Id,-6} {student.FullName,-20} {student.Score,-6} {student.GetGrade(),-6} {status,-6}");
            }

            writer.WriteLine(new string('-', 54));

            // Summary stats
            double avgScore = students.Average(s => s.Score);
            var topStudent = students.OrderByDescending(s => s.Score).First();
            var lowStudent = students.OrderBy(s => s.Score).First();

            writer.WriteLine($"Total Students: {students.Count}");
            writer.WriteLine($"Average Score: {avgScore:F2}");
            writer.WriteLine($"Highest Score: {topStudent.Score} ({topStudent.FullName})");
            writer.WriteLine($"Lowest Score : {lowStudent.Score} ({lowStudent.FullName})");
            writer.WriteLine("=====================================================");
        }
    }
}
