Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Class frmOptions
    Dim AlarmIsEnabled As Boolean = False
    Friend Mode As Drawing2D.LinearGradientMode

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Me.Close()
    End Sub


    Private Sub BG_C1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClockColor1.Click
        ColorDialog1.Color = frmTheClock.Used_Color.Analog_Color1
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            CC1.BackColor = ColorDialog1.Color
            frmTheClock.Used_Color.Analog_Color1 = ColorDialog1.Color
        End If
    End Sub

    Private Sub BG_C2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClockColor2.Click
        ColorDialog1.Color = frmTheClock.Used_Color.Analog_Color2
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            CC2.BackColor = ColorDialog1.Color
            frmTheClock.Used_Color.Analog_Color2 = ColorDialog1.Color
        End If
    End Sub

    Private Sub BG_NC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNumbersColor.Click
        ColorDialog1.Color = frmTheClock.Used_Color.Analog_NumberColor
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            P3.ForeColor = ColorDialog1.Color
            frmTheClock.Used_Color.Analog_NumberColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub BG_NBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNumbersBackColor.Click
        ColorDialog1.Color = frmTheClock.Used_Color.Analog_NumberBackColor
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            P3.BackColor = Color.FromArgb(Alpha.Value, ColorDialog1.Color)
            frmTheClock.Used_Color.Analog_NumberBackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub HS_H_C1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHourColor1.Click
        ColorDialog1.Color = frmTheClock.Used_Color.Hour_Color1
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            HC1.BackColor = ColorDialog1.Color
            frmTheClock.Used_Color.Hour_Color1 = ColorDialog1.Color
        End If
    End Sub

    Private Sub HS_H_C2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHourColor2.Click
        ColorDialog1.Color = frmTheClock.Used_Color.Hour_Color2
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            HC2.BackColor = ColorDialog1.Color
            frmTheClock.Used_Color.Hour_Color2 = ColorDialog1.Color
        End If
    End Sub

    Private Sub HS_M_C1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinuteColor1.Click
        ColorDialog1.Color = frmTheClock.Used_Color.Minute_Color1
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            MC1.BackColor = ColorDialog1.Color
            frmTheClock.Used_Color.Minute_Color1 = ColorDialog1.Color
        End If
    End Sub

    Private Sub HS_M_C2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinuteColor2.Click
        ColorDialog1.Color = frmTheClock.Used_Color.Minute_Color2
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            MC2.BackColor = ColorDialog1.Color
            frmTheClock.Used_Color.Minute_Color2 = ColorDialog1.Color
        End If
    End Sub

    Private Sub HS_S_C_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSecondColor.Click
        ColorDialog1.Color = frmTheClock.Used_Color.Second_Color
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            SC.BackColor = ColorDialog1.Color
            frmTheClock.Used_Color.Second_Color = ColorDialog1.Color
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHide.CheckedChanged

        btnSecondColor.Enabled = Not chkHide.Checked
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        frmTheClock.Save(Imaging.PixelFormat.Format64bppPArgb)
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTransparent.CheckedChanged
        If chkTransparent.Checked = False Then
            frmTheClock.BackColor = System.Drawing.SystemColors.Control
            frmTheClock.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        Else
            frmTheClock.BackColor = System.Drawing.SystemColors.ActiveCaption
            frmTheClock.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNumbersFont.Click
        FontDialog1.ShowDialog()
        P3.Font = FontDialog1.Font
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        frmTheClock.Y -= 1
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeft.Click
        frmTheClock.X -= 1
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRight.Click
        frmTheClock.X += 1
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        frmTheClock.Y += 1
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        frmNumbers.ShowDialog()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetPage.Click
        If TabControl1.SelectedIndex = 0 Then
            CC1.BackColor = Color.Black
            frmTheClock.Used_Color.Analog_Color1 = Color.Black

            rdbCircle.Checked = True

            CC2.BackColor = Color.White
            frmTheClock.Used_Color.Analog_Color2 = Color.White

            rdbAngle.Checked = True
            Angle.Value = 90
            Type.SelectedIndex = -1

            rdbHigh.Checked = True

            chkTransparent.Checked = True


            chkShowHands.Checked = False

            chkStartWithWindows.Checked = False
        Else

            rdb1st.Checked = True
            Alpha.Value = 20
            P3.ForeColor = Color.LightGray
            frmTheClock.Used_Color.Analog_NumberColor = Color.LightGray
            P3.BackColor = Color.FromArgb(Alpha.Value, Color.White)
            frmTheClock.Used_Color.Analog_NumberBackColor = Color.White
            P3.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            frmTheClock.X = 0
            frmTheClock.Y = 0

            frmTheClock.One.X = 0
            frmTheClock.One.Y = 0

            frmTheClock.Two.X = 0
            frmTheClock.Two.Y = 0

            frmTheClock.Three.X = 0
            frmTheClock.Three.Y = 0

            frmTheClock.Four.X = 0
            frmTheClock.Four.Y = 0

            frmTheClock.Five.X = 0
            frmTheClock.Five.Y = 0

            frmTheClock.Six.X = 0
            frmTheClock.Six.Y = 0

            frmTheClock.Seven.X = 0
            frmTheClock.Seven.Y = 0

            frmTheClock.Eight.X = 0
            frmTheClock.Eight.Y = 0

            frmTheClock.Nine.X = 0
            frmTheClock.Nine.Y = 0

            frmTheClock.Ten.X = 0
            frmTheClock.Ten.Y = 0

            frmTheClock.Eleven.X = 0
            frmTheClock.Eleven.Y = 0

            frmTheClock.Twelve.X = 0
            frmTheClock.Twelve.Y = 0

            HC1.BackColor = Color.Black
            MC1.BackColor = Color.Black
            SC.BackColor = Color.Black

            HC2.BackColor = Color.White
            MC2.BackColor = Color.White

            frmTheClock.Used_Color.Hour_Color1 = Color.Black
            frmTheClock.Used_Color.Hour_Color2 = Color.White
            frmTheClock.Used_Color.Minute_Color1 = Color.Black
            frmTheClock.Used_Color.Minute_Color2 = Color.White
            frmTheClock.Used_Color.Second_Color = Color.Black

            chkHide.Checked = False
            btnSecondColor.Enabled = True

            CheckBox1.Checked = True
        End If

    End Sub

    Friend Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        If TabControl1.SelectedIndex = 0 Then
            btnResetPage.PerformClick()
            TabControl1.SelectedIndex = 1
            btnResetPage.PerformClick()
            TabControl1.SelectedIndex = 0
        Else
            btnResetPage.PerformClick()
            TabControl1.SelectedIndex = 0
            btnResetPage.PerformClick()
            TabControl1.SelectedIndex = 1
        End If
    End Sub

    Private Sub SecondType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb2nd.CheckedChanged
        Me.btnNumbersFont.Enabled = Not rdb2nd.Checked
    End Sub

    Private Sub Circle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCircle.CheckedChanged
        frmTheClock.Redraw(Imaging.PixelFormat.Format64bppPArgb)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Static a As Integer = 0
        a += 1
        If a >= 1000 Then
            a = 0
            Dialog1_FormClosed(Nothing, Nothing)
        End If
        lblTime.Text = Now.ToString
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        AboutBox1.ShowDialog()
    End Sub

    Friend Sub Dialog1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Dim AdjustType, ColorType, NumbersType As Byte
        If rdbAngle.Checked = True Then
            AdjustType = 1
            ColorType = Angle.Value
        Else
            AdjustType = 2
            ColorType = Type.SelectedIndex
        End If

        If rdb1st.Checked = True Then
            NumbersType = 1
        ElseIf rdb2nd.Checked = True Then
            NumbersType = 2
        Else
            NumbersType = 3
        End If

        Dim Text() As String = {CC1.BackColor.ToArgb, CC2.BackColor.ToArgb, P3.Font.FontFamily.Name, P3.ForeColor.ToArgb, frmTheClock.Used_Color.Analog_NumberBackColor.ToArgb,
                                HC1.BackColor.ToArgb, HC2.BackColor.ToArgb, MC1.BackColor.ToArgb, MC2.BackColor.ToArgb, SC.BackColor.ToArgb, rdbCircle.Checked, rdbHigh.Checked,
                                chkTransparent.Checked, AdjustType, chkShowHands.Checked, chkHide.Checked, NumbersType, chkStartWithWindows.Checked, frmTheClock.Location.X,
                                frmTheClock.Location.Y, ColorType, Alpha.Value, frmTheClock.X, frmTheClock.Y,
                                frmTheClock.One.X, frmTheClock.One.Y, frmTheClock.Two.X, frmTheClock.Two.Y, frmTheClock.Three.X, frmTheClock.Three.Y, frmTheClock.Four.X, frmTheClock.Four.Y,
                                frmTheClock.Five.X, frmTheClock.Five.Y, frmTheClock.Six.X, frmTheClock.Six.Y, frmTheClock.Seven.X, frmTheClock.Seven.Y, frmTheClock.Eight.X, frmTheClock.Eight.Y,
                                frmTheClock.Nine.X, frmTheClock.Nine.Y, frmTheClock.Ten.X, frmTheClock.Ten.Y, frmTheClock.Eleven.X, frmTheClock.Eleven.Y, frmTheClock.Twelve.X, frmTheClock.Twelve.Y, chkSplash.Checked, Not frmTheClock.HideName, CheckBox1.Checked}

        My.Computer.Registry.CurrentUser.CreateSubKey("Software\Analog Clock").SetValue("Data", Join(Text, "|"))

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStartWithWindows.CheckedChanged
        If chkStartWithWindows.Checked = True Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "Analog", Application.ExecutablePath)

        Else
            My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue("Analog")

        End If

    End Sub

    Private Sub rdbs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAngle.CheckedChanged, rdbType.CheckedChanged
        Angle.Enabled = rdbAngle.Checked
        Type.Enabled = Not rdbAngle.Checked

    End Sub

    Private Sub Type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Type.SelectedIndexChanged
        If Type.SelectedIndex = 0 Then Mode = Drawing2D.LinearGradientMode.ForwardDiagonal
        If Type.SelectedIndex = 1 Then Mode = Drawing2D.LinearGradientMode.BackwardDiagonal
        If Type.SelectedIndex = 2 Then Mode = Drawing2D.LinearGradientMode.Horizontal
        If Type.SelectedIndex = 3 Then Mode = Drawing2D.LinearGradientMode.Vertical
    End Sub

    Private Sub rdbSquare_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSquare.CheckedChanged
        frmTheClock.Square = rdbSquare.Checked
    End Sub

    Private Sub HourTimer_1_TextChanged(ByVal sender As TextBox, ByVal e As System.EventArgs) Handles HourTimer_1.TextChanged
        On Error GoTo Check
        Integer.Parse(sender.Text)

        Select Case Val(sender.Text)
            Case Is > 12, Is < 1
Check:          pnlPanel.BackColor = Color.Red
                Exit Sub
            Case Else
                pnlPanel.BackColor = Color.Green
        End Select

    End Sub

    Private Sub MinuteTimer_1_TextChanged(ByVal sender As TextBox, ByVal e As System.EventArgs) Handles MinuteTimer_1.TextChanged
        On Error GoTo Check
        Integer.Parse(sender.Text)

        Select Case Val(sender.Text)
            Case Is > 59, Is < 0
Check:          pnlPanel.BackColor = Color.Red
                Exit Sub
            Case Else
                pnlPanel.BackColor = Color.Green
        End Select

    End Sub

    Private Sub pnlPanel_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPanel.BackColorChanged
        If pnlPanel.BackColor = Color.Red Then AlarmIsEnabled = False Else AlarmIsEnabled = True

    End Sub

    Private Sub frmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
