using System.Diagnostics;

namespace Application.Response
{
	public class DefaultResponse
	{
        public string Elapsed { get; set; }
        public long ElapsedMilliseconds { get; set; }
        public long ElapsedTicks { get; set; }

		public DefaultResponse(Stopwatch stopwatch)
		{
			Elapsed = stopwatch.Elapsed.ToString("c");
			ElapsedMilliseconds = stopwatch.ElapsedMilliseconds;
			ElapsedTicks = stopwatch.ElapsedTicks;
		}
	}
}
