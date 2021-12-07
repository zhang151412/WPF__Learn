using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CatiaManipulateLibCore
{
    internal static class Marshal2
    {

        //
        // 摘要:
        //     Obtains a running instance of the specified object from the running object table
        //     (ROT).
        //
        // 参数:
        //   progID:
        //     The programmatic identifier (ProgID) of the object that was requested.
        //
        // 返回结果:
        //     The object that was requested; otherwise null. You can cast this object to any
        //     COM interface that it supports.
        //
        // 异常:
        //   T:System.Runtime.InteropServices.COMException:
        //     The object was not found.
        [SecurityCritical]
        public static object GetActiveObject(string progID)
        {
            object ppunk = null;
            Guid clsid;
            try
            {
                CLSIDFromProgIDEx(progID, out clsid);
            }
            catch (Exception)
            {
                CLSIDFromProgID(progID, out clsid);
            }

            GetActiveObject(ref clsid, IntPtr.Zero, out ppunk);
            return ppunk;
        }


        [DllImport("ole32.dll", PreserveSig = false)]
        [SuppressUnmanagedCodeSecurity]
        [SecurityCritical]
        private static extern void CLSIDFromProgIDEx([MarshalAs(UnmanagedType.LPWStr)] string progId, out Guid clsid);

        [DllImport("ole32.dll", PreserveSig = false)]
        [SuppressUnmanagedCodeSecurity]
        [SecurityCritical]
        private static extern void CLSIDFromProgID([MarshalAs(UnmanagedType.LPWStr)] string progId, out Guid clsid);


        [DllImport("oleaut32.dll", PreserveSig = false)]
        [SuppressUnmanagedCodeSecurity]
        [SecurityCritical]
        private static extern void GetActiveObject(ref Guid rclsid, IntPtr reserved, [MarshalAs(UnmanagedType.Interface)] out object ppunk);


    }
}
