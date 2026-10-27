# DBLib

DBLib is API for connecting your CS# plugin to shared database using LINQ2DB ORM model

## Nuget

To use DBLib install [Nuget package](https://www.nuget.org/packages/CounterStrikeSharpDBLib) or run `dotnet app package CounterStrikeSharpDBLib`

To access your db ORM object see this example code

```cs
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using DBLib.Contracts;
using LinqToDB.Data;
using LinqToDB.Internal.Common;
using Microsoft.Extensions.Logging;

namespace TestDBLib;

public class Plugin : BasePlugin
{
  public override string ModuleName => "Test";

  public override string ModuleVersion => "0.0.1";

  public IDatabaseService? svc;

  public override void Load(bool hotReload)
  {
    svc = DatabaseCapability.Service.Get();
    Server.NextFrameAsync(async () =>
    {
      try
      {
        int i = await svc!.UseAsync(db => db.ExecuteAsync<int>("SELECT 1;"));
        Logger.LogInformation("[TEST]: {i}", i);
      }
      catch (Exception e)
      {
        Logger.LogError("[TEST ERROR]: {Error}", e.ToString());
      }
    });
  }
}

```
