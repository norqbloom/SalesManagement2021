using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement2021
{
    class AuthorityDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetAuthorityData()
        //引　数   ：なし
        //戻り値   ：権限データ
        //機　能   ：権限データの取得
        ///////////////////////////////
        public List<M_Authority> GetAuthorityData()
        {
            List<M_Authority> authority = null;
            try
            {
                var context = new SalesManagementDbContext();
                authority = context.M_Authoritys.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return authority;

        }
        ///////////////////////////////
        //メソッド名：GetAuthorityDspData()
        //引　数   ：なし
        //戻り値   ：表示用権限データ
        //機　能   ：表示用権限データの取得
        ///////////////////////////////
        public List<M_Authority> GetAuthorityDspData()
        {
            List<M_Authority> authority = null;
            try
            {
                var context = new SalesManagementDbContext();
                authority = context.M_Authoritys.Where(x => x.DeleteFlg == false).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return authority;

        }
    }
}
