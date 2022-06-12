namespace studentM
{
    /*internal class Subject
    {
        public static List<Subject> subjects = new List<Subject>();
        private string title;

        public Subject(string title)
        {
            this.title = title;
            subjects.Add(new Subject(title));
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public static void addSubject()
        {
            Subject subject =null;

            Console.WriteLine("Subject Title: ");
            string title = Console.ReadLine();

            foreach(Subject subject1 in subjects)
            {
                if(subject1.Title == title)
                {
                    subject = subject1;
                }
            }  
        }

    }*/

    internal class Subject
    {
        private string title;
        public static List<Subject> subjects = new List<Subject>();
        public Subject(string title)
        {
            this.title = title;
            subjects.Add(this);
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public override string ToString()
        {
            return title;
        }
    }
}
