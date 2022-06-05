Imports System.Threading
Imports FastLogin.Important
Namespace Features
  Public Class newTriggerbot
    Public Declare Function GetAsyncKeyState Lib "user32" (vKey As Integer) As Integer
    Public Shared m_bActive As Boolean = False
    Public Shared Sub newTriggerbot()
    While Settings.Triggerbot
        While True
         Thread.Sleep(1)
          Dim bTriggered = False
          If Settings.TriggerMode = 1
            While GetAsyncKeyState(Settings.TriggerKey)
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
              If Utils.IsSniper() AndAlso not Player.Local.IsScoping() Then Return 
              m_bActive = True
              If Settings.TriggerHead AndAlso headShot Then
                If Settings.OnlyAimOnVisible Then
                  If Hack.BspMap.IsVisible(Player.Local.VecEye(), enemy.BonePosition(8)) Then
                    if Utils.IsSniper() OrElse Utils.IsShotgun() OrElse Utils.IsPistol() Then
                      Utils.Shoot()
                      else
                      Utils.Shoot(3)
                    End If
                  End If
                Else
                  if Utils.IsSniper() OrElse Utils.IsShotgun() OrElse Utils.IsPistol() Then
                    Utils.Shoot()
                  else
                    Utils.Shoot(3)
                  End If
                End If
              ElseIf chestShot Or headShot Then
                If Settings.OnlyAimOnVisible Then
                  If Hack.BspMap.IsVisible(Player.Local.VecEye(), enemy.BonePosition(8)) Then
                    if Utils.IsSniper() OrElse Utils.IsShotgun() OrElse Utils.IsPistol() Then
                      Utils.Shoot()
                    else
                      Utils.Shoot(3)
                    End If
                  End If
                Else
                  if Utils.IsSniper() OrElse Utils.IsShotgun() OrElse Utils.IsPistol() Then
                    Utils.Shoot()
                  else
                    Utils.Shoot(3)
                  End If
                End If
              End If
              bTriggered = True
              If GetAsyncKeyState(Settings.TriggerKey)
                if GetAsyncKeyState(Keys.Left)
                  Utils.SetAttack(false)
                End If
              End If
            End While
            m_bActive = False
          End If
        End While
    End While
    End Sub

    Public Function getState() As Boolean
      return m_bActive
    End Function
  End Class

End Namespace

