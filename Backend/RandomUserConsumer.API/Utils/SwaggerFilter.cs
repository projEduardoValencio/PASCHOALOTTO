using Microsoft.OpenApi.Models;
using RandomuserConsumer.Communication.Responses.RandomUserApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PASCHOALOTTO_Random_User_Consumer.Utils;

public class SwaggerFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var typesToIgnore = new List<Type>
        {
        };

        if (typesToIgnore.Contains(context.Type))
        {
            schema.Properties.Clear();
        }
    }
}