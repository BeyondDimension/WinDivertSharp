﻿#if NET45 || NET40 || NET35
namespace System
{
    internal static class AppContext
    {
        public static string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;
    }
}
#endif