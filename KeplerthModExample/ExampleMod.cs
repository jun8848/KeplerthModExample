using DataBase;
using Harmony;
using Keplerth;
using System.Collections.Generic;

namespace KeplerthModExample
{
    [HarmonyPatch(typeof(BaseBag), "SortItems")]
    public class ExampleMod
    {
        public static bool Prefix(int bagID, int bagCount)
        {

            ModTools.SortItems(bagID, bagCount);
            return false;
        }
    }
}
