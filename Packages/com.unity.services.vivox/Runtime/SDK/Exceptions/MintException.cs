using System;
using Unity.Services.Core;
using Unity.Services.Vivox.Mint.Http;
using Unity.Services.Vivox.Mint.Models;

namespace Unity.Services.Vivox
{
    /// <summary>
    /// An Exception relating to the Vivox Mint Authentication service, which checks Vivox tokens against the Unity Game Gateway
    /// </summary>
    [Serializable]
    public class MintException : RequestFailedException
    {
        /// <summary>
        /// The Exception details received from the server if present. Null otherwise.
        /// </summary>
        public string Detail => (InnerException as HttpException<MintErrorStatus>)?.ActualError?.Detail;

        /// <summary>
        /// Date and time of the end of the ban if applicable. Null otherwise.
        /// </summary>
        public DateTime? ExpiresAt => (InnerException as HttpException<MintErrorStatus>)?.ActualError?.ExpiresAt;

        /// <summary>
        /// The Exception error code enum value
        /// </summary>
        public MintExceptionCode ExceptionCode => (MintExceptionCode)ErrorCode;

        /// <summary>
        /// The exception ctor
        /// </summary>
        /// <param name="innerException"> The exception that the Mint exception is being created from </param>
        internal MintException(Exception innerException) : base(
            (int)((HttpException)innerException).Response.StatusCode,
            ((HttpException)innerException).Response.ErrorMessage,
            innerException)
        {
        }
    }
}
