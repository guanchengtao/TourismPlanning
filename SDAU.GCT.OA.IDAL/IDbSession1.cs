﻿ 
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
	
	
      ILogInfoDal LogInfoDal { get; }
	
	
      IPlantImageDal PlantImageDal { get; }
	
	
      IPlantInfoDal PlantInfoDal { get; }
	
	
      IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get; }
	
	
      IRoleInfoDal RoleInfoDal { get; }
	
	
      IUserCommentDal UserCommentDal { get; }
	
	
      IUserInfoDal UserInfoDal { get; }
	
}
}