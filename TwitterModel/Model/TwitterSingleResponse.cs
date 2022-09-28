namespace TwitterModel.Model;

public record TwitterSingleResponse<T>
{
    public T Data { get; set; }
}