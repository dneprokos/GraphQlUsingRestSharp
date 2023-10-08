using System.Text;

namespace GraphQl.Client.Builders
{
    public class GraphQLQueryBuilder
    {
        private StringBuilder queryBuilder;

        /// <summary>
        /// Initializes graph ql query build operation
        /// </summary>
        public GraphQLQueryBuilder()
        {
            queryBuilder = new StringBuilder();
        }

        /// <summary>
        /// Starts adding operation
        /// </summary>
        /// <param name="operationName">Name of the operation. Depends on API. Like 'Query'</param>
        /// <param name="field">Top level resource field. Like 'countries'</param>
        /// <param name="arguments">Top level field arguments. Filters like 'code: "UA"'</param>
        /// <returns></returns>
        public GraphQLQueryBuilder AddOperation(string operationName, string field, Dictionary<string, string> arguments)
        {
            queryBuilder.AppendLine($"query {operationName} {{");
            queryBuilder.Append($"  {field}");

            if (arguments != null && arguments.Count > 0)
            {
                queryBuilder.Append("(");
                foreach (var argument in arguments)
                {
                    queryBuilder.Append($"{argument.Key}: \"{argument.Value}\", ");
                }
                queryBuilder.Remove(queryBuilder.Length - 2, 2); // Remove the trailing comma and space
                queryBuilder.Append("){");
            }

            queryBuilder.AppendLine();
            return this;
        }

        /// <summary>
        /// Adds field that you want to return. Like 'name'
        /// </summary>
        /// <param name="field">Field name you want to return</param>
        /// <returns></returns>
        public GraphQLQueryBuilder AddField(string field)
        {
            queryBuilder.AppendLine($"  {field}");
            return this;
        }

        /// <summary>
        /// Adds nested object field
        /// </summary>
        /// <param name="field">Field name like, 'languages'</param>
        /// <param name="nestedQuery">Nested query of added fields. Example: 
        /// AddNestedField("languages", (languagesQuery) => {
        ///         languagesQuery
        ///            .AddField("code")
        ///            .AddField("name");
        ///            })
        /// </param>
        /// <returns></returns>
        public GraphQLQueryBuilder AddNestedField(string field, Action<GraphQLQueryBuilder> nestedQuery)
        {
            queryBuilder.AppendLine($"  {field} {{");
            nestedQuery(this);
            queryBuilder.AppendLine("  }");
            return this;
        }

        /// <summary>
        /// Finalize query
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            CloseOperation();
            return queryBuilder.ToString();
        }

        #region Private helpers

        private void CloseOperation()
        {
            queryBuilder.AppendLine("}}");
        }

        #endregion
    }
}
