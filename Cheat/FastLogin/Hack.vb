Imports System.IO
Imports System.Threading
Imports FastLogin.Features
Imports FastLogin.Important
Imports Portable.Licensing
Imports MaterialSkin

Public Class Hack
  Public Declare Function GetAsyncKeyState Lib "user32" (vKey As Integer) As Integer
  Public Shared BspMap As Bsp
  Public Delegate Sub AppendTextBoxDelegate(ByVal TB As TextBox, ByVal txt As String)

  Public Sub AppendTextBox(ByVal TB As TextBox, ByVal txt As String)
    If TB.InvokeRequired Then
      TB.Invoke(New AppendTextBoxDelegate(AddressOf AppendTextBox), New Object() {TB, txt})
    Else
      TB.AppendText(txt)
    End If
  End Sub
  Private Sub EnemyInfo()
    Dim playerIdList As New List(Of Integer)
    While Settings.EnemyInfo

      For Each enemy In Utils.GetValidEnemies()
        If Not playerIdList.Contains(enemy.PlayerId) Then
          playerIdList.Add(enemy.PlayerId)
          Dim row = {enemy.PlayerId, enemy.Name, Utils.UnitsToMeter(enemy.Distance), enemy.Health, enemy.WeaponName, enemy.Wins, enemy.Rank}
          DGV_EnemyInfo.Invoke(Sub() DGV_EnemyInfo.Rows.Add(row))
        Else
          For Each row As DataGridViewRow In DGV_EnemyInfo.Rows
            If row.Cells(0).Value = enemy.PlayerId Then
              Dim newRow = {enemy.PlayerId, enemy.Name, Utils.UnitsToMeter(enemy.Distance), enemy.Health, enemy.WeaponName, enemy.Wins, enemy.Rank}
              DGV_EnemyInfo.Invoke(Sub() DGV_EnemyInfo.Rows.Item(row.Index).Cells.Item(0).Value = newRow(0))
              DGV_EnemyInfo.Invoke(Sub() DGV_EnemyInfo.Rows.Item(row.Index).Cells.Item(1).Value = newRow(1))
              DGV_EnemyInfo.Invoke(Sub() DGV_EnemyInfo.Rows.Item(row.Index).Cells.Item(2).Value = newRow(2))
              DGV_EnemyInfo.Invoke(Sub() DGV_EnemyInfo.Rows.Item(row.Index).Cells.Item(3).Value = newRow(3))
              DGV_EnemyInfo.Invoke(Sub() DGV_EnemyInfo.Rows.Item(row.Index).Cells.Item(4).Value = newRow(4))
              DGV_EnemyInfo.Invoke(Sub() DGV_EnemyInfo.Rows.Item(row.Index).Cells.Item(5).Value = newRow(5))
            End If
          Next
        End If

      Next
      Thread.Sleep(20)
    End While
    DGV_EnemyInfo.Rows.Clear()
  End Sub

  Private Sub Hack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim materialSkinManager = MaterialSkin.MaterialSkinManager.Instance
    materialSkinManager.AddFormToManage(Me)

    materialSkinManager.Theme = MaterialSkinManager.Themes.DARK
    materialSkinManager.ColorScheme = New ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)

    While True
      If Process.TryAttachToProcess("Counter-Strike: Global Offensive") Then
        MemEdit.SetProcessHandle(Process.GetHandle())
        Process.InitializeModules()
        Offsets.SetOffsets()

        Dim task = New Task(AddressOf Player.SetLocal)
        task.Start()

        Label9.Text = "Conntected to CSGO!"
        Label9.ForeColor = Color.Green
        Dim bspTask = New Task(AddressOf LoadBsp)
        bspTask.Start()
        Exit While
      End If
      Thread.Sleep(1000)
    End While

    If (License.type = LicenseType.Trial) Then CB_Aimbot.Enabled = False
    Label_FOV.Text = TB_FOV.Value
    Settings.FovValue = Convert.ToSingle(TB_FOV.Value)
    Settings.AimbotKey = Keys.XButton1
    Settings.BoneId = 8
    CB_Aimkey.Text = "Mousebutton 4"
    CB_Aimspot.Text = "Head"
    CB_AimMode.Text = "Closest enemy"
    CB_Glow_Players.Checked = True
    CB_TriggerKey.Text = "Mousebutton 4"
  End Sub
  Private Sub CB_NoFlash_CheckedChanged(sender As Object, e As EventArgs) Handles CB_NoFlash.CheckedChanged
    Settings.NoFlash = CB_NoFlash.Checked

    If CB_NoFlash.Checked Then
      Dim noflashTask = New Task(AddressOf Miscellaneous.NoFlash)
      noflashTask.Start()
    End If
  End Sub

  Private Sub CB_BunnyHop_CheckedChanged(sender As Object, e As EventArgs) Handles CB_BunnyHop.CheckedChanged
    Settings.BunnyHop = CB_BunnyHop.Checked

    If CB_BunnyHop.Checked Then
      Dim bunnyHopTask = New Task(AddressOf Miscellaneous.Bunnyhop)
      bunnyHopTask.Start()
    End If
  End Sub

  Private Sub CB_GlowHack_CheckedChanged(sender As Object, e As EventArgs) Handles CB_GlowHack.CheckedChanged
    Settings.Glow = CB_GlowHack.Checked

    If CB_GlowHack.Checked Then
      Dim glowhackTask = New Task(AddressOf GlowManager.GlowHack)
      glowhackTask.Start()
    End If
  End Sub

  Private Sub CB_Radar_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Radar.CheckedChanged
    Settings.Radar = CB_Radar.Checked

    If CB_Radar.Checked Then
      Dim radarTask = New Task(AddressOf Miscellaneous.Radar)
      radarTask.Start()
    End If
  End Sub

  Private Sub CB_GetEnemyInfo_CheckedChanged(sender As Object, e As EventArgs) Handles CB_GetEnemyInfo.CheckedChanged
    Settings.EnemyInfo = CB_GetEnemyInfo.Checked

    If CB_GetEnemyInfo.Checked Then
      Dim enemyInfoTask = New Task(AddressOf EnemyInfo)
      enemyInfoTask.Start()
    Else
      DGV_EnemyInfo.Rows.Clear()
    End If
  End Sub

  Private Sub CB_Aimbot_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Aimbot.CheckedChanged
    Settings.AimBot = CB_Aimbot.Checked

    If CB_Aimbot.Checked Then
      Dim aimbotTask = New Task(AddressOf Aimbot.Aimbot)
      aimbotTask.Start()
    End If
  End Sub

  Private Sub CB_SilentAim_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SilentAim.CheckedChanged
    If CB_SilentAim.Checked Then
      Settings.AimBotMode = 2
      CB_Aimkey.Text = "Left Mousebutton"
      Settings.AimbotKey = Keys.LButton
      CB_Aimkey.Enabled = False
    Else
      Settings.AimBotMode = 1
      CB_Aimkey.Enabled = True
    End If
  End Sub

  Private Sub CB_RCS_CheckedChanged(sender As Object, e As EventArgs) Handles CB_RCS.CheckedChanged
    Settings.Rcs = CB_RCS.Checked

    If CB_RCS.Checked Then
      Dim rcsTask = New Task(AddressOf Miscellaneous.RecoilControlSystem)
      rcsTask.Start()
    End If
  End Sub

  Private Sub CB_Triggerbot_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Triggerbot.CheckedChanged
    Settings.TriggerBot = CB_Triggerbot.Checked

    If CB_Triggerbot.Checked Then
      Dim triggerbotTask = New Task(AddressOf newTriggerbot.newTriggerbot)
      triggerbotTask.Start()
    End If
  End Sub

  Private Sub CB_FakeLag_CheckedChanged(sender As Object, e As EventArgs) Handles CB_FakeLag.CheckedChanged
    Settings.FakeLag = CB_FakeLag.Checked

    If CB_FakeLag.Checked Then
      Dim fakelagTask = New Task(AddressOf Miscellaneous.FakeLag)
      fakelagTask.Start()
    End If
  End Sub

  Private Sub TB_FOV_ValueChanged(sender As Object, e As EventArgs) Handles TB_FOV.ValueChanged
    Settings.FovValue = TB_FOV.Value
    Label_FOV.Text = TB_FOV.Value
  End Sub
  Private Sub CB_AimMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_AimMode.SelectedIndexChanged
    Settings.AimBotTargetMode = CB_AimMode.SelectedIndex + 1
  End Sub

  Private Sub CB_Aimspot_TextChanged(sender As Object, e As EventArgs) Handles CB_Aimspot.TextChanged
    Select Case CB_Aimspot.Text
      Case "Head"
        Settings.BoneId = 8
      Case "Neck"
        Settings.BoneId = 7
      Case "Chest"
        Settings.BoneId = 6
      Case "Stomach"
        Settings.BoneId = 4
      Case "Dick"
        Settings.BoneId = 77
    End Select
  End Sub

  Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles CB_Aimkey.TextChanged
    Select Case CB_Aimkey.Text
      Case "Left Mousebutton"
        Settings.AimbotKey = Keys.LButton
      Case "Right Mousebutton"
        Settings.AimbotKey = Keys.RButton
      Case "Middle Mousebutton"
        Settings.AimbotKey = Keys.MButton
      Case "Mousebutton 4"
        Settings.AimbotKey = Keys.XButton1
      Case "Mousebutton 5"
        Settings.AimbotKey = Keys.XButton2
      Case "Left Shift"
        Settings.AimbotKey = Keys.LShiftKey
      Case "Right Shift"
        Settings.AimbotKey = Keys.RShiftKey
      Case "Left Ctrl"
        Settings.AimbotKey = Keys.LControlKey
      Case "Right Ctrl"
        Settings.AimbotKey = Keys.RControlKey
    End Select
  End Sub

  Private Sub CB_VisibilityCheck_CheckedChanged(sender As Object, e As EventArgs) Handles CB_VisibilityCheck.CheckedChanged
    Settings.OnlyAimOnVisible = CB_VisibilityCheck.Checked
  End Sub

  Private Shared Sub LoadBsp()
    Dim stream As FileStream
    Dim mapDirectory = MemEdit.ReadAsciiString(Offsets.ClientState + Offsets.dwClientState_MapDirectory, 50)
    If mapDirectory <> "" Then
      stream = File.OpenRead("C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\csgo\" & mapDirectory)
      BspMap = New Bsp(stream)
    End If

    While True
      Dim temp = MemEdit.ReadAsciiString(Offsets.ClientState + Offsets.dwClientState_MapDirectory, 50)
      If temp <> mapDirectory AndAlso Not temp = "" Then
        mapDirectory = temp
        stream = File.OpenRead("C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\csgo\" & mapDirectory)
        BspMap = New Bsp(stream)
      End If
      Thread.Sleep(1000)
    End While
  End Sub

  Private Shared Sub Hack_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    Process.DetachFromProcess()
  End Sub
  Private Sub Glow_VB_CheckedChanged(sender As Object, e As EventArgs) Handles Glow_VB.CheckedChanged
    Settings.OnlyGlowOnVisible = Glow_VB.Checked
  End Sub

  Private Sub Trigger_VC_CheckedChanged(sender As Object, e As EventArgs) Handles Trigger_VC.CheckedChanged
    Settings.TriggerOnVsibile = Trigger_VC.Checked
  End Sub

  Private Sub Trigger_HB_CheckedChanged(sender As Object, e As EventArgs) Handles Trigger_HB.CheckedChanged
    Settings.TriggerHead = Trigger_HB.Checked
  End Sub

  Private Sub CB_SkinChanger_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SkinChanger.CheckedChanged
    Settings.SkinChanger = CB_SkinChanger.Checked

    If CB_SkinChanger.Checked Then
      Dim skinChangerTask = New Task(AddressOf Skinchanger.Skinchanger)
      skinChangerTask.Start()
    End If
  End Sub

  Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TB_Smooth.ValueChanged
    Settings.SmoothValue = TB_Smooth.Value * 10
    Label_Smooth.Text = TB_Smooth.Value
  End Sub

  Private Sub CB_AutoPistol_CheckedChanged(sender As Object, e As EventArgs) Handles CB_FullAuto.CheckedChanged
    Settings.FullAuto = CB_FullAuto.Checked

    If CB_FullAuto.Checked Then
      Dim fullAutoTask = New Task(AddressOf Miscellaneous.FullAuto)
      fullAutoTask.Start()
    End If
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    CB_FullAuto.Checked = True
    CB_BunnyHop.Checked = True
    CB_NoFlash.Checked = True
    CB_Radar.Checked = True
    CB_SkinChanger.Checked = True
    CB_GlowHack.Checked = True
    Glow_VB.Checked = True
    CB_Aimbot.Checked = True
    CB_AimMode.SelectedIndex = 1
    TB_FOV.Value = 20
    CB_GetEnemyInfo.Checked = True
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    CB_FullAuto.Checked = True
    CB_Radar.Checked = True
    CB_SkinChanger.Checked = True
    CB_Aimbot.Checked = True
    CB_VisibilityCheck.Checked = True
    CB_AimMode.SelectedIndex = 1
    CB_SilentAim.Checked = True
    TB_FOV.Value = 1
    CB_GetEnemyInfo.Checked = True
  End Sub

  Private Sub CB_Glow_Chicken_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Glow_Chicken.CheckedChanged
    Settings.GlowChicken = CB_Glow_Chicken.Checked
  End Sub

  Private Sub CB_Glow_Grenades_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Glow_Grenades.CheckedChanged
    Settings.GlowGrenades = CB_Glow_Grenades.Checked
  End Sub

  Private Sub CB_Glow_Bomb_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Glow_Bomb.CheckedChanged
    Settings.GlowBomb = CB_Glow_Bomb.Checked
  End Sub

  Private Sub CB_Glow_Players_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Glow_Players.CheckedChanged
    Settings.GlowPlayers = CB_Glow_Players.Checked
  End Sub

  Private Sub CB_Glow_Weapons_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Glow_Weapons.CheckedChanged
    Settings.GlowWeapons = CB_Glow_Weapons.Checked
  End Sub

  Private Sub CB_NoSmoke_CheckedChanged(sender As Object, e As EventArgs) Handles CB_NoSmoke.CheckedChanged
    Settings.NoSmoke = CB_NoSmoke.Checked

    If CB_NoSmoke.Checked Then
      Dim nosmokeTask = New Task(AddressOf Miscellaneous.NoSmoke)
      nosmokeTask.Start()
    End If
  End Sub

  Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
    If CheckBox2.Checked Then
      Settings.TriggerMode = 1
    Else
      Settings.TriggerMode = 0
    End If
  End Sub

  Private Sub MaterialCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CB_KnifeChanger.CheckedChanged
    Settings.KnifeChanger = CB_KnifeChanger.Checked

    If CB_KnifeChanger.Checked Then
      Dim knifechangerTask = New Task(AddressOf KnifeChanger.KnifeChanger)
      knifechangerTask.Start()
    End If
  End Sub

  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    If GetAsyncKeyState(Keys.Insert) Then
      If (Settings.AimBot) Then
        Settings.AimBot = False
        CB_Aimbot.Checked = False
      Else
        Settings.AimBot = True
        CB_Aimbot.Checked = True
      End If
    End If
  End Sub

  Private Sub CB_GHSound_CheckedChanged(sender As Object, e As EventArgs) Handles CB_GHSound.CheckedChanged
    Settings.GlowSound = CB_GHSound.Checked
  End Sub

  Private Sub CB_GHDistance_CheckedChanged(sender As Object, e As EventArgs) Handles CB_GHDistance.CheckedChanged
    Settings.GlowMaxDistanceBool = CB_GHDistance.Checked
  End Sub

  Private Sub TB_Distance_ValueChanged(sender As Object, e As EventArgs) Handles TB_Distance.ValueChanged
    Settings.GlowMaxDistance = TB_Distance.Value
    Label_DistanceInt.Text = TB_Distance.Value
  End Sub

  Private Sub CB_TriggerKey_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_TriggerKey.SelectedIndexChanged
    Select Case CB_TriggerKey.Text
      Case "Left Mousebutton"
        Settings.TriggerKey = Keys.LButton
      Case "Right Mousebutton"
        Settings.TriggerKey = Keys.RButton
      Case "Middle Mousebutton"
        Settings.TriggerKey = Keys.MButton
      Case "Mousebutton 4"
        Settings.TriggerKey = Keys.XButton1
      Case "Mousebutton 5"
        Settings.TriggerKey = Keys.XButton2
      Case "Left Shift"
        Settings.TriggerKey = Keys.LShiftKey
      Case "Right Shift"
        Settings.TriggerKey = Keys.RShiftKey
      Case "Left Ctrl"
        Settings.TriggerKey = Keys.LControlKey
      Case "Right Ctrl"
        Settings.TriggerKey = Keys.RControlKey
    End Select
  End Sub
End Class