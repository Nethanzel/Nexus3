Imports System.Speech

Module Speaker

    Private Sub Mouth(ByVal Lines As String)

        Dim a = CreateObject("SAPI.spvoice")
        a.volume = 100
        a.rate = 1
        a.speak(Lines)

    End Sub
    Private LineInput As String
    Private Sub InputMethod()

        Mouth(LineInput)

    End Sub

    Public Sub SpeakAsync(ByVal Phrase As String)

        LineInput = Phrase
        Dim SpkrProcces As New Threading.Thread(AddressOf InputMethod)
        SpkrProcces.Start()

    End Sub

    Public Sub Get_Response(ByVal Argument As String)


        If Argument.Contains("hola") Or Argument.Contains("ola") Then

            SpeakAsync("Hola, ¿Cómo estás?. Yo estoy muy bien.")




        ElseIf Argument = "verónica" Then

            SpeakAsync("¿Me has llamado?, Aquí estoy para ti.")




        ElseIf Argument = "cómo te llamas" Then

            SpeakAsync("Mi nombre es Verónica, ¿En qué puedo ayudarte? ")





        ElseIf Argument.Contains("como") AndAlso Argument.Contains("éstas") Or Argument.Contains("estas") Or Argument.Contains("esta") AndAlso Argument.Length < 10 Then

            SpeakAsync("Todo va bien. ¿Qué puedo hacer por ti?.")





        ElseIf Argument.Contains("reproducir") AndAlso Argument.Contains("música") Or Argument.Contains("reproducir") Or Argument = "puedes poner música" Then

            SpeakAsync("Si me das un momento pondré tu lista de música favorita.")

            App_Break(2500)

            Dim eValue As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxReproductor\IsRun")

            If eValue = "False" Then

                Process.Start("N:\Dev App\NxPlayer\NxPlayer\bin\Debug\NxPlayer.exe")

            End If

            '-----------------------------        ------------------------
            '           Agregar lista de reproduccion favorita           '
            '-----------------------------        ------------------------

            My.Application.ApplicationContext.MainForm.Close()

        ElseIf Argument = "gracias" Then

            SpeakAsync("De nada. Para mi ha sido un placer.")




        ElseIf Argument = "adiós" Or Argument = "a dios" Or Argument = "nos vemos" Then

            SpeakAsync("Adiós, espero que te vaya bien. Cuando regreses aquí estaré.")

            IO.File.WriteAllText("N:\Nexus\AppWork\Settings\Vero\IsRun", "False")
            App_Break(4000)

            End
        
        ElseIf Argument = "qué hora es" Then
            'Buscar la forma para que esto sea la fecha del servidor de hora
            If Now.Hour > 12 Then
                If Now.Hour > 18 Then
                    SpeakAsync("Son las " & Now.Hour & " " & Now.Minute & " de la noche.")
                Else
                    SpeakAsync("Son las " & Now.Hour & " " & Now.Minute & " de la tarde.")
                End If

            ElseIf Now.Hour < 12 Then

                If Now.Hour < 7 Then
                    SpeakAsync("Son las " & Now.Hour & " " & Now.Minute & " de la madrugada. ¿No deberia estar dormido?")
                ElseIf Now.Hour = 7 Then
                    SpeakAsync("Son las " & Now.Hour & " " & Now.Minute & " de la mañana. Que no se te haga tarde para ir al trabajo.")
                Else
                    SpeakAsync("Son las " & Now.Hour & " " & Now.Minute & " de la mañana. Que tenga un buen día.")
                End If


            ElseIf Now.Hour = 12 Then
                SpeakAsync("Son las " & Now.Hour & " del medio dia y " & Now.Minute & " minutos. De seguro ya debes de tener hambre.")

            End If



        ElseIf Argument = "qué día es hoy" Then
            'Buscar la forma para que esto sea la fecha del servidor de hora
            SpeakAsync("Hoy es " & GetDay(Now.DayOfWeek) & ", " & Now.Day & " de " & GetMonth(Now.Month) & " del " & Now.Year)


        ElseIf Argument = "pendiente" Or Argument = "pendientes" Or Argument = "que tengo pendiente" Then

            SpeakAsync("En seguida te dire que tienes pendiente.")

            App_Break(2500)

            SpeakAsync("Te seré sincera, aun no puedo decirte que tienes pendiente, ¿puedes decirle a mi creador que me permita hacerlo?.")




        ElseIf Argument = "manejador de archivos" Or Argument = "abrir archivos" Then

            SpeakAsync("Si me das un momento abriré el programa gestor de archivos.")

            App_Break(2500)

            Dim eValue As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxDisckExplorer\IsRun")

            If eValue = "False" Then

                Process.Start("N:\Dev App\DickExplorer\DickExplorer\bin\Debug\DickExplorer.exe")

            End If

            My.Application.ApplicationContext.MainForm.Close()


        ElseIf Argument = "comando" Or Argument = "comandos" Or Argument = "un comando" Or Argument = "el comando" Then

            SpeakAsync("En seguida abriré el programa de línea de comandos.")

            App_Break(2500)

            Dim eValue As String = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Gfire")

            If eValue = "False" Then

                Process.Start("N:\Nexus\App\SystemApp\GoFire\GoFire\bin\Debug\FireLine.exe")

            End If

            My.Application.ApplicationContext.MainForm.Close()

        Else

            If Argument = "es la" Then

                Exit Sub
            ElseIf Argument.Length > 3 Then
                SpeakAsync("Disculpa, pero no puedo responder a lo que me dices.")


            End If



            End If


    End Sub


    Function GetDay(ByVal DayN As Integer) As String

        If DayN = 0 Then
            Return "Domingo"

        ElseIf DayN = 1 Then

            Return "Lunes"
        ElseIf DayN = 2 Then

            Return "Martes"
        ElseIf DayN = 3 Then

            Return "Miercoles"
        ElseIf DayN = 4 Then

            Return "Jueves"
        ElseIf DayN = 5 Then

            Return "Viernes"
        ElseIf DayN = 6 Then
            Return "Sabado"
        End If


    End Function

    Function GetMonth(ByVal Month As Integer) As String

        If Month = 1 Then

            Return "Enero"

        ElseIf Month = 2 Then
            Return "Febrero"

        ElseIf Month = 3 Then
            Return "Marzo"

        ElseIf Month = 4 Then
            Return "Abril"

        ElseIf Month = 5 Then
            Return "Mayo"

        ElseIf Month = 6 Then
            Return "Junio"

        ElseIf Month = 7 Then
            Return "Julio"

        ElseIf Month = 8 Then
            Return "Agosto"

        ElseIf Month = 9 Then
            Return "Septiembre"

        ElseIf Month = 10 Then
            Return "Octubre"

        ElseIf Month = 11 Then
            Return "Noviembre"

        ElseIf Month = 12 Then
            Return "Diciembre"
        End If


    End Function

    Private Declare Function GetTickCount Lib "kernel32" () As Integer

    Sub App_Break(ByVal Time As Integer)

        Dim retraso As Integer = Time
        retraso = retraso + GetTickCount

        While retraso >= GetTickCount
            Application.DoEvents()
        End While

    End Sub

End Module
