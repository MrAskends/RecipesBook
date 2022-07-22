namespace RecipesBook
{
    class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }

        public User()
        {
            this.id = 0;
            this.login = "";
            this.password = "";
            this.admin = false;
        }

        public User(int id, string login, string password, bool admin)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.admin = false;
        }
    }
}
