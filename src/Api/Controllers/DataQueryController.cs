using _5by5.Learning.News.Infrastructure.Data.Query;
using Microsoft.AspNetCore.Mvc;

namespace _5by5.Learning.News.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataQueryController : ControllerBase
    {
        private readonly IDataQuery _dataQuery;
        public DataQueryController(IDataQuery dataQuery)
        {
            _dataQuery = dataQuery;
        }

        [HttpGet]
        public string dataQuery()
        {
            var MessageDataQuery = _dataQuery.MessageDataQuery();
            return MessageDataQuery;
        }
    }
}
