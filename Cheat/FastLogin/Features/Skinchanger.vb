Imports FastLogin.Important

Namespace Features
  Public Class Skinchanger
    Public Declare Function GetAsyncKeyState Lib "user32" (vKey As Integer) As Integer

    Public Shared Sub Skinchanger()
      While Settings.SkinChanger
        Dim weaponEntity = Player.Local.WeaponEntity
        Dim weaponId = Player.Local.WeaponId

        If weaponId <> 0 Then
          Dim overrideSkin As Integer
          Dim overrideName As String

          Select Case weaponId
            Case Pistols.Desert_Eagle
              overrideSkin = My.Settings.Desert_Eagle_SkinID
              overrideName = My.Settings.Desert_Eagle_SkinName
            Case Pistols.Dual_Berettas
              overrideSkin = My.Settings.Dual_Berettas_SkinID
              overrideName = My.Settings.Dual_Berettas_SkinName
            Case Pistols.Five_Seven
              overrideSkin = My.Settings.Five_Seven_SkinID
              overrideName = My.Settings.Five_Seven_SkinName
            Case Pistols.Glock_18
              overrideSkin = My.Settings.Glock_18_SkinID
              overrideName = My.Settings.Glock_18_SkinName
            Case Pistols.Tec_9
              overrideSkin = My.Settings.Tec_9_SkinID
              overrideName = My.Settings.Tec_9_SkinName
            Case Pistols.P2000
              overrideSkin = My.Settings.P2000_SkinID
              overrideName = My.Settings.P2000_SkinName
            Case Pistols.P250
              overrideSkin = My.Settings.P250_SkinID
              overrideName = My.Settings.P250_SkinName
            Case Pistols.USP_S
              overrideSkin = My.Settings.USP_S_SkinID
              overrideName = My.Settings.USP_S_SkinName
            Case Pistols.CZ75_Auto
              overrideSkin = My.Settings.CZ75_Auto_SkinID
              overrideName = My.Settings.CZ75_Auto_SkinName
            Case Pistols.R8_Revolver
              overrideSkin = My.Settings.R8_Revolver_SkinID
              overrideName = My.Settings.R8_Revolver_SkinName
            Case Shotguns.XM1014
              overrideSkin = My.Settings.XM1014_SkinID
              overrideName = My.Settings.XM1014_SkinName
            Case Shotguns.MAG_7
              overrideSkin = My.Settings.MAG_7_SkinID
              overrideName = My.Settings.MAG_7_SkinName
            Case Shotguns.Sawed_Off
              overrideSkin = My.Settings.Sawed_Off_SkinID
              overrideName = My.Settings.Sawed_Off_SkinName
            Case Shotguns.Nova
              overrideSkin = My.Settings.Nova_SkinID
              overrideName = My.Settings.Nova_SkinName
            Case SMGs.MAC_10
              overrideSkin = My.Settings.MAC_10_SkinID
              overrideName = My.Settings.MAC_10_SkinName
            Case SMGs.P90
              overrideSkin = My.Settings.P90_SkinID
              overrideName = My.Settings.P90_SkinName
            Case SMGs.UMP_45
              overrideSkin = My.Settings.UMP_45_SkinID
              overrideName = My.Settings.UMP_45_SkinName
            Case SMGs.PP_Bizon
              overrideSkin = My.Settings.PP_Bizon_SkinID
              overrideName = My.Settings.PP_Bizon_SkinName
            Case SMGs.MP7
              overrideSkin = My.Settings.MP7_SkinID
              overrideName = My.Settings.MP7_SkinName
            Case SMGs.MP9
              overrideSkin = My.Settings.MP9_SkinID
              overrideName = My.Settings.MP9_SkinName
            Case Rifles.AK_47
              overrideSkin = My.Settings.AK_47_SkinID
              overrideName = My.Settings.AK_47_SkinName
            Case Rifles.AUG
              overrideSkin = My.Settings.AUG_SkinID
              overrideName = My.Settings.AUG_SkinName
            Case Rifles.FAMAS
              overrideSkin = My.Settings.FAMAS_SkinID
              overrideName = My.Settings.FAMAS_SkinName
            Case Rifles.Galil_AR
              overrideSkin = My.Settings.Galil_AR_SkinID
              overrideName = My.Settings.Galil_AR_SkinName
            Case Rifles.M4A4
              overrideSkin = My.Settings.M4A4_SkinID
              overrideName = My.Settings.M4A4_SkinName
            Case Rifles.SG_553
              overrideSkin = My.Settings.SG_553_SkinID
              overrideName = My.Settings.SG_553_SkinName
            Case Rifles.M4A1_S
              overrideSkin = My.Settings.M4A1_S_SkinID
              overrideName = My.Settings.M4A1_S_SkinName
            Case Snipers.AWP
              overrideSkin = My.Settings.AWP_SkinID
              overrideName = My.Settings.AWP_SkinName
            Case Snipers.G3SG1
              overrideSkin = My.Settings.G3SG1_SkinID
              overrideName = My.Settings.G3SG1_SkinName
            Case Snipers.SCAR_20
              overrideSkin = My.Settings.SCAR_20_SkinID
              overrideName = My.Settings.SCAR_20_SkinName
            Case Snipers.SSG_08
              overrideSkin = My.Settings.SSG_08_SkinID
              overrideName = My.Settings.SSG_08_SkinName
            Case Machineguns.M249
              overrideSkin = My.Settings.M249_SkinID
              overrideName = My.Settings.M249_SkinName
            Case Machineguns.Negev
              overrideSkin = My.Settings.Negev_SkinID
              overrideName = My.Settings.Negev_SkinName
            Case Else
              Continue While
          End Select

          If Player.Local.WeaponSkinId <> overrideSkin Then
            MemEdit.WriteInt32(weaponEntity + Offsets.m_iItemIDHigh, -1)
            MemEdit.WriteInt32(weaponEntity + Offsets.m_nFallbackPaintKit, overrideSkin)
            MemEdit.WriteInt32(weaponEntity + Offsets.m_nFallbackSeed, 1)
            MemEdit.WriteFloat(weaponEntity + Offsets.m_flFallbackWear, 0.000001F)

            Dim overrideStatTrack As Integer? = Settings.SkinChangerStatTrakKills

            If overrideStatTrack.HasValue Then
              MemEdit.WriteInt32(weaponEntity + Offsets.m_iAccountID, Player.Local.WeaponXuid)
              MemEdit.WriteInt32(weaponEntity + Offsets.m_nFallbackStatTrak, overrideStatTrack)
            End If

            If overrideName <> Nothing Then MemEdit.WriteAsciiString(weaponEntity + Offsets.m_szCustomName, overrideName)
          End If

          If GetAsyncKeyState(Keys.NumPad0) Then Utils.ForceUpdate()

        End If
      End While
    End Sub
  End Class
End Namespace