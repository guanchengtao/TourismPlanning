 
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
	  
	public ILogInfoDal LogInfoDal { get
            {
                return StaticDalFactory.getLogInfoDal();
            }
        }
	  
	public IPlantImageDal PlantImageDal { get
            {
                return StaticDalFactory.getPlantImageDal();
            }
        }
	  
	public IPlantInfoDal PlantInfoDal { get
            {
                return StaticDalFactory.getPlantInfoDal();
            }
        }
	  
	public IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get
            {
                return StaticDalFactory.getR_UserInfo_ActionInfoDal();
            }
        }
	  
	public IRoleInfoDal RoleInfoDal { get
            {
                return StaticDalFactory.getRoleInfoDal();
            }
        }
	  
	public IUserCommentDal UserCommentDal { get
            {
                return StaticDalFactory.getUserCommentDal();
            }
        }
	  
	public IUserInfoDal UserInfoDal { get
            {
                return StaticDalFactory.getUserInfoDal();
            }
        }
}
}