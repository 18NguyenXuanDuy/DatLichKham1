namespace DatLichKham.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongKham")]
    public partial class PhongKham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongKham()
        {
            LichKham = new HashSet<LichKham>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PhongKham_ID { get; set; }

        [StringLength(50)]
        public string PhongKham_Name { get; set; }

        public int SoLuongToiDa { get; set; }

        public int SoLuongHienTai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichKham> LichKham { get; set; }
    }
}
