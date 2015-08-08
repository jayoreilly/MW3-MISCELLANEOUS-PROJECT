using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS3TMAPI_NET;

namespace Kiwi_modz
{
    class PS3
    {
        private static uint GetProcessID()
        {
            uint[] array;
            PS3TMAPI.GetProcessList(0, out array);
            return array[0];
        }
        public static Int32 Target = 0;
        public static String GetTargetName()
        {
            if ((Parameters.ConsoleName == null) || (Parameters.ConsoleName == string.Empty))
            {
                PS3TMAPI.InitTargetComms();
                PS3TMAPI.TargetInfo targetInfo = new PS3TMAPI.TargetInfo
                {
                    Flags = PS3TMAPI.TargetInfoFlag.TargetID,
                    Target = Target
                };
                PS3TMAPI.GetTargetInfo(ref targetInfo);
                Parameters.ConsoleName = targetInfo.Name;
            }
            return Parameters.ConsoleName;
        }
        public static UInt32 ProcessID()
        {
            return Parameters.ProcessID;
        }
        public class Parameters
        {
            public static string ConsoleName;
            public static string info;
            public static uint ProcessID;
            public static uint[] processIDs;
        }
        public enum ResetTarget
        {
            Hard,
            Quick,
            ResetEx,
            Soft
        }
        public static Boolean Attach()
        {
            Boolean flag = false;
            PS3TMAPI.GetProcessList((Int32)Target, out Parameters.processIDs);
            if (Parameters.processIDs.Length > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            if (flag)
            {
                ulong num = Parameters.processIDs[0];
                Parameters.ProcessID = Convert.ToUInt32(num);
                PS3TMAPI.ProcessAttach((Int32)Target, PS3TMAPI.UnitType.PPU, Parameters.ProcessID);
                PS3TMAPI.ProcessContinue((Int32)Target, Parameters.ProcessID);
                Parameters.info = "The Process 0x" + Parameters.ProcessID.ToString("X8") + " Has Been Attached !";
            }
            return flag;
        }
        public static Boolean Connect(Int32 TargetInPS3 = 0)
        {
            Boolean flag = false;
            Target = TargetInPS3;
            flag = PS3TMAPI.SUCCEEDED(PS3TMAPI.InitTargetComms());
            return PS3TMAPI.SUCCEEDED(PS3TMAPI.Connect(TargetInPS3, null));
        }
        public static void GetMemory(uint addr, ref byte[] Buffer)
        {
            PS3TMAPI.ProcessGetMemory(0, PS3TMAPI.UnitType.PPU, Parameters.ProcessID, 0, addr, ref Buffer);
        }
        public static void SetMemory(UInt32 Address, Byte[] bytes)
        {
            PS3TMAPI.ProcessSetMemory(0, PS3TMAPI.UnitType.PPU, Parameters.ProcessID, 0L, (ulong)Address, bytes);
        }
        public static Byte[] GetMem(UInt32 Address, Int32 Length)
        {
            Byte[] buff = new Byte[Length];
            PS3TMAPI.ProcessGetMemory(0, PS3TMAPI.UnitType.PPU, Parameters.ProcessID, 0, Address, ref buff);
            return buff;
        }

        public static void WriteString(uint Offset, string Text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(Text);
            Array.Resize(ref buffer, buffer.Length + 1);
            PS3.SetMemory(Offset, buffer);
        }

        public static void WriteByte(uint Offset, byte Byte)
        {
            byte[] buffer = new byte[1];
            buffer[0] = Byte;
            PS3.SetMemory(Offset, buffer);
        }

        public static void WriteFloat(uint Offset, float Float)
        {
            byte[] buffer = new byte[4];
            BitConverter.GetBytes(Float).CopyTo(buffer, 0);
            Array.Reverse(buffer, 0, 4);
            PS3.SetMemory(Offset, buffer);
        }

        public static void WriteFloatArray(uint Offset, float[] Array)
        {
            byte[] buffer = new byte[Array.Length * 4];
            for (int Lenght = 0; Lenght < Array.Length; Lenght++)
            {
                ReverseBytes(BitConverter.GetBytes(Array[Lenght])).CopyTo(buffer, Lenght * 4);
            }
            PS3.SetMemory(Offset, buffer);
        }

        public static void WriteInt(uint Offset, int Value)
        {
            byte[] buffer = BitConverter.GetBytes(Value);
            Array.Reverse(buffer);
            PS3.SetMemory(Offset, buffer);
        }

        public static Byte[] SetMem(UInt32 Address, Int32 Length)
        {
            Byte[] bytes = new Byte[Length];
            PS3TMAPI.ProcessSetMemory(0, PS3TMAPI.UnitType.PPU, Parameters.ProcessID, 0L, (ulong)Address, bytes);
            return bytes;
        }
        public static float ReadFloat(UInt32 offset)
        {
            byte[] myBuffer = PS3.GetMem(offset, 4);
            Array.Reverse(myBuffer, 0, 4);
            return BitConverter.ToSingle(myBuffer, 0);
        }
       
        public static Byte ReadByte(UInt32 address)
        {
            return PS3.GetMem(address, 1)[0];
        }

        public static Byte[] ReadBytes(UInt32 address, Int32 length)
        {
            return PS3.GetMem(address, length);
        }

        public static Int32 ReadInt32(UInt32 address)
        {
            Byte[] memory = PS3.GetMem(address, 4);
            Array.Reverse(memory, 0, 4);
            return BitConverter.ToInt32(memory, 0);
        }
                             
        public static float ReadSingle(UInt32 address)
        {
            Byte[] memory = PS3.GetMem(address, 4);
            Array.Reverse(memory, 0, 4);
            return BitConverter.ToSingle(memory, 0);
        }

        public static float[] ReadSingle(UInt32 address, Int32 length)
        {
            Byte[] memory = PS3.GetMem(address, length * 4);
            ReverseBytes(memory);
            float[] numArray = new float[length];
            for (Int32 i = 0; i < length; i++)
            {
                numArray[i] = BitConverter.ToSingle(memory, ((length - 1) - i) * 4);
            }
            return numArray;
        }

        public static string ReadString(UInt32 address)
        {
            Int32 length = 40;
            Int32 num2 = 0;
            string source = "";
            do
            {
                Byte[] memory = PS3.GetMem(address + ((UInt32)num2), length);
                source = source + Encoding.UTF8.GetString(memory);
                num2 += length;
            }
            while (!source.Contains<char>('\0'));
            Int32 inPS3 = source.IndexOf('\0');
            string str2 = source.Substring(0, inPS3);
            source = string.Empty;
            return str2;
        }

        public static Byte[] ReverseBytes(Byte[] toReverse)
        {
            Array.Reverse(toReverse);
            return toReverse;
        }

        public static void WriteBytes(UInt32 address, Byte[] input)
        {
            PS3.SetMemory(address, input);
        }

        public static bool WriteBytesToggle(uint Offset, Byte[] On, Byte[] Off)
        {
            bool flag = ReadByte(Offset) == On[0];
            WriteBytes(Offset, !flag ? On : Off);
            return flag;
        }

        public static void WriteInt16(UInt32 address, short input)
        {
            Byte[] array = new Byte[2];
            ReverseBytes(BitConverter.GetBytes(input)).CopyTo(array, 0);
            PS3.SetMemory(address, array);
        }

        public static void WriteInt32(UInt32 address, Int32 input)
        {
            Byte[] array = new Byte[4];
            ReverseBytes(BitConverter.GetBytes(input)).CopyTo(array, 0);
            PS3.SetMemory(address, array);
        }
      
        public static void WriteSingle(UInt32 address, float input)
        {
            Byte[] array = new Byte[4];
            BitConverter.GetBytes(input).CopyTo(array, 0);
            Array.Reverse(array, 0, 4);
            PS3.SetMemory(address, array);
        }

        public static void WriteSingle(UInt32 address, float[] input)
        {
            Int32 length = input.Length;
            Byte[] array = new Byte[length * 4];
            for (Int32 i = 0; i < length; i++)
            {
                ReverseBytes(BitConverter.GetBytes(input[i])).CopyTo(array, (Int32)(i * 4));
            }
            PS3.SetMemory(address, array);
        }

        public static int ReadInt(uint Offset)
        {
            byte[] buffer = new byte[4];
            PS3.GetMemory(Offset, ref buffer);
            Array.Reverse(buffer);
            int Value = BitConverter.ToInt32(buffer, 0);
            return Value;
        }

        public static float[] ReadFloatLength(uint Offset, int Length)
            {
                byte[] buffer = new byte[Length * 4];
                PS3.GetMemory(Offset, ref buffer);
                Array.Reverse(buffer);
                float[] FArray = new float[Length];
                for (int i = 0; i < Length; i++)
                {
                    FArray[i] = BitConverter.ToSingle(buffer, (Length - 1 - i) * 4);
                }
                return FArray;
            }

       public static void WriteUInt(uint Offset, uint Value)
        {
            byte[] buffer = new byte[4];
            BitConverter.GetBytes(Value).CopyTo(buffer, 0);
            Array.Reverse(buffer, 0, 4);
            PS3.SetMemory(Offset, buffer);
        }

        public static void WriteUInt16(UInt32 address, ushort input)
        {
            Byte[] array = new Byte[2];
            BitConverter.GetBytes(input).CopyTo(array, 0);
            Array.Reverse(array, 0, 2);
            PS3.SetMemory(address, array);
        }
                
        public static void WriteUInt32(UInt32 address, UInt32 input)
        {
            Byte[] array = new Byte[4];
            BitConverter.GetBytes(input).CopyTo(array, 0);
            Array.Reverse(array, 0, 4);
            PS3.SetMemory(address, array);
        }

    }

}
