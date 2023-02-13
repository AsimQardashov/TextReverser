using Microsoft.AspNetCore.Mvc;
using ChangeData.Helpers;
using ChangeData.Models;

namespace ChangeData.Controllers
{
   

        [Route("api/[controller]")]
        [ApiController]
        public class ReverseController : ControllerBase
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
