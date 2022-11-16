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
    class M_Tax
    {
        [Key]
        [Column("M_TaxID", TypeName = "int", Order = 0)]
        [DisplayName("消費税ID")]
        public int M_TaxID { get; set; }

        [Required]
        [Column("Tax", TypeName = "int", Order = 1)]
        [DisplayName("消費税率")]
        public int Tax { get; set; }

        [Required]
        [Column("ModifyDate", TypeName = "date", Order = 2)]
        [DisplayName("変更日")]
        public DateTime? ModifyDate { get; set; }

        [Column("DeleteFlg", TypeName = "bit", Order = 3)]
        [DisplayName("削除フラグ")]
        public bool DeleteFlg { get; set; }

        [MaxLength(80)]
        [Column("Comments", TypeName = "nvarchar", Order = 4)]
        [DisplayName("備考")]
        public string Comments { get; set; }
    }
}
