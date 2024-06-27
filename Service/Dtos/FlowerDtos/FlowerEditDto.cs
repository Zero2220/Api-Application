using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.FlowerDtos
{
    public class FlowerEditDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public List<IFormFile> FormFiles { get; set; }
        public List<int>? FileIds { get; set; }
    }
}
