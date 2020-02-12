 
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
        bool SetRole(int id, List<int> roleInfoList);
    }
	
	 public partial interface ILogInfoService:IBaseService<LogInfo>
    {

    }
	
	 public partial interface IPlantImageService:IBaseService<PlantImage>
    {

    }
	
	 public partial interface IPlantInfoService:IBaseService<PlantInfo>
    {

    }
	
	 public partial interface IR_UserInfo_ActionInfoService:IBaseService<R_UserInfo_ActionInfo>
    {

    }
	
	 public partial interface IRoleInfoService:IBaseService<RoleInfo>
    {

    }
	
	 public partial interface IUserCommentService:IBaseService<UserComment>
    {

    }
	
	 public partial interface IUserInfoService:IBaseService<UserInfo>
    {
        bool SetRole(int id, List<int> roleInfoList);
    }
}