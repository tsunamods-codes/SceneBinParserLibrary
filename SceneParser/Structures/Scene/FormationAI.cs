using SceneParser.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SceneParser.Structures.Scene
{
    public class FormationAIHandler : ByteHandler<FormationAIHandler.FormationAI>
    {
        public struct FormationAI
        {
        }

        public override byte[] Encode(FormationAI obj)
        {
            throw new NotImplementedException();
        }

        public override FormationAI Parse(byte[] raw)
        {
            throw new NotImplementedException();
        }
    }
}
