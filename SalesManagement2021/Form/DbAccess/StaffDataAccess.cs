using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace SalesManagement2021
{
    class StaffDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckStaffCDExistence()
        //引　数   ：スタッフコード
        //戻り値   ：True or False
        //機　能   ：一致するスタッフコードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckStaffCDExistence(string staffCD)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //スタッフCDで一致するデータが存在するか
                flg = context.M_Staffs.Any(x => x.StaffCD == staffCD);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：CheckUserIDExistenceCount()
        //引　数   ：スタッフログインID
        //戻り値   ：True or False
        //機　能   ：一致するスタッフコードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckUserIDExistenceCount(string userID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //ログインユーザIDで一致するデータが存在するか
                flg = context.M_Staffs.Any(x => x.StaffUserID == userID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }


        ///////////////////////////////
        //メソッド名：SelectStaffExistenceCheck()
        //引　数   ：スタッフコード、スタッフ名
        //戻り値   ：True or False
        //機　能   ：部分一致するスタッフコード、スタッフ名の有無を確認
        //          ：部分一致データありの場合True
        //          ：部分一致データなしの場合False
        ///////////////////////////////
        public bool SelectStaffExistenceCheck(string staffCD, string staffName)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementDbContext();
                //スタッフCD、スタッフ名で部分一致するデータが存在するか
                flg = context.M_Staffs.Any(x => x.StaffCD.Contains(staffCD)
                                            && x.StaffName.Contains(staffName));
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddStaffData()
        //引　数   ：スタッフデータ
        //戻り値   ：True or False
        //機　能   ：スタッフデータの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddStaffData(M_Staff regStaff)
        {
            try
            {
                var context = new SalesManagementDbContext();
                context.M_Staffs.Add(regStaff);
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
        //メソッド名：UpdateStaffData()
        //引　数   ：スタッフデータ
        //戻り値   ：True or False
        //機　能   ：スタッフデータの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateStaffData(M_Staff updStaff)
        {
            try
            {
                var context = new SalesManagementDbContext();
                var staff = context.M_Staffs.Single(x => x.StaffCD == updStaff.StaffCD);

                staff.StaffName = updStaff.StaffName;
                staff.StaffNameKana = updStaff.StaffNameKana;
                staff.StaffPostal = updStaff.StaffPostal;
                staff.StaffAddress = updStaff.StaffAddress;
                staff.StaffAddressKana = updStaff.StaffAddressKana;
                staff.StaffTel = updStaff.StaffTel;
                staff.StaffBirthday = updStaff.StaffBirthday;
                staff.StaffJoinDate = updStaff.StaffJoinDate;
                staff.StoreCD = updStaff.StoreCD;
                staff.PositionCD = updStaff.PositionCD;
                staff.DivisionCD = updStaff.DivisionCD;
                staff.AuthorityCD = updStaff.AuthorityCD;
                staff.StaffUserID = updStaff.StaffUserID;
                // パスワード入力時のみ更新
                if(!String.IsNullOrEmpty(updStaff.StaffPassword))
                    staff.StaffPassword = updStaff.StaffPassword;
                staff.DeleteFlg = updStaff.DeleteFlg;
                staff.Comments = updStaff.Comments;

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
        //メソッド名：DeleteStaffData()
        //引　数   ：スタッフデータ
        //戻り値   ：True or False
        //機　能   ：スタッフデータの削除
        //          ：削除成功の場合True
        //          ：削除失敗の場合False
        ///////////////////////////////
        public bool DeleteStaffData(string delStaffCD)
        {
            try
            {

                var context = new SalesManagementDbContext();
                var staff = context.M_Staffs.Single(x => x.StaffCD == delStaffCD);
                context.M_Staffs.Remove(staff);
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
        //引　数   ：スタッフCD
        //戻り値   ：True or False
        //機　能   ：スタッフCDがスタッフマスタでの利用可否
        //          ：利用されているの場合True
        //          ：利用されていない場合False
        ///////////////////////////////
        //public bool CheckCascadeStaff(string staffCD)
        //{
        //    var context = new SalesManagementDbContext();
        //    //スタッフIDがスタッフマスタで利用されているか
        //    bool flg = context.M_Staffs.Any(x => x.StaffCD == staffCD);

        //    return flg;
        //}

        ///////////////////////////////
        //メソッド名：GetStaffData()
        //引　数   ：なし
        //戻り値   ：全スタッフデータ
        //機　能   ：全スタッフデータの取得
        ///////////////////////////////
        public List<M_StaffDsp> GetStaffData()
        {
            List<M_StaffDsp> staff = new List<M_StaffDsp>();

            try
            {

                var context = new SalesManagementDbContext();
                // tbはIEnumerable型
                var tb = from t1 in context.M_Staffs
                         join t2 in context.M_Stores
                         on t1.StoreCD equals t2.StoreCD
                         join t3 in context.M_Positions
                         on t1.PositionCD equals t3.PositionCD
                         join t4 in context.M_Divisions
                         on t1.DivisionCD equals t4.DivisionCD
                         join t5 in context.M_Authoritys
                         on t1.AuthorityCD equals t5.AuthorityCD
                         select new
                         {
                             t1.StaffCD,
                             t1.StaffName,
                             t1.StaffNameKana,
                             t1.StaffPostal,
                             t1.StaffAddress,
                             t1.StaffAddressKana,
                             t1.StaffTel,
                             t1.StaffMobileTel,
                             t1.StaffMail,
                             t1.StaffBirthday,
                             t1.StaffJoinDate,
                             t1.StoreCD,
                             t2.StoreName,
                             t1.PositionCD,
                             t3.PositionName,
                             t1.DivisionCD,
                             t4.DivisionName,
                             t1.AuthorityCD,
                             t5.AuthorityName,
                             t1.StaffUserID,
                             t1.StaffPassword,
                             t1.DeleteFlg,
                             t1.Comments

                         };

                // IEnumerable型のデータをList型へ
                foreach (var p in tb)
                {
                    staff.Add(new M_StaffDsp()
                    {
                        StaffCD = p.StaffCD,
                        StaffName = p.StaffName,
                        StaffNameKana = p.StaffNameKana,
                        StaffPostal = p.StaffPostal,
                        StaffAddress = p.StaffAddress,
                        StaffAddressKana = p.StaffAddressKana,
                        StaffTel = p.StaffTel,
                        StaffMobileTel = p.StaffMobileTel,
                        StaffMail = p.StaffMail,
                        StaffBirthday = p.StaffBirthday,
                        StaffJoinDate = p.StaffJoinDate,
                        StoreCD = p.StoreCD,
                        StoreName = p.StoreName,
                        PositionCD = p.PositionCD,
                        PositionName = p.PositionName,
                        DivisionCD = p.DivisionCD,
                        DivisionName = p.DivisionName,
                        AuthorityCD = p.AuthorityCD,
                        AuthorityName = p.AuthorityName,
                        StaffUserID = p.StaffUserID,
                        StaffPassword = p.StaffPassword,
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
            return staff;

        }
        ///////////////////////////////
        //メソッド名：GetStaffData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致スタッフデータ
        //機　能   ：条件一致スタッフデータの取得
        ///////////////////////////////
        public List<M_StaffDsp> GetStaffData(M_StaffDsp selectCondition)
        {
            List<M_StaffDsp> staff = new List<M_StaffDsp>();

            try
            {

                var context = new SalesManagementDbContext();
                // tbはIEnumerable型
                var tb = from t1 in context.M_Staffs
                         join t2 in context.M_Stores
                         on t1.StoreCD equals t2.StoreCD
                         join t3 in context.M_Positions
                         on t1.PositionCD equals t3.PositionCD
                         join t4 in context.M_Divisions
                         on t1.DivisionCD equals t4.DivisionCD
                         join t5 in context.M_Authoritys
                         on t1.AuthorityCD equals t5.AuthorityCD
                          where t1.StaffCD.Contains(selectCondition.StaffCD) &&
                                t1.StaffName.Contains(selectCondition.StaffName) &&
                                t1.StaffNameKana.Contains(selectCondition.StaffNameKana) &&
                                t1.StaffAddress.Contains(selectCondition.StaffAddress) &&
                                t1.StaffAddressKana.Contains(selectCondition.StaffAddressKana) &&
                                t1.StoreCD.Contains(selectCondition.StoreCD) &&
                                t1.PositionCD.Contains(selectCondition.PositionCD) &&
                                t1.DivisionCD.Contains(selectCondition.DivisionCD) &&
                                t1.AuthorityCD.Contains(selectCondition.AuthorityCD) &&
                                t1.StaffUserID.Contains(selectCondition.StaffUserID)
                          select new
                          {
                              t1.StaffCD,
                              t1.StaffName,
                              t1.StaffNameKana,
                              t1.StaffPostal,
                              t1.StaffAddress,
                              t1.StaffAddressKana,
                              t1.StaffTel,
                              t1.StaffMobileTel,
                              t1.StaffMail,
                              t1.StaffBirthday,
                              t1.StaffJoinDate,
                              t1.StoreCD,
                              t2.StoreName,
                              t1.PositionCD,
                              t3.PositionName,
                              t1.DivisionCD,
                              t4.DivisionName,
                              t1.AuthorityCD,
                              t5.AuthorityName,
                              t1.StaffUserID,
                              t1.StaffPassword,
                              t1.DeleteFlg,
                              t1.Comments
                              
                          };

                // IEnumerable型のデータをList型へ
                foreach (var p in tb)
                {
                    staff.Add(new M_StaffDsp()
                    {
                        StaffCD = p.StaffCD,
                        StaffName = p.StaffName,
                        StaffNameKana = p.StaffNameKana,
                        StaffPostal = p.StaffPostal,
                        StaffAddress = p.StaffAddress,
                        StaffAddressKana = p.StaffAddressKana,
                        StaffTel = p.StaffTel,
                        StaffMobileTel = p.StaffMobileTel,
                        StaffMail = p.StaffMail,
                        StaffBirthday = p.StaffBirthday,
                        StaffJoinDate = p.StaffJoinDate,
                        StoreCD = p.StoreCD,
                        StoreName = p.StoreName,
                        PositionCD = p.PositionCD,
                        PositionName = p.PositionName,
                        DivisionCD = p.DivisionCD,
                        DivisionName = p.DivisionName,
                        AuthorityCD = p.AuthorityCD,
                        AuthorityName = p.AuthorityName,
                        StaffUserID = p.StaffUserID,
                        StaffPassword = p.StaffPassword,
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
            return staff;

        }
 
    }
}
