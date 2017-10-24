Imports System.Data.SqlClient
Public Class Form6
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New SqlConnection("Data Source=HP-PC;Initial Catalog=kelime_oyunu;Integrated Security=True")
        Dim verial As New SqlDataAdapter("select top 10 Oyuncu,Skor  from tblSkor order by Skor desc", conn)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim tabloyaAl As New DataTable()
        verial.Fill(tabloyaAl)
        DataGridView1.DataSource = tabloyaAl
        conn.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Form3.Show()
    End Sub
End Class
