using KilimoWebApp.Modules.Streams.Model;

namespace KilimoWebApp.Modules.Streams.Repository;

public interface IStreamRepository
{
    void CreateStream(StreamEntity streamEntity);
    List<StreamEntity> GetAllStreams();
    StreamEntity GetStreamByName(string name);
    void UpadteStreamById(StreamEntity streamEntity);
    void DeleteStreamByName(string name);
}