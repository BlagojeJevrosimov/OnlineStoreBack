using Common;
using UserDAL.Enums;

namespace UserDAL.Entites
{
    public class User : BaseEntity
    {
        public string? UserName { get; set; }
        public string? Email { get; set;}
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public DateTime BirthDay { get; set; }
        public string? Address {get; set;}
        public Role Role { get; set;}

        public String? ProfilePhotoPath { get; set; }

    }
}
