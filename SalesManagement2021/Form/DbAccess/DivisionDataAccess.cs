using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement2021
{
    class DivisionDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckDivisionCDExistence()
        //引　数   ：部署コード
        //戻り値   ：True or False
        //機　能   ：一致する部署コードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckDivisionCDExistence(string divisionCD)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //部署CDで一致するデータが存在するか
                flg = context.M_Divisions.Any(x => x.DivisionCD == divisionCD);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：SelectDivisionExistenceCheck()
        //引　数   ：部署コード、部署名
        //戻り値   ：True or False
        //機　能   ：部分一致する部署コード、部署名の有無を確認
        //          ：部分一致データありの場合True
        //          ：部分一致データなしの場合False
        ///////////////////////////////
        public bool SelectDivisionExistenceCheck(string divisionCD, string divisionName)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //部署CD、部署名で部分一致するデータが存在するか
                flg = context.M_Divisions.Any(x => x.DivisionCD.Contains(divisionCD)
                                            && x.DivisionName.Contains(divisionName));
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddDivisionData()
        //引　数   ：部署データ
        //戻り値   ：True or False
        //機　能   ：部署データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddDivisionData(M_Division regDivision)
        {
            try
            {
                var context = new SalesManagementDbContext();
                context.M_Divisions.Add(regDivision);
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
        //メソッド名：UpdateDivisionData()
        //引　数   ：部署データ
        //戻り値   ：True or False
        //機　能   ：部署データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateDivisionData(M_Division updDivision)
        {
            try
            {
                var context = new SalesManagementDbContext();
                var division = context.M_Divisions.Single(x => x.DivisionCD == updDivision.DivisionCD);
                division.DivisionName = updDivision.DivisionName;
                division.DeleteFlg = updDivision.DeleteFlg;
                division.Comments = updDivision.Comments;

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
        //メソッド名：DeleteDivisionData()
        //引　数   ：部署データ
        //戻り値   ：True or False
        //機　能   ：部署データの削除
        //          ：削除成功の場合True
        //          ：削除失敗の場合False
        ///////////////////////////////
        public bool DeleteDivisionData(string delDivisionCD)
        {
            try
            {

                var context = new SalesManagementDbContext();
                var division = context.M_Divisions.Single(x => x.DivisionCD == delDivisionCD);
                context.M_Divisions.Remove(division);
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
        //引　数   ：部署CD
        //戻り値   ：True or False
        //機　能   ：部署CDがスタッフマスタでの利用可否
        //          ：利用されているの場合True
        //          ：利用されていない場合False
        ///////////////////////////////
        public bool CheckCascadeStaff(string divisionCD)
        {
            var context = new SalesManagementDbContext();
            //部署IDがスタッフマスタで利用されているか
            bool flg = context.M_Staffs.Any(x => x.DivisionCD == divisionCD);

            return flg;
        }

        ///////////////////////////////
        //メソッド名：GetDivisionData()
        //引　数   ：なし
        //戻り値   ：部署データ
        //機　能   ：部署データの取得
        ///////////////////////////////
        public List<M_Division> GetDivisionData()
        {
            List<M_Division> division = new List<M_Division>();
            try
            {
                var context = new SalesManagementDbContext();
                division = context.M_Divisions.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return division;

        }
        ///////////////////////////////
        //メソッド名：GetDivisionData()　オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致部署データ
        //機　能   ：条件一致部署データの取得
        ///////////////////////////////
        public List<M_Division> GetDivisionData(M_Division selectCondition)
        {
            List<M_Division> division = new List<M_Division>();
            try
            {
                var context = new SalesManagementDbContext();
                division = context.M_Divisions.Where(x => x.DivisionCD.Contains(selectCondition.DivisionCD) &&
                                                    x.DivisionName.Contains(selectCondition.DivisionName)).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return division;

        }
        ///////////////////////////////
        //メソッド名：GetDivisionDspData()
        //引　数   ：なし
        //戻り値   ：表示用部署データ
        //機　能   ：表示用部署データの取得
        ///////////////////////////////
        public List<M_Division> GetDivisionDspData()
        {
            List<M_Division> division = new List<M_Division>();
            try
            {
                var context = new SalesManagementDbContext();
                division = context.M_Divisions.Where(x => x.DeleteFlg == false).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return division;

        }
    }
}
