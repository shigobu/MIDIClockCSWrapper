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

		#region プロパティ

		private IntPtr _unManagedObjectPointer = IntPtr.Zero;
		/// <summary>
		/// アンマネージドのオブジェクトポインタ
		/// </summary>
		private IntPtr UnManagedObjectPointer
		{
			get
			{
				if (_unManagedObjectPointer != IntPtr.Zero)
				{
					return _unManagedObjectPointer;
				}
				else
				{
					throw new InvalidOperationException("UnManagedObjectPointerはnullです。");
				}
			}
			set
			{
				_unManagedObjectPointer = value;
			}
		}

		/// <summary>
		/// MIDIクロックの動作状況を取得します。
		/// </summary>
		public bool IsRunning
		{
			get
			{
				return Convert.ToBoolean(MIDIClock_IsRunning(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// テンポ
		/// </summary>
		public int Tempo
		{
			get
			{
				return MIDIClock_GetTempo(this.UnManagedObjectPointer);
			}
		}

		/// <summary>
		/// スピード
		/// </summary>
		public int Speed
		{
			get
			{
				return MIDIClock_GetSpeed(this.UnManagedObjectPointer);
			}
		}

		#endregion

		#region 列挙型

		public enum TimeMode
		{
			TPQNBASE    =  0,
			SMPTE24BASE = 24,
			SMPTE25BASE = 25,
			SMPTE29BASE = 29,
			SMPTE30BASE = 30,
		}

		#endregion

		#region コンストラクタ

		/// <summary>
		/// MIDIクロックオブジェクトを初期化して生成します。
		/// </summary>
		/// <param name="timeMode">タイムモード</param>
		/// <param name="resolution">分解能</param>
		/// <param name="tempo">テンポ</param>
		public MIDIClock(TimeMode timeMode, int resolution, int tempo)
		{
			IntPtr intPtr = MIDIClock_Create((int)timeMode, resolution, tempo);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIClockLibException("MIDIクロックの生成に失敗しました。");
			}
			this.UnManagedObjectPointer = intPtr;
		}

		#endregion

		#region メソッド

		/// <summary>
		/// MIDIクロックを削除する。
		/// </summary>
		private void Delete()
		{
			MIDIClock_Delete(this.UnManagedObjectPointer);
			this.UnManagedObjectPointer = IntPtr.Zero;
		}

		/// <summary>
		/// MIDIクロックをスタートする。
		/// </summary>
		public void Start()
		{
			if (!IsRunning)
			{
				int err = MIDIClock_Start(this.UnManagedObjectPointer);
				if (err == 0)
				{
					throw new MIDIClockLibException("MIDIクロックのスタートに失敗しました。");
				}
			}
		}

		/// <summary>
		/// MIDIクロックをストップする。
		/// </summary>
		public void Stop()
		{
			MIDIClock_Stop(this.UnManagedObjectPointer);
		}

		/// <summary>
		/// MIDIクロックをリセットする。
		/// </summary>
		public void Reset()
		{
			MIDIClock_Reset(this.UnManagedObjectPointer);
		}

		/// <summary>
		/// タイムベースを取得します。
		/// </summary>
		/// <param name="timeMode">タイムモード</param>
		/// <param name="resolution">分解能</param>
		public void GetTimeBase(out TimeMode timeMode, out int resolution)
		{
			int mode, res;
			int err = MIDIClock_GetTimeBase(this.UnManagedObjectPointer, out mode, out res);
			if (err == 0)
			{
				throw new MIDIClockLibException("タイムベースの取得に失敗しました。");
			}
			timeMode = (TimeMode)Enum.ToObject(typeof(TimeMode), mode);
			resolution = res;
		}

		#endregion
	}
}
