using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement2021
{
    class M_Division
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(5)]
        [Column("DivisionCD", TypeName = "char", Order = 0)]
        [DisplayName("部署CD")]
        public string DivisionCD { get; set; }

        [Required]
        [MaxLength(25)]
        [Column("DivisionName", TypeName = "nvarchar", Order = 1)]
        [DisplayName("部署名")]
        public string DivisionName { get; set; }

        [Column("DeleteFlg", TypeName = "bit", Order = 2)]
        [DisplayName("削除フラグ")]
        public bool DeleteFlg { get; set; }

        [MaxLength(80)]
        [Column("Comments", TypeName = "nvarchar", Order = 3)]
        [DisplayName("備考")]
        public string Comments { get; set; }
    }
}
