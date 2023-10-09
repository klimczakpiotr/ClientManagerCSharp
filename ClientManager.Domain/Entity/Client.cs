using ClientManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManager.Domain.Entity
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int PESEL { get; set; }
        public int NIP { get; set; }
    }
}
