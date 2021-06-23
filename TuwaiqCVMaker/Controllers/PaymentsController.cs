using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moyasar.Models;
using Moyasar.Services;

namespace TuwaiqCVMaker.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentsController
    {
        public async Task<ActionResult> PaymentHook()
        {
            Payment pp;
            PaymentInfo p;
            return new OkResult();
        }
    }
}