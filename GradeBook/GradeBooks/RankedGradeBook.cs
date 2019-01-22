using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook( string name ) : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade( double averageGrade )
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requiers at lest 5 students.");
            }

            var threshold = (int)Math.Ceiling(this.Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[threshold-1] <= averageGrade)
            {
                return 'A';
            }
            else if ((grades[(threshold * 2) - 1] <= averageGrade))
            {
                return 'B';
            }
            else if ((grades[(threshold * 3) - 1] <= averageGrade))
            {
                return 'C';
            }
            else if ((grades[(threshold * 4) - 1] <= averageGrade))
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
