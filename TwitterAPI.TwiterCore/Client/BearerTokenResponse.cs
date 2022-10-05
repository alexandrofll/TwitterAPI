namespace TwitterAPI.TwiterCore.Client
{
    /// <summary>
    /// Used to parse authorization 
    /// response containing the bearer token
    /// </summary>
    public class BearerTokenResponse
    {
        /// <summary>
        /// It gets sets the token type
        /// </summary>
        public string? token_type { get; set; }

        /// <summary>
        /// It gets sets the bearer token
        /// </summary>
        public string? access_token { get; set; }
    }
}
