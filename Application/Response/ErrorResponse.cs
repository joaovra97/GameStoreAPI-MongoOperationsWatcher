using System.Diagnostics;

namespace Application.Response
{
	public class ErrorResponse : DefaultResponse
	{
		public string ErrorMessage { get; set; }

		public ErrorResponse(Stopwatch stopwatch, string errorMessage) : base(stopwatch)
		{
			ErrorMessage = errorMessage;
		}
	}
}
