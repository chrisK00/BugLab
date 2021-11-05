using System;
using System.Collections.Generic;

namespace BugLab.Business.Helpers
{
    public static class Guard
    {
        public static void NotFound<TInput, TId>(TInput input, string inputName, TId id)
        {
            _ = input ?? throw new KeyNotFoundException($"The requested {inputName} with an id of {id} was not found");
        }

        public static void NotFound<TInput, TId>(TInput input, string inputTitle)
        {
            _ = input ?? throw new KeyNotFoundException($"{inputTitle} was not found");
        }

        public static void NotFound<T>(bool input, string inputName, T id)
        {
            if (!input) throw new KeyNotFoundException($"The requested {inputName} with an id of {id} was not found");
        }

        public static void NullOrWhitespace(string input, string inputName, string message = null)
        {
            Null(input, inputName, message);

            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException(message ?? $"{inputName} was empty");
        }

        public static T Null<T>(T input, string parameterName, string message = null)
        {
            if (input is not null) return input;

            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(parameterName);

            throw new ArgumentNullException(message);
        }
    }
}
