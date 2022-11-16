using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IndustrialKitchenEquipmentsCRM.DTOs;
using IndustrialKitchenEquipmentsCRM.Entities.Auth;
using Microsoft.IdentityModel.Tokens;

namespace IndustrialKitchenEquipmentsCRM.API.Extension.Token
{
    public class JwtTokenGenerator
    {
        public static JwyTokenResponse GenerateToken(CLoginDto dto)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name,dto.Email));
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                claims:claims,
                issuer: JwtTokenSettings.Issuer,
                audience: JwtTokenSettings.Audience,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(JwtTokenSettings.Expire),
                signingCredentials: credentials
                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new JwyTokenResponse(handler.WriteToken(token)); 
        }
    }
}
