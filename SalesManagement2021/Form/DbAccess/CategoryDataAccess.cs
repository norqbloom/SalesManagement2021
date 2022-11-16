using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement2021
{
    class CategoryDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckCategoryCDExistence()
        //引　数   ：商品カテゴリコード
        //戻り値   ：True or False
        //機　能   ：一致する商品カテゴリコードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckCategoryCDExistence(string categoryCD)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //商品カテゴリCDで一致するデータが存在するか
                flg = context.M_Categorys.Any(x => x.CategoryCD == categoryCD);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：SelectCategoryExistenceCheck()
        //引　数   ：商品カテゴリコード、商品カテゴリ名
        //戻り値   ：True or False
        //機　能   ：部分一致する商品カテゴリコード、商品カテゴリ名の有無を確認
        //          ：部分一致データありの場合True
        //          ：部分一致データなしの場合False
        ///////////////////////////////
        public bool SelectCategoryExistenceCheck(string categoryCD, string categoryName)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //商品カテゴリCD、商品カテゴリ名で部分一致するデータが存在するか
                flg = context.M_Categorys.Any(x => x.CategoryCD.Contains(categoryCD)
                                            && x.CategoryName.Contains(categoryName));
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddCategoryData()
        //引　数   ：商品カテゴリデータ
        //戻り値   ：True or False
        //機　能   ：商品カテゴリデータの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddCategoryData(M_Category regCategory)
        {
            try
            {
                var context = new SalesManagementDbContext();
                context.M_Categorys.Add(regCategory);
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
        //メソッド名：UpdateCategoryData()
        //引　数   ：商品カテゴリデータ
        //戻り値   ：True or False
        //機　能   ：商品カテゴリデータの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateCategoryData(M_Category updCategory)
        {
            try
            {
                var context = new SalesManagementDbContext();
                var category = context.M_Categorys.Single(x => x.CategoryCD == updCategory.CategoryCD);
                category.ParentCategory = updCategory.ParentCategory;
                category.CategoryName = updCategory.CategoryName;
                category.CategoryKana = updCategory.CategoryKana;
                category.DeleteFlg = updCategory.DeleteFlg;
                category.Comments = updCategory.Comments;

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
        //メソッド名：DeleteCategoryData()
        //引　数   ：商品カテゴリデータ
        //戻り値   ：True or False
        //機　能   ：商品カテゴリデータの削除
        //          ：削除成功の場合True
        //          ：削除失敗の場合False
        ///////////////////////////////
        public bool DeleteCategoryData(string delCategoryCD)
        {
            try
            {

                var context = new SalesManagementDbContext();
                var category = context.M_Categorys.Single(x => x.CategoryCD == delCategoryCD);
                context.M_Categorys.Remove(category);
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
        /////////////////////////////////
        ////メソッド名：CheckCascadeItem()
        ////引　数   ：商品カテゴリCD
        ////戻り値   ：True or False
        ////機　能   ：商品カテゴリCDが商品マスタでの利用可否
        ////          ：利用されているの場合True
        ////          ：利用されていない場合False
        /////////////////////////////////
        public bool CheckCascadeItem(string categoryCD)
        {
            var context = new SalesManagementDbContext();
            //商品カテゴリCDが商品マスタで利用されているか
            bool flg = context.M_Items.Any(x => x.CategoryCD == categoryCD);

            return flg;
        }

        /////////////////////////////////
        ////メソッド名：CheckCascadeParentCategory()
        ////引　数   ：商品カテゴリCD
        ////戻り値   ：True or False
        ////機　能   ：商品カテゴリCDが親カテゴリとしての利用可否
        ////          ：利用されているの場合True
        ////          ：利用されていない場合False
        /////////////////////////////////
        public bool CheckCascadeParentCategory(string categoryCD)
        {
            var context = new SalesManagementDbContext();
            //商品カテゴリCDが親カテゴリとして利用されているか
            bool flg = context.M_Categorys.Any(x => x.ParentCategory == categoryCD);

            return flg;
        }


        ///////////////////////////////
        //メソッド名：GetCategoryData()
        //引　数   ：なし
        //戻り値   ：商品カテゴリデータ
        //機　能   ：商品カテゴリデータの取得
        ///////////////////////////////
        public List<M_Category> GetCategoryData()
        {
            List<M_Category> category = new List<M_Category>();
            try
            {
                var context = new SalesManagementDbContext();
                category = context.M_Categorys.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return category;

        }
        ///////////////////////////////
        //メソッド名：GetCategoryData()　オーバーロードdivision
        //引　数   ：検索条件
        //戻り値   ：条件一致商品カテゴリデータ
        //機　能   ：条件一致商品カテゴリデータの取得
        ///////////////////////////////
        public List<M_Category> GetCategoryData(M_Category selectCondition)
        {
            List<M_Category> category = new List<M_Category>();
            try
            {
                var context = new SalesManagementDbContext();
                category = context.M_Categorys.Where(x => x.ParentCategory.Contains(selectCondition.ParentCategory) &&
                                                    x.CategoryCD.Contains(selectCondition.CategoryCD) &&
                                                    x.CategoryName.Contains(selectCondition.CategoryName) &&
                                                    x.CategoryKana.Contains(selectCondition.CategoryKana)).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return category;

        }
        ///////////////////////////////
        //メソッド名：GetParentCategoryDspData()
        //引　数   ：なし
        //戻り値   ：表示用商品親カテゴリデータ
        //機　能   ：表示用商品親カテゴリデータの取得
        ///////////////////////////////
        public List<M_Category> GetParentCategoryDspData()
        {
            List<M_Category> category = new List<M_Category>();
            try
            {
                var context = new SalesManagementDbContext();
                category = context.M_Categorys.Where(x => x.ParentCategory == "" && x.DeleteFlg == false).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return category;

        }

        ///////////////////////////////
        //メソッド名：GetCategoryDspData()
        //引　数   ：なし
        //戻り値   ：表示用商品カテゴリデータ
        //機　能   ：表示用商品カテゴリデータの取得
        ///////////////////////////////
        public List<M_Category> GetCategoryDspData(string cmbValue)
        {
            List<M_Category> category = new List<M_Category>();
            try
            {
                var context = new SalesManagementDbContext();
                category = context.M_Categorys.Where(x => x.ParentCategory == cmbValue && x.DeleteFlg == false).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return category;

        }
        ///////////////////////////////
        //メソッド名：GetComboboxText()
        //引　数   ：なし
        //戻り値   ：カテゴリ名
        //機　能   ：カテゴリCDからカテゴリ名の取得
        ///////////////////////////////
        public string GetComboboxText(string cmbValue)
        {
            string cmbText = null;
            try
            {
                var context = new SalesManagementDbContext();
                //商品カテゴリCDで一致するカテゴリ名を取得
                cmbText = context.M_Categorys.Single(x => x.CategoryCD == cmbValue).CategoryName;
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return cmbText;
        }
    }
}
