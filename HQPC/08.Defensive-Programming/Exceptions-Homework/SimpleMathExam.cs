// ********************************
// <copyright file="SimpleMathExam.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;

public class SimpleMathExam : Exam
{
	public const int TotalProblems = 2;

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
			throw new ArgumentOutOfRangeException("Problems solved can't be less than 0.");
        }

        if (problemsSolved > TotalProblems)
        {
			throw new ArgumentOutOfRangeException("Problems solved can't be more than total problems (" + TotalProblems + ") to solve.");
        }

        this.ProblemsSolved = problemsSolved;
    }
    
	public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: Nothing done.");
        }
		else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: Half done.");
        }
		else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Good result: All done.");
        }

        throw new ArgumentOutOfRangeException("Invalid number of problems solved!");
    }
}
