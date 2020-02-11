using SceneParser.Helpers;
using SceneParser.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SceneParser.Parsers
{
    public class SceneBinHeaderParser : ByteHandler<SceneBinHeaderParser.SceneBinHeader>
    {
        public class SceneBinHeader
        {
            public int[] sceneFileStartLocation { get; set; }
            public int[] sceneFileLength { get; set; }

            public Structures.ScenePossitionInfo getSceneBlockInfo(ushort scene_id)
            {
                return new Structures.ScenePossitionInfo() { Start = sceneFileStartLocation[scene_id], Length = sceneFileLength[scene_id] };
            }

            public int getTotalSceneBlocks()
            {
                return sceneFileStartLocation.Length;
            }
        }

        public override byte[] Encode(SceneBinHeader obj)
        {
            throw new NotImplementedException();
        }

        public override SceneBinHeader Parse(byte[] header)
        {
            SceneBinHeader sceneBinHeader = new SceneBinHeader();
            List<int> starts = new List<int>();
            List<int> ends = new List<int>();
            int foundEnd = 0;
            for (ushort i = 0x0; i < 0x40; i += 4)
            {
                if (header[i] == 255)
                {
                    foundEnd = i / 4;
                }

                int startPossition = EndianConverter.GetLittleEndianInt(new byte[4] {
        header[i], header[i + 1], header[i + 2], header[i + 3]
    }) * 4;
                starts.Add(startPossition);

                if (foundEnd > 0)
                {
                    break;
                }
            }
            int[] startLocs = starts.ToArray();
            for (ushort n = 0; n < startLocs.Length; n++)
            {
                if (n == foundEnd - 1)
                {
                    int end = 0x2000 - (startLocs[n]);
                    ends.Add(end);
                    if (Parser.DebugMode) Console.WriteLine("Found lst data file it starts at {0:X} with length of {1}({1:X})", startLocs[n], end);
                    break;
                }
                else
                {
                    int end = 4 * (startLocs[n + 1] - startLocs[n]);
                    ends.Add(end);
                    if (Parser.DebugMode) Console.WriteLine("Found data file it starts at {0:X} with length of {1}({1:X})", startLocs[n], end);
                }
            }
            starts.RemoveAt(starts.Count - 1);
            sceneBinHeader.sceneFileStartLocation = starts.ToArray();
            sceneBinHeader.sceneFileLength = ends.ToArray();
            return sceneBinHeader;
        }
    }
}
