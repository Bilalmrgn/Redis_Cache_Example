using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        //In-Memory cache'i inject et
        private readonly IMemoryCache _memoryCache;
        public CacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public string Set()
        {
            _memoryCache.Set("name", "bilal", options: new()
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(30)
            });

            return "cache set edildi";
        }

        [HttpGet("get")]
        public string Get()
        {
            return _memoryCache.Get<string>("name");
        }
        //liste şeklinde veri eklemek için
        [HttpPost("set-list")]
        public string SetList()
        {
            var names = new List<string>
            {
                "muhammed",
                "mustafa",
                "ahmet",
                "mahmut"
            };

            _memoryCache.Set("names", names);

            return "liste cache'e eklendi";
        }

        //cache den listeyi çekmek
        [HttpGet("get-list")]
        public List<string> GetList()
        {
            return _memoryCache.Get<List<string>>("names");
        }

        [HttpPost("set-date")]
        public void SetDate()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),//bu cache item'i en fazla 30 saniye yaşayabilir. 30 saniye sonra kesin olarak silinir
                SlidingExpiration = TimeSpan.FromSeconds(5)//eğer 5 saniye boyunca cache'deki verilere erişilmezse silinir. Her erişimde süre yeniden 5 saniye olur
            });
        }
        [HttpGet("get-date")]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");
        }

    }
}
