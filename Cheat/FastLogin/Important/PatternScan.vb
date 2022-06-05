Imports System.Globalization
Imports System.Text.RegularExpressions

Namespace Important

  Public Class PatternScan
    Public Shared Function Scan(dll As Integer, pattern As String, options As Integer, offsetAdress As Integer, subtraction As Boolean) As Integer
      Dim offset = BitConverter.ToInt32(MemEdit.ReadBytes(ScanFunction(dll, &H1800000, pattern, 0) + options, 4), 0) + offsetAdress
      If subtraction Then offset -= dll
      Return offset
    End Function

    Private Shared Function ScanFunction(base As Integer, range As Integer, signature As String, instance As Integer) As Integer
      If signature <> String.Empty Then
        Dim nString = Regex.Replace(signature.Replace("??", "3F"), "[^a-fA-F0-9]", "")
        Dim c = -1
        Dim search = New Byte((nString.Length / 2) - 1) {}

        For i = 0 To search.Length - 1
          search(i) = Byte.Parse(nString.Substring(i * 2, 2), NumberStyles.HexNumber)
        Next i

        Dim sIn = MemEdit.ReadBytes(base, range)

        Dim z = 0, p = 0
        Dim iEnd = If(search.Length < &H20, search.Length, &H20)
        Dim sBytes = New Integer(&H100 - 1) {}

        For j = 0 To iEnd - 1
          If search(j) = &H3F Then
            z = (z Or (1 << ((iEnd - j) - 1)))
          End If
        Next j

        If z <> 0 Then
          For k = 0 To sBytes.Length - 1
            sBytes(k) = z
          Next k
        End If

        z = 1
        Dim index = iEnd - 1

        While index >= 0
          sBytes(search(index)) = sBytes(search(index)) Or z
          index -= 1
          z = z << 1
        End While

        While p <= (sIn.Length - search.Length)
          z = search.Length - 1
          Dim last As Integer = search.Length
          Dim m As Integer = -1

          While m <> 0
            m = m And sBytes(sIn(p + z))
            If m <> 0 Then
              If z = 0 Then
                c += 1
                If c = instance Then Return base + p
                p += 2
              End If
              last = z
            End If
            z -= 1
            m = m << 1
          End While
          p += last
        End While
      End If
      Return -1
    End Function

  End Class
End Namespace