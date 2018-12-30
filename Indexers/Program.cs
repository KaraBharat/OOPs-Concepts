using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    public class LocalStorage
    {
        private Dictionary<string, object> _localData { get; set; }
        public DateTime Expiry { get; set; }

        public LocalStorage()
        {
            this._localData = new Dictionary<string, object>();
        }

        public object this[string key]
        {
            get { return this._localData[key]; }
            set { this._localData[key] = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var localStorage = new LocalStorage();

            localStorage["userName"] = "john@smith";
            localStorage.Expiry = DateTime.Now.AddDays(5);

            Console.WriteLine(localStorage["userName"]);
            Console.WriteLine(localStorage.Expiry);
        }
    }
}
