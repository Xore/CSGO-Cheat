<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Hack
  Inherits MaterialSkin.Controls.MaterialForm

  'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Wird vom Windows Form-Designer benötigt.
  Private components As System.ComponentModel.IContainer

  'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
  'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
  'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TabControl1 = New MaterialSkin.Controls.MaterialTabControl()
    Me.TP_Aimbot = New System.Windows.Forms.TabPage()
    Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
    Me.Label_Smooth = New MaterialSkin.Controls.MaterialLabel()
    Me.TB_Smooth = New System.Windows.Forms.TrackBar()
    Me.Label1 = New MaterialSkin.Controls.MaterialLabel()
    Me.CB_VisibilityCheck = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_SilentAim = New MaterialSkin.Controls.MaterialCheckBox()
    Me.Label_FOV = New MaterialSkin.Controls.MaterialLabel()
    Me.Label4 = New MaterialSkin.Controls.MaterialLabel()
    Me.TB_FOV = New System.Windows.Forms.TrackBar()
    Me.CB_Aimkey = New System.Windows.Forms.ComboBox()
    Me.Label3 = New MaterialSkin.Controls.MaterialLabel()
    Me.CB_Aimspot = New System.Windows.Forms.ComboBox()
    Me.CB_AimMode = New System.Windows.Forms.ComboBox()
    Me.CB_Aimbot = New MaterialSkin.Controls.MaterialCheckBox()
    Me.Label2 = New MaterialSkin.Controls.MaterialLabel()
    Me.TP_Visuals = New System.Windows.Forms.TabPage()
    Me.Label_Distance = New MaterialSkin.Controls.MaterialLabel()
    Me.Label_DistanceInt = New MaterialSkin.Controls.MaterialLabel()
    Me.TB_Distance = New System.Windows.Forms.TrackBar()
    Me.CB_GHDistance = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_GHSound = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_NoSmoke = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_Glow_Weapons = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_Glow_Grenades = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_Glow_Bomb = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_Glow_Players = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_Glow_Chicken = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_GlowHack = New MaterialSkin.Controls.MaterialCheckBox()
    Me.Glow_VB = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_Radar = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_NoFlash = New MaterialSkin.Controls.MaterialCheckBox()
    Me.TP_Misc = New System.Windows.Forms.TabPage()
    Me.CB_FullAuto = New MaterialSkin.Controls.MaterialCheckBox()
    Me.Trigger_HB = New MaterialSkin.Controls.MaterialCheckBox()
    Me.Trigger_VC = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CheckBox2 = New MaterialSkin.Controls.MaterialCheckBox()
    Me.Label5 = New MaterialSkin.Controls.MaterialLabel()
    Me.CB_Triggerbot = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_FakeLag = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_BunnyHop = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_RCS = New MaterialSkin.Controls.MaterialCheckBox()
    Me.TP_Skinchanger = New System.Windows.Forms.TabPage()
    Me.CB_KnifeChanger = New MaterialSkin.Controls.MaterialCheckBox()
    Me.CB_SkinChanger = New MaterialSkin.Controls.MaterialCheckBox()
    Me.TB_Kills = New MaterialSkin.Controls.MaterialSingleLineTextField()
    Me.Label8 = New MaterialSkin.Controls.MaterialLabel()
    Me.CB_Weapons = New System.Windows.Forms.ComboBox()
    Me.Label7 = New MaterialSkin.Controls.MaterialLabel()
    Me.Label6 = New MaterialSkin.Controls.MaterialLabel()
    Me.CB_SkinId = New System.Windows.Forms.ComboBox()
    Me.DGV_EnemyInfo = New System.Windows.Forms.DataGridView()
    Me.Player_PlayerId = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Player_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Player_Distance = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Player_Health = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Player_Weapon = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Player_Wins = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Player_Rank = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.CB_GetEnemyInfo = New MaterialSkin.Controls.MaterialCheckBox()
    Me.Label9 = New MaterialSkin.Controls.MaterialLabel()
    Me.MaterialTabSelector2 = New MaterialSkin.Controls.MaterialTabSelector()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.CB_TriggerKey = New System.Windows.Forms.ComboBox()
    Me.TabControl1.SuspendLayout
    Me.TP_Aimbot.SuspendLayout
    CType(Me.TB_Smooth,System.ComponentModel.ISupportInitialize).BeginInit
    CType(Me.TB_FOV,System.ComponentModel.ISupportInitialize).BeginInit
    Me.TP_Visuals.SuspendLayout
    CType(Me.TB_Distance,System.ComponentModel.ISupportInitialize).BeginInit
    Me.TP_Misc.SuspendLayout
    Me.TP_Skinchanger.SuspendLayout
    CType(Me.DGV_EnemyInfo,System.ComponentModel.ISupportInitialize).BeginInit
    Me.SuspendLayout
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TP_Aimbot)
    Me.TabControl1.Controls.Add(Me.TP_Visuals)
    Me.TabControl1.Controls.Add(Me.TP_Misc)
    Me.TabControl1.Controls.Add(Me.TP_Skinchanger)
    Me.TabControl1.Depth = 0
    Me.TabControl1.Location = New System.Drawing.Point(16, 118)
    Me.TabControl1.MouseState = MaterialSkin.MouseState.HOVER
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(412, 237)
    Me.TabControl1.TabIndex = 20
    '
    'TP_Aimbot
    '
    Me.TP_Aimbot.BackColor = System.Drawing.Color.White
    Me.TP_Aimbot.Controls.Add(Me.MaterialLabel1)
    Me.TP_Aimbot.Controls.Add(Me.Label_Smooth)
    Me.TP_Aimbot.Controls.Add(Me.TB_Smooth)
    Me.TP_Aimbot.Controls.Add(Me.Label1)
    Me.TP_Aimbot.Controls.Add(Me.CB_VisibilityCheck)
    Me.TP_Aimbot.Controls.Add(Me.CB_SilentAim)
    Me.TP_Aimbot.Controls.Add(Me.Label_FOV)
    Me.TP_Aimbot.Controls.Add(Me.Label4)
    Me.TP_Aimbot.Controls.Add(Me.TB_FOV)
    Me.TP_Aimbot.Controls.Add(Me.CB_Aimkey)
    Me.TP_Aimbot.Controls.Add(Me.Label3)
    Me.TP_Aimbot.Controls.Add(Me.CB_Aimspot)
    Me.TP_Aimbot.Controls.Add(Me.CB_AimMode)
    Me.TP_Aimbot.Controls.Add(Me.CB_Aimbot)
    Me.TP_Aimbot.Controls.Add(Me.Label2)
    Me.TP_Aimbot.Location = New System.Drawing.Point(4, 22)
    Me.TP_Aimbot.Name = "TP_Aimbot"
    Me.TP_Aimbot.Padding = New System.Windows.Forms.Padding(3)
    Me.TP_Aimbot.Size = New System.Drawing.Size(404, 211)
    Me.TP_Aimbot.TabIndex = 0
    Me.TP_Aimbot.Text = "Aimbot"
    '
    'MaterialLabel1
    '
    Me.MaterialLabel1.AutoSize = true
    Me.MaterialLabel1.Depth = 0
    Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 11!)
    Me.MaterialLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.MaterialLabel1.Location = New System.Drawing.Point(253, 55)
    Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
    Me.MaterialLabel1.Name = "MaterialLabel1"
    Me.MaterialLabel1.Size = New System.Drawing.Size(97, 19)
    Me.MaterialLabel1.TabIndex = 26
    Me.MaterialLabel1.Text = "Smoothing %"
    '
    'Label_Smooth
    '
    Me.Label_Smooth.AutoSize = true
    Me.Label_Smooth.Depth = 0
    Me.Label_Smooth.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label_Smooth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label_Smooth.Location = New System.Drawing.Point(365, 55)
    Me.Label_Smooth.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label_Smooth.Name = "Label_Smooth"
    Me.Label_Smooth.Size = New System.Drawing.Size(17, 19)
    Me.Label_Smooth.TabIndex = 25
    Me.Label_Smooth.Text = "0"
    '
    'TB_Smooth
    '
    Me.TB_Smooth.AutoSize = false
    Me.TB_Smooth.BackColor = System.Drawing.SystemColors.ButtonFace
    Me.TB_Smooth.LargeChange = 10
    Me.TB_Smooth.Location = New System.Drawing.Point(249, 77)
    Me.TB_Smooth.Maximum = 100
    Me.TB_Smooth.Name = "TB_Smooth"
    Me.TB_Smooth.Size = New System.Drawing.Size(149, 17)
    Me.TB_Smooth.TabIndex = 24
    Me.TB_Smooth.TickStyle = System.Windows.Forms.TickStyle.None
    '
    'Label1
    '
    Me.Label1.AutoSize = true
    Me.Label1.Depth = 0
    Me.Label1.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label1.Location = New System.Drawing.Point(253, 7)
    Me.Label1.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(37, 19)
    Me.Label1.TabIndex = 23
    Me.Label1.Text = "FOV"
    '
    'CB_VisibilityCheck
    '
    Me.CB_VisibilityCheck.AutoSize = true
    Me.CB_VisibilityCheck.BackColor = System.Drawing.Color.White
    Me.CB_VisibilityCheck.Depth = 0
    Me.CB_VisibilityCheck.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_VisibilityCheck.ForeColor = System.Drawing.SystemColors.ControlText
    Me.CB_VisibilityCheck.Location = New System.Drawing.Point(6, 64)
    Me.CB_VisibilityCheck.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_VisibilityCheck.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_VisibilityCheck.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_VisibilityCheck.Name = "CB_VisibilityCheck"
    Me.CB_VisibilityCheck.Ripple = true
    Me.CB_VisibilityCheck.Size = New System.Drawing.Size(124, 30)
    Me.CB_VisibilityCheck.TabIndex = 22
    Me.CB_VisibilityCheck.Text = "Visibility Check"
    Me.CB_VisibilityCheck.UseVisualStyleBackColor = false
    '
    'CB_SilentAim
    '
    Me.CB_SilentAim.AutoSize = true
    Me.CB_SilentAim.BackColor = System.Drawing.Color.White
    Me.CB_SilentAim.Depth = 0
    Me.CB_SilentAim.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_SilentAim.Location = New System.Drawing.Point(6, 98)
    Me.CB_SilentAim.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_SilentAim.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_SilentAim.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_SilentAim.Name = "CB_SilentAim"
    Me.CB_SilentAim.Ripple = true
    Me.CB_SilentAim.Size = New System.Drawing.Size(65, 30)
    Me.CB_SilentAim.TabIndex = 21
    Me.CB_SilentAim.Text = "Silent"
    Me.CB_SilentAim.UseVisualStyleBackColor = false
    '
    'Label_FOV
    '
    Me.Label_FOV.AutoSize = true
    Me.Label_FOV.Depth = 0
    Me.Label_FOV.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label_FOV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label_FOV.Location = New System.Drawing.Point(365, 7)
    Me.Label_FOV.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label_FOV.Name = "Label_FOV"
    Me.Label_FOV.Size = New System.Drawing.Size(33, 19)
    Me.Label_FOV.TabIndex = 7
    Me.Label_FOV.Text = "360"
    '
    'Label4
    '
    Me.Label4.AutoSize = true
    Me.Label4.Depth = 0
    Me.Label4.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label4.Location = New System.Drawing.Point(6, 128)
    Me.Label4.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(59, 19)
    Me.Label4.TabIndex = 20
    Me.Label4.Text = "Aimkey"
    '
    'TB_FOV
    '
    Me.TB_FOV.AutoSize = false
    Me.TB_FOV.BackColor = System.Drawing.SystemColors.ButtonFace
    Me.TB_FOV.LargeChange = 10
    Me.TB_FOV.Location = New System.Drawing.Point(249, 29)
    Me.TB_FOV.Maximum = 360
    Me.TB_FOV.Minimum = 1
    Me.TB_FOV.Name = "TB_FOV"
    Me.TB_FOV.Size = New System.Drawing.Size(149, 17)
    Me.TB_FOV.TabIndex = 6
    Me.TB_FOV.TickStyle = System.Windows.Forms.TickStyle.None
    Me.TB_FOV.Value = 360
    '
    'CB_Aimkey
    '
    Me.CB_Aimkey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CB_Aimkey.FormattingEnabled = true
    Me.CB_Aimkey.Items.AddRange(New Object() {"Left Mousebutton", "Right Mousebutton", "Middle Mousebutton", "Mousebutton 4", "Mousebutton 5", "Left Shift", "Right Shift", "Left Ctrl", "Right Ctrl"})
    Me.CB_Aimkey.Location = New System.Drawing.Point(90, 129)
    Me.CB_Aimkey.Name = "CB_Aimkey"
    Me.CB_Aimkey.Size = New System.Drawing.Size(127, 21)
    Me.CB_Aimkey.TabIndex = 10
    '
    'Label3
    '
    Me.Label3.AutoSize = true
    Me.Label3.Depth = 0
    Me.Label3.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label3.Location = New System.Drawing.Point(6, 155)
    Me.Label3.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(43, 19)
    Me.Label3.TabIndex = 19
    Me.Label3.Text = "Bone"
    '
    'CB_Aimspot
    '
    Me.CB_Aimspot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CB_Aimspot.FormattingEnabled = true
    Me.CB_Aimspot.Items.AddRange(New Object() {"Head", "Neck", "Chest", "Stomach", "Dick"})
    Me.CB_Aimspot.Location = New System.Drawing.Point(90, 156)
    Me.CB_Aimspot.Name = "CB_Aimspot"
    Me.CB_Aimspot.Size = New System.Drawing.Size(76, 21)
    Me.CB_Aimspot.TabIndex = 12
    '
    'CB_AimMode
    '
    Me.CB_AimMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CB_AimMode.FormattingEnabled = true
    Me.CB_AimMode.Items.AddRange(New Object() {"Closest enemy", "Smallest FOV"})
    Me.CB_AimMode.Location = New System.Drawing.Point(90, 183)
    Me.CB_AimMode.Name = "CB_AimMode"
    Me.CB_AimMode.Size = New System.Drawing.Size(127, 21)
    Me.CB_AimMode.TabIndex = 18
    '
    'CB_Aimbot
    '
    Me.CB_Aimbot.AutoSize = true
    Me.CB_Aimbot.BackColor = System.Drawing.Color.White
    Me.CB_Aimbot.Depth = 0
    Me.CB_Aimbot.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_Aimbot.Location = New System.Drawing.Point(6, 7)
    Me.CB_Aimbot.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_Aimbot.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_Aimbot.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_Aimbot.Name = "CB_Aimbot"
    Me.CB_Aimbot.Ripple = true
    Me.CB_Aimbot.Size = New System.Drawing.Size(69, 30)
    Me.CB_Aimbot.TabIndex = 5
    Me.CB_Aimbot.Text = "Active"
    Me.CB_Aimbot.UseVisualStyleBackColor = false
    '
    'Label2
    '
    Me.Label2.AutoSize = true
    Me.Label2.Depth = 0
    Me.Label2.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label2.Location = New System.Drawing.Point(6, 182)
    Me.Label2.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(78, 19)
    Me.Label2.TabIndex = 17
    Me.Label2.Text = "Aim Mode"
    '
    'TP_Visuals
    '
    Me.TP_Visuals.BackColor = System.Drawing.Color.White
    Me.TP_Visuals.Controls.Add(Me.Label_Distance)
    Me.TP_Visuals.Controls.Add(Me.Label_DistanceInt)
    Me.TP_Visuals.Controls.Add(Me.TB_Distance)
    Me.TP_Visuals.Controls.Add(Me.CB_GHDistance)
    Me.TP_Visuals.Controls.Add(Me.CB_GHSound)
    Me.TP_Visuals.Controls.Add(Me.CB_NoSmoke)
    Me.TP_Visuals.Controls.Add(Me.CB_Glow_Weapons)
    Me.TP_Visuals.Controls.Add(Me.CB_Glow_Grenades)
    Me.TP_Visuals.Controls.Add(Me.CB_Glow_Bomb)
    Me.TP_Visuals.Controls.Add(Me.CB_Glow_Players)
    Me.TP_Visuals.Controls.Add(Me.CB_Glow_Chicken)
    Me.TP_Visuals.Controls.Add(Me.CB_GlowHack)
    Me.TP_Visuals.Controls.Add(Me.Glow_VB)
    Me.TP_Visuals.Controls.Add(Me.CB_Radar)
    Me.TP_Visuals.Controls.Add(Me.CB_NoFlash)
    Me.TP_Visuals.Location = New System.Drawing.Point(4, 22)
    Me.TP_Visuals.Name = "TP_Visuals"
    Me.TP_Visuals.Padding = New System.Windows.Forms.Padding(3)
    Me.TP_Visuals.Size = New System.Drawing.Size(404, 211)
    Me.TP_Visuals.TabIndex = 1
    Me.TP_Visuals.Text = "Visuals"
    '
    'Label_Distance
    '
    Me.Label_Distance.AutoSize = true
    Me.Label_Distance.Depth = 0
    Me.Label_Distance.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label_Distance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label_Distance.Location = New System.Drawing.Point(91, 97)
    Me.Label_Distance.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label_Distance.Name = "Label_Distance"
    Me.Label_Distance.Size = New System.Drawing.Size(68, 19)
    Me.Label_Distance.TabIndex = 34
    Me.Label_Distance.Text = "Distance"
    '
    'Label_DistanceInt
    '
    Me.Label_DistanceInt.AutoSize = true
    Me.Label_DistanceInt.Depth = 0
    Me.Label_DistanceInt.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label_DistanceInt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label_DistanceInt.Location = New System.Drawing.Point(203, 97)
    Me.Label_DistanceInt.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label_DistanceInt.Name = "Label_DistanceInt"
    Me.Label_DistanceInt.Size = New System.Drawing.Size(33, 19)
    Me.Label_DistanceInt.TabIndex = 33
    Me.Label_DistanceInt.Text = "450"
    '
    'TB_Distance
    '
    Me.TB_Distance.AutoSize = false
    Me.TB_Distance.BackColor = System.Drawing.SystemColors.ButtonFace
    Me.TB_Distance.LargeChange = 10
    Me.TB_Distance.Location = New System.Drawing.Point(87, 119)
    Me.TB_Distance.Maximum = 9600
    Me.TB_Distance.Minimum = 90
    Me.TB_Distance.Name = "TB_Distance"
    Me.TB_Distance.Size = New System.Drawing.Size(149, 17)
    Me.TB_Distance.TabIndex = 32
    Me.TB_Distance.TickFrequency = 10
    Me.TB_Distance.TickStyle = System.Windows.Forms.TickStyle.None
    Me.TB_Distance.Value = 450
    '
    'CB_GHDistance
    '
    Me.CB_GHDistance.AutoSize = true
    Me.CB_GHDistance.BackColor = System.Drawing.Color.White
    Me.CB_GHDistance.Depth = 0
    Me.CB_GHDistance.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_GHDistance.Location = New System.Drawing.Point(257, 106)
    Me.CB_GHDistance.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_GHDistance.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_GHDistance.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_GHDistance.Name = "CB_GHDistance"
    Me.CB_GHDistance.Ripple = true
    Me.CB_GHDistance.Size = New System.Drawing.Size(113, 30)
    Me.CB_GHDistance.TabIndex = 31
    Me.CB_GHDistance.Text = "max Distance"
    Me.CB_GHDistance.UseVisualStyleBackColor = false
    '
    'CB_GHSound
    '
    Me.CB_GHSound.AutoSize = true
    Me.CB_GHSound.BackColor = System.Drawing.Color.White
    Me.CB_GHSound.Depth = 0
    Me.CB_GHSound.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_GHSound.Location = New System.Drawing.Point(257, 7)
    Me.CB_GHSound.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_GHSound.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_GHSound.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_GHSound.Name = "CB_GHSound"
    Me.CB_GHSound.Ripple = true
    Me.CB_GHSound.Size = New System.Drawing.Size(134, 30)
    Me.CB_GHSound.TabIndex = 30
    Me.CB_GHSound.Text = "only when Sound"
    Me.CB_GHSound.UseVisualStyleBackColor = false
    '
    'CB_NoSmoke
    '
    Me.CB_NoSmoke.AutoSize = true
    Me.CB_NoSmoke.BackColor = System.Drawing.Color.White
    Me.CB_NoSmoke.Depth = 0
    Me.CB_NoSmoke.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_NoSmoke.Location = New System.Drawing.Point(110, 178)
    Me.CB_NoSmoke.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_NoSmoke.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_NoSmoke.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_NoSmoke.Name = "CB_NoSmoke"
    Me.CB_NoSmoke.Ripple = true
    Me.CB_NoSmoke.Size = New System.Drawing.Size(94, 30)
    Me.CB_NoSmoke.TabIndex = 29
    Me.CB_NoSmoke.Text = "No Smoke"
    Me.CB_NoSmoke.UseVisualStyleBackColor = false
    '
    'CB_Glow_Weapons
    '
    Me.CB_Glow_Weapons.AutoSize = true
    Me.CB_Glow_Weapons.BackColor = System.Drawing.Color.White
    Me.CB_Glow_Weapons.Depth = 0
    Me.CB_Glow_Weapons.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_Glow_Weapons.Location = New System.Drawing.Point(257, 67)
    Me.CB_Glow_Weapons.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_Glow_Weapons.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_Glow_Weapons.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_Glow_Weapons.Name = "CB_Glow_Weapons"
    Me.CB_Glow_Weapons.Ripple = true
    Me.CB_Glow_Weapons.Size = New System.Drawing.Size(87, 30)
    Me.CB_Glow_Weapons.TabIndex = 28
    Me.CB_Glow_Weapons.Text = "Weapons"
    Me.CB_Glow_Weapons.UseVisualStyleBackColor = false
    '
    'CB_Glow_Grenades
    '
    Me.CB_Glow_Grenades.AutoSize = true
    Me.CB_Glow_Grenades.BackColor = System.Drawing.Color.White
    Me.CB_Glow_Grenades.Depth = 0
    Me.CB_Glow_Grenades.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_Glow_Grenades.Location = New System.Drawing.Point(10, 37)
    Me.CB_Glow_Grenades.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_Glow_Grenades.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_Glow_Grenades.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_Glow_Grenades.Name = "CB_Glow_Grenades"
    Me.CB_Glow_Grenades.Ripple = true
    Me.CB_Glow_Grenades.Size = New System.Drawing.Size(89, 30)
    Me.CB_Glow_Grenades.TabIndex = 27
    Me.CB_Glow_Grenades.Text = "Grenades"
    Me.CB_Glow_Grenades.UseVisualStyleBackColor = false
    '
    'CB_Glow_Bomb
    '
    Me.CB_Glow_Bomb.AutoSize = true
    Me.CB_Glow_Bomb.BackColor = System.Drawing.Color.White
    Me.CB_Glow_Bomb.Depth = 0
    Me.CB_Glow_Bomb.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_Glow_Bomb.Location = New System.Drawing.Point(116, 67)
    Me.CB_Glow_Bomb.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_Glow_Bomb.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_Glow_Bomb.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_Glow_Bomb.Name = "CB_Glow_Bomb"
    Me.CB_Glow_Bomb.Ripple = true
    Me.CB_Glow_Bomb.Size = New System.Drawing.Size(66, 30)
    Me.CB_Glow_Bomb.TabIndex = 26
    Me.CB_Glow_Bomb.Text = "Bomb"
    Me.CB_Glow_Bomb.UseVisualStyleBackColor = false
    '
    'CB_Glow_Players
    '
    Me.CB_Glow_Players.AutoSize = true
    Me.CB_Glow_Players.BackColor = System.Drawing.Color.White
    Me.CB_Glow_Players.Depth = 0
    Me.CB_Glow_Players.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_Glow_Players.Location = New System.Drawing.Point(10, 67)
    Me.CB_Glow_Players.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_Glow_Players.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_Glow_Players.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_Glow_Players.Name = "CB_Glow_Players"
    Me.CB_Glow_Players.Ripple = true
    Me.CB_Glow_Players.Size = New System.Drawing.Size(76, 30)
    Me.CB_Glow_Players.TabIndex = 25
    Me.CB_Glow_Players.Text = "Players"
    Me.CB_Glow_Players.UseVisualStyleBackColor = false
    '
    'CB_Glow_Chicken
    '
    Me.CB_Glow_Chicken.AutoSize = true
    Me.CB_Glow_Chicken.BackColor = System.Drawing.Color.White
    Me.CB_Glow_Chicken.Depth = 0
    Me.CB_Glow_Chicken.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_Glow_Chicken.Location = New System.Drawing.Point(116, 37)
    Me.CB_Glow_Chicken.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_Glow_Chicken.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_Glow_Chicken.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_Glow_Chicken.Name = "CB_Glow_Chicken"
    Me.CB_Glow_Chicken.Ripple = true
    Me.CB_Glow_Chicken.Size = New System.Drawing.Size(79, 30)
    Me.CB_Glow_Chicken.TabIndex = 24
    Me.CB_Glow_Chicken.Text = "Chicken"
    Me.CB_Glow_Chicken.UseVisualStyleBackColor = false
    '
    'CB_GlowHack
    '
    Me.CB_GlowHack.AutoSize = true
    Me.CB_GlowHack.BackColor = System.Drawing.Color.White
    Me.CB_GlowHack.Depth = 0
    Me.CB_GlowHack.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_GlowHack.Location = New System.Drawing.Point(10, 7)
    Me.CB_GlowHack.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_GlowHack.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_GlowHack.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_GlowHack.Name = "CB_GlowHack"
    Me.CB_GlowHack.Ripple = true
    Me.CB_GlowHack.Size = New System.Drawing.Size(92, 30)
    Me.CB_GlowHack.TabIndex = 2
    Me.CB_GlowHack.Text = "GlowHack"
    Me.CB_GlowHack.UseVisualStyleBackColor = false
    '
    'Glow_VB
    '
    Me.Glow_VB.AutoSize = true
    Me.Glow_VB.BackColor = System.Drawing.Color.White
    Me.Glow_VB.Depth = 0
    Me.Glow_VB.Font = New System.Drawing.Font("Roboto", 10!)
    Me.Glow_VB.Location = New System.Drawing.Point(116, 7)
    Me.Glow_VB.Margin = New System.Windows.Forms.Padding(0)
    Me.Glow_VB.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.Glow_VB.MouseState = MaterialSkin.MouseState.HOVER
    Me.Glow_VB.Name = "Glow_VB"
    Me.Glow_VB.Ripple = true
    Me.Glow_VB.Size = New System.Drawing.Size(124, 30)
    Me.Glow_VB.TabIndex = 23
    Me.Glow_VB.Text = "Visibility Check"
    Me.Glow_VB.UseVisualStyleBackColor = false
    '
    'CB_Radar
    '
    Me.CB_Radar.AutoSize = true
    Me.CB_Radar.BackColor = System.Drawing.Color.White
    Me.CB_Radar.Depth = 0
    Me.CB_Radar.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_Radar.Location = New System.Drawing.Point(6, 148)
    Me.CB_Radar.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_Radar.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_Radar.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_Radar.Name = "CB_Radar"
    Me.CB_Radar.Ripple = true
    Me.CB_Radar.Size = New System.Drawing.Size(66, 30)
    Me.CB_Radar.TabIndex = 4
    Me.CB_Radar.Text = "Radar"
    Me.CB_Radar.UseVisualStyleBackColor = false
    '
    'CB_NoFlash
    '
    Me.CB_NoFlash.AutoSize = true
    Me.CB_NoFlash.BackColor = System.Drawing.Color.White
    Me.CB_NoFlash.Depth = 0
    Me.CB_NoFlash.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_NoFlash.Location = New System.Drawing.Point(6, 178)
    Me.CB_NoFlash.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_NoFlash.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_NoFlash.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_NoFlash.Name = "CB_NoFlash"
    Me.CB_NoFlash.Ripple = true
    Me.CB_NoFlash.Size = New System.Drawing.Size(84, 30)
    Me.CB_NoFlash.TabIndex = 0
    Me.CB_NoFlash.Text = "No Flash"
    Me.CB_NoFlash.UseVisualStyleBackColor = false
    '
    'TP_Misc
    '
    Me.TP_Misc.BackColor = System.Drawing.Color.White
    Me.TP_Misc.Controls.Add(Me.CB_TriggerKey)
    Me.TP_Misc.Controls.Add(Me.CB_FullAuto)
    Me.TP_Misc.Controls.Add(Me.Trigger_HB)
    Me.TP_Misc.Controls.Add(Me.Trigger_VC)
    Me.TP_Misc.Controls.Add(Me.CheckBox2)
    Me.TP_Misc.Controls.Add(Me.Label5)
    Me.TP_Misc.Controls.Add(Me.CB_Triggerbot)
    Me.TP_Misc.Controls.Add(Me.CB_FakeLag)
    Me.TP_Misc.Controls.Add(Me.CB_BunnyHop)
    Me.TP_Misc.Controls.Add(Me.CB_RCS)
    Me.TP_Misc.Location = New System.Drawing.Point(4, 22)
    Me.TP_Misc.Name = "TP_Misc"
    Me.TP_Misc.Padding = New System.Windows.Forms.Padding(3)
    Me.TP_Misc.Size = New System.Drawing.Size(404, 211)
    Me.TP_Misc.TabIndex = 2
    Me.TP_Misc.Text = "Misc"
    '
    'CB_FullAuto
    '
    Me.CB_FullAuto.AutoSize = true
    Me.CB_FullAuto.Depth = 0
    Me.CB_FullAuto.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_FullAuto.Location = New System.Drawing.Point(134, 100)
    Me.CB_FullAuto.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_FullAuto.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_FullAuto.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_FullAuto.Name = "CB_FullAuto"
    Me.CB_FullAuto.Ripple = true
    Me.CB_FullAuto.Size = New System.Drawing.Size(85, 30)
    Me.CB_FullAuto.TabIndex = 27
    Me.CB_FullAuto.Text = "Full Auto"
    Me.CB_FullAuto.UseVisualStyleBackColor = true
    '
    'Trigger_HB
    '
    Me.Trigger_HB.AutoSize = true
    Me.Trigger_HB.Depth = 0
    Me.Trigger_HB.Font = New System.Drawing.Font("Roboto", 10!)
    Me.Trigger_HB.Location = New System.Drawing.Point(274, 3)
    Me.Trigger_HB.Margin = New System.Windows.Forms.Padding(0)
    Me.Trigger_HB.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.Trigger_HB.MouseState = MaterialSkin.MouseState.HOVER
    Me.Trigger_HB.Name = "Trigger_HB"
    Me.Trigger_HB.Ripple = true
    Me.Trigger_HB.Size = New System.Drawing.Size(110, 30)
    Me.Trigger_HB.TabIndex = 26
    Me.Trigger_HB.Text = "Hitbox: Head"
    Me.Trigger_HB.UseVisualStyleBackColor = true
    '
    'Trigger_VC
    '
    Me.Trigger_VC.AutoSize = true
    Me.Trigger_VC.Depth = 0
    Me.Trigger_VC.Font = New System.Drawing.Font("Roboto", 10!)
    Me.Trigger_VC.Location = New System.Drawing.Point(274, 33)
    Me.Trigger_VC.Margin = New System.Windows.Forms.Padding(0)
    Me.Trigger_VC.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.Trigger_VC.MouseState = MaterialSkin.MouseState.HOVER
    Me.Trigger_VC.Name = "Trigger_VC"
    Me.Trigger_VC.Ripple = true
    Me.Trigger_VC.Size = New System.Drawing.Size(124, 30)
    Me.Trigger_VC.TabIndex = 25
    Me.Trigger_VC.Text = "Visibility Check"
    Me.Trigger_VC.UseVisualStyleBackColor = true
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = true
    Me.CheckBox2.Checked = true
    Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckBox2.Depth = 0
    Me.CheckBox2.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CheckBox2.Location = New System.Drawing.Point(134, 41)
    Me.CheckBox2.Margin = New System.Windows.Forms.Padding(0)
    Me.CheckBox2.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CheckBox2.MouseState = MaterialSkin.MouseState.HOVER
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Ripple = true
    Me.CheckBox2.Size = New System.Drawing.Size(121, 30)
    Me.CheckBox2.TabIndex = 22
    Me.CheckBox2.Text = "Ray Triggerbot"
    Me.CheckBox2.UseVisualStyleBackColor = true
    '
    'Label5
    '
    Me.Label5.AutoSize = true
    Me.Label5.Depth = 0
    Me.Label5.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label5.Location = New System.Drawing.Point(104, 15)
    Me.Label5.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(41, 19)
    Me.Label5.TabIndex = 21
    Me.Label5.Text = "Key: "
    '
    'CB_Triggerbot
    '
    Me.CB_Triggerbot.AutoSize = true
    Me.CB_Triggerbot.Depth = 0
    Me.CB_Triggerbot.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_Triggerbot.Location = New System.Drawing.Point(6, 7)
    Me.CB_Triggerbot.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_Triggerbot.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_Triggerbot.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_Triggerbot.Name = "CB_Triggerbot"
    Me.CB_Triggerbot.Ripple = true
    Me.CB_Triggerbot.Size = New System.Drawing.Size(95, 30)
    Me.CB_Triggerbot.TabIndex = 16
    Me.CB_Triggerbot.Text = "Triggerbot"
    Me.CB_Triggerbot.UseVisualStyleBackColor = true
    '
    'CB_FakeLag
    '
    Me.CB_FakeLag.AutoSize = true
    Me.CB_FakeLag.Depth = 0
    Me.CB_FakeLag.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_FakeLag.Location = New System.Drawing.Point(6, 178)
    Me.CB_FakeLag.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_FakeLag.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_FakeLag.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_FakeLag.Name = "CB_FakeLag"
    Me.CB_FakeLag.Ripple = true
    Me.CB_FakeLag.Size = New System.Drawing.Size(82, 30)
    Me.CB_FakeLag.TabIndex = 19
    Me.CB_FakeLag.Text = "FakeLag"
    Me.CB_FakeLag.UseVisualStyleBackColor = true
    '
    'CB_BunnyHop
    '
    Me.CB_BunnyHop.AutoSize = true
    Me.CB_BunnyHop.Depth = 0
    Me.CB_BunnyHop.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_BunnyHop.Location = New System.Drawing.Point(7, 100)
    Me.CB_BunnyHop.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_BunnyHop.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_BunnyHop.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_BunnyHop.Name = "CB_BunnyHop"
    Me.CB_BunnyHop.Ripple = true
    Me.CB_BunnyHop.Size = New System.Drawing.Size(94, 30)
    Me.CB_BunnyHop.TabIndex = 1
    Me.CB_BunnyHop.Text = "BunnyHop"
    Me.CB_BunnyHop.UseVisualStyleBackColor = true
    '
    'CB_RCS
    '
    Me.CB_RCS.AutoSize = true
    Me.CB_RCS.Depth = 0
    Me.CB_RCS.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_RCS.Location = New System.Drawing.Point(6, 139)
    Me.CB_RCS.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_RCS.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_RCS.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_RCS.Name = "CB_RCS"
    Me.CB_RCS.Ripple = true
    Me.CB_RCS.Size = New System.Drawing.Size(56, 30)
    Me.CB_RCS.TabIndex = 15
    Me.CB_RCS.Text = "RCS"
    Me.CB_RCS.UseVisualStyleBackColor = true
    '
    'TP_Skinchanger
    '
    Me.TP_Skinchanger.BackColor = System.Drawing.Color.White
    Me.TP_Skinchanger.Controls.Add(Me.CB_KnifeChanger)
    Me.TP_Skinchanger.Controls.Add(Me.CB_SkinChanger)
    Me.TP_Skinchanger.Controls.Add(Me.TB_Kills)
    Me.TP_Skinchanger.Controls.Add(Me.Label8)
    Me.TP_Skinchanger.Controls.Add(Me.CB_Weapons)
    Me.TP_Skinchanger.Controls.Add(Me.Label7)
    Me.TP_Skinchanger.Controls.Add(Me.Label6)
    Me.TP_Skinchanger.Controls.Add(Me.CB_SkinId)
    Me.TP_Skinchanger.Location = New System.Drawing.Point(4, 22)
    Me.TP_Skinchanger.Name = "TP_Skinchanger"
    Me.TP_Skinchanger.Padding = New System.Windows.Forms.Padding(3)
    Me.TP_Skinchanger.Size = New System.Drawing.Size(404, 211)
    Me.TP_Skinchanger.TabIndex = 3
    Me.TP_Skinchanger.Text = "Skinchanger"
    '
    'CB_KnifeChanger
    '
    Me.CB_KnifeChanger.AutoSize = true
    Me.CB_KnifeChanger.Depth = 0
    Me.CB_KnifeChanger.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_KnifeChanger.Location = New System.Drawing.Point(6, 42)
    Me.CB_KnifeChanger.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_KnifeChanger.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_KnifeChanger.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_KnifeChanger.Name = "CB_KnifeChanger"
    Me.CB_KnifeChanger.Ripple = true
    Me.CB_KnifeChanger.Size = New System.Drawing.Size(114, 30)
    Me.CB_KnifeChanger.TabIndex = 26
    Me.CB_KnifeChanger.Text = "KnifeChanger"
    Me.CB_KnifeChanger.UseVisualStyleBackColor = true
    '
    'CB_SkinChanger
    '
    Me.CB_SkinChanger.AutoSize = true
    Me.CB_SkinChanger.Depth = 0
    Me.CB_SkinChanger.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_SkinChanger.Location = New System.Drawing.Point(6, 7)
    Me.CB_SkinChanger.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_SkinChanger.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_SkinChanger.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_SkinChanger.Name = "CB_SkinChanger"
    Me.CB_SkinChanger.Ripple = true
    Me.CB_SkinChanger.Size = New System.Drawing.Size(69, 30)
    Me.CB_SkinChanger.TabIndex = 25
    Me.CB_SkinChanger.Text = "Active"
    Me.CB_SkinChanger.UseVisualStyleBackColor = true
    '
    'TB_Kills
    '
    Me.TB_Kills.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    Me.TB_Kills.Depth = 0
    Me.TB_Kills.Hint = ""
    Me.TB_Kills.Location = New System.Drawing.Point(277, 86)
    Me.TB_Kills.MaxLength = 32767
    Me.TB_Kills.MouseState = MaterialSkin.MouseState.HOVER
    Me.TB_Kills.Name = "TB_Kills"
    Me.TB_Kills.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
    Me.TB_Kills.SelectedText = ""
    Me.TB_Kills.SelectionLength = 0
    Me.TB_Kills.SelectionStart = 0
    Me.TB_Kills.Size = New System.Drawing.Size(78, 23)
    Me.TB_Kills.TabIndex = 24
    Me.TB_Kills.TabStop = false
    Me.TB_Kills.UseSystemPasswordChar = false
    '
    'Label8
    '
    Me.Label8.AutoSize = true
    Me.Label8.Depth = 0
    Me.Label8.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label8.Location = New System.Drawing.Point(208, 12)
    Me.Label8.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(63, 19)
    Me.Label8.TabIndex = 13
    Me.Label8.Text = "Weapon"
    '
    'CB_Weapons
    '
    Me.CB_Weapons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CB_Weapons.FormattingEnabled = true
    Me.CB_Weapons.Location = New System.Drawing.Point(277, 12)
    Me.CB_Weapons.Name = "CB_Weapons"
    Me.CB_Weapons.Size = New System.Drawing.Size(121, 21)
    Me.CB_Weapons.TabIndex = 12
    '
    'Label7
    '
    Me.Label7.AutoSize = true
    Me.Label7.Depth = 0
    Me.Label7.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label7.Location = New System.Drawing.Point(208, 86)
    Me.Label7.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(38, 19)
    Me.Label7.TabIndex = 4
    Me.Label7.Text = "Kills"
    '
    'Label6
    '
    Me.Label6.AutoSize = true
    Me.Label6.Depth = 0
    Me.Label6.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label6.Location = New System.Drawing.Point(208, 47)
    Me.Label6.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(56, 19)
    Me.Label6.TabIndex = 3
    Me.Label6.Text = "Skin ID"
    '
    'CB_SkinId
    '
    Me.CB_SkinId.FormattingEnabled = true
    Me.CB_SkinId.Location = New System.Drawing.Point(277, 47)
    Me.CB_SkinId.Name = "CB_SkinId"
    Me.CB_SkinId.Size = New System.Drawing.Size(78, 21)
    Me.CB_SkinId.TabIndex = 2
    '
    'DGV_EnemyInfo
    '
    Me.DGV_EnemyInfo.AllowUserToAddRows = false
    Me.DGV_EnemyInfo.AllowUserToDeleteRows = false
    Me.DGV_EnemyInfo.AllowUserToResizeColumns = false
    Me.DGV_EnemyInfo.AllowUserToResizeRows = false
    Me.DGV_EnemyInfo.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DGV_EnemyInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.DGV_EnemyInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DGV_EnemyInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Player_PlayerId, Me.Player_Name, Me.Player_Distance, Me.Player_Health, Me.Player_Weapon, Me.Player_Wins, Me.Player_Rank})
    Me.DGV_EnemyInfo.GridColor = System.Drawing.SystemColors.Control
    Me.DGV_EnemyInfo.Location = New System.Drawing.Point(20, 361)
    Me.DGV_EnemyInfo.Name = "DGV_EnemyInfo"
    Me.DGV_EnemyInfo.RowHeadersVisible = false
    Me.DGV_EnemyInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
    Me.DGV_EnemyInfo.Size = New System.Drawing.Size(408, 182)
    Me.DGV_EnemyInfo.TabIndex = 0
    '
    'Player_PlayerId
    '
    Me.Player_PlayerId.HeaderText = "ID"
    Me.Player_PlayerId.Name = "Player_PlayerId"
    Me.Player_PlayerId.ReadOnly = true
    Me.Player_PlayerId.Width = 30
    '
    'Player_Name
    '
    Me.Player_Name.HeaderText = "Name"
    Me.Player_Name.Name = "Player_Name"
    Me.Player_Name.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
    Me.Player_Name.Width = 80
    '
    'Player_Distance
    '
    Me.Player_Distance.HeaderText = "Distance"
    Me.Player_Distance.Name = "Player_Distance"
    Me.Player_Distance.Width = 55
    '
    'Player_Health
    '
    Me.Player_Health.HeaderText = "HP"
    Me.Player_Health.Name = "Player_Health"
    Me.Player_Health.Width = 30
    '
    'Player_Weapon
    '
    Me.Player_Weapon.HeaderText = "Weapon"
    Me.Player_Weapon.Name = "Player_Weapon"
    Me.Player_Weapon.Width = 80
    '
    'Player_Wins
    '
    Me.Player_Wins.HeaderText = "Wins"
    Me.Player_Wins.Name = "Player_Wins"
    Me.Player_Wins.Width = 40
    '
    'Player_Rank
    '
    Me.Player_Rank.HeaderText = "Rank"
    Me.Player_Rank.Name = "Player_Rank"
    Me.Player_Rank.Width = 90
    '
    'CB_GetEnemyInfo
    '
    Me.CB_GetEnemyInfo.AutoSize = true
    Me.CB_GetEnemyInfo.Depth = 0
    Me.CB_GetEnemyInfo.Font = New System.Drawing.Font("Roboto", 10!)
    Me.CB_GetEnemyInfo.Location = New System.Drawing.Point(20, 554)
    Me.CB_GetEnemyInfo.Margin = New System.Windows.Forms.Padding(0)
    Me.CB_GetEnemyInfo.MouseLocation = New System.Drawing.Point(-1, -1)
    Me.CB_GetEnemyInfo.MouseState = MaterialSkin.MouseState.HOVER
    Me.CB_GetEnemyInfo.Name = "CB_GetEnemyInfo"
    Me.CB_GetEnemyInfo.Ripple = true
    Me.CB_GetEnemyInfo.Size = New System.Drawing.Size(198, 30)
    Me.CB_GetEnemyInfo.TabIndex = 9
    Me.CB_GetEnemyInfo.Text = "Refresh Enemy Information"
    Me.CB_GetEnemyInfo.UseVisualStyleBackColor = true
    '
    'Label9
    '
    Me.Label9.AutoSize = true
    Me.Label9.BackColor = System.Drawing.Color.Transparent
    Me.Label9.Depth = 0
    Me.Label9.Font = New System.Drawing.Font("Roboto", 11!)
    Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
    Me.Label9.Location = New System.Drawing.Point(132, 33)
    Me.Label9.MouseState = MaterialSkin.MouseState.HOVER
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(178, 19)
    Me.Label9.TabIndex = 21
    Me.Label9.Text = "Not conntected to CSGO!"
    '
    'MaterialTabSelector2
    '
    Me.MaterialTabSelector2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    Me.MaterialTabSelector2.BaseTabControl = Me.TabControl1
    Me.MaterialTabSelector2.Depth = 0
    Me.MaterialTabSelector2.Location = New System.Drawing.Point(0, 55)
    Me.MaterialTabSelector2.MouseState = MaterialSkin.MouseState.HOVER
    Me.MaterialTabSelector2.Name = "MaterialTabSelector2"
    Me.MaterialTabSelector2.Size = New System.Drawing.Size(435, 59)
    Me.MaterialTabSelector2.TabIndex = 22
    Me.MaterialTabSelector2.Text = "MaterialTabSelector2"
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(379, 557)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(49, 23)
    Me.Button1.TabIndex = 23
    Me.Button1.Text = "Rage"
    Me.Button1.UseVisualStyleBackColor = true
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(324, 557)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(49, 23)
    Me.Button2.TabIndex = 24
    Me.Button2.Text = "Legit"
    Me.Button2.UseVisualStyleBackColor = true
    '
    'Timer1
    '
    Me.Timer1.Enabled = true
    Me.Timer1.Interval = 1000
    '
    'CB_TriggerKey
    '
    Me.CB_TriggerKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CB_TriggerKey.FormattingEnabled = true
    Me.CB_TriggerKey.Items.AddRange(New Object() {"Left Mousebutton", "Right Mousebutton", "Middle Mousebutton", "Mousebutton 4", "Mousebutton 5", "Left Shift", "Right Shift", "Left Ctrl", "Right Ctrl"})
    Me.CB_TriggerKey.Location = New System.Drawing.Point(144, 13)
    Me.CB_TriggerKey.Name = "CB_TriggerKey"
    Me.CB_TriggerKey.Size = New System.Drawing.Size(127, 21)
    Me.CB_TriggerKey.TabIndex = 28
    '
    'Hack
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.ButtonFace
    Me.ClientSize = New System.Drawing.Size(435, 593)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.MaterialTabSelector2)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.DGV_EnemyInfo)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.CB_GetEnemyInfo)
    Me.MaximizeBox = false
    Me.Name = "Hack"
    Me.Sizable = false
    Me.TabControl1.ResumeLayout(false)
    Me.TP_Aimbot.ResumeLayout(false)
    Me.TP_Aimbot.PerformLayout
    CType(Me.TB_Smooth,System.ComponentModel.ISupportInitialize).EndInit
    CType(Me.TB_FOV,System.ComponentModel.ISupportInitialize).EndInit
    Me.TP_Visuals.ResumeLayout(false)
    Me.TP_Visuals.PerformLayout
    CType(Me.TB_Distance,System.ComponentModel.ISupportInitialize).EndInit
    Me.TP_Misc.ResumeLayout(false)
    Me.TP_Misc.PerformLayout
    Me.TP_Skinchanger.ResumeLayout(false)
    Me.TP_Skinchanger.PerformLayout
    CType(Me.DGV_EnemyInfo,System.ComponentModel.ISupportInitialize).EndInit
    Me.ResumeLayout(false)
    Me.PerformLayout

End Sub
  Friend WithEvents DGV_EnemyInfo As DataGridView
  Friend WithEvents TB_FOV As TrackBar
  Friend WithEvents CB_Aimkey As ComboBox
  Friend WithEvents CB_Aimspot As ComboBox
  Friend WithEvents CB_AimMode As ComboBox
  Friend WithEvents TP_Aimbot As TabPage
  Friend WithEvents TP_Visuals As TabPage
  Friend WithEvents TP_Misc As TabPage
  Friend WithEvents TP_Skinchanger As TabPage
  Friend WithEvents CB_SkinId As ComboBox
  Friend WithEvents CB_Weapons As ComboBox
  Friend WithEvents Label2 As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents Label_FOV As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents TabControl1 As MaterialSkin.Controls.MaterialTabControl
  Friend WithEvents Label4 As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents Label3 As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents Label7 As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents Label6 As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents Label8 As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents Label1 As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents Label5 As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents CB_NoFlash As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_BunnyHop As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_GlowHack As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_Radar As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_GetEnemyInfo As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_Aimbot As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_RCS As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_Triggerbot As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_FakeLag As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_SilentAim As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_VisibilityCheck As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CheckBox2 As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents Label9 As MaterialSkin.Controls.MaterialLabel
  Private WithEvents MaterialTabSelector2 As MaterialSkin.Controls.MaterialTabSelector
  Private WithEvents TB_Kills As MaterialSkin.Controls.MaterialSingleLineTextField
  Friend WithEvents Glow_VB As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents Trigger_VC As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents Trigger_HB As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_SkinChanger As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents Label_Smooth As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents TB_Smooth As TrackBar
  Friend WithEvents CB_FullAuto As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents Player_PlayerId As DataGridViewTextBoxColumn
  Friend WithEvents Player_Name As DataGridViewTextBoxColumn
  Friend WithEvents Player_Distance As DataGridViewTextBoxColumn
  Friend WithEvents Player_Health As DataGridViewTextBoxColumn
  Friend WithEvents Player_Weapon As DataGridViewTextBoxColumn
  Friend WithEvents Player_Wins As DataGridViewTextBoxColumn
  Friend WithEvents Player_Rank As DataGridViewTextBoxColumn
  Friend WithEvents Button1 As Button
  Friend WithEvents Button2 As Button
  Friend WithEvents CB_Glow_Grenades As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_Glow_Bomb As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_Glow_Players As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_Glow_Chicken As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_Glow_Weapons As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_NoSmoke As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_KnifeChanger As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents Timer1 As Timer
  Friend WithEvents CB_GHDistance As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents CB_GHSound As MaterialSkin.Controls.MaterialCheckBox
  Friend WithEvents Label_Distance As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents Label_DistanceInt As MaterialSkin.Controls.MaterialLabel
  Friend WithEvents TB_Distance As TrackBar
  Friend WithEvents CB_TriggerKey As ComboBox
End Class
