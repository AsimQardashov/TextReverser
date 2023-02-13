using Microsoft.AspNetCore.Mvc;
using Service.Helpers;
using Service.Models;

namespace Service.Controllers
{
    public class ReverseController : Controller
    {
        private readonly ReverseText reverseText;

        public ReverseController(ReverseText reverse)
        {
            reverseText = reverse;
        }

        [HttpPost]
        public string ReverseString([FromBody] Data apiData)
        {
            return apiData.Text = reverseText.ReverseString(apiData.Text);
        }
    }
}
