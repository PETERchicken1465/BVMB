namespace DatVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Ghe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Ghe()
        {
            tb_DatVe = new HashSet<tb_DatVe>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaGhe { get; set; }

        public int? SoGhe { get; set; }

        public bool? TrangThai { get; set; }

        [StringLength(10)]
        public string DayGhe { get; set; }

        public int? MaHangGhe { get; set; }

        public int? MaMayBay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_DatVe> tb_DatVe { get; set; }

        public virtual tb_HangGhe tb_HangGhe { get; set; }

        public virtual tb_MayBay tb_MayBay { get; set; }
    }
}
