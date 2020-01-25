using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SceneParser.Structures;
using SceneParser.Parsers;
using System.IO.Compression;

namespace SceneParser
{
    public class Parser
    {
        public List<Structures.Scene.Scene> Scenes { get; set; } = new List<Structures.Scene.Scene>();
        private byte[] raw;

        public static bool DebugMode { get; private set; }

        public Parser(bool debug = false)
        {
            DebugMode = debug;
        }

        private byte[] readSceneBinFile(string SceneBinFilePath, ref byte[] fileContent)
        {
            fileContent = File.ReadAllBytes(SceneBinFilePath);
            float size = fileContent.Length;
            int i = 0;
            string mesurment;
            while (size > 1024)
            {
                size /= 1024;
                i++;
            }
            switch (i)
            {
                default: case 0: mesurment = "bytes"; break;
                case 1: mesurment = "KB"; break;
                case 2: mesurment = "MB"; break;
                case 3: mesurment = "GB"; break;
                case 4: mesurment = "TB"; break;
            }
            Console.WriteLine("Found SceneBin with a size of {0}{1}", size, mesurment);
            return fileContent;
        }

        private void parseHeaders()
        {
            SceneBinHeader headerParser = new SceneBinHeader();

            byte[] headerRaw = new byte[0x40];
            Array.Copy(raw, 0, headerRaw, 0, 0x40);

            headerParser.parseHeader(headerRaw);
            int scenesCount = headerParser.getTotalSceneBlocks();
            if (DebugMode) Console.WriteLine("Found {0} blocks", scenesCount);

            for(ushort i = 0; i < scenesCount; i++)
            {
                byte[] decompressed = Compression.decompress(headerParser.getSceneBlockInfo(i), ref raw);
                Scenes.Add(new Structures.Scene.Scene(decompressed));
                if (Parser.DebugMode) Console.WriteLine("Uncompressed Scene {0}", i);
            }
        }

        public void LoadSceneBin(string SceneBinFilePath)
        {
            // read whole file into memory
            readSceneBinFile(SceneBinFilePath, ref raw);
            // read the headers
            parseHeaders();

            // destory raw so we're not wasting memory as it's been constructed into object
            raw = null;
        }

    }
}
