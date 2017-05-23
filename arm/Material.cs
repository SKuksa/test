using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace arm
{
    [DataContract]
    public class Material
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public bool isUsed { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
