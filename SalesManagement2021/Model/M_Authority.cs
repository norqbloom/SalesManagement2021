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
    class M_Authority
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(5)]
        [Column("AuthorityCD", TypeName = "char", Order = 0)]
        [DisplayName("権限CD")]
        public string AuthorityCD { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("AuthorityName", TypeName = "nvarchar", Order = 1)]
        [DisplayName("権限名")]
        public string AuthorityName { get; set; }

        [Column("DeleteFlg", TypeName = "bit", Order = 2)]
        [DisplayName("削除フラグ")]
        public bool DeleteFlg { get; set; }

        [MaxLength(80)]
        [Column("Comments", TypeName = "nvarchar", Order = 3)]
        [DisplayName("備考")]
        public string Comments { get; set; }
    }
}
