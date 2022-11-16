using System.Text;
using static System.Net.WebRequestMethods;

namespace IndustrialKitchenEquipmentsCRM.API.Extension.Token
{
    public class JwtTokenSettings
    {

        //ValidIssuer = "http://localhost",
        //ValidAudience = "http://localhost",
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Tmrmutfakmalzemeleri.")),
        //ValidateIssuerSigningKey = true,
        //ValidateLifetime = true,
        //ClockSkew = TimeSpan.Zero

        public const string Issuer= "http://localhost";
        public const string Audience= "http://localhost";
        public const string Key= "Tmrmutfakmalzemeleri.";
        public const int Expire= 30;


    }
}
