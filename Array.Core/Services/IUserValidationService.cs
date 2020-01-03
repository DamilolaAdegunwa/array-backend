using Array.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Array.Core.Services
{
    public interface IUserValidationService
    {
        UserEntity IsValidate(string username, string password);
    }
}
