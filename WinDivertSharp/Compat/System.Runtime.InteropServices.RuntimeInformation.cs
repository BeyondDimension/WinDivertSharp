#if NET45 || NET46 || NET47 || NET40 || NET35
#if !NET35
using EnvironmentCompat = System.Environment;
#endif
namespace System.Runtime.InteropServices
{
    internal static class RuntimeInformation
    {
        public static string ProcessArchitecture
        {
            get
            {
                if (EnvironmentCompat.Is64BitProcess)
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