using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordFinderApp.Models;

namespace WordFinderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordFinderController : ControllerBase
    {
        [HttpPost("find")]
        public ActionResult<IList<string>> FindWords([FromBody] WordFinderRequest request)
        {
            var wordFinder = new WordFinder(request.Dictionary);
            var result = wordFinder.Find(request.Matrix);
            return Ok(result);
        }

        [HttpPost("find_trie")]
        public ActionResult<IList<string>> FindWords_Trie([FromBody] WordFinderRequest request)
        {
            var wordFinder = new WordFinderTrie(request.Dictionary);
            var result = wordFinder.Find(request.Matrix);
            return Ok(result);
        }
    }

    public class WordFinderRequest
    {
        public IEnumerable<string> Dictionary { get; set; }
        public IEnumerable<string> Matrix { get; set; }
    }
}
