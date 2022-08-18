'Perfoming Inheritance from Abstract class Account
Public Class CurrentAccount : Inherits BankAccount

    'Protected Variable in the child class
    Protected decOverdraft As Decimal

    'Property procedures to set the overdraft
    Public WriteOnly Property setOverdraft() As Integer
        Set(value As Integer)
            decOverdraft = value
        End Set
    End Property

    Public Overrides Function openAccount(ByVal accountId As Long)

        'Assigining protected parent variable to value
        MyBase.strCustomerNum = accountId

        'Returning information from function
        Return "Your Cusomer Number is: " & MyBase.strCustomerNum & "And Your Balance is: " & MyBase.decAccountBalance.ToString("C2")
    End Function

    Public Function Withdraw(ByVal accountId As Long, ByRef AmountToWithdraw As Integer)
        'Using try catch to validate and throw exception
        Try

            Dim decWidthdrawBalance As Decimal

            'Assigining protected parent variable to value and doing some addition
            decWidthdrawBalance = MyBase.decAccountBalance + decOverdraft

            If accountId <> MyBase.strCustomerNum Then
                Throw New Exception("ACCOUNT DOES NOT EXIST")
                Exit Function

            ElseIf AmountToWithdraw > decWidthdrawBalance Then
                Throw New Exception("YOU CANNOT WITHDRAW MORE THAN YOUR BALANCE AND OVERDRAFT LIMIT")
                Exit Function

            ElseIf AmountToWithdraw > MyBase.decAccountBalance Then

                'Assigining variable to value and doing some subtraction
                decOverdraft = decWidthdrawBalance - AmountToWithdraw

            End If

            'Assigining protected parent variable to value and doing some subtraction
            MyBase.decAccountBalance -= AmountToWithdraw

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        'Returning information from function
        Return "Your Recent Current Account Balance is: " & MyBase.decAccountBalance.ToString("C2") & " & Overdraft Balance is: " & decOverdraft.ToString("c2")
    End Function

    Public Function Deposit(ByVal AccountID As Long, ByRef AmountToDeposit As Integer)
        'Using try catch to validate and throw exception
        Try
            If AccountID <> strCustomerNum Then
                Throw New Exception("ACCOUNT DOES NOT EXIST")
                Exit Function
            End If

            'Assigining protected parent variable to value and doing some addition
            MyBase.decAccountBalance = MyBase.decAccountBalance + AmountToDeposit

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        'Returning information from function
        Return "Your Recent Current Account Balance is: " & MyBase.decAccountBalance.ToString("C2")
    End Function

End Class
