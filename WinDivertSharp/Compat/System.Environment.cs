#if NET35
namespace System
{
    internal static class EnvironmentCompat
    {
        public static bool Is64BitProcess => IntPtr.Size == 8;
    }
}
#endif