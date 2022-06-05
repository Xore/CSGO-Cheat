Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports System.Management
Imports System.Diagnostics
Imports FastLogin.License
Public Class Verification
  Private Shared Function GenerateHwidString() As String
    Dim mainboardString = ""
    Dim productkeyString = ""

    Const queryMainboard = "Select SerialNumber From Win32_BaseBoard"
    Const queryProductkey = "SELECT SerialNumber FROM Win32_OperatingSystem"

    Using mbs = New ManagementObjectSearcher(queryMainboard)
      For Each mo As ManagementObject In mbs.Get
        For Each pd As PropertyData In mo.Properties
          ' should be only one
          If pd.Name = "SerialNumber" Then
            ' value is object, test for Nothing
            If pd.Value IsNot Nothing Then
              mainboardString = pd.Value.ToString
            End If
            Exit For
          End If
        Next
      Next
    End Using

    Using mbs = New ManagementObjectSearcher(queryProductkey)
      For Each product As ManagementObject In mbs.Get
        For Each pd As PropertyData In product.Properties
          ' should be only one
          If pd.Name = "SerialNumber" Then
            ' value is object, test for Nothing
            If pd.Value IsNot Nothing Then
              productkeyString = pd.Value.ToString
            End If
            Exit For
          End If
        Next
      Next
    End Using

    Return (mainboardString + productkeyString).Replace(" ", "")
  End Function

  Public Function Hash512(password As String, salt As String) As String
    Dim convertedToBytes As Byte() = Encoding.UTF8.GetBytes(password & salt)
    Dim hashType As HashAlgorithm = New SHA512Managed()
    Dim hashBytes As Byte() = hashType.ComputeHash(convertedToBytes)
    Dim hashedResult As String = Convert.ToBase64String(hashBytes)
    Return hashedResult
  End Function

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    If (TextBox1.Text IsNot "" OrElse TextBox2.Text IsNot "") Then
      Dim hwid = GenerateHwidString()
      Dim cryptedPassword = Hash512(TextBox2.Text, hwid)
      cryptedPassword = cryptedPassword.Replace("+"c, "%2b")
            Dim request = CType(WebRequest.Create("https://URLHERE/login.php?Name=" & TextBox1.Text & "&Password=" & cryptedPassword & "&Hwid=" & hwid), HttpWebRequest)
            request.Method = "GET"
      request.ContentType = "text/plain"

      Dim response = CType(request.GetResponse(), HttpWebResponse)
      Dim dataStream = response.GetResponseStream()
      Dim reader As New StreamReader(dataStream)
      Dim responseFromServer = reader.ReadToEnd()

      Dim answer() = responseFromServer.Split(" ")

      If (answer(0) = "isvalid") Then
        Dim pubKey = answer(1)
        License.Load()
        Dim valid = License.ValidateCurrent(pubKey)
        If (valid = "Valid") Then
          Hack.Show()
          Me.Hide()
        ElseIf (valid = "Invalid keylength") Then
          MessageBox.Show("Please enter a valid publickey!")
        Else
          MessageBox.Show(valid)
          System.Diagnostics.Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath)
          Application.Exit()
        End If
      Else
        MessageBox.Show("Data isn't valid or the cheat is not activated for you.")
      End If

      reader.Close()
      dataStream.Close()
      response.Close()
    End If
  End Sub
End Class