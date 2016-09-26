namespace Digirati.IIIF.Model.Types.Auth
{
    public class AuthServiceError : ITokenResponse
    {
        public string MessageId { get; set; }

        public string Error { get; set; }

        // ErrorDescription was the original auth spec - use both to allow UV to transition over
        public string ErrorDescription { get; set; }
        public string Description { get; set; }
        // public string ErrorUri { get; set; } no longer used
    }
}
