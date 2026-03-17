using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ASpWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsApiController: ControllerBase
    {
        public static List<string> fruits=new List<string>()
        {
            "Apple",
            "Mango",
            "Cherry",
            "Grapes"
        };
        [HttpGet]
        public List<string> GetFruits()
        {
            return fruits;
        }
//         [HttpGet("{id}")]
//         [HttpGet("{c}")]
        [HttpGet("index/{id}")]
        public string GetFruitsByIndex(int id)
        {
            return fruits.ElementAt(id);
        }
        [HttpGet("starts/{c}")]
        public string GetFruitsByChar(char c)
        {
            foreach(string i in fruits)
            {
                if (i.StartsWith(c)){
                    return i;
                }
            }
            return "No fruit found";
        }
        [HttpPost]
        public string AddFruit([FromBody] string fruit)
        {
            fruits.Add(fruit);
            return "Fruit Added";
        }
        [HttpPut("{id}")]
        public string AddFruitbyId(int id,[FromBody] string fruit)
        {
            fruits[id]=fruit;
            return "Fruit Updated";
        }
        [HttpPatch("{id}")]
        public string PatchFruit(int id, [FromBody] string fruit)
        {
            fruits[id]=fruit;
            return "fruits Partially Updated";
        }
        [HttpDelete("{id}")]
        public string DeleteFruit(int id)
        {
            fruits.RemoveAt(id);
            return "Fruit Deleted";
        }

    }
}
