 
using SDAU.GCT.OA.DAL;
using SDAU.GCT.OA.IDAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.DALFactory
{
    public partial class StaticDalFactory
    {
        public static string assemblyname = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
	  
		  public static IActionInfoDal getActionInfoDal()
        {      
        return Assembly.Load(assemblyname).CreateInstance(assemblyname+".ActionInfoDal") as IActionInfoDal;
        }
	  
		  public static IPublicInformationDal getPublicInformationDal()
        {      
        return Assembly.Load(assemblyname).CreateInstance(assemblyname+".PublicInformationDal") as IPublicInformationDal;
        }
	  
		  public static IR_UserInfo_ActionInfoDal getR_UserInfo_ActionInfoDal()
        {      
        return Assembly.Load(assemblyname).CreateInstance(assemblyname+".R_UserInfo_ActionInfoDal") as IR_UserInfo_ActionInfoDal;
        }
	  
		  public static IRoleInfoDal getRoleInfoDal()
        {      
        return Assembly.Load(assemblyname).CreateInstance(assemblyname+".RoleInfoDal") as IRoleInfoDal;
        }
	  
		  public static IUserCommentDal getUserCommentDal()
        {      
        return Assembly.Load(assemblyname).CreateInstance(assemblyname+".UserCommentDal") as IUserCommentDal;
        }
	  
		  public static IUserInfoDal getUserInfoDal()
        {      
        return Assembly.Load(assemblyname).CreateInstance(assemblyname+".UserInfoDal") as IUserInfoDal;
        }
}
}