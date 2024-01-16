namespace RestApi.Models.Input
{
    public class UserRESTInputDTO
    {
        public UserRESTInputDTO(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
