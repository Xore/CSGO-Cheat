Imports System.Security.Cryptography
Imports System.Threading
Imports FastLogin.Important

Namespace Features
  Public Class GlowManager
    Public Shared Sub GlowHack()
      While Settings.Glow
        Dim glowObjectManager = MemEdit.ReadInt32(Process.ClientDll + Offsets.GlowObject)
        Dim glowObjectCount = MemEdit.ReadInt32(Process.ClientDll + Offsets.GlowObject + &H4)

        For i = 0 To glowObjectCount
          Dim entity = MemEdit.ReadInt32(glowObjectManager + &H38 * i)
          If entity = 0 Then Continue For

          Dim glowObject = MemEdit.ReadMemory(Of GlowObject_t)(glowObjectManager + (i * &H38))

          If glowObject.Entity Then
            glowObject.RenderWhenOccluded = True
            glowObject.RenderWhenUnoccluded = False
            glowObject.FullBloom = False

            Dim classId = Utils.GetClassId(MemEdit.ReadInt32(glowObjectManager + (i * &H38)))

            If Settings.GlowBomb AndAlso {ClassIDs.CC4, ClassIDs.CPlantedC4}.Contains(classId) Then
              glowObject.R = 0
              glowObject.G = 0.34
              glowObject.B = 1
              glowObject.A = 0.8
              MemEdit.WriteStruct(glowObjectManager + (i * &H38), glowObject)
            End If

            If Settings.GlowWeapons AndAlso {ClassIDs.CAK47, ClassIDs.CDEagle, ClassIDs.CWeaponAWP, ClassIDs.CWeaponAug, ClassIDs.CWeaponBizon, ClassIDs.CWeaponElite, ClassIDs.CWeaponFamas, ClassIDs.CWeaponFiveSeven, ClassIDs.CWeaponG3SG1, ClassIDs.CWeaponGalilAR, ClassIDs.CWeaponGlock, ClassIDs.CWeaponHKP2000, ClassIDs.CWeaponM249, ClassIDs.CWeaponM4A1, ClassIDs.CWeaponMAC10, ClassIDs.CWeaponMP7, ClassIDs.CWeaponMP9, ClassIDs.CWeaponMag7, ClassIDs.CWeaponNOVA, ClassIDs.CWeaponNegev, ClassIDs.CWeaponP250, ClassIDs.CWeaponP90, ClassIDs.CWeaponSCAR20, ClassIDs.CWeaponSG550, ClassIDs.CWeaponSSG08, ClassIDs.CWeaponSawedoff, ClassIDs.CWeaponTaser, ClassIDs.CWeaponTec9, ClassIDs.CWeaponUMP45, ClassIDs.CWeaponUSP, ClassIDs.CWeaponXM1014}.Contains(classId) Then
              glowObject.R = 0
              glowObject.G = 0.34
              glowObject.B = 1
              glowObject.A = 0.8
              MemEdit.WriteStruct(glowObjectManager + (i * &H38), glowObject)
            End If

            If Settings.GlowChicken AndAlso classId = ClassIDs.CChicken Then
              glowObject.R = 0
              glowObject.G = 0.34
              glowObject.B = 1
              glowObject.A = 0.8
              MemEdit.WriteStruct(glowObjectManager + (i * &H38), glowObject)
            End If

            If Settings.GlowGrenades AndAlso {ClassIDs.CBaseCSGrenadeProjectile, ClassIDs.CFlashbang, ClassIDs.CDecoyProjectile, ClassIDs.CDecoyGrenade, ClassIDs.CHEGrenade, ClassIDs.CIncendiaryGrenade, ClassIDs.CMolotovProjectile, ClassIDs.CMolotovGrenade, ClassIDs.CSensorGrenade, ClassIDs.CSmokeGrenadeProjectile, ClassIDs.CSmokeGrenade, ClassIDs.ParticleSmokeGrenade, ClassIDs.CParticleFire}.Contains(classId) Then
              glowObject.R = 0
              glowObject.G = 0.34
              glowObject.B = 1
              glowObject.A = 0.8

              MemEdit.WriteStruct(glowObjectManager + (i * &H38), glowObject)
            End If

            Dim globalVars = MemEdit.ReadMemory(Of GlobalVarsBase)(Process.EngineDll + Offsets.GlobalVars)
            If Settings.GlowPlayers AndAlso classId = ClassIDs.CCSPlayer Then
              Dim enemy = New Player(MemEdit.ReadInt32(glowObjectManager + (i * &H38)))

              If Settings.GlowSound Then
                If enemy.Velocity() < 80 Then Return
                If enemy.MoveType <> 2 Then Return
              End If
              If Player.Local.Team <> enemy.Team Then
                glowObject.R = 0
                glowObject.G = 0.34
                glowObject.B = 1
                glowObject.A = 0.8
                If Settings.OnlyGlowOnVisible AndAlso Hack.BspMap IsNot Nothing Then
                  If Not Hack.BspMap.IsVisible(Player.Local.VecEye(), enemy.BonePosition(8)) Then
                    glowObject.R = 0
                    glowObject.G = 0.34
                    glowObject.B = 1
                    glowObject.A = 0.8
                  End If
                End If
                If Settings.GlowMaxDistanceBool AndAlso enemy.Distance() <= Settings.GlowMaxDistance Then
                  MemEdit.WriteStruct(glowObjectManager + (i * &H38), glowObject)
                ElseIf Settings.GlowMaxDistanceBool = False Then
                  MemEdit.WriteStruct(glowObjectManager + (i * &H38), glowObject)
                End If
              End If
            End If
          End If
        Next
        Thread.Sleep(10)
      End While
    End Sub
  End Class
End Namespace

'  Unused shit
'Private Structure Glowstruct
'  Public R As Single
'  Public G As Single
'  Public B As Single
'  Public A As Single
'  Public Rwo As Boolean
'  Public Rwuo As Boolean
'  'Public FullBloom As Boolean
'End Structure
'Dim glowStruct As New Glowstruct()
'glowStruct.R = 0
'glowStruct.G = 1
'glowStruct.A = 0.8
'glowStruct.Rwo = True
'glowStruct.Rwuo = False

'Dim baseGlowObject = Process.ClientDll + Offsets.GlowObject
'Dim glowObject = MemEdit.ReadInt32(baseGlowObject)

'For Each enemy In Utils.GetValidEnemies()
'  Dim glowIndex = MemEdit.ReadInt32(enemy.Pointer + Offsets.GlowIndex)

'  glowStruct.B = 0

'  Select Case enemy.Health
'    Case 75 To 100
'      glowStruct.R = 0
'      glowStruct.G = 1
'    Case 50 To 74
'      glowStruct.R = 1
'      glowStruct.G = 0.84
'    Case 25 To 49
'      glowStruct.R = 1
'      glowStruct.G = 0.65
'    Case 1 To 24
'      glowStruct.R = 1
'      glowStruct.G = 0
'  End Select

'  If Settings.OnlyGlowOnVisible AndAlso Hack.BspMap IsNot Nothing Then
'    If Not Hack.BspMap.IsVisible(Player.Local.VecEye(), enemy.BonePosition(8)) Then
'      glowStruct.R = 0
'      glowStruct.G = 0.34
'      glowStruct.B = 1
'    End If
'  End If

'  Dim calculation = glowIndex * &H38 + &H4
'  Dim current = glowObject + calculation
'  MemEdit.WriteFloat(current, glowStruct.R)

'  calculation = glowIndex * &H38 + &H8
'  current = glowObject + calculation
'  MemEdit.WriteFloat(current, glowStruct.G)

'  calculation = glowIndex * &H38 + &HC
'  current = glowObject + calculation
'  MemEdit.WriteFloat(current, glowStruct.B)

'  calculation = glowIndex * &H38 + &H10
'  current = glowObject + calculation
'  MemEdit.WriteFloat(current, glowStruct.A)

'  calculation = glowIndex * &H38 + &H24
'  current = glowObject + calculation
'  MemEdit.WriteByte(current, glowStruct.Rwo)

'  calculation = glowIndex * &H38 + &H25
'  current = glowObject + calculation
'  MemEdit.WriteByte(current, glowStruct.Rwuo)
'Next
