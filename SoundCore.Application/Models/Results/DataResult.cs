using System.Collections.Generic;

namespace SoundCore.Application.Models.Results
{
    public class DataResult<T>
    {
      
        public T Data { get; set; }

        /// <summary>
        /// By Default the base response Success is set to True
        /// </summary>
        ///
        public DataResult()
        {
            Success = true;
        }
        public DataResult(string message = null)
        {
            Success = true;
            Message = message;
        }

        public DataResult(T data,string message = null)
        {
            Success = true;
            Message = message;
            Data = data;
        }

        public DataResult(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
