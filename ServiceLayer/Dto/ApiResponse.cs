using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
    public class ApiResponse<T>
    {
        public T DataList { get; set; }
        public string CommandMessage { get; set; }
        public bool IsValidResponse { get; set; }
        public int  Totalcount { get; set; }

        public ApiResponse()
        {
            DataList = default;
            CommandMessage = "Something went wrong, please try again later";
            IsValidResponse = default;
        }

        public ApiResponse(T data, string msg, bool isValid, int total)
        {
            DataList = data;
            CommandMessage = msg;
            IsValidResponse = isValid;
            Totalcount = total;
        }

        public ApiResponse(T data, string msg, bool isValid)
        {
            DataList = data;
            CommandMessage = msg;
            IsValidResponse = isValid;
        }

    }
}
