using SceneParser.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SceneParser.Structures.Scene
{
    public class Scene
    {
        Enemy[] enemies = new Enemy[3];

        public byte[] raw { get; set; }

        public Scene(byte[] uncompressed)
        {
            this.raw = uncompressed;
        }

        public void Parse()
        {
            int parsePtr = 0x0;
            // parse the 3 Enemy_id's
            for(int i = 0; i < 3; i++)
            {
                int id = EndianConverter.GetLittleEndianIntTwofer(new byte[2] { this.raw[parsePtr], this.raw[parsePtr + 1] });
                parsePtr += 2;
            }
            // skip padding
            parsePtr += 2;

            // initilize a temp array so memory cleaner can clean uneeded memory as we proccess
            byte[] tempStore;

            // read the Battle Setup
            tempStore = new byte[0x50];
            Array.Copy(this.raw, parsePtr, tempStore, 0, 0x50);
            parsePtr += 0x50;
            // @todo handle paring of battle setup

            // read the camera info 
            tempStore = new byte[0xC0];
            Array.Copy(this.raw, parsePtr, tempStore, 0, 0xC0);
            parsePtr += 0xC0;
            // @todo handle preparing the camera

            // read the battle formations
            for(int i = 0; i < 4; i++)
            {
                tempStore = new byte[0x60];
                Array.Copy(this.raw, parsePtr, tempStore, 0, 0x60);
                parsePtr += 0x60;
                //@todo handle creation of battle formation
            }

            // read the Enemy Datas
            for (int i = 0; i < 3; i++)
            {
                tempStore = new byte[0xB8];
                Array.Copy(this.raw, parsePtr, tempStore, 0, 0xB8);
                parsePtr += 0xB8;
                //@todo handle creation of enemy data (enemy.addData)
            }

            // read the Attack Datas
            for (int i = 0; i < 32; i++)
            {
                tempStore = new byte[0x1C];
                Array.Copy(this.raw, parsePtr, tempStore, 0, 0x1C);
                parsePtr += 0x1C;
                //@todo handle creation of Attack data
            }

            // read the Attack IDs
            for (int i = 0; i < 32; i++)
            {
                tempStore = new byte[0x02];
                Array.Copy(this.raw, parsePtr, tempStore, 0, 0x02);
                parsePtr += 0x02;
                //@todo handle creation of Attack ID's
            }

            // read the Attack Names
            for (int i = 0; i < 32; i++)
            {
                tempStore = new byte[0x20];
                Array.Copy(this.raw, parsePtr, tempStore, 0, 0x20);
                parsePtr += 0x20;
                //@todo handle creation of Attack ID's
            }

            // read the Formation AI Script Offsets
            for (int i = 0; i < 32; i++)
            {
                tempStore = new byte[0x02];
                Array.Copy(this.raw, parsePtr, tempStore, 0, 0x02);
                parsePtr += 0x02;
                //@todo handle Formation AI Scripts
            }

            // read the Formation AI Data
            tempStore = new byte[0x1F8];
            Array.Copy(this.raw, parsePtr, tempStore, 0, 0x1F8);
            parsePtr += 0x1F8;
            //@todo handle Formation AI Data

            // read the Enemy AI Script Offsets
            for (int i = 0; i < 3; i++)
            {
                tempStore = new byte[0x02];
                Array.Copy(this.raw, parsePtr, tempStore, 0, 0x02);
                parsePtr += 0x02;
                //@todo handle Enemy AI Scripts
            }

            tempStore = new byte[0xFFA];
            Array.Copy(this.raw, parsePtr, tempStore, 0, 0xFFA);
            parsePtr += 0xFFA;
            //@todo parse Enemy AI
        }

        public static Scene newScene()
        {
            byte[] raw = new byte[7808];
            for(int i = 0; i < raw.Length; i++)
            {
                raw[i] = 0xFF;
            }
            return new Scene(raw);
        }
    }
}
