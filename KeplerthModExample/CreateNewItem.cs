using DataBase;
using Harmony;
using Keplerth;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace KeplerthModExample
{
    /// <summary>
    /// 添加物品
    /// </summary>
    [HarmonyPatch(typeof(ConfigItem), "initData")]
    public class CreateNewItem
    {
        public static bool Prefix()
        {
            ConfigItem.Table.Clear();
            WWW www = new WWW(Config.filepath + "Config/ConfigItem.json");
            while (!www.isDone)
            {
            }
            ConfigItem.Table = JsonConvert.DeserializeObject<Dictionary<int, ConfigItem>>(www.text);
            www.Dispose();
            CreateItem();

            Workshop.LoadModsConfig<ConfigItem>(ConfigItem.Table, "ConfigItem");
            return false;

        }

        public static void CreateItem()
        {
            int id = 200000;
            
            for (int i = 0; i < 10; i++)
            {
                ConfigItem data = ConfigItem.Table[3201];
                ConfigItem configItem = new ConfigItem(data);
              
                configItem.Name = "ItemName" + (id + i);
                configItem.PlacenmentId = id + 10000 + i;
                ModDebug.Log("PlacenmentId:" + configItem.PlacenmentId);
                ConfigItem.Table.Add(id + i, configItem);
                
            }
        }
    }
}
