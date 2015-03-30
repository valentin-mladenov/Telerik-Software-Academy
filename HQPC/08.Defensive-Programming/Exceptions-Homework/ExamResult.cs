using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
			throw new ArgumentOutOfRangeException("Grade value can't be negative!");
        }

        if (minGrade < 0)
        {
			throw new ArgumentOutOfRangeException("Min grade value can't be negative!");
        }

        if (maxGrade <= minGrade)
        {
			throw new ArgumentOutOfRangeException("Max grade value can't be less then min grade!");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException("Comments can't be empty or without value!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
