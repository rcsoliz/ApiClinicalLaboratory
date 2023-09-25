namespace CLINICAL.Application.UseCase.Commons.Basess
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message {get; set; }

        public IEnumerable<BaseError>? Error { get; set; }
    }
}
