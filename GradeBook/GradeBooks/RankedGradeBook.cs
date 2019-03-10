using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int threshold = (int)(this.Students.Count * 0.2);
            int numLessThan = 0;
            foreach (Student student in this.Students)
            {
                if (averageGrade < student.AverageGrade)
                {
                    numLessThan += 1;
                }
            }

            char letterGrade;
            if (numLessThan < threshold)
            {
                letterGrade = 'A';
            }
            else if (numLessThan < (threshold * 2))
            {
                letterGrade = 'B';
            }
            else if (numLessThan < (threshold * 3))
            {
                letterGrade = 'C';
            }
            else if (numLessThan < (threshold * 4))
            {
                letterGrade = 'D';
            }
            else
            {
                letterGrade = 'F';
            }
            
            return letterGrade;
        }
    }
}
