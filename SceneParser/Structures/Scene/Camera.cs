using SceneParser.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SceneParser.Structures.Scene
{
    public class CameraParser : ByteHandler<CameraParser.Camera>
    {
        public struct Camera
        {
            public struct Point3D
            {
                public ushort X { get; set; }
                public ushort Y { get; set; }
                public ushort Z { get; set; }
            }

            public Point3D possition { get; set; }
            public Point3D lookAt { get; set; }
        }

        public override byte[] Encode(Camera obj)
        {
            throw new NotImplementedException();
        }

        public override Camera Parse(byte[] raw)
        {
            throw new NotImplementedException();
        }
    }
}
