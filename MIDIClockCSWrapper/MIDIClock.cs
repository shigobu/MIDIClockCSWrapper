using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MIDIClockCSWrapper
{
	public class MIDIClock
	{
		#region Dll読み込み

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIClock_Create(int lTimeMode, int lResolution, int lTempo);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern void MIDIClock_Delete(IntPtr pMIDIClock);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_Start(IntPtr pMIDIClock);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_Stop(IntPtr pMIDIClock);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_Reset(IntPtr pMIDIClock);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_IsRunning(IntPtr pMIDIClock);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_GetTimeBase(IntPtr pMIDIClock, out int pTimeMode, out int pResolution);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_GetTempo(IntPtr pMIDIClock);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_GetSpeed(IntPtr pMIDIClock);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_GetMIDIInSyncMode(IntPtr pMIDIClock);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_GetMillisec(IntPtr pMIDIClock);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_GetTickCount(IntPtr pMIDIClock);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_SetTimeBase(IntPtr pMIDIClock, int lTimeMode, int lResolution);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_SetTempo(IntPtr pMIDIClock, int lTempo);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_SetSpeed(IntPtr pMIDIClock, int lSpeed);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_SetMIDIInSyncMode(IntPtr pMIDIClock, int lMIDIInSyncMode);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_SetMillisec(IntPtr pMIDIClock, int lMillisec);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_SetTickCount(IntPtr pMIDIClock, int lTickCount);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIClock_PutMIDIMessage(IntPtr pMIDIClock, byte[] pMIDIMessage, int lLen);

		#endregion

		#region 列挙型

		enum TimeMode
		{
			TPQNBASE    =  0,
			SMPTE24BASE = 24,
			SMPTE25BASE = 25,
			SMPTE29BASE = 29,
			SMPTE30BASE = 30,
		}

		#endregion

		public MIDIClock()
		{

		}
	}
}
