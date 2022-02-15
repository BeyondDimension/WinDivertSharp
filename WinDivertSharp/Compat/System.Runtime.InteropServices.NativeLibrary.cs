#if NETSTANDARD || NETFRAMEWORK
namespace System.Runtime.InteropServices
{
    internal static class NativeLibrary
    {
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);

        public static IntPtr Load(string libraryPath) => LoadLibrary(libraryPath);
    }
}
#endif