using System.Collections.Generic;

namespace SoundCore.Application.Models.Results
{
    public class BaseResult
    {
        /// <summary>
        /// By Default the base response Success is set to True
        /// </summary>
        public BaseResult()
        {
            Success = true;
        }
        public BaseResult(string message = null)
        {
            Success = true;
            Message = message;
        }

        public BaseResult(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
