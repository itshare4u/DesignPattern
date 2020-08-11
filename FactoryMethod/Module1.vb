Imports System.ComponentModel
Imports System.Diagnostics.Eventing.Reader

Module Module1
    Sub Main()
        Dim bank = BankFactory.GetBank(BankType.TPBANK)
        Console.WriteLine(bank.GetBankName())
    End Sub

    Public Interface Bank
        Function GetBankName As String
    End Interface

    Public Class TpBank
        Implements Bank

        Public Sub New()
            BankName = "TPBank"
        End Sub

        Public Function GetBankName() As String Implements Bank.GetBankName
            Return BankName
        End Function

        Private Property BankName
    End Class

    Public Class VietComBank
        Implements Bank

        Public Sub New()
            BankName = "VietCombank"
        End Sub

        Public Function GetBankName() As String Implements Bank.GetBankName
            Return BankName
        End Function

        Private Property BankName
    End Class

    Enum BankType
        TPBANK =1
        VIETCOMBANK =2
    End Enum

    Public Class BankFactory
        Private Sub New()
        End Sub
        Public Shared Function GetBank(bankType As BankType) As Bank
            Select bankType
                Case BankType.TPBANK
                    Return New TpBank()
                Case BankType.VIETCOMBANK
                    Return New VietComBank()
                Case Else
                    Throw New InvalidEnumArgumentException("This bank type is not supported")
            End Select
        End Function
    End Class
End Module

