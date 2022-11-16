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
    class M_Maker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(5)]
        [Column("MakerCD", TypeName = "char", Order = 0)]
        [DisplayName("メーカCD")]
        public string MakerCD { get; set; }

        [Required]
        [MaxLength(25)]
        [Column("MakerName", TypeName = "nvarchar", Order = 1)]
        [DisplayName("メーカ名")]
        public string MakerName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("MakerKana", TypeName = "nvarchar", Order = 2)]
        [DisplayName("メーカカナ名")]
        public string MakerKana { get; set; }

        [Column("DeleteFlg", TypeName = "bit", Order = 3)]
        [DisplayName("削除フラグ")]
        public bool DeleteFlg { get; set; }

        [MaxLength(80)]
        [Column("Comments", TypeName = "nvarchar", Order = 4)]
        [DisplayName("備考")]
        public string Comments { get; set; }

    }
}
