using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public interface IItemStatsConverter
{
    Dictionary<string, string> Generate(JArray statsDataObject);
}