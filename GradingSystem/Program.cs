using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.txt";
        string outputPath = "output.txt";

        try
        {
            var processor = new StudentResultProcessor();
            List<Student> students = processor.ReadStudentsFromFile(inputPath);
            processor.WriteReportToFile(students, outputPath);

            Console.WriteLine("Report generated successfully at " + outputPath);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: Input file not found.");
        }
        catch (InvalidScoreFormatException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (MissingFieldException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}
