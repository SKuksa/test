using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace arm
{
    public enum EWeighingMode
    {
        GrossAndTare,
        Cross_Tare,
        Mixed,
        Tare_Gross,
        OnlyGross
    }
    [DataContract]
    public class WeighingMode
    {
        [DataMember]
        public EWeighingMode Mode { get; set; }

    }
}
