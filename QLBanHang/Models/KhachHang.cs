using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLBanHang.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }
        [Key]
        [StringLength(4)]
        public string MaKH { get; set; }

        [StringLength(30)]
        public string TenKH { get; set; }

        [StringLength(30)]
        public string DiaChi { get; set; }

        [StringLength(7)]
        public string DienThoai { get; set; }

        [StringLength(12)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}