using InformationSlipManagement.Manager;
using InformationSlipManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace InformationSlipManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationSlipController : ControllerBase
    {
        private readonly InformationSlipManager _informationSlipManager; //Burada signleton kullandım. Program dosyasında eklentisi Signlenton eklentisi mevcut.

        public InformationSlipController(InformationSlipManager informationSlipManager)
        {
            _informationSlipManager = informationSlipManager;
        }

        [HttpPost]
        public async Task<IActionResult> SlipEditor(List<Root> Root)
        {
            string result = _informationSlipManager.InformationSlipEditor(Root);
            return Ok(result);
        }
    }
}
