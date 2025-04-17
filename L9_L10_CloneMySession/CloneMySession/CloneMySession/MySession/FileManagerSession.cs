using System.Text.Json;

namespace CloneMySession.MySession;

public class FileManagerSession : IStorageEngine
{
    private readonly string _directoryPath;

    public FileManagerSession(string directoryPath)
    {
        _directoryPath = directoryPath;
    }

    public async Task<Dictionary<string, byte[]>> LoadAsync(string id, CancellationToken cancellationToken)
    {
        var storePath = Path.Combine(_directoryPath, id);
        if (!File.Exists(storePath))
        {
            return [];
        }

        using FileStream fileStream = new FileStream(storePath, FileMode.Open);
        using StreamReader streamReader = new StreamReader(fileStream);
        var  json = await streamReader.ReadToEndAsync(cancellationToken);
        return  JsonSerializer.Deserialize<Dictionary<string, byte[]>>(json)??[];

    }

    public Task CommitAsync(string id, Dictionary<string, byte[]> store, CancellationToken cancellationToken)
    {
        var storePath = Path.Combine(_directoryPath, id);
        using FileStream fileStream = new FileStream(storePath, FileMode.Create); 
        using  StreamWriter streamWriter = new StreamWriter(fileStream);
        streamWriter.Write(JsonSerializer.Serialize(store));
        return Task.CompletedTask;
    }
}