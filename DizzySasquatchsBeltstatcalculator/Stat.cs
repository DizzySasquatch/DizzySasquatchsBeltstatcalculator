using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzySasquatchsBeltstatcalculator
{
    public struct Stat
    {
        public StatType Type { get; }
        public float ValueBase { get; }
        public float ValuePerStage { get; }

        public Stat(StatType type, float valueBase, float valuePerStage)
        {
            Type = type;
            ValueBase = valueBase;
            ValuePerStage = valuePerStage;
        }

        public static implicit operator Stat((StatType type, float valueBase, float valuePerStage) values)
        {
            return new Stat( values.type, values.valueBase, values.valuePerStage );
        }
    }
}
