using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement2021
{
    class PositionDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckPositionCDExistence()
        //引　数   ：役職コード
        //戻り値   ：True or False
        //機　能   ：一致する役職コードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckPositionCDExistence(string positionCD)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //役職CDで一致するデータが存在するか
                flg = context.M_Positions.Any(x => x.PositionCD == positionCD);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：SelectPositionExistenceCheck()
        //引　数   ：役職コード、役職名
        //戻り値   ：True or False
        //機　能   ：部分一致する役職コード、役職名の有無を確認
        //          ：部分一致データありの場合True
        //          ：部分一致データなしの場合False
        ///////////////////////////////
        public bool SelectPositionExistenceCheck(string positionCD, string positionName)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //役職CD、役職名で部分一致するデータが存在するか
                flg = context.M_Positions.Any(x => x.PositionCD.Contains(positionCD)
                                            && x.PositionName.Contains(positionName));
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddPositionData()
        //引　数   ：役職データ
        //戻り値   ：True or False
        //機　能   ：役職データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddPositionData(M_Position regPosition)
        {
            try
            {
                var context = new SalesManagementDbContext();
                context.M_Positions.Add(regPosition);
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
        //メソッド名：UpdatePositionData()
        //引　数   ：役職データ
        //戻り値   ：True or False
        //機　能   ：役職データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdatePositionData(M_Position updPosition)
        {
            try
            {
                var context = new SalesManagementDbContext();
                var position = context.M_Positions.Single(x => x.PositionCD == updPosition.PositionCD);
                position.PositionName = updPosition.PositionName;
                position.DeleteFlg = updPosition.DeleteFlg;
                position.Comments = updPosition.Comments;

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
        //メソッド名：DeletePositionData()
        //引　数   ：役職データ
        //戻り値   ：True or False
        //機　能   ：役職データの削除
        //          ：削除成功の場合True
        //          ：削除失敗の場合False
        ///////////////////////////////
        public bool DeletePositionData(string delPositionCD)
        {
            try
            {

                var context = new SalesManagementDbContext();
                var position = context.M_Positions.Single(x => x.PositionCD == delPositionCD);
                context.M_Positions.Remove(position);
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
        //引　数   ：役職CD
        //戻り値   ：True or False
        //機　能   ：役職CDがスタッフマスタでの利用可否
        //          ：利用されているの場合True
        //          ：利用されていない場合False
        ///////////////////////////////
        public bool CheckCascadeStaff(string positionCD)
        {
            var context = new SalesManagementDbContext();
            //役職IDがスタッフマスタで利用されているか
            bool flg = context.M_Staffs.Any(x => x.PositionCD == positionCD);

            return flg;
        }

        ///////////////////////////////
        //メソッド名：GetPositionData()
        //引　数   ：なし
        //戻り値   ：役職データ
        //機　能   ：役職データの取得
        ///////////////////////////////
        public List<M_Position> GetPositionData()
        {
            List<M_Position> position = null;
            try
            {
                var context = new SalesManagementDbContext();
                position = context.M_Positions.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return position;

        }
        ///////////////////////////////
        //メソッド名：GetPositionData()　オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致部署データ
        //機　能   ：条件一致部署データの取得
        ///////////////////////////////
        public List<M_Position> GetPositionData(M_Position selectCondition)
        {
            List<M_Position> position = new List<M_Position>();
            try
            {
                var context = new SalesManagementDbContext();
                position = context.M_Positions.Where(x => x.PositionCD.Contains(selectCondition.PositionCD) &&
                                                    x.PositionName.Contains(selectCondition.PositionName)).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return position;

        }
        ///////////////////////////////
        //メソッド名：GetPositionDspData()
        //引　数   ：なし
        //戻り値   ：表示用役職データ
        //機　能   ：表示用役職データの取得
        ///////////////////////////////
        public List<M_Position> GetPositionDspData()
        {
            List<M_Position> position = null;
            try
            {
                var context = new SalesManagementDbContext();
                position = context.M_Positions.Where(x => x.DeleteFlg == false).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return position;

        }
    }
}
