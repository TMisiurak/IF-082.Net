using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace WebAPI.Swagger
{
    public class CustomTokenFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.OperationId == "AuthPost")
            {
                operation.Consumes.Add("application/x-www-form-urlencoded");

                operation.Parameters = new List<IParameter>();

                operation.Parameters.Add(new Parameter
                {
                    Name = "grant_type",
                    @In = "formData",
                    Type = "string",
                    Required = true
                });

                operation.Parameters.Add(new Parameter
                {
                    Name = "username",
                    @In = "formData",
                    Type = "string",
                    Required = true
                });

                operation.Parameters.Add(new Parameter
                {
                    Name = "password",
                    @In = "formData",
                    Type = "string",
                    Required = true
                });
            }
        }
    }

    public class Parameter : IParameter
    {
        public string Description { get; set; }

        public Dictionary<string, object> Extensions { get; }

        public string In { get; set; }

        public string Name { get; set; }

        public bool Required { get; set; }

        public string Type { get; set; }
    }

    public class AddRequiredHeaderParameter : IOperationFilter
    {
        void IOperationFilter.Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new Parameter
            {
                Name = "Authorization",
                @In = "header",
                Type = "string",
                Required = true
            });
        }
    }
}
