using System;

namespace DataBoard.Core.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public User()
        {
            
        }
        
        public User(string email, string password)
        {
            Id = Guid.NewGuid();
            SetEmail(email);
            SetPassword(password);
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can't be empty.");
            }

            if (Email == email)
            {
                return;
            }
            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if (String.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can't be empty.");
            }

            if (password.Length < 6)
            {
                throw new Exception("Password can't be shorter then 6 characters.");
            }

            if (password.Length > 20)
            {
                throw new Exception("Password can't be longer then 20 characters.");
            }

            if (Password == password)
            {
                return;
            }
            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }
    }

}