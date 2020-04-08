 
using SDAU.GCT.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.IDAL
{   
	
	public partial interface IActionInfoDal : IBaseDal<ActionInfo>
    {  
	}   
	
	public partial interface IPublicInformationDal : IBaseDal<PublicInformation>
    {  
	}   
	
	public partial interface IR_UserInfo_ActionInfoDal : IBaseDal<R_UserInfo_ActionInfo>
    {  
	}   
	
	public partial interface IReplyCommentDal : IBaseDal<ReplyComment>
    {  
	}   
	
	public partial interface IRoleInfoDal : IBaseDal<RoleInfo>
    {  
	}   
	
	public partial interface ITouristAttractionDal : IBaseDal<TouristAttraction>
    {  
	}   
	
	public partial interface ITouristPlanningDal : IBaseDal<TouristPlanning>
    {  
	}   
	
	public partial interface IUserInfoDal : IBaseDal<UserInfo>
    {  
	}   
	
	public partial interface IVisitorCommentDal : IBaseDal<VisitorComment>
    {  
	}   
}