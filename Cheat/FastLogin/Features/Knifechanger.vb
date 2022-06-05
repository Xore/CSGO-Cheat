Imports FastLogin.Important

Namespace Features
  Public Class KnifeChanger

    ''' <summary>
    ''' Klappt gerade nur Lokal
    ''' </summary>
    Public Shared Sub KnifeChanger()
      Dim knifeId As Integer
      Dim needIndexes = True
      Dim startPoint As Integer

      While Settings.KnifeChanger
        If Not Utils.IsIngame() Then needIndexes = True

        Dim knifeModel = 4
        Dim weaponBase As Integer = Player.Local.WeaponEntity
        Dim weaponDefId As Integer = Player.Local.WeaponId

        If needIndexes Then
          Dim hWeapon As Integer = MemEdit.ReadInt32(Player.Local.Pointer + Offsets.m_hViewModel)
          Dim knifeBase As Integer = MemEdit.ReadInt32(Process.ClientDll + Offsets.EntityList + ((hWeapon And &HFFF) - 1) * &H10)


          Select Case weaponDefId
            Case Pistols.USP_S
              startPoint = MemEdit.ReadInt32(knifeBase + Offsets.m_nModelIndex)
              knifeId = startPoint + 25 + (3 * knifeModel - 3)
              needIndexes = False
            Case Pistols.Glock_18
              startPoint = MemEdit.ReadInt32(knifeBase + Offsets.m_nModelIndex)
              knifeId = startPoint + 249 + (3 * knifeModel - 3)
              needIndexes = False
            Case Pistols.P2000
              startPoint = MemEdit.ReadInt32(knifeBase + Offsets.m_nModelIndex)
              knifeId = startPoint + 102 + (3 * knifeModel - 3)
              needIndexes = False
            Case Pistols.Desert_Eagle
              startPoint = MemEdit.ReadInt32(knifeBase + Offsets.m_nModelIndex)
              knifeId = startPoint + 276 + (3 * knifeModel - 3)
              needIndexes = False
          End Select

        ElseIf Player.Local.WeaponClip = -1 And IsKnife(weaponDefId) And Not needIndexes And weaponBase >= 1000 Then
          Dim hWeapon As Integer = MemEdit.ReadInt32(Player.Local.Pointer + Offsets.m_hViewModel)
          Dim knifeBase As Integer = MemEdit.ReadInt32(Process.ClientDll + Offsets.EntityList + ((hWeapon And &HFFF) - 1) * &H10)

          If knifeBase >= 1000 Then
            'SetKnifeData(KnifeID)
            Dim skinModel = knifeId + 1
            Dim skinModel2 = knifeId

            If Player.Local.WeaponClip = -1 And IsKnife(weaponDefId) And MemEdit.ReadInt32(knifeBase + Offsets.m_nModelIndex) <> knifeId Then
              MemEdit.WriteInt32(knifeBase + Offsets.m_nModelIndex, knifeId)
            End If

            Dim tmpSkinModel = MemEdit.ReadInt32(weaponBase + Offsets.m_iWorldModelIndex)
            Dim tmpSkinModel2 = MemEdit.ReadInt32(weaponBase + Offsets.m_iWorldModelIndex + &H4)

            If Player.Local.WeaponClip = -1 And IsKnife(weaponDefId) And tmpSkinModel <> knifeId + 1 Or tmpSkinModel2 <> knifeId Then
              MemEdit.WriteInt32(weaponBase + Offsets.m_nModelIndex, skinModel2)
              MemEdit.WriteInt32(weaponBase + Offsets.m_iWorldModelIndex, skinModel)
              MemEdit.WriteInt32(weaponBase + Offsets.m_iWorldModelIndex + &H4, skinModel2)
            End If

            If Player.Local.WeaponClip = -1 And IsKnife(weaponDefId) And MemEdit.ReadInt32(weaponBase + Offsets.m_iItemDefinitionIndex) <> GetKnifeId(knifeModel) Then
              MemEdit.WriteInt32(weaponBase + Offsets.m_iItemDefinitionIndex, GetKnifeId(knifeModel))
            End If

          End If
        End If
      End While
    End Sub

    Private Shared Function IsKnife(weaponId As Integer) As Boolean
      Select Case weaponId
        Case 42, 59, 500, 505, 506, 507, 508, 509, 512, 514, 515, 516
          Return True
        Case Else
          Return False
      End Select
    End Function

    Private Shared Function GetKnifeId(id As Integer) As Integer
      Select Case id
        Case 1
          Return 500
        Case 2
          Return 505
        Case 3
          Return 506
        Case 4
          Return 507
        Case 5
          Return 508
        Case 6
          Return 509
        Case 7
          Return 512
        Case 8
          Return 514
        Case 9
          Return 515
        Case 10
          Return 516
        Case Else
          Return 42
      End Select
      '(m_iViewModelIndex, m_iWorldModelIndex, m_iItemDefinitionIndex)
      '(379, 380, 500), // KNIFE_BAYONET
      '(382, 383, 505), // KNIFE_FLIP
      '(385, 386, 506), // KNIFE_GUT
      '(388, 389, 507), // KNIFE_KARAMBIT
      '(391, 392, 508), // KNIFE_M9BAYONET
      '(394, 395, 509), // KNIFE_TACTICAL
      '(397, 398, 510), // KNIFE_FALCHION
      '(400, 401, 511), // KNIFE_BOWIE
      '(403, 404, 515), // KNIFE_BUTTERFLY
      '(406, 407, 516), // KNIFE_SHADOWDAGGERS
    End Function

  End Class
End Namespace