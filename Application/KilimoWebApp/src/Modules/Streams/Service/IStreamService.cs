using KilimoWebApp.Common;
using KilimoWebApp.Modules.Streams.Model;
using KilimoWebApp.Modules.Students.Model;
using Microsoft.AspNetCore.Mvc;

namespace KilimoWebApp.Modules.Streams.Service;

public interface IStreamService
{
    ResponseBody GetAllStreams();
    ResponseBody GetStreamByName(string name);
}