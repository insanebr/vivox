using System.Collections.Generic;

namespace Unity.Services.Vivox
{
    /// <summary>
    /// Used for configuring optional fields related to sending channel or direct messages.
    /// </summary>
    public sealed class MessageOptions
    {
        /// <summary>
        /// A metadata tag for the language that this message is in
        /// Defaults to null
        /// </summary>
        public string Language { get; set; } = null;
    }
}
