/*
 * WinDivertNative.cs
 * (C) 2018, all rights reserved,
 *
 * This file is part of WinDivertSharp.
 *
 * WinDivertSharp is free software: you can redistribute it and/or modify it under
 * the terms of the GNU Lesser General Public License as published by the
 * Free Software Foundation, either version 3 of the License, or (at your
 * option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
 * License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 * WinDivertSharp is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free
 * Software Foundation; either version 2 of the License, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License
 * for more details.
 *
 * You should have received a copy of the GNU General Public License along
 * with this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
 */

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
#if !NET35
using PathCompat = System.IO.Path;
#endif

namespace WinDivertSharp
{
    internal static unsafe class WinDivertNative
    {
        const string WinDivert = "WinDivert.dll";

        /// <summary>
        /// Static initializer to get our paths correct.
        /// </summary>
        static WinDivertNative()
        {
            var baseDir = AppContext.BaseDirectory;
            var libraryPath = Path.Combine(baseDir, WinDivert);
            if (!File.Exists(libraryPath))
                libraryPath = PathCompat.Combine(baseDir, RuntimeInformation.ProcessArchitecture.ToString(), WinDivert);
            if (!File.Exists(libraryPath))
                throw new FileNotFoundException(null, libraryPath);
            NativeLibrary.Load(libraryPath);
        }

        /// Return Type: HANDLE->void*
        ///filter: char*
        ///layer: WINDIVERT_LAYER->Anonymous_13846946_b76a_4250_9642_c2122691f126
        ///priority: INT16->short
        ///flags: UINT64->unsigned __int64
        [DllImport(WinDivert, EntryPoint = "WinDivertOpen", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr WinDivertOpen([In()][MarshalAs(UnmanagedType.LPStr)] string filter, WinDivertLayer layer, short priority, ulong flags);

        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_33ad92c9_0104_417e_989a_2fdd4b3efcc1*
        ///readLen: ref uint
        [DllImport(WinDivert, EntryPoint = "WinDivertRecv", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertRecv([In()] IntPtr handle, IntPtr pPacket, uint packetLen, [In()] ref WinDivertAddress pAddr, ref uint readLen);

        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///flags: UINT64->unsigned __int64
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_33ad92c9_0104_417e_989a_2fdd4b3efcc1*
        ///readLen: ref uint
        ///lpOverlapped: LPOVERLAPPED->_OVERLAPPED*
        [DllImport(WinDivert, EntryPoint = "WinDivertRecvEx", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertRecvEx([In()] IntPtr handle, IntPtr pPacket, uint packetLen, ulong flags, ref WinDivertAddress pAddr, ref uint readLen, ref NativeOverlapped lpOverlapped);

        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_33ad92c9_0104_417e_989a_2fdd4b3efcc1*
        ///writeLen: ref uint
        [DllImport(WinDivert, EntryPoint = "WinDivertSend", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertSend([In()] IntPtr handle, [In()] IntPtr pPacket, uint packetLen, [In()] ref WinDivertAddress pAddr, ref uint writeLen);

        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///flags: UINT64->unsigned __int64
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_33ad92c9_0104_417e_989a_2fdd4b3efcc1*
        ///writeLen: ref uint
        ///lpOverlapped: LPOVERLAPPED->_OVERLAPPED*
        [DllImport(WinDivert, EntryPoint = "WinDivertSendEx", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertSendEx([In()] IntPtr handle, [In()] IntPtr pPacket, uint packetLen, ulong flags, [In()] ref WinDivertAddress pAddr, ref uint writeLen, ref NativeOverlapped lpOverlapped);

        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///flags: UINT64->unsigned __int64
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_33ad92c9_0104_417e_989a_2fdd4b3efcc1*
        ///writeLen: ref uint
        ///lpOverlapped: LPOVERLAPPED->_OVERLAPPED*
        [DllImport(WinDivert, EntryPoint = "WinDivertSendEx", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertSendEx([In()] IntPtr handle, [In()] IntPtr pPacket, uint packetLen, ulong flags, [In()] ref WinDivertAddress pAddr, IntPtr ignoredLenPtr, IntPtr ignoredOverlappedPtr);

        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        [DllImport(WinDivert, EntryPoint = "WinDivertClose", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertClose([In()] IntPtr handle);

        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///param: WINDIVERT_PARAM->Anonymous_fff177c6_9a3b_4c59_b7f9_62aa58d87f4e
        ///value: UINT64->unsigned __int64
        [DllImport(WinDivert, EntryPoint = "WinDivertSetParam", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertSetParam([In()] IntPtr handle, WinDivertParam param, ulong value);

        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///param: WINDIVERT_PARAM->Anonymous_fff177c6_9a3b_4c59_b7f9_62aa58d87f4e
        ///pValue: UINT64*
        [DllImport(WinDivert, EntryPoint = "WinDivertGetParam", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertGetParam([In()] IntPtr handle, WinDivertParam param, [Out()] out ulong pValue);

        /// Return Type: BOOL->int
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///ppIpHdr: PWINDIVERT_IPHDR*
        ///ppIpv6Hdr: PWINDIVERT_IPV6HDR*
        ///ppIcmpHdr: PWINDIVERT_ICMPHDR*
        ///ppIcmpv6Hdr: PWINDIVERT_ICMPV6HDR*
        ///ppTcpHdr: PWINDIVERT_TCPHDR*
        ///ppUdpHdr: PWINDIVERT_UDPHDR*
        ///ppData: PVOID*
        ///pDataLen: ref uint
        [DllImport(WinDivert, EntryPoint = "WinDivertHelperParsePacket", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertHelperParsePacket([In()] IntPtr pPacket, uint packetLen, IPv4Header** ppIpHdr, IPv6Header** ppIpv6Hdr, IcmpV4Header** ppIcmpHdr, IcmpV6Header** ppIcmpv6Hdr, TcpHeader** ppTcpHdr, UdpHeader** ppUdpHdr, byte** ppData, ref uint pDataLen);

        /// Return Type: UINT->unsigned int
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_33ad92c9_0104_417e_989a_2fdd4b3efcc1*
        ///flags: UINT64->unsigned __int64
        [DllImport(WinDivert, EntryPoint = "WinDivertHelperCalcChecksums", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern uint WinDivertHelperCalcChecksums(IntPtr pPacket, uint packetLen, [In()] ref WinDivertAddress pAddr, ulong flags);

        /// Return Type: UINT->unsigned int
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_33ad92c9_0104_417e_989a_2fdd4b3efcc1*
        ///flags: UINT64->unsigned __int64
        [DllImport(WinDivert, EntryPoint = "WinDivertHelperCalcChecksums", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern uint WinDivertHelperCalcChecksums(IntPtr pPacket, uint packetLen, [In()] IntPtr ignoredAddress, ulong flags);

        /// Return Type: UINT->unsigned int
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_33ad92c9_0104_417e_989a_2fdd4b3efcc1*
        ///flags: UINT64->unsigned __int64
        [DllImport(WinDivert, EntryPoint = "WinDivertHelperCalcChecksums", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern uint WinDivertHelperCalcChecksums(byte* pPacket, uint packetLen, [In()] IntPtr ignoredAddress, ulong flags);

        /// Return Type: BOOL->int
        ///filter: char*
        ///layer: WINDIVERT_LAYER->Anonymous_13846946_b76a_4250_9642_c2122691f126
        ///errorStr: char**
        ///errorPos: ref uint
        [DllImport(WinDivert, EntryPoint = "WinDivertHelperCheckFilter", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertHelperCheckFilter([In()][MarshalAs(UnmanagedType.LPStr)] string filter, WinDivertLayer layer, char** errorStr, ref uint errorPos);

        /// Return Type: BOOL->int
        ///filter: char*
        ///layer: WINDIVERT_LAYER->Anonymous_13846946_b76a_4250_9642_c2122691f126
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_33ad92c9_0104_417e_989a_2fdd4b3efcc1*
        [DllImport(WinDivert, EntryPoint = "WinDivertHelperEvalFilter", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertHelperEvalFilter([In()][MarshalAs(UnmanagedType.LPStr)] string filter, WinDivertLayer layer, [In()] IntPtr pPacket, uint packetLen, [In()] ref WinDivertAddress pAddr);
    }
}