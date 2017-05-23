using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace arm
{
    [DataContract]
    public class File
    {
        public string Code { get; set;}
        public string Name { get; set; }
        public byte[] Byte { get; set; }
    }

    [DataContract]
    public class RecordWeight
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string MaterialFact { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public File  Files{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Consignee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Autotruck { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Shipper { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string WeighingMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool isCompleted { get; set; }
  
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime DateTare{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime DateGross { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int WeightTara { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int WeightGross { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int NetWeight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string WeighmanTare{ get; set; }//весовщик тара
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string WeighmanGross { get; set; }//весовщик тара
     
        public RecordWeight()
        {
            DateTare = DateTime.MinValue;
            DateGross = DateTime.MinValue;


            MaterialFact = string.Empty;
            //Files;
            Consignee = string.Empty;
            Autotruck = string.Empty;
            Shipper = string.Empty;
            WeighingMode = string.Empty;
            isCompleted=false;

            DateTare=DateTime.MinValue;
            DateGross = DateTime.MinValue;
            WeightTara = 0; ;
            WeightGross = 0; ;
            NetWeight = 0; ;
            Code =0;
            WeighmanTare = string.Empty;//весовщик тара
            WeighmanGross = string.Empty; //весовщик тара


    }
        public RecordWeight(int Num)
        {
            DateTare = DateTime.MinValue;
            DateGross = DateTime.MinValue;


            MaterialFact = string.Empty;
            //Files;
            Consignee = string.Empty;
            Autotruck = string.Empty;
            Shipper = string.Empty;
            WeighingMode = string.Empty;
            isCompleted = false;

            DateTare = DateTime.MinValue;
            DateGross = DateTime.MinValue;
            WeightTara = 0; ;
            WeightGross = 0; ;
            NetWeight = 0; ;
            Code = Num;
            WeighmanTare = string.Empty;//весовщик тара
            WeighmanGross = string.Empty; //весовщик тара
        }
    }
}
