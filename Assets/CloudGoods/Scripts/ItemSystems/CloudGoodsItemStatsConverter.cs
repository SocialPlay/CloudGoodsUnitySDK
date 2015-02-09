using UnityEngine;
using System.Collections;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;


public class SocialplayItemStatsConverter : IItemStatsConverter
{
    public Dictionary<string, string> Generate(JArray statsDataObject)
    {
        Dictionary<string, string> statPair = new Dictionary<string, string>();

        for (int i = 0; i < statsDataObject.Count; i++)
        {
            float itemStat = 0.0f;

            statPair.Add(statsDataObject[i]["Name"].ToString(), statsDataObject[i]["Value"].ToString());
        }

        return statPair;
    }
}

