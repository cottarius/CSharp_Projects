namespace EntityFrameworkCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BRANCH")]
    public partial class BRANCH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BRANCH()
        {
            EMPLOYEE = new HashSet<EMPLOYEE>();
        }

        [Key]
        public int BRANCH_ID { get; set; }

        [StringLength(30)]
        public string ADDRESS { get; set; }

        [StringLength(20)]
        public string CITY { get; set; }

        [Required]
        [StringLength(20)]
        public string NAME { get; set; }

        [StringLength(10)]
        public string STATE { get; set; }

        [StringLength(12)]
        public string ZIP_CODE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYEE> EMPLOYEE { get; set; }
    }
}
