using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module02Exercise01.Services
{
    public interface IMyService
    {
        string GetMessage();
    }

    public class MyService : IMyService
    {
        public string GetMessage()
        {
            return "Hi from MyService";
        }
    }
}
