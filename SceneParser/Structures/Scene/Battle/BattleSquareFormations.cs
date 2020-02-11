using SceneParser.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneParser.Structures.Scene.Battle
{
    public class BattleSquareFormationsHandler : ByteHandler<BattleSquareFormationsHandler.BattleSquareFormations>
    {
        public class BattleSquareFormations
        {
            public FormationID[] Battles { get; set; }

            public FormationID this[int index]
            {
                get
                {
                    return Battles[index];
                }
                set
                {
                    Battles[index] = value;
                }
            }
        }

        override public BattleSquareFormations Parse(byte[] raw)
        {
            return new BattleSquareFormations()
            {
                Battles = new FormationID[4] {
                    FormationID.Parse(new byte[2]{ raw[0], raw[1] }),
                    FormationID.Parse(new byte[2]{ raw[2], raw[3] }),
                    FormationID.Parse(new byte[2]{ raw[4], raw[5] }),
                    FormationID.Parse(new byte[2]{ raw[6], raw[7] })
                }
            };
        }

        public override byte[] Encode(BattleSquareFormations obj)
        {
            throw new NotImplementedException();
        }
    }
}
