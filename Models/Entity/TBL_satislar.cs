//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_satislar
    {
        public int satisid { get; set; }
        public Nullable<int> urun { get; set; }
        public Nullable<int> musteri { get; set; }
        public Nullable<byte> adet { get; set; }
        public Nullable<decimal> fiyat { get; set; }
    
        public virtual TBL_musteriler TBL_musteriler { get; set; }
        public virtual TBL_urunler TBL_urunler { get; set; }
    }
}
