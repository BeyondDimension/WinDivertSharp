#if NET35
using System.Linq.Expressions;

namespace System
{
    internal static partial class EnumExtensions
    {
        static TOut Convert<TOut, TIn>(TIn value)
        {
            var parameter = Expression.Parameter(typeof(TIn), null);
            var dynamicMethod = Expression.Lambda<Func<TIn, TOut>>(
                Expression.Convert(parameter, typeof(TOut)),
                parameter);
            return dynamicMethod.Compile()(value);
        }

        public static bool HasFlag<T>(this T @this, T flag) where T : Enum
        {
            switch (@this.GetTypeCode())
            {
                case TypeCode.Byte:
                    {
                        var pThisValue = Convert<byte, T>(@this);
                        var pFlagsValue = Convert<byte, T>(flag);
                        return (pThisValue & pFlagsValue) == pFlagsValue;
                    }
                case TypeCode.SByte:
                    {
                        var pThisValue = Convert<sbyte, T>(@this);
                        var pFlagsValue = Convert<sbyte, T>(flag);
                        return (pThisValue & pFlagsValue) == pFlagsValue;
                    }
                case TypeCode.Int16:
                    {
                        var pThisValue = Convert<short, T>(@this);
                        var pFlagsValue = Convert<short, T>(flag);
                        return (pThisValue & pFlagsValue) == pFlagsValue;
                    }
                case TypeCode.UInt16:
                    {
                        var pThisValue = Convert<ushort, T>(@this);
                        var pFlagsValue = Convert<ushort, T>(flag);
                        return (pThisValue & pFlagsValue) == pFlagsValue;
                    }
                case TypeCode.Int32:
                    {
                        var pThisValue = Convert<int, T>(@this);
                        var pFlagsValue = Convert<int, T>(flag);
                        return (pThisValue & pFlagsValue) == pFlagsValue;
                    }
                case TypeCode.UInt32:
                    {
                        var pThisValue = Convert<uint, T>(@this);
                        var pFlagsValue = Convert<uint, T>(flag);
                        return (pThisValue & pFlagsValue) == pFlagsValue;
                    }
                case TypeCode.Int64:
                    {
                        var pThisValue = Convert<long, T>(@this);
                        var pFlagsValue = Convert<long, T>(flag);
                        return (pThisValue & pFlagsValue) == pFlagsValue;
                    }
                case TypeCode.UInt64:
                    {
                        var pThisValue = Convert<ulong, T>(@this);
                        var pFlagsValue = Convert<ulong, T>(flag);
                        return (pThisValue & pFlagsValue) == pFlagsValue;
                    }
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
#endif