using SceneParser.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SceneParser.Structures.Scene
{
    public class AttackHandler : ByteHandler<AttackHandler.Attack>
    {
        public override byte[] Encode(Attack obj)
        {
            throw new NotImplementedException();
        }

        public override Attack Parse(byte[] raw)
        {
            throw new NotImplementedException();
        }

        public class Attack
        {
        }
    }
}
