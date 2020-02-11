using SceneParser.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SceneParser.Structures.Scene
{
    public class EnemyHandler : ByteHandler<EnemyHandler.Enemy>
    {
        public struct Enemy
        {
            public int EnemyID { get; set; }
        }
        public override byte[] Encode(Enemy obj)
        {
            throw new NotImplementedException();
        }

        public override Enemy Parse(byte[] raw)
        {
            throw new NotImplementedException();
        }
    }
}
