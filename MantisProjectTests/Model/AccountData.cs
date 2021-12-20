namespace MantisProjectTests
{
    public class AccountData
    {
        public string Name { get; set; }
        public string Pass { get; set; }
        public AccountData(string name, string pass)
        {
            Name = name;
            Pass = pass;
        }
    }
}
