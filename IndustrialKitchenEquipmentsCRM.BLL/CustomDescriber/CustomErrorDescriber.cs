using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IndustrialKitchenEquipmentsCRM.BLL.CustomDescriber
{
	public class CustomErrorDescriber:IdentityErrorDescriber
	{
        public override IdentityError DuplicateUserName(string userName)
        {

            return new()
            {
                Code = "DublicateUserName",
                Description = $"{userName} zaten alındı"
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {

            return new()
            {
                Code = "PasswordTooShort",
                Description = $" Parola en az {length} karekter olmalıdır"
            };
        }

       
    }
}
