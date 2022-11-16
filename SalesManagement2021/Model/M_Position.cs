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
    class M_Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(5)]
        [Column("PositionCD", TypeName = "char", Order = 0)]
        [DisplayName("役職CD")]
        public string PositionCD { get; set; }

        [Required]
        [MaxLength(25)]
        [Column("PositionName", TypeName = "nvarchar", Order = 1)]
        [DisplayName("役職名")]
        public string PositionName { get; set; }

        [Column("DeleteFlg", TypeName = "bit", Order = 2)]
        [DisplayName("削除フラグ")]
        public bool DeleteFlg { get; set; }

        [MaxLength(80)]
        [Column("Comments", TypeName = "nvarchar", Order = 3)]
        [DisplayName("備考")]
        public string Comments { get; set; }
    }
}
