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
    public class ModTools
    {
        /// <summary>
        /// 整理背包
        /// </summary>
        public static void SortItems(int bagID, int bagCount)
        {
            Dictionary<int, ItemData> bagItems = BaseBag.GetBagItems(bagID, int.MaxValue);
            for (int i = 0; i < bagCount - 1; i++)
            {
                if (i >= 10 && i <= 20)
                {
                    for (int j = i + 1; j < bagCount; j++)
                    {
                        if (bagItems.ContainsKey(j))
                        {
                            if (!bagItems.ContainsKey(i))
                            {
                                if (ConfigItem.getItemType(bagItems[j].id) != 19)
                                {
                                    bagItems[i] = bagItems[j];
                                    bagItems.Remove(j);
                                    break;
                                }
                            }
                        }
                    }
                }

                if (i >= 20)
                {
                    for (int j = i + 1; j < bagCount; j++)
                    {
                        if (bagItems.ContainsKey(j))
                        {
                            if (!bagItems.ContainsKey(i))
                            {
                                bagItems[i] = bagItems[j];
                                bagItems.Remove(j);
                            }
                            else
                            {
                                ItemData itemData = bagItems[i];
                                ItemData itemData2 = bagItems[j];
                                int itemType = ConfigItem.getItemType(itemData.id);
                                int itemType2 = ConfigItem.getItemType(itemData2.id);
                                if ((itemType == itemType2) ? ((itemData.id == itemData2.id) ? (itemData.count < itemData2.count) : (itemData.id > itemData2.id)) : (itemType > itemType2))
                                {
                                    bagItems[i] = itemData2;
                                    bagItems[j] = itemData;
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 10; i < 20; i++)
            {
                if (bagItems.ContainsKey(i) && ConfigItem.getItemType(bagItems[i].id) != 19)
                {
                    for (int j = i + 1; j <= 20; j++)
                    {
                        if (bagItems.ContainsKey(j) && ConfigItem.getItemType(bagItems[j].id) == 19)
                        {
                            ItemData itemData = bagItems[i];
                            bagItems[i] = bagItems[j];
                            bagItems[j] = itemData;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取玩家已存在的饰品BuffId
        /// </summary>
        public static List<int> GetPlayerAccessorieOnBuffIds()
        {
            List<int> list = new List<int>();
            List<Buff> buffs = Config.PlayerCharacter.BuffCtrl.Buffs;
            // 所有饰品列表
            List<int> armourAllBuffIds = GetArmourAllBuffIds();

            foreach (Buff buff in buffs)
            {
                if (armourAllBuffIds.Contains(buff.Id))
                {
                    list.Add(buff.Id);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取玩家穿戴饰品的buff列表
        /// </summary>
        public static List<int> GetPlayerAccessorieBuffs()
        {
            List<int> list = new List<int>();
            Dictionary<int, ItemData> bagItems = BaseBag.GetBagItems(1, int.MaxValue);
            foreach (KeyValuePair<int, ItemData> keyValuePair in bagItems)
            {
                list.Add(keyValuePair.Value.equipBuff);
            }
            return list;
        }

        /// <summary>
        /// 获取玩家背包饰品BuffID列表
        /// </summary>
        public static List<int> GetAccesorieBuffIs()
        {
            List<int> list = new List<int>();
            Dictionary<int, ItemData> bagItems = BaseBag.GetBagItems(0, int.MaxValue);
            foreach (KeyValuePair<int, ItemData> keyValuePair in bagItems)
            {
                bool flag = keyValuePair.Key < 20 && keyValuePair.Key >= 10;
                if (flag)
                {
                    bool flag2 = keyValuePair.Value.subType == 19;
                    if (flag2)
                    {
                        list.Add(ConfigArmour.Table[keyValuePair.Value.id].equipBuffId);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取物品buffID
        /// </summary>
        public static int GetBuffIds(int itemId)
        {
            return ConfigArmour.Table[itemId].equipBuffId; ;
        }

        /// <summary>
        /// 获取所有饰品的buffId
        /// </summary>
        public static List<int> GetArmourAllBuffIds()
        {
            List<int> list = new List<int>();
            foreach (KeyValuePair<int, ConfigArmour> keyValuePair in ConfigArmour.Table)
            {
                bool flag = keyValuePair.Key >= 2301 && keyValuePair.Key <= 2349;
                if (flag)
                {
                    list.Add(keyValuePair.Value.equipBuffId);
                }
            }
            return list;
        }

    }
}
