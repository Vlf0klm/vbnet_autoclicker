Public Class superclass
    Function newerror(ByRef err As String)
        Return MessageBox.Show("Un erreur est survenue," + vbNewLine + err, "Erreur ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Function

End Class
