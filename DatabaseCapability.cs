using CounterStrikeSharp.API.Core.Capabilities;

namespace DBLib.Contracts;

public static class DatabaseCapability
{
  public static readonly PluginCapability<IDatabaseService> Service = new("lukseh74:dblib");
}