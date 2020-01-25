using System;
using System.Collections.Generic;
using System.Text;

namespace SceneParser.Structures.Scene
{
    public class Scene
    {
        public byte[] raw { get; private set; }

        public Scene(byte[] uncompresses)
        {
            this.raw = uncompresses;
        }
    }
}
