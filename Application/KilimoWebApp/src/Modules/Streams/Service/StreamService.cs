using KilimoWebApp.Common;
using KilimoWebApp.Modules.Streams.Model;
using KilimoWebApp.Modules.Streams.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace KilimoWebApp.Modules.Streams.Service;

public class StreamService(IStreamRepository streamRepository) : IStreamService
{
    public ResponseBody GetAllStreams()
    {
        var stream = streamRepository.GetAllStreams();

        if (stream is null)
        {
            return new ResponseBody(400, "No stream was found", null);
        }

        return new ResponseBody(200, "List of streams found.", stream.Select(s => new { s.Name }));
    }

    public ResponseBody GetStreamByName(string name)
    {
        var stream = streamRepository.GetStreamByName(name);

        if (stream is null)
        {
            return new ResponseBody(400, "Stream does not exsit", null);
        }

        return new ResponseBody(200, "Stream found.", stream.Name);
    }
}