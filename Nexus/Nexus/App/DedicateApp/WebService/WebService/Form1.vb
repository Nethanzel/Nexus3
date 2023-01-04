Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports System.Text

Public Class Form1

    Dim Status As String
    Dim Lbl1 As String
    Dim lbl2 As String
    Dim HaveWebAcc As Boolean
    Dim LastState As Integer = 0
    Dim State As Integer = -1

    Dim LanIp As String
    Dim InternetIp As String

    Sub RefreshIp()

        LanIp = LocalIp()

        InternetIp = PublicIp()

    End Sub


    Sub Test_Conection()

        Try


            If My.Computer.Network.IsAvailable Then
                Status = "Conectando..."
                'IO.File.WriteAllText("N:\NexusFrameWork\WebService\&WebState&", Status)

                PictureBox1.Image = My.Resources.NetworkLoad
                Lbl1 = "Obteniendo estado de la conexion..."
                lbl2 = "Conectando..."


                If My.Computer.Network.Ping("74.125.141.94") = True Then
                    Status = "Conectado"
                    ' IO.File.WriteAllText("N:\NexusFrameWork\WebService\&WebState&", Status)
                    'HaveWebAcc = True
                    PictureBox1.Image = My.Resources.NetworkGood
                    lbl2 = "Acceso a Internet."
                    Lbl1 = "Conectado."
                    LastState = State
                    State = 0
                Else

                    Status = "Error"
                    'IO.File.WriteAllText("N:\NexusFrameWork\WebService\&WebState&", Status)
                    ' HaveWebAcc = False
                    PictureBox1.Image = My.Resources.NetworkProblem
                    Lbl1 = "Problema en la conexion."
                    lbl2 = "Problema desconocido."
                    LastState = State
                    State = 1

                End If


            Else
                PictureBox1.Image = My.Resources.NetworkBad
                Status = "Sin Medios"
                'IO.File.WriteAllText("N:\NexusFrameWork\WebService\&WebState&", Status)
                'HaveWebAcc = False
                lbl2 = "Sin ninguna conexion disponible."
                Lbl1 = "Sin conexion."
                LastState = State
                State = 2


            End If

        Catch ex As System.Net.NetworkInformation.PingException

            PictureBox1.Image = My.Resources.NetworkBad
            Status = "Sin Medios"
            'IO.File.WriteAllText("N:\NexusFrameWork\WebService\&WebState&", Status)
            'HaveWebAcc = False
            lbl2 = "Sin ninguna conexion disponible."
            Lbl1 = "Sin conexion."
            LastState = State
            State = 2

        End Try

        Dim xProc As New Thread(AddressOf RefreshIp)
        xProc.Start()

    End Sub

    Dim counter As Integer = 0
    Dim StatusStream As String

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.Top = My.Computer.Screen.WorkingArea.Height - (Me.Height + 13)
        Me.Left = My.Computer.Screen.WorkingArea.Width - (Me.Width + 5)

        counter = counter + 1
        If counter >= 4 Then
            Dim thread3 As New Thread(New ThreadStart(AddressOf Test_Conection))
            thread3.Start()
            counter = 0
        End If

        StatusStream = Status & vbNewLine & LanIp & vbNewLine & InternetIp
        RESPUESTA = StatusStream
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = My.Computer.Screen.WorkingArea.Height - (Me.Height + 13)
        Me.Left = My.Computer.Screen.WorkingArea.Width - (Me.Width + 5)

        Status = "Conectando..."
        'IO.File.WriteAllText("N:\NexusFrameWork\WebService\&WebState&", Status)
        Label1.Text = "Obteniendo acceso..."
        Label2.Text = "Conectando..."


        IO.File.WriteAllText("N:\Nexus\AppWork\WebService\IsRun", "True")

        Dim thread2 As New Thread(New ThreadStart(AddressOf Test_Conection))
        thread2.Start()

        StartServer()

    End Sub

    Dim Net As String

    Private Sub Reader_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reader.Tick
        Try

            Net = IO.File.ReadAllText("N:\Nexus\AppWork\Interface/$Network-%")

            If Net = "True" Then
                Me.Opacity = 100
                Me.Visible = True
            Else
                Me.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        IO.File.WriteAllText("N:\Nexus\AppWork\WebService\IsRun", "False")

        Try
            HEBRA.Abort()
            SERVIDOR.Stop()
            Application.Exit()
        Catch ex As Exception

        End Try

    End Sub


    Dim client As TcpClient
    Dim HostDirection As String = "localhost"

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Lbl1
        Label2.Text = lbl2

        Label3.Text = "Ip local: " & LanIp
        Label4.Text = "Ip pública: " & InternetIp
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        State = -1
        LastState = 0
    End Sub

    Function LocalIp() As String
        Try

            Dim ip As System.Net.IPHostEntry
            Dim nombrePC As String = Dns.GetHostName
            ip = Dns.GetHostEntry(nombrePC)
            Return ip.AddressList(2).ToString

        Catch ex As Exception
            Return "No disponible."
        End Try

    End Function

    Function PublicIp() As String

        Try

            Dim Result As String

            Result = New System.Net.WebClient().DownloadString("https://smartworld-whatismyip.000webhostapp.com/Index.php")

            Return Result

        Catch ex As Exception

            Return "No disponible."
        End Try

    End Function



#Region "Server"

    Dim SERVIDOR As HttpListener
    Dim HEBRA As Threading.Thread
    Dim RESPUESTA As String

    Sub StartServer()
        Try

            SERVIDOR = New HttpListener
            SERVIDOR.Prefixes.Add("http://localhost:15315/SystemConection/")
            SERVIDOR.Start()
            HEBRA = New Threading.Thread(AddressOf RESPONDE)
            HEBRA.Start()
        Catch ex As Exception

            SERVIDOR.Close()
        End Try

    End Sub

    Public Sub RESPONDE()
        While True
            Try
                Dim CONTEXTO As HttpListenerContext = SERVIDOR.GetContext
                CONTEXTO.Response.ContentLength64 = Encoding.UTF8.GetByteCount(RESPUESTA)
                CONTEXTO.Response.StatusCode = HttpStatusCode.OK
                Dim MISTREAM As Stream = CONTEXTO.Response.OutputStream
                Using (MISTREAM)
                    Using ESCRITOR As StreamWriter = New StreamWriter(MISTREAM)
                        ESCRITOR.Write(RESPUESTA)
                    End Using
                End Using
            Catch ex As Exception

            End Try
        End While

    End Sub


#End Region

End Class
