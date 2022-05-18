using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class Log
    {
        public int id { get; set; }
        public string message { get; set; }

        public Log() { }

        public Log(int id, string message)
        {
            this.id = id;
            this.message = message;
        }
    }
}
