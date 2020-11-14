using GraphQL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLWebAPI.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly BlogSchema _schema;

        public GraphQLController(BlogSchema schema)
        {
            _schema = schema;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            Inputs inputs;
            if (query.Variables == null)
                inputs = new Inputs(new Dictionary<string, object>());
            else
                inputs = new Inputs(query.Variables.ToObject<Dictionary<string,object>>());
            var schema = _schema;

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = new Inputs(inputs);
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
