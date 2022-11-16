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
    class M_Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(5)]
        [Column("StaffCD", TypeName = "char", Order = 0)]
        [DisplayName("スタッフCD")]
        public string StaffCD { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("StaffName", TypeName = "nvarchar", Order = 1)]
        [DisplayName("スタッフ名")]
        public string StaffName { get; set; }

        [Required]
        [MaxLength(40)]
        [Column("StaffNameKana", TypeName = "nvarchar", Order = 2)]
        [DisplayName("スタッフカナ名")]
        public string StaffNameKana { get; set; }

        [MaxLength(7)]
        [Column("StaffPostal", TypeName = "varchar", Order = 3)]
        [DisplayName("郵便番号")]
        public string StaffPostal { get; set; }

        [MaxLength(50)]
        [Column("StaffAddress", TypeName = "nvarchar", Order = 4)]
        [DisplayName("住所")]
        public string StaffAddress { get; set; }

        [MaxLength(100)]
        [Column("StaffAddressKana", TypeName = "nvarchar", Order = 5)]
        [DisplayName("住所カナ")]
        public string StaffAddressKana { get; set; }

        [MaxLength(12)]
        [Column("StaffTel", TypeName = "nvarchar", Order = 6)]
        [DisplayName("電話番号")]
        public string StaffTel { get; set; }

        [MaxLength(12)]
        [Column("StaffMobileTel", TypeName = "nvarchar", Order = 7)]
        [DisplayName("携帯番号")]
        public string StaffMobileTel { get; set; }

        [MaxLength(30)]
        [Column("StaffMail", TypeName = "nvarchar", Order = 8)]
        [DisplayName("メールアドレス")]
        public string StaffMail { get; set; }

        [Column("StaffBirthday", TypeName = "date", Order = 9)]
        [DisplayName("生年月日")]
        public DateTime? StaffBirthday { get; set; }

        [Column("StaffJoinDate", TypeName = "date", Order = 10)]
        [DisplayName("入社日")]
        public DateTime? StaffJoinDate { get; set; }

	    [Required]
        [MaxLength(5)]
        [ForeignKey("M_Store"), Column("StoreCD", TypeName = "char", Order = 11)]
        [DisplayName("店舗CD")]
        public string StoreCD { get; set; }

	    [Required]
        [MaxLength(5)]
        [ForeignKey("M_Position"), Column("PositionCD", TypeName = "char", Order = 12)]
        [DisplayName("役職CD")]
        public string PositionCD { get; set; }

	    [Required]
        [MaxLength(5)]
        [ForeignKey("M_Division"), Column("DivisionCD", TypeName = "char", Order = 13)]
        [DisplayName("部署CD")]
        public string DivisionCD { get; set; }

	    [Required]
        [MaxLength(5)]
        [ForeignKey("M_Authority"), Column("AuthorityCD", TypeName = "char", Order = 14)]
        [DisplayName("権限CD")]
        public string AuthorityCD { get; set; }

        [Required]
        [MaxLength(18)]
        [Column("StaffUserID", TypeName = "nvarchar", Order = 15)]
        [DisplayName("ログインID")]
        public string StaffUserID { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("StaffPassword", TypeName = "nvarchar", Order = 16)]
        [DisplayName("ログインパスワード")]
        public string StaffPassword { get; set; }

        [Column("DeleteFlg", TypeName = "bit", Order = 17)]
        [DisplayName("削除フラグ")]
        public bool DeleteFlg { get; set; }

        [MaxLength(80)]
        [Column("Comments", TypeName = "nvarchar", Order = 18)]
        [DisplayName("備考")]
        public string Comments { get; set; }

        public virtual M_Store M_Store { get; set; }
        public virtual M_Position M_Position { get; set; }
        public virtual M_Division M_Division { get; set; }
        public virtual M_Authority M_Authority { get; set; }
    }
    //データグリッド表示用
    class M_StaffDsp
    {
        [DisplayName("スタッフCD")]
        public string StaffCD { get; set; }

        [DisplayName("スタッフ名")]
        public string StaffName { get; set; }

        [DisplayName("スタッフカナ")]
        public string StaffNameKana { get; set; }

        [DisplayName("郵便番号")]
        public string StaffPostal { get; set; }

        [DisplayName("住所")]
        public string StaffAddress { get; set; }

        [DisplayName("住所カナ")]
        public string StaffAddressKana { get; set; }

        [DisplayName("電話番号")]
        public string StaffTel { get; set; }

        [DisplayName("携帯番号")]
        public string StaffMobileTel { get; set; }

        [DisplayName("メールアドレス")]
        public string StaffMail { get; set; }

        [DisplayName("生年月日")]
        public DateTime? StaffBirthday { get; set; }

        [DisplayName("入社日")]
        public DateTime? StaffJoinDate { get; set; }

        [DisplayName("店舗CD")]
        public string StoreCD { get; set; }

        [DisplayName("店舗名")]
        public string StoreName { get; set; }

        [DisplayName("役職CD")]
        public string PositionCD { get; set; }

        [DisplayName("役職名")]
        public string PositionName { get; set; }

        [DisplayName("部署CD")]
        public string DivisionCD { get; set; }

        [DisplayName("部署名")]
        public string DivisionName { get; set; }

        [DisplayName("権限CD")]
        public string AuthorityCD { get; set; }

        [DisplayName("権限名")]
        public string AuthorityName { get; set; }

        [DisplayName("ログインID")]
        public string StaffUserID { get; set; }

        [DisplayName("ログインパスワード")]
        public string StaffPassword { get; set; }

        [DisplayName("削除フラグ")]
        public bool DeleteFlg { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }
    }
}
