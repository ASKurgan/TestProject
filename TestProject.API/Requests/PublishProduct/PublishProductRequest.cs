namespace TestProject.API.Requests.PublishProduct
{
    public record PublishProductRequest(string PCName,
                                        string Name,
                                        string Description,
                                        DateTimeOffset ExpirationDate,
                                        decimal Price,
                                        long Amount,
                                        DateTimeOffset DateCreate);
}
