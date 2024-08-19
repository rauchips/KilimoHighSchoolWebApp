using KilimoWebApp.Common;
using KilimoWebApp.Modules.Streams.Model;
using Microsoft.EntityFrameworkCore;

namespace KilimoWebApp.Modules.Streams.Repository;

public class StreamRepository(KilimoContext kilimoContext) : IStreamRepository
{
    public void CreateStream(StreamEntity streamEntity)
    {
        kilimoContext.Streams.Add(streamEntity);
        kilimoContext.SaveChanges();
    }

    public List<StreamEntity> GetAllStreams()
    {
        return kilimoContext.Streams.AsNoTracking().ToList();
    }

    public StreamEntity GetStreamByName(string name)
    {
        return kilimoContext.Streams.FirstOrDefault(stream => stream != null && stream.Name.Equals(name));
    }

    public void UpadteStreamById(StreamEntity streamEntity)
    {
        kilimoContext.Streams.Update(streamEntity);
        kilimoContext.SaveChanges();
    }

    public void DeleteStreamByName(string name)
    {
        var streamEntity = GetStreamByName(name);
        kilimoContext.Streams.Remove(streamEntity);
        kilimoContext.SaveChanges();
    }
}