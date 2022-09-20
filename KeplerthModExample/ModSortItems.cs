using DataBase;
using Harmony;
using Keplerth;
using System.Collections.Generic;

namespace KeplerthModExample
{
    [HarmonyPatch(typeof(BaseBag), "SortItems")]
    public class ModSortItems
    {
        public static bool Prefix(int bagID, int bagCount)
        {
            if (bagID==0)
            {
                ModTools.SortItems(0, bagCount);
                return false;
            }
            return true;
        }
    }
}
