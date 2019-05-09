Public Class frmTheClock

#Region "Private Declares"

    Dim Clk_Gradient As New Drawing2D.Blend
    Dim Bitmap As New Bitmap(200, 200, Imaging.PixelFormat.Format64bppPArgb)
#End Region

    Friend X, Y As Integer
    Friend ShownCompleted As Boolean = False
    Friend HideName As Boolean
    Friend Square As Boolean = False
#Region "Numbers Structures"

    Structure One
        Shared X As Integer
        Shared Y As Integer
    End Structure

    Structure Two
        Shared X As Integer
        Shared Y As Integer
    End Structure

    Structure Three
        Shared X As Integer
        Shared Y As Integer
    End Structure

    Structure Four
        Shared X As Integer
        Shared Y As Integer
    End Structure

    Structure Five
        Shared X As Integer
        Shared Y As Integer
    End Structure

    Structure Six
        Shared X As Integer
        Shared Y As Integer
    End Structure

    Structure Seven
        Shared X As Integer
        Shared Y As Integer
    End Structure

    Structure Eight
        Shared X As Integer
        Shared Y As Integer
    End Structure

    Structure Nine
        Shared X As Integer
        Shared Y As Integer
    End Structure

    Structure Ten
        Shared X As Integer
        Shared Y As Integer
    End Structure

    Structure Eleven
        Shared X As Integer
        Shared Y As Integer
    End Structure

    Structure Twelve
        Shared X As Integer
        Shared Y As Integer
    End Structure

#End Region

#Region "Draw The Clock"

    Private Sub DrawClock(ByVal Bitmap As Bitmap, Optional ByVal DrawHands As Boolean = True)
        Dim Graphic As Graphics = Graphics.FromImage(Bitmap)
        Dim Clock_Font As Font = frmOptions.P3.Font
        'For Perfect Picture (Not Important)
        If frmOptions.rdbHigh.Checked = True Then
            Graphic.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            Graphic.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            Graphic.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            Graphic.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            Graphic.CompositingQuality = Drawing2D.CompositingQuality.AssumeLinear
        End If

        'Adjusting the gradient location points.
        Clk_Gradient.Positions = {0.0F, 0.1F, 0.3F, 0.4F, 0.5F, 0.6F, 0.7F, 0.8F, 1.0F}
        'Adjusting the gradient colors through 9 points, where 0.0F is the first color entirly, and 1.0F is the second color.
        Clk_Gradient.Factors = {0.0F, 0.2F, 0.5F, 0.7F, 1.0F, 0.7F, 0.5F, 0.2F, 0.0F}
        '---------------------------------------------------------------------------
        'Draw Analog Clock Background

        'This should be possible to change later
        Dim rect As New Rectangle(0, 0, 200, 200)

        'Defines the brush to drow the gradient
        Dim lgb As Drawing2D.LinearGradientBrush
        'Sets the gradient angle.
        Console.WriteLine(frmOptions.Mode.ToString)
        If frmOptions.rdbAngle.Checked Then
            lgb = New Drawing2D.LinearGradientBrush(rect, Used_Color.Analog_Color1, Used_Color.Analog_Color2, frmOptions.Angle.Value)
        Else
            lgb = New Drawing2D.LinearGradientBrush(rect, Used_Color.Analog_Color1, Used_Color.Analog_Color2, frmOptions.Mode)

        End If
        lgb.Blend = Clk_Gradient

        'fills the outer part of the clock
        If Square Then Graphic.FillRectangle(lgb, rect) Else Graphic.FillEllipse(lgb, rect)

        rect = New Rectangle(10, 10, 180, 180)

        'fills the inverted part of the clock (the part that appears to 'pop' out)
        lgb.LinearColors = New Color() {Used_Color.Analog_Color2, Used_Color.Analog_Color1}
        If Square Then Graphic.FillRectangle(lgb, rect) Else Graphic.FillEllipse(lgb, rect)


        'Uses some calculators to return something similar to (13,13,174,174)
        rect.X += 3 : rect.Y += 3 : rect.Width -= 2 * 3 : rect.Height -= 2 * 3
        'fills the rest of the clock
        lgb.LinearColors = New Color() {Used_Color.Analog_Color1, Used_Color.Analog_Color2}
        If Square Then Graphic.FillRectangle(lgb, rect) Else Graphic.FillEllipse(lgb, rect)

        '---------------------------------------------------------------------------

        'Draw Analog Clock Numbers Background

        Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()

        'Uses some calculators to return something similar to (20,20,160,160)
        Dim a As New Rectangle(20, 20, 160, 160)
        'Uses some calculators to return something similar to (40,40,120,120)
        Dim b As New Rectangle(40, 40, 120, 120)
        If Square Then
            path.AddRectangle(a)
            path.AddRectangle(b)
        Else
            path.AddEllipse(a)
            path.AddEllipse(b)
        End If


        Graphic.FillPath(New SolidBrush(Color.FromArgb(frmOptions.Alpha.Value, Used_Color.Analog_NumberBackColor)), path)
        '---------------------------------------------------------------------------

        'Draw Numbers

        Dim sbW As New SolidBrush(Used_Color.Analog_NumberColor)
        If HideName = False Then
            Using TheFont As New Font("Arial", 9.0F, FontStyle.Bold)
                Graphic.DrawString("Megadardery", TheFont, sbW, 62, 130)
            End Using
        End If
        If Square Then
            If frmOptions.rdb1st.Checked Then
                Graphic.DrawString("1", Clock_Font, sbW, (130 + X + One.X), (20 + Y + One.Y))
                Graphic.DrawString("2", Clock_Font, sbW, (161 + X + Two.X), (55 + Y + Two.Y))
                Graphic.DrawString("3", Clock_Font, sbW, (162 + X + Three.X), (90 + Y + Three.Y))
                Graphic.DrawString("4", Clock_Font, sbW, (161 + X + Four.X), (125 + Y + Four.Y))
                Graphic.DrawString("5", Clock_Font, sbW, (130 + X + Five.X), (157 + Y + Five.Y))
                Graphic.DrawString("6", Clock_Font, sbW, (93 + X + Six.X), (160 + Y + Six.Y))
                Graphic.DrawString("7", Clock_Font, sbW, (55 + X + Seven.X), (157 + Y + Seven.Y))
                Graphic.DrawString("8", Clock_Font, sbW, (23 + X + Eight.X), (125 + Y + Eight.Y))
                Graphic.DrawString("9", Clock_Font, sbW, (23 + X + Nine.X), (90 + Y + Nine.Y))
                Graphic.DrawString("10", Clock_Font, sbW, (20 + X + Ten.X), (55 + Y + Ten.Y))
                Graphic.DrawString("11", Clock_Font, sbW, (55 + X + Eleven.X), (20 + Y + Eleven.Y))
                Graphic.DrawString("12", Clock_Font, sbW, (89 + X + Twelve.X), (20 + Y + Twelve.Y))
            ElseIf frmOptions.rdb2nd.Checked Then
                Dim Clock_Font_Other As New Font("Bodoni MT Poster Compressed", 11.0F, FontStyle.Bold)
                Graphic.DrawString("I", Clock_Font_Other, sbW, (133 + X + One.X), (20 + Y + One.Y))
                Graphic.DrawString("II", Clock_Font_Other, sbW, (164 + X + Two.X), (55 + Y + Two.Y))
                Graphic.DrawString("III", Clock_Font_Other, sbW, (165 + X + Three.X), (90 + Y + Three.Y))
                Graphic.DrawString("IV", Clock_Font_Other, sbW, (164 + X + Four.X), (125 + Y + Four.Y))
                Graphic.DrawString("V", Clock_Font_Other, sbW, (133 + X + Five.X), (160 + Y + Five.Y))
                Graphic.DrawString("VI", Clock_Font_Other, sbW, (96 + X + Six.X), (160 + Y + Six.Y))
                Graphic.DrawString("VII", Clock_Font_Other, sbW, (58 + X + Seven.X), (159 + Y + Seven.Y))
                Graphic.DrawString("VIII", Clock_Font_Other, sbW, (21 + X + Eight.X), (125 + Y + Eight.Y))
                Graphic.DrawString("IX", Clock_Font_Other, sbW, (25 + X + Nine.X), (90 + Y + Nine.Y))
                Graphic.DrawString("X", Clock_Font_Other, sbW, (25 + X + Ten.X), (55 + Y + Ten.Y))
                Graphic.DrawString("XI", Clock_Font_Other, sbW, (58 + X + Eleven.X), (20 + Y + Eleven.Y))
                Graphic.DrawString("XII", Clock_Font_Other, sbW, (92 + X + Twelve.X), (20 + Y + Twelve.Y))
            Else
                Graphic.DrawString("_", Clock_Font, sbW, (162 + X + Three.X), (85 + Y + Three.Y))
                Graphic.DrawString("|", Clock_Font, sbW, (95 + X + Six.X), (160 + Y + Six.Y))
                Graphic.DrawString("_", Clock_Font, sbW, (23 + X + Nine.X), (85 + Y + Nine.Y))
                Graphic.DrawString("|", Clock_Font, sbW, (95 + X + Twelve.X), (20 + Y + Twelve.Y))
            End If
            '---------------------------------------------------------------------------
        Else
            If frmOptions.rdb1st.Checked Then
                Graphic.DrawString("1", Clock_Font, sbW, (130 + X + One.X), (30 + Y + One.Y))
                Graphic.DrawString("2", Clock_Font, sbW, (153 + X + Two.X), (55 + Y + Two.Y))
                Graphic.DrawString("3", Clock_Font, sbW, (162 + X + Three.X), (90 + Y + Three.Y))
                Graphic.DrawString("4", Clock_Font, sbW, (153 + X + Four.X), (125 + Y + Four.Y))
                Graphic.DrawString("5", Clock_Font, sbW, (130 + X + Five.X), (150 + Y + Five.Y))
                Graphic.DrawString("6", Clock_Font, sbW, (93 + X + Six.X), (160 + Y + Six.Y))
                Graphic.DrawString("7", Clock_Font, sbW, (55 + X + Seven.X), (150 + Y + Seven.Y))
                Graphic.DrawString("8", Clock_Font, sbW, (32 + X + Eight.X), (125 + Y + Eight.Y))
                Graphic.DrawString("9", Clock_Font, sbW, (23 + X + Nine.X), (90 + Y + Nine.Y))
                Graphic.DrawString("10", Clock_Font, sbW, (27 + X + Ten.X), (55 + Y + Ten.Y))
                Graphic.DrawString("11", Clock_Font, sbW, (55 + X + Eleven.X), (30 + Y + Eleven.Y))
                Graphic.DrawString("12", Clock_Font, sbW, (89 + X + Twelve.X), (20 + Y + Twelve.Y))
            ElseIf frmOptions.rdb2nd.Checked Then
                Dim Clock_Font_Other As New Font("Bodoni MT Poster Compressed", 11.0F, FontStyle.Bold)
                Graphic.DrawString("I", Clock_Font_Other, sbW, (133 + X + One.X), (30 + Y + One.Y))
                Graphic.DrawString("II", Clock_Font_Other, sbW, (156 + X + Two.X), (55 + Y + Two.Y))
                Graphic.DrawString("III", Clock_Font_Other, sbW, (165 + X + Three.X), (90 + Y + Three.Y))
                Graphic.DrawString("IV", Clock_Font_Other, sbW, (156 + X + Four.X), (125 + Y + Four.Y))
                Graphic.DrawString("V", Clock_Font_Other, sbW, (133 + X + Five.X), (150 + Y + Five.Y))
                Graphic.DrawString("VI", Clock_Font_Other, sbW, (96 + X + Six.X), (160 + Y + Six.Y))
                Graphic.DrawString("VII", Clock_Font_Other, sbW, (58 + X + Seven.X), (150 + Y + Seven.Y))
                Graphic.DrawString("VIII", Clock_Font_Other, sbW, (30 + X + Eight.X), (125 + Y + Eight.Y))
                Graphic.DrawString("IX", Clock_Font_Other, sbW, (26 + X + Nine.X), (90 + Y + Nine.Y))
                Graphic.DrawString("X", Clock_Font_Other, sbW, (30 + X + Ten.X), (55 + Y + Ten.Y))
                Graphic.DrawString("XI", Clock_Font_Other, sbW, (58 + X + Eleven.X), (30 + Y + Eleven.Y))
                Graphic.DrawString("XII", Clock_Font_Other, sbW, (92 + X + Twelve.X), (20 + Y + Twelve.Y))
            Else
                Graphic.DrawString("_", Clock_Font, sbW, (162 + X + Three.X), (85 + Y + Three.Y))
                Graphic.DrawString("|", Clock_Font, sbW, (95 + X + Six.X), (160 + Y + Six.Y))
                Graphic.DrawString("_", Clock_Font, sbW, (23 + X + Nine.X), (85 + Y + Nine.Y))
                Graphic.DrawString("|", Clock_Font, sbW, (95 + X + Twelve.X), (20 + Y + Twelve.Y))
            End If
        End If

        If DrawHands = True Then
            'This code basically sets the center of the drawing, so it acts similar to actual geographic.

            Graphic.TranslateTransform(100, 100, Drawing2D.MatrixOrder.Append)
            '---------------------------------------------------------------------------

            'Create The Angle Of Each Hand (note that 0 is looking straight up)

            'Basically, 2 * PI is a full turn, we want any value that is 1 to face upwards.

            'gets the ratio of the hours hand rotation (this also adds the little fraction of additional movement due to the minutes hand)
            Dim hAngle As Double = 2.0 * Math.PI * (Now.Hour + (Now.Minute / 60.0)) / 12.0 ' m_Hours
            'gets the ratio of the minutes hand rotation (this also adds the little fraction of additional movement due to the seconds hand)
            Dim mAngle As Double = 2.0 * Math.PI * (Now.Minute + Now.Second / 60.0) / 60.0 ' minute
            'gets the ratio of the seconds hand rotation
            Dim sAngle As Double = 2.0 * Math.PI * (Now.Second) / 60.0 ' seconds

            '---------------------------------------------------------------------------


            'Draw Hours Hand


            'The point where the hours hand should end
            Dim hourEnd As New Point(CInt(50 * Math.Sin(hAngle)), CInt(-50 * Math.Cos(hAngle)))
            'The two points away 5pts from the start point, they are perpendicular on the hours hand.
            'Since they are perpendicular, the cos and the sin are switched.
            Dim hourStart1 As New Point(CInt(5 * Math.Cos(hAngle)), CInt(5 * Math.Sin(hAngle)))
            Dim hourStart2 As New Point(CInt(-5 * Math.Cos(hAngle)), CInt(-5 * Math.Sin(hAngle)))

            Dim HourArrow As Point() = {hourEnd, hourStart2, hourStart1, hourEnd}
            Dim PathHours As New Drawing2D.GraphicsPath()
            PathHours.AddPolygon(HourArrow)

            Dim hourBrush As New Drawing2D.LinearGradientBrush(PathHours.GetBounds(), Used_Color.Hour_Color1, Used_Color.Hour_Color2, hAngle, False)
            hourBrush.Blend = Clk_Gradient

            Graphic.FillPath(hourBrush, PathHours)

            'fills a circle around the center of the clock
            Graphic.FillEllipse(hourBrush, -5, -5, 10, 10)
            '---------------------------------------------------------------------------

            'Draw Minute Hand
            'The point where the minutes hand should end
            Dim minEnd As New Point(CInt(65 * Math.Sin(mAngle)), CInt(-65 * Math.Cos(mAngle)))
            'The two points away 5pts from the start point, they are perpendicular on the minutes hand.
            Dim minStart1 As New Point(CInt(5 * Math.Cos(mAngle)), CInt(5 * Math.Sin(mAngle)))
            Dim minStart2 As New Point(CInt(-5 * Math.Cos(mAngle)), CInt(-5 * Math.Sin(mAngle)))

            Dim MinArrow As Point() = {minEnd, minStart1, minStart2, minEnd}
            Dim PathMins As New Drawing2D.GraphicsPath()
            PathMins.AddPolygon(MinArrow)

            Dim minBrush As New Drawing2D.LinearGradientBrush(PathMins.GetBounds(), Used_Color.Minute_Color1, Used_Color.Minute_Color2, mAngle, False)
            minBrush.Blend = Clk_Gradient

            Graphic.FillPath(minBrush, PathMins)

            'fills a circle around the center of the clock
            Graphic.FillEllipse(minBrush, -5, -5, 10, 10)
            '---------------------------------------------------------------------------


            If Not frmOptions.chkHide.Checked Then
                ' Draw Second Hand      
                Dim secondPen As New Pen(Used_Color.Second_Color, 1.5)

                Dim SecEnd As New Point(CInt(70 * Math.Sin(sAngle)), CInt(-70 * Math.Cos(sAngle)))



                If frmOptions.CheckBox1.Checked Then
                    Dim SecRectEnd As New Point(New Point(CInt(-13 * Math.Sin(sAngle)), CInt(13 * Math.Cos(sAngle))))
                    Dim SecRectStart As New Point(New Point(CInt(-33 * Math.Sin(sAngle)), CInt(33 * Math.Cos(sAngle))))

                    Graphic.DrawLine(secondPen, SecRectEnd, SecEnd)
                    secondPen.Width = 5
                    Graphic.DrawLine(secondPen, SecRectStart, SecRectEnd)

                    Graphic.FillEllipse(secondPen.Brush, -4, -4, 8, 8)
                Else
                    Graphic.DrawLine(secondPen, New Point(0, 0), SecEnd)
                    Graphic.FillEllipse(minBrush, -5, -5, 10, 10)
                End If
            End If
            '---------------------------------------------------------------------------

        End If
    End Sub

    Friend Sub Redraw(ByVal PixelFormat As Imaging.PixelFormat)
        If ShownCompleted = True Then
            Bitmap = New Bitmap(200, 200, PixelFormat)
        End If
    End Sub
#End Region

#Region "Move The Window"

    Private MouseOffset As Point
    Private IsLeftButtonDown As Boolean = False

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles TheAnalogClock.MouseDown
        Dim xOffset As Integer
        Dim yOffset As Integer
        If e.Button = MouseButtons.Left Then

            xOffset = -e.X - SystemInformation.FrameBorderSize.Width
            yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height
            MouseOffset = New Point(xOffset, yOffset)
            IsLeftButtonDown = True
        End If
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles TheAnalogClock.MouseMove
        If IsLeftButtonDown Then
            Dim MousePosition As Point = Control.MousePosition
            MousePosition.Offset(MouseOffset.X, MouseOffset.Y)
            Location = MousePosition
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles TheAnalogClock.MouseUp
        If e.Button = MouseButtons.Left Then
            IsLeftButtonDown = False
        End If
    End Sub

#End Region

    Structure Used_Color
        Shared Analog_Color1 As Color = Color.Black
        Shared Analog_Color2 As Color = Color.White
        Shared Analog_NumberBackColor As Color = Color.White
        Shared Analog_NumberColor As Color = Color.LightGray
        Shared Hour_Color1 As Color = Color.Black
        Shared Hour_Color2 As Color = Color.White
        Shared Minute_Color1 As Color = Color.Black
        Shared Minute_Color2 As Color = Color.White
        Shared Second_Color As Color = Color.Black
    End Structure

    Private Sub TheAnalogClock_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TheAnalogClock.DoubleClick
        frmOptions.ShowDialog()
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TheAnalogClock.Paint
        e.Graphics.DrawImage(Bitmap, 0, 0, 200, 200)
    End Sub

    Friend Sub Save(ByVal PixelFormat As Imaging.PixelFormat)

        Dim SavedBitmap As Bitmap = New Bitmap(200, 200, PixelFormat)

        Try
            Dim Type As Imaging.ImageFormat = Imaging.ImageFormat.Bmp
            If (SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) = False Then Exit Sub
            Select Case SaveFileDialog1.FilterIndex
                Case 1
                    Type = Imaging.ImageFormat.Bmp
                Case 2
                    Type = Imaging.ImageFormat.Gif
                Case 3
                    Type = Imaging.ImageFormat.Jpeg
                Case 4
                    Type = Imaging.ImageFormat.Tiff
            End Select

            DrawClock(SavedBitmap, frmOptions.chkShowHands.Checked)

            SavedBitmap.Save(SaveFileDialog1.FileName, Type)

        Catch ex As Exception
            If MessageBox.Show(String.Format("Unhandled Error Has Occurred Please E-mail Me At {0} With The Following Message {1}{1}{2}{1}{1} Continue?", {"Megadardery@yahoo.com", vbCrLf, ex.ToString}), "Unhandled Error", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If
            Application.ExitThread()
            Exit Sub
        Finally
            Me.Timer1.Enabled = True
            SavedBitmap.Dispose()
        End Try
        Process.Start(SaveFileDialog1.FileName)

        SaveFileDialog1.FileName = ""
    End Sub

    Private Sub TheClock_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmOptions.Dialog1_FormClosed(Nothing, Nothing)
        Application.ExitThread()
    End Sub

    Private Sub DateAndTime_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        For counter As Double = 1.0# To 0.0# Step -0.02#
            Me.Opacity = counter
            Me.Refresh()
            Threading.Thread.Sleep(10)
        Next
    End Sub

    Private Sub TheClock_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        For counter As Double = 0.0# To 1.0# Step 0.02#
            Me.Opacity = counter
            Me.Refresh()
            Threading.Thread.Sleep(10)
        Next
        ShownCompleted = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
            DrawClock(Bitmap, True)
            Me.Refresh()
    End Sub

    Private Sub TheClock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            MsgBox("Double Click On The Clock(Or Press Alt + O) To Show Options", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub TheClock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DrawClock(Bitmap, True)

    End Sub

    Friend Sub LoadOptions()
        On Error Resume Next
        Dim Text() As String = Split(My.Computer.Registry.CurrentUser.OpenSubKey("Software\Analog Clock").GetValue("Data"), "|")
        '
        frmOptions.CC1.BackColor = Color.FromArgb(Text(0))
        Used_Color.Analog_Color1 = Color.FromArgb(Text(0))
        '
        '
        frmOptions.CC2.BackColor = Color.FromArgb(Text(1))
        Used_Color.Analog_Color2 = Color.FromArgb(Text(1))
        '
        '
        frmOptions.P3.Font = New Font(Text(2), 11.0F, FontStyle.Bold)
        '
        '
        frmOptions.P3.ForeColor = Color.FromArgb(Text(3))
        Used_Color.Analog_NumberColor = Color.FromArgb(Text(3))
        '
        '
        frmOptions.P3.BackColor = Color.FromArgb(frmOptions.Alpha.Value, Color.FromArgb(Text(4)))
        Used_Color.Analog_NumberBackColor = Color.FromArgb(Text(4))
        '
        '
        frmOptions.HC1.BackColor = Color.FromArgb(Text(5))
        Used_Color.Hour_Color1 = Color.FromArgb(Text(5))
        '
        '
        frmOptions.HC2.BackColor = Color.FromArgb(Text(6))
        Used_Color.Hour_Color2 = Color.FromArgb(Text(6))
        '
        '
        frmOptions.MC1.BackColor = Color.FromArgb(Text(7))
        Used_Color.Minute_Color1 = Color.FromArgb(Text(7))
        '
        '
        frmOptions.MC2.BackColor = Color.FromArgb(Text(8))
        Used_Color.Minute_Color2 = Color.FromArgb(Text(8))
        '
        '
        frmOptions.SC.BackColor = Color.FromArgb(Text(9))
        Used_Color.Second_Color = Color.FromArgb(Text(9))
        '
        '
        frmOptions.rdbSquare.Checked = Not CBool(Text(10))
        '
        '
        frmOptions.rdbLow.Checked = Not CBool(Text(11))
        '
        '
        frmOptions.chkTransparent.Checked = CBool(Text(12))
        '
        '
        If Val(Text(13)) = 1 Then frmOptions.rdbAngle.Checked = True Else frmOptions.rdbType.Checked = True
        '
        '
        frmOptions.chkShowHands.Checked = CBool(Text(14))
        '
        '
        frmOptions.chkHide.Checked = CBool(Text(15))
        '
        '
        Select Case Val(Text(16))
            Case 1 : frmOptions.rdb1st.Checked = True
            Case 2 : frmOptions.rdb2nd.Checked = True
            Case 3 : frmOptions.rdb3rd.Checked = True
        End Select
        '
        '
        frmOptions.chkStartWithWindows.Checked = CBool(Text(17))
        '
        '
        If Text(18) = Nothing And Text(19) = Nothing Then
        Else
            Me.StartPosition = FormStartPosition.Manual
            Me.Location = New Point(Text(18), Text(19))
        End If
        '
        '
        If frmOptions.rdbAngle.Checked = True Then frmOptions.Angle.Value = Text(20) Else frmOptions.Type.SelectedIndex = Text(20)
        '
        '
        frmOptions.Alpha.Value = Val(Text(21))
        '
        '
        X = Text(22) : Y = Text(23)
        One.X = Text(24) : One.Y = Text(25)
        Two.X = Text(26) : Two.Y = Text(27)
        Three.X = Text(28) : Three.Y = Text(29)
        Four.X = Text(30) : Four.Y = Text(31)
        Five.X = Text(32) : Five.Y = Text(33)
        Six.X = Text(34) : Six.Y = Text(35)
        Seven.X = Text(36) : Seven.Y = Text(37)
        Eight.X = Text(38) : Eight.Y = Text(39)
        Nine.X = Text(40) : Nine.Y = Text(41)
        Ten.X = Text(42) : Ten.Y = Text(43)
        Eleven.X = Text(44) : Eleven.Y = Text(45)
        Twelve.X = Text(46) : Twelve.Y = Text(47)
        '
        '
        frmOptions.chkSplash.Checked = Text(48)
        '
        HideName = Not CBool(Text(49))
        '
        frmOptions.CheckBox1.Checked = CBool(Text(50))
    End Sub

    Private Sub TheAnalogClock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TheAnalogClock.Click

    End Sub

    Private Sub TheClock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Static Cheat As Integer = 0
        If HideName = False Then
            If e.KeyChar = "h"c Then Cheat += 1
            If Cheat = 1 AndAlso e.KeyChar = "i"c Then Cheat += 1
            If Cheat = 2 AndAlso e.KeyChar = "d"c Then Cheat += 1
            If Cheat = 3 AndAlso e.KeyChar = "e"c Then Cheat += 1
            If Cheat = 4 AndAlso e.KeyChar = "m"c Then Cheat += 1
            If Cheat = 5 AndAlso e.KeyChar = "y"c Then Cheat += 1
            If Cheat = 6 AndAlso e.KeyChar = "n"c Then Cheat += 1
            If Cheat = 7 AndAlso e.KeyChar = "a"c Then Cheat += 1
            If Cheat = 8 AndAlso e.KeyChar = "m"c Then Cheat += 1
            If Cheat = 9 AndAlso e.KeyChar = "e"c Then
                HideName = True
                Cheat = 0
            End If

        Else
            If e.KeyChar = "s"c Then Cheat += 1
            If Cheat = 1 AndAlso e.KeyChar = "h"c Then Cheat += 1
            If Cheat = 2 AndAlso e.KeyChar = "o"c Then Cheat += 1
            If Cheat = 3 AndAlso e.KeyChar = "w"c Then Cheat += 1
            If Cheat = 4 AndAlso e.KeyChar = "m"c Then Cheat += 1
            If Cheat = 5 AndAlso e.KeyChar = "y"c Then Cheat += 1
            If Cheat = 6 AndAlso e.KeyChar = "n"c Then Cheat += 1
            If Cheat = 7 AndAlso e.KeyChar = "a"c Then Cheat += 1
            If Cheat = 8 AndAlso e.KeyChar = "m"c Then Cheat += 1
            If Cheat = 9 AndAlso e.KeyChar = "e"c Then
                HideName = False
                Cheat = 0
            End If
        End If
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        frmOptions.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub frmTheClock_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus

    End Sub
End Class