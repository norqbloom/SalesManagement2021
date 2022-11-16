using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement2021
{
    class StoreDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckStoreCDExistence()
        //引　数   ：店舗コード
        //戻り値   ：True or False
        //機　能   ：一致する店舗コードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckStoreCDExistence(string storeCD)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //店舗CDで一致するデータが存在するか
                flg = context.M_Stores.Any(x => x.StoreCD == storeCD);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：SelectStoreExistenceCheck()
        //引　数   ：店舗コード、店舗名
        //戻り値   ：True or False
        //機　能   ：部分一致する店舗コード、店舗名の有無を確認
        //          ：部分一致データありの場合True
        //          ：部分一致データなしの場合False
        ///////////////////////////////
        public bool SelectStoreExistenceCheck(string storeCD, string storeName)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //店舗CD、店舗名で部分一致するデータが存在するか
                flg = context.M_Stores.Any(x => x.StoreCD.Contains(storeCD)
                                            && x.StoreName.Contains(storeName));
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddStoreData()
        //引　数   ：店舗データ
        //戻り値   ：True or False
        //機　能   ：店舗データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddStoreData(M_Store regStore)
        {
            try
            {
                var context = new SalesManagementDbContext();
                context.M_Stores.Add(regStore);
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
        //メソッド名：UpdateStoreData()
        //引　数   ：店舗データ
        //戻り値   ：True or False
        //機　能   ：店舗データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateStoreData(M_Store updStore)
        {
            try
            {
                var context = new SalesManagementDbContext();
                var store = context.M_Stores.Single(x => x.StoreCD == updStore.StoreCD);
                store.StoreName = updStore.StoreName;
                store.StoreNameKana = updStore.StoreNameKana;
                store.StorePostal = updStore.StorePostal;
                store.StoreAddress = updStore.StoreAddress;
                store.StoreAddressKana = updStore.StoreAddressKana;
                store.StoreTel = updStore.StoreTel;
                store.StoreFax = updStore.StoreFax;
                store.StoreMail = updStore.StoreMail;
                store.DeleteFlg = updStore.DeleteFlg;
                store.Comments = updStore.Comments;

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
        //メソッド名：DeleteStoreData()
        //引　数   ：店舗データ
        //戻り値   ：True or False
        //機　能   ：店舗データの削除
        //          ：削除成功の場合True
        //          ：削除失敗の場合False
        ///////////////////////////////
        public bool DeleteStoreData(string delStoreCD)
        {
            try
            {

                var context = new SalesManagementDbContext();
                var store = context.M_Stores.Single(x => x.StoreCD == delStoreCD);
                context.M_Stores.Remove(store);
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
        //メソッド名：CheckCascadeStaff()
        //引　数   ：店舗CD
        //戻り値   ：True or False
        //機　能   ：店舗CDがスタッフマスタでの利用可否
        //          ：利用されているの場合True
        //          ：利用されていない場合False
        ///////////////////////////////
        public bool CheckCascadeStaff(string storeCD)
        {
            var context = new SalesManagementDbContext();
            //店舗IDがスタッフマスタで利用されているか
            bool flg = context.M_Staffs.Any(x => x.StoreCD == storeCD);

            return flg;
        }

        ///////////////////////////////
        //メソッド名：GetStoreData()
        //引　数   ：なし
        //戻り値   ：店舗データ
        //機　能   ：店舗データの取得
        ///////////////////////////////
        public List<M_Store> GetStoreData()
        {
            List<M_Store> store = new List<M_Store>();
            try
            {
                var context = new SalesManagementDbContext();
                store = context.M_Stores.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return store;

        }
        ///////////////////////////////
        //メソッド名：GetStoreData()　オーバーロード
        //引　数   ：なし
        //戻り値   ：店舗データ
        //機　能   ：店舗データの取得
        ///////////////////////////////
        public List<M_Store> GetStoreData(M_Store selectCondition)
        {
            List<M_Store> store = new List<M_Store>();
            try
            {
                var context = new SalesManagementDbContext();
                store = context.M_Stores.Where(x => x.StoreCD.Contains(selectCondition.StoreCD) &&
                                                    x.StoreName.Contains(selectCondition.StoreName) &&
                                                    x.StoreNameKana.Contains(selectCondition.StoreNameKana) &&
                                                    x.StoreAddress.Contains(selectCondition.StoreAddress) &&
                                                    x.StoreAddressKana.Contains(selectCondition.StoreAddressKana)).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return store;

        }

        ///////////////////////////////
        //メソッド名：GetStoreDspData()
        //引　数   ：なし
        //戻り値   ：表示用店舗データ
        //機　能   ：表示用の店舗データの取得
        ///////////////////////////////
        public List<M_Store> GetStoreDspData()
        {
            List<M_Store> store = new List<M_Store>();
            try
            {
                var context = new SalesManagementDbContext();
                store = context.M_Stores.Where(x => x.DeleteFlg == false).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return store;

        }
    }
}
