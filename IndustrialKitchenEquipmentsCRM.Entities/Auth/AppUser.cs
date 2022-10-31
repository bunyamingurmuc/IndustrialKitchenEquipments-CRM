using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IndustrialKitchenEquipmentsCRM.Entities.Auth
{
    public class AppUser : IdentityUser<int>
    {
        public AppUser()
        {
            Cards = new List<Entities.Card.Card>();
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Adress { get; set; }
        public List<Card.Card> Cards { get; set; }

    }
}
