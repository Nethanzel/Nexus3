Imports System.Speech

Module Speaker

    Public SpeakLine As String = ""

    Sub Mouth()

        Dim a = CreateObject("SAPI.spvoice")
        a.volume = 100
        a.rate = 0
        a.speak(SpeakLine)

    End Sub

End Module
