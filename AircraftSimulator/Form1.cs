using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Media;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
namespace AircraftSimulator
{
    public partial class Game : Form
    {
        public World World = new World();
        public dynamic Player = new Aircraft(new Vector());

        public List<string> PressedKeys = new List<string>();
        DateTime LastFPSUpdate = DateTime.Now;
        int FramesCount = 0;
        public string TeamA = "TeamA";
        public Camera cam = new Camera();
        public bool DoSpawnAircraft = true;
        public double SpawnAircraftDelay = 20;
        public DateTime LastSpawnAircraftTime = DateTime.MinValue;
        Vector ContextMenuPos = new Vector();
        public Game()
        {

            InitializeComponent();
            InitUI();
            InitWorld();

        }
        private void InitWorld()
        {
            World = new World();
            Player = new Aircraft(new Vector());
            Player.EnableAI = false;
            Player.TrapsDelay = 0.2;
            World.InstantiateObject(Player);
            Player.Color = Color.LimeGreen;
            World.InstantiateObject(new Aircraft(new Vector(-200, 200)) { Team = TeamA });
            //World.InstantiateObject(new Missile(new Vector(50, -2000)));
            World.InstantiateObject(new Antiair(new Vector(-6000, -200)) { Team = TeamA });
            World.InstantiateObject(new Base(new Vector(-1200)) { Rotation = 340, Team = TeamA });
            World.ShowInfo = ShowInfoToggle.Checked;
            World.EnableSmoke = EnableSmokeCheckBox.Checked;
            Airport a = new Airport(new Vector(300)) { Team = Player.Team, Rotation = 30 };
            a.LandedAircraft = Player;
            a.LandedAircraftOriginalMinSpeed = Player.MinSpeed;
            Player.Pos = Core.MoveForward(a.Pos.Copy(), a.Rotation, -((a.Length / 2) - Player.Model.GetAvarageRadius() - 30));
            Player.Rotation = a.Rotation;
            Player.Speed = 0;
            Player.MinSpeed = 0;
            Player.Grounded = true;
            World.InstantiateObject(a);
            cam.Pos = Player.Pos;
        }
        private void InitUI()
        {
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Width = (int)Core.Screen.X;
            pictureBox1.Height = (int)Core.Screen.Y;
            pictureBox1.BackColor = Color.Black;
            FPS.BackColor = Color.FromArgb(255, 0, 0, 0);
        }
        public bool IsPressed(string key)
        {
            foreach (string i in PressedKeys)
            {
                if (i == key) return true;
            }
            return false;
        }
        public void SpawnEnemyAircraft(int range = 5000)
        {
            World.InstantiateObject(new Aircraft(Core.RandomVector(5000)));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //óïðàâëÿòüToolStripMenuItem_MouseEnter(null, new EventArgs());
            Core.Screen = new Vector(Width, Height);
            if (DateTime.Now.Subtract(LastSpawnAircraftTime).TotalSeconds > SpawnAircraftDelay && DoSpawnAircraft)
            {
                SpawnEnemyAircraft();
                LastSpawnAircraftTime = DateTime.Now;
            }
            World.Update();
            cam.Pos = Player.GetType() == typeof(Aircraft) && Player.Speed > Player.MaxSpeed ? Player.Pos + Core.RandomVector(1.5 * Player.MaxSpeed / Player.Speed) : Player.Pos;
            Bitmap img = World.Render(cam);
            if (Player.GetType().GetField("RWS") != null) img = World.RenderObject(Player.RWS, img, null);
            if (Player.GetType().GetField("Radar") != null) img = World.RenderObject(Player.Radar, img, null, true);
            if (Player.GetType().GetField("TrapsCount") != null) FlaresCountLabel.Text = $"ËÒÖ: {Player.TrapsCount}/{Player.MaxTrapsCount}";
            SpeedLabel.Text = $"Ñêîðîñòü: {Math.Round(Player.Speed, 1)}";
            if (Player.GetType() == typeof(Aircraft) || (Player.GetType() == typeof(Antiair) && Player.Gun.GetType() == typeof(Gun))) AmmoInfoLabel.Text = $"ÐÊÒ: {Player.Gun.Ammo[Player.Gun.SelectedAmmo].Name} {Player.Gun.AmmoCount}/{Player.Gun.MaxAmmoCount}";
            if (Player.GetType().GetField("BulletGun") != null) BulletGunAmmoInfo.Text = $"ÏØÊ: {Player.BulletGun.AmmoCount} / {Player.BulletGun.MaxAmmoCount}";
            else if (Player.GetType().GetField("Gun") != null && Player.Gun.GetType() == typeof(BulletGun)) BulletGunAmmoInfo.Text = $"ÏØÊ: {Player.Gun.AmmoCount} / {Player.Gun.MaxAmmoCount}";
            pictureBox1.Image = img;
            FramesCount += 1;
            if (DateTime.Now.Subtract(LastFPSUpdate).TotalSeconds >= 1)
            {
                FPS.Text = $"{FramesCount} FPS";
                LastFPSUpdate = DateTime.Now;
                FramesCount = 0;
            }
            if (IsPressed("D"))
            {
                if (Player.GetType() == typeof(Aircraft)) Player.TurnRight();
                else Player.Rotation += 2;
            }
            if (IsPressed("A"))
            {
                if (Player.GetType() == typeof(Aircraft)) Player.TurnLeft();
                else Player.Rotation -= 2;
            }
            if (IsPressed("W"))
            {
                Player.Speed += Player.IncreaseSpeedValue;
            }
            if (IsPressed("S"))
            {
                Player.Speed -= Player.IncreaseSpeedValue;
            }
            if (IsPressed("MouseLeft"))
            {
                if (Player.GetType() == typeof(Aircraft)) Player.BulletGun.Shoot();
                if (Player.GetType() == typeof(Antiair)) Player.Gun.Shoot();
            }
            double overload = Player.GetOverload();
            OverloadInfo.Text = $"{Math.Round(overload, 1)} G";
            OverloadInfo.ForeColor = (Player.GetOverload() < 8) ? Color.FromArgb(255, 0, 192, 0) : Color.Red;
            if (Player.GetType() == typeof(Aircraft)) StaminaBar.Value = (int)Player.PilotStamina;
            if (Player.GetType() == typeof(Antiair))
            {
                Player.Gun.Rotation = GetMouseInTheWorld(cam.Pos).AngleTo(Player.Pos) + 180;
            }
        }

        private void Game_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FPS_Click(object sender, EventArgs e)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {
            Debug.WriteLine(Core.GetObjectsUpdateSpeed());
        }

        private void Game_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }
        public void SetPlayerAmmo(int id)
        {
            if (Player.GetType().GetField("Gun") != null && Player.Gun.GetType() == typeof(Gun)) Player.Gun.SelectedAmmo = id >= 0 && id <= Player.Gun.Ammo.Count - 1 ? id : Player.Gun.SelectedAmmo;
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            PressedKeys.Add(e.KeyCode.ToString());
            switch (e.KeyCode.ToString())
            {
                case "R":
                    InitWorld();
                    break;
                case "F3":
                    ShowInfoToggle.Checked = ShowInfoToggle.Checked ? false : true;
                    break;
                case "ShiftKey":
                    if (Player.GetType() == typeof(Aircraft)) Player.DoTraps();
                    break;
                case "Space":
                    if (Player.GetType().GetField("Gun") != null) Player.Gun.Shoot();
                    break;
                case "D1": SetPlayerAmmo(0); break;
                case "D2": SetPlayerAmmo(1); break;
                case "D3": SetPlayerAmmo(2); break;
                case "D4": SetPlayerAmmo(3); break;
                case "D5": SetPlayerAmmo(4); break;
                case "D6": SetPlayerAmmo(5); break;
                case "D7": SetPlayerAmmo(6); break;
                case "D8": SetPlayerAmmo(7); break;
                case "D9": SetPlayerAmmo(8); break;
                case "D0": SetPlayerAmmo(9); break;
            }

        }
        private void RemovePressedKey(string k)
        {
            List<string> temp = new List<string>();
            foreach (string key in PressedKeys)
            {
                if (key != k)
                {
                    temp.Add(key);
                }
            }
            PressedKeys = temp;
        }
        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            RemovePressedKey(e.KeyCode.ToString());
        }

        private void EnableSmokeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            World.EnableSmoke = EnableSmokeCheckBox.Checked;
            ActiveControl = null;
        }
        private void ShowInfoToggle_CheckedChanged(object sender, EventArgs e)
        {
            World.ShowInfo = ShowInfoToggle.Checked;
            ActiveControl = null;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ContextMenuPos = GetMousePosition();
        }

        private void ðËÑToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ðåñòàðòRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitWorld();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Player.Pos = new Vector(0, 0);
        }
        private void ñëó÷àéíîToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.Pos = Core.RandomVector(60000);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Player.Pos = Core.MoveForward(Player.Pos, Player.Rotation, 100);
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Player.Pos = Core.MoveForward(Player.Pos, Player.Rotation, 1000);
        }
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Player.Pos = Core.MoveForward(Player.Pos, Player.Rotation, 5000);
        }
        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Player.Pos = Core.MoveForward(Player.Pos, Player.Rotation, 10000);
        }
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Player.Pos = Core.MoveForward(Player.Pos, Player.Rotation, 50000);
        }
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Player.Pos = Core.MoveForward(Player.Pos, Player.Rotation, 100000);
        }
        public Vector GetMousePosition()
        {

            return new Vector(MousePosition.X - Location.X - pictureBox1.Location.X, MousePosition.Y - Location.Y - pictureBox1.Location.Y);
        }
        public Vector GetMouseInTheWorld(Vector CameraPos, Vector? MousePos = null)
        {
            return CameraPos + ((MousePos == null ? -GetMousePosition() : -MousePos) + Core.Screen / 2);
        }
        private void ñàìîëåòToolStripMenuItem_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Aircraft(GetMouseInTheWorld(cam.Pos, ContextMenuPos)));
        }

        private void ðàêåòàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Missile(GetMouseInTheWorld(cam.Pos, ContextMenuPos)));
        }

        private void ïÂÎToolStripMenuItem_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Antiair(GetMouseInTheWorld(cam.Pos, ContextMenuPos)));
        }

        private void áàçóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Base(GetMouseInTheWorld(cam.Pos, ContextMenuPos)));
        }

        private void àåðîïîðòToolStripMenuItem_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Airport(GetMouseInTheWorld(cam.Pos, ContextMenuPos)));
        }
        private void êÎÝÏÇîíòToolStripMenuItem_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Umbrella(GetMouseInTheWorld(cam.Pos, ContextMenuPos)));
        }
        public void CreateAntiairComplex(int w = 10, int h = 1, double padding = 40, double YPaddding = 70)
        {
            Vector p = GetMouseInTheWorld(cam.Pos, ContextMenuPos);

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    World.InstantiateObject(new Antiair(p.Copy() + new Vector(x * padding, y * YPaddding)) { Team = "AntiairComplex" });
                }
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CreateAntiairComplex(10, 1);
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CreateAntiairComplex(10, 5);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            CreateAntiairComplex(10, 10);
        }

        private void Game_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void FlaresCountLabel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) PressedKeys.Add("MouseLeft");
            if (e.Button == MouseButtons.Right) PressedKeys.Add("MouseRight");
            if (e.Button == MouseButtons.Middle) PressedKeys.Add("MouseMiddle");
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) RemovePressedKey("MouseLeft");
            if (e.Button == MouseButtons.Right) RemovePressedKey("MouseRight");
            if (e.Button == MouseButtons.Middle) RemovePressedKey("MouseMiddle");
        }

        private void óäàëèòüÏÂÎToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < World.Objects.Count; i++)
            {
                dynamic obj = World.Objects[i];
                if (obj.GetType() == Core.AntiairType)
                {
                    obj.Destroy();
                }
            }
            if (World.Objects.Any(o => o.GetType() == Core.AntiairType))
            {
                óäàëèòüÏÂÎToolStripMenuItem_Click(sender, e);
            }
        }

        private void ïÂÎÏØÊToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void îòêëþ÷èòüÂÂÑToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSpawnAircraft = false;
        }

        private void lWingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.DestructableModules.Remove("LeftWing");
        }

        private void rWingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.DestructableModules.Remove("RightWing");
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.DestructableModules.Remove("Back");
        }

        private void fuelTankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.DestructableModules.Remove("FuelTank");
        }

        private void óíè÷òîæèòüÌîäóëüToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ììToolStripMenuItem_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Bullet(GetMouseInTheWorld(cam.Pos, ContextMenuPos), 50, 3));
        }

        private void ììToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Bullet(GetMouseInTheWorld(cam.Pos, ContextMenuPos), 50, 7.62));
        }

        private void ììToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Bullet(GetMouseInTheWorld(cam.Pos, ContextMenuPos), 50, 12));
        }

        private void ììToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Bullet(GetMouseInTheWorld(cam.Pos, ContextMenuPos), 50, 20));
        }

        private void ììToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Bullet(GetMouseInTheWorld(cam.Pos, ContextMenuPos), 50, 30));
        }

        private void ììToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Bullet(GetMouseInTheWorld(cam.Pos, ContextMenuPos), 50, 120));
        }

        private void ììToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            World.InstantiateObject(new Bullet(GetMouseInTheWorld(cam.Pos, ContextMenuPos), 50, 1488));
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void óíè÷òîæèòüÂñåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<dynamic> temp = [.. World.Objects];
            World.Objects = new List<dynamic>();
            foreach (dynamic obj in temp)
            {
                Core.DestroyModeleffect(obj);
            }
        }

        private void óïðàâëÿòüToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void OnControlItemClick(dynamic sender, EventArgs e)
        {
            dynamic o = World.FindObjectWithId(sender.Tag);
            if (o != null)
            {
                Player = o;
                if (new List<Type> { typeof(Antiair) }.Contains(Player.GetType()))
                {
                    Player.EnableAI = false;
                }
            }
        }
        private void óïðàâëÿòüToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            óïðàâëÿòüToolStripMenuItem.DropDownItems.Clear();
            int i = 0;
            foreach (dynamic o in World.Objects)
            {
                Type t = o.GetType();
                if (t != Core.SmokeType && t != Core.ThermalTrapType)
                {
                    óïðàâëÿòüToolStripMenuItem.DropDownItems.Add(o.Name, null, new EventHandler(OnControlItemClick));
                    óïðàâëÿòüToolStripMenuItem.DropDownItems[i].Tag = o.Id;
                    i++;
                }
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Antiair a = new Antiair(GetMouseInTheWorld(cam.Pos, ContextMenuPos), "BulletGun");
            a.Gun.Delay = 0.01;
            a.Gun.Caliber = 3;
            a.Gun.MaxAmmoCount = 1200;
            a.Gun.AmmoCount = 1200;
            World.InstantiateObject(a);
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Antiair a = new Antiair(GetMouseInTheWorld(cam.Pos, ContextMenuPos), "BulletGun");
            a.Gun.Delay = 0.1;
            a.Gun.Caliber = 7.62;
            World.InstantiateObject(a);
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Antiair a = new Antiair(GetMouseInTheWorld(cam.Pos, ContextMenuPos), "BulletGun");
            a.Gun.Delay = 0.13;
            a.Gun.Caliber = 12;
            World.InstantiateObject(a);
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Antiair a = new Antiair(GetMouseInTheWorld(cam.Pos, ContextMenuPos), "BulletGun");
            a.Gun.Delay = 0.2;
            a.Gun.Caliber = 20;
            World.InstantiateObject(a);
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Antiair a = new Antiair(GetMouseInTheWorld(cam.Pos, ContextMenuPos), "BulletGun");
            a.Gun.Delay = 0.7;
            a.Gun.Caliber = 80;
            World.InstantiateObject(a);
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Antiair a = new Antiair(GetMouseInTheWorld(cam.Pos, ContextMenuPos), "BulletGun");
            a.Gun.Delay = 1.5;
            a.Gun.Caliber = 300;
            World.InstantiateObject(a);
        }
    }
}
