using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlogToRestart.Models
{
    public class Response<T>
    {
        public T Post { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
