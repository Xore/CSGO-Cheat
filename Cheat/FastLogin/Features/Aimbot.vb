Imports FastLogin.Important

Namespace Features
  Public Class Aimbot
    Public Declare Function GetAsyncKeyState Lib "user32" (vKey As Integer) As Integer
    Const MultiplayerBackup = 150



    Public Shared Sub Aimbot()
      While Settings.AimBot
        If GetAsyncKeyState(Settings.AimbotKey) Then
          Dim enemyPointer = 0

          Select Case Settings.AimBotTargetMode
            Case 1
              enemyPointer = Utils.ClosestEnemyByDistance()
            Case 2
              Dim fov = 999.0F
              fov = Utils.GetSmallestFovByRange(enemyPointer)
              If Not fov <= Settings.FovValue Then Continue While
          End Select

          If enemyPointer <> 0 Then
            Dim enemy As New Player(enemyPointer)

            Dim pAngle = Utils.CalcAngle(Player.Local.Position, enemy.BonePosition(Settings.BoneId))
            If Player.Local.ShotsFired > 1  AndAlso Settings.AimBotMode = 1 AndAlso Not Utils.IsPistol() Then NoViewPunch(pAngle)
            SmoothAngles(pAngle)
            Utils.NormalizeAngle(pAngle)

            If Settings.AimBotMode = 1 Then
              If Settings.OnlyAimOnVisible Then
                If Hack.BspMap.IsVisible(Player.Local.VecEye, enemy.BonePosition(Settings.BoneId)) Then Utils.SetAngles(pAngle)
              Else
                Utils.SetAngles(pAngle)
              End If
            ElseIf Settings.AimBotMode = 2  AndAlso Utils.IsIngame() AndAlso Utils.IsAbleToShoot() Then
              If Settings.OnlyAimOnVisible Then
                If Hack.BspMap.IsVisible(Player.Local.VecEye, enemy.BonePosition(Settings.BoneId)) Then SetViewAnglesSilent(pAngle)
              Else
                SetViewAnglesSilent(pAngle)
              End If
            End If
          End If
        End If
      End While
    End Sub

    Public Shared Sub NoViewPunch(ByRef playerAngles As FVector)
      Dim aimPunchVector = Player.Local.PunchAngle()
      playerAngles.X -= aimPunchVector.X * 2.0F
      playerAngles.Y -= aimPunchVector.Y * 2.0F
    End Sub

    Private Shared Sub SmoothAngles(ByRef aimAng As FVector)
      If Settings.SmoothValue <= 10 Then Exit Sub
      Dim smoothPercent = Settings.SmoothValue / 10
      Dim delta As New FVector(0, 0, 0)
      Dim viewAngle = Player.Local.ViewAngles

      delta.X = viewAngle.X - aimAng.X
      delta.Y = viewAngle.Y - aimAng.Y
      delta.Z = viewAngle.Z - aimAng.Z
      Utils.NormalizeAngle(delta)

      aimAng.X = viewAngle.X - delta.X / smoothPercent
      aimAng.Y = viewAngle.Y - delta.Y / smoothPercent
      aimAng.Z = viewAngle.Z - delta.Z / smoothPercent
    End Sub

    Private Shared Sub SetViewAnglesSilent(vecViewAngles As FVector)
      Utils.SetSendPacket(False)

      Dim iCurrentSequenceNumber = MemEdit.ReadInt32(Offsets.ClientState + &H4C7C) + 2
      Dim dwInput = Process.ClientDll + Offsets.Input
      Dim dwUserCmd = MemEdit.ReadInt32(dwInput + &HEC)
      Dim dwUserVerCmd = MemEdit.ReadInt32(dwInput + &HF0)

      Dim pUserCmd = dwUserCmd + (iCurrentSequenceNumber Mod MultiplayerBackup) * &H64 'sizeof(UserCmd_t)
      Dim pOldUserCmd = dwUserCmd + ((iCurrentSequenceNumber - 1) Mod MultiplayerBackup) * &H64 'sizeof(UserCmd_t)
      Dim pVerifiedOldUserCmd = dwUserVerCmd + ((iCurrentSequenceNumber - 1) Mod MultiplayerBackup) * &H68 'sizeof(VerifiedUserCmd_t)

      Dim wtfAmi = MemEdit.ReadInt32(pUserCmd + &H4)
      While wtfAmi <> iCurrentSequenceNumber
        Task.Yield()
        wtfAmi = MemEdit.ReadInt32(pUserCmd + &H4)
      End While

      MemEdit.WriteFVector(pOldUserCmd + &HC, vecViewAngles)
      MemEdit.WriteFVector(pVerifiedOldUserCmd + &HC, vecViewAngles)

      Utils.SetSendPacket(True)
    End Sub
  End Class
End Namespace
