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
    class M_Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(5)]
        [Column("CategoryCD", TypeName = "char", Order = 0)]
        [DisplayName("カテゴリCD")]
        public string CategoryCD { get; set; }

        [MaxLength(5)]
        [Column("ParentCategory", TypeName = "varchar", Order = 1)]
        [DisplayName("親カテゴリCD")]
        public string ParentCategory { get; set; }

        [Required]
        [MaxLength(25)]
        [Column("CategoryName", TypeName = "nvarchar", Order = 2)]
        [DisplayName("カテゴリ名")]
        public string CategoryName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("CategoryKana", TypeName = "nvarchar", Order = 3)]
        [DisplayName("カテゴリカナ名")]
        public string CategoryKana { get; set; }

        [Column("DeleteFlg", TypeName = "bit", Order = 4)]
        [DisplayName("削除フラグ")]
        public bool DeleteFlg { get; set; }

        [MaxLength(80)]
        [Column("Comments", TypeName = "nvarchar", Order = 5)]
        [DisplayName("備考")]
        public string Comments { get; set; }

    }
}
