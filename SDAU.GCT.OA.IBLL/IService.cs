 
using SDAU.GCT.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.IBLL
{
	
	 public partial interface IActionInfoService:IBaseService<ActionInfo>
    {

    }
	
	 public partial interface IPublicInformationService:IBaseService<PublicInformation>
    {

    }
	
	 public partial interface IR_UserInfo_ActionInfoService:IBaseService<R_UserInfo_ActionInfo>
    {

    }
	
	 public partial interface IReplyCommentService:IBaseService<ReplyComment>
    {

    }
	
	 public partial interface IRoleInfoService:IBaseService<RoleInfo>
    {

    }
	
	 public partial interface ITouristAttractionService:IBaseService<TouristAttraction>
    {

    }
	
	 public partial interface ITouristPlanningService:IBaseService<TouristPlanning>
    {

    }
	
	 public partial interface IUserInfoService:IBaseService<UserInfo>
    {

    }
	
	 public partial interface IVisitorCommentService:IBaseService<VisitorComment>
    {

    }
}