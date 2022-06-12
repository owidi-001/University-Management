using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentM
{
    internal class Course
    {
        static List<Course> courses=new();

        private string name;
        private List<Subject> subjects=new();
        public Course(string name,List<Subject> subjects)
        {
            this.name = name;
            this.subjects = subjects;
            courses.Add(this);
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Subject> Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }
        public static List<Course> Courses
        {
            get { return courses; }
        }
        //Add Course
        public static void addCourse(string name,List<Subject> subjects)
        {
            courses.Add(new Course(name,subjects));
        }
        // Delete course
        public static void deleteCourse(string name)
        {
            
            foreach (Course course in Course.Courses)
            {
                if (course.Name.Equals(name))
                {
                    courses.Remove(course);
                }
            }
        }
        // Search course by name
        public static Course findCourse(string name)
        {
            Course myCourse = null;


            foreach (Course course in Course.Courses)
            {
                if (course.Name.Equals(name))
                {
                    myCourse = course;
                }
            }

            return myCourse;
        }
    }
}
