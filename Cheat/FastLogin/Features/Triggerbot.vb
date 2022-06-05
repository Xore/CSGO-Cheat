Imports System.Threading
Imports FastLogin.Important

Namespace Features
  Public Class Triggerbot
    Public Declare Function GetAsyncKeyState Lib "user32" (vKey As Integer) As Integer
    Public Shared Sub TriggerBot()
      While Settings.TriggerBot
        If GetAsyncKeyState(Settings.TriggerKey) Then
          If Settings.TriggerMode = 0 Then
            Dim crosshairId = MemEdit.ReadInt32(Player.Local.Pointer + Offsets.CrossHairId)
            If crosshairId >= 0 AndAlso crosshairId < 64 Then
              If GetAsyncKeyState(Settings.TriggerKey) Then
                Dim enemy As New Player(Player.PointerByIndex(crosshairId))
                If enemy.Pointer <> 0 AndAlso enemy.Health > 0 AndAlso enemy.Team <> Player.Local.Team Then
                  If Settings.OnlyAimOnVisible Then
                    If Hack.BspMap.IsVisible(Player.Local.VecEye(), enemy.BonePosition(8)) Then
                      MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 5)
                      Thread.Sleep(50)
                      MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 4)
                    End If
                  Else
                    MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 5)
                    Thread.Sleep(50)
                    MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 4)
                  End If
                End If
              End If
            End If
          ElseIf Settings.TriggerMode = 1 Then
            Dim enemy As New Player(Utils.ClosestEnemyByFov())

            Dim bBone = enemy.BonePosition(8) + New FVector(0, 0, 3)
            Dim bottomHitboxHead = New FVector(bBone.X - 2.54F, bBone.Y - 4.145F, bBone.Z - 7.0F)
            Dim topHitboxHead = New FVector(bBone.X + 2.54F, bBone.Y + 4.0F, bBone.Z + 3.0F)

            Dim hBone = enemy.BonePosition(3)
            Dim bottomHitboxChest = New FVector(hBone.X - 7.8F, hBone.Y - 5.5F, hBone.Z - 25.0F)
            Dim topHitboxChest = New FVector(hBone.X + 7.0F, hBone.Y + 5.5F, hBone.Z + 15.0F)



            Dim viewDirection = Cray.AngleToDirection(Player.Local.ViewAngles)
            Dim viewRay As New Cray(Player.Local.VecOrigin + Player.Local.ViewOffset, viewDirection)
            Dim distance As Single
            Dim headShot = viewRay.Trace(bottomHitboxHead, topHitboxHead, distance)
            Dim chestShot = viewRay.Trace(bottomHitboxChest, topHitboxChest, distance)

            If Settings.TriggerHead AndAlso headShot Then
              If Settings.OnlyAimOnVisible Then
                If Hack.BspMap.IsVisible(Player.Local.VecEye(), enemy.BonePosition(8)) Then
                  MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 5)
                  Thread.Sleep(1)
                  MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 4)
                End If
              Else
                MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 5)
                Thread.Sleep(1)
                MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 4)
              End If
            ElseIf chestShot Or headShot Then
              If Settings.OnlyAimOnVisible Then
                If Hack.BspMap.IsVisible(Player.Local.VecEye(), enemy.BonePosition(8)) Then
                  MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 5)
                  Thread.Sleep(1)
                  MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 4)
                End If
              Else
                MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 5)
                Thread.Sleep(1)
                MemEdit.WriteInt32(Process.ClientDll + Offsets.ForceAttack, 4)
              End If
            End If
          End If
        End If
        Thread.Sleep(5)
      End While
    End Sub
  End Class
End Namespace
