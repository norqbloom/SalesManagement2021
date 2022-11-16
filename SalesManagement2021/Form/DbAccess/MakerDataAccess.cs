using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement2021
{
    class MakerDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckMakerCDExistence()
        //引　数   ：商品メーカコード
        //戻り値   ：True or False
        //機　能   ：一致する商品メーカコードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckMakerCDExistence(string makerCD)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //商品メーカCDで一致するデータが存在するか
                flg = context.M_Makers.Any(x => x.MakerCD == makerCD);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：SelectMakerExistenceCheck()
        //引　数   ：商品メーカコード、商品メーカ名
        //戻り値   ：True or False
        //機　能   ：部分一致する商品メーカコード、商品メーカ名の有無を確認
        //          ：部分一致データありの場合True
        //          ：部分一致データなしの場合False
        ///////////////////////////////
        public bool SelectMakerExistenceCheck(string makerCD, string makerName)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //商品メーカCD、商品メーカ名で部分一致するデータが存在するか
                flg = context.M_Makers.Any(x => x.MakerCD.Contains(makerCD)
                                            && x.MakerName.Contains(makerName));
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddMakerData()
        //引　数   ：商品メーカデータ
        //戻り値   ：True or False
        //機　能   ：商品メーカデータの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddMakerData(M_Maker regMaker)
        {
            try
            {
                var context = new SalesManagementDbContext();
                context.M_Makers.Add(regMaker);
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
        //メソッド名：UpdateMakerData()
        //引　数   ：商品メーカデータ
        //戻り値   ：True or False
        //機　能   ：商品メーカデータの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateMakerData(M_Maker updMaker)
        {
            try
            {
                var context = new SalesManagementDbContext();
                var maker = context.M_Makers.Single(x => x.MakerCD == updMaker.MakerCD);
                maker.MakerName = updMaker.MakerName;
                maker.MakerKana = updMaker.MakerKana;
                maker.DeleteFlg = updMaker.DeleteFlg;
                maker.Comments = updMaker.Comments;

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
        //メソッド名：DeleteMakerData()
        //引　数   ：商品メーカデータ
        //戻り値   ：True or False
        //機　能   ：商品メーカデータの削除
        //          ：削除成功の場合True
        //          ：削除失敗の場合False
        ///////////////////////////////
        public bool DeleteMakerData(string delMakerCD)
        {
            try
            {

                var context = new SalesManagementDbContext();
                var maker = context.M_Makers.Single(x => x.MakerCD == delMakerCD);
                context.M_Makers.Remove(maker);
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
        //引　数   ：商品メーカCD
        //戻り値   ：True or False
        //機　能   ：商品メーカCDがスタッフマスタでの利用可否
        //          ：利用されているの場合True
        //          ：利用されていない場合False
        ///////////////////////////////
        public bool CheckCascadeItem(string makerCD)
        {
            var context = new SalesManagementDbContext();
            //商品メーカIDがスタッフマスタで利用されているか
            bool flg = context.M_Items.Any(x => x.MakerCD == makerCD);

            return flg;
        }

        ///////////////////////////////
        //メソッド名：GetMakerData()
        //引　数   ：なし
        //戻り値   ：商品メーカデータ
        //機　能   ：商品メーカデータの取得
        ///////////////////////////////
        public List<M_Maker> GetMakerData()
        {
            List<M_Maker> maker = new List<M_Maker>();
            try
            {
                var context = new SalesManagementDbContext();
                maker = context.M_Makers.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return maker;

        }
        ///////////////////////////////
        //メソッド名：GetMakerData()　オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致商品メーカデータ
        //機　能   ：条件一致商品メーカデータの取得
        ///////////////////////////////
        public List<M_Maker> GetMakerData(M_Maker selectCondition)
        {
            List<M_Maker> maker = new List<M_Maker>();
            try
            {
                var context = new SalesManagementDbContext();
                maker = context.M_Makers.Where(x => x.MakerCD.Contains(selectCondition.MakerCD) &&
                                                    x.MakerName.Contains(selectCondition.MakerName) &&
                                                    x.MakerKana.Contains(selectCondition.MakerKana)).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return maker;

        }
        ///////////////////////////////
        //メソッド名：GetMakerDspData()
        //引　数   ：なし
        //戻り値   ：表示用商品メーカデータ
        //機　能   ：表示用商品メーカデータの取得
        ///////////////////////////////
        public List<M_Maker> GetMakerDspData()
        {
            List<M_Maker> maker = new List<M_Maker>();
            try
            {
                var context = new SalesManagementDbContext();
                maker = context.M_Makers.Where(x => x.DeleteFlg == false).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return maker;

        }
    }
}
