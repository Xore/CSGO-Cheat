Imports System.Threading
Imports FastLogin.Features

Namespace Important
  Public Class Player
    Public Shared Local As Player
    Public Pointer As Integer

    Public Sub New(ptr As Integer)
      Pointer = ptr
    End Sub

    Public Shared Sub SetLocal()
      While True
        Local = New Player(MemEdit.ReadInt32(Process.ClientDll + Offsets.LocalPlayer))
        Thread.Sleep(1000)
      End While
    End Sub

    Public Shared Function PointerByIndex(index As Integer) As Integer
      Return MemEdit.ReadInt32(Process.ClientDll + Offsets.EntityList + (index * Offsets.EnemyDistance))
    End Function

    Public Function Health() As Integer
      Return MemEdit.ReadInt32(Pointer + Offsets.Health)
    End Function
    Public Function Velocity() As Single
      Return MemEdit.ReadFVector(Pointer + Offsets.Velocity).Length
    End Function

    Public Function Flags() As Integer
      Return MemEdit.ReadInt32(Pointer + Offsets.Flags)
    End Function

    Public Function Team() As Integer
      Return MemEdit.ReadInt32(Pointer + Offsets.Team)
    End Function

    Public Function Dormant() As Boolean
      Return MemEdit.ReadInt32(Pointer + Offsets.Dormant)
    End Function

    Public Function Position() As FVector
      Return MemEdit.ReadFVector(Pointer + Offsets.Position)
    End Function

    Public Function ViewAngles() As FVector
      Return MemEdit.ReadFVector(Offsets.ClientState + Offsets.ViewAngles)
    End Function

    Public Function PunchAngle() As FVector
      Return MemEdit.ReadFVector(Pointer + Offsets.AimPunch)
    End Function

    Public Function ViewOffset() As FVector
      Return MemEdit.ReadFVector(Pointer + Offsets.ViewAngle)
    End Function

    Public Function VecOrigin() As FVector
      Return MemEdit.ReadFVector(Pointer + Offsets.VecOrigin)
    End Function

    Public Function VecEye() As FVector
      Return VecOrigin() + ViewOffset()
    End Function
    Public Function MoveType() As Int32
      Return MemEdit.ReadInt32(Pointer + Offsets.m_MoveType)
    End Function
    Public Function LastNoise() As Int32
      Return MemEdit.ReadInt32(Pointer + Offsets.m_flLastMadeNoiseTime)
    End Function
    Public Function IsWalking() As Boolean
      Return MemEdit.ReadInt32(Pointer + &H387D)
    End Function
    Public Function IsScoping() As Boolean
      Return MemEdit.ReadInt32(Pointer + Offsets.m_bIsScoped)
    End Function
    Public Function BonePosition(boneId As Integer) As FVector
      Dim boneMatrix = MemEdit.ReadInt32(Pointer + Offsets.BoneMatrix)
      Dim buffer = MemEdit.ReadBytes(boneMatrix + &H30 * boneId + &HC, 36)
      Dim bonePos As New FVector(BitConverter.ToSingle(buffer, 0), BitConverter.ToSingle(buffer, 16), BitConverter.ToSingle(buffer, 32))
      Return bonePos
    End Function

    Public Function Spotted() As Boolean
      Return MemEdit.ReadInt32(Pointer + Offsets.Spotted)
    End Function

    Public Function ShotsFired() As Integer
      Return MemEdit.ReadInt32(Pointer + Offsets.ShotsFired)
    End Function

    Public Function InCrosshairId() As Integer
      Return MemEdit.ReadInt32(Pointer + Offsets.CrossHairId)
    End Function
    Public Function InAttack() As Boolean
      return MemEdit.ReadInt32(Process.ClientDll + Offsets.ForceAttack) = 5
    End Function

    Public Function Fov() As Single
      Dim pAngle = BonePosition(Settings.BoneId)
      pAngle = Utils.CalcAngle(Local.Position, pAngle)
      Aimbot.NoViewPunch(pAngle)
      Utils.NormalizeAngle(pAngle)
      Return Utils.GetDistance(pAngle, Local.ViewAngles)
    End Function

    Public Function WeaponEntity() As Integer
      Dim weaponIndex = MemEdit.ReadInt32(Pointer + Offsets.ActiveWeapon) And &HFFF
      Return MemEdit.ReadInt32((Process.ClientDll + Offsets.EntityList + weaponIndex * &H10) - &H10)
    End Function

    Public Function WeaponId() As Integer
      Return MemEdit.ReadInt32(WeaponEntity() + Offsets.ItemDefinitionIndex)
    End Function

    Public Function WeaponXuid() As Integer
      Return MemEdit.ReadInt32(WeaponEntity() + Offsets.m_OriginalOwnerXuidLow)
    End Function

    Public Function WeaponSkinId() As Integer
      Return MemEdit.ReadInt32(WeaponEntity() + Offsets.m_nFallbackPaintKit)
    End Function

    Public Function WeaponClip() As Integer
      Return MemEdit.ReadInt32(WeaponEntity() + Offsets.m_iClip1)
    End Function

    Public Function Distance() As Single
      Return Utils.GetDistance(Local.VecEye(), BonePosition(Settings.BoneId))
    End Function

    Public Function PlayerId() As Integer
      Return MemEdit.ReadInt32(Pointer + Offsets.PlayerId)
    End Function

    Public Function Name() As String
      Return Utils.EnemyName(PlayerId)
    End Function

    Public Function WeaponName() As String
      Return Utils.GetWeaponName(WeaponId())
    End Function

    Public Function Rank() As String
      Return Utils.Rank(PlayerId)
    End Function

    Public Function Wins() As Integer
      Return Utils.Wins(PlayerId)
    End Function
  End Class
End Namespace