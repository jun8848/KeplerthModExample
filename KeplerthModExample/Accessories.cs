using Harmony;
using Keplerth;
using System.Collections.Generic;
namespace KeplerthModExample
{
    [HarmonyPatch(typeof(GlobalDataManger), "Update")]
    public class Accessories
    {
        public static void Postfix()
        {
            // 玩家当前拥有饰品buff列表
            List<int> playerOnBuffIds = ModTools.GetPlayerAccessorieOnBuffIds();

            // 穿戴饰品的buff列表
            List<int> playerAccessorieBuffs = ModTools.GetPlayerAccessorieBuffs();

            // 得到背包饰品buffId列表
            List<int> playerAccesorises =  ModTools.GetAccesorieBuffIs();

            // 判断背包饰品的buff是否存在 存在则移除
            for (int i = 0; i < playerAccesorises.Count; i++)
            {
                if (playerAccessorieBuffs.Contains(playerAccesorises[i]) || playerOnBuffIds.Contains(playerAccesorises[i]))
                {
                    playerAccesorises.Remove(i);
                }
            }

            // 移除不存在的buff
            for (int i = 0; i < playerOnBuffIds.Count; i++)
            {
                if (!playerAccesorises.Contains(playerOnBuffIds[i]) && !playerAccessorieBuffs.Contains(playerOnBuffIds[i]))
                {   
                    Config.PlayerCharacter.BuffCtrl.DetachBuff(playerOnBuffIds[i], BuffTypeIndex.None, false, 0f, true);
                }
            }

            // 添加buff
            for (int i = 0; i < playerAccesorises.Count; i++)
            {
                
                Config.PlayerCharacter.BuffCtrl.AttachBuff(playerAccesorises[i], BuffTypeIndex.None, false, 0f, 1, 0f);
            }
        }
    }

}
    