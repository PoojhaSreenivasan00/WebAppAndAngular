namespace DemoProject.Model
{
    public class User
    {
        // public int Id { get; set; }
        // public string Name;    
        // public int Age;
        //public long PhoneNo { get; set; }

        private int _id;
        private string _name;
        private int _age;
        private long _phoneNo;
        public User(int id, string name, int age, long phoneNo)
        {
            _id = id;
            _name = name;
            _age = age;
            _phoneNo = phoneNo;
        }

        public int Id => _id;
        public string Name => _name;
        public int Age => _age;
        public long PhoneNo => _phoneNo;


    }
}
