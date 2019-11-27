using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiApi.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nome { get; set; }
        public string morada { get; set; }
        public string codigoPostal { get; set; }
        public Localizacao idLocalizacao { get; set; }
    }
}
