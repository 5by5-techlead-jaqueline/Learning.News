using System;

public class GetUserControllerCommand
{
    public GetUserControllerCommand()
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Preference preferences { get; set; }
    }
}
