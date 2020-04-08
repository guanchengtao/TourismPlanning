 
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
		}
	
	  public partial class PublicInformationService : BaseService<PublicInformation>, IPublicInformationService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.PublicInformationDal;
        }
		}
	
	  public partial class R_UserInfo_ActionInfoService : BaseService<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.R_UserInfo_ActionInfoDal;
        }
		}
	
	  public partial class ReplyCommentService : BaseService<ReplyComment>, IReplyCommentService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.ReplyCommentDal;
        }
		}
	
	  public partial class RoleInfoService : BaseService<RoleInfo>, IRoleInfoService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.RoleInfoDal;
        }
		}
	
	  public partial class TouristAttractionService : BaseService<TouristAttraction>, ITouristAttractionService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.TouristAttractionDal;
        }
		}
	
	  public partial class TouristPlanningService : BaseService<TouristPlanning>, ITouristPlanningService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.TouristPlanningDal;
        }
		}
	
	  public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.UserInfoDal;
        }
		}
	
	  public partial class VisitorCommentService : BaseService<VisitorComment>, IVisitorCommentService
    {
	  public override void GetCurrentDal()
        {
            CurrentDal =DbSession.VisitorCommentDal;
        }
		}
}