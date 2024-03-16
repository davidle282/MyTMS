using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Data.Models.User
{
    public record AddUserInput : UserModel, IBaseCreateOrUpdateModel
    {
        public string Password { get; set; }

    }
}
