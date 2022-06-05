Namespace Important

  Public Class Process

    Private Declare Function OpenProcess Lib "kernel32.dll" (dwDesiredAcess As UInteger, bInheritHandle As Boolean, dwProcessId As Integer) As IntPtr
    Private Declare Function CloseHandle Lib "kernel32.dll" (hObject As IntPtr) As Boolean
    Private Shared _targetProcess As Diagnostics.Process = Nothing
    Private Shared _targetProcessHandle As IntPtr = IntPtr.Zero
    Private Const ProcessVmRead As UInteger = &H10
    Private Const ProcessVmWrite As UInteger = &H20
    Private Const ProcessVmOperation As UInteger = &H8
    Public Shared ClientDll As IntPtr
    Public Shared EngineDll As IntPtr

    Public Shared Function TryAttachToProcess(windowCaption As String) As Boolean
      Dim allProcesses() = Diagnostics.Process.GetProcesses
      Dim validProcesses = allProcesses.Where(Function(x) x.MainWindowTitle = windowCaption).ToList()
      If Not validProcesses.Any Then Return False
      If validProcesses.Count() > 1 Then MessageBox.Show($"More then 1 Process, called {windowCaption}, found")

      Return TryAttachToProcess(validProcesses.First())
    End Function

    Public Shared Function TryAttachToProcess(proc As Diagnostics.Process) As Boolean
      _targetProcess = proc
      _targetProcessHandle = OpenProcess(ProcessVmRead Or ProcessVmWrite Or ProcessVmOperation, False, _targetProcess.Id)

      Return _targetProcessHandle
    End Function

    Private Shared Function GetModule(dll As String) As Integer
      For Each csgoModule As ProcessModule In _targetProcess.Modules
        If Right(csgoModule.FileName, dll.Length + 1) = "\" & dll Then Return csgoModule.BaseAddress
      Next
      MessageBox.Show($"Baseaddress for {dll} couldn't be found")
      End
    End Function

    Public Shared Sub InitializeModules()
      ClientDll = GetModule("client.dll")
      EngineDll = GetModule("engine.dll")
    End Sub

    Public Shared Function GetHandle() As IntPtr
      Return _targetProcessHandle
    End Function

    Public Shared Sub DetachFromProcess()
      If Not _targetProcessHandle = IntPtr.Zero Then
        _targetProcess = Nothing
        Try
          CloseHandle(_targetProcessHandle)
          _targetProcessHandle = IntPtr.Zero
        Catch ex As Exception
          MessageBox.Show("Prozess konnte nicht abgekoppelt werden.")
        End Try
      End If
    End Sub
  End Class
End Namespace