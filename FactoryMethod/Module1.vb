Imports System.ComponentModel
Imports System.Diagnostics.Eventing.Reader

Module Module1
    Sub Main()
        Dim bank = BankFactory.GetBank(BankType.TPBANK)
        Console.WriteLine(bank.GetBankName())
    End Sub

    Public Interface Bank
        Function GetBankName As String
        Property Name() As String
    End Interface

    Public Class TpBank
        Implements Bank

        Public Sub New()
            Bank_Name = "TPBank"
        End Sub

        Public Function GetBankName() As String Implements Bank.GetBankName
            Return Bank_Name
        End Function

        Private Property Bank_Name As String Implements Bank.Name
    End Class

    Public Class VietComBank
        Implements Bank

        Public Sub New()
            Bank_Name = "VietCombank"
        End Sub

        Public Function GetBankName() As String Implements Bank.GetBankName
            Return Bank_Name
        End Function

        Private Property Bank_Name As String Implements Bank.Name
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

