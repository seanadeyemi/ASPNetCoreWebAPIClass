namespace ASPNetCoreWebAPIClass.Domain.Models.API
{
    public class ApiResponse<T>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public T Data { get; set; }
    }
}
