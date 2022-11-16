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
    class M_Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(8)]
        [Column("ItemCD", TypeName = "char", Order = 0)]
        [DisplayName("商品CD")]
        public string ItemCD { get; set; }

        [Required]
        [MaxLength(25)]
        [Column("ItemName", TypeName = "nvarchar", Order = 1)]
        [DisplayName("商品名")]
        public string ItemName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("ItemKana", TypeName = "nvarchar", Order = 2)]
        [DisplayName("商品カナ名")]
        public string ItemKana { get; set; }

        [Required]
        [MaxLength(5)]
        [ForeignKey("M_Category"), Column("CategoryCD", TypeName = "char", Order = 3)]
        [DisplayName("カテゴリCD")]
        public string CategoryCD { get; set; }

        [MaxLength(13)]
        [Column("JanCD", TypeName = "varchar", Order = 4)]
        [DisplayName("JANCD")]
        public string JanCD { get; set; }

        [Required]
        [MaxLength(5)]
        [ForeignKey("M_Maker"), Column("MakerCD", TypeName = "char", Order = 5)]
        [DisplayName("メーカCD")]
        public string MakerCD { get; set; }

        [MaxLength(30)]
        [Column("ModelNo", TypeName = "nvarchar", Order = 6)]
        [DisplayName("型番")]
        public string ModelNo { get; set; }

        [Column("ListPrice", TypeName = "int", Order = 7)]
        [DisplayName("定価")]
        public int? ListPrice { get; set; }

        [Required]
        [Column("SellingPrice", TypeName = "int", Order = 8)]
        [DisplayName("店頭販売単価")]
        public int SellingPrice { get; set; }

        [Column("DeleteFlg", TypeName = "bit", Order = 9)]
        [DisplayName("削除フラグ")]
        public bool DeleteFlg { get; set; }

        [MaxLength(80)]
        [Column("Comments", TypeName = "nvarchar", Order = 10)]
        [DisplayName("備考")]
        public string Comments { get; set; }

        public virtual M_Category M_Category { get; set; }
        public virtual M_Maker M_Maker { get; set; }
    }

    //データグリッド表示用
    class M_ItemDsp
    {
        [DisplayName("商品CD")]
        public string ItemCD { get; set; }

        [DisplayName("商品名")]
        public string ItemName { get; set; }

        [DisplayName("商品カナ名")]
        public string ItemKana { get; set; }

        [DisplayName("親カテゴリCD")]
        public string ParentCategoryCD { get; set; }

        [DisplayName("親カテゴリ名")]
        public string PanrentCategoryName { get; set; }

        [DisplayName("カテゴリCD")]
        public string CategoryCD { get; set; }

        [DisplayName("カテゴリ名")]
        public string CategoryName { get; set; }

        [DisplayName("JANCD")]
        public string JanCD { get; set; }

        [DisplayName("メーカCD")]
        public string MakerCD { get; set; }

        [DisplayName("メーカ名")]
        public string MakerName { get; set; }

        [DisplayName("型番")]
        public string ModelNo { get; set; }

        [DisplayName("定価")]
        public int? ListPrice { get; set; }

        [DisplayName("店頭販売単価")]
        public int SellingPrice { get; set; }

        [DisplayName("削除フラグ")]
        public bool DeleteFlg { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }
    }
}
