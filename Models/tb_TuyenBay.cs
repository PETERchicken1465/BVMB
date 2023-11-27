namespace DatVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_TuyenBay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_TuyenBay()
        {
            tb_ChuyenBay = new HashSet<tb_ChuyenBay>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTuyenBay { get; set; }

        public int? MaSanBayDi { get; set; }

        public int? MaSanBayDen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_ChuyenBay> tb_ChuyenBay { get; set; }

        public virtual tb_SanBay tb_SanBay { get; set; }

        public virtual tb_SanBay tb_SanBay1 { get; set; }
    }
}
