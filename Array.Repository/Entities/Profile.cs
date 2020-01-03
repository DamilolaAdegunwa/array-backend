using System;
using System.Collections.Generic;
using System.Text;

namespace Array.Repository.Entities
{
    public class Profile
    {
        public long Id { get; set; }
        #region 1-1 relationship with user
        public long UserId { get; set; }
        public User User { get; set; }
        #endregion
    }
}
/*
The "User" as well as the "Profile" class jointly represent the individual users on the platform. The separation was done to create room for pulling the basic content while lazy-loading the other data if need be
*/