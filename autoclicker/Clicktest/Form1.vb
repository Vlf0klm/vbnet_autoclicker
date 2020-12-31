Imports System.Net
Imports System.IO
Public Class Form1

    '' ####################################################################################################
    ''          ATTENTION: CODE NON OPTIMISE, JE DECONSEILLE De COPIER COLLER CE CODE (dégeulasse)
    ''                       Vous pouvez trouvez mieux, vraiment...
    '' ####################################################################################################

    Public Superclass As New superclass
    Dim Red, Blue, Green, Yellow As String
    Dim valuecps As Integer
    Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
    Public Const MOUSEEVENTF_LEFTDOWN = &H2
    Public Const MOUSEEVENTF_LEFTUP = &H4

    Public Const MOUSEEVENTF_RIGHTDOWN = &H8
    Public Const MOUSEEVENTF_RIGHTUP = &H10
    Dim Touche
    ''Dim maj As New WebClient

    ''ReadOnly derniereversion As String = maj.DownloadString("[patch]")

    ''Dim download As String = maj.DownloadString("[patch]")
    Dim Connecté As Boolean




    '---
    Private Declare Function InternetGetConnectedState Lib "wininet.dll" (ByVal lpdwFlags As Integer, ByVal dwReserved As Integer) As Boolean
    Private Declare Function GetAsyncKeyState Lib "User32" (ByVal uAction As Long) As Long
    Function ConnexionStatus() As Boolean
        Dim Status As Integer
        ConnexionStatus = (InternetGetConnectedState(Status, 0&) <> 0)

    End Function


    Private Sub Accept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles accept.CheckedChanged
        Button1.Enabled = True
        Button3.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Try
                gen.Interval = TrackBar1.Value
                gen.Start()
            Catch Ex As Exception
                Superclass.newerror("Erreur: Une erreur est survenue lors de la génération de click.")
                gen.Stop()
                TrackBar1.Value = 500
                Label1.Text = TrackBar1.Value & " millisecondes"
                accept.Checked = False
                Button1.Enabled = False
                Button3.Enabled = True
                Exit Sub
            End Try
            ProgressBar1.Visible = True
            clickdroit.Enabled = False
            clickgauche.Enabled = False
            modemc.Enabled = False
            Button1.Visible = False
            accept.Visible = False
            TrackBar1.Enabled = False
            choicesplus.Enabled = False
            choicespeedmoin.Enabled = False
            Button2.Visible = True
            Button2.Enabled = True
            GroupBox1.ForeColor = Color.Black
            GroupBox2.ForeColor = Color.Black
            GroupBox3.ForeColor = Color.Black
            GroupBox4.ForeColor = Color.Black
            accept.ForeColor = Color.Black
            Button1.ForeColor = Color.Black
            Button2.ForeColor = Color.Black
            If var.mcmodevar = True Then
                Label9.Visible = True
            End If
        Catch ex As Exception
            Superclass.newerror("Oups... Une erreur est survenue ... Veuillez réessayer !")
        End Try
    End Sub

    Private Sub apptjrsfirst_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles apptjrsfirst.CheckedChanged
        Me.TopMost = apptjrsfirst.Checked
    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        Me.Opacity = TrackBar2.Value / 100
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Label1.Text = TrackBar1.Value & " millisecondes"
    End Sub

    Private Sub choicespeedmoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles choicespeedmoin.Click
        Try
            TrackBar1.Value -= 1

            Label10.Text = valuecps & " cps"
            Label1.Text = TrackBar1.Value & " millisecondes"
        Catch Ex As Exception
            Superclass.newerror("Erreur: Vous ne pouvez pas diminuez plus le nombres de millisecondes !")
        End Try
    End Sub

    Private Sub choicesplus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles choicesplus.Click
        Try
            TrackBar1.Value += 1
            Label1.Text = TrackBar1.Value & " millisecondes"
        Catch Ex As Exception
            Superclass.newerror("Erreur: Vous ne pouvez pas augmentez plus le nombres de millisecondes !")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Touche = ComboBox1.Text
            Label4.Text = "Veuillez appuyer sur la touche " & Touche & " pour tester."
            ComboBox1.Enabled = False
            Button1.Enabled = False
            Button3.Visible = False
            Button7.Visible = False
            test.Start()
        Catch ex As Exception
            Superclass.newerror("Erreur: lors du chargement de la touche ... Veuillez réessayer !")
        End Try
    End Sub

    Private Sub test_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles test.Tick
        Try
            Select Case Touche

                Case "CTRL"
                    If My.Computer.Keyboard.CtrlKeyDown Then
                    Else
                        Exit Sub
                    End If
                Case "ALT"
                    If My.Computer.Keyboard.AltKeyDown Then
                    Else
                        Exit Sub
                    End If

                Case "SHIFT"
                    If My.Computer.Keyboard.ShiftKeyDown Then
                    Else
                        Exit Sub
                    End If

                Case "NUM LOCK"
                    If My.Computer.Keyboard.NumLock Then
                    Else
                        Exit Sub
                    End If

                Case "CAPS LOCK"
                    If My.Computer.Keyboard.CapsLock Then
                    Else
                        Exit Sub
                    End If

                Case Else
                    Exit Sub
                    MsgBox("Veuillez réesayer.", MsgBoxStyle.Critical)
            End Select
            Label4.Text = "✔ La touche à bien était appuyer"
            accept.Enabled = True
            Button3.Visible = True
        Catch ex As Exception
            Superclass.newerror("Veuillez réessayer !")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            ComboBox1.Enabled = True
            accept.Enabled = False
            Button1.Enabled = False
            Button3.Visible = False
            Button7.Visible = True
            test.Stop()
            Label4.Text = "En attente d'une touche ..."
        Catch ex As Exception
            Superclass.newerror("Veuillez réessayer !")
        End Try
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            gen.Stop()
            test.Stop()
            Chroma.Stop()
            testappmc.Stop()
            wait.Stop()
            test2.Stop()
            timer.Stop()
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            gen.Stop()
            timer.Start()
            Me.Text = "GO2CLICK RELEASE ! v" & var.thisversion
            If My.Settings.msgstartupwarning = True Then
                If MessageBox.Show("Ce logiciel et sous votre résponsabilité, " + vbNewLine + "le créateur indique qu c'est VOUS qui avez installer ce logiciel (en beta.)", "ATTENTION !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel Then
                    End
                Else
                    'continue le code

                End If
            End If
            If My.Settings.superdebugstartup = True Then
                debug()
            Else
                ''checkupdates()
                Label11.Text = "Version actuelle: " + var.thisversion
                var.user = TBUsername.Text
                var.pass = TBPassword.Text
            End If
            checkupdates()


        Catch ex As Exception
            Superclass.newerror("Veuillez réessayer !")
        End Try
    End Sub

    Private Sub gen_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gen.Tick
        Try
            If clickgauche.Checked = True Then
                Try
                    Select Case Touche

                        Case "CTRL"
                            If My.Computer.Keyboard.CtrlKeyDown Then
                                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0) 'Enfonce le bouton de la souris
                                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0) ' le relève
                            End If
                        Case "ALT"
                            If My.Computer.Keyboard.AltKeyDown Then
                                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0) 'Enfonce le bouton de la souris
                                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0) ' le relève
                            End If
                        Case "SHIFT"
                            If My.Computer.Keyboard.ShiftKeyDown Then
                                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0) 'Enfonce le bouton de la souris
                                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0) ' le relève
                            End If

                        Case "NUM LOCK"
                            If My.Computer.Keyboard.NumLock Then
                                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0) 'Enfonce le bouton de la souris
                                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0) ' le relève
                            End If

                        Case "CAPS LOCK"
                            If My.Computer.Keyboard.CapsLock Then
                                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0) 'Enfonce le bouton de la souris
                                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0) ' le relève
                            End If

                        Case Else
                            Exit Sub
                            MsgBox("Veuillez réesayer.", MsgBoxStyle.Critical)
                    End Select
                Catch Ex As Exception
                    Superclass.newerror("Erreur: Une erreur est survenue lors de la génération de click.")
                End Try
                '-------------------------------------------------------------------------------
            ElseIf clickdroit.Checked = True Then
                Try
                    Select Case Touche

                        Case "CTRL"
                            If My.Computer.Keyboard.CtrlKeyDown Then
                                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0) 'Enfonce le bouton de la souris
                                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0) ' le relève
                            End If
                        Case "ALT"
                            If My.Computer.Keyboard.AltKeyDown Then
                                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0) 'Enfonce le bouton de la souris
                                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0) ' le relève
                            End If
                        Case "SHIFT"
                            If My.Computer.Keyboard.ShiftKeyDown Then
                                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0) 'Enfonce le bouton de la souris
                                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0) ' le relève
                            End If

                        Case "NUM LOCK"
                            If My.Computer.Keyboard.NumLock Then
                                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0) 'Enfonce le bouton de la souris
                                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0) ' le relève
                            End If

                        Case "CAPS LOCK"
                            If My.Computer.Keyboard.CapsLock Then
                                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0) 'Enfonce le bouton de la souris
                                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0) ' le relève
                            End If

                        Case Else
                            Exit Sub
                            MsgBox("Veuillez réesayer.", MsgBoxStyle.Critical)
                    End Select
                Catch Ex As Exception
                    Superclass.newerror("Erreur: Une erreur est survenue lors de la génération de click.")
                End Try
                '------------------------------------------------------------------------------------
            Else
                End
            End If
        Catch Ex As Exception
            Superclass.newerror("Erreur: Une erreur est survenue lors de la génération de click.")
        End Try



    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            gen.Stop()
            accept.Visible = True
            clickdroit.Enabled = True
            clickgauche.Enabled = True
            accept.Checked = False
            CheckBox2.Enabled = True
            Button1.Visible = True
            Button1.Enabled = False
            Button2.Visible = False
            Button3.Enabled = True
            modemc.Enabled = True
            TrackBar1.Enabled = True
            choicesplus.Enabled = True
            choicespeedmoin.Enabled = True
            ProgressBar1.Visible = False
            If var.mcmodevar = True Then
                Label9.Visible = False
            End If
        Catch ex As Exception
            Superclass.newerror("Veuillez réessayer !")
        End Try

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            ''If TBPassword.Text = "passadmin" And TBUsername.Text = "debug" Then
            ''TBverif.Text = ""
            ''TBverif.Visible = True
            ''Exit Sub
            ''End If

            If TBPassword.Text = "" Or TBUsername.Text = "" Then
                MsgBox("Veuillez renseigner le nom d'utilisateur et le mot de passe", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error no more information")
                Exit Sub
            Else
                var.pass = TBPassword.Text
                var.user = TBUsername.Text
            End If
            gen.Stop()
            accept.Visible = True
            accept.Checked = False
            TrackBar1.Enabled = True
            choicesplus.Enabled = True
            Button1.Visible = True
            Button1.Enabled = False
            Button2.Visible = False
            Button3.Enabled = True
            choicespeedmoin.Enabled = True
            ProgressBar1.Visible = False
            LoginForm1.Show()
            Me.Hide()
        Catch ex As Exception
            Superclass.newerror("Veuillez réessayer !")
        End Try
    End Sub

    Private Sub no_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''rackBar1.Value = TextBox1.Value

        ''TextBox1.Visible = True
        ''selectifyesornochoice.Enabled = False
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Chroma.Start()
    End Sub

    Private Sub Chroma_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chroma.Tick
        Try
            Red = Int(Rnd() * 255)
            Blue = Int(Rnd() * 255)
            Green = Int(Rnd() * 255)
            GroupBox1.ForeColor = Color.FromArgb(Red, Blue, Green)
            GroupBox2.ForeColor = Color.FromArgb(Red, Blue, Green)
            GroupBox3.ForeColor = Color.FromArgb(Red, Blue, Green)
            GroupBox4.ForeColor = Color.FromArgb(Red, Blue, Green)
            accept.ForeColor = Color.FromArgb(Red, Blue, Green)
            Button1.ForeColor = Color.FromArgb(Red, Blue, Green)
            Button2.ForeColor = Color.FromArgb(Red, Blue, Green)
            ProgressBar1.ForeColor = Color.FromArgb(Red, Blue, Green)
            TBPassword.ForeColor = Color.FromArgb(Red, Blue, Green)
            TBUsername.ForeColor = Color.FromArgb(Red, Blue, Green)
        Catch ex As Exception
            Superclass.newerror("Veuillez réessayer !")
        End Try
    End Sub

    Private Sub modemc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles modemc.CheckedChanged
        gen.Stop()
        test.Stop()
        Chroma.Stop()
        wait.Stop()
        test2.Stop()
        Label8.Text = "Logiciel non détécté !"
        Label8.Visible = True
        testappmc.Start()
        modemc.Enabled = False

    End Sub

    Private Sub testappmc_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles testappmc.Tick
        Try
            For Each proc As Process In Process.GetProcesses
                If proc.ProcessName = "javaw" Then
                    modemcapp()
                    testappmc.Stop()

                Else


                End If
            Next

        Catch ex As Exception
            Superclass.newerror("Veuillez réessayer !")
        End Try
    End Sub
    Sub modemcapp()
        Try
            Label8.ForeColor = Color.Green
            Label10.Visible = True
            Label8.Text = "Minecraft java à été détecté avec succès !"
            var.mcmodevar = True
            wait.Start()
            ProgressBar2.Visible = True
            TabControl1.Enabled = False
        Catch ex As Exception
            Superclass.newerror("Veuillez réessayer !")
        End Try

    End Sub
    Sub debug()
        TBPassword.Text = ""
        TBUsername.Text = ""
        ''selectifyesornochoice.Visible = True
        '' selectifyesornochoice.Enabled = True
        ''Button5.Visible = True
        ''Button5.Enabled = True
        '' TextBox1.Visible = True
        Button4.Enabled = False
        ''Button6.Visible = True
        Me.Text = "Go2click - debug mode"
    End Sub
    Private Sub wait_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wait.Tick
        Try
            ProgressBar2.Increment(8)
            If ProgressBar2.Value = 100 Then
                ProgressBar2.Value = 0
                ProgressBar2.Visible = False
                TabControl1.Enabled = True
                MsgBox("Chargement terminée !")
                wait.Stop()


            End If
        Catch ex As Exception
            Superclass.newerror("Veuillez réessayer !")
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Label8.Visible = True
            Label8.ForeColor = Color.Green
            Label10.Visible = True
            Label8.Text = "Débug"
            var.mcmodevar = True
            ProgressBar2.Visible = True
        Catch ex As Exception
            Superclass.newerror("Veuillez réessayer !")
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'var.pass = TBPassword.Text
        'var.user = TBUsername.Text
        var.debug = True

        LoginForm1.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            If Button7.Text = "Annuler" Then

                Button7.Text = "Autres..."
                GroupBox1.Enabled = True
                Button7.Location = New Point(10, 54)
                Label4.Text = "En attente d'une touche ..."
                ComboBox1.Enabled = True


            ElseIf Button7.Text = "Autres..." Then

                Button7.Text = "Annuler"
                GroupBox1.Enabled = False
                accept.Enabled = False
                Label4.Text = "Veuillez appuyer sur une touche."
                Button7.Location = New Point(373, 53)
                ComboBox1.Enabled = False
                ComboBox1.Text = ""


            Else
                Superclass.newerror("Veuillez réessayer !")
                End
            End If
        Catch ex As Exception
            Superclass.newerror("Veuillez réessayer !")
        End Try
    End Sub

    Private Sub timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer.Tick
        var.startupwarning = My.Settings.msgstartupwarning
        var.startupnewmaj = My.Settings.msgstartupnewmaj
        var.superdebug = My.Settings.superdebugstartup

        If var.mcmodevar = True Then
            Label10.Text = "~ " & TrackBar1.Value * 1000 & " CPS "
            Label9.Text = TrackBar1.Value * 1000 & " CPS EN JEU"
        End If
    End Sub

    Sub checkupdates()
        Try
            Connecté = False
            '' Label12.Text = "Mise à jour disponible: erreur"
            Superclass.newerror("Erreur lors de la verification des mises à jours:" + vbNewLine + "PROJET ABONDONNE, SERVEUR NON TROUVE")
            Exit Sub
            '' [CODE INUTILE]
            If Not Label1.Text = "carrote" Then
                If My.Settings.msgstartupnewmaj = True Then
                    ''If MessageBox.Show("Une nouvelle version est disponible ! " + vbNewLine + "Vous avez la version: " + var.thisversion + vbNewLine + "La dernière version est : " + derniereversion, "Mise à jour disponible !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Label12.Text = "Mise à jour disponible: oui"
                    Button8.Enabled = True
                    Exit Sub
                    '' Else
                    ''updates()
                    ''End If
                Else
                    Label12.Text = "Mise à jour disponible: oui"
                    Button8.Enabled = True
                End If

            Else
                Exit Sub
            End If
        Catch Ex As Exception
            Superclass.newerror("Erreur lors de la verification des mises à jours: inconnue.")
        End Try

    End Sub
    Sub updates()
        If Label1.Text = "carrote" Then
            If MessageBox.Show("Voulez vous vraiment mettre à jour le logiciel ?", "Clicktest", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                'continue le code
            End If

            Try
                var.debug = False
                var.majload = True
                gen.Stop()
                test.Stop()
                Chroma.Stop()
                wait.Stop()
                test2.Stop()
                timer.Stop()
                TabControl1.Enabled = False
                accept.Enabled = False
                Button1.Enabled = False
                Button2.Enabled = False
                Label12.Text = "Mise à jour disponible: mise à jour en cours..."
                Button8.Enabled = False
                Me.Hide()
                LoginForm1.Show()

            Catch Ex As Exception
                Superclass.newerror("Erreur lors de la verification des mises à jours... Veuillez recommencer plus tard.")
            End Try
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        ''updates()
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged

    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged

    End Sub
End Class
