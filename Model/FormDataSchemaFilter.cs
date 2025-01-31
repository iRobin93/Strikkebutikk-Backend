using Microsoft.OpenApi.Models;
using StrikkebutikkBackend.Controllers;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StrikkebutikkBackend.Model
{
    public class MultipartFormDataSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            // Check if the type is the request model for the PostProduct endpoint
            if (context.Type == typeof(ProductBase))
            {
                schema.Type = "object";
                schema.Properties = new Dictionary<string, OpenApiSchema>
                {
                    // Define the schema for the JSON-serialized product
                    ["product"] = new OpenApiSchema
                    {
                        Type = "string",
                        Description = "JSON-serialized ProductBase object"
                    },

                    // Define the schema for the productImg file
                    ["productImg"] = new OpenApiSchema
                    {
                        Type = "string",
                        Format = "binary",  // Indicates that this is a file
                        Description = "Product image file"
                    }
                };
            }
        }
    }
}
