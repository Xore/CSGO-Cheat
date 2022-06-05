Imports System.Threading

Namespace Important

  Public Class Utils
    Public Declare Function GetAsyncKeyState Lib "user32" (vKey As Integer) As Integer
    Public Shared Function GetDistance(myVector As FVector, enemyVector As FVector) As Single
      Dim xVector = enemyVector.X - myVector.X
      Dim yVector = enemyVector.Y - myVector.Y
      Dim zVector = enemyVector.Z - myVector.Z
      Return Math.Sqrt(xVector * xVector + yVector * yVector + zVector * zVector)
    End Function

    Public Shared Function UnitsToMeter(units As Single) As Single
      Return (units * 1.905) / 100
    End Function

    Public Shared Function CalcAngle(playerPosition As FVector, enemyPosition As FVector) As FVector
      Dim delta = New FVector(playerPosition.X - enemyPosition.X, playerPosition.Y - enemyPosition.Y, (playerPosition.Z + Player.Local.ViewOffset.Z) - enemyPosition.Z)
      Dim hyp As Single = Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y)

      Dim aimAngle As New FVector
      aimAngle.X = Math.Atan(delta.Z / hyp) * 57.29578F
      aimAngle.Y = Math.Atan(delta.Y / delta.X) * 57.29578F
      aimAngle.Z = 0

      If delta.X >= 0.0 Then aimAngle.Y += 180.0F
      NormalizeAngle(aimAngle)
      Return aimAngle
    End Function
    Public Shared Function IsPistol() As Boolean
      Select Case Player.Local.WeaponId()
        Case Pistols.Desert_Eagle, Pistols.Dual_Berettas, Pistols.Five_Seven, Pistols.Glock_18, Pistols.P2000, Pistols.P250, Pistols.Tec_9, Pistols.USP_S
          Return True
        Case Else
          Return False
      End Select
    End Function
    Public Shared Function IsSniper() As Boolean
      Select Case Player.Local.WeaponId()
          Case Snipers.AWP, Snipers.G3SG1, Snipers.SCAR_20, Snipers.SSG_08
          Return True
          Case Else
          Return False
      End Select
    End Function
    Public Shared Function IsShotgun() As Boolean
      Select Case Player.Local.WeaponId()
          Case Shotguns.MAG_7, Shotguns.Nova, Shotguns.Sawed_Off
          Return True
          Case Else
          Return False
      End Select
    End Function
    Public Shared Function IsRifle() As Boolean
      Select Case Player.Local.WeaponId()
        Case Rifles.AK_47, Rifles.AUG,Rifles.FAMAS,Rifles.Galil_AR,Rifles.M4A1_S,Rifles.M4A4,Rifles.SG_553
          Return True
        Case Else
          Return False
      End Select
    End Function
    Public Shared Function IsSMG() As Boolean
      Select Case Player.Local.WeaponId()
        Case SMGs.MAC_10, SMGs.MP7, SMGs.MP9, SMGs.P90, SMGs.PP_Bizon, SMGs.UMP_45
          Return True
        Case Else
          Return False
      End Select
    End Function
    Public Shared Sub SetAttack(p_bState)
      Dim writeValue As Integer = 4
      if p_bState then writeValue = 5
      MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, writeValue)
    End Sub
    Public Shared Sub Shoot()
      Shoot(1)
    End Sub
    Public Shared Sub Shoot(p_iBullets As Integer)
      Shoot(p_iBullets, true)
    End Sub
    Public Shared Sub Shoot(p_iBullets As Integer, stopAttack As Boolean)
      Dim bulletsFired = Player.Local.ShotsFired()
      If IsRifle() OrElse IsSMG() Then
          SetAttack(True)

        While(bulletsFired < p_iBullets)
          If Not Player.Local.InAttack() Then Return
            bulletsFired = Player.Local.ShotsFired()
        End While

        If stopAttack OrElse GetAsyncKeyState(Keys.Left) Then SetAttack(False)

        elseif IsPistol() OrElse IsSniper() AndAlso p_iBullets >= 2
        for i = 0 to p_iBullets Step 1
          if Player.Local.WeaponClip = 0 Then return
          Shoot(1, true)
          Thread.Sleep(100)
        Next
        Else
        SetAttack(true)
        Thread.Sleep(50)
        SetAttack(false)
      End If
    End Sub
    Public Shared Sub NormalizeAngle(Byref angle As FVector)
      While angle.X > 89.0F
        angle.X -= 180.0F
      End While
      While angle.X < -89.0F
        angle.X += 180.0F
      End While
      While angle.Y > 180.0F
        angle.Y -= 360.0F
      End While
      While angle.Y < -180.0F
        angle.Y += 360.0F
      End While
    End Sub
    Public Shared Function SetAngles(angles As FVector) As Boolean
      Return MemEdit.WriteFVector(Offsets.ClientState + Offsets.ViewAngles, angles)
    End Function
    Public Shared Function RadiansToDegrees(radius As Single) As Single
      Return radius * 57.29578F
    End Function
    Public Shared Function DegreesToRadians(degrees As Single) As Single
      Return Math.PI / 180 * degrees
    End Function

    Public Shared Sub SetSendPacket(bool As Boolean)
      MemEdit.WriteByte(Process.EngineDll + Offsets.SendPackets, bool)
    End Sub

    Public Shared Sub ForceUpdate()
      MemEdit.WriteInt32(Offsets.ClientState + &H174, -1)
    End Sub
    Public Shared Sub ShootWeapon()
      MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 5)
      Threading.Thread.Sleep(1)
      MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 4)
    End Sub

    Public Shared Function GetValidEnemies() As List(Of Player)
      Dim enemyList As New List(Of Player)
      For i = 0 To 63
        Dim enemy As New Player(Player.PointerByIndex(i))
        If enemy.Pointer <> 0 AndAlso enemy.Health > 0 AndAlso Not enemy.Dormant AndAlso enemy.Team <> Player.Local.Team Then
          enemyList.Add(enemy)
        End If
      Next
      Return enemyList
    End Function

    Public Shared Function ClosestEnemyByDistance() As Integer
      If Settings.OnlyAimOnVisible Then
        Dim pointer = 0
        Dim distance = 9999.0F
        For Each enemy In GetValidEnemies()
          If Hack.BspMap.IsVisible(Player.Local.VecEye, enemy.BonePosition(Settings.BoneId)) AndAlso enemy.Distance < distance Then
            pointer = enemy.Pointer
            distance = enemy.Distance
          End If
        Next
        Return pointer
      End If

      Dim sortedByDistance = From enemy In GetValidEnemies()
                             Order By enemy.Distance
                             Select enemy

      Return sortedByDistance.First().Pointer
    End Function

    Public Shared Function GetSmallestFovByRange(ByRef pPointer As Integer) As Integer
      Dim fov As Single

      Dim closestPlayer = 0
      Dim closestAngle As Single = 360

      For Each enemy In GetValidEnemies()
        If enemy.Fov < closestAngle Then
          closestPlayer = enemy.Pointer
          closestAngle = enemy.Fov
          fov = enemy.Fov
        End If
      Next

      Dim pNearestPlayer As New Player(closestPlayer)
      Dim myAngle = Player.Local.ViewAngles() + Player.Local.PunchAngle()
      NormalizeAngle(myAngle)
      Dim enemyAngle = CalcAngle(Player.Local.Position(), pNearestPlayer.BonePosition(Settings.BoneId))

      Dim angleY = enemyAngle.Y - myAngle.Y
      If angleY < 0 Then angleY *= -1

      Dim angleX = enemyAngle.X - myAngle.X
      If angleX < 0 Then angleX *= -1

      Dim r = GetDistance(Player.Local.VecOrigin(), pNearestPlayer.VecOrigin())

      Dim fovFractionY = Math.Sqrt(2 * r * r - 2 * r * r * Math.Cos(DegreesToRadians(angleY)))
      Dim fovFractionX = Math.Sqrt(2 * r * r - 2 * r * r * Math.Cos(DegreesToRadians(angleX)))

      fov = Math.Sqrt((fovFractionY * fovFractionY) + (fovFractionX * fovFractionX))

      pPointer = closestPlayer
      Return fov / 10
    End Function

    Public Shared Function IsIngame() As Boolean
      Return MemEdit.ReadInt32(Offsets.ClientState + &H108) = 6
    End Function

    Public Shared Function GetWeaponName(weaponId As Integer) As String
      Select Case weaponId
        Case 1
          Return "Deagle"
        Case 2
          Return "Duals"
        Case 3
          Return "Five-Seven"
        Case 4
          Return "Glock"
        Case 7
          Return "Ak-47"
        Case 8
          Return "Aug"
        Case 9
          Return "AWP"
        Case 10
          Return "Famas"
        Case 11
          Return "T-Autosniper"
        Case 13
          Return "Galil"
        Case 14
          Return "M249"
        Case 16
          Return "M4A1"
        Case 17
          Return "Mac10"
        Case 19
          Return "P90"
        Case 24
          Return "UMP"
        Case 25
          Return "XM1014"
        Case 26
          Return "Bizon"
        Case 27
          Return "Mag7"
        Case 28
          Return "Negev"
        Case 29
          Return "Sawed Off"
        Case 30
          Return "Tec9"
        Case 31
          Return "Taser"
        Case 32
          Return "P2000"
        Case 33
          Return "MP7"
        Case 34
          Return "MP9"
        Case 35
          Return "Nova"
        Case 36
          Return "P250"
        Case 38
          Return "Scar20"
        Case 39
          Return "SG"
        Case 40
          Return "Scout"
        Case 43
          Return "Flashbang"
        Case 44
          Return "Grenade"
        Case 45
          Return "Smoke"
        Case 46
          Return "Molotov"
        Case 47
          Return "Decoy"
        Case 48
          Return "Incendarynade"
        Case 49
          Return "C4"
        Case 60
          Return "M4A1-S"
        Case 61
          Return "USP-S"
        Case 63
          Return "CZ"
        Case 64
          Return "Revolver"
        Case 42, 59, 500, 505, 506, 507, 508, 509, 512, 514, 515, 516
          Return "Knife"
      End Select
      Return "Error"
    End Function

    Public Shared Function ClosestEnemyByFov() As Integer
      Dim localPlayer As New Player(MemEdit.ReadInt32(Process.ClientDll + Offsets.LocalPlayer))
      Dim enemyDictionary As New Dictionary(Of Integer, Single)
      For i = 0 To 63
        Dim enemy As New Player(Player.PointerByIndex(i))

        If enemy.Pointer <> 0 AndAlso enemy.Health > 0 AndAlso Not enemy.Dormant AndAlso enemy.Team <> localPlayer.Team AndAlso
          (enemy.Fov() < Settings.FovValue OrElse enemy.Fov().IsNaN(enemy.Fov())) Then
            enemyDictionary.Add(enemy.Pointer, enemy.Fov())
          End If
      Next

      If enemyDictionary.Any Then
        Dim sortedByFov = From enemy In enemyDictionary
                          Order By enemy.Value
                          Select enemy
        Return sortedByFov.First().Key
      End If

      Return 0
    End Function
    Public Shared Function EnemyName(playerId As Integer) As String
      Dim radarBaseBase As Integer = MemEdit.ReadInt32(Process.ClientDll + Offsets.RadarBase)
      Dim radar As Integer = MemEdit.ReadInt32(radarBaseBase + &H20)
      Dim sName As String = MemEdit.ReadUnicodeString(radar + (&H1EC * playerId + &H3C), 15)
      If sName = "" Then Return "Fix Me"
      Return sName
    End Function

    Public Shared Function Wins(playerId As Integer) As Integer
      Dim gameResources = MemEdit.ReadInt32(Process.ClientDll + Offsets.PlayerResource)
      Return MemEdit.ReadInt32(gameResources + Offsets.CompetitiveWins + (playerId * 4))
    End Function

    Public Shared Function Rank(playerId As Integer) As String
      Dim compRanks = {"Unranked", "S1", "S2", "S3", "S4", "SE", "SEM", "GN1", "GN2", "GN3", "GNE", "MG1", "MG2", "MGE", "DMG", "LE", "LEM", "SMFC", "GE"}
      Dim gameResources = MemEdit.ReadInt32(Process.ClientDll + Offsets.PlayerResource)
      Dim compRank As Integer = MemEdit.ReadInt32(gameResources + Offsets.CompetitiveRanking + (playerId * 4))
      If compRank <= compRanks.Length Then Return compRanks(compRank) Else Return "Fix Me"
    End Function

    Public Shared Function GetClassId(address As Integer) As Integer
      Dim one As Integer = MemEdit.ReadInt32(address + &H8)
      Dim two As Integer = MemEdit.ReadInt32(one + 2 * &H4)
      Dim three As Integer = MemEdit.ReadInt32(two + 1)
      Return MemEdit.ReadInt32(three + 20)
    End Function

    ''' <summary>
    ''' funzt
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function IsAbleToShoot() As Boolean
      Dim flNextPrimaryAttack = MemEdit.ReadFloat(Player.Local.WeaponEntity() + Offsets.m_flNextPrimaryAttack)

      Dim globalVars = MemEdit.ReadMemory(Of GlobalVarsBase)(Process.EngineDll + Offsets.GlobalVars)
      Dim flServerTime = MemEdit.ReadInt32(Player.Local.Pointer + Offsets.m_nTickBase) * globalVars.interval_per_tick
      Return (Not (flNextPrimaryAttack > flServerTime))
    End Function
    Public Shared Function GetCurTime() As Int32
      Dim globalVars = MemEdit.ReadMemory(Of GlobalVarsBase)(Process.EngineDll + Offsets.GlobalVars)
      Return globalVars.curtime
    End Function
  End Class
End Namespace