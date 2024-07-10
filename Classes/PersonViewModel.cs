namespace Project_Automait.Classes
{
    public class PersonViewModel
    {
        public Person Person { get; set; }

        public List<Person> PersonList { get; set; }

        public PersonViewModel()
        {
            Person = new Person
            {
                Name = "John",
                Surname = "Doe"
            };

            PersonList = new List<Person>
            {
                new Person
                {
                    Name = "John1",
                    Surname = "Doe1"
                },
                new Person
                {
                    Name = "John2",
                    Surname = "Doe2"
                },
                   new Person
                {
                    Name = "John2",
                    Surname = "Doe2"
                },
                      new Person
                {
                    Name = "John2",
                    Surname = "Doe2"
                },
                     new Person
                 {
                      Name = "John2",
                      Surname = "Doe2"
                 },
                     new Person
                 {
                      Name = "John2",
                      Surname = "Doe2"
                 },
                     new Person
                 {
                      Name = "John2",
                      Surname = "Doe2"
                 },
                     new Person
                 {
                      Name = "John2",
                      Surname = "Doe2"
                 },
                     new Person
                 {
                      Name = "John2",
                      Surname = "Doe2"
                 },
                     new Person
                 {
                      Name = "John2",
                      Surname = "Doe2"
                 },
                     new Person
                 {
                      Name = "John2",
                      Surname = "Doe2"
                 },
                     new Person
                 {
                      Name = "John2",
                      Surname = "Doe2"
                 }
            };
        }
    }

}