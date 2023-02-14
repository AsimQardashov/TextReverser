using Microsoft.AspNetCore.Mvc;
using Service.Helpers;
using Service.Models;

namespace Service.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReverseController : Controller
    {
        private readonly ReverseText reverseText;

        public ReverseController(ReverseText reverse)
        {
            reverseText = reverse;
        }

        [HttpPost]
        public string ReverseText([FromBody] Data apiData)
        {
            return apiData.Text != null ? reverseText.ReverseData(apiData.Text) : null;
        }
    }
}
