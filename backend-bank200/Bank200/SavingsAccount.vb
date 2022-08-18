'Perfoming Inheritance from Abstract class Account

Public Class SavingsAccount : Inherits BankAccount
    Dim f As Boolean
    Public Overrides Function OpenAccount(ByVal accountId As Long, ByRef AmountToDeposit As Long)
        'Using try catch to validate and throw exception
        Try
            If AmountToDeposit < 1000 Then

                Throw New Exception("TO OPEN A SAVINGS ACCOUNT YOU HAVE TO DEPOSIT R1000 OR MORE")
                Exit Function
            Else
                'Assigining protected parent variables to values
                MyBase.strCustomerNum = accountId
                MyBase.decAccountBalance = AmountToDeposit

            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        'Returning information from function
        Return "Your Cusomer Number is: " & MyBase.strCustomerNum & "And Your Balance is: " & MyBase.decAccountBalance.ToString("C2")
    End Function

    Public Function Withdraw(ByVal accountId As Long, ByRef AmountToWithdraw As Integer)

        Dim decWidthdrawBalance As Decimal

        'Using try catch to validate and throw exception
        Try
            If accountId <> MyBase.strCustomerNum Then

                Throw New Exception("ACCOUNT DOES NOT EXIST")
                f = False
                Exit Function

            ElseIf MyBase.decAccountBalance <= 1000 Then

                Throw New Exception("YOU CANNOT WITHDRAW WITH A MINIMUM OF R1000")
                Exit Function

            End If

            'Assigining protected parent variable to value and doing some subtraction
            decWidthdrawBalance = MyBase.decAccountBalance - CDec(AmountToWithdraw)

            If decWidthdrawBalance < 1000 Then

                Throw New Exception("THE MINIMUM BALANCE TO YOUR SAVING ACCOUNT NEEDS TO BE R1000, AMOUNT TOO LARGE FOR WITHDRAWAL !")
                Exit Function

            End If

            'Assigining protected parent variable to value
            MyBase.decAccountBalance = decWidthdrawBalance

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        'Returning information from function
        Return "Your Recent Savings Account Balance is: " & MyBase.decAccountBalance.ToString("C2")
    End Function

    Public Function Deposit(ByVal AccountID As Long, ByRef AmountToDeposit As Integer)
        'Using try catch to validate and throw exception
        Try
            If AccountID <> MyBase.strCustomerNum Then
                Throw New Exception("ACCOUNT DOES NOT EXIST")
                f = False
                Exit Function
            End If

            'Assigining protected parent variable to value and doing some addition
            MyBase.decAccountBalance = MyBase.decAccountBalance + AmountToDeposit

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        'Returning information from function
        Return "Your Recent Savings Account Balance is: " & MyBase.decAccountBalance.ToString("C2")
    End Function
End Class
