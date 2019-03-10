using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
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

        public override void CalculateStatistics()
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly" +
                                  "calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly" +
                                  "calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
