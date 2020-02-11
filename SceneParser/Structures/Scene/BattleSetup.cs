using SceneParser.Enumerators;
using SceneParser.Interface;
using SceneParser.Structures.Scene.Battle;
using System;
using System.Collections.Generic;
using System.Text;

namespace SceneParser.Structures.Scene
{
    public class BattleSetupByteHandler : ByteHandler<BattleSetupByteHandler.BattleSetup>
    {
        public class BattleSetup
        {
            public Location BattleLocation { get; set; }

            public FormationID AutoBatle { get; set; }

            public BattleSquareFormations BattleSquareFormations { get; set; }

            public FlagsAttribute Flags { get; set; }

            public Layout Layout { get; set; }
        }

        override public BattleSetup Parse(byte[] raw)
        {
            BattleSetup inst = new BattleSetup();
            return inst;
        }

        override public byte[] Encode(BattleSetup obj)
        {
            throw new NotImplementedException();
        }
    }
}
