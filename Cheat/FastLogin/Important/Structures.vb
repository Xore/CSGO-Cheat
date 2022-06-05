Imports System.Runtime.InteropServices

Namespace Important

  Public Structure FVector
    Public X As Single?
    Public Y As Single?
    Public Z As Single?

    Public Sub New(v1 As Single?, v2 As Single?, v3 As Single?)
      Me.New()
      X = v1
      Y = v2
      Z = v3
    End Sub

    Public Shared Operator -(a As FVector, b As FVector) As FVector
      Dim vector As New FVector
      vector.X = a.X - b.X
      vector.Y = a.Y - b.Y
      vector.Z = a.Z - b.Z
      Return vector
    End Operator

    Public Shared Operator +(a As FVector, b As FVector) As FVector
      Dim vector As New FVector
      vector.X = a.X + b.X
      vector.Y = a.Y + b.Y
      vector.Z = a.Z + b.Z
      Return vector
    End Operator

    Public Shared Operator /(value As FVector, scale As Double) As FVector
      Return New FVector(value.X.Value / scale, value.Y.Value / scale, value.Z.Value / scale)
    End Operator

    Public Function DotProduct(vector2 As FVector) As Single
      Return X * vector2.X + Y * vector2.Y + Z * vector2.Z
    End Function

    Public Function Length() As Double
      Return Math.Sqrt((X * X) + (Y * Y) + (Z * Z))
    End Function
  End Structure

  Public Structure Input_t
    Public m_pVftable As UIntPtr
    Public m_bTrackIRAvailable As Boolean
    Public m_bMouseInitialized As Boolean
    Public m_bMouseActive As Boolean
    Public m_bJoystickAdvancedInit As Boolean
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=44)>
    Public Unk1 As Byte()
    Public m_pKeys As UIntPtr
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=100)>
    Public Unk2 As Byte()
    Public m_bCameraInterceptingMouse As Boolean
    Public m_bCameraInThirdPerson As Boolean
    Public m_bCameraMovingWithMouse As Boolean
    Public m_vecCameraOffset As FVector
    Public m_bCameraDistanceMove As Boolean
    Public m_nCameraOldX As Integer
    Public m_nCameraOldY As Integer
    Public m_nCameraX As Integer
    Public m_nCameraY As Integer
    Public m_bCameraIsOrthographic As Boolean
    Public m_vecPreviousViewAngles As FVector
    Public m_vecPreviousViewAnglesTilt As FVector
    Public m_flLastForwardMove As Single          '
    Public m_nClearInputState As Integer
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)>
    Public Unk3 As Byte()
    Public m_pCommands As UIntPtr
    Public m_pVerifiedCommands As UIntPtr
  End Structure

  Public Structure UserCmd_t
    Public pVft As UIntPtr
    Public m_iCmdNumber As Integer
    Public m_iTickCount As Integer
    Public m_vecViewAngles As FVector
    Public m_vecAimDirection As FVector
    Public m_flForwardmove As Single
    Public m_flSidemove As Single
    Public m_flUpmove As Single
    Public m_iButtons As Integer
    Public m_bImpulse As Byte()
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)>
    Public Pad1 As Byte()
    Public m_iWeaponSelect As Integer
    Public m_iWeaponSubtype As Integer
    Public m_iRandomSeed As Integer
    Public m_siMouseDx As Short
    Public m_siMouseDy As Short
    Public m_bHasBeenPredicted As Boolean
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=27)>
    Public Pad2 As Byte()
  End Structure

  Public Structure VerifiedUserCmd_t
    Public m_Command As UserCmd_t
    Public m_Crc As UInteger
  End Structure

  Public Structure GlobalVarsBase
    Public realtime As Single
    Public framecount As Integer
    Public absoluteframetime As Single
    Public absoluteframestarttimestddev As Single
    Public curtime As Single
    Public frametime As Single
    Public maxClients As Integer
    Public tickcount As Integer
    Public interval_per_tick As Single
    Public interpolation_amount As Single
  End Structure

  Public Structure GlowObject_t
    Dim Entity As Integer
    Dim R As Single
    Dim G As Single
    Dim B As Single
    Dim A As Single
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)>
    Public unk1 As Byte()
    Dim RenderWhenOccluded As Boolean
    Dim RenderWhenUnoccluded As Boolean
    Dim FullBloom As Boolean
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)>
    Public unk2 As Byte()
  End Structure

End Namespace