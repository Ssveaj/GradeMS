
namespace Core.Models
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Error { get; set; } = string.Empty;
        public int HttpStatusCode { get; set; }
        public T? Value { get; set; }
        public Result(T value) => this.Value = value;
        public Result()
        {
        }
    }
}
