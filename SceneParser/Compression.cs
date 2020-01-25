using SceneParser.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneParser
{
    public class Compression
    {
        public static byte[] decompress(ScenePossitionInfo scenePoss, ref byte[] raw)
        {
            int bytesRead;
            byte[] compressedScene = new byte[scenePoss.Length];
            byte[] uncompressedScene = new byte[7808];
            byte[] response;

            Array.Copy(raw, scenePoss.Start, compressedScene, 0, scenePoss.Length);

            using (MemoryStream inputWrapper = new MemoryStream(compressedScene))
            {
                using (MemoryStream decompressedOutput = new MemoryStream())
                {
                    using (GZipStream zipInput = new GZipStream(inputWrapper, CompressionMode.Decompress, true))
                    {
                        while ((bytesRead = zipInput.Read(uncompressedScene, 0, 16)) != 0)
                        {
                            decompressedOutput.Write(uncompressedScene, 0, bytesRead);
                        }
                        zipInput.Close();
                    }
                    decompressedOutput.Close();
                    response = decompressedOutput.ToArray();
                }
                inputWrapper.Close();
            }

            return response;
        }
    }
}
