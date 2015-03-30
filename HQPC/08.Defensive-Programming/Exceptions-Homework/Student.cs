using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public IList<Exam> Exams { get; set; }

    public Student(string firstName, string lastName, IList<Exam> exams)
    {
		if (string.IsNullOrEmpty(firstName))
        {
			throw new ArgumentNullException("First name can't be empty or without value!");
        }

        if (string.IsNullOrEmpty(lastName))
        {
			throw new ArgumentNullException("Last name can't be empty or without value!");
        }

		if (exams == null)
		{
			throw new ArgumentNullException("Exams cannot have null value.");
		}

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
			throw new ArgumentNullException("Exams cannot have null value.");
        }

		if (this.Exams.Count == 0)
		{
			throw new ArgumentOutOfRangeException("The student has no exams!");
		}

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            // Cannot calculate average on missing exams
			throw new ArgumentNullException("Exams cannot have null value.");
        }

        if (this.Exams.Count == 0)
        {
			// No exams
			throw new ArgumentOutOfRangeException("The student has no exams!");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average() * 100; //// multiplaing by 100 make the number in %
    }
}
