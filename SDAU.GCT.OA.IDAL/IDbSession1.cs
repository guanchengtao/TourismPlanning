 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.IDAL
{ 
public partial interface IDbSession
    {
	
      IActionInfoDal ActionInfoDal { get; }
	
	
      IPublicInformationDal PublicInformationDal { get; }
	
	
      IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get; }
	
	
      IReplyCommentDal ReplyCommentDal { get; }
	
	
      IRoleInfoDal RoleInfoDal { get; }
	
	
      ITouristAttractionDal TouristAttractionDal { get; }
	
	
      ITouristPlanningDal TouristPlanningDal { get; }
	
	
      IUserInfoDal UserInfoDal { get; }
	
	
      IVisitorCommentDal VisitorCommentDal { get; }
	
}
}