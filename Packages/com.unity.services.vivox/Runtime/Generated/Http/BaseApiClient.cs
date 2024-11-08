//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using Unity.Services.Vivox.Mint.Scheduler;

namespace Unity.Services.Vivox.Mint.Http
{
    /// <summary>
    /// Base Api Client.
    /// </summary>
    internal abstract class BaseApiClient
    {
        /// <summary>Instance of HttpClient.</summary>
        protected readonly IHttpClient HttpClient;

        /// <summary>Constructor.</summary>
        /// <param name="httpClient">BaseApiClient.</param>
        public BaseApiClient(IHttpClient httpClient)
        {
            HttpClient = httpClient ?? new HttpClient();
        }
    }
}
