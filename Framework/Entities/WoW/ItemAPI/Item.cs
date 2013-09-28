using System.Collections.Generic;
using Entities;

namespace Framework.Entities.WoW.ItemAPI
{
    public class BonusStat
    {
        public int Stat { get; set; }
        public int Amount { get; set; }
    }

    public class Socket
    {
        public string Type { get; set; }
    }

    public class SocketInfo
    {
        public List<Socket> Sockets { get; set; }
        public string SocketBonus { get; set; }
    }

    public class ItemSource
    {
        public int SourceId { get; set; }
        public string SourceType { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public int DisenchantingSkillRank { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Stackable { get; set; }
        public List<int> AllowableClasses { get; set; }
        public int ItemBind { get; set; }
        public List<BonusStat> BonusStats { get; set; }
        public List<object> ItemSpells { get; set; }
        public int BuyPrice { get; set; }
        public int ItemClass { get; set; }
        public int ItemSubClass { get; set; }
        public int ContainerSlots { get; set; }
        public int InventoryType { get; set; }
        public bool Equippable { get; set; }
        public int ItemLevel { get; set; }
        public ItemSet ItemSet { get; set; }
        public int MaxCount { get; set; }
        public int MaxDurability { get; set; }
        public int MinFactionId { get; set; }
        public int MinReputation { get; set; }
        public int Quality { get; set; }
        public int SellPrice { get; set; }
        public int RequiredSkill { get; set; }
        public int RequiredLevel { get; set; }
        public int RequiredSkillRank { get; set; }
        public SocketInfo SocketInfo { get; set; }
        public ItemSource ItemSource { get; set; }
        public int BaseArmor { get; set; }
        public bool HasSockets { get; set; }
        public bool IsAuctionable { get; set; }
        public int Armor { get; set; }
        public int DisplayInfoId { get; set; }
        public string NameDescription { get; set; }
        public string NameDescriptionColor { get; set; }
        public bool Upgradable { get; set; }
        public bool HeroicTooltip { get; set; }
    }
}
