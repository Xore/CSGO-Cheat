Namespace Important
  Public Class Offsets
    Public Shared Health As Integer = &HFC
    Public Shared Team As Integer = &HF0
    Public Shared Dormant As Integer = &HE9
    Public Shared Flags As Integer = &H100
    Public Shared FlashDuration As Integer = &HA2E8
    Public Shared GlowIndex As Integer = &HA300
    Public Shared EnemyDistance As Integer = &H10
    Public Shared Position As Integer = &H134
    Public Shared Spotted As Integer = &H939
    Public Shared m_flLastMadeNoiseTime As Integer = &HC4
    Public Shared m_bIsScoped as Integer = &H387E
    Public Shared CompetitiveWins As Integer = &H1B48
    Public Shared CompetitiveRanking As Integer = &H1A44
    Public Shared RadarBasePointer As Integer = &H50
    Public Shared PlayerId As Integer = &H64
    Public Shared AimPunch As Integer = &H301C
    Public Shared ShotsFired As Integer = &HA2B0
    Public Shared BoneMatrix As Integer = &H2698
    Public Shared CrossHairId As Integer = &HB2A4

    Public Shared ViewAngle As Integer = &H104
    Public Shared WeaponId As Integer = &H32EC
    Public Shared ActiveWeapon As Integer = &H2EE8
    Public Shared ItemDefinitionIndex As Integer = &H2F88
    Public Shared Velocity As Integer = &H110

    Public Shared VecOrigin As Integer = &H134

    Public Shared BombPlanted As Integer = &H8D5
    Public Shared GameRulesProxy As Integer = &H4F8E4E4

    Public Shared m_hMyWeapons As Integer = &H2DE8
    Public Shared m_iItemDefinitionIndex As Integer = &H2F88


    Public Shared m_hViewModel As Integer = &H32FC
    Public Shared m_nModelIndex As Integer = &H254
    Public Shared m_iWorldModelIndex As Integer = &H31E4


    Public Shared m_MoveType As Integer = &H258

    Public Shared m_flNextPrimaryAttack As Integer = &H31D8
    Public Shared m_nTickBase As Integer = &H3404
    Public Shared m_iClip1 As Integer = &H3204
    Public Shared dwClientState_MapDirectory As Integer = &H188

    Public Shared m_OriginalOwnerXuidLow As Integer = &H3168
    Public Shared m_OriginalOwnerXuidHigh As Integer = &H316C
    Public Shared m_flFallbackWear As Integer = &H3178
    Public Shared m_nFallbackPaintKit As Integer = &H3170
    Public Shared m_nFallbackSeed As Integer = &H3174
    Public Shared m_nFallbackStatTrak As Integer = &H317C
    Public Shared m_szCustomName As Integer = &H301C
    Public Shared m_iAccountID As Integer = &H2FA8
    Public Shared m_iItemIDLow As Integer = &H24FA
    Public Shared m_iItemIDHigh As Integer = &H2FA0
    Public Shared m_iEntityQuality As Integer = &H2F8C

    Public Shared EntityList As Integer
    Public Shared ClientState As Integer = &H5A783C
    Public Shared ForceAttack As Integer
    Public Shared ForceJump As Integer
    Public Shared GlowObject As Integer
    Public Shared LocalPlayer As Integer
    Public Shared RadarBase As Integer
    Public Shared ViewAngles As Integer
    Public Shared PlayerResource As Integer
    Public Shared Input As Integer
    Public Shared GlobalVars As Integer
    Public Shared SendPackets As Integer = &HCD0AA

    Public Shared Sub SetOffsets()
      EntityList = PatternScan.Scan(Process.ClientDll, "BB????????83FF010F8C????????3BF8", 1, 0, True)
      Dim clientStatePointer = PatternScan.Scan(Process.EngineDll, "A1????????33D26A006A0033C989B0", 1, 0, True) 'Kaputt
      ClientState = MemEdit.ReadInt32(Process.EngineDll + clientStatePointer)
      ForceAttack = PatternScan.Scan(Process.ClientDll, "890D????????8B0D????????8BF28BC183CE04", 2, 0, True)
      ForceJump = PatternScan.Scan(Process.ClientDll, "890D????????8B0D????????8BF28BC183CE08", 2, 0, True)
      GlowObject = PatternScan.Scan(Process.ClientDll, "A1????????A801754B", 1, 4, True)
      LocalPlayer = PatternScan.Scan(Process.ClientDll, "A3????????C705????????????????E8????????59C36A??", 1, 16, True)
      RadarBase = PatternScan.Scan(Process.ClientDll, "A1????????8B0CB08B01FF50??463B35????????7CEA8B0D", 1, 0, True)
      ViewAngles = PatternScan.Scan(Process.EngineDll, "F30F1180????????D94604D905", 4, 0, False)
      PlayerResource = PatternScan.Scan(Process.ClientDll, "8B3D????????85FF0F84????????81C7", 2, 0, True)
      Input = PatternScan.Scan(Process.ClientDll, "B9????????F30F110424FF5010", 1, 0, True)
      GlobalVars = PatternScan.Scan(Process.EngineDll, "68????????68????????FF500885C0", 1, 0, True)
    End Sub
  End Class
End Namespace