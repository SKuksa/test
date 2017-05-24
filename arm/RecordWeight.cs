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
        [DataMember]
        public string Code { get; set;}
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string BlobFilePath { get; set; }
        [DataMember]
        public byte[] Byte { get; set; }

    }

    [DataContract]
    public class Weighing
    {
     
        [DataMember]
        public string MaterialFact { get; set; }
        
        [DataMember]
        public File[]  Files{ get; set; }
       
        [DataMember]
        public string Consignee { get; set; }
        
        [DataMember]
        public string Autotruck { get; set; }
       
        [DataMember]
        public string Shipper { get; set; }
        
        [DataMember]
        public EWeighingMode WeighingMode { get
            {

                if (DateGross == null)
                    return EWeighingMode.Cross_Tare;
                if (DateTare == null)
                    return EWeighingMode.Cross_Tare;
                if(DateGross==DateTime.MinValue && DateTare == DateTime.MinValue)
                    return EWeighingMode.Cross_Tare;

                if (DateGross >DateTare)
                    return EWeighingMode.Tare_Gross;
                else
                    return EWeighingMode.Cross_Tare;
            } set { }
        }
        
        [DataMember]
        public bool isCompleted { get
            {

                if (DateGross != null && DateGross != DateTime.MinValue && DateTare != null && DateTare != DateTime.MinValue)
                    return true;
                else
                    return false;

            }set { } }
  
       
        [DataMember]
        public DateTime DateTare{ get; set; }
        
        [DataMember]
        public DateTime DateGross { get; set; }
        
        [DataMember]
        public int WeightTara { get; set; }
       
        [DataMember]
        public int WeightGross { get; set; }
        
        [DataMember]
        public int NetWeight { get; set; }
      
        [DataMember]
        public int Code { get; set; }
       
        [DataMember]
        public string WeighmanTare{ get; set; }//весовщик тара
        
        [DataMember]
        public string WeighmanGross { get; set; }//весовщик тара
     
        public Weighing()
        {
            DateTare = DateTime.MinValue;
            DateGross = DateTime.MinValue;


            MaterialFact = string.Empty;
            //Files;
            Consignee = string.Empty;
            Autotruck = string.Empty;
            Shipper = string.Empty;
            WeighingMode =  EWeighingMode.Cross_Tare;
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
        public Weighing(int Num)
        {
            DateTare = DateTime.MinValue;
            DateGross = DateTime.MinValue;


            MaterialFact = string.Empty;
            //Files;
            Consignee = string.Empty;
            Autotruck = string.Empty;
            Shipper = string.Empty;
            WeighingMode =  EWeighingMode.Cross_Tare;
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
