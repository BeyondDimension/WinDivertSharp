// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// https://github.com/dotnet/runtime/blob/v6.0.2/src/libraries/System.Private.CoreLib/src/System/Numerics/BitOperations.cs#L564

#if NET40 || NET35
using System.Runtime.CompilerServices;

namespace System.Numerics
{
    internal static class BitOperations
    {
        [MethodImpl(256)]
        public static uint RotateLeft(uint value, int offset)
            => (value << offset) | (value >> (32 - offset));

        [MethodImpl(256)]
        public static uint RotateRight(uint value, int offset)
            => (value >> offset) | (value << (32 - offset));
    }
}
#endif
