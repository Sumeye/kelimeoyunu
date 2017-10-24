Imports System.Data.SqlClient
Public Class Form4
    Dim say As Integer
    Function karistir(ByVal girdi As String) As String
        Dim str As List(Of Char) = girdi.ToList()
        Dim karisik As String = ""
        Dim rand As Random = New Random()
        Dim t As Integer = str.Count - 1
        For i As Integer = 0 To t
            Dim p As Integer = rand.Next(str.Count)
            karisik &= str(p)
            str.RemoveAt(p)
        Next i
        Return karisik
    End Function

    Dim rnd As New Random
    Dim tutulan As Integer
    Dim i As Integer
    Dim sayac As Integer
    Dim puan As Integer
    Dim kez As Integer
    Dim dogru As Integer
    Dim baraj As Integer
    Dim conn As New SqlConnection("Data Source=HP-PC;Initial Catalog=kelime_oyunu;Integrated Security=True")

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        say = say - 1 '
        Label3.Text = say
        If say = 0 Then
            Timer1.Stop()
            MsgBox("SÜRE DOLDU")
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        baraj = 50
        Timer1.Interval = 1000
        say = 300
        Timer1.Enabled = True
        Timer1.Start()
        tutulan = rnd.Next(1, 31)
        'Dim skor As New SqlDataAdapter("select max(Skor)  from tblSkor", conn) bu satırı iptal.
        Dim strQ As String = "SELECT * FROM kelime WHERE id='" & tutulan & "'"
        Dim CMD As New SqlCommand(strQ, conn)
        conn.Open()
        Dim dr As SqlDataReader = CMD.ExecuteReader()
        Dim sonuc As String = String.Empty
        

        Do While dr.Read
            Label1.Text = karistir(dr(1))
        Loop
        conn.Close()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim strQ1 As String = "SELECT * FROM kelime WHERE id='" & tutulan & "'"
        Dim CMD1 As New SqlCommand(strQ1, conn)
        conn.Open()
        Dim oyun As SqlDataReader = CMD1.ExecuteReader()
        Dim sonuc1 As String = String.Empty
        Do While oyun.Read
            If TextBox1.Text = oyun(1) Then
                dogru = dogru + 1
                Label4.Text = dogru
                sayac += 10
                puan = sayac
                Label2.Text = puan
                TextBox1.Text = ""
            Else
                kez = kez + 1
                Label5.Text = kez
                TextBox1.Text = ""
                If kez = 1 Then
                    PictureBox2.ImageLocation = "kalpyanls.jpg"
                    PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
                End If

                If kez = 2 Then
                    PictureBox3.ImageLocation = "kalpyanls.jpg"
                    PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
                End If
                If kez = 3 Then
                    PictureBox4.ImageLocation = "kalpyanls.jpg"
                    PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
                End If

                If kez >= 3 And puan > baraj Then

                    Timer1.Stop()
                    kez = 0
                    puan = 0
                    sayac = 0
                    say = 10
                    TextBox1.Enabled = False
                    PictureBox1.Enabled = False
                    Me.Close()
                    Form8.Show()
                ElseIf kez >= 3 And puan < baraj Then
                    Timer1.Stop()
                    kez = 0
                    puan = 0
                    sayac = 0
                    say = 10
                    TextBox1.Enabled = False
                    PictureBox1.Enabled = False
                    Me.Close()
                    Form5.Show()
                ElseIf kez >= 3 Then
                    Timer1.Stop()
                    kez = 0
                    puan = 0
                    sayac = 0
                    say = 10
                    TextBox1.Enabled = False
                    PictureBox1.Enabled = False
                    Me.Close()
                    Form5.Show()

                End If
                End If
        Loop
        conn.Close()
        tutulan = rnd.Next(1, 32)
        Dim strQ As String = "SELECT * FROM kelime WHERE id='" & tutulan & "'"
        Dim CMD As New SqlCommand(strQ, conn)
        conn.Open()
        Dim dr As SqlDataReader = CMD.ExecuteReader()
        Dim sonuc As String = String.Empty
        Do While dr.Read
            Label1.Text = karistir(dr(1))
        Loop
        conn.Close()
        Form5.F5puan = puan
        Form8.F5puan = puan
    End Sub
End Class