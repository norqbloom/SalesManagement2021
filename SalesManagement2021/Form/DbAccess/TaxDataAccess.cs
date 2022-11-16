using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement2021
{
    class TaxDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckTaxCDExistence()
        //引　数   ：消費税ID
        //戻り値   ：True or False
        //機　能   ：一致する消費税IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckTaxCDExistence(int taxID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //消費税CDで一致するデータが存在するか
                flg = context.M_Taxs.Any(x => x.M_TaxID == taxID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：SelectTaxExistenceCheck()
        //引　数   ：消費税率
        //戻り値   ：True or False
        //機　能   ：一致する消費率の有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool SelectTaxExistenceCheck(int tax)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //消費税CD、消費税名で部分一致するデータが存在するか
                flg = context.M_Taxs.Any(x => x.Tax == tax);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddTaxData()
        //引　数   ：消費税データ
        //戻り値   ：True or False
        //機　能   ：消費税データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddTaxData(M_Tax regTax)
        {
            try
            {
                var context = new SalesManagementDbContext();
                context.M_Taxs.Add(regTax);
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
        //メソッド名：UpdateTaxData()
        //引　数   ：消費税データ
        //戻り値   ：True or False
        //機　能   ：消費税データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateTaxData(M_Tax updTax)
        {
            try
            {
                var context = new SalesManagementDbContext();
                var tax = context.M_Taxs.Single(x => x.M_TaxID == updTax.M_TaxID);
                tax.Tax = updTax.Tax;
                tax.ModifyDate = updTax.ModifyDate;
                tax.DeleteFlg = updTax.DeleteFlg;
                tax.Comments = updTax.Comments;

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
        //メソッド名：DeleteTaxData()
        //引　数   ：消費税データ
        //戻り値   ：True or False
        //機　能   ：消費税データの削除
        //          ：削除成功の場合True
        //          ：削除失敗の場合False
        ///////////////////////////////
        public bool DeleteTaxData(int delTaxID)
        {
            try
            {

                var context = new SalesManagementDbContext();
                var tax = context.M_Taxs.Single(x => x.M_TaxID == delTaxID);
                context.M_Taxs.Remove(tax);
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
        ////メソッド名：CheckCascadeStaff()
        ////引　数   ：消費税CD
        ////戻り値   ：True or False
        ////機　能   ：消費税CDがスタッフマスタでの利用可否
        ////          ：利用されているの場合True
        ////          ：利用されていない場合False
        /////////////////////////////////
        //public bool CheckCascadeStaff(int taxID)
        //{
        //    var context = new SalesManagementDbContext();
        //    //消費税IDがスタッフマスタで利用されているか
        //    bool flg = context.M_Staffs.Any(x => x.M_TaxID == taxID);

        //    return flg;
        //}

        ///////////////////////////////
        //メソッド名：GetTaxData()
        //引　数   ：なし
        //戻り値   ：消費税データ
        //機　能   ：消費税データの取得
        ///////////////////////////////
        public List<M_Tax> GetTaxData()
        {
            List<M_Tax> tax = new List<M_Tax>();
            try
            {
                var context = new SalesManagementDbContext();
                tax = context.M_Taxs.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tax;

        }
        ///////////////////////////////
        //メソッド名：GetTaxData()　オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致消費税データ
        //機　能   ：条件一致消費税データの取得
        ///////////////////////////////
        public List<M_Tax> GetTaxData(M_Tax selectCondition)
        {
            List<M_Tax> tax = new List<M_Tax>();
            try
            {
                var context = new SalesManagementDbContext();
                tax = context.M_Taxs.Where(x => x.M_TaxID == selectCondition.M_TaxID).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tax;

        }
        ///////////////////////////////
        //メソッド名：GetTaxDspData()
        //引　数   ：なし
        //戻り値   ：表示用消費税データ
        //機　能   ：表示用消費税データの取得
        ///////////////////////////////
        public List<M_Tax> GetTaxDspData()
        {
            List<M_Tax> tax = new List<M_Tax>();
            try
            {
                var context = new SalesManagementDbContext();
                tax = context.M_Taxs.Where(x => x.DeleteFlg == false).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tax;

        }
    }
}
