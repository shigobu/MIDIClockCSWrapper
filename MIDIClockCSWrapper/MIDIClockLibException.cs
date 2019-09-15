using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDIClockCSWrapper
{
	public class MIDIClockLibException : Exception
	{
		public MIDIClockLibException() : base("MIDIClockライブラリで不明なエラーが発生しました。")
		{
		}
		public MIDIClockLibException(string message) : base(message)
		{
		}
		public MIDIClockLibException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
