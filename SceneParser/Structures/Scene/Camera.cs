using System;
using System.Collections.Generic;
using System.Text;

namespace SceneParser.Structures.Scene
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
}
