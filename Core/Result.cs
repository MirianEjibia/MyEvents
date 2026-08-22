using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public bool IsFailuire () => !IsSuccess;
        public string? Error { get; set;}
        public T? Value {get; set; }
        public int? ErrorCode { get; set; }

        public  static Result<T> Success (T value) => new() {IsSuccess = true, Value = value };

        public static Result<T> Failuire (string error, int errorCode) => new () {IsSuccess = false, Error = error, ErrorCode = errorCode};

    }
}