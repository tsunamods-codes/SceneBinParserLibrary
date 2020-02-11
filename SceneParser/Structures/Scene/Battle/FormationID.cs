using SceneParser.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneParser.Structures.Scene.Battle
{
    public class FormationIDHandler : ByteHandler<FormationIDHandler.FormationID>
    {
        public struct FormationID
        {
            public int SceneIndex { get; set; }
            public int FormationIndex { get; set; }
        }
        override public FormationID Parse(byte[] raw)
        {
            // @todo build parser for SceneIndex and FormatIndex
            return new FormationID() { };
        }

        public override byte[] Encode(FormationID obj)
        {
            throw new NotImplementedException();
        }
    }
}
