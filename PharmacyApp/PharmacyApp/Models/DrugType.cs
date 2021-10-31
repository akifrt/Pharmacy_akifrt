using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
     public class DrugType
    {
        public int Id { get; }
        public string TypeName { get; }

        private static int _counter = 0;

        public DrugType(string typeName)
        {
            TypeName = typeName;
            _counter++;
            Id = _counter;
        }

        public override string ToString()
        {
            return this.TypeName;
        }
    }
}
