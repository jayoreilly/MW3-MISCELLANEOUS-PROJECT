using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Reflection;
using System.IO;
using System.Resources;
using PS3Lib;
using System.Diagnostics;
using System.Runtime.InteropServices;



namespace Kiwi_modz
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        public Form1()
        {

            InitializeComponent();
            for (int i = 0; i < 18; i++)
            {
                dataGridView1.RowCount = 18;
                dataGridView1.Rows[i].Cells[0].Value = i;
            }
            for (int i = 0; i < 1; i++)
            {
                dataGridView2.RowCount = 1;
                dataGridView3.RowCount = 1;
                EnemysTeam.RowCount = 1;
                dataGridView2.Rows[i].Cells[0].Value = i;
                dataGridView3.Rows[i].Cells[0].Value = i;
                EnemysTeam.Rows[i].Cells[0].Value = i;
                dataGridView2.Rows[0].Cells[1].Value = "All Clients";
                dataGridView3.Rows[0].Cells[1].Value = "My Team";
                EnemysTeam.Rows[0].Cells[1].Value = "Enemy's Team";




                dataGridView2.Rows[0].Cells[0].Value = ">";
                dataGridView3.Rows[0].Cells[0].Value = ">";
                EnemysTeam.Rows[0].Cells[0].Value = ">";
                Application.DoEvents();
            }
        }

        private void Aimbot_Tick(object sender, EventArgs e)
        {
            if (Functions.Aimbot_and_ForgeMode.ReadFloat(0x110a5f8 + ((uint)numericUpDown1.Value * 0x3980)) > 0)
            {
                Functions.Aimbot_and_ForgeMode.AimbotTeamBased((uint)numericUpDown1.Value, Functions.Aimbot_and_ForgeMode.FindClosestEnemy((uint)numericUpDown1.Value));
                Functions.AutoShoot((int)numericUpDown1.Value);
            }
        }

        private void AdvancedNoClip_Tick(object sender, EventArgs e)
        {
            Functions.AdvancedNoClip((int)numericUpDown2.Value);

            if (Functions.Aimbot_and_ForgeMode.ReadInt(0xFCA41D + ((uint)numericUpDown2.Value * 0x280)) == 0)
            {
                System.Threading.Thread.Sleep(1500);
                Functions.allPerks((int)numericUpDown2.Value);
                Functions.iPrintln((int)numericUpDown2.Value, "^1Advanced NoClip By ^:Kiwi_modz");
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            numericUpDown1.Value = dataGridView1.CurrentRow.Index; MainStrip.Show();
            numericUpDown2.Value = dataGridView1.CurrentRow.Index; MainStrip.Show();
            FXC.Value = dataGridView1.CurrentRow.Index;
            ST.Value = dataGridView1.CurrentRow.Index;
            PTC.Value = dataGridView1.CurrentRow.Index;
        }
        private static float[] GetOrigin(uint client)
        {
            float[] Origin;
            Origin = PS3.ReadSingle(0x0110A29C + 0x3980 * client, 3);
            return Origin;
        }
        private static float[] GetAngles(uint client)
        {
            float[] Origin;
            Origin = PS3.ReadSingle(0x0110A29C + 0x9 + 0x3980 * client, 3);
            return Origin;
        }
        private void Forge_Mode_Tick(object sender, EventArgs e)
        {

            if (Functions.Aimbot_and_ForgeMode.ReadFloat(0x110a5f8 + ((uint)ST.Value * 0x3980)) > 0)
            {

            }
            else
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    dataGridView1.Focus();

                }
            }
            catch
            {
                //nothing
            }
        }

        private void oNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.godMode(client);
                Functions.iPrintln(client, "^5God Mode Is ^2Enabled ^:" + Functions.GetName(client));
                MainStrip.Show();


            }
        }

        private void oFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.godMode1(client);
                Functions.iPrintln(client, "^5God Mode Is ^1Disabled ^:" + Functions.GetName(client));
                MainStrip.Show();
            }
        }

        private void Fx_Tick(object sender, EventArgs e)
        {
            if (Functions.Aimbot_and_ForgeMode.ReadFloat(0x110a5f8 + ((uint)FXC.Value * 0x3980)) > 0)
            {
                Functions.SetFX((uint)FXC.Value, (Int32)num.Value, (uint)num.Value);
            }
        }

        private void yesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.PS3Freeze((Int32)client);
                MainStrip.Show();
            }
        }

        private void onToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.FreezePlayer((Int32)client, true);
                MainStrip.Show();
            }
        }

        private void offToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.FreezePlayer((Int32)client, false);
                MainStrip.Show();
            }
        }

        private void aC130ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.GiveWeapon(client, Offsets.Weapons.killstreak_predator_missile_mp);
                //Functions.Clients.Special((Int32)client, Functions.Clients.Killstreaks.AC130);
            }
        }

        private void oNToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.InfAmmo(client, true);
            }
        }

        private void oFFToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.InfAmmo(client, false);
            }
        }

        private void oNToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.MW2Wallhack(client, true);
            }
        }

        private void oFFToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.MW2Wallhack(client, false);
            }
        }

        private void oNToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.RedBox(client, true);
            }
        }

        private void oFFToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.RedBox(client, false);
            }
        }

        private void yesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.Suicide(client);
                //Functions.G_Damage(Functions.GetHostNumber(), (Int32)client);
            }
        }

        private void oNToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.Ufo(client, true);
            }
        }

        private void oFFToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.Ufo(client, false);
            }
        }

        private void nothingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Nothing);
            }
        }

        private void deltaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Delta);
            }
        }

        private void snowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Snow);
            }
        }

        private void multicamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Multicam);
            }
        }

        private void digitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Digital);
            }
        }

        private void hexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Hex);
            }
        }

        private void chocoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Choco);
            }
        }

        private void snakeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Snake);
            }
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Blue);
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Red);
            }
        }

        private void autumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Autumn);
            }
        }

        private void goldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Gold);
            }
        }

        private void winterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Marine);
            }
        }

        private void marineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Weapons.ChangeCamo(client, Functions.Weapons.Camos.Winter);
            }
        }
        private void giveAllPerksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.allPerks(client);

            }
        }

        private void sendClientMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index;
            {
                string a = "";
                if (InputBox("Send " + Functions.GetName(client) + "A Message", "Enter Your Message:", ref a) == DialogResult.OK)
                {
                    Functions.iPrintln(client, a);
                    MainStrip.Show();
                }
                else
                {
                    //nothing
                    MainStrip.Show();
                }
            }
        }
        #region InputBox
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "✔";
            buttonCancel.Text = "✖";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        #endregion
        private void changeClientsNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int client = dataGridView1.CurrentRow.Index;
            {
                string a = Functions.GetName(client); ;
                if (InputBox("Change Clients Name", "Enter Clients New Name:", ref a) == DialogResult.OK)
                {
                    byte[] NewName = Encoding.ASCII.GetBytes(a + "\0");
                    PS3.SetMemory(0x0110D694 + (0x3980 * (uint)client), NewName);
                    Functions.iPrintln(client, "Your Name Is Now: " + a);
                    MainStrip.Show();
                }
                else
                {
                    //nothing
                    MainStrip.Show();
                }
            }

        }
        private void oNToolStripMenuItem5_Click(object sender, EventArgs e)
        {

            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Invert(client, 7);
            }
        }

        private void takeGunsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.TakeWeapon(client);
            }
        }

        private void turtleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.Turtle(client);
            }
        }

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.Speedx2(client);
            }
        }

        private void x8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.Speedx4(client);
            }
        }
        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.Default(client);
            }
        }

        private void onToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.Akimboon(client);
            }
        }

        private void oFFToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.Akimbooff(client);
            }
        }
        private void oNToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.LagPlayer((Int32)client, true);

            }
        }

        private void oFFToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.LagPlayer((Int32)client, false);

            }
        }

        private void giveClientDrugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.DrugsMode((Int32)client);

            }
        }
        private void leftGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.KickPlayer((uint)client, "Has left the game");

            }
        }

        private void oNToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.CBUF_ADDTEXT("bg_bulletExplRadius 1000");
                Functions.CBUF_ADDTEXT("bg_bulletExplDmgFactor 100");
                Functions.Clients.ExplosiveBullets((Int32)client, true);
            }
        }

        private void oFFToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.ExplosiveBullets((Int32)client, false);
            }
        }

        private void kickedForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.KickPlayer((uint)client, "EXE_PLAYERKICKED for inactivity");

            }
        }

        private void timedOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.KickPlayer((uint)client, "Server connection timed out");

            }
        }

        private void kickedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.KickPlayer((uint)client, "EXE_PLAYERKICKED");

            }
        }

        private void yourOwnReasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                string a = "EXE_PLAYERKICKED ";
                if (InputBox("Kick" + Functions.GetName(client) + "?", "Enter Kick Message Below:", ref a) == DialogResult.OK)
                {
                    Functions.KickPlayer((uint)client, a);
                }
                else
                {
                    //nothing
                }
            }
        }

        private void switchTeamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.toggleTeam((Int32)client);

            }
        }
        private void teleportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.Teleport.TeleportAllTo((uint)client);

            }
        }

        private void haxorBS16thFakeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.ClientPrestige((int)client, 21);
                Functions.Clients.Maxrank((int)client);
            }
        }

        private void setClientsPrestigeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.ClientPrestige((int)client, 0);
                Functions.Clients.Derank((int)client);
            }
        }

        private void setClientsLevelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int client = dataGridView1.CurrentRow.Index; MainStrip.Show();
            {
                Functions.Clients.ClientPrestige((int)client, 20);
                Functions.Clients.Maxrank((int)client);
            }
        }

       
      
        private void Painter_Tick(object sender, EventArgs e)
        {
            if (PS3.ReadFloat(0x110a5f8 + ((uint)FXC.Value * 0x3980)) > 0)
            {
                Functions.SetFX((uint)PTC.Value, (Int32)Colorr.Value, (uint)Dist.Value);
            }
        }

        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataGridView2.Rows[e.RowIndex].Selected = true;
                    dataGridView2.Focus();

                }
            }
            catch
            {
                //nothing
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //All Clients
            for (int i = 0; i < 18; i++)
            {
                Functions.godMode(i);
                Functions.iPrintln(i, "^5God Mode Is ^2Enabled ^:" + Functions.GetName(i));
            }

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //All Clients
            for (int i = 0; i < 18; i++)
            {
                Functions.godMode1(i);
                Functions.iPrintln(i, "^5God Mode Is ^1Disabled ^:" + Functions.GetName(i));
            }
        }



        private void Crate_Tick(object sender, EventArgs e)
        {
            if (PS3.ReadFloat(0x110a5f8 + ((uint)FXC.Value * 0x3980)) > 0)
            {
                float[] Origin = Functions.GetOrigin((uint)numericUpDown12.Value);
                float[] Angles = Functions.GetAngles((uint)numericUpDown12.Value);
                Origin[2] += 30;
                Functions.SolidModel(Functions.AnglesToForward(Origin, new float[] { 0, 0, 0 }, 80), new float[] { 0, Angles[1] + 90, 0 }, comboBox4.Text, 2);
            }
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            //0x318c9ab1
            byte[] Buffer = Encoding.ASCII.GetBytes(textBox1.Text);
            Array.Resize(ref Buffer, Buffer.Length + 1);
            PS3.SetMemory(0x318c9ab1, Buffer);

            byte[] Buffer1 = Encoding.ASCII.GetBytes(textBox5.Text);
            Array.Resize(ref Buffer1, Buffer1.Length + 1);
            PS3.SetMemory(0x318c838b, Buffer1);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            Functions.SV_GameSendServerCommand(-1, "d 1134 " + comboBox2.Text);

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Functions.SV_GameSendServerCommand(-1, "d 1657 " + comboBox3.Text);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Functions.SV_GameSendServerCommand(-1, "d 8 " + R.Value + " " + G.Value + " " + B.Value);
        }

        private void R_ValueChanged(object sender, EventArgs e)
        {
            Functions.SV_GameSendServerCommand(-1, "d 8 " + R.Value + " " + G.Value + " " + B.Value);
        }

        private void B_ValueChanged(object sender, EventArgs e)
        {
            Functions.SV_GameSendServerCommand(-1, "d 8 " + R.Value + " " + G.Value + " " + B.Value);
        }

        private void G_ValueChanged(object sender, EventArgs e)
        {
            Functions.SV_GameSendServerCommand(-1, "d 8 " + R.Value + " " + G.Value + " " + B.Value);
        }

        public static void PlaySound(int Client, Int32 SoundID)
        {
            Functions.SV_GameSendServerCommand(Client, "n " + SoundID);
        }
        private void metroButton5_Click(object sender, EventArgs e)
        {
            PlaySound(-1, (Int32)numericUpDown6.Value);
            //{
            //    Functions.SV_GameSendServerCommand(-1, "d " + numericUpDown6.Value + " vehicle_forklift");
            //    numericUpDown6.Value += 1;

            //}
            //Thread.Sleep(100);
            //Functions.SomeShit();
            //textBox1.Text = RPC.Call(0x22A4A8, 1018, "", 900).ToString();//22120
            //PS3.WriteUInt32(0x0110d644 + (i * 0x3980), 101);// cool gloves
        }

        private void button22_Click(object sender, EventArgs e)
        {
            for (uint i = 19; i < 1300; i++)
            {
                PS3.WriteByte(0xFCA28F + (i * 0x280), 0);
                PS3.WriteByte(0xFCA28F + (i * 0x280), 0x6);
            }
        }

        public static void GiveWeapon(uint Client, int WeaponID)
        {
            PS3.WriteInt32(0x0110a4fc + (Client * 0x3980), WeaponID);
            PS3.WriteInt32(0x0110a624 + (Client * 0x3980), WeaponID);
            PS3.WriteInt32(0x0110a6a4 + (Client * 0x3980), WeaponID);
            PS3.WriteInt32(0x0110a5f0 + (Client * 0x3980), WeaponID);
            RPC.Call(0x18A29C, 0xFCA280 + (Client * 0x280), WeaponID, "", 9999, 9999);
        }

        private void metroButton6_Click(object sender, EventArgs e)
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
            for (uint i = 0; i < 18; i++)
            {
                if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                {
                    GiveWeapon(i, 4 + Value);
                }
            }

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            Functions.SV_GameSendServerCommand(-1, textBox2.Text);
            //for (uint i = 50; i < 2000; i++)
            //{
            //    Functions.SV_GameSendServerCommand(-1, "d " + i + " vehicle_forklift");

            //}
            //Thread.Sleep(100);
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            if (mb8.Text == "DrawModels [ OFF ]")
            {
                Crate.Start();
                mb8.Text = "DrawModels [ ON ]";
            }
            else if (mb8.Text == "DrawModels [ ON ]")
            {
                Crate.Stop();
                mb8.Text = "DrawModels [ OFF ]";
            }
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            Functions.SpawnWall((uint)Functions.GetHostNumber(), 5, 5);
        }

        private void metroButton8_Click_1(object sender, EventArgs e)
        {
            Functions.CBUF_ADDTEXT("g_knockback " + textBox3.Text);
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            Functions.CBUF_ADDTEXT("reset g_knockback");
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            Functions.SV_GameSendServerCommand(-1, "q cg_deadChatWithDead 1" + " cg_deadChatWithTeam 1" + " cg_deadHearTeamLiving 1" + " cg_deadHearAllLiving 1" + " cg_everyonehearseveryone 1");
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            Functions.CBUF_ADDTEXT(textBox4.Text);
        }
        public static bool DiscoState = false;
        public static Thread DiscoThread;
        private void metroButton13_Click(object sender, EventArgs e)
        {
            if (SunLoop.Text == "Sun loop [ OFF ]")
            {
                ThreadStart Start = null;
                Thread.Sleep(100);
                if (Start == null)
                {
                    Start = () => Disco();
                }
                DiscoThread = new Thread(Start);
                DiscoThread.IsBackground = true;
                DiscoThread.Start();
                SunLoop.Text = "Sun loop [ ON ]";
            }
            else if (SunLoop.Text == "Sun loop [ ON ]")
            {
                DiscoThread.Abort();
                Functions.SetSunLight(-1, 1.0, 1.0, 1.0);
                SunLoop.Text = "Sun loop [ OFF ]";
            }
        }
        public static void Disco()
        {
            PS3.Connect();
            while (DiscoThread.IsAlive)
            {
                for (double Colour = 1; Colour < 14; Colour++)
                {
                    if (Colour > 2)//Red
                    {
                        if (Colour > 4)//Yellow
                        {
                            if (Colour > 6)//Grenn
                            {
                                if (Colour > 8)//Cyan
                                {
                                    if (Colour > 10)//Blue
                                    {
                                        if (Colour == 13)//Violett
                                        {
                                            Functions.iPrintln(-1, "^1F^2U^4C^1K^2I^4N^1G ^2P^4A^1R^2T^4Y ^1H^2A^4R^1D ^6<3");
                                        }
                                        else
                                            Functions.SetSunLight(-1, Colour - 10, 0, Colour - 10);
                                    }
                                    else
                                        Functions.SetSunLight(-1, 0, 0, Colour - 8);
                                }
                                else
                                    Functions.SetSunLight(-1, 0, Colour - 6, Colour - 6);
                            }
                            else
                                Functions.SetSunLight(-1, 0, Colour - 4, 0);
                        }
                        else
                            Functions.SetSunLight(-1, Colour - 2, Colour - 2, 0);
                    }
                    else
                        Functions.SetSunLight(-1, Colour, 0, 0);
                    Thread.Sleep(200);
                }
            }
        }

        private void metroButton13_Click_1(object sender, EventArgs e)
        {
            Functions.CBUF_ADDTEXT("gameInvitesReceived");
        }

        private void metroButton14_Click(object sender, EventArgs e)
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
            for (uint i = 0; i < 18; i++)
            {
                if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                {
                    GiveWeapon(i, 42 + Value);
                }
            }
        }


        private void oFFToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NOPE");
            AllClients.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            //All Clients
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.FreezePlayer((Int32)i, true);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            //All Clients
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.FreezePlayer((Int32)i, false);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.PS3Freeze(i);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.InfAmmo(i, true);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.InfAmmo(i, false);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.MW2Wallhack(i, true);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.MW2Wallhack(i, false);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.RedBox(i, false);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.RedBox(i, true);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.Suicide(i);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.Ufo(i, true);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.Ufo(i, false);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem49_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.allPerks(i);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem50_Click(object sender, EventArgs e)
        {
            string a = "";
            if (InputBox("Send All Clients A Message", "Enter Your Message:", ref a) == DialogResult.OK)
            {
                for (int i = 0; i < 18; i++)
                {
                    Functions.iPrintln(i, a);
                    AllClients.Show();
                }
            }
            else
            {
                AllClients.Show();
            }
        }

        private void toolStripMenuItem54_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.CBUF_ADDTEXT("bg_bulletExplRadius 1000");
                Functions.CBUF_ADDTEXT("bg_bulletExplDmgFactor 100");
                Functions.Clients.ExplosiveBullets((Int32)i, true);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem55_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.ExplosiveBullets((Int32)i, false);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem56_Click(object sender, EventArgs e)
        {
            string a = "";
            if (InputBox("Change Clients Name", "Enter Clients New Name:", ref a) == DialogResult.OK)
            {
                for (int i = 0; i < 18; i++)
                {
                    byte[] NewName = Encoding.ASCII.GetBytes(a + "\0");
                    PS3.SetMemory(0x0110D694 + (0x3980 * (uint)i), NewName);
                    Functions.iPrintln(i, "Your Name Is Now: " + a);
                }
                AllClients.Show();
            }
            else
            {
                //nothing
                AllClients.Show();
            }
        }


        private void toolStripMenuItem58_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.LagPlayer(i, true);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem59_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.LagPlayer(i, false);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem61_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.ClientPrestige((int)i, 0);
                Functions.Clients.Derank((int)i);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem62_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.ClientPrestige((int)i, 20);
                Functions.Clients.Maxrank((int)i);
                AllClients.Show();
            }
        }

        private void toolStripMenuItem63_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.ClientPrestige((int)i, 21);
                Functions.Clients.Maxrank((int)i);
                AllClients.Show();
            }
        }

        private void teleportAllToHostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.Teleport.TeleportAllTo((uint)i);
                AllClients.Show();
            }
        }

        private void takeAllClientsWeaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Clients.TakeWeapon(i);
                AllClients.Show();
            }
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            Functions.Kickgod("kicked ^5For Being a ^1GodMode ^5using Fuckwit^7\nBy " + Functions.GetName(Functions.GetHostNumber()));
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            Functions.restartGame();
        }

        private void metroButton17_Click(object sender, EventArgs e)
        {
            Functions.NoRecoil();
        }

        private void metroButton18_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 0;
            for (int i = 0; i < 18; i++)
            {
                System.Threading.Thread.Sleep(10);
                dataGridView1.Enabled = true;
                dataGridView1.RowCount = 18;
                dataGridView1.Rows[i].Cells[0].Value = i;
                dataGridView1.Rows[i].Cells[1].Value = Functions.GetName(i);
                Application.DoEvents();
            }

            try
            {
                dataGridView1.Rows[Functions.GetHostNumber()].Cells[0].Style.SelectionBackColor = MetroFramework.MetroColors.Orange;
                dataGridView1.Rows[Functions.GetHostNumber()].Cells[0].Style.BackColor = MetroFramework.MetroColors.Orange;
                dataGridView1.Rows[Functions.GetHostNumber()].Cells[0].Style.ForeColor = Color.White;
                dataGridView1.Rows[Functions.GetHostNumber()].Cells[1].Style.SelectionBackColor = MetroFramework.MetroColors.Orange;
                dataGridView1.Rows[Functions.GetHostNumber()].Cells[1].Style.BackColor = MetroFramework.MetroColors.Orange;
                dataGridView1.Rows[Functions.GetHostNumber()].Cells[1].Style.ForeColor = Color.White;
            }
            catch
            {

            }

            try
            {
                HOST.Text = Functions.ServerInfo.getHostName();
                MAP.Text = Functions.ServerInfo.getMapName();
                MODE.Text = Functions.ServerInfo.getGameMode();

                
                
            }
            catch
            {
                HOST.Text = "Null";
                MAP.Text = "Null";
                MODE.Text = "Null";
                dataGridView1.RowCount = 0;
            }
        }

        private void metroButton19_Click(object sender, EventArgs e)
        {
            byte[] Buffer = Encoding.ASCII.GetBytes(textBox6.Text);
            Array.Resize(ref Buffer, Buffer.Length + 1);
            PS3.SetMemory(0X01bbbc2c, Buffer);
        }

        private void metroButton20_Click(object sender, EventArgs e)
        {
            PS3.WriteByte(0x5F067, 0x02);
        }

        private void metroButton21_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x65D14, new byte[] { 0x60, 0x0, 0x0, 0x1 });
        }

        private void metroButton22_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.Invert(i, 7);
            }
        }

        private void metroButton23_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3984df, new byte[] { 0x01 });
        }

        private void metroButton24_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3984df, new byte[] { 0x00 });
        }

        private void metroButton25_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                Functions.iPrintln((Int32)i, metroTextBox1.Text);
            }
        }

        private void metroButton26_Click(object sender, EventArgs e)
        {
            float[] Origin = GetOrigin((uint)Functions.GetHostNumber());
            Functions.MysteryBox.Spawn(Origin, Functions.GetHostNumber());
        }

        private void metroButton27_Click(object sender, EventArgs e)
        {
            Functions.MysteryBox.DeleteMB();
        }
        private void metroButton28_Click(object sender, EventArgs e)
        {
            Functions.Clients.Teleport.teleportTeam();
        }

        private void metroButton29_Click(object sender, EventArgs e)
        {
            try
            {
                PS3.Connect();
                System.Threading.Thread.Sleep(300);
                if (PS3.Attach()) label25.Text = "Process Attached.";
                System.Threading.Thread.Sleep(300);
                RPC.Enable();

            }
            catch
            {

            }
        }

        private void metroButton30_Click(object sender, EventArgs e)
        {
            if (metroButton30.Text == "Start Painting [ OFF ]")
            {
                Painter.Start();
                metroButton30.Text = "Start Painting [ ON ]";
                Functions.MysteryBox.StoreText(500 + ((uint)PTC.Value), (PTC.Value), "Press [{+speed_throw}] To Start Drawing", 7, 0.8f, 195, 300, 255, 255, 255, 255, 0, 0, 0, 0);
            }
            else if (metroButton30.Text == "Start Painting [ ON ]")
            {
                Painter.Stop();
                metroButton30.Text = "Start Painting [ OFF ]";
                for (uint i = 0; i < 18; i++)
                {
                    PS3.SetMemory(Functions.MysteryBox.Element(500 + (uint)i), new byte[0xB4]);
                }
            }
        }

        private void refreshr_Tick(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 0;
            for (int i = 0; i < 18; i++)
            {
                System.Threading.Thread.Sleep(10);
                dataGridView1.Enabled = true;
                dataGridView1.RowCount = 18;
                dataGridView1.Rows[i].Cells[0].Value = i;
                dataGridView1.Rows[i].Cells[1].Value = Functions.GetName(i);
                Application.DoEvents();
            }

            try
            {
                dataGridView1.Rows[Functions.GetHostNumber()].Cells[0].Style.SelectionBackColor = MetroFramework.MetroColors.Orange;
                dataGridView1.Rows[Functions.GetHostNumber()].Cells[0].Style.BackColor = MetroFramework.MetroColors.Orange;
                dataGridView1.Rows[Functions.GetHostNumber()].Cells[0].Style.ForeColor = Color.White;
                dataGridView1.Rows[Functions.GetHostNumber()].Cells[1].Style.SelectionBackColor = MetroFramework.MetroColors.Orange;
                dataGridView1.Rows[Functions.GetHostNumber()].Cells[1].Style.BackColor = MetroFramework.MetroColors.Orange;
                dataGridView1.Rows[Functions.GetHostNumber()].Cells[1].Style.ForeColor = Color.White;
            }
            catch
            {

            }

            try
            {
                HOST.Text = Functions.ServerInfo.getHostName();
                MAP.Text = Functions.ServerInfo.getMapName();
                MODE.Text = Functions.ServerInfo.getGameMode();
            }
            catch
            {
                HOST.Text = "Null";
                MAP.Text = "Null";
                MODE.Text = "Null";
                dataGridView1.RowCount = 0;
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                refreshr.Start();
            }

            else
            {
                refreshr.Stop();
            }
        }

        private void Box_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if ((Box.Text == "Green") && (MAP.Text == "Dome"))
            {
                Colorr.Value = 92;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Dome"))
            {
                Colorr.Value = 66;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Seatown"))
            {
                Colorr.Value = 90;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Seatown"))
            {
                Colorr.Value = 64;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Arkaden"))
            {
                Colorr.Value = 98;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Arkaden"))
            {
                Colorr.Value = 72;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Bakaara"))
            {
                Colorr.Value = 88;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Bakaara"))
            {
                Colorr.Value = 62;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Resistance"))
            {
                Colorr.Value = 84;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Resistance"))
            {
                Colorr.Value = 58;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Downturn"))
            {
                Colorr.Value = 95;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Downturn"))
            {
                Colorr.Value = 69;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Bootleg"))
            {
                Colorr.Value = 105;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Bootleg"))
            {
                Colorr.Value = 79;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Bootleg"))
            {
                Colorr.Value = 105;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Bootleg"))
            {
                Colorr.Value = 79;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Carbon"))
            {
                Colorr.Value = 132;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Carbon"))
            {
                Colorr.Value = 106;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Hardhat"))
            {
                Colorr.Value = 100;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Hardhat"))
            {
                Colorr.Value = 74;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Lockdown"))
            {
                Colorr.Value = 86;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Lockdown"))
            {
                Colorr.Value = 60;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Village"))
            {
                Colorr.Value = 85;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Village"))
            {
                Colorr.Value = 59;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Fallen"))
            {
                Colorr.Value = 102;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Fallen"))
            {
                Colorr.Value = 76;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Outpost"))
            {
                Colorr.Value = 118;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Outpost"))
            {
                Colorr.Value = 92;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Interchange"))
            {
                Colorr.Value = 83;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Interchange"))
            {
                Colorr.Value = 57;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Underground"))
            {
                Colorr.Value = 109;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Underground"))
            {
                Colorr.Value = 83;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Mission"))
            {
                Colorr.Value = 87;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Mission"))
            {
                Colorr.Value = 61;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Terminal"))
            {
                Colorr.Value = 92;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Terminal"))
            {
                Colorr.Value = 66;
            }
        }

        private void metroButton37_Click(object sender, EventArgs e)
        {
            if (metroButton37.Text == "TeamBased Aimbot [ OFF ]")
            {
                Functions.NoRecoil();
                Functions.InfAmmo((int)numericUpDown1.Value);
                //Functions.redBoxes((int)numericUpDown1.Value);
                Functions.allPerks((int)numericUpDown1.Value);
                Aimbot.Start();
                metroButton37.Text = "TeamBased Aimbot [ ON ]";
            }
            else if (metroButton37.Text == "TeamBased Aimbot [ ON ]")
            {

                metroButton37.Text = "TeamBased Aimbot [ OFF ]";
                Aimbot.Stop();
            }
        }

        private void metroButton36_Click(object sender, EventArgs e)
        {
            if (metroButton36.Text == "PlayFX [ OFF ]")
            {
                Fx.Start();
                metroButton36.Text = "PlayFX [ ON ]";
            }
            else if (metroButton36.Text == "PlayFX [ ON ]")
            {
                Fx.Stop();
                metroButton36.Text = "PlayFX [ OFF ]";
            }
        }

        private void metroButton34_Click(object sender, EventArgs e)
        {
            if (metroButton34.Text == "Advanced No-Clip [ OFF ]")
            {

                Functions.allPerks((int)numericUpDown2.Value);
                Advanced_NoClip.Start();
                metroButton34.Text = "Advanced No-Clip [ ON ]";
                Functions.iPrintln((int)numericUpDown2.Value, "^1Advanced NoClip By ^:Kiwi_modz ^2ON");
                System.Threading.Thread.Sleep(1500);
                Functions.iPrintln((int)numericUpDown2.Value, "^1 Press And Hold [{+gostand}] To Go Up");
                System.Threading.Thread.Sleep(1500);
                Functions.iPrintln((int)numericUpDown2.Value, "^1 Press And Hold [{+melee}] To Go Down");
            }
            else if (metroButton34.Text == "Advanced No-Clip [ ON ]")
            {
                Advanced_NoClip.Stop();
                metroButton34.Text = "Advanced No-Clip [ OFF ]";
                Functions.iPrintln((int)numericUpDown2.Value, "^1Advanced NoClip By ^:Kiwi_modz ^1OFF");
                System.Threading.Thread.Sleep(1500);
            }


        }

        private void metroButton33_Click(object sender, EventArgs e)
        {
            Functions.iPrintln((Int32)numericUpDown3.Value, "^:Turret Spawned On your Position. ^1KILL KILL KILL");
            Functions.Spawn_Turrent.OnAnglesToForward((uint)numericUpDown3.Value);
            System.Threading.Thread.Sleep(3000);
        }

        private void metroButton32_Click(object sender, EventArgs e)
        {
            Functions.StairsToHeaven((uint)numericUpDown4.Value, (uint)numericUpDown9.Value);

        }

        private void metroButton31_Click(object sender, EventArgs e)
        {
            Functions.RemoveAll();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

            PlaySound(-1, (Int32)numericUpDown6.Value);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Functions.SV_GameSendServerCommand(-1, "d 1657 " + comboBox3.Text);
        }

        private void metroButton38_Click(object sender, EventArgs e)
        {
        }

       

        private void metroButton41_Click(object sender, EventArgs e)
        {
            for (int i = 1060; i < 1090; i++)
            {
                Functions.SV_GameSendServerCommand(-1, "d " + i + " " + MEE.Text);
            }
        }

       
        private void metroButton43_Click(object sender, EventArgs e)
        {
            Functions.SpawnO((uint)Functions.GetHostNumber(), 5, 25);
        }

        private void MEE_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 1060; i < 1090; i++)
            {
                Functions.SV_GameSendServerCommand(-1, "d " + i + " " + MEE.Text);
            }
        }

        private void metroButton41_Click_1(object sender, EventArgs e)
        {
            Functions.Kickgod("EXE_PLAYERKICKED");
        }

        private void metroButton45_Click(object sender, EventArgs e)
        {
            Functions.SV_GameSendServerCommand(-1, "q g_scriptmainmenu \" \"");
        }

        private void metroButton44_Click(object sender, EventArgs e)
        {
            Functions.SV_GameSendServerCommand(-1, "q g_scriptmainmenu \"class\"");
        }

        private void aCRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStrip.Show();
            int Value = 0;
            byte[] buffer = new byte[100];
            PS3.GetMemory(0x8360d5, ref buffer);
            System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
            string Map = Encoding.GetString(buffer).Split(Convert.ToChar(0x5c))[6];
            if (Map == "mp_seatown" | Map == "mp_plaza2" | Map == "mp_exchange" | Map == "mp_bootleg" | Map == "mp_alpha" | Map == "mp_village" | Map == "mp_bravo" | Map == "mp_courtyard_ss" | Map == "mp_aground_ss")
                Value = -1;
            else
                Value = 0;

            if (PS3.ReadInt(0xFCA41D + ((uint)dataGridView1.CurrentRow.Index * 0x280)) > 0) // Cheacks If Client Is Alive
            {
                GiveWeapon((uint)dataGridView1.CurrentRow.Index, 28 + Value);//acr
                Functions.InfAmmo(dataGridView1.CurrentRow.Index);
            }

        }

        private void p90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStrip.Show();
            int Value = 0;
            byte[] buffer = new byte[100];
            PS3.GetMemory(0x8360d5, ref buffer);
            System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
            string Map = Encoding.GetString(buffer).Split(Convert.ToChar(0x5c))[6];
            if (Map == "mp_seatown" | Map == "mp_plaza2" | Map == "mp_exchange" | Map == "mp_bootleg" | Map == "mp_alpha" | Map == "mp_village" | Map == "mp_bravo" | Map == "mp_courtyard_ss" | Map == "mp_aground_ss")
                Value = -1;
            else
                Value = 0;

            if (PS3.ReadInt(0xFCA41D + ((uint)dataGridView1.CurrentRow.Index * 0x280)) > 0) // Cheacks If Client Is Alive
            {
                GiveWeapon((uint)dataGridView1.CurrentRow.Index, 20 + Value);//p90
                Functions.InfAmmo(dataGridView1.CurrentRow.Index);
            }

        }

        private void m4A1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStrip.Show();
            int Value = 0;
            byte[] buffer = new byte[100];
            PS3.GetMemory(0x8360d5, ref buffer);
            System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
            string Map = Encoding.GetString(buffer).Split(Convert.ToChar(0x5c))[6];
            if (Map == "mp_seatown" | Map == "mp_plaza2" | Map == "mp_exchange" | Map == "mp_bootleg" | Map == "mp_alpha" | Map == "mp_village" | Map == "mp_bravo" | Map == "mp_courtyard_ss" | Map == "mp_aground_ss")
                Value = -1;
            else
                Value = 0;

            if (PS3.ReadInt(0xFCA41D + ((uint)dataGridView1.CurrentRow.Index * 0x280)) > 0) // Cheacks If Client Is Alive
            {
                GiveWeapon((uint)dataGridView1.CurrentRow.Index, 26 + Value);//m4a1
                Functions.InfAmmo(dataGridView1.CurrentRow.Index);
            }
        }

        private void mSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStrip.Show();
            int Value = 0;
            byte[] buffer = new byte[100];
            PS3.GetMemory(0x8360d5, ref buffer);
            System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
            string Map = Encoding.GetString(buffer).Split(Convert.ToChar(0x5c))[6];
            if (Map == "mp_seatown" | Map == "mp_plaza2" | Map == "mp_exchange" | Map == "mp_bootleg" | Map == "mp_alpha" | Map == "mp_village" | Map == "mp_bravo" | Map == "mp_courtyard_ss" | Map == "mp_aground_ss")
                Value = -1;
            else
                Value = 0;

            if (PS3.ReadInt(0xFCA41D + ((uint)dataGridView1.CurrentRow.Index * 0x280)) > 0) // Cheacks If Client Is Alive
            {
                GiveWeapon((uint)dataGridView1.CurrentRow.Index, 42 + Value);//msr
                Functions.InfAmmo(dataGridView1.CurrentRow.Index);
            }
        }

        private void aA12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStrip.Show();
            int Value = 0;
            byte[] buffer = new byte[100];
            PS3.GetMemory(0x8360d5, ref buffer);
            System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
            string Map = Encoding.GetString(buffer).Split(Convert.ToChar(0x5c))[6];
            if (Map == "mp_seatown" | Map == "mp_plaza2" | Map == "mp_exchange" | Map == "mp_bootleg" | Map == "mp_alpha" | Map == "mp_village" | Map == "mp_bravo" | Map == "mp_courtyard_ss" | Map == "mp_aground_ss")
                Value = -1;
            else
                Value = 0;

            if (PS3.ReadInt(0xFCA41D + ((uint)dataGridView1.CurrentRow.Index * 0x280)) > 0) // Cheacks If Client Is Alive
            {
                GiveWeapon((uint)dataGridView1.CurrentRow.Index, 50 + Value);//aa12
                Functions.InfAmmo(dataGridView1.CurrentRow.Index);
            }
        }

        private void jAVELINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStrip.Show();
            int Value = 0;
            byte[] buffer = new byte[100];
            PS3.GetMemory(0x8360d5, ref buffer);
            System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
            string Map = Encoding.GetString(buffer).Split(Convert.ToChar(0x5c))[6];
            if (Map == "mp_seatown" | Map == "mp_plaza2" | Map == "mp_exchange" | Map == "mp_bootleg" | Map == "mp_alpha" | Map == "mp_village" | Map == "mp_bravo" | Map == "mp_courtyard_ss" | Map == "mp_aground_ss")
                Value = -1;
            else
                Value = 0;

            if (PS3.ReadInt(0xFCA41D + ((uint)dataGridView1.CurrentRow.Index * 0x280)) > 0) // Cheacks If Client Is Alive
            {
                GiveWeapon((uint)dataGridView1.CurrentRow.Index, 24 + Value);//ak47
                Functions.InfAmmo(dataGridView1.CurrentRow.Index);
            }
        }

        private void rPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStrip.Show();
            int Value = 0;
            byte[] buffer = new byte[100];
            PS3.GetMemory(0x8360d5, ref buffer);
            System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
            string Map = Encoding.GetString(buffer).Split(Convert.ToChar(0x5c))[6];
            if (Map == "mp_seatown" | Map == "mp_plaza2" | Map == "mp_exchange" | Map == "mp_bootleg" | Map == "mp_alpha" | Map == "mp_village" | Map == "mp_bravo" | Map == "mp_courtyard_ss" | Map == "mp_aground_ss")
                Value = -1;
            else
                Value = 0;

            if (PS3.ReadInt(0xFCA41D + ((uint)dataGridView1.CurrentRow.Index * 0x280)) > 0) // Cheacks If Client Is Alive
            {
                GiveWeapon((uint)dataGridView1.CurrentRow.Index, 36 + Value);//rpg
                Functions.InfAmmo(dataGridView1.CurrentRow.Index);
            }
        }

        private void toolStripMenuItem67_Click(object sender, EventArgs e)
        {
            Functions.Clients.Teleport.teleportTeam();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.godMode(i);
                    Functions.iPrintln(i, "^5God Mode Is ^2Enabled For Your Team ^:" + Functions.GetName(i));
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.godMode1(i);
                    Functions.iPrintln(i, "^5God Mode Is ^1Disabled For Your Team ^:" + Functions.GetName(i));
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.InfAmmo(i, true);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.InfAmmo(i, false);
                }
                else
                {
                    
                }
            }
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.CBUF_ADDTEXT("bg_bulletExplRadius 1000");
                    Functions.CBUF_ADDTEXT("bg_bulletExplDmgFactor 100");
                    Functions.Clients.ExplosiveBullets(i, true);
                }
                else
                {
                    
                }
            }
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.ExplosiveBullets(i, false);
                }
                else
                {
                  
                }
            }
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    string a = "";
                    if (InputBox("Send A Message To Your Team", "Enter Your Message:", ref a) == DialogResult.OK)
                    {
                        Functions.iPrintln(i, a);
                        MainStrip.Show();
                    }
                    else
                    {

                    }
                }
                else
                {
                    
                }
            }
        }

        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.Akimboon(i);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.Akimbooff(i);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.RedBox(i, true);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.RedBox(i, false);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem46_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.Ufo(i, true);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.Ufo(i, false);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem48_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.allPerks(i);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem51_Click(object sender, EventArgs e)
        {
            string a = "";
            if (InputBox("Change Clients Name", "Enter Clients New Name:", ref a) == DialogResult.OK)
            {
                for (int i = 0; i < 18; i++)
                {
                    if (Functions.isSameTeam(i) == true)
                    {
                        byte[] NewName = Encoding.ASCII.GetBytes(a + "\0");
                        PS3.SetMemory(0x0110D694 + (0x3980 * (uint)i), NewName);
                        Functions.iPrintln(i, "Your Name Is Now: " + a);
                    }
                    else
                    {

                    }
                }
                AllClients.Show();
            }
            else
            {
                //nothing
                AllClients.Show();
            }
        }

        private void toolStripMenuItem69_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.MW2Wallhack(i, true);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem70_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.MW2Wallhack(i, false);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem72_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.Turtle(i);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem73_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.Speedx2(i);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem74_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.Speedx4(i);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem75_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.Default(i);
                }
                else
                {

                }
            }
        }

        private void toolStripMenuItem77_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Nothing);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem78_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Delta);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem79_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Snow);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem80_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Multicam);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem81_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Digital);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem82_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Hex);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem83_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Choco);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem84_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Snake);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem85_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Blue);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem86_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Red);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem87_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Autumn);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem88_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Gold);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem89_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Winter);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem90_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Weapons.ChangeCamo(i, Functions.Weapons.Camos.Marine);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem97_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
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

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 28 + Value);//acr
                        Functions.InfAmmo(i);
                    }
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem98_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
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

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 20 + Value);//p90
                        Functions.InfAmmo(i);
                    }
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem99_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
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

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 26 + Value);//m4a1
                        Functions.InfAmmo(i);
                    }
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem100_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
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

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 42 + Value);//msr
                        Functions.InfAmmo(i);
                    }
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem101_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
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

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 50 + Value);//m4a1
                        Functions.InfAmmo(i);
                    }
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem102_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
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

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 24 + Value);//m4a1
                        Functions.InfAmmo(i);
                    }
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem103_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
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

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 36 + Value);//m4a1
                        Functions.InfAmmo(i);
                    }
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem123_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == true)
                {
                    Functions.Clients.TakeWeapon(i);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem130_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.godMode(i);
                    Functions.iPrintln(i, "^5God Mode Is ^2Enabled For Your Team ^:" + Functions.GetName(i));
                }
                else
                {
                    
                }
            } 
        }

        private void toolStripMenuItem131_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.godMode1(i);
                    Functions.iPrintln(i, "^5God Mode Is ^1Disabled For Your Team ^:" + Functions.GetName(i));
                }
                else
                {
                   
                }
            } 
        }

        private void toolStripMenuItem133_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.InfAmmo(i, true);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem134_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.InfAmmo(i, false);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem136_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.CBUF_ADDTEXT("bg_bulletExplRadius 1000");
                    Functions.CBUF_ADDTEXT("bg_bulletExplDmgFactor 100");
                    Functions.Clients.ExplosiveBullets(i, true);
                }
                else
                {
                    
                }
            } 
        }

        private void toolStripMenuItem137_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.ExplosiveBullets(i, false);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem140_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.Akimboon(i);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem141_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.Akimbooff(i);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem143_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.RedBox(i, true);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem144_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.RedBox(i, false);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem146_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.Ufo(i, true);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem147_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.Ufo(i, false);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem148_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.allPerks(i);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem151_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.Teleport.teleportETeamm();

                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem153_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.MW2Wallhack(i, true);

                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem154_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.MW2Wallhack(i, false);
                }
                else
                {
                    
                }
            } 
        }

        private void toolStripMenuItem156_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.Turtle(i);
                }
                else
                {

                }
            } 
        }

        private void toolStripMenuItem157_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.Speedx2(i);
                }
                else
                {
                  
                }
            } 
        }

        private void toolStripMenuItem158_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {

                }
                else
                {
                    Functions.Clients.Speedx4(i);
                }
            } 
        }

        private void toolStripMenuItem159_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.Default(i);
                }
                else
                {
                    
                }
            } 
        }

        private void toolStripMenuItem181_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.TakeWeapon(i);
                    int Value = 0;
                    byte[] buffer = new byte[100];
                    PS3.GetMemory(0x8360d5, ref buffer);
                    System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
                    string Map = Encoding.GetString(buffer).Split(Convert.ToChar(0x5c))[6];
                    if (Map == "mp_seatown" | Map == "mp_plaza2" | Map == "mp_exchange" | Map == "mp_bootleg" | Map == "mp_alpha" | Map == "mp_village" | Map == "mp_bravo" | Map == "mp_courtyard_ss" | Map == "mp_aground_ss")
                        Value = -1;
                    else
                        Value = 0;

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 28 + Value);//acr
                        Functions.InfAmmo(i);
                    }  
                }
                else
                {
                   
                }
            } 
        }

        private void toolStripMenuItem182_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.TakeWeapon(i);
                    int Value = 0;
                    byte[] buffer = new byte[100];
                    PS3.GetMemory(0x8360d5, ref buffer);
                    System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
                    string Map = Encoding.GetString(buffer).Split(Convert.ToChar(0x5c))[6];
                    if (Map == "mp_seatown" | Map == "mp_plaza2" | Map == "mp_exchange" | Map == "mp_bootleg" | Map == "mp_alpha" | Map == "mp_village" | Map == "mp_bravo" | Map == "mp_courtyard_ss" | Map == "mp_aground_ss")
                        Value = -1;
                    else
                        Value = 0;

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 20 + Value);//p90
                        Functions.InfAmmo(i);
                    }
                }
                else
                {
                    
                }
            } 
        }

        private void toolStripMenuItem183_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
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

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 26 + Value);//m4a1
                        Functions.InfAmmo(i);
                    }
                }
                else
                {
                   
                }
            } 
        }

        private void toolStripMenuItem184_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
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

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 42 + Value);//msr
                        Functions.InfAmmo(i);
                    }
                }
                else
                {
                   
                }
            } 
        }

        private void toolStripMenuItem185_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
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

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 50 + Value);//aa12
                        Functions.InfAmmo(i);
                    }
                }
                else
                {
                    
                }
            } 
        }

        private void toolStripMenuItem186_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
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

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 24 + Value);//ak47
                        Functions.InfAmmo(i);
                    }
                }
                else
                {
                   
                }
            } 
        }

        private void toolStripMenuItem187_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
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

                    if (PS3.ReadInt(0xFCA41D + ((uint)i * 0x280)) > 0) // Cheacks If Client Is Alive
                    {
                        GiveWeapon((uint)i, 36 + Value);//rpg
                        Functions.InfAmmo(i);
                    }
                }
                else
                {
                    
                }
            } 
        }

        private void toolStripMenuItem189_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.LagPlayer(i, true);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem190_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.LagPlayer(i, false);

                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem192_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.FreezePlayer(i, true);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem193_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.FreezePlayer(i, false);
                }
                else
                {
                }
            } 
        }


        private void toolStripMenuItem196_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.Suicide(i);
                }
                else
                {
                }
            } 
        }

        private void toolStripMenuItem207_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.TakeWeapon(i);
                }
                else
                {
                    
                }
            } 
        }

        private void toolStripMenuItem208_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Invert(i, 7);
                }
                else
                {
                    
                }
            } 
        }

        private void toolStripMenuItem212_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.PS3Freeze(i);
                }
                else
                {
                    
                }
            } 
        }

        private void clientToHostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Functions.Clients.Teleport.TeleportCToC((uint)i, (uint)Functions.GetHostNumber());
        }

        private void meToClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Functions.Clients.Teleport.TeleportCToC((uint)Functions.GetHostNumber(), (uint)i);
        }

        private void changeEnemysNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = "";
            if (InputBox("Change Clients Name", "Enter Clients New Name:", ref a) == DialogResult.Cancel)
            {
                
            }
            else
            {
                for (int i = 0; i < 18; i++)
                {
                    if (Functions.isSameTeam(i) == false)
                    {
                        byte[] NewName = Encoding.ASCII.GetBytes(a + "\0");
                        PS3.SetMemory(0x0110D694 + (0x3980 * (uint)i), NewName);
                        Functions.iPrintln(i, "Your Name Is Now: " + a);
                    }
                    else
                    {

                    }
                }
                
            }
        }

        private void oNToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Functions.Clients.JammRadar((uint)i, true);
        }

        private void oFFToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            Functions.Clients.JammRadar((uint)i, false);
        }

        private void oNToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.JammRadar((uint)i, true);
                }
                else
                {
                }
            }
        }

        private void oFFToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 18; i++)
            {
                if (Functions.isSameTeam(i) == false)
                {
                    Functions.Clients.JammRadar((uint)i, false);

                }
                else
                {
                }
            }
        }
    }
}








