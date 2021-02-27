using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamZ.Web.FormModels
{
    public class Result
    {
        public bool Success { get; }
        public string Error { get; private set; }
        public bool IsFailure => !Success;

        protected Result(bool success, string error)
        {
            if (success && error != string.Empty)
                throw new InvalidOperationException();
            if (!success && error == string.Empty)
                throw new InvalidOperationException();
            Success = success;
            Error = error;
        }

        public static Result Fail(string message) => new Result(false, message);
        public static Result<T> Fail<T>(string message) => new Result<T>(default(T), false, message);
        public static Result Ok() => new Result(true, string.Empty);
        public static Result<T> Ok<T>(T value) => new Result<T>(value, true, string.Empty);
    }

    public class Result<T> : Result
    {
        public T Value { get; set; }

        protected internal Result(T value, bool success, string error) : base(success, error)
        {
            Value = value;
        }
    }
}
