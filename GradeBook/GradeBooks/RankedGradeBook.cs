using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count <= 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            int thr = (int)Math.Floor(Students.Count * 0.2);
            var grades = Students.OrderByDescending(a => a.AverageGrade).Select(a => a.AverageGrade).ToList();

            if (grades[thr] <= averageGrade)
                return 'A';
            else if (grades[thr * 2] <= averageGrade)
                return 'B';
            else if (grades[thr * 3] <= averageGrade)
                return 'C';
            else if (grades[thr * 4] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}

