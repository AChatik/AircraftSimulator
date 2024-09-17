using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Threading;
using System.Numerics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Reflection;
namespace AircraftSimulator
{
    public class Core
    {
        public static Type MissileType = new Missile(new Vector()).GetType();
        public static Type AirportType = new Airport(new Vector()).GetType();
        public static Type AntiairType = new Antiair(new Vector()).GetType();
        public static Type ThermalTrapType = new ThermalTrap(new Vector()).GetType();
        public static Type ExplosionType = new Explosion(new Vector()).GetType();
        public static Type AircraftType = new Aircraft(new Vector()).GetType();
        public static Type ModelType = new Model(new List<Vector>()).GetType();
        public static Type GunType = new Gun(new Vector()).GetType();
        public static Type RadarType = new Radar(new Vector()).GetType();
        public static Type MissileTargetType = new MissileTarget(new Vector()).GetType();
        public static Type WorldType = new World().GetType();
        public static Type SmokeType = new Smoke(new Vector()).GetType();
        public static Type VectorType = new Vector().GetType();
        public static Type BaseType = new Base().GetType();
        public static Type RWSType = new RWS().GetType();
        public static Type UmbrellaType = new Umbrella().GetType();
        public static Type BulletType = new Bullet().GetType();
        public static Type BulletGunType = new BulletGun().GetType();

        public static Random Random = new Random();

        public static Missile Aim9L = new Missile()
        {
            Name = "Aim 9L",
            Radar = new Radar(new Vector(), 0, 9000, 60, 0.1) { IsRadio = false },
            AfterburnAddSpeed = 1,
            AfterburnerTime = 0.6,
            IncreaseSpeedValue = 0.2,
            AfterburnIncreaseSpeedValue = 3,
            RadioFuseDistance = 30,
            DetonationTime = 40,
            IncreaseRotationSpeedValue = 1,
            MaxRotationSpeed = 110
        };
        public static Missile Aim120A = new Missile()
        {
            Name = "Aim 120A",
            Radar = new Radar(new Vector(), 0, 70000, 30, 0) { IsRadio = true },
            AfterburnAddSpeed = 2,
            AfterburnerTime = 0.1,
            IncreaseSpeedValue = 2,
            AfterburnIncreaseSpeedValue = 5,
            RadioFuseDistance = 30,
            DetonationTime = 300,
            IncreaseRotationSpeedValue = 1,
            maxRadarRotationAngle = 220,
            MaxRotationSpeed = 90
        };
        public static Missile m_9M37 = new Missile()
        {
            Name = "9M37 (Стрела)",
            Radar = new Radar(new Vector(), 0, 6000, 90, 0.1) { IsRadio = false },
            AfterburnAddSpeed = 1,
            AfterburnerTime = 0.6,
            IncreaseSpeedValue = 0.2,
            AfterburnIncreaseSpeedValue = 3,
            IncreaseRotationSpeedValue = 1,
            maxRadarRotationAngle = 30,
            MaxRotationSpeed = 50

        };
        public static Missile m_9M335 = new Missile()
        {
            Name = "9M335",
            Radar = new Radar(new Vector(), 0, 18000, 10, 0.05) { IsRadio = false },
            AfterburnAddSpeed = 1,
            AfterburnerTime = 0.7,
            IncreaseSpeedValue = 2,
            AfterburnIncreaseSpeedValue = 6,
            IncreaseRotationSpeedValue = 1,
            maxRadarRotationAngle = 120,
            MaxRotationSpeed = 80
        };
        public static Missile Tor_M1 = new Missile()
        {
            Name = "Тор М1",
            Radar = new Radar(new Vector(), 0, 60000, 40, 0.2) { IsRadio = false },
            AfterburnAddSpeed = 1,
            AfterburnerTime = 1.4,
            IncreaseSpeedValue = 1,
            AfterburnIncreaseSpeedValue = 2.5,
            IncreaseRotationSpeedValue = 1,
            maxRadarRotationAngle = 45,
            MaxRotationSpeed = 50
        };
        public static Missile Helmet1 = new Missile()
        {
            Name = "Шлем 1",
            Radar = new Radar(new Vector(), 0, 5000, 20, 0.02) { IsRadio = false, MinTemperature = 600 },
            AfterburnAddSpeed = 1,
            AfterburnerTime = 0.3,
            IncreaseSpeedValue = 3,
            AfterburnIncreaseSpeedValue = 8,
            DetonationTime = 10,
            RadioFuseDistance = 30,
            IncreaseRotationSpeedValue = 1,
            maxRadarRotationAngle = 45,
            MaxRotationSpeed = 150
        };
        public static Missile Helmet2 = new Missile()
        {
            Name = "Шлем 2",
            Radar = new Radar(new Vector(), 0, 2000, 40, 0.01) { IsRadio = false, MinTemperature = 700 },
            AfterburnAddSpeed = 5,
            AfterburnerTime = 0.05,
            IncreaseSpeedValue = 5,
            AfterburnIncreaseSpeedValue = 24,
            DetonationTime = 3,
            RadioFuseDistance = 30,
            IncreaseRotationSpeedValue = 1,
            maxRadarRotationAngle = 160,
            MaxRotationSpeed = 220
        };
        public static Color CopyColor(Color c)
        {
            return Color.FromArgb(c.A, c.R, c.G, c.B);
        }
        public static SoundPlayer FlaresSound = new SoundPlayer();
        public static Vector RandomVector(double Range = 1)
        {
            Random r = Core.Random;
            return new Vector(r.Next(-(int)(Range * 10000), (int)(Range * 10000)) / 10000, r.Next(-(int)(Range * 10000), (int)(Range * 10000)) / 10000);
        }
        public static Bitmap RenderRadarRange(Bitmap img, Radar r, Vector p, Color c)
        {
            Graphics g = Graphics.FromImage(img);
            g.DrawLine(new Pen(c), Core.MoveForward(p.Copy(), r.Rotation + r.DetectAngle / 2, -r.DetectRange).ToPoint(), p.ToPoint());
            g.DrawLine(new Pen(c), Core.MoveForward(p.Copy(), r.Rotation - r.DetectAngle / 2, -r.DetectRange).ToPoint(), p.ToPoint());
            c = Color.FromArgb(10, c.R, c.G, c.B);
            if (r.DetectRange <= 1000) g.FillPie(new SolidBrush(c), new Rectangle((int)(p.X - r.DetectRange), (int)(p.Y - r.DetectRange), (int)r.DetectRange * 2, (int)r.DetectRange * 2), (float)(r.Rotation - r.DetectAngle / 2 - 90), (float)(r.DetectAngle));
            return img;
        }
        public static void DestroyModeleffect(dynamic o)
        {
            o.MyWorld.InstantiateObject(new Smoke(o.Pos.Copy(), o.Model.GetAvarageRadius(), 0.2, null, false));
            foreach (Vector p in RotateModel(o.Model, o.Rotation).Points)
            {
                o.MyWorld.InstantiateObject(new ThermalTrap(o.Pos.Copy() + p, o.Speed * 0.9 + 2 + Random.Next(0,9)) { Rotation = o.Pos.AngleTo(MoveForward(o.Pos, o.Rotation - 180, o.Speed*8) + p) + 180 + Core.Random.Next(-20, 20), LifeTime = 2 + Random.Next(-200,200)/100});
            }

        }
        public static double Sin(double d)
        {
            return Math.Sin(Radians(d));
        }
        public static double Cos(double d)
        {
            return Math.Cos(Radians(d));
        }
        public static Vector Screen = new Vector(1600, 900);
        public static double GetObjectUpdatesSpeed(dynamic o)
        {
            o.MyWorld = new World();
            DateTime start = DateTime.Now;
            o.Update();
            //o.Update05S();
            //o.Update1S();
            //o.Update10S();
            return DateTime.Now.Subtract(start).TotalSeconds;
        }
        public static string GetObjectsUpdateSpeed()
        {
            string result = "";
            result += $"ObjectBase: {GetObjectUpdatesSpeed(new ObjectBase(new Vector()))} s\n";
            result += $"Smoke: {GetObjectUpdatesSpeed(new Smoke(new Vector()))} s\n";
            result += $"MissileTarget: {GetObjectUpdatesSpeed(new MissileTarget(new Vector()))} s\n";
            result += $"Radar: {GetObjectUpdatesSpeed(new Radar(new Vector()))} s\n";
            result += $"Smoke: {GetObjectUpdatesSpeed(new Smoke(new Vector()))} s\n";
            result += $"Gun: {GetObjectUpdatesSpeed(new Gun(new Vector()))} s\n";
            result += $"Aircraft: {GetObjectUpdatesSpeed(new Aircraft(new Vector()))} s\n";
            result += $"Missile: {GetObjectUpdatesSpeed(new Missile(new Vector()))} s\n";
            result += $"Explosion: {GetObjectUpdatesSpeed(new Explosion(new Vector()))} s\n";
            result += $"ThermalTrap: {GetObjectUpdatesSpeed(new ThermalTrap(new Vector()))} s\n";
            result += $"Antiair: {GetObjectUpdatesSpeed(new Antiair(new Vector()))} s\n";
            result += $"Airport: {GetObjectUpdatesSpeed(new Airport(new Vector()))} s\n";
            result += $"Base: {GetObjectUpdatesSpeed(new Base(new Vector()))} s\n";
            return result;
        }
        public static Vector MoveForward(Vector v, double Angle, double Distance)
        {
            Angle += 90;
            Angle = Radians(Angle);
            return new Vector(v.X + Distance * Math.Cos(Angle), v.Y + Distance * Math.Sin(Angle));
        }
        public static double Radians(double d)
        {
            return d * (Math.PI / 180);
        }
        public static double Degrees(double rad)
        {
            return (180 / Math.PI) * rad;
        }
        public static Bitmap PutText(Bitmap img, string text, Vector pos, Color color, int size = 12)
        {
            Font f = new Font(FontFamily.GenericSansSerif, size);
            Graphics g = Graphics.FromImage(img);
            g.DrawString(
                text,
                f,
                new SolidBrush(
                    color
                ),

                (float)pos.X,
                (float)pos.Y
            );
            return img;
        }
        public static double GetAngle(Vector root, Vector a)
        {
            double d = root.DistanceTo(a);
            double x = (root.X - a.X);
            double y = (root.Y - a.Y);
            double Cos = x != 0 ? x / d : 0;
            double Sin = y != 0 ? y / d : 0;

            double an = 0;
            if (Sin >= 0 && Cos >= 0) an = Math.Asin(Sin);

            else if (Sin >= 0 && Cos < 0) an = Math.Acos(Cos);

            else if (Sin < 0 && Cos < 0) an = Radians(180) + Math.Abs(Math.Asin(Sin));

            else if (Sin < 0 && Cos >= 0) an = Radians(270) + (Radians(90) - Math.Acos(Cos));

            an = Degrees(an);

            return (an + 90 < 360) ? an + 90 : an + 90 - 360;
        }
        public static Bitmap RenderModel(dynamic o, Vector Pos, Bitmap img, Vector? Multiplyer = null, Model? model = null)
        {
            Graphics g = Graphics.FromImage(img);
            Brush brush = new SolidBrush(o.Color);
            Model t = model == null ? o.Model.Copy() : model.Copy();
            if (Multiplyer == null)
            {
                Multiplyer = new Vector(1, 1);
            }
            for (int i = 0; i < t.Points.Count; i++)
            {
                t.Points[i] *= Multiplyer;
            }
            Model m = RotateModel(t, o.Rotation);

            for (int i = 0; i < m.Points.Count; i++)
            {
                Vector MP = m.Points[i];
                g.FillEllipse(brush, (float)(Pos.X - o.Size / 2), (float)(Pos.Y - o.Size / 2), (float)o.Size, (float)o.Size);
                if (m.Points.Count > 1)
                {
                    Vector lMP = m.Points[i - 1 < 0 ? m.Points.Count - 1 : i - 1];
                    Point p1 = (Pos + MP).ToPoint();
                    Point p2 = (Pos + lMP).ToPoint();
                    g.DrawLine(new Pen(o.Color, (float)o.Size), p1, p2);
                }
            }
            return img;
        }
        public static Model RotateModel(Model model, double deg)
        {
            Model result = new Model(new List<Vector>());
            Vector root = new Vector(0, 0);
            foreach (Vector i_ in model.Points)
            {
                Vector i = i_.Copy();
                double d = root.DistanceTo(i);
                double a = deg + root.AngleTo(i) + 90;
                double cos = -Math.Cos(Radians(a));
                double sin = -Math.Sin(Radians(a));
                i.X = root.X + d * cos;
                i.Y = root.Y + d * sin;
                result.Points.Add(i);
            }
            return result;
        }
        public double norm(double size, double Min, double param, double paramLow, double paramTop) => -(((size / (paramTop - paramLow)) * (paramTop - param)) - size) + Min;
        internal static bool IsObjectInRadar(ObjectBase o, Radar r)
        {
            double a = r.Pos.AngleTo(o.Pos);
            bool IsInRadar = false;

            if (a > r.Rotation - (r.DetectAngle / 2) && a < r.Rotation + (r.DetectAngle / 2))
            {
                if (r.Pos.DistanceTo(o.Pos) <= r.DetectRange)
                {
                    IsInRadar = true;
                }
            }

            return IsInRadar;
        }
        public static bool LAng(double a1, double a2)
        {
            return (Cos(a1) + Sin(a1) > Sin(a2) + Cos(a2));
        }
        public static double NormRotation(double Rotation)
        {
            if (Rotation > 360)
            {
                Rotation -= 360;
            }
            if (Rotation < 0)
            {
                Rotation += 360;
            }
            if (Rotation > 360 || Rotation < 0)
            {
                NormRotation(Rotation);
            }
            return Rotation;
        }
    }
    public class Vector
    {
        public double X, Y;
        public Vector(double x=0, double y=0, double z=0) 
        {
            X = x;
            Y = y;
        }
        public double DistanceTo(Vector a)
        {
            return Math.Sqrt(Math.Pow(X - a.X, 2) + Math.Pow(Y - a.Y, 2));
        }
        public double AngleTo(Vector a)
        {
            return Core.GetAngle(this, a);
            
        }
        public override string ToString()
        {
            return $"{(int)X} {(int)Y}";
        }
        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y);
        public static Vector operator *(Vector a, Vector b) => new Vector(a.X * b.X, a.Y * b.Y);
        public static Vector operator /(Vector a, Vector b) => new Vector(a.X / b.X, a.Y / b.Y);
        public static Vector operator /(Vector a, int b) => new Vector(a.X / b, a.Y / b);
        public static Vector operator /(Vector a, double b) => new Vector(a.X / b, a.Y / b);
        public static Vector operator -(Vector a) => new Vector(-a.X, -a.Y);
        public Vector Copy()
        {
            return new Vector(X , Y);
        }
        public static Vector Copy(Vector a)
        {
            return new Vector(a.X, a.Y);
        }
        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }
    }
    public class Camera
    {
        public Vector Pos;
        public double Zoom = 0;
        public string Team = "CameraTeam";
        public Camera(Vector? pos=null)
        {
            Pos = pos == null? new Vector() : pos;
        }
    }
    public class ObjectBase
    {
        public double IncreaseSpeedValue = 0;
        public string Id = "";
        public string Team = $"Team_{new Random().Next(0,10000)}";
        public World MyWorld;
        public Vector Pos;
        public double Temperature = 50;
        public double Rotation = 0,
            RotationSpeed = 0,
            MaxRotationSpeed = 90,
            IncreaseRotationSpeedValue = 2,
            Size = 3, 
            Speed = 0;
        public string Name = "UnnamedObject";
        public Color Color = Color.FromArgb(255,255,255,255);
        public bool IsRadio = false;
        public double CleverMoveMultiplyer = 40;
        public Model Model = new Model(new List<Vector> { new Vector() });
        public bool Destroyed = false;
        public bool Grounded = false;
        public double MaxOverload = 24;
        public List<string> DestructableModules = new List<string> { "body" };
        public double GetOverload()
        {
            return Math.Abs(Speed * RotationSpeed)/(2*Math.PI)/17;
        }
        public ObjectBase Copy()
        {
            ObjectBase NewO = new ObjectBase(Pos);
            NewO.Name = Name;
            NewO.Color = Color;
            NewO.IsRadio = IsRadio;
            NewO.Rotation = Rotation;
            NewO.RotationSpeed = RotationSpeed;
            NewO.Size = Size;
            NewO.Speed = Speed;
            NewO.Team = Team;
            NewO.CleverMoveMultiplyer = CleverMoveMultiplyer;
            NewO.MyWorld = MyWorld;
            NewO.Model = Model;
            return NewO;

        }
        public ObjectBase(Vector? pos=null)
        {
            Pos = pos == null ? new Vector() : pos;
        }
        public virtual void OnPing(Radar? r) { }
        public virtual void Update() { 
            CleverRotation(); 
            CleverMove();
            if (RotationSpeed > MaxRotationSpeed) RotationSpeed = MaxRotationSpeed;
            if (RotationSpeed < -MaxRotationSpeed) RotationSpeed = -MaxRotationSpeed;
            if (!DestructableModules.Contains("body"))
            {
                Destroy();
            }
        }
        public virtual void Update05S() { }
        public virtual void Update1S() { }
        public virtual void Update10S() { }
        public override string ToString() => Name;
        public bool IsBulletPenetrated(Bullet b) => (Core.Random.NextDouble() < (b.Caliber / 25) * (b.Speed / b.StartSpeed)) ? true : false;
        public virtual void OnBulletHit(Bullet b)
        {
            if (IsBulletPenetrated(b)) this.Destroy();
        } 
        public double GetCleverSpeed()
        {
            return Speed * MyWorld.DeltaTime * CleverMoveMultiplyer;
        }
        public void CleverRotation()
        {
            Rotation += RotationSpeed * MyWorld.DeltaTime;
        }
        public void CleverMove()
        {
            Pos = Core.MoveForward(Pos, Rotation, GetCleverSpeed());
        }
        public void Destroy()
        {
            Core.DestroyModeleffect(this);
            MyWorld.Delete(this);
        }
        public void NormRotation()
        {
            Rotation = Core.NormRotation(Rotation);
        }

    }
    public class Smoke : ObjectBase
    {
        public double SizeSpeed = 0.3;
        bool RandomDelete = false;
        bool NotDeletedByRandom = false;
        public Smoke(Vector pos, double size = 20, double sizeSpeed = 0.3, Color? color = null, bool RandomDelete = true) : base(pos)
        {
            Size = size;
            SizeSpeed = sizeSpeed;
            Color = color == null ? Color.FromArgb(100, 255, 255, 255) : (Color)color;
            this.RandomDelete = RandomDelete;
            Name = "Smoke";

        }
        public new void Destroy()
        {
            MyWorld.Delete(this);
        }
        public override void Update()
        {

            if (RandomDelete && Core.Random.Next(1,4) == 1 && !NotDeletedByRandom)
            {
                MyWorld.Delete(this);
            }
            else
            {
                NotDeletedByRandom = true;
            }
            Size -= SizeSpeed;
            if (Size <= 1)
            {
                MyWorld.Delete(this);
            }
        }
        public Bitmap Render(Bitmap img)
        {
            
            Graphics grph = Graphics.FromImage(img);
            Brush brush = new SolidBrush(Color);
            grph.FillEllipse(brush, (float)Pos.X, (float)Pos.Y, (float)Size, (float)Size);
            return img;
        }
    }
    public class World
    {
        public List<dynamic> Objects;
        public double DeltaTime = 0.0;
        public DateTime LastCall = DateTime.Now;
        public DateTime LastUpdate05SCall = DateTime.MinValue;
        public DateTime LastUpdate1SCall = DateTime.MinValue;
        public DateTime LastUpdate10SCall = DateTime.MinValue;
        public bool ShowInfo = false;
        public bool EnableSmoke = true;
        public World()
        {
            Objects = new List<dynamic>();
        }
        public static string GenerateId(int len = 16)
        {
            string s = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            string r = "";
            for (int i = 0; i < len; i++)
            {
                r += s[Core.Random.Next(0, s.Length - 1)];
            }
            return r;
        }
        public void InstantiateObject(dynamic o)
        {
            if (o.GetType() == Core.SmokeType && !EnableSmoke) return;
            o.MyWorld = this;
            o.Id = GenerateId();
            Objects.Add(o);
           
        }
        public dynamic? FindObjectWithId(string id)
        {
            foreach (dynamic o in Objects)
            {
                if (o.Id == id) return o;
            }
            return null;
        }
        public void Delete(dynamic o)
        {
            Objects.Remove(o);
        }
        public void Update()
        {
            DeltaTime = (DateTime.Now.Subtract(LastCall)).TotalSeconds;
            if (DeltaTime > 1)
            {
                DeltaTime = 1;
            }
            LastCall = DateTime.Now;
            if (DateTime.Now.Subtract(LastUpdate05SCall).TotalSeconds >= 0.5)
            {
                LastUpdate05SCall = DateTime.Now;
                for (int i =0; i < Objects.Count; i++)
                {
                    dynamic o = Objects[i];
                    o.NormRotation();
                    o.Update05S();
                }
            }
            if (DateTime.Now.Subtract(LastUpdate1SCall).TotalSeconds >= 1)
            {
                Debug.WriteLine("Update1S()");
                LastUpdate1SCall = DateTime.Now;
                for (int i = 0; i < Objects.Count; i++)
                {
                    dynamic o = Objects[i];
                    o.NormRotation();
                    o.Update1S();
                }
            }
            if (DateTime.Now.Subtract(LastUpdate10SCall).TotalSeconds >= 10)
            {
                Debug.WriteLine("Update10S()");
                LastUpdate10SCall = DateTime.Now;
                for (int i = 0; i < Objects.Count; i++)
                {
                    dynamic o = Objects[i];
                    o.NormRotation();
                    o.Update10S();
                }
            }

            for (int i = 0; i < Objects.Count; i++)
            {
                dynamic o = Objects[i];
                o.NormRotation();
                o.Update();
            }
        }
        public Vector ObjectOnScreen(dynamic o, Camera cam)
        {
            return cam.Pos - o.Pos + Core.Screen / 2; ;
        }
        public Bitmap RenderObject(dynamic o,Bitmap img, Camera? cam = null, bool IsMainPlayer = false)
        {
            Graphics g = Graphics.FromImage(img);
            Type t = o.GetType();
            if (cam == null) cam = new Camera();
            Vector ScreenPos = ObjectOnScreen(o, cam);
            if (t == Core.AircraftType)
            {
                img = Core.RenderModel(o, ScreenPos, img, new Vector(Math.Abs(Math.Cos(Core.Radians(o.ZRotation))), 1));
                img = Core.RenderModel(o, ScreenPos, img, new Vector(-Math.Sin(Core.Radians(o.ZRotation)), 1), o.SubModel);
                //img = RenderObject(o.Radar, img, CameraPosition, CameraTeam);
            }
            else
            {
                img = Core.RenderModel(o, ScreenPos, img);
            }
            if (t == Core.AntiairType)
            {
                //img = Core.RenderModel(o.Radar, Core.MoveForward(ScreenPos, o.Rotation, -15), img);
                //img = Core.RenderModel(o.Gun, Core.MoveForward(ScreenPos, o.Rotation, 5), img);
                img = RenderObject(o.Radar, img, cam);
                img = RenderObject(o.Gun, img, cam);
            }
            if (t == Core.AirportType)
            {
                if (o.LandedAircraft != null)
                {
                    double a = 30 + o.LandedAircraft.Model.GetAvarageRadius();
                    Vector p = ObjectOnScreen(o.LandedAircraft, cam);
                    g.DrawEllipse(new Pen(Color.FromArgb(30, 255, 255, 255)), (float)(ScreenPos.X - o.Length / 2), (float)(ScreenPos.Y - o.Length / 2), (float)o.Length, (float)o.Length);
                }
            }
            if (t == Core.UmbrellaType)
            {
                img = Core.RenderModel(o.Radar, ObjectOnScreen(o.Radar, cam), img);
            }
            if (t == Core.RWSType)
            {
                int a = (int)(o.RenderSize);
                int p = 45;
                string text = "";
                Color baseColor = Color.FromArgb(255, 0, 170, 0);
                Rectangle pos = new Rectangle((int)Core.Screen.X - a - p, (int)Core.Screen.Y - a - p, a, a);
                Vector center = new Vector(pos.X, pos.Y) + new Vector(a / 2, a / 2);
                g.FillEllipse(new SolidBrush(Color.FromArgb(20, 0, 255, 0)), pos);
                g.DrawEllipse(new Pen(baseColor), pos);
                foreach (RWSPoint P in o.Points)
                {
                    text = "СПО: ПОИСК";
                    double d = P.Distance / o.DetectionRange;
                    double l = (a / 2) - 15;
                    g.DrawLine(new Pen(Color.FromArgb(120, 0, 200, 0), 3), Core.MoveForward(center.Copy(), P.Angle, 30).ToPoint(), Core.MoveForward(center.Copy(), P.Angle, 30+l*d).ToPoint());
                    g.FillPie(new SolidBrush(Color.FromArgb(10, 0, 200, 0)), pos, (float)Core.NormRotation(P.Angle)+90-10, 20);
                }
                if (o.Points.Count > 10) text =  Core.Sin(DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds*360*1.3) > 0 ? "СПО: ЗАХВАТ" : "";
                img = Core.PutText(img, text, new Vector(pos.X, pos.Y - 30), baseColor, 14);
                img = Core.RenderModel(new Aircraft(new Vector()) { Rotation = o.Rotation, Size = 2, Color = Color.FromArgb(255, 0, 150, 0) }, center, img, new Vector(0.8, 0.8));
            }
            if (t == Core.RadarType && IsMainPlayer)
            {
                int a = 230;
                int p = 45;
                Color baseColor = Color.FromArgb(255, 0, 170, 0);
                Rectangle pos = new Rectangle((int)Core.Screen.X - a - p, p, a, a);
                Rectangle ContentPos = new Rectangle(pos.X + 10, pos.Y + 10, pos.Width - 20, pos.Height - 20);
                Vector center = new Vector(pos.X, pos.Y) + new Vector(a / 2, a / 2);
                g.FillEllipse(new SolidBrush(Color.FromArgb(20, 0, 255, 0)), pos);
                g.DrawEllipse(new Pen(baseColor), pos);
                double r = a / 2;
                foreach (RadarPoint P in o.Points)
                {
                    double d = P.Distance / o.DetectRange;
                    
                    Color c = Color.FromArgb(30, 0, 255, 0);
                    Vector dPos = Core.MoveForward(center.Copy(), 180 + P.Rotation, 30 + (r - 40) * d);
                    if (P.Type == Core.MissileType)
                    {
                        Core.PutText(img, "РКТ", dPos, baseColor, 10);
                    }
                    g.FillEllipse(new SolidBrush(Color.FromArgb(70, 0, 255, 0)), (float)dPos.X-5, (float)dPos.Y-5, 10, 10);
                    g.FillPie(new SolidBrush(c), ContentPos, (float)Core.NormRotation(P.Rotation) + 180 + 90 - (float)o.DetectAngle / 2, (float)o.DetectAngle);
                }
                Core.PutText(img, "0", center-new Vector(5, 46), Color.FromArgb(70, 0,255,0), 8);
                g.DrawEllipse(new Pen(Color.FromArgb(100, 0, 255, 0)), ContentPos);
                g.DrawEllipse(new Pen(Color.FromArgb(100, 0, 255, 0)), new Rectangle((int)center.X - 30, (int)center.Y - 30, 60,60));
                g.DrawPie(new Pen(baseColor, 1), pos, (float)Core.NormRotation(o.Rotation) + 180 + 90 - (float)o.DetectAngle/2, (float)o.DetectAngle);
                g.FillPie(new SolidBrush(Color.FromArgb(20, 0, 255, 0)), pos, (float)Core.NormRotation(o.Rotation) + 180 + 90 - (float)o.DetectAngle / 2, (float)o.DetectAngle);
                Core.PutText(img, $"Макс. дист: {(int)o.DetectRange}, {(int)o.DetectAngle} гр.", center-new Vector(r, r+30), baseColor, 14);
            }
            if (ShowInfo && t != Core.SmokeType)
            {
                if (t == Core.UmbrellaType)
                {
                    img = Core.RenderRadarRange(img,o.Radar,ObjectOnScreen(o.Radar, cam), Color.FromArgb(100, 0, 0, 255));
                }
                if (t == Core.RWSType || (t == Core.RadarType && IsMainPlayer))
                {
                    return img;
                }
                if (t == Core.MissileType && o.Target != null)
                {
                    img = RenderObject(new MissileTarget(o.Target.Pos.Copy()), img, cam);
                    img = Core.RenderRadarRange(img, o.Radar, ScreenPos, Color.FromArgb(100, 0,0,255));
                }
                if (t == Core.RadarType) 
                {
                    img = Core.RenderRadarRange(img, o, ScreenPos, Color.FromArgb(100, 0, 255, 0));
                }
                if (t == Core.AntiairType)
                {
                    if (o.Target != null)
                    {
                        double a = 30 + o.Target.Model.GetAvarageRadius();
                        Vector p = ObjectOnScreen(o.Target, cam);
                        g.DrawRectangle(new Pen(Color.LightBlue), new Rectangle((int)(p.X-a), (int)(p.Y-a), (int)a*2, (int)a*2));
                    }
                }
                if (t == Core.AirportType)
                {
                    img = RenderObject(o.Radar, img, cam);
                    g.FillEllipse(new SolidBrush(Color.FromArgb(30,255,0,255)), (float)(ScreenPos.X-o.Length/2), (float)(ScreenPos.Y-o.Length/2),(float)o.Length,(float)o.Length);
                    if (o.LandedAircraft != null)
                    {
                        double a = 30 + o.LandedAircraft.Model.GetAvarageRadius();
                        Vector p = ObjectOnScreen(o.LandedAircraft, cam);
                        g.FillEllipse(new SolidBrush(Color.FromArgb(40, 0, 255, 0)), new Rectangle((int)(p.X - a), (int)(p.Y - a), (int)a * 2, (int)a * 2));
                    }
                }
                double Yoff = o.Model.GetAvarageRadius() + 10 + o.Size;
                double Xoff = 20;
                if (o.Speed != 0) img = Core.PutText(img, $"Speed: {Math.Round(o.Speed, 1)}", new Vector(ScreenPos.X - Xoff, ScreenPos.Y - Yoff), Color.FromArgb(100, 0, 0, 255));
                img = Core.PutText(img, o.Name, new Vector(ScreenPos.X - Xoff, ScreenPos.Y - Yoff - 40), Color.FromArgb(100, 255, 0, 255));
                img = Core.PutText(img, $"{(int)o.Temperature} C", new Vector(ScreenPos.X - Xoff, ScreenPos.Y - Yoff - 20), Color.DarkOrange);
                img = Core.PutText(img, $"{Math.Round(o.GetOverload(),1)} G", new Vector(ScreenPos.X - Xoff, ScreenPos.Y - Yoff - 60), Color.Magenta);
                g.DrawLine(new Pen(Color.FromArgb(255, 255, 0, 255)), ScreenPos.ToPoint(), Core.MoveForward(ScreenPos.Copy(), o.Rotation, -(100 + o.Speed)).ToPoint());
            }
            return img;
        }
        public Bitmap Render(Camera cam = null, bool IsMainPlayer = false)
        {

            Bitmap img  = new Bitmap((int)Core.Screen.X, (int)Core.Screen.Y);

            //Graphics g = Graphics.FromImage(img);
            double RenderRange = 5000;
            if (cam == null)
            {
                cam = new Camera();
            }
            foreach (dynamic o in Objects)
            {
                Vector ScreenPos = cam.Pos - o.Pos + Core.Screen / 2;
                if (ScreenPos.X > -RenderRange && ScreenPos.X < Core.Screen.X + RenderRange && ScreenPos.Y > -RenderRange && ScreenPos.Y < Core.Screen.Y+ RenderRange)
                {
                    img = RenderObject(o, img, cam, IsMainPlayer);
                }
            }
            return img;
        }
    }
    public class MissileTarget : ObjectBase
    {
        public MissileTarget(Vector pos) : base(pos)
        {
            Pos = pos;
            double a = 10;
            Model = new Model(new List<Vector> { 
                new Vector(a, a),
                new Vector(a, -a),
                new Vector(-a, -a),
                new Vector(-a, a),
            });
            Color = Color.FromArgb(100, 0, 255, 0);
        }
        public override void Update()
        {
            MyWorld.Delete(this);
        }
        public new void Destroy()
        {
            MyWorld.Delete(this);
        }
    }
    public class Radar : ObjectBase
    {
        public double RotationSpeed,
            DetectRange,
            DetectAngle,
            PingDelay;
        public Model Model = new Model(new List<Vector> {
            new Vector(-5,3),
            new Vector(),
            new Vector(5,3)
        });
        bool Scanning = true;
        DateTime LastPingTime  = DateTime.Now;
        ObjectBase Target = new ObjectBase(new Vector());
        public double MinTemperature = 50;
        public List<RadarPoint> Points = new List<RadarPoint>();
        public double PointsLifeTime = 1;
        public Radar(Vector pos, double rotationSpeed = 10, double detectRange = 8000, double detectAngle = 50, double pingDelay = 0.1) : base(pos)
        {
            RotationSpeed = rotationSpeed;
            DetectRange = detectRange;
            DetectAngle = detectAngle;
            PingDelay = pingDelay;
            Size = 2;
            Color = Color.FromArgb(255, 200, 255, 200);
            IsRadio = true;
            Name = "Radar";
            PointsLifeTime = 360 / rotationSpeed;
        }
        public bool CanPing()
        {
            return DateTime.Now.Subtract(LastPingTime).TotalSeconds >= PingDelay;
        }
        public dynamic SelectMethod(List<dynamic> objects)
        {
            return objects.MinBy(x => x.Pos.DistanceTo(Pos) / (IsRadio ? 1 : x.Temperature));
        }
        public dynamic SelectRadioMethod(List<dynamic> objects)
        {
            return objects.MinBy(x => x.Pos.DistanceTo(Pos) / (IsRadio ? x.Model.GetAvarageRadius() : 1));
        }
        public new Radar Copy()
        {
            Radar r = new Radar(Pos.Copy());
            r.Name = Name;
            r.Rotation = Rotation;
            r.RotationSpeed = RotationSpeed;
            r.DetectRange = DetectRange;
            r.DetectAngle = DetectAngle;
            r.Model = Model.Copy();
            r.Scanning = Scanning;
            r.Color = Core.CopyColor(Color);
            r.PingDelay = PingDelay;
            r.IsRadio = IsRadio;
            return r;
        }
        public dynamic? Ping(List<Type>? NegativeFilter = null)
        {
            List<dynamic> DetectedObjects = new List<dynamic>();
            LastPingTime = DateTime.Now;
            foreach (dynamic o in MyWorld.Objects)
            {
                if (Core.IsObjectInRadar(o, this) && Pos.DistanceTo(o.Pos) >= 40 && !o.Grounded)
                {
                    if (o.GetType() != Core.SmokeType && o.GetType() != Core.BulletType)
                    {
                        //Debug.WriteLine($"{o} {o.IsRadio} {IsRadio}");
                        if ((o.IsRadio && IsRadio && o.Speed > 2) || !IsRadio)
                        {   
                            if (o.Temperature >= MinTemperature || IsRadio)
                            {
                                if (Team != o.Team || !IsRadio)
                                {
                                    if (o.GetType() != Core.MissileType || o.Radar != this)
                                    {
                                        DetectedObjects.Add(o);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (DetectedObjects.Count > 0)
            {
                dynamic o;
                if (!IsRadio) o = SelectMethod(DetectedObjects);
                else o = SelectRadioMethod(DetectedObjects);
                if (IsRadio) o.OnPing(this);
                Points.Add(new RadarPoint(Pos.DistanceTo(o.Pos), Rotation, o.GetType(), o.Pos, o.Speed));
                return o;
            }
            else
            {
                return null;
            }
        }
        public new void Update()
        {
            List<RadarPoint> NewList = new List<RadarPoint>();
            for (int i = 0; i < Points.Count; i++)
            {
                RadarPoint p = Points[i];
                if (DateTime.Now.Subtract(p.InitTime).TotalSeconds >= PointsLifeTime)
                {
                    continue;
                }
                NewList.Add(p);
            }
            Points = NewList;
            Rotation += RotationSpeed * MyWorld.DeltaTime;
            NormRotation();
        }
        public Bitmap Render(Bitmap img) => Core.RenderModel(this, Pos, img);
    }
    public class Gun : ObjectBase
    {
        public List<Missile> Ammo = new List<Missile> { Core.Aim9L, Core.Aim120A,  };
        public int AmmoCount = 10;
        public int MaxAmmoCount = 10;
        public double ReloadTime = 5;
        public DateTime LastRealodTime = DateTime.Now;
        public Missile? LastMissile = null;
        public int SelectedAmmo = 0;
        public bool Blocked = false;
        
        public Gun(Vector pos) : base(pos)
        {
            Pos = pos;
            Model = new Model(new List<Vector>
            {
                new Vector(0,-5),
                new Vector(0,15)
            });
            Color = Color.DarkGreen;
            Name = "Gun";
            Size = 5;
        }
        public void Shoot()
        {
            if (DateTime.Now.Subtract(LastRealodTime).TotalSeconds >= ReloadTime && AmmoCount > 0 && !Blocked)
            {
                LastRealodTime = DateTime.Now;
                Missile NewMissile = new Missile(Pos.Copy());
                NewMissile.CopyFrom(Ammo[SelectedAmmo]);
                NewMissile.Speed = Speed;
                NewMissile.Rotation = Rotation;
                NewMissile.Pos = Pos.Copy();
                NewMissile.Team = Team;
                MyWorld.InstantiateObject(NewMissile);
                LastMissile = NewMissile;
                AmmoCount -= 1;
            }
        }
        public override void Update()
        {
            if (LastMissile != null)
            {
                if (LastMissile.Detonated || LastMissile.Destroyed || !MyWorld.Objects.Contains(LastMissile))
                {
                    LastMissile = null;
                }
            }
        }
    }
    public class BulletGun : ObjectBase
    {
        public double Spread = 5;
        public double BulletStartSpeed = 50;
        public bool Blocked = false;
        public int MaxAmmoCount = 300;
        public int AmmoCount = 300;
        public double Delay = 0.05;
        public DateTime LastShootTime;
        public double Caliber = 12;
        public BulletGun(Vector? pos = null, double caliber = 12)
        {
            Pos = pos == null ? new Vector(0, 0) : pos;
            LastShootTime = DateTime.Now;
            Model = new Model(new List<Vector>
            {
                new Vector(0,-5),
                new Vector(0,15)
            });
            Color = Color.FromArgb(255, 100, 100, 100);
            Caliber = caliber;
        }
        public void Shoot()
        {
            if (AmmoCount > 0 && DateTime.Now.Subtract(LastShootTime).TotalSeconds >= Delay && !Blocked)
            {
                AmmoCount -= 1;
                MyWorld.InstantiateObject(new Bullet(Pos.Copy(), Speed + BulletStartSpeed, Caliber, Delay > 0.02 && Caliber >= 5) { Rotation = Rotation + Core.Random.NextDouble()*Spread*Core.Random.Next(-1,1), MyWorld = MyWorld, Grounded = Grounded });
                LastShootTime = DateTime.Now;
                
            }
        }
    }
    public class Bullet : ObjectBase
    {
        public double AirResistrance = 0.002;
        public double LifeTime = 10;
        public double SmokingTime = 0.2;
        public DateTime? InitTime = null;
        public double Caliber = 12;
        public bool DoSmoke = true;
        public double StartSpeed { get; }
        public Bullet(Vector? pos = null, double StartSpeed = 50, double caliber = 12, bool doSmoke = true)
        {
            Pos = pos == null ? new Vector() : pos;
            Speed = StartSpeed;
            Color = Color.FromArgb(247, 242, 77);
            Model = new Model(new List<Vector> { new Vector(0, -5), new Vector(0, 5) });
            Name = "Пуля";
            Caliber = caliber >= 3 ? caliber : 3;
            Model *= (Caliber / 12);
            this.StartSpeed = StartSpeed;
            DoSmoke = doSmoke;
        }
        public new void Destroy()
        {
            MyWorld.Delete(this);
        } 
        public override void Update()
        {
            if (InitTime == null) InitTime = DateTime.Now;
            CleverMove();
            Speed *= 1 - AirResistrance;
            double t = DateTime.Now.Subtract((DateTime)InitTime).TotalSeconds;
            if (t >= LifeTime) Destroy();
            if (t < SmokingTime && DoSmoke)
            {
                MyWorld.InstantiateObject(new Smoke(Core.MoveForward(Pos.Copy(), Rotation, -10), 8 * ((SmokingTime-t)/SmokingTime), 0.4));
            }
            for (int i = 0; i < MyWorld.Objects.Count; i++)
            {
                dynamic o = MyWorld.Objects[i];
                if (Pos.DistanceTo(o.Pos) < o.Model.GetAvarageRadius()+Model.GetAvarageRadius()*2 && !new List<Type> { Core.BulletType, Core.ThermalTrapType, Core.SmokeType }.Contains(o.GetType()) && o.Grounded == Grounded)
                {
                    o.OnBulletHit(this);
                    Destroy();
                } 
            }
        }
    }
    public class Model
    {
        public List<Vector> Points = new List<Vector>();
        public Model(List<Vector> Points)
        {
            this.Points = Points;
        }
        public static Model operator *(Model a, double b)
        {
            for (int i = 0; i < a.Points.Count; i++)
            {
                a.Points[i].X *= b;
                a.Points[i].Y *= b;
            }
            return a;
        }
        public double GetAvarageRadius()
        {
            double r = 0;
            foreach (Vector v in Points)
            {
                r += new Vector().DistanceTo(v);
            }
            return r / Points.Count;
        }
        public void Move(Vector v)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] += v;
            }
        }
        public void MirrorX()
        {
            for (int i = Points.Count-1; i >= 0; i--)
            {
                Vector p = Points[i];
                Points.Add(new Vector(-p.X, p.Y));
            }
        }
        public void RemovePointsInRadius(Vector pos, double r)
        {
            List<Vector> newPoints = new List<Vector>();
            foreach(Vector p in Points)
            {
                if (p.DistanceTo(pos) > r)
                {
                    newPoints.Add(p);
                }
            }
            Points = newPoints;
        }
        public Model Copy()
        {
            List<Vector> newPoints = new List<Vector> ();
            for (int i = 0; i<Points.Count; i++)
            {
                newPoints.Add(Points[i].Copy());
            }
            return new Model(newPoints);
        }
    }
    public class RWSPoint
    {
        public DateTime InitTime { get; }
        public double Angle = 0;
        public double Distance = 0;
        public RWSPoint(double distance = 0, double angle = 0)
        {
            InitTime = DateTime.Now;
            Angle = angle;
            Distance = distance; 
        }
    }
    public class RWS : ObjectBase
    {
        public double DetectionRange = 50000;
        public List<RWSPoint> Points = new List<RWSPoint>();
        public double PointLifeTime = 1;
        public double RenderSize = 230;
        public RWS(Vector? pos = null, double DetectionRange = 50000) : base(pos)
        {
            this.DetectionRange = DetectionRange; 
            Model = new Model(new List<Vector>());
            Name = "СПО";
        }
        public void OnPing(Radar? r = null)
        {
            if (r != null && r.Team != Team && Points.Count < 30)
            {
                Points.Add(new RWSPoint(r.Pos.DistanceTo(Pos), 180+Core.NormRotation(Pos.AngleTo(r.Pos))));
            }
        }
        public override void Update()
        {
            NormRotation();
            for (int i = 0; i < Points.Count; i++)
            {
                RWSPoint p = Points[i];
                if (DateTime.Now.Subtract(p.InitTime).TotalSeconds >= PointLifeTime)
                {
                    Points.Remove(p);
                }
            }
        }
    }
    public class RadarPoint
    {

        public Vector Pos;
        public double Distance;
        public double Rotation;
        public Type Type;
        public DateTime InitTime;
        public double Speed;
        public RadarPoint(double distance = 0, double rotation = 0, Type? type = null, Vector? Pos=null, double speed=0)
        {
            this.Pos = Pos == null ? new Vector() : Pos;
            Distance = distance;
            Rotation = rotation;
            Type = type == null? Core.AircraftType : type;
            InitTime = DateTime.Now;
            Speed = speed;
        }
    }
    public class Aircraft : ObjectBase
    {
        public bool CanTurn = true;
        public RadarPoint? AITarget = null;
        public double? AIRotationTarget = null;
        public double AISpeedTarget = 12;
        public bool EnableAI;
        public Radar Radar;
        public double TrapsDelay = 0.5;
        public double TrapsCount = 60;
        public double MaxTrapsCount = 60;
        DateTime LastTrapsTime = DateTime.Now;
        public int DoTrapsCount = 2;
        public Gun Gun;
        public BulletGun BulletGun;
        public RWS RWS;
        public double ZRotation = 0;
        double LastRotation = 0;
        public double IncreaseSpeedValue = 0.03;
        public Model Model = new Model(new List<Vector> { 
            new Vector(0, -50),
            new Vector( 10, -55),
            new Vector( 12, -50),
            new Vector( 4, -45),
            new Vector( 4, -25),
            new Vector( 30, -35),
            new Vector( 25, -25),
            new Vector( 4, -5),
            new Vector( 4, 5),
            new Vector( 0, 15),
            new Vector( 0, 15),
        });
        public Model SubModel = new Model(new List<Vector> {
            new Vector(0, 15),
            new Vector(10 , 5),
            new Vector(2 , -25),
            new Vector(2 , -30),
            new Vector(15 , -55),
            new Vector(0 , -50),
        });
        public double MinSpeed = 3;
        public double MaxSpeed = 20;
        public double PilotStamina = 100;
        public DateTime LastCriticalOverloadTime = DateTime.MinValue;
        public Aircraft(Vector pos, double speed = 1, double rotation = 0, double rotationSpeed = 1) : base(pos)
        {
            Pos = pos;
            Speed = speed;
            Rotation = rotation;
            Size = 2;
            Radar = new Radar(Pos, 270, 28000,10, 0);
            Radar.MyWorld = MyWorld;
            Radar.Model = new Model(new List<Vector>());
            Gun = new Gun(Pos);
            Gun.Team = Team;
            Gun.ReloadTime = 0.3;
            Gun.AmmoCount = 8;
            Gun.MaxAmmoCount = 8;
            BulletGun = new BulletGun(Pos, 20);
            BulletGun.Team = Team;

            Radar.Team = Team;
            Name = "Aircraft";
            IsRadio = true;
            Model.MirrorX();
            Model.Move(new Vector(0, 25));
            SubModel.Move(new Vector(0, 25));
            Temperature = 70;
            RWS = new RWS(Pos);
            EnableAI = true;
            MaxRotationSpeed = 50;
            DestructableModules.AddRange(new List<string> { "LeftWing", "RightWing", "Back", "FuelTank" });
        }
        public void DoTraps()
        {
            double a = 60;
            if (DateTime.Now.Subtract(LastTrapsTime).TotalSeconds > TrapsDelay)
            {
                LastTrapsTime = DateTime.Now;
                for (int i = 0; i < DoTrapsCount; i++)
                {
                    if (TrapsCount > 0)
                    {
                        if (i == (int)(DoTrapsCount / 2))
                        {
                            a = -60;
                        }
                        MyWorld.InstantiateObject(new ThermalTrap(Pos.Copy()) { Rotation = a + Rotation + Core.Random.Next(-10, 10) });
                        a += a > 0 ? 20 : -20;
                        TrapsCount -= 1;
                    }
                }
            }
        }
        public new void Destroy()
        {
            Core.DestroyModeleffect(this);
            MyWorld.Delete(this);

        }
        public override void OnPing(Radar? r = null)
        {
            RWS.OnPing(r);
        }
        public override void OnBulletHit(Bullet b)
        {
            if (!IsBulletPenetrated(b)) return;
            double r = Model.GetAvarageRadius();
            Vector LeftWingPos = Core.MoveForward(Pos.Copy(), Rotation-90, r);
            Vector RightWingPos = Core.MoveForward(Pos.Copy(), Rotation + 90, r);
            Vector BackPos = Core.MoveForward(Pos.Copy(), Rotation + 180, r);
            Vector FuelTankPos = Core.MoveForward(Pos.Copy(), Rotation + 180, r * 0.66);
            
            bool hit = false;
            if (LeftWingPos.DistanceTo(b.Pos) <= b.Model.GetAvarageRadius()+ 14 && DestructableModules.Contains("LeftWing"))
            {

                DestructableModules.Remove("LeftWing");
                Model.RemovePointsInRadius(Core.MoveForward(new Vector(), -90, r), 20);
                MyWorld.InstantiateObject(new ThermalTrap(LeftWingPos, Speed));
                hit = true;
            }
            if (RightWingPos.DistanceTo(b.Pos) <= b.Model.GetAvarageRadius() + 14 && DestructableModules.Contains("RightWing"))
            {
                DestructableModules.Remove("RightWing");
                Model.RemovePointsInRadius(Core.MoveForward(new Vector(), 90, r), 20);
                MyWorld.InstantiateObject(new ThermalTrap(RightWingPos, Speed));
                hit = true;
            }
            if (BackPos.DistanceTo(b.Pos) <= b.Model.GetAvarageRadius() + 14 && DestructableModules.Contains("Back"))
            {
                DestructableModules.Remove("Back");
                Model.RemovePointsInRadius(Core.MoveForward(new Vector(), 180, r), 20);
                MyWorld.InstantiateObject(new ThermalTrap(BackPos, Speed));
                hit = true;
            }
            if (FuelTankPos.DistanceTo(b.Pos) <= b.Model.GetAvarageRadius() + 9 && DestructableModules.Contains("FuelTank"))
            {
                DestructableModules.Remove("FuelTank");
                if (Core.Random.Next(0,2) == 0) MyWorld.InstantiateObject(new Explosion(BackPos, 14));
                MaxSpeed *= 0.6;
                if (Speed > MaxSpeed) Speed = MaxSpeed;
                IncreaseSpeedValue /= 3;
                hit = true;
            }

            if (!hit)
            {
                Destroy();
            }
        }
        public override void Update10S()
        {
            RWS.Team = Team;
        }
        public void TurnLeft()
        {
            if (CanTurn) RotationSpeed -= IncreaseRotationSpeedValue * ((PilotStamina > 50 ? PilotStamina : 50) / 100) * (MaxOverload - GetOverload()) / MaxOverload;
        }
        public void TurnRight()
        {
            if (CanTurn) RotationSpeed += IncreaseRotationSpeedValue * ((PilotStamina > 50 ? PilotStamina : 50) / 100) * (MaxOverload - GetOverload()) / MaxOverload;
        }
        public void UpdateAI()
        {
            foreach (RadarPoint p in Radar.Points)
            {
                if (p.Type == Core.MissileType && p.Distance <= 800)
                {
                    DoTraps();
                }
                if (AITarget == null && p.Type == Core.AircraftType && p.Distance < 5000)
                {
                    AITarget = p;
                }
            }
            if (AITarget != null)
            {
                Radar.Rotation = Pos.AngleTo(AITarget.Pos);
                if (Radar.CanPing())
                {
                    dynamic? o = Radar.Ping();
                    AITarget = o != null && o.GetType() == Core.AircraftType? new RadarPoint(Pos.DistanceTo(o.Pos),Pos.AngleTo(o.Pos),o.GetType(),o.Pos, o.Speed) : AITarget;
                }
                AIRotationTarget = Pos.AngleTo(AITarget.Pos);
                if (AITarget.Speed+1 < MaxSpeed)
                {
                    AISpeedTarget = AITarget.Speed + 1;
                }
            }
            if (AIRotationTarget != null)
            {
                if (Rotation < AIRotationTarget)
                {
                    TurnRight();
                }
                else
                {
                    TurnLeft();
                }
                if (Math.Abs(Rotation - (double)AIRotationTarget) < RotationSpeed*2)
                {
                    AIRotationTarget = null;
                    if (AITarget != null && (Gun.LastMissile == null || Gun.LastMissile.Pos.DistanceTo(Pos) > AITarget.Pos.DistanceTo(Pos)*1.3))
                    {
                        if (AITarget.Pos.DistanceTo(Pos) < 800) 
                        {
                            BulletGun.Shoot();
                        }
                        else
                        {
                            Gun.Shoot();
                        }
                    }
                    //AITarget = null;
                }
            }
            if (Speed < AISpeedTarget) Speed += IncreaseSpeedValue;
            else if (Speed > AISpeedTarget) Speed -= IncreaseSpeedValue;
            if (Math.Abs(Speed - AISpeedTarget) <= IncreaseSpeedValue * 1.5) Speed = AISpeedTarget;
        }
        public override void Update()
        {
            base.Update();
            Temperature = 1200 * (0.05 + Speed / MaxSpeed);
            Radar.Pos = Pos.Copy();
            Radar.MyWorld = MyWorld;
            Radar.Grounded = Grounded;
            Radar.Update();
            Gun.Blocked = Grounded;
            Gun.Pos = Pos.Copy();
            Gun.Rotation = Rotation;
            Gun.Speed = Speed;
            Gun.MyWorld = MyWorld;
            Gun.Update();
            BulletGun.Blocked = Grounded;
            BulletGun.Pos = Core.MoveForward(Pos.Copy(), Rotation, Model.GetAvarageRadius() + 10);
            BulletGun.Rotation = Rotation;
            BulletGun.Speed = Speed;
            BulletGun.MyWorld = MyWorld;
            RWS.Pos = Pos;
            RWS.Rotation = Rotation;
            RWS.Update();
            if (Radar.CanPing() && (AITarget == null || EnableAI == false))
            {
                Radar.Ping();
            }
            if (Speed > 1) MyWorld.InstantiateObject(new Smoke(
                        Core.MoveForward(
                            Pos.Copy(), Rotation - 180, 20 + Speed * 2
                        ),
                        Core.Random.Next(10, 20)
                    ));
            if (Speed >= MaxSpeed * 0.9)
            {

            }
            if (Speed > MaxSpeed * 1.2 || GetOverload() > MaxOverload)
            {
                Destroy();
            }
            if (Speed < MinSpeed)
            {
                Speed = MinSpeed;
            }
            double m = Math.Abs(Math.Sin(Core.Radians(ZRotation)));

            if (Rotation > LastRotation && !Grounded && Speed > 2) ZRotation += (1 + (ZRotation < 0 ? m * 2 : 0));
            else if (Rotation < LastRotation && !Grounded && Speed > 2) ZRotation -= (1 + (ZRotation > 0 ? m * 2 : 0));
            else
            {
                if (ZRotation > 0) ZRotation -= 0.5;
                else ZRotation += 0.5;
            }
            if (RotationSpeed > 0) RotationSpeed -= 0.5;
            if (RotationSpeed < 0) RotationSpeed += 0.5;
            if (Math.Abs(RotationSpeed) < 0.5) RotationSpeed = 0;
            if (!Grounded) ZRotation = 70 * (RotationSpeed / MaxRotationSpeed);
            LastRotation = Rotation;
            if (!DestructableModules.Contains("LeftWing")) RotationSpeed += 1 * GetOverload() / 2;
            if (!DestructableModules.Contains("RightWing")) RotationSpeed -= 1 * GetOverload() / 2;
            if (!DestructableModules.Contains("LeftWing") && !DestructableModules.Contains("RightWing"))
            {
                IncreaseRotationSpeedValue = 0;
                IncreaseSpeedValue = 0;
                MinSpeed = 0;
                if (Model.GetAvarageRadius() > 14)
                {
                    Model *= 0.99;
                    SubModel *= 0.99;
                }
                else
                {
                    Destroy();
                }
                Speed -= 0.04;
            }
            if (!DestructableModules.Contains("Back")) IncreaseRotationSpeedValue = 1.2;
            if (!DestructableModules.Contains("FuelTank")) 
            {
                MyWorld.InstantiateObject(new Smoke(
                        Core.MoveForward(
                            Pos.Copy() + Core.RandomVector(4), Rotation - 180, 5 + Speed * 1.4
                        ),
                        Core.Random.Next(16, 25), 0.7,
                        Color.FromArgb(200, 255, 160, 18)
                   ));
            }
            if (EnableAI)
            {
                UpdateAI();
            }
            if (GetOverload() < 4) PilotStamina += 0.4 + (DateTime.Now.Subtract(LastCriticalOverloadTime).TotalSeconds > 2? 0.6 * (PilotStamina / 100) : 0);
            else LastCriticalOverloadTime = DateTime.Now;

            PilotStamina -= GetOverload()/13/Math.PI;
            if (PilotStamina > 100) PilotStamina = 100;
            if (PilotStamina  < 0) PilotStamina = 0;
            if (PilotStamina < 10) CanTurn = false;
            if (!CanTurn && PilotStamina > 30) CanTurn = true;
        }
        public Bitmap Render(Bitmap img)
        {
            img = Core.RenderModel(this, Pos, img);
            return img;
        }
    }
    public class Missile : ObjectBase
    {
        public double
            IncreaseSpeedValue = 1,
            MaxSpeed = 50,
            RadioFuseDistance = 20,
            ExplosionRadius = 50,
            DetonationTime = 120,
            maxRadarRotationAngle = 50,
            AfterburnIncreaseSpeedValue = 3,
            AfterburnAddSpeed = 1,
            AfterburnerTime = 0.5;
        public bool
            Afterburned = false,
            Detonated = false;
        public Radar Radar;
        public DateTime LaunchTime = DateTime.Now;
        public ObjectBase? Target = null;
        ObjectBase? OriginalTarget = null;

        public Missile(Vector pos = null) : base(pos)
        {
            Model = new Model(new List<Vector> {
                new Vector(0,5),
                new Vector(0,20),
            });
            Color = Color.Red;
            Size = 4;
            IsRadio = true;
            Radar = new Radar(Pos, 0, 9000, 60, 0);
            Radar.IsRadio = false;
            Radar.MyWorld = MyWorld;
            Target = null;
            Name = "Missile";
            LaunchTime = DateTime.Now;
            
            
        }
        public void CopyFrom(Missile m)
        {
            Color = Core.CopyColor(m.Color);
            Size = m.Size;
            IsRadio = m.IsRadio;
            Radar = m.Radar.Copy();
            Radar.Pos = Pos;
            Name = m.Name;

            IncreaseSpeedValue = m.IncreaseSpeedValue;
            MaxSpeed = m.MaxSpeed;
            RadioFuseDistance = m.RadioFuseDistance;
            ExplosionRadius = m.ExplosionRadius;
            DetonationTime = m.DetonationTime;
            maxRadarRotationAngle = m.maxRadarRotationAngle;
            AfterburnIncreaseSpeedValue = m.AfterburnIncreaseSpeedValue;
            AfterburnAddSpeed = m.AfterburnAddSpeed;
            AfterburnerTime = m.AfterburnerTime;
            IncreaseRotationSpeedValue = m.IncreaseRotationSpeedValue;
            MaxRotationSpeed = m.MaxRotationSpeed;

        }
        public new void Destroy()
        {
            Destroyed = true;
            Core.DestroyModeleffect(this);
            MyWorld.Delete(this);
        }
        public void Detonate()
        {

            if (!Detonated)
            {
                Detonated = true;
                MyWorld.InstantiateObject(new Explosion(this));
                Destroy();
            }

        }
        private void Afterburn()
        {
            MyWorld.InstantiateObject(new Smoke(Pos.Copy(), 30, 0.2, Color.FromArgb(170, 255,255,255), false));
            Speed += AfterburnAddSpeed;
            IncreaseSpeedValue = AfterburnIncreaseSpeedValue;

        }
        public override void Update()
        {
            Temperature = 1200 * (0.05 + Speed / MaxSpeed);
            NormRotation();
            base.Update();
            if (Target == null)
            {
                Target = new ObjectBase(Core.MoveForward(Pos.Copy(), Rotation, 300));
                Target.Speed = 0;
                
            }
            Radar.Pos = Pos;
            Radar.MyWorld = MyWorld;
            
            MyWorld.InstantiateObject(new Smoke(Pos.Copy(), Core.Random.Next(5,15)));
            if (DateTime.Now.Subtract(LaunchTime).TotalSeconds >= DetonationTime || (Pos.DistanceTo(Target.Pos) <= RadioFuseDistance && Afterburned && Target.IsRadio))
            {
                Detonate();
            }
            if (DateTime.Now.Subtract(LaunchTime).TotalSeconds >= AfterburnerTime && !Afterburned)
            {
                Afterburned = true;
                Afterburn();
            }

            double TargetAngle = Pos.AngleTo(Target.Pos);
            Speed += IncreaseSpeedValue * MyWorld.DeltaTime;

            if (Afterburned)
            {

                if (Rotation > TargetAngle)
                {
                    Rotation -= IncreaseRotationSpeedValue;
                }
                if (Rotation < TargetAngle)
                {
                    Rotation += IncreaseRotationSpeedValue;
                }


            }
            if (Radar.CanPing())
            {
                ObjectBase NewTarget = Radar.Ping();
                Target = NewTarget;
                if (NewTarget != null) 
                {
                    Target = Target.Copy();
                    Radar.Rotation = Rotation;
                    double d = Target.Pos.DistanceTo(Pos);
                    Radar.Rotation = Rotation;
                    double a = Core.NormRotation(Pos.AngleTo(Target.Pos));
                    Radar.Rotation = Rotation;


                    if (a-Rotation <= maxRadarRotationAngle)
                    {
                        Radar.Rotation = a;
                    }
                    OriginalTarget = Target;
                    OriginalTarget.Pos = Target.Pos.Copy();

                    Target.Pos = Core.MoveForward(Target.Pos, Target.Rotation, d * (1+Radar.PingDelay) * Math.Abs(Core.Cos(RotationSpeed) * Target.GetCleverSpeed())/GetCleverSpeed() );
                }
                else
                {
                    Radar.Rotation = Rotation;
                }
                
            }
            if (Speed > MaxSpeed)
            {
                Speed = MaxSpeed;
            }
        }
    }
    public class Explosion : ObjectBase 
    {
        public double Radius=10;
        public Explosion(Missile m) : base(m.Pos) 
        {
            Radius = m.ExplosionRadius;
            Pos = m.Pos;
        }
        public Explosion(Vector Pos, double radius = 10) : base(Pos)
        {
            Radius = radius;
        }
        public new void Destroy()
        {
            MyWorld.Delete(this);
        }
        public override void Update()
        {
            for (int i = 0; i < MyWorld.Objects.Count; i++) 
            { 
                dynamic o = MyWorld.Objects[i];
                if (o.Pos.DistanceTo(Pos) < Radius && Grounded == o.Grounded)
                {
                    o.Destroy();
                    MyWorld.Delete(o);
                }
            }
            MyWorld.InstantiateObject(new Smoke(Pos, Radius, 0.2, null, false));
            MyWorld.Delete(this);
        }
    }
    public class ThermalTrap : ObjectBase
    {
        DateTime InitTime = DateTime.Now;
        public double LifeTime = 7;
        public ThermalTrap(Vector pos, double StartSpeed = 6) : base(pos)
        {
            Pos = pos;
            Speed = StartSpeed;
            InitTime = DateTime.Now;
            Model = new Model(new List<Vector> { new Vector() });
            Color = Color.Orange;
            Size = 8;
            Name = "Flare";
            IsRadio = false;
            Temperature = 600;

        }
        public new void Destroy()
        {
            MyWorld.Delete(this);
        }
        public override void Update()
        {
            IsRadio = false;
            CleverMove();
            Temperature -= 3;
            Rotation += Core.Random.Next(-50, 50) / 10;
            if (Temperature < 60)
            {
                Temperature = 60;
            }
            Speed *= 0.92;
            if (Speed < 0.2) Speed = 0.2;
            if (DateTime.Now.Subtract(InitTime).TotalSeconds >= LifeTime )
            {
                MyWorld.Delete(this);
            }
            MyWorld.InstantiateObject(new Smoke(Pos.Copy()+ Core.RandomVector(5), Core.Random.Next(5,12), 0.2, Color.FromArgb(70, 255,200,200)));
        }
    }
    public class Antiair : ObjectBase
    {
        public dynamic Gun;
        public Radar Radar;
        public dynamic? Target = null;
        public double MaxSpeed = 4;
        public double IncreaseSpeedValue = 0.2;
        public bool EnableAI = true;
        bool Gased = false;
        Base? SelectedBase = null;
        public Type TypeGun { get; }
        public Antiair(Vector? pos = null, string TypeGun = "RocketLauncher") : base(pos)
        {
            Radar = new Radar(Pos, 360, 50000, 10, 0)
            {
                Team = this.Team,
            };
            if (TypeGun == "BulletGun")
            {
                Gun = new BulletGun(Pos, 7.62);
                Gun.Delay = 0.1;
                Radar.DetectRange = 4000;
                Gun.Spread = 4;
                Gun.Caliber = 12;
            }
            else
            {
                Gun = new Gun(Pos);
                Gun.Ammo = new List<Missile>
                {
                    Core.m_9M37,
                    Core.m_9M335,
                    Core.Tor_M1,
                    Core.Helmet1,
                    Core.Helmet2,
                };
            }

            this.TypeGun = this.Gun.GetType();

            Color = Color.DarkGreen;

            Model = new Model(new List<Vector>
            {
                new Vector(15,30),
                new Vector(15,-30),
                new Vector(-15,-30),
                new Vector(-15,30),
            });
            Name = "Antiair";
            Grounded = true;
        }
        public void AISelectAmmo(double distance)
        {
            if (distance <= 400)
            {
                Gun.SelectedAmmo = 4;
            }
            else if (distance <= 5700)
            {
                Gun.SelectedAmmo = 0;
            }
            else if (distance <= 18600)
            {
                Gun.SelectedAmmo = 1;
            }
            else if (distance > 18600)
            {
                Gun.SelectedAmmo = 2;
            }
        }
        public void Gas()
        {
            Speed += IncreaseSpeedValue*MyWorld.DeltaTime*60;
            if (Speed > MaxSpeed) Speed = MaxSpeed;
            Gased = true;
        }
        public override void Update()
        {
            CleverMove();
            Gased = false;
            Radar.Pos = Core.MoveForward(Pos, Rotation, -15);
            Gun.Pos = Core.MoveForward(Pos, Rotation+30, 12);
            Gun.MyWorld = MyWorld;
            Gun.Team = Team;
            Radar.MyWorld = MyWorld;
            Radar.Team = Team;
            Radar.Update();
            Gun.Update();
            Gun.Grounded = false;
            if (!EnableAI && Radar.CanPing()) Radar.Ping(new List<Type> { this.GetType() });
            if (Target == null && EnableAI)
            {
                if (Radar.CanPing())
                {
                    Target = Radar.Ping(new List<Type> { this.GetType() });

                    if (Target != null && !(Target.GetType() == Core.MissileType && Math.Abs(Target.Rotation - Target.Pos.AngleTo(Pos)) > 40))
                    {
                        Gun.Rotation = Pos.AngleTo(Target.Pos);
                        if (TypeGun == Core.GunType && Gun.LastMissile == null)
                        {
                            if (Target.GetType() == Core.MissileType)
                            {
                                double d = Pos.DistanceTo(Target.Pos);
                                if (d <= Core.Helmet2.Radar.DetectRange) Gun.SelectedAmmo = 4;
                                else if (d <= Core.Helmet1.Radar.DetectRange) Gun.SelectedAmmo = 3;
                                else Target = null;

                            }
                            else AISelectAmmo(Pos.DistanceTo(Target.Pos));
                            if (Target != null)
                            {
                                Gun.Shoot();
                                if (Gun.LastMissile != null) Gun.LastMissile.Target = Target;
                            }
                        }
                        else if (TypeGun == Core.BulletGunType)
                        {
                            
                        }
                    }
                }
            }
            else
            {
                if (EnableAI)
                {
                    Radar.Rotation = Radar.Pos.AngleTo(Target.Pos);
                    //dynamic? newT = Radar.CanPing() ? Radar.Ping() : null;
                    if (TypeGun == Core.GunType && Gun.LastMissile != null && Pos.DistanceTo(Gun.LastMissile.Pos) > Pos.DistanceTo(Target.Pos) + 150)
                    {
                        Gun.LastMissile.Detonate();
                        Target = null;
                    }
                    if (TypeGun == Core.GunType && Gun.LastMissile == null)
                    {
                        Target = null;
                    }
                    if (TypeGun == Core.BulletGunType)
                    {
                        Gun.Rotation = Pos.AngleTo(Core.MoveForward(Target.Pos.Copy(), Target.Rotation, Target.Speed * Target.Pos.DistanceTo(Pos) / Gun.BulletStartSpeed));
                        Gun.Shoot();
                    }
                    if (!MyWorld.Objects.Contains(Target) || Pos.DistanceTo(Target.Pos) > Radar.DetectRange)
                    {
                        Target = null;
                    }
                }

            }
            if (EnableAI  && SelectedBase == null && Gun.AmmoCount == 0) 
            { 
                foreach (dynamic o in MyWorld.Objects)
                {
                    if (o.GetType() == Core.BaseType && o.Team == Team)
                    {
                        SelectedBase = o;
                        Rotation = Pos.AngleTo(SelectedBase.Pos);
                        break;
                    }
                }
            }
            if (SelectedBase != null && Gun.AmmoCount == 0 && !SelectedBase.EnteredVehicle.Contains(this))
            {
                Gas();
            }
            if (SelectedBase != null && SelectedBase.EnteredVehicle.Contains(this))
            {
                SelectedBase = null;
            }
            if (!Gased) Speed *= 0.94;
        }
    }
    public class Airport : ObjectBase
    {
        public double Length = 800;
        public double Width = 50;
        bool AdditionalSpawned = false;
        public Radar Radar;
        public Aircraft? LandedAircraft = null;
        public double LandedAircraftOriginalMinSpeed = 3;
        bool IsLandedAircraftTakingOff = false;
        public Airport(Vector? pos = null) : base(pos)
        {
            Model = new Model(new List<Vector>
            {
                new Vector(Width/2, Length/2),
                new Vector(Width/2, -Length/2),
                new Vector(-Width/2, -Length/2),
                new Vector(-Width/2, Length/2),
            });
            Grounded = true;
            IsRadio = false;
            Color = Color.DarkGreen;
            Name = "Airport";
            Radar = new Radar(Pos, 0, Length, 30) { Team = "AirportRadar", Rotation = Rotation };
        }
        public override void Update05S()
        {
            Radar.Pos = Core.MoveForward(Pos.Copy(), Rotation, -Length / 2);
            Radar.Rotation = Rotation;
            Radar.MyWorld = MyWorld;
            dynamic o = Radar.Ping();
            if (o != null && LandedAircraft == null)
            {
                if (o.GetType() == Core.AircraftType)
                {
                    if (o.Speed <= o.MinSpeed)
                    {
                        if (Math.Abs(o.ZRotation) < 30)
                        {
                            Debug.WriteLine("New landed aircraft!");
                            LandedAircraft = o;
                            LandedAircraftOriginalMinSpeed = LandedAircraft.MinSpeed;
                        }
                    }
                }
            }
        }
        public override void Update()
        {
            Radar.Pos =Core.MoveForward(Pos.Copy(), Rotation, -Length/2);
            Radar.Rotation = Rotation;
            Radar.MyWorld = MyWorld;
            if (!AdditionalSpawned)
            {
                AdditionalSpawned = true;
                //Antiair a = new Antiair(Core.MoveForward(Pos - new Vector(-Width - 70), Rotation, -Length / 3)) { Team = Team, Rotation = Rotation };
                Antiair a = new Antiair(Pos + Core.RandomVector(Length*0.4)) { Team = Team, Rotation = Rotation };
                a.Radar.DetectRange = 6000;
                a.Gun.AmmoCount = 2;
                MyWorld.InstantiateObject(a);
                double A = 50;
                Base b = new Base(Core.MoveForward(Pos - new Vector(-Width - 70 - A), Rotation, Length / 5), A) { Team = Team, Rotation = Rotation };
                MyWorld.InstantiateObject(b);
            }

            if (LandedAircraft != null)
            {
                if (LandedAircraft.Pos.DistanceTo(Pos) > Length/2)
                {
                    IsLandedAircraftTakingOff = true;
                }
                if (LandedAircraft.Speed != 0) {

                    //LandedAircraft.Speed -= LandedAircraft.IncreaseSpeedValue;
                    LandedAircraft.MinSpeed = 0;
                }
                if (LandedAircraft.Speed <= 0)
                {
                    LandedAircraft.Grounded = true;
                    LandedAircraft.Gun.AmmoCount = LandedAircraft.Gun.MaxAmmoCount;
                    LandedAircraft.BulletGun.AmmoCount = LandedAircraft.BulletGun.MaxAmmoCount;
                    LandedAircraft.TrapsCount = LandedAircraft.MaxTrapsCount;
                    LandedAircraft.Model = new Aircraft(new Vector()).Model;
                    LandedAircraft.DestructableModules = new Aircraft(new Vector()).DestructableModules;
                }
                if (LandedAircraft.Grounded && LandedAircraft.Speed > 0)
                {
                    //IsLandedAircraftTakingOff = true;
                }
            }
            if (IsLandedAircraftTakingOff)
            {
                if (LandedAircraft.Speed < LandedAircraftOriginalMinSpeed)
                {
                    LandedAircraft.Speed += LandedAircraft.IncreaseSpeedValue;
                }
                else
                {
                    LandedAircraft.MinSpeed = LandedAircraftOriginalMinSpeed;
                    LandedAircraft.Grounded = false;
                    LandedAircraft = null;
                    IsLandedAircraftTakingOff = false;
                }
            }
        }
    }
    public class Umbrella : ObjectBase
    {
        public int AmmonCount = 10;
        public int MaxAmmoCount = 10;
        public DateTime StartRealodingTime = DateTime.Now;
        public double ReloadingTime = 10;
        public int TrapsInShoot = 30;
        public Radar Radar;

        public Umbrella(Vector? pos = null) : base(pos) 
        {
            Name = "КОЭП \"Зонт\"";
            Radar = new Radar(Pos, 60, 800, 200, 0);
            Model = new Model(new List<Vector> {
                new Vector(0,0),
                new Vector(20,6),
                new Vector(24,14),
                new Vector(-24,14),
                new Vector(-20,6),
            });
            Grounded = true;
            Color = Color.FromArgb(255, 0, 100, 0);
        }
        public bool CanShoot()
        {
            return DateTime.Now.Subtract(StartRealodingTime).TotalSeconds >= ReloadingTime && AmmonCount > 0;
        }
        public void Shoot()
        {
            if (CanShoot())
            {
                
                AmmonCount -= 1;
                StartRealodingTime = DateTime.Now;
                for (int i = 0; i < TrapsInShoot; i++)
                {
                    MyWorld.InstantiateObject(new ThermalTrap(Pos.Copy(), 25+Core.Random.Next(-10,10)) { Rotation = Rotation + Core.Random.Next(-(int)Radar.DetectAngle/2, (int)Radar.DetectAngle / 2) });
                }
                
            }
        }
        public override void Update()
        {
            Radar.Pos = Pos;
            Radar.MyWorld = MyWorld;
            if (CanShoot()) Radar.Update();
            Rotation = Radar.Rotation;
            if (Radar.CanPing())
            {
                dynamic? o = Radar.Ping();
                if (o != null)
                {
                    if (o.GetType() == Core.MissileType && Math.Abs(o.Rotation - o.Pos.AngleTo(Pos)) < Radar.DetectAngle)
                    {
                        //Rotation = Pos.AngleTo(o.Pos);
                        Shoot();
                    }
                }
            }
        }
    }
    public class Base : ObjectBase
    {
        public List<dynamic> EnteredVehicle = new List<dynamic>();
        public double Radius { get; }
        public Base(Vector? pos = null, double a = 100) : base(pos)
        {
            Grounded = true;
            Radius = a;
            Color = Color.DarkOliveGreen;
            Size = 4;
            Model = new Model(new List<Vector>
            {
                new Vector(a, a),
                new Vector(a,-a),
                new Vector(-a, -a),
                new Vector(-a,a),
            });
            Name = "Base";
        }
        public override void Update()
        {
            for (int i = 0; i < MyWorld.Objects.Count; i++)
            {
                dynamic o = MyWorld.Objects[i];
                if (o.Grounded && o.Pos.DistanceTo(Pos) <= Radius && !EnteredVehicle.Contains(o) && o.GetType() != Core.AirportType && o.GetType() != Core.BaseType)
                {
                    EnteredVehicle.Add(o);
                }

            }
            for (int i = 0; i < EnteredVehicle.Count; i++)
            {
                dynamic o = EnteredVehicle[i];
                if (!(o.Pos.DistanceTo(Pos) <= Radius)) {
                    EnteredVehicle.Remove(o);
                    continue;
                } 
                o.Gun.AmmoCount = o.Gun.MaxAmmoCount;
            }
        }
    }
}
