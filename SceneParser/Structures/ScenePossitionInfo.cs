using System;
using System.Collections.Generic;
using System.Text;

namespace SceneParser.Structures
{
    public struct ScenePossitionInfo
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public int blockEnd
        {
            get
            {
                return Start + Length;
            }
        }
    }
}
