using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arm
{
    public class RecordWeight
    {
        public string Regim { get; set; }
        public DateTime dataTara { get; set; }
        public DateTime dataBrutto { get; set; }
        public int WeightTara { get; set; }
        public int WeightBrutto { get; set; }
        public int WeightNetto { get; set; }
        public int Number { get; set; }
        public string Autor { get; set; }
        public string AutoTara { get; set; }
        public string AutoBrutto { get; set; }
        public string CarName { get; set; }
        public string CarNumber { get; set; }
        public string CarDriver { get; set; }
        public string Pricep { get; set; }
        public string PricepNumber { get; set; }
        public string GrusOtprav { get; set; }
        public string GrusPoluch { get; set; }
        public string Tovar { get; set; }
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
