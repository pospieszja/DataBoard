namespace DataBoard.Infrastructure.Commands.Users
{
    public class CreateUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}