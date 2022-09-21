using DataBase;
using Harmony;
using Keplerth;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace KeplerthModExample
{
    [HarmonyPatch(typeof(ConfigPlacement), "initData")]
    public class CreateNewPlacement
    {
        public static bool Prefix()
        {


            ConfigPlacement.Table.Clear();
            WWW www = new WWW(Config.filepath + "Config/ConfigPlacement.json");
            while (!www.isDone)
            {
            }
            ConfigPlacement.Table = JsonConvert.DeserializeObject<Dictionary<int, ConfigPlacement>>(www.text);
            www.Dispose();

            // 添加放置物
            CreatePlacement();

            Workshop.LoadModsConfig<ConfigPlacement>(ConfigPlacement.Table, "ConfigPlacement");
            return false;
        }

        public static void CreatePlacement()
        {
            for (int i = 0; i < 10; i++)
            {
                ConfigPlacement data = ConfigPlacement.Table[2001];
                ConfigPlacement placement = new ConfigPlacement(data);
                placement.HandItemId = CreateNewItem.ItemId + i;
                // 根据当前游戏语言 更改材质
                if (Config.SelectLanguage != LanguageType.Chinese || Config.SelectLanguage != LanguageType.ChineseTw)
                {
                    placement.Texture = ConfigPlacement.Table[2092].Texture;
                }
                ConfigPlacement.Table.Add(CreateNewItem.ItemId + 10000 + i, placement);
            }
            
        }

        public static void CreateBox()
        {

        }
    }
}
