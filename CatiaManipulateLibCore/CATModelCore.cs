using System.Runtime.InteropServices;
using INFITF;
using MECMOD;
using PARTITF;
using ProductStructureTypeLib;
using System.Security;

namespace CatiaManipulateLibCore
{
    public class CATModelCore
    {
        INFITF.Application CATIA;
        public CATModelCore()
        {
            //用C#创建Automation根对象的代码
            //贴一段C#的代码，这段代码用于获得CATIA对象，是每个自动化程序最初的一步，之后都是按部就班的创建和操作CATIA的子类就可以了。
            //INFITF.Application CATIA;
            try
            {
                // 连接CATIA
                //CATIA = (INFITF.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("CATIA.Application");
                //CATIA = (INFITF.Application)Marshal.GetActiveObject("CATIA.Application");
                CATIA = (INFITF.Application)Marshal2.GetActiveObject("CATIA.Application");
                //【Marshal.GetActiveObject：】
                //It can't be a .NETCore project, must be .NETFramework. Which is fine, you need Windows anyway to run CATIA and this code. 
            }
            catch
            {
                Type oType = System.Type.GetTypeFromProgID("CATIA.Application");
                CATIA = (INFITF.Application)Activator.CreateInstance(oType);
                CATIA.Visible = true;
            }




        }
    }
}