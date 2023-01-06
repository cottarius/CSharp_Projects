namespace EntityFrameworkCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLOYEE")]
    public partial class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            EMPLOYEE1 = new HashSet<EMPLOYEE>();
        }

        [Key]
        public int EMP_ID { get; set; }

        public DateTime? END_DATE { get; set; }

        [Required]
        [StringLength(20)]
        public string FIRST_NAME { get; set; }

        [Required]
        [StringLength(20)]
        public string LAST_NAME { get; set; }

        public DateTime START_DATE { get; set; }

        [StringLength(20)]
        public string TITLE { get; set; }

        public int? ASSIGNED_BRANCH_ID { get; set; }

        public int? DEPT_ID { get; set; }

        public int? SUPERIOR_EMP_ID { get; set; }

        public virtual BRANCH BRANCH { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYEE> EMPLOYEE1 { get; set; }

        public virtual EMPLOYEE EMPLOYEE2 { get; set; }
    }
}
