 
using SDAU.GCT.OA.DAL;
using SDAU.GCT.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.DALFactory
{
   public partial class DbSession:IDbSession
    { 
	  
	public IActionInfoDal ActionInfoDal { get
            {
                return StaticDalFactory.getActionInfoDal();
            }
        }
	  
	public IPublicInformationDal PublicInformationDal { get
            {
                return StaticDalFactory.getPublicInformationDal();
            }
        }
	  
	public IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get
            {
                return StaticDalFactory.getR_UserInfo_ActionInfoDal();
            }
        }
	  
	public IReplyCommentDal ReplyCommentDal { get
            {
                return StaticDalFactory.getReplyCommentDal();
            }
        }
	  
	public IRoleInfoDal RoleInfoDal { get
            {
                return StaticDalFactory.getRoleInfoDal();
            }
        }
	  
	public ITouristAttractionDal TouristAttractionDal { get
            {
                return StaticDalFactory.getTouristAttractionDal();
            }
        }
	  
	public ITouristPlanningDal TouristPlanningDal { get
            {
                return StaticDalFactory.getTouristPlanningDal();
            }
        }
	  
	public IUserInfoDal UserInfoDal { get
            {
                return StaticDalFactory.getUserInfoDal();
            }
        }
	  
	public IVisitorCommentDal VisitorCommentDal { get
            {
                return StaticDalFactory.getVisitorCommentDal();
            }
        }
}
}