using IRFestival.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Newtonsoft.Json;
using System;
using System.Net;

namespace IRFestival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : Controller
    {

        private CosmosClient _cosmosClient { get; set; }
        private Container _websiteArticlesContainer { get; set; }

        public ArticlesController(IConfiguration configuration)
        {
            _cosmosClient = new CosmosClient(configuration.GetConnectionString("CosmosConnection"));
            _websiteArticlesContainer = _cosmosClient.GetContainer("IRFestivalArticles", "WebsiteArticles");
        }


        [HttpGet]
        public async Task GetDatabase()
        {
            Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync("IRFestivalArticles");
            _websiteArticlesContainer = await database.CreateContainerIfNotExistsAsync("WebsiteArticles", "/tag");
        }


        [HttpPost("PostArticle")]
        public async Task<ActionResult> PostArticle(Article dummyArticle)
        {
            var article = await _websiteArticlesContainer.CreateItemAsync(dummyArticle);
            return Ok(article);
        }

        [HttpGet("GetArticle")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Article))]
        public async Task<ActionResult> GetAsync()
        {
            await GetDatabase();

            var result = new List<Article>();

            var queryDefinition = _websiteArticlesContainer.GetItemLinqQueryable<Article>()
                .Where(p => p.Status == nameof(Status.Published))
                .OrderBy(p => p.Date);

            var iterator = queryDefinition.ToFeedIterator();
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                result = response.ToList();
            }

            return Ok(result);
        }
    }
}
