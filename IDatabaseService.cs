using LinqToDB.Data;

namespace DBLib.Contracts;

public interface IDatabaseService
{
  DbProviderKind Provider { get; }

  /// <summary>
  /// Creates a new linq2db connection. Caller owns it and MUST dispose it.
  /// Never cache it and never share it between threads.
  /// </summary>
  DataConnection GetDatabaseConnection();

  /// <summary>Runs work on a scoped connection that is always disposed.</summary>
  Task<T> UseAsync<T>(Func<DataConnection, Task<T>> work, CancellationToken ct = default);

  Task UseAsync(Func<DataConnection, Task> work, CancellationToken ct = default);
}