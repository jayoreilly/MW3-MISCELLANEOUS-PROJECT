using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace Kiwi_modz
{
    class Functions
    {
        #region IsSameTeam
        public static Boolean isSameTeam(int Client)
        {
            byte team1 = PS3.ReadByte(0x0110d657 + (0x3980 * (uint)GetHostNumber()));
            byte team2 = PS3.ReadByte(0x0110d657 + (0x3980 * (uint)Client));
            return team1 == team2;
        }
#endregion
        #region CBUF
        public static void CBUF_ADDTEXT(String Command)
        {// 0x1DB240
            RPC.Call(0x1DB240, new Object[] { 0, Command });
        }
        #endregion
        #region Switch Teams
        public static void toggleTeam(Int32 client)
        {
            Byte team = PS3.ReadByte(0x0110d657 + (0x3980 * (UInt32)client));
            if (team == 0x01)
            {
                PS3.SetMemory(0x0110d657 + (0x3980 * (UInt32)client), new Byte[] { 0x02 });
                iPrintln(client, "Team: ^2Switched");
            }
            if (team == 0x02)
            {
                PS3.SetMemory(0x0110d657 + (0x3980 * (UInt32)client), new Byte[] { 0x01 });
                iPrintln(client, "Team: ^2Switched");
            }
        }
        #endregion
        #region Give Drugs
        public static void DrugsMode(Int32 client)
        {
            PS3.SetMemory(0x110a280 + 0x64 + ((UInt32)client * 0x3980), new Byte[] { 0x44 });
            PS3.SetMemory(0x110a280 + 0x68 + ((UInt32)client * 0x3980), new Byte[] { 0x44 });

            for (Byte i = 0x00; i < 0x57; i++)
            {
                PS3.WriteByte(0x110a280 + 0x65 + ((UInt32)client * 0x3980), i);
                PS3.WriteByte(0x110a280 + 0x69 + ((UInt32)client * 0x3980), i);
                System.Threading.Thread.Sleep(50);
            }
        }
        public static void Invert(Int32 client, Byte input)
        {
            PS3.SetMemory(0x110a280 + 0x64 + ((UInt32)client * 0x3980), new Byte[] { 0x44 });
            PS3.SetMemory(0x110a280 + 0x68 + ((UInt32)client * 0x3980), new Byte[] { 0x44 });
            PS3.WriteByte(0x110a280 + 0x65 + ((UInt32)client * 0x3980), input);
            PS3.WriteByte(0x110a280 + 0x69 + ((UInt32)client * 0x3980), input);

        }
        #endregion
        #region Lobby Mods
        public static class Lobby
        {
            public static void ChromePlayers(bool state)
            {
                if (state)
                {
                    PS3.SetMemory(0x3984df, new byte[] { 1 });
                    PS3.SetMemory(0x3984f2, new byte[] { 5, 0x70 });
                }
                else
                {
                    PS3.SetMemory(0x3984df, new byte[1]);
                    PS3.SetMemory(0x3984f2, new byte[] { 5, 0x6a });
                }
            }

            public static void InvisibleBullets(bool state)
            {
                if (state)
                {
                    PS3.SetMemory(0x18c9158, new byte[] { 0, 0, 0, 0, 0, 0x53, 0xc5, 0x48, 0, 0x44, 5, 0, 1 });
                }
                else
                {
                    PS3.SetMemory(0x18c9158, new byte[] { 0, 0, 0, 0, 0, 0x53, 0xc5, 0x48, 0, 0x44, 5, 0, 0 });
                }
            }

            public static void LobbyJump(JumpHeight height)
            {
                byte[] buffer;
                if (height.ToString() == "Normal")
                {
                    buffer = new byte[4];
                    buffer[0] = 0x42;
                    buffer[1] = 0x9c;
                    PS3.SetMemory(0x19780, buffer);
                }
                if (height.ToString() == "High")
                {
                    buffer = new byte[4];
                    buffer[0] = 0x44;
                    buffer[1] = 0xf9;
                    PS3.SetMemory(0x19780, buffer);
                }
                if (height.ToString() == "Super")
                {
                    buffer = new byte[4];
                    buffer[0] = 70;
                    PS3.SetMemory(0x19780, buffer);
                }
            }

            public static void LobbySpeed(Speed speed)
            {
                if (speed.ToString() == "Normal")
                {
                    PS3.SetMemory(0x173bb0, new byte[] { 0x38, 160, 0, 190 });
                }
                if (speed.ToString() == "Super")
                {
                    PS3.SetMemory(0x173bb0, new byte[] { 0x38, 160, 7, 0 });
                }
                if (speed.ToString() == "Freeze")
                {
                    byte[] buffer = new byte[4];
                    buffer[0] = 0x38;
                    buffer[1] = 160;
                    PS3.SetMemory(0x173bb0, buffer);
                }
            }
            public static void MapColor(ChromeMap map)
            {
                if (map.ToString() == "Black")
                {
                    PS3.SetMemory(0x18c66a0, new byte[] { 0x60 });
                }
                if (map.ToString() == "BlackWhite")
                {
                    PS3.SetMemory(0x18c66a0, new byte[] { 80 });
                }
                if (map.ToString() == "Default")
                {
                    PS3.SetMemory(0x18c66a0, new byte[] { 0x40 });
                }
            }
            public static void RapidFire(bool state)
            {
                byte[] buffer;
                if (state)
                {
                    buffer = new byte[4];
                    buffer[0] = 0x60;
                    PS3.SetMemory(0x31d6c, buffer);
                    buffer = new byte[4];
                    buffer[0] = 0xc0;
                    buffer[1] = 0x23;
                    PS3.SetMemory(0x31d84, buffer);
                    buffer = new byte[4];
                    buffer[0] = 0x48;
                    buffer[3] = 60;
                    PS3.SetMemory(0x31d8c, buffer);
                    PS3.SetMemory(0x31b44, new byte[] { 0x3d, 0x4c, 0xcc, 0xcd });
                }
                else
                {
                    PS3.SetMemory(0x31d6c, new byte[] { 0x41, 130, 0, 0x94 });
                    buffer = new byte[4];
                    buffer[0] = 0xc0;
                    buffer[1] = 0x24;
                    PS3.SetMemory(0x31d84, buffer);
                    PS3.SetMemory(0x31d8c, new byte[] { 0x40, 130, 0, 60 });
                    PS3.SetMemory(0x31b44, new byte[] { 0x41, 130, 0, 0x94 });
                }
            }


            public static void SuperUAV(bool state)
            {
                if (state)
                {
                    PS3.SetMemory(0x5f067, new byte[] { 2 });
                }
                else
                {
                    PS3.SetMemory(0x5f067, new byte[] { 1 });
                }
            }

            public static void Wallbreak(bool state)
            {
                if (state)
                {
                    PS3.SetMemory(0x173b62, new byte[] { 1, 0x2c });
                }
                else
                {
                    PS3.SetMemory(0x173b62, new byte[] { 2, 0x81 });
                }
            }

            public enum ChromeMap
            {
                Black,
                BlackWhite,
                Default
            }

            public enum JumpHeight
            {
                Normal,
                High,
                Super
            }

            public enum Speed
            {
                Normal,
                Super,
                Freeze
            }
        }
        #endregion
        #region Stats
        public static class Stats
        {
            public static void Assists(int assists)
            {
                PS3.WriteBytes(0x1c194bc, BitConverter.GetBytes(assists));
            }

            public static void BlackOpsPrestige(int prestige)
            {
                PS3.WriteBytes(0x1c1b388, BitConverter.GetBytes(prestige));
            }

            public static void Clantag(string clantag)
            {
                PS3.WriteString(0x892c0e, clantag);
            }

            public static void ClassName(int Class, string name)
            {
                PS3.SetMemory((uint)(0x1c1982c + ((Class - 1) * 0x62)), new byte[30]);
                PS3.SetMemory((uint)(0x1c1982c + ((Class - 1) * 0x62)), Encoding.Default.GetBytes(name));
            }

            public static void CoD4Prestige(int prestige)
            {
                PS3.WriteBytes(0x1c1b376, BitConverter.GetBytes(prestige));
            }

            public static void Deaths(int deaths)
            {
                PS3.WriteBytes(0x1c194b4, BitConverter.GetBytes(deaths));
            }

            public static void Headshots(int headshots)
            {
                PS3.WriteBytes(0x1c194c0, BitConverter.GetBytes(headshots));
            }

            public static void Hits(int hits)
            {
                PS3.WriteBytes(0x1c194f8, BitConverter.GetBytes(hits));
            }

            public static void Kills(int kills)
            {
                PS3.WriteBytes(0x1c194ac, BitConverter.GetBytes(kills));
            }

            public static void Killstreak(int killstreak)
            {
                PS3.WriteBytes(0x1c194b0, BitConverter.GetBytes(killstreak));
            }

            public static void Losses(int losses)
            {
                PS3.WriteBytes(0x1c194e4, BitConverter.GetBytes(losses));
            }

            public static void Misses(int misses)
            {
                PS3.WriteBytes(0x1c194fc, BitConverter.GetBytes(misses));
            }

            public static void MW2Prestige(int prestige)
            {
                PS3.WriteBytes(0x1c1b381, BitConverter.GetBytes(prestige));
            }

            public static void Prestige(int lvl)
            {
                PS3.WriteByte(0x1c1947c, (byte)lvl);
            }

            public static void PrestigeTokens(int tokens)
            {
                PS3.WriteBytes(0x1c1b2db, BitConverter.GetBytes(tokens));
            }

            public static void UnlockAllTitles()
            {
                PS3.SetMemory(0x1c19fab, new byte[] { 0x13, 2 });
                for (uint i = 0; i < 0x200; i += 2)
                {
                    PS3.SetMemory(0x1c190b4 + i, new byte[] { 30, 0xb8 });
                }
                for (uint j = 0; j < 0x1064; j += 4)
                {
                    PS3.SetMemory(0x1c19ff2 + j, new byte[] { 10, 10, 10, 10 });
                }
                for (uint k = 0; k < 0x200; k++)
                {
                    PS3.SetMemory(0x1c1b0a0 + k, new byte[] { 0xff });
                }
            }

            public static void WaWPrestige(int prestige)
            {
                PS3.WriteBytes(0x1c1b37b, BitConverter.GetBytes(prestige));
            }

            public static void Wins(int wins)
            {
                PS3.WriteBytes(0x1c194e0, BitConverter.GetBytes(wins));
            }

            public static void Winstreak(int winstreak)
            {
                PS3.WriteBytes(0x1c194ec, BitConverter.GetBytes(winstreak));
            }
        }
        #endregion
        #region Client Mods
        public static class Clients
        {
            public static class Teleport
            {
                
                    private static float[] GetOrigin(uint Client)
                    {
                        return PS3.ReadFloatLength(0x110a29c + (Client * 0x3980), 3);
                    }

                    private static void SetOrigin(uint Client, float[] Origin)
                    {
                        PS3.WriteFloatArray(0x110a29c + (Client * 0x3980), Origin);
                    }

                    public static void TeleportAllTo(uint Client)
                    {
                        float[] Origin = GetOrigin(Client);
                        for (uint i = 0; i < 18; i++)
                        {
                            if (Client == i) { }
                            else
                            {
                                SetOrigin(i, Origin);
                            }
                        }
                    }

                    public static void TeleportCToC(uint Client, uint toClient)
                    {
                        float[] Origin = GetOrigin(toClient);
                        SetOrigin(Client, Origin);
                    }
                   
                    public static Boolean isSameTeam(uint Owner, uint Victim)
                    {
                        byte team1 = PS3.ReadByte(0x0110d657 + (0x3980 * (uint)GetHostNumber()));
                        byte team2 = PS3.ReadByte(0x0110d657 + (0x3980 * (uint)Victim));
                        return team1 == team2;
                    }

                   

                    public static void teleportTeam()
                    {
                            for (uint i = 0; i < 18; i++)
                            {

                                if ((PS3.ReadInt(0xFCA41D + (i * 0x280)) > 0) && !isSameTeam((uint)GetHostNumber(), i))
                                {
                                    continue;
                                }
                                else 
                                
                                {
                                    float[] Origin = GetOrigin((uint)GetHostNumber());
                                    SetOrigin(i, Origin);
                                }
                            }
                    }
                    public static void teleportETeamm()
                    {

                        for (uint i = 0; i < 18; i++)
                        {

                            if ((PS3.ReadInt(0xFCA41D + (i * 0x280)) > 0) && !isSameTeam((uint)GetHostNumber(), i))
                            {
                                float[] Origin = GetOrigin((uint)GetHostNumber());
                                SetOrigin(i, Origin);
                            }
                            else
                            {
                                
                            }
                        }
                    }
            
                    public static void TeleporttoSecretRoom(uint Client)
                    {
                        
                         //if(MapName() == "Seatown")
                         //{
                         //    float[] dome = { -2030, 1520, 48 };
                         //    SetOrigin(Client, dome);
                         //}
                         
                    }
            }

            public static string MapName()
            {

                byte[] MAPN = new byte[17];

                string Mapstring = "";
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                PS3.GetMemory(0x11f92ad, ref MAPN);
                Mapstring = encoding.GetString(MAPN);
                string NAMEPMAP = "";
                NAMEPMAP = Mapstring;

                if (Mapstring.Contains("mp_mogadishu"))
                {
                    NAMEPMAP = "Bakaara";
                }
                if (Mapstring.Contains("mp_terminal"))
                {
                    NAMEPMAP = "Terminal";
                }
                if (Mapstring.Contains("mp_seatown"))
                {
                    NAMEPMAP = "Seatown";
                }
                if (Mapstring.Contains("mp_dome"))
                {
                    NAMEPMAP = "Dome";
                }
                if (Mapstring.Contains("mp_plaza2"))
                {
                    NAMEPMAP = "Arkaden";
                }
                if (Mapstring.Contains("mp_paris"))
                {
                    NAMEPMAP = "Resistance";
                }
                if (Mapstring.Contains("mp_exchange"))
                {
                    NAMEPMAP = "Exchange";
                }
                if (Mapstring.Contains("mp_bootleg"))
                {
                    NAMEPMAP = "Bootleg";
                }
                if (Mapstring.Contains("mp_carbon"))
                {
                    NAMEPMAP = "Carbon";
                }
                if (Mapstring.Contains("mp_hardhat"))
                {
                    NAMEPMAP = "Hardhat";
                }
                if (Mapstring.Contains("mp_alpha"))
                {
                    NAMEPMAP = "mp_alpha";
                }
                if (Mapstring.Contains("mp_village"))
                {
                    NAMEPMAP = "Village";
                }
                if (Mapstring.Contains("mp_lambeth"))
                {
                    NAMEPMAP = "mp_lambeth";
                }
                if (Mapstring.Contains("mp_radar"))
                {
                    NAMEPMAP = "Outpost";
                }
                if (Mapstring.Contains("mp_interchange"))
                {
                    NAMEPMAP = "Interchange";
                }
                if (Mapstring.Contains("mp_underground"))
                {
                    NAMEPMAP = "Underground";
                }
                if (Mapstring.Contains("mp_bravo"))
                {
                    NAMEPMAP = "mp_bravo";
                }
                return NAMEPMAP;
            }
            public static void JammRadar(uint Client, bool State)
            {
                if (State == true)
                {
                    PS3.SetMemory(0x0110d73f + (Client * 0x3980), new byte[] { 0x01, 0xFF });
                }
                if (State == false)
                {
                    PS3.SetMemory(0x0110d73f + (Client * 0x3980), new byte[] { 0x00, 0x00 });
                }
            }
            public static void LagPlayer(int client, bool state)
            {
                if (state)
                {
                    PS3.SetMemory((uint)(0x110a280 + (client * 0x3980)), new byte[] { 0x80 });
                }
                else
                {
                    PS3.SetMemory((uint)(0x110a280 + (client * 0x3980)), new byte[] { 0x00 });
                }
            }

            public static void SpinMode(Int32 client)
            {
                PS3.SetMemory(0x110a280 + 0x64 + ((UInt32)client * 0x3980), new Byte[] { 0x44 });

                for (Byte i = 0x00; i < 0x57; i++)
                {
                    PS3.WriteByte(0x110a280 + 0x65 + ((UInt32)client * 0x3980), i);
                    System.Threading.Thread.Sleep(50);

                }
            }

            public static void TakeWeapon(Int32 client)
            {

                PS3.SetMemory(0x0110A4F0 + (0x3980 * (uint)client), new byte[] { 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x45, 0x00, 0x00, 0x00, 0x5C, 0x00, 0x00,
                0x00, 0x8B, 0x00, 0x00, 0x00, 0x68, 0x00, 0x00, 0x00, 0x67, 0x00, 0x00, 0x00, 0x51, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x42, 0x00, 0x00, 0x00,
                0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x8B, 0x0F, 0xFF, 0xFF, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08,
                0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x42, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x1A, 0x00, 0x00, 0x00, 0x50, 0x00, 0x00, 0x00, 0x45, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x51, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x8B, 0x00, 0x0F, 0xFF, 0x00, 0x00,
                0x00, 0x00, 0x5C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x67, 0x00, 0x00, 0xFF, 0x00,
                0x00, 0x00, 0x00, 0x68, 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08,
                0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x42, 0x00, 0x00, 0x00,
                0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x28, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x45, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x8B, 0x00, 0x0F, 0xFF, 0xFF, 0x00, 0x00, 0x00 });
            }

            public static void Turtle(Int32 client)
            {
                PS3.SetMemory(0x110D640 + 0x3980 * (uint)client, new byte[] { 0x3F, 0x00, 0x00, 0x00 });
            }

            public static void Speedx2(Int32 client)
            {
                PS3.SetMemory(0x110D640 + 0x3980 * (uint)client, new byte[] { 0x3F, 0xFF, 0x00, 0x00 });
            }

            public static void Speedx4(Int32 client)
            {
                PS3.SetMemory(0x110D640 + 0x3980 * (uint)client, new byte[] { 0x40, 0x30, 0x00, 0x00 });
            }

            public static void Default(Int32 client)
            {
                PS3.SetMemory(0x110D640 + 0x3980 * (uint)client, new byte[] { 0x3F, 0x66, 0x66, 0x67 });
            }

            public static void Akimboon(Int32 Client)
            {
                PS3.SetMemory(0x0110a549 + (0x3980 * (uint)Client), new byte[] { 0x01 });
                PS3.SetMemory(0x0110a531 + (0x3980 * (uint)Client), new byte[] { 0x01 });
            }

            public static void Akimbooff(Int32 Client)
            {
                PS3.SetMemory(0x0110a549 + (0x3980 * (uint)Client), new byte[] { 0x00 });
                PS3.SetMemory(0x0110a531 + (0x3980 * (uint)Client), new byte[] { 0x00 });
            }

            public static void Derank(Int32 client)
            {
                PS3.SetMemory(0x110d6bb + ((UInt32)client * 0x3980), new byte[] { 0x00 });
            }
            public static void Maxrank(int client)
            {
                PS3.SetMemory(0x110d6bb + ((UInt32)client * 0x3980), new byte[] { 0x4F });
            }

            public static void ClientName(int client, string name)
            {
                PS3.SetMemory((uint)(0x110d694 * (client * 0x3980)), new byte[30]);
                PS3.SetMemory((uint)(0x110d694 * (client * 0x3980)), Encoding.Default.GetBytes(name));
            }

            public static void ClientPrestige(int client, int prestige)
            {
                PS3.SetMemory((uint)(0x110d6bf + (client * 0x3980)), BitConverter.GetBytes(prestige));
            }


            public static void ExplosiveBullets(int client, bool state)
            {
                if (state)
                {
                    PS3.SetMemory((uint)(0x110a773 + (client * 0x3980)), new byte[] { 0xc5, 0xff });
                }
                else
                {
                    PS3.SetMemory((uint)(0x110a773 + (client * 0x3980)), new byte[2]);
                }
            }

            public static void FreezePlayer(int client, bool state)
            {
                if (state)
                { //0x110a280
                    PS3.SetMemory((uint)(0x110a280 + (client * 0x3980)), new byte[] { 0x30 });
                }
                else
                {
                    PS3.SetMemory((uint)(0x110a280 + (client * 0x3980)), new byte[] { 0x00 });
                }
            }

            public static float[] getLocation(int client)
            {
                uint num = 0x110a280;
                return new float[] { PS3.ReadFloat((num + 0x1c) + ((uint)(0x3980 * client))), PS3.ReadFloat((num + 0x20) + ((uint)(0x3980 * client))), PS3.ReadFloat((num + 0x24) + ((uint)(0x3980 * client))) };
            }

            public static uint getPlayerState(int clientIndex)
            {
                byte[] array = PS3.ReadBytes((uint)((0xfca280 + (clientIndex * 640)) + 0x158), 4);
                Array.Reverse(array);
                return BitConverter.ToUInt32(array, 0);
            }

            public static void InfAmmo(int client, bool state)
            {
                if (state)
                {
                    PS3.SetMemory((uint)(0x110a6a8 + (client * 0x3980)), new byte[] { 15, 0xff, 0xff, 0xff, 15, 0xff, 0xff, 0xff });
                    PS3.SetMemory((uint)(0x110a628 + (client * 0x3980)), new byte[] { 15, 0xff, 0xff, 0xff, 15, 0xff, 0xff, 0xff });
                    PS3.SetMemory((uint)(0x110a618 + (client * 0x3980)), new byte[] { 15, 0xff, 0xff, 0xff, 15, 0xff, 0xff, 0xff });
                    PS3.SetMemory((uint)(0x110a690 + (client * 0x3980)), new byte[] { 15, 0xff, 0xff, 0xff, 15, 0xff, 0xff, 0xff });
                    PS3.SetMemory((uint)(0x110a6b4 + (client * 0x3980)), new byte[] { 15, 0xff, 0xff, 0xff, 15, 0xff, 0xff, 0xff });
                    PS3.SetMemory((uint)(0x110a69c + (client * 0x3980)), new byte[] { 15, 0xff, 0xff, 0xff, 15, 0xff, 0xff, 0xff });
                }
                else
                {
                    PS3.SetMemory((uint)(0x110a6a8 + (client * 0x3980)), new byte[8]);
                    PS3.SetMemory((uint)(0x110a628 + (client * 0x3980)), new byte[8]);
                    PS3.SetMemory((uint)(0x110a618 + (client * 0x3980)), new byte[8]);
                    PS3.SetMemory((uint)(0x110a690 + (client * 0x3980)), new byte[8]);
                    PS3.SetMemory((uint)(0x110a6b4 + (client * 0x3980)), new byte[8]);
                    PS3.SetMemory((uint)(0x110a69c + (client * 0x3980)), new byte[8]);
                }
            }

            public static void MW2Wallhack(int client, bool state)
            {
                byte[] buffer;
                if (state)
                {
                    buffer = new byte[6];
                    buffer[0] = 0x10;
                    buffer[5] = 9;
                    PS3.SetMemory((uint)(0x110a292 + (client * 0x3980)), buffer);
                }
                else
                {
                    buffer = new byte[6];
                    buffer[0] = 0x10;
                    PS3.SetMemory((uint)(0x110a292 + (client * 0x3980)), buffer);
                }
            }


            public static void RedBox(int client, bool state)
            {
                if (state)
                {
                    PS3.SetMemory((uint)(0x110a293 + (client * 0x3980)), new byte[] { 0x55 });
                }
                else
                {
                    PS3.SetMemory((uint)(0x110a293 + (client * 0x3980)), new byte[1]);
                }
            }

            public static void setLocation(int client, float[] newLoc)
            {
                uint num = 0x110a280;
                PS3.WriteFloat((num + 0x1c) + ((uint)(0x3980 * client)), newLoc[0]);
                PS3.WriteFloat((num + 0x20) + ((uint)(0x3980 * client)), newLoc[1]);
                PS3.WriteFloat((num + 0x24) + ((uint)(0x3980 * client)), newLoc[2]);
            }


            public static void Special(int client, Killstreaks weapon)
            {
                byte[] buffer;
                if (weapon.ToString() == "AC130")
                {
                    buffer = new byte[3];
                    buffer[2] = 0x69;
                    PS3.SetMemory((uint)(0x110a4fd + (client * 0x3980)), buffer);
                    buffer = new byte[3];
                    buffer[2] = 0x69;
                    PS3.SetMemory((uint)(0x110a5f1 + (client * 0x3980)), buffer);
                    buffer = new byte[3];
                    buffer[2] = 0x69;
                    PS3.SetMemory((uint)(0x110a6a5 + (client * 0x3980)), buffer);
                    PS3.SetMemory((uint)(0x110a6a8 + (client * 0x3980)), new byte[] { 15, 0xff, 0xff, 0xff });
                }
                if (weapon.ToString() == "Chopper")
                {
                    buffer = new byte[3];
                    buffer[2] = 0x7d;
                    PS3.SetMemory((uint)(0x110a4fd + (client * 0x3980)), buffer);
                    buffer = new byte[3];
                    buffer[2] = 0x7d;
                    PS3.SetMemory((uint)(0x110a5f1 + (client * 0x3980)), buffer);
                    buffer = new byte[3];
                    buffer[2] = 0x7d;
                    PS3.SetMemory((uint)(0x110a6a5 + (client * 0x3980)), buffer);
                    PS3.SetMemory((uint)(0x110a6a8 + (client * 0x3980)), new byte[] { 15, 0xff, 0xff, 0xff });
                }
                if (weapon.ToString() == "PaveLow")
                {
                    buffer = new byte[3];
                    buffer[2] = 0x71;
                    PS3.SetMemory((uint)(0x110a4fd + (client * 0x3980)), buffer);
                    buffer = new byte[3];
                    buffer[2] = 0x71;
                    PS3.SetMemory((uint)(0x110a5f1 + (client * 0x3980)), buffer);
                    buffer = new byte[3];
                    buffer[2] = 0x71;
                    PS3.SetMemory((uint)(0x110a6a5 + (client * 0x3980)), buffer);
                    PS3.SetMemory((uint)(0x110a6a8 + (client * 0x3980)), new byte[] { 15, 0xff, 0xff, 0xff });
                }
                if (weapon.ToString() == "Harrier")
                {
                    buffer = new byte[3];
                    buffer[2] = 0x70;
                    PS3.SetMemory((uint)(0x110a4fd + (client * 0x3980)), buffer);
                    buffer = new byte[3];
                    buffer[2] = 0x70;
                    PS3.SetMemory((uint)(0x110a5f1 + (client * 0x3980)), buffer);
                    buffer = new byte[3];
                    buffer[2] = 0x70;
                    PS3.SetMemory((uint)(0x110a6a5 + (client * 0x3980)), buffer);
                    PS3.SetMemory((uint)(0x110a6a8 + (client * 0x3980)), new byte[] { 15, 0xff, 0xff, 0xff });
                }
            }

            public static void Suicide(int Client)
            {
                PS3.WriteByte(0xFCA381 + ((uint)Client * 0x280), 1);
                Thread.Sleep(500);
                PS3.WriteByte(0xFCA381 + ((uint)Client * 0x280), 0);
            }


            public static void Ufo(int client, bool state)
            {
                if (state)
                {
                    PS3.SetMemory((uint)(0x110d87f + (client * 0x3980)), new byte[] { 1 });
                }
                else
                {
                    PS3.SetMemory((uint)(0x110d87f + (client * 0x3980)), new byte[1]);
                }
            }

            public static uint UseButtonMonitoring(int client)
            {
                return (getPlayerState(client) + 0x3609);
            }



            public enum Killstreaks
            {
                AC130,
                Chopper,
                PaveLow,
                Harrier
            }

        }
        #endregion
        #region Weapon mods
        public static class Weapons
        {
            public static class Camos
            {
                public static Byte
                    Nothing = 0x00,
                    Delta = 0x01,
                    Snow = 0x02,
                    Multicam = 0x03,
                    Digital = 0x04,
                    Hex = 0x05,
                    Choco = 0x06,
                    Snake = 0x07,
                    Blue = 0x08,
                    Red = 0x09,
                    Autumn = 0x0a,
                    Gold = 0x0b,
                    Winter = 0x0c,
                    Marine = 0x0d;
            }
            public static void InfAmmo(Int32 client)
            {

                byte[] PEmptyN = new byte[] { 0x0f, 0xff, 0xff, 0xff };
                byte[] PEmptyN1 = new byte[] { 0x0f, 0xff, 0xff };

                PS3.SetMemory(0x0110a6ab + (0x3980 * (UInt32)client), PEmptyN);
                PS3.SetMemory(0x0110a629 + (0x3980 * (UInt32)client), PEmptyN1);

                byte[] PEmptyN2 = new byte[] { 0x0f, 0xff, 0xff, 0xff };
                byte[] PEmptyN3 = new byte[] { 0x0f, 0xff, 0xff };

                PS3.SetMemory(0x0110a691 + (0x3980 * (UInt32)client), PEmptyN2);
                PS3.SetMemory(0x0110a619 + (0x3980 * (UInt32)client), PEmptyN3);
                PS3.SetMemory(0x0110a690 + (0x3980 * (UInt32)client), PEmptyN3);
                PS3.SetMemory(0x0110a6a8 + (0x3980 * (UInt32)client), PEmptyN3);
                PS3.SetMemory(0x0110a6cd + (0x3980 * (UInt32)client), PEmptyN3);
                PS3.SetMemory(0x0110a6c0 + (0x3980 * (UInt32)client), PEmptyN3);
                PS3.SetMemory(0x0110a69c + (0x3980 * (UInt32)client), PEmptyN3);
                PS3.SetMemory(0x0110a6c0 + (0x3980 * (UInt32)client), PEmptyN3);
                PS3.SetMemory(0x0110a6b4 + (0x3980 * (UInt32)client), PEmptyN3);
            }

            public static void ChangeWeapon(Int32 clientIndex, Int32 Inventory, Int32 Attachment1, Byte Attachment2AndCamo, String Weapon)
            {
                Int32 weaponIndex = GetWeaponIndexForName(Weapon);
                if (Inventory == 0)
                {
                    PS3.WriteBytes(Offsets.Funcs.G_Client(clientIndex, Offsets.PrimaryWeapon), new Byte[4]);
                    PS3.WriteInt32(Offsets.Funcs.G_Client(clientIndex, Offsets.PrimaryWeapon), weaponIndex);
                    PS3.WriteInt32(Offsets.Funcs.G_Client(clientIndex, Offsets.PrimaryWeapon - 2), Attachment1);
                    PS3.WriteByte(Offsets.Funcs.G_Client(clientIndex, Offsets.PrimaryWeapon + 2), Attachment2AndCamo);
                    RPC.Call(Offsets.G_InitializeAmmo, new Object[] { Offsets.Funcs.G_Entity(clientIndex, 0), (UInt32)weaponIndex, 0, 0x270f });
                    G_SelectWeaponIndex(clientIndex, weaponIndex);
                }
                if (Inventory == 1)
                {
                    PS3.WriteBytes(Offsets.Funcs.G_Client(clientIndex, Offsets.SecondaryWeapon), new Byte[4]);
                    PS3.WriteInt32(Offsets.Funcs.G_Client(clientIndex, Offsets.SecondaryWeapon), weaponIndex);
                    PS3.WriteInt32(Offsets.Funcs.G_Client(clientIndex, Offsets.SecondaryWeapon - 2), Attachment1);
                    PS3.WriteByte(Offsets.Funcs.G_Client(clientIndex, Offsets.SecondaryWeapon + 2), Attachment2AndCamo);
                    RPC.Call(Offsets.G_InitializeAmmo, new Object[] { Offsets.Funcs.G_Entity(clientIndex, 0), (UInt32)weaponIndex, 0, 0x270f });
                    G_SelectWeaponIndex(clientIndex, weaponIndex);
                }
            }
            public static void G_SelectWeaponIndex(Int32 clientIndex, Int32 WeaponIndex)
            {
                SV_GameSendServerCommand(clientIndex, "a " + WeaponIndex);
            }
            public static void TakeWeapon(Int32 clientIndex, Int32 weaponIndex)
            {
                RPC.Call(Offsets.BG_TakePlayerWeapon, new Object[] { Offsets.Funcs.G_Client(clientIndex, 0), weaponIndex, 0 });
            }
            public static void GiveWeapon(Int32 clientIndex, String Weapon)
            {
                Int32 weaponIndex = GetWeaponIndexForName(Weapon);
                RPC.Call(Offsets.G_GivePlayerWeapon, new Object[] { Offsets.Funcs.G_Client(clientIndex, 0), (UInt32)weaponIndex, 0 });
                RPC.Call(Offsets.G_InitializeAmmo, new Object[] { Offsets.Funcs.G_Entity(clientIndex, 0), (UInt32)weaponIndex, 0, 0x270f });
                G_SelectWeaponIndex(clientIndex, weaponIndex);
            }
            public static Int32 GetWeaponIndexForName(String WeaponName)
            {
                RPC.Call(Offsets.BG_GetWeaponIndexForName, new Object[] { 0x1100000, WeaponName });
                return PS3.ReadInt32(0x1100000);
            }
            public static void ChangeCamo(Int32 clientIndex, Byte Camo)
            {
                PS3.WriteByte(0x0110a4fe + ((UInt32)clientIndex * Offsets.G_ClientSize), Camo);
                PS3.WriteByte(0x0110a5f2 + ((UInt32)clientIndex * Offsets.G_ClientSize), Camo);
                PS3.WriteByte(0x0110a626 + ((UInt32)clientIndex * Offsets.G_ClientSize), Camo);
                PS3.WriteByte(0x0110a6a6 + ((UInt32)clientIndex * Offsets.G_ClientSize), Camo);
            }
        }

        #endregion
        #region AllPerks
        public static void allPerks(Int32 client)
        {

            PS3.SetMemory(0x110A76D + (0x3980 * (UInt32)client), new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });
        }
        #endregion
        #region InfAmmo
        public static void InfAmmo(Int32 client)
        {//Credits To BLB < for this
            byte[] PEmptyN = new byte[] { 0x0f, 0xff, 0xff, 0xff };
            byte[] PEmptyN1 = new byte[] { 0x0f, 0xff, 0xff };
            PS3.SetMemory(0x0110a6ab + (0x3980 * (UInt32)client), PEmptyN);
            PS3.SetMemory(0x0110a629 + (0x3980 * (UInt32)client), PEmptyN1);
            byte[] PEmptyN2 = new byte[] { 0x0f, 0xff, 0xff, 0xff };
            byte[] PEmptyN3 = new byte[] { 0x0f, 0xff, 0xff };
            PS3.SetMemory(0x0110a691 + (0x3980 * (UInt32)client), PEmptyN2);
            PS3.SetMemory(0x0110a619 + (0x3980 * (UInt32)client), PEmptyN3);
            PS3.SetMemory(0x0110a690 + (0x3980 * (UInt32)client), PEmptyN3);
            PS3.SetMemory(0x0110a6a8 + (0x3980 * (UInt32)client), PEmptyN3);
            PS3.SetMemory(0x0110a6cd + (0x3980 * (UInt32)client), PEmptyN3);
            PS3.SetMemory(0x0110a6c0 + (0x3980 * (UInt32)client), PEmptyN3);
            PS3.SetMemory(0x0110a69c + (0x3980 * (UInt32)client), PEmptyN3);
            PS3.SetMemory(0x0110a6c0 + (0x3980 * (UInt32)client), PEmptyN3);
            PS3.SetMemory(0x0110a6b4 + (0x3980 * (UInt32)client), PEmptyN3);
        }
        #endregion
        #region ServerInFo
        public static class ServerInfo
        {//credits to Seb5594 for this
            public static String ReturnInfos(Int32 Index)
            {

                return Encoding.ASCII.GetString(PS3.ReadBytes(0x8360d5, 0x100)).Replace(@"\", "|").Split(new char[] { '|' })[Index];

            }
            public static String getHostName()
            {
                String str = ReturnInfos(0x10);
                switch (str)
                {
                    case "Modern Warfare 3":
                        return "Dedicated Server (No Player is Host)";
                    case "":
                        return "You are not In-Game";
                }
                return str;
            }
            public static String getGameMode()
            {
                switch (ReturnInfos(2))
                {
                    case "war":
                        return "Team Deathmatch";
                    case "dm":
                        return "Free for All";
                    case "sd":
                        return "Search and Destroy";
                    case "dom":
                        return "Domination";
                    case "conf":
                        return "Kill Confirmed";
                    case "sab":
                        return "Sabotage";
                    case "koth":
                        return "Head Quartes";
                    case "ctf":
                        return "Capture The Flag";
                    case "infect":
                        return "Infected";
                    case "sotf":
                        return "Hunted";
                    case "dd":
                        return "Demolition";
                    case "grnd":
                        return "Drop Zone";
                    case "tdef":
                        return "Team Defender";
                    case "tjugg":
                        return "Team Juggernaut";
                    case "jugg":
                        return "Juggernaut";
                    case "gun":
                        return "Gun Game";
                    case "oic":
                        return "One In The Chamber";
                }
                return "Unknown Gametype";
            }
            public static String getMapName()
            {
                switch (ReturnInfos(6))
                {
                    case "mp_alpha":
                        return "Lockdown";
                    case "mp_bootleg":
                        return "Bootleg";
                    case "mp_bravo":
                        return "Mission";
                    case "mp_carbon":
                        return "Carbon";
                    case "mp_dome":
                        return "Dome";
                    case "mp_exchange":
                        return "Downturn";
                    case "mp_hardhat":
                        return "Hardhat";
                    case "mp_interchange":
                        return "Interchange";
                    case "mp_lambeth":
                        return "Fallen";
                    case "mp_mogadishu":
                        return "Bakaara";
                    case "mp_paris":
                        return "Resistance";
                    case "mp_plaza2":
                        return "Arkaden";
                    case "mp_radar":
                        return "Outpost";
                    case "mp_seatown":
                        return "Seatown";
                    case "mp_underground":
                        return "Underground";
                    case "mp_village":
                        return "Village";
                    case "mp_aground_ss":
                        return "Aground";
                    case "mp_aqueduct_ss":
                        return "Aqueduct";
                    case "mp_cement":
                        return "Foundation";
                    case "mp_hillside_ss":
                        return "Getaway";
                    case "mp_italy":
                        return "Piazza";
                    case "mp_meteora":
                        return "Sanctuary";
                    case "mp_morningwood":
                        return "Black Box";
                    case "mp_overwatch":
                        return "Overwatch";
                    case "mp_park":
                        return "Liberation";
                    case "mp_qadeem":
                        return "Oasis";
                    case "mp_restrepo_ss":
                        return "Lookout";

                    case "mp_terminal_cls":
                        return "Terminal";
                }
                return "Unknown Map";
            }
        }
        #endregion
        #region KickPlayer
        public static void KickPlayer(uint client, String message)
        {//Credits To SC58< for this function
            RPC.Call(0x00223BD0, new Object[] { client, message });
        }
        #endregion
        #region SV_ExecuteClientCommand
        public static void SV_ExecuteClientCommand(Int32 client, String command)
        {
            RPC.Call(Offsets.SV_ExecuteClientCommand, new Object[] { client, command });//patched
        }
        #endregion
        #region godMode
        public static void godMode(Int32 client)
        {
            PS3.WriteByte(0x0FCA41E + ((UInt32)client * 0x280), 0x64);
        }
        public static void godMode1(Int32 client)
        {
            PS3.WriteByte(0x0FCA41E + ((UInt32)client * 0x280), 0x00);
        }
        #endregion
        #region Freeze PS3
        public static void PS3Freeze(Int32 client)
        {
            PS3.SetMemory(0x0110A4FF + ((UInt32)client * 0x3980), new byte[] {0x4a, 0x4a, 0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a, 0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a, 0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a, 0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,
                0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a});
        }

        #endregion
        #region SV_GameSendServerCommand
        public static void SV_GameSendServerCommand(Int32 client, String command)
        {//Credits To SC58< for this function
            RPC.Call(Offsets.SV_GameSendServerCommand, new Object[] { client, 0, command });
        }
        #endregion
        #region iPrintl
        public static void iPrintln(Int32 client, string Text)
        {
            SV_GameSendServerCommand(client, "c \"" + Text + "\"");
            Thread.Sleep(20);
        }
        #endregion
        #region RedBoxes
        public static void redBoxes(Int32 client)
        {//Credits To INSAN3LY_D34TH For Offest
            PS3.WriteByte(0x0110a293 + ((UInt32)client * 0x3980), 0x55);
        }
        #endregion
        #region AutoShoot
        public static void AutoShoot(Int32 client)
        {
            if (Buttons.DetectButton(client) == Buttons.L1 + Buttons.R1)
            {
                PS3.WriteByte(0x110a4c7 + ((UInt32)client * 0x3980), 0x01);
                //Credits to Mango_Knife for AutoShoot OffSet :)
            }
        }
        #endregion
        #region Restart
        public static void restartGame()
        {
            RPC.Call(0x00223B20);
        }
        #endregion
        #region Ghetto Advanced No CLip
        public static void IsAirborn(Int32 client)
        {//Credits To kiwi_modz
            float Velocity = PS3.ReadFloat(Offsets.Funcs.G_Client(client, 0x30));
            Velocity = 5;
            PS3.WriteFloat(Offsets.Funcs.G_Client(client, 0x30), Velocity);
        }
        public static void MoveUp(Int32 client)
        {//Credits To Sticky < for this function that was originally called "double jump"
            //He Ported this function from se7ensins.com so credits to that aswell.
            //I made Ghetto Shit with this Func to start with :)

            float Velocity = PS3.ReadFloat(Offsets.Funcs.G_Client(client, 0x30));
            Velocity += 50;
            PS3.WriteFloat(Offsets.Funcs.G_Client(client, 0x30), Velocity);
        }
        public static void MoveDown(Int32 client)
        {//Credits To kiwi_modz
            System.Threading.Thread.Sleep(20);
            float Velocity = PS3.ReadFloat(Offsets.Funcs.G_Client(client, 0x30));
            Velocity -= 550;
            PS3.WriteFloat(Offsets.Funcs.G_Client(client, 0x30), Velocity);
        }

        public static void AdvancedNoClip(Int32 client)
        {//Credits To kiwi_modz
            if (Buttons.DetectButton(client) == Buttons.X)
            {
                MoveUp(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.X + Buttons.L1)
            {
                MoveUp(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.R3)
            {
                MoveDown(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.NoButtonPressed)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.R1)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.L1)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.L1 + Buttons.L3)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.L1 + Buttons.L3 + Buttons.R1)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.L1 + Buttons.R1)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.Square)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.L3)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.R3)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.L2)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.R2)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.O)
            {
                IsAirborn(client);
            }
        }
        #endregion
        #region NoReCoil
        public static void NoRecoil()
        {
            PS3.SetMemory(0xBE6D0, new Byte[] { 0x60, 0x00, 0x00, 0x00 });
            //Credit to Mango_Knife for the OffSet :)
        }
        #endregion
        #region KickGod
 
        public static void Kickgod(string message)
        {
            for (uint i = 0; i < 18; i++)
            {
                byte[] antigod1 = new byte[1];
                byte[] antigod2 = new byte[1];
                byte[] antigod3 = new byte[1];
                PS3.GetMemory(0x110a280 + 0x27b + (i * 0x3980), ref antigod1);
                PS3.GetMemory(0x110a280 + 0x283 + (i * 0x3980), ref antigod2);
                PS3.GetMemory(0x110a280 + 0x27f + (i * 0x3980), ref antigod3);
                if (antigod1[0] != 0x00 && antigod2[0] == 0x00 && antigod3[0] == 0x00)
                {
                    SV_GameSendServerCommand((Int32)i, "^1FUCK OFF");
                    Thread.Sleep(50);
                    PS3Freeze((Int32)i);//freeze clients console
                    Thread.Sleep(100);
                    KickPlayer(i, message);//kick the fuck out
                }
            }
        }
        #endregion
        #region PlayerFX

        public static uint SetFX(UInt32 Client, Int32 FX_Value, uint Distance)
        {
            float[] Origin = GetOrigin(Client);
            float[] Angles = GetAngles(Client);
            Origin[2] += 59;
            return Functions.PlayFX(AnglesToForward(Origin, Angles, Distance), Angles, FX_Value);



        }
        public static void Earthquake(int Duration, float[] origin, float radius, float scale)
        {
            int ent = RPC.Call(0x1C0B7C, origin, 0x5F);
            PS3.WriteFloat((uint)ent + 0x5C, radius);
            PS3.WriteFloat((uint)ent + 0x54, scale);
            PS3.WriteFloat((uint)ent + 0x58, Duration);
            PS3.WriteInt32((uint)ent + 0xD8, 0x00);
        }
        public static uint PlayFXSC(float[] Origin, float[] Angles, int EffectIndex)
        {
            uint ent = (uint)RPC.Call(0x1C0B7C, Origin, 0x56); //G_Temp
            PS3.WriteInt32(ent + 0xA0, EffectIndex);
            PS3.WriteInt32(ent + 0xD8, 0);
            PS3.WriteFloat(ent + 0x40, 0f);
            PS3.WriteFloat(ent + 0x44, 0f);
            PS3.WriteFloat(ent + 0x3C, 270f);
            Origin[1] += 21;
            return ent;
        }
        public static uint PlayFXSCT(float[] Origin, float[] Angles, int EffectIndex)
        {
            uint ent = (uint)RPC.Call(0x1C0B7C, Origin, 0x56); //G_Temp
            PS3.WriteInt32(ent + 0xA0, EffectIndex);
            PS3.WriteInt32(ent + 0xD8, 0);
            PS3.WriteFloat(ent + 0x40, 0f);
            PS3.WriteFloat(ent + 0x44, 0f);
            PS3.WriteFloat(ent + 0x3C, 270f);
            Origin[2] += 21;
            return ent;
        }
        public static uint PlayFX(float[] Origin, float[] Angles, int EffectIndex)
        {
            uint ent = (uint)RPC.Call(0x1C0B7C, Origin, 0x56); //G_Temp
            PS3.WriteInt32(ent + 0xA0, EffectIndex);
            PS3.WriteInt32(ent + 0xD8, 0);
            PS3.WriteFloat(ent + 0x40, 0f);
            PS3.WriteFloat(ent + 0x44, 0f);
            PS3.WriteFloat(ent + 0x3C, 270f);
            Origin[2] += 20;
            return ent;
        }
        #endregion
        #region MysteryBox
        public static class MysteryBox
        {
            #region Variables
            public static uint Weapon = 0;
            public static uint[] MBIndexes = new uint[3];
            public static string WeaponName = null;
            public static Thread MBThread;
            #endregion
            #region Dvar_GetBool
            public static bool Dvar_GetBool(string DVAR)
            {//0x00291060 - Dvar_GetBool(const char *dvarName)
                bool State;
                uint Value = (uint)RPC.Call(0x00291060, DVAR);
                if (Value == 1)
                    State = true;
                else
                    State = false;
                return State;
            }
            #endregion

            #region HUDS
            public static uint Element(uint Index)
            {
                return 0xF0E10C + ((Index) * 0xB4);
            }

            public static uint StoreText(uint Index, decimal Client, string Text, int Font, float FontScale, int X, int Y, decimal R, decimal G, decimal B, decimal A, decimal R1, decimal G1, decimal B1, decimal A1)
            {
                uint elem = Element(Index);
                PS3.WriteInt(elem + 0x84, RPC.Call(0x1BE6CC, Text));
                PS3.WriteInt(elem + 0x24, Font);
                PS3.WriteFloat(elem + 0x14, FontScale);
                PS3.WriteFloat(elem + 0x4, X);
                PS3.WriteFloat(elem + 0x8, Y);
                PS3.SetMemory(elem + 0xa7, new byte[] { 7 });
                PS3.SetMemory(elem + 0x30, new byte[] { (byte)R, (byte)G, (byte)B, (byte)A });
                PS3.SetMemory(elem + 0x8C, new byte[] { (byte)R1, (byte)G1, (byte)B1, (byte)A1 });
                PS3.WriteInt(elem + 0xA8, (int)Client);
                System.Threading.Thread.Sleep(20);
                PS3.WriteInt(elem, 1);
                return elem;
            }
            #endregion

            #region Functions

            public static string ChangeWeaponModel()
            {
                int Value = 0;
                byte[] buffer = new byte[100];
                PS3.GetMemory(0x8360d5, ref buffer);
                System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
                string Map = Encoding.GetString(buffer).Split(Convert.ToChar(0x5c))[6];
                if (Map == "mp_seatown" | Map == "mp_plaza2" | Map == "mp_exchange" | Map == "mp_bootleg" | Map == "mp_alpha" | Map == "mp_village" | Map == "mp_bravo" | Map == "mp_courtyard_ss" | Map == "mp_aground_ss")
                    Value = -1;
                else
                    Value = 0;

                Random Random = new Random();
                switch (Random.Next(1, 50))
                {
                    case 1:
                        Weapon = (uint)Value + 4;
                        WeaponName = "Riotshield";
                        return "weapon_riot_shield_mp";
                    case 2:
                        Weapon = (uint)Value + 6;
                        WeaponName = ".44 Magnum";
                        return "weapon_44_magnum_iw5";
                    case 3:
                        Weapon = (uint)Value + 7;
                        WeaponName = "USP .45";
                        return "weapon_usp45_iw5";
                    case 4:
                        Weapon = (uint)Value + 9;
                        WeaponName = "Desert Eagle";
                        return "weapon_desert_eagle_iw5";
                    case 5:
                        Weapon = (uint)Value + 10;
                        WeaponName = "MP412";
                        return "weapon_mp412";
                    case 6:
                        Weapon = (uint)Value + 12;
                        WeaponName = "P99";
                        return "weapon_walther_p99_iw5";
                    case 7:
                        Weapon = (uint)Value + 13;
                        WeaponName = "Five-Seven";
                        return "weapon_fn_fiveseven_iw5";
                    case 8:
                        Weapon = (uint)Value + 14;
                        WeaponName = "FMG9";
                        return "weapon_fmg_iw5";
                    case 9:
                        Weapon = (uint)Value + 15;
                        WeaponName = "Skorpion";
                        return "weapon_skorpion_iw5";
                    case 10:
                        Weapon = (uint)Value + 16;
                        WeaponName = "MP9";
                        return "weapon_mp9_iw5";
                    case 11:
                        Weapon = (uint)Value + 17;
                        WeaponName = "G18";
                        return "weapon_g18_iw5";
                    case 12:
                        Weapon = (uint)Value + 18;
                        WeaponName = "MP5";
                        return "weapon_mp5_iw5";
                    case 13:
                        Weapon = (uint)Value + 19;
                        WeaponName = "PM-9";
                        return "weapon_uzi_m9_iw5";
                    case 14:
                        Weapon = (uint)Value + 20;
                        WeaponName = "P90";
                        return "weapon_p90_iw5";
                    case 15:
                        Weapon = (uint)Value + 21;
                        WeaponName = "PP90M1";
                        return "weapon_pp90m1_iw5";
                    case 16:
                        Weapon = (uint)Value + 22;
                        WeaponName = "UMP45";
                        return "weapon_ump45_iw5";
                    case 17:
                        Weapon = (uint)Value + 23;
                        WeaponName = "MP7";
                        return "weapon_mp7_iw5";
                    case 18:
                        Weapon = (uint)Value + 24;
                        WeaponName = "AK-47";
                        return "weapon_ak47_iw5";
                    case 19:
                        Weapon = (uint)Value + 25;
                        WeaponName = "M16A4";
                        return "weapon_m16_iw5";
                    case 20:
                        Weapon = (uint)Value + 26;
                        WeaponName = "M4A1";
                        return "weapon_m4_iw5";
                    case 21:
                        Weapon = (uint)Value + 27;
                        WeaponName = "FAD";
                        return "weapon_fad_iw5";
                    case 22:
                        Weapon = (uint)Value + 28;
                        WeaponName = "ACR 6.8";
                        return "weapon_remington_acr_iw5";
                    case 23:
                        Weapon = (uint)Value + 29;
                        WeaponName = "Typ 95";
                        return "weapon_type95_iw5";
                    case 24:
                        Weapon = (uint)Value + 30;
                        WeaponName = "MK14";
                        return "weapon_m14_iw5";
                    case 25:
                        Weapon = (uint)Value + 31;
                        WeaponName = "SCAR-L";
                        return "weapon_scar_iw5";
                    case 26:
                        Weapon = (uint)Value + 32;
                        WeaponName = "G36C";
                        return "weapon_g36_iw5";
                    case 27:
                        Weapon = (uint)Value + 33;
                        WeaponName = "CM901";
                        return "weapon_cm901";
                    case 28:
                        Weapon = (uint)Value + 35;
                        WeaponName = "M320 GLM";
                        return "weapon_m320_gl";
                    case 29:
                        Weapon = (uint)Value + 36;
                        WeaponName = "RPG-7";
                        return "weapon_rpg7";
                    case 30:
                        Weapon = (uint)Value + 37;
                        WeaponName = "SMAW";
                        return "weapon_smaw";
                    case 31:
                        Weapon = (uint)Value + 39;
                        WeaponName = "Javelin";
                        return "weapon_javelin";
                    case 32:
                        Weapon = (uint)Value + 40;
                        WeaponName = "XM25";
                        return "weapon_xm25";
                    case 33:
                        Weapon = (uint)Value + 12329;
                        WeaponName = "Dragunow";
                        return "weapon_dragunov_iw5";
                    case 34:
                        Weapon = (uint)Value + 12330;
                        WeaponName = "MSR";
                        return "weapon_remington_msr_iw5";
                    case 35:
                        Weapon = (uint)Value + 12331;
                        WeaponName = "BARRET KAL. .50";
                        return "weapon_m82_iw5";
                    case 36:
                        Weapon = (uint)Value + 12332;
                        WeaponName = "RSASS";
                        return "weapon_rsass_iw5";
                    case 37:
                        Weapon = (uint)Value + 12333;
                        WeaponName = "AS50";
                        return "weapon_as50_iw5";
                    case 38:
                        Weapon = (uint)Value + 12334;
                        WeaponName = "L118A";
                        return "weapon_l96a1_iw5";
                    case 39:
                        Weapon = (uint)Value + 47;
                        WeaponName = "KSG 12";
                        return "weapon_ksg_iw5";
                    case 40:
                        Weapon = (uint)Value + 48;
                        WeaponName = "MODELL 1887";
                        return "weapon_model1887";
                    case 41:
                        Weapon = (uint)Value + 49;
                        WeaponName = "STRIKER";
                        return "weapon_striker_iw5";
                    case 42:
                        Weapon = (uint)Value + 50;
                        WeaponName = "AA-12";
                        return "weapon_aa12_iw5";
                    case 43:
                        Weapon = (uint)Value + 51;
                        WeaponName = "USAS12";
                        return "weapon_usas12_iw5";
                    case 44:
                        Weapon = (uint)Value + 52;
                        WeaponName = "SPAS-12";
                        return "weapon_spas12_iw5";
                    case 45:
                        Weapon = (uint)Value + 54;
                        WeaponName = "M60E4";
                        return "weapon_m60_iw5";
                    case 46:
                        Weapon = (uint)Value + 17461;
                        WeaponName = "AUG";
                        return "weapon_steyr_digital";
                    case 47:
                        Weapon = (uint)Value + 55;
                        WeaponName = "MK46";
                        return "weapon_mk46_iw5";
                    case 48:
                        Weapon = (uint)Value + 56;
                        WeaponName = "PKP PECHENEG";
                        return "weapon_pecheneg_iw5";
                    case 49:
                        Weapon = (uint)Value + 57;
                        WeaponName = "L86 LSW";
                        return "weapon_sa80_iw5";
                    case 50:
                        Weapon = (uint)Value + 58;
                        WeaponName = "MG36";
                        return "weapon_mg36";
                }
                return null;
            }

            public static void MBFunction(float[] Origin, float[] Angles)
            {
                float[] BoxOrigin = Origin;
                float WeaponZ1 = 0;
                bool Running = false;
                uint ClientUsing = 0, WeaponID = 0;
                PS3.Connect();
                Origin[2] += 16;
                MBIndexes[0] = SolidModel(Origin, Angles, "com_plasticcase_trap_friendly", 0);
                MBIndexes[1] = SolidModel(new float[] { Origin[0], Origin[1], Origin[2] += 28 }, Angles, "tag_origin", 0);
                MBIndexes[2] = SolidModel(new float[] { Origin[0] += -8, Origin[1], Origin[2] += -18 }, Angles, "weapon_ak47_iw5", 0);
                WeaponID = MBIndexes[2];
                while (MBThread.IsAlive)
                {
                    if (Dvar_GetBool("cl_ingame") == false)
                    {
                        MBThread.Abort();
                        for (uint i = 0; i < 3; i++)
                            PS3.SetMemory(MBIndexes[i], new byte[0x280]);
                        PS3.SetMemory(0xF0E10C + (500 * 0xB4), new byte[18 * 0xB4]);
                    }
                    else
                    {
                        if (Running == false)
                        {
                            for (uint Client = 0; Client < 18; Client++)
                            {
                                if (PS3.ReadInt(0xFCA41D + (Client * 0x280)) > 0)
                                {
                                    float[] PlayerOrigin = PS3.ReadFloatLength(0x110a29c + (Client * 0x3980), 3);
                                    float X = PlayerOrigin[0] - BoxOrigin[0];
                                    float Y = PlayerOrigin[1] - BoxOrigin[1];
                                    float Z = PlayerOrigin[2] - (BoxOrigin[2] - 23);
                                    float Distance = (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
                                    if (Distance < 50)
                                    {
                                        StoreText(500 + Client, Client, "Press  for a Random Weapon", 7, 0.8f, 195, 300, 255, 255, 255, 255, 0, 0, 0, 0);
                                        byte[] Key = new byte[1];
                                        PS3.GetMemory(0x110D5E3 + (0x3980 * Client), ref Key);
                                        if (Key[0] == 0x20)
                                        {
                                            PS3.SetMemory(0xF0E10C + (500 * 0xB4), new byte[18 * 0xB4]);
                                            float WeaponZ = Origin[2];
                                            for (int i = 0; i < 37; i++)
                                            {
                                                PS3.WriteFloat(WeaponID + 0x20, WeaponZ += 0.7f);
                                                if ((i / 2) * 2 == i)
                                                {
                                                    PS3.WriteUInt(WeaponID + 0x58, (uint)RPC.Call(0x1BE7A8, ChangeWeaponModel()));
                                                }
                                                if (i == 36)
                                                {
                                                    break;
                                                }
                                                WeaponZ1 = WeaponZ;
                                                Thread.Sleep(100);
                                            }
                                            Running = true;
                                            ClientUsing = Client;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        PS3.SetMemory(Element(500 + Client), new byte[0xB4]);
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 37; i++)
                            {
                                float[] PlayerOrigin = PS3.ReadFloatLength(0x110a29c + (ClientUsing * 0x3980), 3);
                                float X = PlayerOrigin[0] - BoxOrigin[0];
                                float Y = PlayerOrigin[1] - BoxOrigin[1];
                                float Z = PlayerOrigin[2] - (BoxOrigin[2] - 23);
                                float Distance = (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
                                if (Distance < 50)
                                {
                                    StoreText(500 + ClientUsing, ClientUsing, "Press  for " + WeaponName, 7, 0.8f, 195, 300, 255, 255, 255, 255, 0, 0, 0, 0);
                                    byte[] Key = new byte[1];
                                    PS3.GetMemory(0x110D5E3 + (0x3980 * ClientUsing), ref Key);
                                    if (Key[0] == 0x20)
                                    {

                                        if (PS3.ReadInt(0x0110a5f0 + (ClientUsing * 0x3980)) == PS3.ReadInt(0x0110a4fc + (ClientUsing * 0x3980)))
                                        {
                                            PS3.WriteUInt(0x0110a4fc + (ClientUsing * 0x3980), Weapon);
                                            PS3.WriteUInt(0x0110a624 + (ClientUsing * 0x3980), Weapon);
                                            PS3.WriteUInt(0x0110a6a4 + (ClientUsing * 0x3980), Weapon);
                                        }
                                        else
                                        {
                                            PS3.WriteUInt(0x0110a4f4 + (ClientUsing * 0x3980), Weapon);
                                            PS3.WriteUInt(0x0110a68c + (ClientUsing * 0x3980), Weapon);
                                            PS3.WriteUInt(0x0110a614 + (ClientUsing * 0x3980), Weapon);
                                        }
                                        PS3.WriteUInt(0x0110a5f0 + (ClientUsing * 0x3980), Weapon);
                                        RPC.Call(0x18A29C, 0xFCA280 + (ClientUsing * 0x280), Weapon, "", 9999, 9999);
                                        PS3.WriteFloat(WeaponID + 0x20, Origin[2]);
                                        PS3.WriteUInt(WeaponID + 0x58, (uint)RPC.Call(0x1BE7A8, "weapon_ak47_iw5"));
                                        PS3.SetMemory(Element(500 + ClientUsing), new byte[0xB4]);
                                        Running = false;
                                        break;
                                    }
                                    else
                                    {
                                        PS3.WriteFloat(WeaponID + 0x20, WeaponZ1 += -0.7f);
                                        if (i == 36)
                                        {
                                            PS3.WriteUInt(WeaponID + 0x58, (uint)RPC.Call(0x1BE7A8, "weapon_ak47_iw5"));
                                            PS3.SetMemory(Element(500 + ClientUsing), new byte[0xB4]);
                                            Running = false;
                                            break;
                                        }
                                        Thread.Sleep(200);
                                    }
                                }
                                else
                                {
                                    PS3.SetMemory(Element(500 + ClientUsing), new byte[0xB4]);
                                    PS3.WriteFloat(WeaponID + 0x20, WeaponZ1 += -0.7f);
                                    if (i == 36)
                                    {
                                        PS3.WriteUInt(WeaponID + 0x58, (uint)RPC.Call(0x1BE7A8, "weapon_ak47_iw5"));
                                        PS3.SetMemory(Element(500 + ClientUsing), new byte[0xB4]);
                                        Running = false;
                                        break;
                                    }
                                    Thread.Sleep(200);
                                }
                            }
                            Thread.Sleep(2000);
                        }
                    }
                }
            }
            #endregion

            public static void Spawn(float[] Origin, float Yaw)
            {
                float[] Angles = new float[] { 0, Yaw, 0 };
                ThreadStart Start = null;
                Thread.Sleep(100);
                if (Start == null)
                {
                    Start = () => MBFunction(Origin, Angles);
                }
                MBThread = new Thread(Start);
                MBThread.IsBackground = true;
                MBThread.Start();
            }

            public static void DeleteMB()
            {
                MBThread.Abort();
                for (uint i = 0; i < 3; i++)
                    PS3.SetMemory(MBIndexes[i], new byte[0x280]);
                PS3.SetMemory(0xF0E10C + (500 * 0xB4), new byte[18 * 0xB4]);
            }
        }
        #endregion
        #region Misc
        public static string GetName(int Client)
        {
            byte[] buffer = new byte[16];
            PS3.GetMemory(0x0110D694 + 0x3980 * (uint)Client, ref buffer);
            string names = Encoding.ASCII.GetString(buffer);
            names = names.Replace("\0", "");
            return names;
        }
        public static void SetSunLight(int Client, double R, double G, double B)
        {
            SV_GameSendServerCommand(Client, "d 8 " + R + " " + G + " " + B);
        }

        public static void SpawnWall(UInt32 Client, uint Height, uint Length)
        {
            bool State = false;
            bool State1 = false;
            uint Count = Height;
            float[] Origin = new float[3];
            float[] NewOrigin = new float[3];
            float[] Angles = new float[3];
            float[] forward = new float[3];

            for (uint i = 0; i < Length * Height + 1; i++)
            {
                if (State == false)
                {
                    Origin = Functions.GetOrigin(Client);
                    NewOrigin = Origin;
                    Angles = Functions.GetAngles(Client);
                    forward = Functions.AnglesToForward(Origin, new float[] { 0, Angles[1], 0 }, 55);
                    State = true;
                }
                Functions.SolidModel(new float[] { forward[0], forward[1], Origin[2] }, new float[] { 0, Angles[1] + 90, 0 }, "com_plasticcase_friendly", 2);
                if (State1 == true)
                {
                    if (i == Count)
                    {
                        Origin[2] += -((Height - 1) * 25);
                        NewOrigin = Functions.AnglesToForward(NewOrigin, new float[] { 0, Angles[1] - 90, 0 }, 55);
                        forward = Functions.AnglesToForward(NewOrigin, new float[] { 0, Angles[1], 0 }, 55);
                        Count += Height;
                    }
                    else
                    {
                        Origin[2] += 25;
                    }
                }
                else
                {
                    State1 = true;

                }

            }
            State = false;
            State1 = false;
        }

        public static void SpawnO(UInt32 Client, uint Height, uint Length)
        {
            bool State = false;
            bool State1 = false;
            uint Count = Height;
            float[] Origin = new float[3];
            float[] NewOrigin = new float[3];
            float[] Angles = new float[3];
            float[] forward = new float[3];

            for (uint i = 0; i < Length * Height + 1; i++)
            {
                if (State == false)
                {
                    Origin = Functions.GetOrigin(Client);
                    NewOrigin = Origin;
                    Angles = Functions.GetAngles(Client);
                    forward = Functions.AnglesToForward(Origin, new float[] { 0, Angles[1], 0 }, 55);
                    Angles[1] += 15;
                    State = true;
                }
                Functions.SolidModel(new float[] { forward[0], forward[1], Origin[2] }, new float[] { 0, Angles[1] + 90, 0 }, "com_plasticcase_friendly", 2);
                if (State1 == true)
                {
                    if (i == Count)
                    {
                        Origin[2] += -((Height - 1) * 25);
                        NewOrigin = Functions.AnglesToForward(NewOrigin, new float[] { 0, Angles[1] - 90, 0 }, 55);
                        forward = Functions.AnglesToForward(NewOrigin, new float[] { 0, Angles[1], 0 }, 55);
                        Count += Height;
                        Angles[1] += 15;
                    }
                    else
                    {
                        Origin[2] += 25;
                    }
                }
                else
                {
                    State1 = true;

                }

            }
            State = false;
            State1 = false;
        }
        public static int GetHostNumber() { string MyName = PS3.ReadString(0x1bbbc2c); for (uint i = 0; i < 18; i++) { if (MyName == PS3.ReadString(0x0110d60c + (i * 0x3980))) return (int)i; } return -1; }
        public static void G_Damage(Int32 You, Int32 Enemy)
        {
            RPC.Call(0x183E18, Offsets.Funcs.G_Entity(Enemy), Offsets.Funcs.G_Entity(You), Offsets.Funcs.G_Entity(You), 0xD00CFF6C, 0xD00CFFA8, 120, 0, 1, 0, 0x1378, 0x10008DA0, 0xD00CFF24, 0xD00CF12C);
        }
        #endregion
        #region SolidModel

        public static uint SolidModel(float[] Origin, float[] Angles, string Model, Int32 Index)// = Bush.CarePackage "com_plasticcase_friendly"
        {
            uint Entity = (uint)RPC.Call(0x01C058C);//G_Spawn
            PS3.WriteFloatArray(Entity + 0x138, Origin);//Position
            PS3.WriteFloatArray(Entity + 0x144, Angles);//Orientation
            RPC.Call(0x01BEF5C, Entity, Model);//G_SetModel
            RPC.Call(0x01B6F68, Entity); //SP_script_model
            RPC.Call(0x002377B8, Entity);//SV_UnlinkEntity
            PS3.WriteByte(Entity + 0x101, 4);
            PS3.WriteInt(Entity + 0x8C, (Int32)Index);
            RPC.Call(0x0022925C, Entity);//SV_SetBrushModel
            RPC.Call(0x00237848, Entity);//SV_LinkEntity
            return Entity;
        }

        public static float[] GetOrigin(uint Client)
        {
            return PS3.ReadFloatLength(0x110a29c + (Client * 0x3980), 3);
        }

        public static float[] GetAngles(uint Client)
        {
            return PS3.ReadFloatLength(0x110a3d8 + (Client * 0x3980), 3);
        }

        public static float[] AnglesToForward(float[] Origin, float[] Angles, uint Distance)
        {
            float diff = Distance;
            float num = ((float)Math.Sin((Angles[0] * Math.PI) / 180)) * diff;
            float num1 = (float)Math.Sqrt(((diff * diff) - (num * num)));
            float num2 = ((float)Math.Sin((Angles[1] * Math.PI) / 180)) * num1;
            float num3 = ((float)Math.Cos((Angles[1] * Math.PI) / 180)) * num1;
            return new float[] { Origin[0] + num3, Origin[1] + num2, Origin[2] - num };
        }

        public static uint[] mods;
        public static void StairsToHeaven(uint Client, uint Stairs, int Time = 220)
        {
            uint[] Index = new uint[Stairs];
            float[] Origin = GetOrigin(Client);
            float[] Angles = new float[3];
            for (uint i = 0; i < Stairs; )
            {
                Index[i] = SolidModel(AnglesToForward(Origin, Angles, 60), Angles, "com_plasticcase_beige_big", 2);
                //Index[i] = PlayFXSC(AnglesToForward(Origin, Angles, 61), Angles, 66);
                //Index[i] = PlayFXSC(AnglesToForward(Origin, Angles, 61), Angles, 92);
                Angles[1] += 18;
                Origin[2] += 10;
                i++;
                Thread.Sleep(Time);
            }
            mods = Index;
        }

        public static void RemoveAll()
        {

            for (uint i = 0; i < mods.Length; i++)
                PS3.SetMemory(mods[i] + 0xF, new byte[] { 0x2 });
        }
        #endregion
        #region Spawn Turrent by JOHN_DAT_GOON
        public static class Spawn_Turrent
        {
            public static Int32 G_Spawn()
            {
                return RPC.Call(0x01C058C); // updated
            }

            public static Int32 OnValues(string Type, string ModelName, Single X, Single Y, Single Z, Single Pitch, Single Yaw, Single Roll)
            {
                int Ent = G_Spawn();
                PS3.WriteSingle((uint)Ent + 0x138, new float[] { X, Y, Z });
                PS3.WriteSingle((uint)Ent + 0x144, new float[] { Pitch, Yaw, Roll });
                RPC.Call(0x01BEF5C, Ent, ModelName);// G_SetModel
                RPC.Call(0x01CF0E8, Ent, Type);//G_SpawnTurret
                return Ent;
            }
            public static void SpawnCrate(float[] Origin, float Yaw)
            {
                float[] Angles = new float[] { 0, Yaw, 0 };

            }
            public static Int32 SpawnTurret(float[] Origin, float[] Angles, string Type, string ModelName)
            {
                int Ent = G_Spawn();
                PS3.WriteSingle((uint)Ent + 0x138, new float[] { Origin[0], Origin[1], Origin[2] });
                PS3.WriteSingle((uint)Ent + 0x144, new float[] { Angles[0], Angles[1], Angles[2] });
                RPC.Call(0x01BEF5C, Ent, ModelName);// G_SetModel
                RPC.Call(0x01CF0E8, Ent, Type);//G_SpawnTurret

                return Ent;
            }

            public static void OnAnglesToForward(uint Client)
            {
                float[] Origin = GetOrigin(Client);
                float[] Angles = GetAngles(Client);
                Origin[2] += 50;
                SpawnTurret(AnglesToForward(Origin, Angles, 10), Angles, "sentry_minigun_mp", "weapon_minigun");
            }
        }
        #endregion
        #region Aimbot_and_ForgeMode
        public static class Aimbot_and_ForgeMode
        {
            //Credits to
            //xCSBKx: Making this class the Aimbot and the ForgeMode Function
            //VezahModz: AnglestoForward Function
            //iMCSx and Seb5594 Read+Write Function
            #region Read + Write
            public static int ReadInt(uint Offset)
            {
                byte[] buffer = new byte[4];
                PS3.GetMemory(Offset, ref buffer);
                Array.Reverse(buffer);
                int Value = BitConverter.ToInt32(buffer, 0);
                return Value;
            }
            public static byte ReadByte(uint Offset)
            {
                byte[] buffer = new byte[1];
                PS3.GetMemory(Offset, ref buffer);
                return buffer[0];
            }
            public static float[] ReadFloatLength(uint Offset, int Length)
            {
                byte[] buffer = new byte[Length * 4];
                PS3.GetMemory(Offset, ref buffer);
                PS3.ReverseBytes(buffer);
                float[] Array = new float[Length];
                for (int i = 0; i < Length; i++)
                {
                    Array[i] = BitConverter.ToSingle(buffer, (Length - 1 - i) * 4);
                }
                return Array;
            }
            public static void SetFX(UInt32 Client, Int32 FX_Value)
            {
                Single[] Origin = clientsP(Client);
                PlayFX(Origin, FX_Value);
            }
            public static uint PlayFX(float[] Origin, int EffectIndex)
            {
                uint ent = (uint)RPC.Call(0x1C0B7C, Origin, 0x56);
                PS3.WriteInt32(ent + 0xA0, EffectIndex);
                PS3.WriteInt32(ent + 0xD8, 0);
                PS3.WriteFloat(ent + 0x40, 0f);
                PS3.WriteFloat(ent + 0x44, 0f);
                PS3.WriteFloat(ent + 0x3C, 270f);
                return ent;

            }
            public static Single[] ReadSingle(uint address, int length)
            {
                byte[] mem = PS3.ReadBytes(address, length * 4);
                Array.Reverse(mem);
                float[] numArray = new float[length];
                for (int index = 0; index < length; ++index)
                    numArray[index] = BitConverter.ToSingle(mem, (length - 1 - index) * 4);
                return numArray;
            }
            public static float[] clientsP(uint client)
            {
                float[] Origin;
                Origin = ReadSingle(0x0110A29C + 0x3980 * client, 3);
                return Origin;
            }
            public static void WriteFloatArray(uint Offset, float[] Array)
            {
                byte[] buffer = new byte[Array.Length * 4];
                for (int Lenght = 0; Lenght < Array.Length; Lenght++)
                {
                    PS3.ReverseBytes(BitConverter.GetBytes(Array[Lenght])).CopyTo(buffer, Lenght * 4);
                }
                PS3.SetMemory(Offset, buffer);
            }
            public static float ReadFloat(uint Offset)
            {
                byte[] buffer = new byte[4];
                PS3.GetMemory(Offset, ref buffer);
                Array.Reverse(buffer, 0, 4);
                return BitConverter.ToSingle(buffer, 0);
            }
            #endregion
            public static void Freeze(uint Client, bool State)
            {
                if (State == true)
                {
                    PS3.SetMemory(0x0110d87f + (Client * 0x3980), new byte[] { 0x04 });
                }
                else
                {
                    PS3.SetMemory(0x0110d87f + (Client * 0x3980), new byte[] { 0x00 });
                }
            }
            public static Boolean isSameTeam(uint Owner, uint Victim)
            {
                byte team1 = PS3.ReadByte(0x0110d657 + (0x3980 * (uint)Owner));
                byte team2 = PS3.ReadByte(0x0110d657 + (0x3980 * (uint)Victim));
                return team1 == team2;
            }
            public static void AimbotTeamBased(uint Client, uint Target)
            {
                #region Check if Dead / sameteam

                if (ReadInt(0xFCA41D + (Target * 0x280)) > 0)
                {
                    #region Stance
                    byte StanceByte = ReadByte(0x110d88a + (Target * 0x3980));
                    float Stance = 0;
                    if (StanceByte == 2)
                        Stance = 21;
                    else if (StanceByte == 1)
                        Stance = 47;
                    else
                        Stance = 0;
                    #endregion
                    #region Origin
                    float[] O1 = ReadFloatLength(0x110a29c + (Client * 0x3980), 3);
                    float[] O2 = ReadFloatLength(0x110a29c + (Target * 0x3980), 3);
                    O2[2] = O2[2] - Stance;
                    #endregion
                    #region VectoAngles
                    float[] value1 = new float[] { O2[0] - O1[0], O2[1] - O1[1], O2[2] - O1[2] };
                    float yaw, pitch;
                    float[] angles = new float[3];
                    if ((value1[1] == 0f) && (value1[0] == 0f))
                    {
                        yaw = 0f;
                        pitch = 0f;
                        if (value1[2] > 0f)
                            pitch = 90f;
                        else
                            pitch = 270f;
                    }
                    else
                    {
                        if (value1[0] != -1f)
                            yaw = (float)((Math.Atan2(value1[1], value1[0]) * 180) / Math.PI);
                        else if (value1[1] > 0f)
                            yaw = 90f;
                        else
                            yaw = 270f;
                        if (yaw < 0f)
                            yaw += 360f;
                        float forward = (float)Math.Sqrt(((value1[0] * value1[0]) + (value1[1] * value1[1])));
                        pitch = (float)((Math.Atan2(value1[2], (double)forward) * 180.0) / Math.PI);
                        if (pitch < 0f)
                            pitch += 360f;
                    }
                    angles[0] = -pitch;
                    angles[1] = yaw;
                    angles[2] = 0;
                    #endregion
                    #region SetViewAngles
                    WriteFloatArray(0x1000000, angles);
                    RPC.Call(0x1767E0, 0xFCA280 + (0x280 * Client), 0x1000000);
                    #endregion
                }
                #endregion
            }
            public static void AimbotNonTeamBased(uint Client, uint Target)
            {
                #region Check if Dead
                if (ReadInt(0xFCA41D + (Target * 0x280)) != 0)
                {
                    #region Stance
                    byte StanceByte = ReadByte(0x110d88a + (Target * 0x3980));
                    float Stance = 0;
                    if (StanceByte == 2)
                        Stance = 21;
                    else if (StanceByte == 1)
                        Stance = 47;
                    else
                        Stance = 0;
                    #endregion
                    #region Origin
                    float[] O1 = ReadFloatLength(0x110a29c + (Client * 0x3980), 3);
                    float[] O2 = ReadFloatLength(0x110a29c + (Target * 0x3980), 3);
                    O2[2] = O2[2] - Stance;
                    #endregion
                    #region VectoAngles
                    float[] value1 = new float[] { O2[0] - O1[0], O2[1] - O1[1], O2[2] - O1[2] };
                    float yaw, pitch;
                    float[] angles = new float[3];
                    if ((value1[1] == 0f) && (value1[0] == 0f))
                    {
                        yaw = 0f;
                        pitch = 0f;
                        if (value1[2] > 0f)
                            pitch = 90f;
                        else
                            pitch = 270f;
                    }
                    else
                    {
                        if (value1[0] != -1f)
                            yaw = (float)((Math.Atan2(value1[1], value1[0]) * 180) / Math.PI);
                        else if (value1[1] > 0f)
                            yaw = 90f;
                        else
                            yaw = 270f;
                        if (yaw < 0f)
                            yaw += 360f;
                        float forward = (float)Math.Sqrt(((value1[0] * value1[0]) + (value1[1] * value1[1])));
                        pitch = (float)((Math.Atan2(value1[2], (double)forward) * 180.0) / Math.PI);
                        if (pitch < 0f)
                            pitch += 360f;
                    }
                    angles[0] = -pitch;
                    angles[1] = yaw;
                    angles[2] = 0;
                    #endregion
                    #region SetViewAngles
                    WriteFloatArray(0x1000000, angles);
                    RPC.Call(0x1767E0, 0xFCA280 + (0x280 * Client), 0x1000000);
                    #endregion
                }
                #endregion
            }
            public static void ForgeMode(uint Client, uint Target, uint Distance_in_Meters = 6)
            {
                #region Get Angles and Origion
                float[] Angles = ReadFloatLength(0x110a3d8 + (Client * 0x3980), 2);
                float[] Origin = ReadFloatLength(0x110a29c + (Client * 0x3980), 3);
                #endregion
                #region AnglestoForward
                float diff = Distance_in_Meters * 40;
                float num = ((float)Math.Sin((Angles[0] * Math.PI) / 180)) * diff;
                float num1 = (float)Math.Sqrt(((diff * diff) - (num * num)));
                float num2 = ((float)Math.Sin((Angles[1] * Math.PI) / 180)) * num1;
                float num3 = ((float)Math.Cos((Angles[1] * Math.PI) / 180)) * num1;
                float[] forward = new float[] { Origin[0] + num3, Origin[1] + num2, Origin[2] - num };
                #endregion
                #region Set Target Origin
                Freeze(Target, true);
                WriteFloatArray(0x110a29c + (Target * 0x3980), forward);
                #endregion
            }
            public static float[] distances = new float[18];
            public static uint FindClosestEnemy(uint Attacker)
            {
                #region Check if Alive and Get Origin
                for (uint i = 0; i < 18; i++)
                {
                    if ((ReadInt(0xFCA41D + (i * 0x280)) > 0) && !isSameTeam(Attacker, i))
                    {

                        #region Attacker Origin
                        float[] Attacker_Origin = ReadFloatLength(0x110a29c + ((uint)Attacker * 0x3980), 3);
                        #endregion
                        #region Client Origin
                        float[] Client_Origin = ReadFloatLength(0x110a29c + (i * 0x3980), 3);
                        #endregion
                        #region Get Distance
                        distances[i] = (float)(Math.Sqrt(
                        ((Client_Origin[0] - Attacker_Origin[0]) * (Client_Origin[0] - Attacker_Origin[0])) +
                        ((Client_Origin[1] - Attacker_Origin[1]) * (Client_Origin[1] - Attacker_Origin[1])) +
                        ((Client_Origin[2] - Attacker_Origin[2]) * (Client_Origin[2] - Attacker_Origin[2]))
                        ));
                        #endregion
                    }
                    else
                    {
                        #region Dead Players get Max Value
                        distances[i] = float.MaxValue;
                        #endregion
                    }
                }
                #endregion
                #region Copy Distances
                float[] newDistances = new float[18];
                Array.Copy(distances, newDistances, distances.Length);
                #endregion
                #region Sort Distances and return Client
                Array.Sort(newDistances);
                // Array.Sort(distances);
                for (uint i = 0; i < 18; i++)
                {
                    if (distances[i] == newDistances[1])
                    //if (distances[i] == distances[1])
                    {
                        return i;
                    }
                }
                #endregion
                #region Failed
                int Failed = -1;
                return (uint)Failed;
                #endregion
            }

        }
        #endregion
    }
}

        
