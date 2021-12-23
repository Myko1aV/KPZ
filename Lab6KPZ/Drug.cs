namespace Lab6KPZ
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Drug
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DrugID { get; set; }

        [Required]
        [StringLength(500)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpirationData { get; set; }

        public int? DrugStorageID { get; set; }

        public double? Price { get; set; }

        public virtual DrugStorage DrugStorage { get; set; }
    }
}
