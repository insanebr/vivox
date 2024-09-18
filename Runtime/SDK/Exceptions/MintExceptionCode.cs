namespace Unity.Services.Vivox
{
    /// <summary>
    /// Simple mapping of HTTP error codes for easier reading
    /// </summary>
    public enum MintExceptionCode
    {
        /// <summary>
        /// Returned when Player is unable to perform the target operation due to sanctions applied by the Moderation SDK or free-tier allowance exhaustion
        /// </summary>
        Unauthorized = 403,

        /// <summary>
        /// Returned when using an invalid token
        /// </summary>
        FailedToDecodeToken = 406
    }
}
