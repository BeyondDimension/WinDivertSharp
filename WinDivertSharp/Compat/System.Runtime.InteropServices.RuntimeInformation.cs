#if NET45 || NET46 || NET47 || NET40
namespace System.Runtime.InteropServices
{
    internal static class RuntimeInformation
    {
        public static string ProcessArchitecture
        {
            get
            {
                if (Environment.Is64BitProcess)
                {
                    return "X64";
                }
                else
                {
                    return "X86";
                }
            }
        }
    }
}
#endif