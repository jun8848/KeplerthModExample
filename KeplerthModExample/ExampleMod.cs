using DataBase;
using Harmony;
using Keplerth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerthModExample
{
    [HarmonyPatch(typeof(BagInfo), "EatFood")]
    public class ExampleMod
    {
        public static void Prefix(Character c, int index)
        {

            if (Config.PlayerCharacter == c)
            {
                if (true)
                {
                    //ItemType item = BaseBag.GetBagItems()[index].type;
                    //int itemType = ConfigItem.getItemType(itmeId);
                    // ModDebug.Log("物品类型" + item + "详细类型" + itemType);
                    // 游戏当前所有统计信息
                    Dictionary<KeyValuePair<int,long>,ulong> achievements = Achievement.SelfAchievements;
                    int itmeId = BaseBag.GetBagItems(0, int.MaxValue)[index].id;
                    AddMaxHp(itmeId);
                }


            }
        }

        public static void AddMaxHp(int itemId)
        {
            // 获取当前食物的食用次数
            ulong eatInfo = Achievement.GetSelfAchievement(itemId, AchievementType.EatFood);
            // 第一次吃食物增加1最大生命值
            if (eatInfo <= 0)
            {
                // 添加buff
                Config.PlayerCharacter.BuffCtrl.AttachBuff(88488996, BuffTypeIndex.None, false, 0f, 1, 0f);
            }
            // 千分之十增加1最大生命值
            else
            {
                int random  = new Random().Next(0, 1000);
                if (random <= 10)
                {
                    Config.PlayerCharacter.BuffCtrl.AttachBuff(88488996, BuffTypeIndex.None, false, 0f, 1, 0f);
                }
            }
        }
    }
}
