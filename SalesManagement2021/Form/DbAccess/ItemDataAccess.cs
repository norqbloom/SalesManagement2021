using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement2021
{
    class ItemDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckItemCDExistence()
        //引　数   ：商品コード
        //戻り値   ：True or False
        //機　能   ：一致する商品コードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckItemCDExistence(string itemCD)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //商品CDで一致するデータが存在するか
                flg = context.M_Items.Any(x => x.ItemCD == itemCD);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddItemData()
        //引　数   ：商品データ
        //戻り値   ：True or False
        //機　能   ：商品データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddItemData(M_Item regItem)
        {
            try
            {
                var context = new SalesManagementDbContext();
                context.M_Items.Add(regItem);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        ///////////////////////////////
        //メソッド名：UpdateItemData()
        //引　数   ：商品データ
        //戻り値   ：True or False
        //機　能   ：商品データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateItemData(M_Item updItem)
        {
            try
            {
                var context = new SalesManagementDbContext();
                var item = context.M_Items.Single(x => x.ItemCD == updItem.ItemCD);

                item.ItemName = updItem.ItemName;
                item.ItemKana = updItem.ItemKana;
                item.CategoryCD = updItem.CategoryCD;
                item.JanCD = updItem.JanCD;
                item.MakerCD = updItem.MakerCD;
                item.ModelNo = updItem.ModelNo;
                item.ListPrice = updItem.ListPrice;
                item.SellingPrice = updItem.SellingPrice;
                item.DeleteFlg = updItem.DeleteFlg;
                item.Comments = updItem.Comments;

                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        ///////////////////////////////
        //メソッド名：DeleteItemData()
        //引　数   ：商品データ
        //戻り値   ：True or False
        //機　能   ：商品データの削除
        //          ：削除成功の場合True
        //          ：削除失敗の場合False
        ///////////////////////////////
        public bool DeleteItemData(string delItemCD)
        {
            try
            {

                var context = new SalesManagementDbContext();
                var item = context.M_Items.Single(x => x.ItemCD == delItemCD);
                context.M_Items.Remove(item);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        ///////////////////////////////
        //メソッド名：GetItemData()
        //引　数   ：なし
        //戻り値   ：全商品データ
        //機　能   ：全商品データの取得
        ///////////////////////////////
        public List<M_ItemDsp> GetItemData()
        {
            List<M_ItemDsp> item = new List<M_ItemDsp>();

            try
            {

                var context = new SalesManagementDbContext();
                // tbはIEnumerable型
                var tb = from t1 in context.M_Items
                         join t2 in context.M_Categorys
                         on t1.CategoryCD equals t2.CategoryCD
                         join t3 in context.M_Makers
                         on t1.MakerCD equals t3.MakerCD

                         select new
                         {
                             t1.ItemCD,
                             t1.ItemName,
                             t1.ItemKana,
                             t2.ParentCategory,
                             ParentCategoryName = (context.M_Categorys.FirstOrDefault(x=> x.CategoryCD == t2.ParentCategory)).CategoryName,
                             t1.CategoryCD,
                             t2.CategoryName,
                             t1.JanCD,
                             t1.MakerCD,
                             t3.MakerName,
                             t1.ModelNo,
                             t1.ListPrice,
                             t1.SellingPrice,
                             t1.DeleteFlg,
                             t1.Comments

                         };

                // IEnumerable型のデータをList型へ
                foreach (var p in tb)
                {
                    item.Add(new M_ItemDsp()
                    {
                        ItemCD = p.ItemCD,
                        ItemName = p.ItemName,
                        ItemKana = p.ItemKana,
                        ParentCategoryCD = p.ParentCategory,
                        PanrentCategoryName = p.ParentCategoryName,
                        CategoryCD = p.CategoryCD,
                        CategoryName = p.CategoryName,
                        JanCD = p.JanCD,
                        MakerCD = p.MakerCD,
                        MakerName = p.MakerName,
                        ModelNo = p.ModelNo,
                        ListPrice = p.ListPrice,
                        SellingPrice = p.SellingPrice,
                        DeleteFlg = p.DeleteFlg,
                        Comments = p.Comments
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return item;

        }
        ///////////////////////////////
        //メソッド名：GetItemData()　オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致商品データ
        //機　能   ：条件一致商品データの取得
        ///////////////////////////////
        public List<M_ItemDsp> GetItemData(M_ItemDsp selectCondition)
        {
            List<M_ItemDsp> item = new List<M_ItemDsp>();

            try
            {

                var context = new SalesManagementDbContext();
                // tbはIEnumerable型
                var tb = from t1 in context.M_Items
                         join t2 in context.M_Categorys
                         on t1.CategoryCD equals t2.CategoryCD
                         join t3 in context.M_Makers
                         on t1.MakerCD equals t3.MakerCD
                         where t1.ItemCD.Contains(selectCondition.ItemCD) &&
                                t1.ItemName.Contains(selectCondition.ItemName) &&
                                t1.ItemKana.Contains(selectCondition.ItemKana) &&
                                t1.CategoryCD.Contains(selectCondition.CategoryCD) &&
                                t1.MakerCD.Contains(selectCondition.MakerCD) &&
                                t1.ModelNo.Contains(selectCondition.ModelNo)
                         select new
                         {
                             t1.ItemCD,
                             t1.ItemName,
                             t1.ItemKana,
                             t2.ParentCategory,
                             ParentCategoryName = (context.M_Categorys.FirstOrDefault(x => x.CategoryCD == t2.ParentCategory)).CategoryName,
                             t1.CategoryCD,
                             t2.CategoryName,
                             t1.JanCD,
                             t1.MakerCD,
                             t3.MakerName,
                             t1.ModelNo,
                             t1.ListPrice,
                             t1.SellingPrice,
                             t1.DeleteFlg,
                             t1.Comments

                         };

                // IEnumerable型のデータをList型へ
                foreach (var p in tb)
                {
                    item.Add(new M_ItemDsp()
                    {
                        ItemCD = p.ItemCD,
                        ItemName = p.ItemName,
                        ItemKana = p.ItemKana,
                        ParentCategoryCD = p.ParentCategory,
                        PanrentCategoryName = p.ParentCategoryName,
                        CategoryCD = p.CategoryCD,
                        CategoryName = p.CategoryName,
                        JanCD = p.JanCD,
                        MakerCD = p.MakerCD,
                        MakerName = p.MakerName,
                        ModelNo = p.ModelNo,
                        ListPrice = p.ListPrice,
                        SellingPrice = p.SellingPrice,
                        DeleteFlg = p.DeleteFlg,
                        Comments = p.Comments
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return item;

        }
    }
}
