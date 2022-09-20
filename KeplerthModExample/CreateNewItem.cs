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
    //[HarmonyPatch(typeof(ConfigWeapon), "initData")]
    //public class CreateNewItem
    //{
    //    public static void Postfix()
    //    {
    //        ConfigItem.Table.Clear();
    //        WWW www = new WWW(Config.filepath + "Config/ConfigItem.json");
    //        while (!www.isDone)
    //        {
    //        }
    //        ConfigItem.Table = JsonConvert.DeserializeObject<Dictionary<int, ConfigItem>>(www.text);
    //        www.Dispose();
    //        CreateItem();
    //        Workshop.LoadModsConfig<ConfigItem>(ConfigItem.Table, "ConfigItem");

    //    }

    //    public static void CreateItem()
    //    {
    //        int itemId = ModInit.GetModHasId() - 200000000;
    //        for (int i = 0; i < 10; i++)
    //        {
    //            ConfigItem data = ConfigItem.Table[3220];
    //            ConfigItem configItem = new ConfigItem(data);
    //            configItem.Name = "ItemName" + itemId;
    //            ConfigItem.Table.Add(itemId + i, configItem);
    //        }
    //    }
    //}
}
