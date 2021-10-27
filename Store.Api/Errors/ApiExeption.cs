using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Errors
{
    public class ApiExeption : ApiResponse
    {
        public string Details { get; set; }
        public ApiExeption(int statusCode, string massage = null,string details=null) : base(statusCode, massage)
        {
            Details = details;
        }
    }
}