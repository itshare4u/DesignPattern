Imports System.Threading

Module Module1
    Sub Main()
        Console.WriteLine(BillPughSingleton.GetInstance())
        Dim tasks As New List(Of Task)()

        ' Create a TaskFactory and pass it our custom scheduler. 
        Dim factory As New TaskFactory()
        Dim cts As New CancellationTokenSource()

        ' Use our factory to run a set of tasks. 
        For tCtr As Integer = 0 To 1000
            Dim t As Task = factory.StartNew(Sub()
                Dim instance = BillPughSingleton.GetInstance()
            End Sub, cts.Token)
            tasks.Add(t)
        Next
        Task.WaitAll(tasks.ToArray())
        cts.Dispose()
        Console.WriteLine(vbCrLf + vbCrLf + "Successful completion.")
    End Sub

    Public Class BillPughSingleton
        Private Shared Property Copper1 As Integer

        Private Sub New()
            Dim random As New Random()
            Copper1 = Copper1 + 2
        End Sub

        Public Shared Function GetInstance() As BillPughSingleton
            Console.WriteLine(Copper1)
            Return SingletonHelper.Instance
        End Function

        Private Class SingletonHelper
            Private Sub New()
            End Sub
            Public Shared ReadOnly Instance As BillPughSingleton = new BillPughSingleton()
        End Class
    End Class
End Module
