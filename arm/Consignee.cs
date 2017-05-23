using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace arm
{
   
   [DataContract]
    public class Consignee
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool isUsed { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
