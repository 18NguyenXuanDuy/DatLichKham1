namespace DatLichKham.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichKham")]
    public partial class LichKham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LichKham_ID { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Tên không được để trống!")]
        [DisplayName("Tên bệnh nhân")]
        public string BenhNhan_Name { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Email không được để trống!")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Địa chỉ email cần nhập đúng định dạng. VD: example@gmail.com")]
        public string BenhNhan_Email { get; set; }

        public int BacSi_ID { get; set; }

        public int PhongKham_ID { get; set; }

        [StringLength(50)]
       
        public string NgayKham { get; set; }

        [StringLength(50)]
        
        public string ThoiGianKham { get; set; }

        public bool TrangThai { get; set; }

        public virtual BacSi BacSi { get; set; }

        public virtual PhongKham PhongKham { get; set; }
    }
}
