using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace arm
{
    [DataContract]
    public class Cars
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Code { get; set; }
        [DataMember]
        public string CarNumber { get; set;}
        [DataMember]
        public string TrailerNumber { get; set; }
        [DataMember]
        public string Carbrand { get; set; }
        [DataMember]
        public string Driver { get; set; }
        [DataMember]
        public Guid Shipper { get; set; }
        [DataMember]
        public bool isUsed { get; set; }
    }
}
