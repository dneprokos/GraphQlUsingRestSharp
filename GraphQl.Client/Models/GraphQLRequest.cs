namespace GraphQl.Client.Models
{
    public class GraphQLRequest
    {
        public string? OperationName { get; set; }

        public string? Query { get; set; }

        public Dictionary<string, object>? Variables { get; set; }
    }
}
