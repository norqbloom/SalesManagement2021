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
    class M_Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(5)]
        [Column("StoreCD", TypeName = "char", Order = 0)]
        [DisplayName("店舗CD")]
        public string StoreCD { get; set; }

        [Required]
        [MaxLength(25)]
        [Column("StoreName", TypeName = "nvarchar", Order = 1)]
        [DisplayName("店舗名")]
        public string StoreName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("StoreNameKana", TypeName = "nvarchar", Order = 2)]
        [DisplayName("店舗カナ名")]
        public string StoreNameKana { get; set; }

        [MaxLength(7)]
        [Column("StorePostal", TypeName = "char", Order = 3)]
        [DisplayName("郵便番号")]
        public string StorePostal { get; set; }

        [MaxLength(50)]
        [Column("StoreAddress", TypeName = "nvarchar", Order = 4)]
        [DisplayName("住所")]
        public string StoreAddress { get; set; }

        [MaxLength(100)]
        [Column("StoreAddressKana", TypeName = "nvarchar", Order = 5)]
        [DisplayName("住所カナ")]
        public string StoreAddressKana { get; set; }

        [Required]
        [MaxLength(12)]
        [Column("StoreTel", TypeName = "nvarchar", Order = 6)]
        [DisplayName("電話番号")]
        public string StoreTel { get; set; }

        [MaxLength(12)]
        [Column("StoreFax", TypeName = "nvarchar", Order = 7)]
        [DisplayName("FAX番号")]
        public string StoreFax { get; set; }

        [MaxLength(30)]
        [Column("StoreMail", TypeName = "nvarchar", Order = 8)]
        [DisplayName("メールアドレス")]
        public string StoreMail { get; set; }

        [Column("DeleteFlg", TypeName = "bit", Order = 9)]
        [DisplayName("削除フラグ")]
        public bool DeleteFlg { get; set; }

        [MaxLength(80)]
        [Column("Comments", TypeName = "nvarchar", Order = 10)]
        [DisplayName("備考")]
        public string Comments { get; set; }
    }
}
