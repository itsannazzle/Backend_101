namespace backend_101.Constants
{
    public static class EnumConstant
    {
        public enum ENUM_HTTP_STATUS
        {
        Continue = 100,
        SwitchingProtocol = 101,
        Processing = 102,

        Ok = 200,
        Created = 201,
        Accepted = 202,
        NonAuthorativeInformation = 203,
        NoContent = 204,
        ResetContent = 205,
        PartialContent = 206,
        MultiStatus = 207,
        AlreadyReported = 208,
        IMUsed = 226,
        
        MultipleChoices = 300,
        MovedPermanently = 301,
        Found = 302,
        SeeOther = 303,
        NotModified = 304,
        UseProxy = 305,
        Unused = 306,
        TemporaryRedirect = 307,
        PermanentRedirection = 308,


        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        NotAcceptable = 406,
        ProxyAuthenticationRequired = 407,
        RequestTimeout = 408,
        Conflict = 409,
        Gone = 410,
        LengthRequired = 411,
        PreconditionFailed = 412,
        RequestEntityTooLarge = 413,
        RequestURITooLong = 414,
        UnsupportedMediaType = 415,
        RequestedRangeNotSatisfiable = 416,
        ExpectationFailed = 417,
        ImATeapot = 418,
        EnhanceYourCalm = 420,
        UnprocessableEntity = 422,
        Locked = 423,
        FailedDependency = 424,
        ReservedForWebDAV = 425,
        UpgradeRequired = 426,
        PreconditionRequires = 428,
        TooManyRequest = 429,
        RequestHeaderFieldsTooLarge = 431,
        NoResponse = 444,
        RetryWith = 449,
        BlockedByWindowsParentalControls = 450,
        UnavailableForLegalReasons = 451,
        ClientClosedRequest = 499,

        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTimeout = 504,
        HTTPVersionNotSupported = 505,
        VariantAlsoNegotiates = 506,
        InsufficientStorage = 507,
        LoopDetected = 508,
        BandwithLimitExceeded = 509,
        NotExtended = 510,
        NetworkAuthenticationRequired = 511,
        ConnectionTimeOut = 522,
        NetworkReadTimeoutError = 598,
        NetworkConnectTimeoutError = 599,
        }

        public enum ENUM_PAYMENT_STATUS
        {
            Draft = 0,
            WaitingForPayment = 1,
            Paid = 1,
            Canceled = 1,
        }
    }
}