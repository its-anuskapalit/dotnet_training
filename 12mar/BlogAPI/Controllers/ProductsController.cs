using Microsoft.AspNetCore.Mvc;
using BlogAPI.Models;
using System.Text.Json;
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly HttpClient _client = new HttpClient();

    private readonly string _baseUrl = "https://dummyjson.com/products";
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        HttpResponseMessage response = await _client.GetAsync(_baseUrl);

        if (!response.IsSuccessStatusCode)
            return StatusCode((int)response.StatusCode);

        string data = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<ProductResponse>(data,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return Ok(result.Products);
    }
     [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        string json = JsonSerializer.Serialize(product);

        var content = new StringContent(json,
            System.Text.Encoding.UTF8,
            "application/json");

        HttpResponseMessage response =
            await _client.PostAsync(_baseUrl + "/add", content);

        if (!response.IsSuccessStatusCode)
            return StatusCode((int)response.StatusCode);

        string data = await response.Content.ReadAsStringAsync();

        return Ok(data);
    }
}