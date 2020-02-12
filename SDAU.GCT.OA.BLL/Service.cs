
using SDAU.GCT.OA.DAL;
using SDAU.GCT.OA.DALFactory;
using SDAU.GCT.OA.IBLL;
using SDAU.GCT.OA.IDAL;
using SDAU.GCT.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace SDAU.GCT.OA.BLL
{
	
	  public partial class ActionInfoService : BaseService<ActionInfo>, IActionInfoService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.ActionInfoDal;
        }
        public bool SetRole(int userId, List<int> roleInfoList)
        {
            var action = DbSession.ActionInfoDal.GetEntities(u => u.Id == userId).FirstOrDefault();
            action.RoleInfo.Clear();//全部删除。

            var allRoles = DbSession.RoleInfoDal.GetEntities(r => roleInfoList.Contains(r.Id));
            foreach (var roleInfo in allRoles)
            {
                action.RoleInfo.Add(roleInfo);//加最新的角色。
            }
            DbSession.Savechanges();
            return true;


        }
    }
	
	  public partial class LogInfoService : BaseService<LogInfo>, ILogInfoService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.LogInfoDal;
        }
		}
	
	  public partial class PlantImageService : BaseService<PlantImage>, IPlantImageService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.PlantImageDal;
        }
		}
	
	  public partial class PlantInfoService : BaseService<PlantInfo>, IPlantInfoService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.PlantInfoDal;
        }
		}
	
	  public partial class R_UserInfo_ActionInfoService : BaseService<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.R_UserInfo_ActionInfoDal;
        }
		}
	
	  public partial class RoleInfoService : BaseService<RoleInfo>, IRoleInfoService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.RoleInfoDal;
        }
		}
	
	  public partial class UserCommentService : BaseService<UserComment>, IUserCommentService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.UserCommentDal;
        }
		}
	
	  public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.UserInfoDal;
        }
        public bool SetRole(int userId, List<int> roleInfoList)
        {
            var action = DbSession.ActionInfoDal.GetEntities(u => u.Id == userId).FirstOrDefault();
            action.RoleInfo.Clear();//全部删除。

            var allRoles = DbSession.RoleInfoDal.GetEntities(r => roleInfoList.Contains(r.Id));
            foreach (var roleInfo in allRoles)
            {
                action.RoleInfo.Add(roleInfo);//加最新的角色。
            }
            DbSession.Savechanges();
            return true;


        }
    }
}