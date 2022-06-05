Imports System.IO

Namespace Important
  Class FileReader
    Private Shared _mBigEndian As Boolean = False

    Public Shared Property BigEndian As Boolean
      Get
        Return _mBigEndian
      End Get
      Set
        _mBigEndian = Value
      End Set
    End Property

    Public Shared Function ReadByte(stream As Stream) As Byte
      Dim buffer = ReadBytes(stream, 1)
      Return buffer(0)
    End Function

    Public Shared Function ReadShort(stream As Stream) As Short
      Dim buffer = ReadBytes(stream, 2)
      If _mBigEndian Then
        buffer.Reverse()
      End If
      Return BitConverter.ToInt16(buffer, 0)
    End Function

    Public Shared Function ReadUShort(stream As Stream) As UShort
      Dim buffer = ReadBytes(stream, 2)
      If _mBigEndian Then
        buffer.Reverse()
      End If
      Return BitConverter.ToUInt16(buffer, 0)
    End Function

    Public Shared Function ReadInt(stream As Stream) As Integer
      Dim buffer = ReadBytes(stream, 4)
      If _mBigEndian Then
        buffer.Reverse()
      End If
      Return BitConverter.ToInt32(buffer, 0)
    End Function

    Public Shared Function ReadUInt(stream As Stream) As UInteger
      Dim buffer = ReadBytes(stream, 4)
      If _mBigEndian Then
        buffer.Reverse()
      End If
      Return BitConverter.ToUInt32(buffer, 0)
    End Function

    Public Shared Function ReadLong(stream As Stream) As Long
      Dim buffer = ReadBytes(stream, 8)
      If _mBigEndian Then
        buffer.Reverse()
      End If
      Return BitConverter.ToInt64(buffer, 0)
    End Function

    Public Shared Function ReadFloat(stream As Stream) As Single
      Dim buffer = ReadBytes(stream, 4)
      If _mBigEndian Then
        buffer.Reverse()
      End If
      Return BitConverter.ToSingle(buffer, 0)
    End Function

    Public Shared Function ReadBytes(stream As Stream, count As Integer) As Byte()
      Dim buffer = New Byte(count - 1) {}
      stream.Read(buffer, 0, count)
      Return buffer
    End Function
  End Class
End Namespace