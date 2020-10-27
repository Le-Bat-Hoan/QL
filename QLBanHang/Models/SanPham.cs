using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLBanHang.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(4)]
        public string MaSP { get; set; }

        [StringLength(20)]
        public string TenSP { get; set; }

        [StringLength(8)]
        public string Donvitinh { get; set; }

        public double? Dongia { get; set; }

        public int? MaLoaiSP { get; set; }

        public string HinhSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }
    }

}