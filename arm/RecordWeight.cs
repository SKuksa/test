using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace arm
{
    [DataContract]
    public class RecordWeight
    {
        [DataMember]
        public string Regim { get; set; }
        [DataMember]
        public DateTime dataTara { get; set; }
        [DataMember]
        public DateTime dataBrutto { get; set; }
        [DataMember]
        public int WeightTara { get; set; }
        [DataMember]
        public int WeightBrutto { get; set; }
        [DataMember]
        public int WeightNetto { get; set; }
        [DataMember]
        public int Number { get; set; }
        public string Autor { get; set; }
        [DataMember]
        public string AutoTara { get; set; }
        [DataMember]
        public string AutoBrutto { get; set; }
        [DataMember]
        public string CarName { get; set; }
        [DataMember]
        public string CarNumber { get; set; }
        [DataMember]
        public string CarDriver { get; set; }
        [DataMember]
        public string Pricep { get; set; }
        [DataMember]
        public string PricepNumber { get; set; }
        [DataMember]
        public string GrusOtprav { get; set; }
        [DataMember]
        public string GrusPoluch { get; set; }
        [DataMember]
        public string Tovar { get; set; }
        [DataMember]
        public string Sclad { get; set; }
        public RecordWeight()
        {
            dataTara = DateTime.MinValue;
            dataBrutto = DateTime.MinValue;
            WeightTara = 0;
            WeightBrutto = 0;
            WeightNetto = 0;
            Number = 0;
            Autor = string.Empty;
            AutoTara = string.Empty;
            AutoBrutto = string.Empty;
            CarName = string.Empty;
            CarNumber = string.Empty;
            CarDriver = string.Empty;
            Pricep = string.Empty;
            PricepNumber = string.Empty;
            GrusOtprav = string.Empty;
            GrusPoluch = string.Empty;
            Tovar = string.Empty;
            Sclad = string.Empty;
        }
        public RecordWeight(int Num)
        {
            dataTara = DateTime.MinValue;
            dataBrutto = DateTime.MinValue;
            WeightTara = 0;
            WeightBrutto = 0;
            WeightNetto = 0;
            Number = Num;
            Autor = string.Empty;
            AutoTara = string.Empty;
            AutoBrutto = string.Empty;
            CarName = string.Empty;
            CarNumber = string.Empty;
            CarDriver = string.Empty;
            Pricep = string.Empty;
            PricepNumber = string.Empty;
            GrusOtprav = string.Empty;
            GrusPoluch = string.Empty;
            Tovar = string.Empty;
            Sclad = string.Empty;
        }
    }
}
