using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzySasquatchsBeltstatcalculator
{
    public class Creature
    {
        public CreatureType Type { get; }
        private int _stage = 0;
        public int Stage
        {
            get => _stage;
            private set
            {
                if (value >= 0 && value <= 5)
                {
                    _stage = value;
                }
            }
        }
        private List<Stat> _stats;

        internal Creature() : this(CreatureType.None, 0) { }
        public Creature(CreatureType type, int stage = 0)
        {
            Type = type;
            Stage = stage;
            _stats = new List<Stat>();

            switch (type)
            {
                case CreatureType.Pantera:
                    _stats.Add((StatType.Strength, 6f, 1f));
                    _stats.Add((StatType.PAtk, 6f, 1f));
                    break;
                case CreatureType.Poultry:
                    _stats.Add((StatType.Dexterity, 6f, 1f));
                    _stats.Add((StatType.Acc, 6f, 1f));
                    break;
                case CreatureType.Tortus:
                    _stats.Add((StatType.Vitality, 6f, 1f));
                    _stats.Add((StatType.PDef, 6f, 1f));
                    break;
                case CreatureType.BluePixie:
                    _stats.Add((StatType.Intelligence, 11f, 1f));
                    _stats.Add((StatType.MAtk, 11f, 1f));
                    break;
                case CreatureType.Lydian:
                    _stats.Add((StatType.Strength, 5.5f, 0.5f));
                    _stats.Add((StatType.Vitality, 5.5f, 0.5f));
                    _stats.Add((StatType.PDef, 11f, 1f));
                    break;
                case CreatureType.Octopus:
                    _stats.Add((StatType.Intelligence, 11f, 1f));
                    _stats.Add((StatType.MAtk, 11f, 1f));
                    break;
                case CreatureType.Orc:
                    _stats.Add((StatType.Strength, 5.5f, 0.5f));
                    _stats.Add((StatType.Vitality, 5.5f, 0.5f));
                    _stats.Add((StatType.PAtk, 5.5f, 0.5f));
                    _stats.Add((StatType.PDef, 5.5f, 0.5f));
                    break;
                case CreatureType.RedPixie:
                    _stats.Add((StatType.Intelligence, 11f, 1f));
                    _stats.Add((StatType.MAtk, 11f, 1f));
                    break;
                case CreatureType.Siren:
                    _stats.Add((StatType.Dexterity, 5.5f, 0.5f));
                    _stats.Add((StatType.Wisdom, 5.5f, 0.5f));
                    _stats.Add((StatType.Acc, 5.5f, 0.5f));
                    _stats.Add((StatType.MAcc, 5.5f, 0.5f));
                    break;
                case CreatureType.Skeleton:
                    _stats.Add((StatType.Agility, 11f, 1f));
                    _stats.Add((StatType.AtkSpd, 11f, 1f));
                    break;
                case CreatureType.Wolf:
                    _stats.Add((StatType.Agility, 11f, 1f));
                    _stats.Add((StatType.Eva, 11f, 1f));
                    break;
                case CreatureType.Yeti:
                    _stats.Add((StatType.Vitality, 11f, 1f));
                    _stats.Add((StatType.PDef, 11f, 1f));
                    break;
                case CreatureType.Harpy:
                    _stats.Add((StatType.Dexterity, 13f, 1f));
                    _stats.Add((StatType.AtkSpd, 13f, 1f));
                    break;
                case CreatureType.Hawkman:
                    _stats.Add((StatType.Strength, 6.5f, 0.5f));
                    _stats.Add((StatType.Vitality, 6.5f, 0.5f));
                    _stats.Add((StatType.PAtk, 6.5f, 0.5f));
                    _stats.Add((StatType.PDef, 6.5f, 0.5f));
                    break;
                case CreatureType.Nightmare:
                    _stats.Add((StatType.Dexterity, 13f, 1f));
                    _stats.Add((StatType.Acc, 13f, 1f));
                    break;
                case CreatureType.Salamander:
                    _stats.Add((StatType.Strength, 6.5f, 0.5f));
                    _stats.Add((StatType.Intelligence, 6.5f, 0.5f));
                    _stats.Add((StatType.PAtk, 6.5f, 0.5f));
                    _stats.Add((StatType.MAtk, 6.5f, 0.5f));
                    break;
                case CreatureType.Unicorn:
                    _stats.Add((StatType.Agility, 13f, 1f));
                    _stats.Add((StatType.Eva, 13f, 1f));
                    break;
                case CreatureType.Angel:
                    _stats.Add((StatType.Vitality, 7.5f, 0.5f));
                    _stats.Add((StatType.Intelligence, 7.5f, 0.5f));
                    _stats.Add((StatType.PDef, 7.5f, 0.5f));
                    _stats.Add((StatType.MAtk, 7.5f, 0.5f));
                    break;
                case CreatureType.Gnoll:
                    _stats.Add((StatType.Vitality, 15f, 1f));
                    _stats.Add((StatType.BlockRatio, 15f, 1f));
                    break;
                case CreatureType.IceMaiden:
                    _stats.Add((StatType.Intelligence, 15f, 1f));
                    _stats.Add((StatType.MAtk, 15f, 1f));
                    break;
                case CreatureType.Kentauros:
                    _stats.Add((StatType.Strength, 15f, 1f));
                    _stats.Add((StatType.PAtk, 15f, 1f));
                    break;
                case CreatureType.Naga:
                    _stats.Add((StatType.Intelligence, 15f, 1f));
                    _stats.Add((StatType.MAtk, 15f, 1f));
                    break;
                case CreatureType.Cerberus:
                    _stats.Add((StatType.Strength, 8.5f, 0.5f));
                    _stats.Add((StatType.Dexterity, 8.5f, 0.5f));
                    _stats.Add((StatType.PAtk, 8.5f, 0.5f));
                    _stats.Add((StatType.Acc, 8.5f, 0.5f));
                    break;
                case CreatureType.Genie:
                    _stats.Add((StatType.Vitality, 17f, 1f));
                    _stats.Add((StatType.HPRegen, 17f, 1f));
                    break;
                case CreatureType.Ifrit:
                    _stats.Add((StatType.Intelligence, 17f, 1f));
                    _stats.Add((StatType.MPRegen, 17f, 1f));
                    break;
                case CreatureType.StoneGolem:
                    _stats.Add((StatType.Vitality, 17f, 1f));
                    _stats.Add((StatType.PDef, 17f, 1f));
                    break;
                case CreatureType.Baphomet:
                    _stats.Add((StatType.Intelligence, 19f, 1f));
                    _stats.Add((StatType.CastSpd, 19f, 1f));
                    break;
                case CreatureType.BlightOgre:
                    _stats.Add((StatType.Strength, 9.5f, 0.5f));
                    _stats.Add((StatType.Intelligence, 9.5f, 0.5f));
                    _stats.Add((StatType.PAtk, 9.5f, 0.5f));
                    _stats.Add((StatType.MAtk, 9.5f, 0.5f));
                    break;
                case CreatureType.DeathTyrant:
                    _stats.Add((StatType.Strength, 19f, 1f));
                    _stats.Add((StatType.PAtk, 9.5f, 0.5f));
                    _stats.Add((StatType.AtkSpd, 9.5f, 0.5f));
                    break;
                case CreatureType.Drillbot:
                    _stats.Add((StatType.Vitality, 9.5f, 0.5f));
                    _stats.Add((StatType.Wisdom, 9.5f, 0.5f));
                    _stats.Add((StatType.PDef, 9.5f, 0.5f));
                    _stats.Add((StatType.MDef, 9.5f, 0.5f));
                    break;
                case CreatureType.Minotaurus:
                    _stats.Add((StatType.Strength, 9.5f, 0.5f));
                    _stats.Add((StatType.Vitality, 9.5f, 0.5f));
                    _stats.Add((StatType.PAtk, 9.5f, 0.5f));
                    _stats.Add((StatType.PDef, 9.5f, 0.5f));
                    break;
                case CreatureType.MysticKoala:
                    _stats.Add((StatType.Luck, 15f, 1f));
                    _stats.Add((StatType.CritRatio, 6f, 1f));
                    break;
                case CreatureType.Snowman:
                    _stats.Add((StatType.Luck, 15f, 1f));
                    _stats.Add((StatType.CritRatio, 6f, 1f));
                    break;
                case CreatureType.Undine:
                    _stats.Add((StatType.Vitality, 19f, 1f));
                    _stats.Add((StatType.PDef, 19f, 1f));
                    break;
                case CreatureType.WhiteDragon:
                    _stats.Add((StatType.Vitality, 9.5f, 0.5f));
                    _stats.Add((StatType.Intelligence, 9.5f, 0.5f));
                    _stats.Add((StatType.PDef, 9.5f, 0.5f));
                    _stats.Add((StatType.MAtk, 9.5f, 0.5f));
                    break;
                case CreatureType cType when cType.ToString().StartsWith("KDS_"):
                    string stat = type.ToString().Split('_')[1];
                    if (stat == "VitalityWisdom")
                    {
                        _stats.Add((StatType.Vitality, 9f, 0.5f));
                        _stats.Add((StatType.Wisdom, 9f, 0.5f));
                    }
                    else if (Enum.TryParse(stat, out StatType statType))
                    {
                        _stats.Add((statType, 13f, 1f));
                    }
                    break;
                default:
                    break;
            }

        }

        public float this[StatType type]
        {
            get { return GetStat(type); }
        }

        public void SetStage(int stage)
        {
            if (stage >= 0 && stage <= 5)
            {
                Stage = stage;
            }
        }

        public float GetStat(StatType type)
        {
            return _stats.Where(s => s.Type == type).Sum(s => s.ValueBase + Stage * s.ValuePerStage);
        }
    }
}
