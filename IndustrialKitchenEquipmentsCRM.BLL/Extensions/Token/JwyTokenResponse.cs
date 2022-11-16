namespace IndustrialKitchenEquipmentsCRM.API.Extension.Token
{
    public class JwyTokenResponse
    {
        public JwyTokenResponse(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
