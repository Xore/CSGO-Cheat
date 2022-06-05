Imports System.Runtime.InteropServices
Imports System.Text

Namespace Important

  Public Class MemEdit

    Shared _targetProcessHandle As IntPtr
    Private Declare Function ReadProcessMemory Lib "kernel32" (hProcess As IntPtr, lpBaseAddress As IntPtr, lpBuffer() As Byte, iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    Private Declare Function WriteProcessMemory Lib "kernel32" (hProcess As IntPtr, lpBaseAddress As IntPtr, lpBuffer As Byte(), nSize As IntPtr, <Out()> ByRef lpNumberOfBytesWritten As IntPtr) As Boolean

    Public Shared Sub SetProcessHandle(handle As IntPtr)
      _targetProcessHandle = handle
    End Sub

    Public Shared Function WriteInt32(address As IntPtr, data As Integer) As Boolean
      Return WriteProcessMemory(_targetProcessHandle, address, BitConverter.GetBytes(data), 4, New Int32)
    End Function

    Public Shared Function WriteFloat(address As IntPtr, data As Single) As Boolean
      Return WriteProcessMemory(_targetProcessHandle, address, BitConverter.GetBytes(data), 4, New Int32)
    End Function

    Public Shared Function WriteFVector(address As IntPtr, vector As FVector) As Boolean
      WriteProcessMemory(_targetProcessHandle, address, BitConverter.GetBytes(vector.X.Value), 4, New Int32)
      WriteProcessMemory(_targetProcessHandle, address + &H4, BitConverter.GetBytes(vector.Y.Value), 4, New Int32)
      Return WriteProcessMemory(_targetProcessHandle, address + &H8, BitConverter.GetBytes(vector.Z.Value), 4, New Int32)
    End Function

    Public Shared Function WriteUnicodeString(address As IntPtr, str As String) As Boolean
      Dim bytes() As Byte = Encoding.Unicode.GetBytes(str)
      Return WriteProcessMemory(_targetProcessHandle, address, bytes, bytes.Length, str.Length - 1)
    End Function

    Public Shared Function WriteUtf8String(address As IntPtr, str As String) As Boolean
      Dim bytes() As Byte = Encoding.UTF8.GetBytes(str)
      Return WriteProcessMemory(_targetProcessHandle, address, bytes, bytes.Length, str.Length - 1)
    End Function

    Public Shared Function WriteAsciiString(address As IntPtr, str As String) As Boolean
      Dim bytes() As Byte = Encoding.ASCII.GetBytes(str)
      Return WriteProcessMemory(_targetProcessHandle, address, bytes, bytes.Length, str.Length - 1)
    End Function

    Public Shared Function WriteString(address As IntPtr, str As String) As Boolean
      Dim bytes() As Byte = Encoding.Default.GetBytes(str)
      Return WriteProcessMemory(_targetProcessHandle, address, bytes, bytes.Length, str.Length - 1)
    End Function

    Public Shared Function WriteByte(addr As IntPtr, aByte As Byte) As Boolean
      Dim bts() As Byte = {aByte}
      Return WriteProcessMemory(_targetProcessHandle, addr, bts, 1, New Int32)
    End Function

    Public Shared Function WriteBytes(addr As IntPtr, pBytes As Byte()) As Boolean
      Return WriteProcessMemory(_targetProcessHandle, addr, pBytes, pBytes.Length, 0)
    End Function

    Public Shared Function WriteStruct(Of T)(address As Integer, mystruct As T)
      Dim pointer = Marshal.AllocHGlobal(Marshal.SizeOf(mystruct))
      Dim byteArray(Marshal.SizeOf(mystruct) - 1) As Byte

      Marshal.StructureToPtr(mystruct, pointer, False)

      Marshal.Copy(pointer, byteArray, 0, Marshal.SizeOf(mystruct))
      Marshal.FreeHGlobal(pointer)

      Return WriteBytes(address, byteArray)
    End Function

    Public Shared Function ReadInt32(address As IntPtr) As Integer
      Dim countBytes(3) As Byte
      ReadProcessMemory(_targetProcessHandle, address, countBytes, 4, vbNull)
      Return BitConverter.ToInt32(countBytes, 0)
    End Function

    Public Shared Function ReadFloat(address As IntPtr) As Single
      Dim countBytes(3) As Byte
      ReadProcessMemory(_targetProcessHandle, address, countBytes, 4, vbNull)
      Return BitConverter.ToSingle(countBytes, 0)
    End Function

    Public Shared Function ReadBytes(addr As IntPtr, size As Integer) As Byte()
      Dim rtnBytes(size - 1) As Byte
      ReadProcessMemory(_targetProcessHandle, addr, rtnBytes, size, vbNull)
      Return rtnBytes
    End Function

    Public Shared Function ReadUnicodeString(addr As IntPtr, size As Integer) As String
      Dim text As Byte() = ReadBytes(addr, size)
      Return Encoding.Unicode.GetString(text).Split(vbNullChar).First()
    End Function

    Public Shared Function ReadAsciiString(addr As IntPtr, size As Integer) As String
      Dim text As Byte() = ReadBytes(addr, size)
      Return Encoding.ASCII.GetString(text).Split(vbNullChar).First()
    End Function

    Public Shared Function ReadUtf8String(addr As IntPtr, size As Integer) As String
      Dim text As Byte() = ReadBytes(addr, size)
      Return Encoding.UTF8.GetString(text).Split(vbNullChar).First()
    End Function

    Public Shared Function ReadFVector(address As IntPtr) As FVector
      Dim vector As New FVector
      Dim countBytes(3) As Byte
      ReadProcessMemory(_targetProcessHandle, address, countBytes, 4, vbNull)
      vector.X = BitConverter.ToSingle(countBytes, 0)
      ReadProcessMemory(_targetProcessHandle, address + &H4, countBytes, 4, vbNull)
      vector.Y = BitConverter.ToSingle(countBytes, 0)
      ReadProcessMemory(_targetProcessHandle, address + &H8, countBytes, 4, vbNull)
      vector.Z = BitConverter.ToSingle(countBytes, 0)
      Return vector
    End Function

    Public Shared Function ReadMemory(Of T)(address As Integer) As T
      Dim buffer As Byte()
      Dim length As Integer = Marshal.SizeOf(GetType(T))

      If GetType(T) Is GetType(Byte()) Then
        buffer = New Byte(length - 1) {}
      Else
        buffer = New Byte(Marshal.SizeOf(GetType(T)) - 1) {}
      End If

      If Not ReadProcessMemory(_targetProcessHandle, New IntPtr(address), buffer, New IntPtr(buffer.Length), IntPtr.Zero) Then Return Nothing

      If GetType(T) Is GetType(Byte()) Then Return CType(CType(buffer, Object), T)

      Dim gcHandle As GCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned)
      Dim returnObject As T
      returnObject = CType(Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject, GetType(T)), T)
      gcHandle.Free()
      Return returnObject
    End Function
  End Class
End Namespace