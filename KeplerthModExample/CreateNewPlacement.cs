using DataBase;
using Harmony;
using Keplerth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            CreatePlacement();

            Workshop.LoadModsConfig<ConfigPlacement>(ConfigPlacement.Table, "ConfigPlacement");
            return false;
        }

        public static void CreatePlacement()
        {
            int id = 200000;

            for (int i = 0; i < 10; i++)
            {
                ConfigPlacement data = ConfigPlacement.Table[2001];
                ConfigPlacement placement = new ConfigPlacement(data);
                placement.HandItemId = id + i;
                ModDebug.Log(placement.HandItemId);
                ConfigPlacement.Table.Add(id + 10000 + i, placement);
            }
            
        }
    }
}
