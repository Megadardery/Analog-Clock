﻿Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            On Error Resume Next
            If My.Computer.Registry.CurrentUser.OpenSubKey("Software\Analog Clock").GetValue("Data") <> Nothing Then
                frmTheClock.LoadOptions()
            Else
                frmOptions.Type.SelectedIndex = 1
            End If
            If frmOptions.chkSplash.Checked = False Then Application.MainForm = frmTheClock
        End Sub
    End Class


End Namespace
