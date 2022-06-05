Imports System.Threading
Imports FastLogin.Important

Namespace Features
  Public Class Miscellaneous
    Private Declare Function GetAsyncKeyState Lib "user32" (vKey As Integer) As Integer

    ''' <summary>
    ''' Bunnyhop by holding space
    ''' </summary>
    Public Shared Sub Bunnyhop()
      While Settings.BunnyHop
        While GetAsyncKeyState(Keys.Space) AndAlso Player.Local.Velocity > 125
          Dim flags = Player.Local.Flags
          If flags = 263 OrElse flags = 257 Then
            MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceJump, 5)
          Else
            MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceJump, 4)
          End If
          Thread.Sleep(5)
        End While
      End While
    End Sub

    ''' <summary>
    ''' Sets Flashduration to 0
    ''' </summary>
    Public Shared Sub NoFlash()
      While Settings.NoFlash
        MemEdit.WriteFloat(Player.Local.Pointer + Offsets.FlashDuration, 0)
        Thread.Sleep(10)
      End While
    End Sub

    ''' <summary>
    ''' Smokegrenade Position is set far away
    ''' </summary>
    Public Shared Sub NoSmoke()
      While Settings.NoSmoke
        Dim glowObjectManager = MemEdit.ReadInt32(Process.ClientDll + Offsets.GlowObject)
        Dim glowObjectCount = MemEdit.ReadInt32(Process.ClientDll + Offsets.GlowObject + &H4)

        For i = 0 To glowObjectCount
          Dim classId = Utils.GetClassId(MemEdit.ReadInt32(glowObjectManager + (i * &H38)))
          If classId = ClassIDs.CSmokeGrenadeProjectile OrElse classId = ClassIDs.CSmokeGrenade OrElse classId = ClassIDs.ParticleSmokeGrenade Then
            MemEdit.WriteFVector(MemEdit.ReadInt32(glowObjectManager + (i * &H38)) + Offsets.VecOrigin, New FVector(0, 0, 9999))
          End If
        Next
        Thread.Sleep(10)
      End While
    End Sub


    ''' <summary>
    ''' Show all enemies on radar
    ''' </summary>
    Public Shared Sub Radar()
      While Settings.Radar
        For each enemy In Utils.GetValidEnemies()
          If Not enemy.Spotted Then MemEdit.WriteByte(enemy.Pointer + Offsets.Spotted, True)
        Next
        Thread.Sleep(100)
      End While
    End Sub

    Public Shared Sub RecoilControlSystem()
      Dim viewAngle As FVector
      Dim punchAngle As FVector
      Dim oldAngle As New FVector
      Dim newAngle As New FVector

      While Settings.Rcs
        If GetAsyncKeyState(Keys.LButton) AndAlso Player.Local.ShotsFired > 1 AndAlso Not GetAsyncKeyState(Settings.AimbotKey) Then
          viewAngle = Player.Local.ViewAngles
          punchAngle = Player.Local.PunchAngle

          viewAngle.X = viewAngle.X + oldAngle.X
          viewAngle.Y = viewAngle.Y + oldAngle.Y

          newAngle.X = viewAngle.X - punchAngle.X * 2.0F
          newAngle.Y = viewAngle.Y - punchAngle.Y * 2.0F
          newAngle.Z = 0

          Utils.NormalizeAngle(newAngle)
          Utils.SetAngles(newAngle)

          oldAngle.X = punchAngle.X * 2.0F
          oldAngle.Y = punchAngle.Y * 2.0F
        Else
          oldAngle.X = 0
          oldAngle.Y = 0
        End If
        Thread.Sleep(7)
      End While
    End Sub

    ''' <summary>
    ''' Lags the client by not sending packets for a short interval
    ''' </summary>
    Public Shared Sub FakeLag()
      While Settings.FakeLag
        If Not GetAsyncKeyState(Keys.LButton) Then
          Utils.SetSendPacket(False)
          Thread.Sleep(Settings.FakeLagValue)
          Utils.SetSendPacket(True)
          Thread.Sleep(1)
        Else
          Utils.SetSendPacket(True)
        End If
      End While
      Utils.SetSendPacket(True)
    End Sub

    Public Shared Sub FullAuto()
      While Settings.FullAuto
        If GetAsyncKeyState(Keys.LButton) Then
          Select Case Player.Local.WeaponId
            Case Pistols.Desert_Eagle, Pistols.Dual_Berettas, Pistols.Five_Seven, Pistols.Glock_18, Pistols.P2000, Pistols.P250, Pistols.Tec_9, Pistols.USP_S,
                 Shotguns.Nova, Shotguns.MAG_7, Shotguns.Sawed_Off,
                 Snipers.AWP, Snipers.SSG_08
              If Player.Local.WeaponClip > 0 Then
                MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 5)
                Thread.Sleep(15)
                MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 4)
              End If
          End Select
          Thread.Sleep(15)
        End If
      End While
    End Sub
  End Class
End Namespace
