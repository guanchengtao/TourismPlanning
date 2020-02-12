 
using SDAU.GCT.OA.IDAL;
using SDAU.GCT.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDAU.GCT.OA.DAL
{
	
	 public partial class ActionInfoDal : BaseDal<ActionInfo>, IActionInfoDal
	 {
	 }
	
	 public partial class LogInfoDal : BaseDal<LogInfo>, ILogInfoDal
	 {
	 }
	
	 public partial class PlantImageDal : BaseDal<PlantImage>, IPlantImageDal
	 {
	 }
	
	 public partial class PlantInfoDal : BaseDal<PlantInfo>, IPlantInfoDal
	 {
	 }
	
	 public partial class R_UserInfo_ActionInfoDal : BaseDal<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoDal
	 {
	 }
	
	 public partial class RoleInfoDal : BaseDal<RoleInfo>, IRoleInfoDal
	 {
	 }
	
	 public partial class UserCommentDal : BaseDal<UserComment>, IUserCommentDal
	 {
	 }
	
	 public partial class UserInfoDal : BaseDal<UserInfo>, IUserInfoDal
	 {
	 }
}