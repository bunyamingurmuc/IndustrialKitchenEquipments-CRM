using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IndustrialKitchenEquipmentsCRM.DTOs.ControllerDtos
{
    public class CImageUploadDto
    {
        public IFormFile File { get; set; }
    }
}
