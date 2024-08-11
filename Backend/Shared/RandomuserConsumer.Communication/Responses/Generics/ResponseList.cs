namespace RandomuserConsumer.Communication.Responses.Generics;

public abstract class ResponseList<T>
{
    public List<T> Results { get; set; }
    public string Search { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public int TotalCount { get; set; }
    
    protected ResponseList(List<T> list,int page, int pageSize, int totalCount, string search)
    {
        Results = list;
        Search = search;
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = (int) Math.Ceiling(totalCount / (double) pageSize);
    }
}