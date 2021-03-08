using Xunit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Classes;

public class RequestFixture
{
    private HttpClient client = new HttpClient();
    public string requestUrl = "https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false";
    public RequestFixture() { }

    public Category category {
        get { return GetRequest(this.requestUrl).Result;}
        private set { category = value; }
    }

    public async Task<Category> GetRequest(string requestUrl)
    {
        var response = await client.GetAsync(requestUrl);

        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        var category = JsonConvert.DeserializeObject<Category>(body);
        return category;
    }
}