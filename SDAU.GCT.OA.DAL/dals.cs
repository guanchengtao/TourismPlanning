 
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
	
	 public partial class PublicInformationDal : BaseDal<PublicInformation>, IPublicInformationDal
	 {
	 }
	
	 public partial class R_UserInfo_ActionInfoDal : BaseDal<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoDal
	 {
	 }
	
	 public partial class ReplyCommentDal : BaseDal<ReplyComment>, IReplyCommentDal
	 {
	 }
	
	 public partial class RoleInfoDal : BaseDal<RoleInfo>, IRoleInfoDal
	 {
	 }
	
	 public partial class TouristAttractionDal : BaseDal<TouristAttraction>, ITouristAttractionDal
	 {
	 }
	
	 public partial class TouristPlanningDal : BaseDal<TouristPlanning>, ITouristPlanningDal
	 {
	 }
	
	 public partial class UserInfoDal : BaseDal<UserInfo>, IUserInfoDal
	 {
	 }
	
	 public partial class VisitorCommentDal : BaseDal<VisitorComment>, IVisitorCommentDal
	 {
	 }
}