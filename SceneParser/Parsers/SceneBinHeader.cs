﻿using SceneParser.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SceneParser.Parsers
{
    internal class SceneBinHeader {
        public int[] sceneFileStartLocations { get; private set; }
        public int[] sceneFileLengths { get; private set; }
        
        public void parseHeader(byte[] header)
        {
            List<int> starts = new List<int>();
            List<int> ends = new List<int>();
            int foundEnd = 0;
            for (ushort i = 0x0; i < 0x40; i += 4)
            {
                if (header[i] == 255)
                {
                    foundEnd = i/4;
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
                if (n == foundEnd-1)
                {
                    int end = 0x2000 - (startLocs[n]);
                    ends.Add(end);
                    if(Parser.DebugMode) Console.WriteLine("Found lst data file it starts at {0:X} with length of {1}({1:X})", startLocs[n], end);
                    break;
                }
                else
                {
                    int end = 4 * (startLocs[n + 1] - startLocs[n]);
                    ends.Add(end);
                    if(Parser.DebugMode) Console.WriteLine("Found data file it starts at {0:X} with length of {1}({1:X})", startLocs[n], end);
                }
            }
            starts.RemoveAt(starts.Count-1);
            sceneFileStartLocations = starts.ToArray();
            sceneFileLengths = ends.ToArray();
        }

        public Structures.ScenePossitionInfo getSceneBlockInfo(ushort scene_id)
        {
            return new Structures.ScenePossitionInfo() { Start = sceneFileStartLocations[scene_id], Length = sceneFileLengths[scene_id] };
        }

        public int getTotalSceneBlocks()
        {
            return sceneFileStartLocations.Length;
        }
    }
}
