using System.Collections;

namespace CloneMySession.MySession;

public interface IStorageEngine
{
    Task<Dictionary<string, byte[]>> LoadAsync(string id, CancellationToken cancellationToken);
    Task CommitAsync(string id,Dictionary<string, byte[]> store, CancellationToken cancellationToken);
}