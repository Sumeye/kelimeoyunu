Imports System.Data.SqlClient

Public Class Form2
    Dim conn As New SqlConnection("Data Source=HP-PC;Initial Catalog=kelime_oyunu;Integrated Security=True")
    Dim komut As New SqlCommand
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form5.adi = Me.txtAd.Text
        Form8.adi = Me.txtAd.Text
        Me.Close()
        Form4.Show()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtAd_TextChanged(sender As Object, e As EventArgs) Handles txtAd.TextChanged

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
