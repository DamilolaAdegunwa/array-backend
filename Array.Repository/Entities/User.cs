using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace Array.Repository.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        [Index(IsUnique = true)]
        public string Email { get; set; }
        public bool Verified { get; set; } = false;
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;//I think it make sense to store date in GMT
        public Profile Profile { get; set; } // 1 - 1 relationship with profile
    }
}
/*
The "User" as well as the "Profile" class jointly represent the individual users on the platform. The separation was done to create room for pulling the basic content while lazy-loading the other data if need be
*/
