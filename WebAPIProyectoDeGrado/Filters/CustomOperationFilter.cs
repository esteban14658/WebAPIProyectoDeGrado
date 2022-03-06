using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using PG.Models.Entitys;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json;

namespace PG.Presentation.Filters
{
    public class CustomOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            if (operation.RequestBody != null && operation.RequestBody.Content.TryGetValue("multipart/form-data", out var openApiMediaType))
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var array = new OpenApiArray
             {
            new OpenApiString(JsonSerializer.Serialize(new Order {Id = 0, TypeOfMaterial="string",Price=0}, options)),
             };

                //openApiMediaType.Schema.Properties["Orders"].Example = array;
            }
        }
    }
}
