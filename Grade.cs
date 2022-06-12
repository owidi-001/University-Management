using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentM
{
    internal class Grade
    {
        Subject subject;
        Student student;
        int score;

        public Grade(Subject subject, Student student, int score)
        {
            this.subject = subject;
            this.student = student;
            this.score = score;
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public Subject Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public Student Student
        {
            get { return student; }
            set
            {
                student = value;
            }
        }
    }
}
