﻿using System;

namespace Catalyte.Theater.Utilities.HttpResponseExceptions
{
    [Serializable]
    public class UnprocessableEntityException : Exception, IHttpResponseException
    {
       public UnprocessableEntityException(string message)
        {
            Value = new(status: 422, error: "Unprocessable Entity", message: message);
        }
        public HttpResponseExceptionValue Value { get; set; }
    }
}
