Public NotInheritable Class frmSplash


    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub Splash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If My.Computer.Registry.CurrentUser.OpenSubKey("Software\Analog Clock").GetValue("Data") <> Nothing Then
                frmTheClock.LoadOptions()
            End If

        Catch

            frmOptions.Button8_Click(Nothing, Nothing)

        End Try


        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.ToString)
        lblCompanyName.Text = My.Application.Info.CompanyName
        Copyright.Text = My.Application.Info.Copyright
    End Sub

    Private Sub Splash_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        For counter As Double = 0.0# To 1.0# Step 0.04#
            Me.Opacity = counter
            Me.Refresh()
            Threading.Thread.Sleep(10)
        Next
        Threading.Thread.Sleep(2500)
        Me.Close()
    End Sub

    Private Sub Splash_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        For counter As Double = 1.0# To 0.0# Step -0.04#
            Me.Opacity = counter
            Me.Refresh()
            Threading.Thread.Sleep(10)
        Next
        Me.Visible = False
        frmTheClock.ShowDialog()
    End Sub

    Private Sub MainLayoutPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MainLayoutPanel.Paint

    End Sub
End Class
