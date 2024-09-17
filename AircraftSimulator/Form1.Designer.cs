namespace AircraftSimulator
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            FPS = new Label();
            ShowInfoToggle = new CheckBox();
            EnableSmokeCheckBox = new CheckBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            создатьToolStripMenuItem = new ToolStripMenuItem();
            самолетToolStripMenuItem = new ToolStripMenuItem();
            ракетаToolStripMenuItem = new ToolStripMenuItem();
            пВОToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            пВОПШКToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripMenuItem14 = new ToolStripMenuItem();
            toolStripMenuItem15 = new ToolStripMenuItem();
            toolStripMenuItem16 = new ToolStripMenuItem();
            toolStripMenuItem17 = new ToolStripMenuItem();
            toolStripMenuItem18 = new ToolStripMenuItem();
            рЛСToolStripMenuItem = new ToolStripMenuItem();
            базуToolStripMenuItem = new ToolStripMenuItem();
            аеропортToolStripMenuItem = new ToolStripMenuItem();
            кОЭПЗонтToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            ммToolStripMenuItem = new ToolStripMenuItem();
            ммToolStripMenuItem1 = new ToolStripMenuItem();
            ммToolStripMenuItem2 = new ToolStripMenuItem();
            ммToolStripMenuItem3 = new ToolStripMenuItem();
            ммToolStripMenuItem4 = new ToolStripMenuItem();
            ммToolStripMenuItem5 = new ToolStripMenuItem();
            ммToolStripMenuItem6 = new ToolStripMenuItem();
            рестартRToolStripMenuItem = new ToolStripMenuItem();
            перемещениеToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            случайноToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            впередToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            toolStripMenuItem11 = new ToolStripMenuItem();
            toolStripMenuItem12 = new ToolStripMenuItem();
            toolStripMenuItem13 = new ToolStripMenuItem();
            удалитьПВОToolStripMenuItem = new ToolStripMenuItem();
            отключитьВВСToolStripMenuItem = new ToolStripMenuItem();
            уничтожитьМодульToolStripMenuItem = new ToolStripMenuItem();
            lWingToolStripMenuItem = new ToolStripMenuItem();
            rWingToolStripMenuItem = new ToolStripMenuItem();
            backToolStripMenuItem = new ToolStripMenuItem();
            fuelTankToolStripMenuItem = new ToolStripMenuItem();
            уничтожитьВсеToolStripMenuItem = new ToolStripMenuItem();
            управлятьToolStripMenuItem = new ToolStripMenuItem();
            FlaresCountLabel = new Label();
            SpeedLabel = new Label();
            AmmoInfoLabel = new Label();
            BulletGunAmmoInfo = new Label();
            OverloadInfo = new Label();
            StaminaBar = new ProgressBar();
            StaminaText = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1600, 900);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // FPS
            // 
            FPS.AutoSize = true;
            FPS.BackColor = Color.Black;
            FPS.Font = new Font("Segoe UI", 12F);
            FPS.ForeColor = Color.Lime;
            FPS.Location = new Point(12, 9);
            FPS.Name = "FPS";
            FPS.Size = new Size(52, 21);
            FPS.TabIndex = 1;
            FPS.Text = "-- FPS";
            FPS.Click += FPS_Click;
            // 
            // ShowInfoToggle
            // 
            ShowInfoToggle.AutoSize = true;
            ShowInfoToggle.BackColor = SystemColors.ActiveCaptionText;
            ShowInfoToggle.Cursor = Cursors.Hand;
            ShowInfoToggle.Font = new Font("Segoe UI", 12F);
            ShowInfoToggle.ForeColor = Color.ForestGreen;
            ShowInfoToggle.Location = new Point(70, 8);
            ShowInfoToggle.Name = "ShowInfoToggle";
            ShowInfoToggle.Size = new Size(106, 25);
            ShowInfoToggle.TabIndex = 2;
            ShowInfoToggle.TabStop = false;
            ShowInfoToggle.Text = "Debug (F3)";
            ShowInfoToggle.UseVisualStyleBackColor = false;
            ShowInfoToggle.CheckedChanged += ShowInfoToggle_CheckedChanged;
            // 
            // EnableSmokeCheckBox
            // 
            EnableSmokeCheckBox.AutoSize = true;
            EnableSmokeCheckBox.BackColor = SystemColors.ActiveCaptionText;
            EnableSmokeCheckBox.Checked = true;
            EnableSmokeCheckBox.CheckState = CheckState.Checked;
            EnableSmokeCheckBox.Cursor = Cursors.Hand;
            EnableSmokeCheckBox.Font = new Font("Segoe UI", 12F);
            EnableSmokeCheckBox.ForeColor = Color.Green;
            EnableSmokeCheckBox.Location = new Point(70, 33);
            EnableSmokeCheckBox.Name = "EnableSmokeCheckBox";
            EnableSmokeCheckBox.Size = new Size(62, 25);
            EnableSmokeCheckBox.TabIndex = 3;
            EnableSmokeCheckBox.TabStop = false;
            EnableSmokeCheckBox.Text = "Дым";
            EnableSmokeCheckBox.UseVisualStyleBackColor = false;
            EnableSmokeCheckBox.CheckedChanged += EnableSmokeCheckBox_CheckedChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.BackColor = SystemColors.ActiveCaptionText;
            contextMenuStrip1.BackgroundImage = Properties.Resources.syahrul_eka_935136;
            contextMenuStrip1.BackgroundImageLayout = ImageLayout.Zoom;
            contextMenuStrip1.Font = new Font("Segoe UI", 12F);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { создатьToolStripMenuItem, рестартRToolStripMenuItem, перемещениеToolStripMenuItem, удалитьПВОToolStripMenuItem, отключитьВВСToolStripMenuItem, уничтожитьМодульToolStripMenuItem, уничтожитьВсеToolStripMenuItem, управлятьToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.ShowImageMargin = false;
            contextMenuStrip1.Size = new Size(232, 266);
            contextMenuStrip1.Text = "ГойдаTool";
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.BackColor = SystemColors.ActiveCaptionText;
            создатьToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
            создатьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { самолетToolStripMenuItem, ракетаToolStripMenuItem, пВОToolStripMenuItem, toolStripMenuItem1, пВОПШКToolStripMenuItem, рЛСToolStripMenuItem, базуToolStripMenuItem, аеропортToolStripMenuItem, кОЭПЗонтToolStripMenuItem, toolStripMenuItem6 });
            создатьToolStripMenuItem.Font = new Font("Segoe UI", 13F);
            создатьToolStripMenuItem.ForeColor = SystemColors.Control;
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.Size = new Size(231, 30);
            создатьToolStripMenuItem.Text = "Создать";
            // 
            // самолетToolStripMenuItem
            // 
            самолетToolStripMenuItem.Name = "самолетToolStripMenuItem";
            самолетToolStripMenuItem.Size = new Size(205, 30);
            самолетToolStripMenuItem.Text = "Самолет";
            самолетToolStripMenuItem.Click += самолетToolStripMenuItem_Click;
            // 
            // ракетаToolStripMenuItem
            // 
            ракетаToolStripMenuItem.Name = "ракетаToolStripMenuItem";
            ракетаToolStripMenuItem.Size = new Size(205, 30);
            ракетаToolStripMenuItem.Text = "Ракету";
            ракетаToolStripMenuItem.Click += ракетаToolStripMenuItem_Click;
            // 
            // пВОToolStripMenuItem
            // 
            пВОToolStripMenuItem.Name = "пВОToolStripMenuItem";
            пВОToolStripMenuItem.Size = new Size(205, 30);
            пВОToolStripMenuItem.Text = "ПВО";
            пВОToolStripMenuItem.Click += пВОToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(205, 30);
            toolStripMenuItem1.Text = "Комплекс ПВО";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(132, 30);
            toolStripMenuItem3.Text = "10х1";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(132, 30);
            toolStripMenuItem4.Text = "10х5";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(132, 30);
            toolStripMenuItem5.Text = "10х10";
            toolStripMenuItem5.Click += toolStripMenuItem5_Click;
            // 
            // пВОПШКToolStripMenuItem
            // 
            пВОПШКToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem7, toolStripMenuItem14, toolStripMenuItem15, toolStripMenuItem16, toolStripMenuItem17, toolStripMenuItem18 });
            пВОПШКToolStripMenuItem.Name = "пВОПШКToolStripMenuItem";
            пВОПШКToolStripMenuItem.Size = new Size(205, 30);
            пВОПШКToolStripMenuItem.Text = "ПВО (ПШК)";
            пВОПШКToolStripMenuItem.Click += пВОПШКToolStripMenuItem_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(180, 30);
            toolStripMenuItem7.Text = "3 мм";
            toolStripMenuItem7.Click += toolStripMenuItem7_Click;
            // 
            // toolStripMenuItem14
            // 
            toolStripMenuItem14.Name = "toolStripMenuItem14";
            toolStripMenuItem14.Size = new Size(180, 30);
            toolStripMenuItem14.Text = "7.62 мм";
            toolStripMenuItem14.Click += toolStripMenuItem14_Click;
            // 
            // toolStripMenuItem15
            // 
            toolStripMenuItem15.Name = "toolStripMenuItem15";
            toolStripMenuItem15.Size = new Size(180, 30);
            toolStripMenuItem15.Text = "12 мм";
            toolStripMenuItem15.Click += toolStripMenuItem15_Click;
            // 
            // toolStripMenuItem16
            // 
            toolStripMenuItem16.Name = "toolStripMenuItem16";
            toolStripMenuItem16.Size = new Size(180, 30);
            toolStripMenuItem16.Text = "20 мм";
            toolStripMenuItem16.Click += toolStripMenuItem16_Click;
            // 
            // toolStripMenuItem17
            // 
            toolStripMenuItem17.Name = "toolStripMenuItem17";
            toolStripMenuItem17.Size = new Size(180, 30);
            toolStripMenuItem17.Text = "80 мм";
            toolStripMenuItem17.Click += toolStripMenuItem17_Click;
            // 
            // toolStripMenuItem18
            // 
            toolStripMenuItem18.Name = "toolStripMenuItem18";
            toolStripMenuItem18.Size = new Size(180, 30);
            toolStripMenuItem18.Text = "300 мм";
            toolStripMenuItem18.Click += toolStripMenuItem18_Click;
            // 
            // рЛСToolStripMenuItem
            // 
            рЛСToolStripMenuItem.Name = "рЛСToolStripMenuItem";
            рЛСToolStripMenuItem.Size = new Size(205, 30);
            рЛСToolStripMenuItem.Text = "Радар";
            рЛСToolStripMenuItem.Click += рЛСToolStripMenuItem_Click;
            // 
            // базуToolStripMenuItem
            // 
            базуToolStripMenuItem.Name = "базуToolStripMenuItem";
            базуToolStripMenuItem.Size = new Size(205, 30);
            базуToolStripMenuItem.Text = "Базу";
            базуToolStripMenuItem.Click += базуToolStripMenuItem_Click;
            // 
            // аеропортToolStripMenuItem
            // 
            аеропортToolStripMenuItem.Name = "аеропортToolStripMenuItem";
            аеропортToolStripMenuItem.Size = new Size(205, 30);
            аеропортToolStripMenuItem.Text = "Аэропорт";
            аеропортToolStripMenuItem.Click += аеропортToolStripMenuItem_Click;
            // 
            // кОЭПЗонтToolStripMenuItem
            // 
            кОЭПЗонтToolStripMenuItem.Name = "кОЭПЗонтToolStripMenuItem";
            кОЭПЗонтToolStripMenuItem.Size = new Size(205, 30);
            кОЭПЗонтToolStripMenuItem.Text = "КОЭП \"Зонт\"";
            кОЭПЗонтToolStripMenuItem.Click += кОЭПЗонтToolStripMenuItem_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.DropDownItems.AddRange(new ToolStripItem[] { ммToolStripMenuItem, ммToolStripMenuItem1, ммToolStripMenuItem2, ммToolStripMenuItem3, ммToolStripMenuItem4, ммToolStripMenuItem5, ммToolStripMenuItem6 });
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(205, 30);
            toolStripMenuItem6.Text = "Пулю";
            toolStripMenuItem6.Click += toolStripMenuItem6_Click;
            // 
            // ммToolStripMenuItem
            // 
            ммToolStripMenuItem.Name = "ммToolStripMenuItem";
            ммToolStripMenuItem.Size = new Size(155, 30);
            ммToolStripMenuItem.Text = "3 мм";
            ммToolStripMenuItem.Click += ммToolStripMenuItem_Click;
            // 
            // ммToolStripMenuItem1
            // 
            ммToolStripMenuItem1.Name = "ммToolStripMenuItem1";
            ммToolStripMenuItem1.Size = new Size(155, 30);
            ммToolStripMenuItem1.Text = "7.62 мм";
            ммToolStripMenuItem1.Click += ммToolStripMenuItem1_Click;
            // 
            // ммToolStripMenuItem2
            // 
            ммToolStripMenuItem2.Name = "ммToolStripMenuItem2";
            ммToolStripMenuItem2.Size = new Size(155, 30);
            ммToolStripMenuItem2.Text = "12 мм";
            ммToolStripMenuItem2.Click += ммToolStripMenuItem2_Click;
            // 
            // ммToolStripMenuItem3
            // 
            ммToolStripMenuItem3.Name = "ммToolStripMenuItem3";
            ммToolStripMenuItem3.Size = new Size(155, 30);
            ммToolStripMenuItem3.Text = "20 мм";
            ммToolStripMenuItem3.Click += ммToolStripMenuItem3_Click;
            // 
            // ммToolStripMenuItem4
            // 
            ммToolStripMenuItem4.Name = "ммToolStripMenuItem4";
            ммToolStripMenuItem4.Size = new Size(155, 30);
            ммToolStripMenuItem4.Text = "30 мм";
            ммToolStripMenuItem4.Click += ммToolStripMenuItem4_Click;
            // 
            // ммToolStripMenuItem5
            // 
            ммToolStripMenuItem5.Name = "ммToolStripMenuItem5";
            ммToolStripMenuItem5.Size = new Size(155, 30);
            ммToolStripMenuItem5.Text = "120 мм";
            ммToolStripMenuItem5.Click += ммToolStripMenuItem5_Click;
            // 
            // ммToolStripMenuItem6
            // 
            ммToolStripMenuItem6.Name = "ммToolStripMenuItem6";
            ммToolStripMenuItem6.Size = new Size(155, 30);
            ммToolStripMenuItem6.Text = "1488 мм";
            ммToolStripMenuItem6.Click += ммToolStripMenuItem6_Click;
            // 
            // рестартRToolStripMenuItem
            // 
            рестартRToolStripMenuItem.Font = new Font("Segoe UI", 13F);
            рестартRToolStripMenuItem.ForeColor = Color.White;
            рестартRToolStripMenuItem.Name = "рестартRToolStripMenuItem";
            рестартRToolStripMenuItem.Size = new Size(231, 30);
            рестартRToolStripMenuItem.Text = "Рестарт (R)";
            рестартRToolStripMenuItem.Click += рестартRToolStripMenuItem_Click;
            // 
            // перемещениеToolStripMenuItem
            // 
            перемещениеToolStripMenuItem.BackColor = SystemColors.ActiveCaptionText;
            перемещениеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator1, случайноToolStripMenuItem, toolStripMenuItem2, впередToolStripMenuItem });
            перемещениеToolStripMenuItem.Font = new Font("Segoe UI", 13F);
            перемещениеToolStripMenuItem.ForeColor = SystemColors.Control;
            перемещениеToolStripMenuItem.Name = "перемещениеToolStripMenuItem";
            перемещениеToolStripMenuItem.Size = new Size(231, 30);
            перемещениеToolStripMenuItem.Text = "Перемещение";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(160, 6);
            // 
            // случайноToolStripMenuItem
            // 
            случайноToolStripMenuItem.Name = "случайноToolStripMenuItem";
            случайноToolStripMenuItem.Size = new Size(163, 30);
            случайноToolStripMenuItem.Text = "Случайно";
            случайноToolStripMenuItem.Click += случайноToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(163, 30);
            toolStripMenuItem2.Text = "0, 0";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // впередToolStripMenuItem
            // 
            впередToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem8, toolStripMenuItem9, toolStripMenuItem10, toolStripMenuItem11, toolStripMenuItem12, toolStripMenuItem13 });
            впередToolStripMenuItem.Name = "впередToolStripMenuItem";
            впередToolStripMenuItem.Size = new Size(163, 30);
            впередToolStripMenuItem.Text = "Вперед";
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(144, 30);
            toolStripMenuItem8.Text = "100";
            toolStripMenuItem8.Click += toolStripMenuItem8_Click;
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(144, 30);
            toolStripMenuItem9.Text = "1000";
            toolStripMenuItem9.Click += toolStripMenuItem9_Click;
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new Size(144, 30);
            toolStripMenuItem10.Text = "5000";
            toolStripMenuItem10.Click += toolStripMenuItem10_Click;
            // 
            // toolStripMenuItem11
            // 
            toolStripMenuItem11.Name = "toolStripMenuItem11";
            toolStripMenuItem11.Size = new Size(144, 30);
            toolStripMenuItem11.Text = "10000";
            toolStripMenuItem11.Click += toolStripMenuItem11_Click;
            // 
            // toolStripMenuItem12
            // 
            toolStripMenuItem12.Name = "toolStripMenuItem12";
            toolStripMenuItem12.Size = new Size(144, 30);
            toolStripMenuItem12.Text = "50000";
            toolStripMenuItem12.Click += toolStripMenuItem12_Click;
            // 
            // toolStripMenuItem13
            // 
            toolStripMenuItem13.Name = "toolStripMenuItem13";
            toolStripMenuItem13.Size = new Size(144, 30);
            toolStripMenuItem13.Text = "100000";
            toolStripMenuItem13.Click += toolStripMenuItem13_Click;
            // 
            // удалитьПВОToolStripMenuItem
            // 
            удалитьПВОToolStripMenuItem.Font = new Font("Segoe UI", 14F);
            удалитьПВОToolStripMenuItem.ForeColor = SystemColors.Control;
            удалитьПВОToolStripMenuItem.Name = "удалитьПВОToolStripMenuItem";
            удалитьПВОToolStripMenuItem.Size = new Size(231, 30);
            удалитьПВОToolStripMenuItem.Text = "Удалить ПВО";
            удалитьПВОToolStripMenuItem.Click += удалитьПВОToolStripMenuItem_Click;
            // 
            // отключитьВВСToolStripMenuItem
            // 
            отключитьВВСToolStripMenuItem.Font = new Font("Segoe UI", 14F);
            отключитьВВСToolStripMenuItem.ForeColor = SystemColors.Control;
            отключитьВВСToolStripMenuItem.Name = "отключитьВВСToolStripMenuItem";
            отключитьВВСToolStripMenuItem.Size = new Size(231, 30);
            отключитьВВСToolStripMenuItem.Text = "Отключить ВВС";
            отключитьВВСToolStripMenuItem.Click += отключитьВВСToolStripMenuItem_Click;
            // 
            // уничтожитьМодульToolStripMenuItem
            // 
            уничтожитьМодульToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lWingToolStripMenuItem, rWingToolStripMenuItem, backToolStripMenuItem, fuelTankToolStripMenuItem });
            уничтожитьМодульToolStripMenuItem.Font = new Font("Segoe UI", 14F);
            уничтожитьМодульToolStripMenuItem.ForeColor = SystemColors.Control;
            уничтожитьМодульToolStripMenuItem.Name = "уничтожитьМодульToolStripMenuItem";
            уничтожитьМодульToolStripMenuItem.Size = new Size(231, 30);
            уничтожитьМодульToolStripMenuItem.Text = "Уничтожить модуль";
            уничтожитьМодульToolStripMenuItem.Click += уничтожитьМодульToolStripMenuItem_Click;
            // 
            // lWingToolStripMenuItem
            // 
            lWingToolStripMenuItem.Name = "lWingToolStripMenuItem";
            lWingToolStripMenuItem.Size = new Size(157, 30);
            lWingToolStripMenuItem.Text = "LWing";
            lWingToolStripMenuItem.Click += lWingToolStripMenuItem_Click;
            // 
            // rWingToolStripMenuItem
            // 
            rWingToolStripMenuItem.Name = "rWingToolStripMenuItem";
            rWingToolStripMenuItem.Size = new Size(157, 30);
            rWingToolStripMenuItem.Text = "RWing";
            rWingToolStripMenuItem.Click += rWingToolStripMenuItem_Click;
            // 
            // backToolStripMenuItem
            // 
            backToolStripMenuItem.Name = "backToolStripMenuItem";
            backToolStripMenuItem.Size = new Size(157, 30);
            backToolStripMenuItem.Text = "Back";
            backToolStripMenuItem.Click += backToolStripMenuItem_Click;
            // 
            // fuelTankToolStripMenuItem
            // 
            fuelTankToolStripMenuItem.Name = "fuelTankToolStripMenuItem";
            fuelTankToolStripMenuItem.Size = new Size(157, 30);
            fuelTankToolStripMenuItem.Text = "FuelTank";
            fuelTankToolStripMenuItem.Click += fuelTankToolStripMenuItem_Click;
            // 
            // уничтожитьВсеToolStripMenuItem
            // 
            уничтожитьВсеToolStripMenuItem.Font = new Font("Segoe UI", 14F);
            уничтожитьВсеToolStripMenuItem.ForeColor = SystemColors.Control;
            уничтожитьВсеToolStripMenuItem.Name = "уничтожитьВсеToolStripMenuItem";
            уничтожитьВсеToolStripMenuItem.Size = new Size(231, 30);
            уничтожитьВсеToolStripMenuItem.Text = "Уничтожить все";
            уничтожитьВсеToolStripMenuItem.Click += уничтожитьВсеToolStripMenuItem_Click;
            // 
            // управлятьToolStripMenuItem
            // 
            управлятьToolStripMenuItem.Font = new Font("Segoe UI", 14F);
            управлятьToolStripMenuItem.ForeColor = SystemColors.Control;
            управлятьToolStripMenuItem.Name = "управлятьToolStripMenuItem";
            управлятьToolStripMenuItem.Size = new Size(231, 30);
            управлятьToolStripMenuItem.Text = "Управлять";
            управлятьToolStripMenuItem.Click += управлятьToolStripMenuItem_Click;
            управлятьToolStripMenuItem.MouseEnter += управлятьToolStripMenuItem_MouseEnter;
            // 
            // FlaresCountLabel
            // 
            FlaresCountLabel.AutoSize = true;
            FlaresCountLabel.BackColor = SystemColors.ActiveCaptionText;
            FlaresCountLabel.Font = new Font("Segoe UI", 12F);
            FlaresCountLabel.ForeColor = Color.FromArgb(0, 192, 0);
            FlaresCountLabel.Location = new Point(182, 9);
            FlaresCountLabel.Name = "FlaresCountLabel";
            FlaresCountLabel.Size = new Size(90, 21);
            FlaresCountLabel.TabIndex = 4;
            FlaresCountLabel.Text = "ЛТЦ: 60/60";
            FlaresCountLabel.Click += FlaresCountLabel_Click;
            // 
            // SpeedLabel
            // 
            SpeedLabel.AutoSize = true;
            SpeedLabel.BackColor = SystemColors.ActiveCaptionText;
            SpeedLabel.Font = new Font("Segoe UI", 12F);
            SpeedLabel.ForeColor = Color.FromArgb(0, 192, 0);
            SpeedLabel.Location = new Point(182, 34);
            SpeedLabel.Name = "SpeedLabel";
            SpeedLabel.Size = new Size(93, 21);
            SpeedLabel.TabIndex = 5;
            SpeedLabel.Text = "Скорость: 3";
            // 
            // AmmoInfoLabel
            // 
            AmmoInfoLabel.AutoSize = true;
            AmmoInfoLabel.BackColor = SystemColors.ActiveCaptionText;
            AmmoInfoLabel.Font = new Font("Segoe UI", 12F);
            AmmoInfoLabel.ForeColor = Color.Cyan;
            AmmoInfoLabel.Location = new Point(292, 9);
            AmmoInfoLabel.Name = "AmmoInfoLabel";
            AmmoInfoLabel.Size = new Size(92, 21);
            AmmoInfoLabel.TabIndex = 6;
            AmmoInfoLabel.Text = "РКТ: Aim 9L";
            // 
            // BulletGunAmmoInfo
            // 
            BulletGunAmmoInfo.AutoSize = true;
            BulletGunAmmoInfo.BackColor = SystemColors.ActiveCaptionText;
            BulletGunAmmoInfo.Font = new Font("Segoe UI", 12F);
            BulletGunAmmoInfo.ForeColor = Color.Cyan;
            BulletGunAmmoInfo.Location = new Point(292, 33);
            BulletGunAmmoInfo.Name = "BulletGunAmmoInfo";
            BulletGunAmmoInfo.Size = new Size(48, 21);
            BulletGunAmmoInfo.TabIndex = 7;
            BulletGunAmmoInfo.Text = "ПШК:";
            // 
            // OverloadInfo
            // 
            OverloadInfo.AutoSize = true;
            OverloadInfo.BackColor = SystemColors.ActiveCaptionText;
            OverloadInfo.Font = new Font("Segoe UI", 12F);
            OverloadInfo.ForeColor = Color.FromArgb(0, 192, 0);
            OverloadInfo.Location = new Point(182, 64);
            OverloadInfo.Name = "OverloadInfo";
            OverloadInfo.Size = new Size(34, 21);
            OverloadInfo.TabIndex = 8;
            OverloadInfo.Text = "0 G";
            // 
            // StaminaBar
            // 
            StaminaBar.BackColor = SystemColors.ActiveCaptionText;
            StaminaBar.ForeColor = Color.Fuchsia;
            StaminaBar.Location = new Point(492, 9);
            StaminaBar.Name = "StaminaBar";
            StaminaBar.Size = new Size(164, 21);
            StaminaBar.Step = 100;
            StaminaBar.TabIndex = 9;
            // 
            // StaminaText
            // 
            StaminaText.AutoSize = true;
            StaminaText.BackColor = SystemColors.ActiveCaptionText;
            StaminaText.Font = new Font("Segoe UI", 12F);
            StaminaText.ForeColor = Color.Fuchsia;
            StaminaText.Location = new Point(433, 9);
            StaminaText.Name = "StaminaText";
            StaminaText.Size = new Size(53, 21);
            StaminaText.TabIndex = 10;
            StaminaText.Text = "СТМН";
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(StaminaText);
            Controls.Add(StaminaBar);
            Controls.Add(OverloadInfo);
            Controls.Add(BulletGunAmmoInfo);
            Controls.Add(AmmoInfoLabel);
            Controls.Add(SpeedLabel);
            Controls.Add(FlaresCountLabel);
            Controls.Add(EnableSmokeCheckBox);
            Controls.Add(ShowInfoToggle);
            Controls.Add(FPS);
            Controls.Add(pictureBox1);
            HelpButton = true;
            MinimumSize = new Size(900, 600);
            Name = "Game";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ТАНКИ";
            Load += Game_Load;
            Scroll += Game_Scroll;
            KeyDown += Game_KeyDown;
            KeyPress += Game_KeyPress;
            KeyUp += Game_KeyUp;
            MouseClick += Game_MouseClick;
            PreviewKeyDown += Game_PreviewKeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        public Label FPS;
        private CheckBox ShowInfoToggle;
        private CheckBox EnableSmokeCheckBox;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem создатьToolStripMenuItem;
        private ToolStripMenuItem самолетToolStripMenuItem;
        private ToolStripMenuItem ракетаToolStripMenuItem;
        private ToolStripMenuItem рестартRToolStripMenuItem;
        private ToolStripMenuItem пВОToolStripMenuItem;
        private ToolStripMenuItem рЛСToolStripMenuItem;
        private ToolStripMenuItem базуToolStripMenuItem;
        private ToolStripMenuItem аеропортToolStripMenuItem;
        private ToolStripMenuItem перемещениеToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem случайноToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem впередToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem toolStripMenuItem13;
        private Label FlaresCountLabel;
        private Label SpeedLabel;
        private Label AmmoInfoLabel;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem кОЭПЗонтToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem6;
        private Label BulletGunAmmoInfo;
        private ToolStripMenuItem удалитьПВОToolStripMenuItem;
        private Label OverloadInfo;
        private ToolStripMenuItem пВОПШКToolStripMenuItem;
        private ToolStripMenuItem отключитьВВСToolStripMenuItem;
        private ToolStripMenuItem уничтожитьМодульToolStripMenuItem;
        private ToolStripMenuItem lWingToolStripMenuItem;
        private ToolStripMenuItem rWingToolStripMenuItem;
        private ToolStripMenuItem backToolStripMenuItem;
        private ToolStripMenuItem fuelTankToolStripMenuItem;
        private ProgressBar StaminaBar;
        private Label StaminaText;
        private ToolStripMenuItem ммToolStripMenuItem;
        private ToolStripMenuItem ммToolStripMenuItem1;
        private ToolStripMenuItem ммToolStripMenuItem2;
        private ToolStripMenuItem ммToolStripMenuItem3;
        private ToolStripMenuItem ммToolStripMenuItem4;
        private ToolStripMenuItem ммToolStripMenuItem5;
        private ToolStripMenuItem ммToolStripMenuItem6;
        private ToolStripMenuItem уничтожитьВсеToolStripMenuItem;
        private ToolStripMenuItem управлятьToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripMenuItem toolStripMenuItem15;
        private ToolStripMenuItem toolStripMenuItem16;
        private ToolStripMenuItem toolStripMenuItem17;
        private ToolStripMenuItem toolStripMenuItem18;
    }
}
