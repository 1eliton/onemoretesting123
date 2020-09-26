using System;
using System.Collections.Generic;
using System.Text;

namespace Omt.Domain
{
    public class ApiResponse
    {
        public ApiResponse()
        {

        }

        public bool Sucess { get; set; }
        public string[] Messages { get; set; }
        public object Content { get; set; }

        public ApiResponse AddSuccess(object content)
        {
            return new ApiResponse
            {
                Sucess = true,
                Content = content
            };
        }
    }
}
