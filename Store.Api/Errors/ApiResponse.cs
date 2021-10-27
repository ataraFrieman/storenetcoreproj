namespace Store.Api.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Massage { get; set; }
        public ApiResponse(int statusCode, string massage = null)
        {
            StatusCode = statusCode;
            Massage = massage ?? GetDefualtMassageForStatusCode(statusCode);
        }

        private string GetDefualtMassageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorization , you are not",
                404 => "Resource found , it's not",
                500 => "Internal Server Error",
                _ => null
           };
        }
    }
}