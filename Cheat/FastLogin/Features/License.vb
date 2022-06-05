Imports Portable.Licensing.Validation
Imports Portable.Licensing
Imports System.IO

Public Class License
  Public Shared license As Portable.Licensing.License
  Public Shared ioStream As Stream
  Public Shared type As LicenseType
  Public Shared Sub Load()
    If Not (File.Exists(Environment.CurrentDirectory + "\license.lic")) Then
      Dim of_Dialog As New OpenFileDialog()
      of_Dialog.Filter = "License (*.lic)|*.lic"
      of_Dialog.FilterIndex = 1
      of_Dialog.RestoreDirectory = True

      If of_Dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        Try
          ioStream = of_Dialog.OpenFile()
          If (ioStream IsNot Nothing) Then
            license = Portable.Licensing.License.Load(ioStream)
            type = license.Type
          End If
        Catch Ex As Exception
          MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
        Finally
          ' Check this again, since we need to make sure we didn't throw an exception on open.
          If (ioStream IsNot Nothing) Then
            ioStream.Close()
          End If
        End Try
      End If
    Else
      Try
        ioStream = File.OpenRead(Environment.CurrentDirectory + "\license.lic")
        If (ioStream IsNot Nothing) Then
          license = Portable.Licensing.License.Load(ioStream)
          type = license.Type
        End If
      Catch Ex As Exception
        MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
      Finally
        ' Check this again, since we need to make sure we didn't throw an exception on open.
        If (ioStream IsNot Nothing) Then
          ioStream.Close()
        End If
      End Try
    End If

  End Sub
  Public Shared Function ValidateCurrent(pubKey As String) As String
    If (pubKey.Length < 64) Then
      Return "Invalid keylength"
    Else

      Dim keyGenerator = Portable.Licensing.Security.Cryptography.KeyGenerator.Create()
      Dim keyPair = keyGenerator.GenerateKeyPair()
      Dim publicKey = keyPair.ToPublicKeyString()

      Dim ReturnValue As String = "Valid"
      Dim validationFailures = license.Validate().ExpirationDate().And().Signature(pubKey).AssertValidLicense()
      If (Not IsNothing(validationFailures)) Then
        ReturnValue = "Valid"
        For Each validationFailure As IValidationFailure In validationFailures
          ReturnValue = ReturnValue & validationFailure.HowToResolve & ": " & vbNewLine & validationFailure.Message & vbNewLine & "deleting itself now!"
        Next
      End If

      Return ReturnValue
    End If
  End Function

End Class
