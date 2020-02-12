 
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
	
	public partial interface ILogInfoDal : IBaseDal<LogInfo>
    {  
	}   
	
	public partial interface IPlantImageDal : IBaseDal<PlantImage>
    {  
	}   
	
	public partial interface IPlantInfoDal : IBaseDal<PlantInfo>
    {  
	}   
	
	public partial interface IR_UserInfo_ActionInfoDal : IBaseDal<R_UserInfo_ActionInfo>
    {  
	}   
	
	public partial interface IRoleInfoDal : IBaseDal<RoleInfo>
    {  
	}   
	
	public partial interface IUserCommentDal : IBaseDal<UserComment>
    {  
	}   
	
	public partial interface IUserInfoDal : IBaseDal<UserInfo>
    {  
	}   
}