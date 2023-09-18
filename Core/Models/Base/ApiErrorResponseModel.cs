using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Base
{
    public class ApiErrorResponseModel
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }
    }
}
