using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzySasquatchsBeltstatcalculator
{
    public class Belt
    {
        public static IReadOnlyDictionary<int, float> BeltCreatureLimit = new Dictionary<int, float>()
        {
            { 0, 30.0f },
            { 20, 31.0f },
            { 21, 31.5f },
            { 22, 32.0f },
            { 23, 32.5f },
            { 24, 33.0f },
            { 25, 33.5f },
        };

        public List<Creature> Creatures = new List<Creature>() { new Creature(), new Creature(), new Creature(), new Creature(), new Creature(), new Creature() };

        public int BeltEnhancement = 0;

        public Belt() { }
        public Belt(int beltEnhancement = 0, params Creature[] creatures)
        {
            Creatures = new List<Creature>(creatures);
        }

        public Creature this[int i]
        {
            get { return Creatures[i]; }
            set { Creatures[i] = value; }
        }

        public float GetStatValue(StatType type)
        {
            float creatureTotal = Creatures.Sum(c => c.GetStat(type));
            return creatureTotal > BeltCreatureLimit[BeltEnhancement] ? BeltCreatureLimit[BeltEnhancement] : creatureTotal;
        }

        public float GetStatHiddenValue(StatType type)
        {
            return Creatures.Sum(c => c.GetStat(type));
        }

        public void Reset()
        {
            Creatures.Clear();
        }
    }
}
