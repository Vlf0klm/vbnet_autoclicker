Imports System.Net
Imports System.Threading



Public Class LoginForm1
    Dim variabletf

    ' TODO: insérez le code pour effectuer une authentification personnalisée à l'aide du nom d'utilisateur et du mot de passe fournis 
    ' (Voir http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' L'objet Principal personnalisé peut ensuite être associé à l'objet Principal du thread actuel comme suit : 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' CustomPrincipal est l'implémentation IPrincipal utilisée pour effectuer l'authentification. 
    ' Par la suite, My.User retournera les informations d'identité encapsulées dans l'objet CustomPrincipal
    ' telles que le nom d'utilisateur, le nom complet, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Then
            MsgBox("Veuillez réessayer !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erreur !")
        ElseIf UsernameTextBox.Text = var.user And PasswordTextBox.Text = var.pass Then
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
            Form1.Show()
            Me.Hide()
        Else
            MsgBox("Veuillez réessayer !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erreur !")
        End If
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Timer1.Stop()
            Me.Hide()
        End If
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MessageBox.Show("Voulez vous vraiment quitter le logiciel ?", "Asynchronisation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            End
        Else
            'continue le code
        End If
    End Sub
    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        ' Try
        If Label1.Text = "carrote" Then
            Me.Height = 200
            Me.Width = 500
            Me.Text = "ClickTest - Mise à jour"
            Annuler.Text = "Annuler"
            Annuler.Visible = True
            ProgressBar1.Visible = True
            Label1.Visible = True
            GroupBox1.Visible = False
            LogoPictureBox.Visible = False
            GroupBox2.Visible = False
        End If

        If Label1.Text = "carrote" Then
            Me.Height = 812
            Me.Height = 812
            Me.Text = "DEBUG"
            Me.ControlBox = True

            GroupBox1.Visible = False
            LogoPictureBox.Visible = False
            GroupBox2.Visible = True


            If My.Settings.superdebugstartup = True Then
                CheckBox1.Checked = True
            Else
                CheckBox1.Checked = False
            End If
            If var.mcmodevar = True Then
                ComboBox1.Text = "TRUE"

            ElseIf var.mcmodevar = False Then
                ComboBox1.Text = "FALSE"
            End If
        End If
        ' Catch ex As Exception
        '   MsgBox("Oups... Une erreur est survenue ... Veuillez réessayer !")
        ' End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        variabletf = ComboBox1.Text
        Label5.Text = variabletf
        Select Case variabletf
            Case "TRUE"
                var.mcmodevar = True
            Case "FALSE"
                var.mcmodevar = False

            Case Else
                Exit Sub
                MsgBox("Veuillez réesayer.", MsgBoxStyle.Critical)
        End Select

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TextBox2.Text = var.user
        TextBox1.Text = var.pass
        Label6.Text = "Startup message warning : " + Str(My.Settings.msgstartupwarning)
        Label7.Text = "Startup message maj : " + Str(My.Settings.msgstartupnewmaj)
    End Sub
    Private Sub ProgChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        '' ProgressBar1.Value = e.ProgressPercentage 'Obtenir la progression du téléchargement en cours
        ''Label1.Text = "Mise à jour en cours... (" & String.Format("{0} MB's / {1} MB's", (e.BytesReceived / 1024D / 1024D).ToString("0.00"), (e.TotalBytesToReceive / 1024D / 1024D).ToString("0.00")) & ")"
    End Sub


    Private Sub Annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annuler.Click
        End
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CheckBox1.Checked = True Then
            var.superdebug = True
        ElseIf CheckBox1.Checked = False Then
            var.superdebug = False
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
