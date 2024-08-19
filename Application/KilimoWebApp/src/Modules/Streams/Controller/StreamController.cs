using KilimoWebApp.Common;
using KilimoWebApp.Modules.Streams.Model;
using KilimoWebApp.Modules.Streams.Service;
using Microsoft.AspNetCore.Mvc;

namespace KilimoWebApp.Modules.Streams.Controller;

[ApiController]
[Route("api/stream")]
public class StreamController(IStreamService streamService) : ControllerBase
{
    [HttpGet("all")]
    public ActionResult<ResponseBody> GetAllStreams()
    {
        var streams = streamService.GetAllStreams();

        if (streams.status.Equals(200))
        {
            return Ok(streams);
        }
        else
        {
            return BadRequest(streams);
        }
    }

    [HttpGet("one")]
    public ActionResult<ResponseBody> GetOneStream(string name)
    {
        var stream = streamService.GetStreamByName(name);

        if (stream.status.Equals(200))
        {
            return Ok(stream);
        }
        else
        {
            return BadRequest(stream);
        }
    }
}