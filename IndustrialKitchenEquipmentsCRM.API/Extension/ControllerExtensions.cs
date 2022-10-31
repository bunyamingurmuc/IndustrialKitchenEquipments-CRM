using IndustrialKitchenEquipmentsCRM.Common;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialKitchenEquipmentsCRM.API.Extension
{
    public static class ControllerExtensions
    {
        public static ActionResult ResponseStatusWithData(this ControllerBase controller, IResponse response)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();

            }
            else
            {
                return controller.Ok();

            }
        }

        public static ActionResult ResponseStatusWithData<T>(this ControllerBase controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                var errors = new List<string>();
                
                return controller.NotFound(response.Message);
            }
            else if (response.ResponseType == ResponseType.ValidationError)
            {
                var errors = new List<string>();
                foreach (var error in response.ValidationErrors)
                {
                    errors.Add(error.ErrorMessage);
                }
                return controller.BadRequest(errors);
            }
            else
            {
                if (response.Data == null)
                {
                    return controller.Ok();
                }
                return controller.Ok(response.Data);
            }

        }
    }
}
