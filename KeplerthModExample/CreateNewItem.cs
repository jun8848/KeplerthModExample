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
        public static int ItemId = ModInit.ModId + 6000;

        public static bool Prefix()
        {
            ConfigItem.Table.Clear();
            WWW www = new WWW(Config.filepath + "Config/ConfigItem.json");
            while (!www.isDone)
            {
            }
            ConfigItem.Table = JsonConvert.DeserializeObject<Dictionary<int, ConfigItem>>(www.text);
            www.Dispose();

            // 添加物品
            CreateItem();

            Workshop.LoadModsConfig<ConfigItem>(ConfigItem.Table, "ConfigItem");
            return false;

        }

        public static void CreateItem()
        {

            for (int i = 0; i < 10; i++)
            {
                ConfigItem data = ConfigItem.Table[3201];
                ConfigItem configItem = new ConfigItem(data);
                configItem.Name = "ItemName" + (ItemId + i);
                configItem.PlacenmentId = ItemId + 10000 + i;
                ConfigItem.Table.Add(ItemId + i, configItem);
                
            }
        }

        public static void CreateBoxItem()
        {
            for (int i = 0; i < 10; i++)
            {
                //ConfigItem data = ConfigItem.Table[3631];
                //ConfigItem configItem = new ConfigItem(data);
                //configItem.Name = "ItemName" + (id + i);
                //configItem.PlacenmentId = id + 10000 + i;
                //ModDebug.Log("PlacenmentId:" + configItem.PlacenmentId);
                //ConfigItem.Table.Add(id + i, configItem);
            }
        }
    }
}
