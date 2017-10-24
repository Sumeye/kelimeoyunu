Imports System.Data.SqlClient
Public Class Form8
    Public adi As String
    Public F5puan As Integer = 0
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Form6.Show()
    End Sub
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = String.Empty
        lblAdi.Text = String.Empty
        Label2.Text = F5puan.ToString()
        lblAdi.Text = adi
        'connection ıslemleri puanı ve adı yazdırıyoruz.
        Dim conn As New SqlConnection("Data Source=HP-PC;Initial Catalog=kelime_oyunu;Integrated Security=True")
        Dim sorgu As New SqlCommand("insert into tblSkor values('" + adi + "'," + F5puan.ToString + ")", conn)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        sorgu.ExecuteNonQuery()
        conn.Close()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class