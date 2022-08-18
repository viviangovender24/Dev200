Public Class SystemDB

    'Declare objects or classes
    Private SavingsCustomers(2) As SavingsAccount
    Private CurrentCustomers(2) As CurrentAccount

    Public Sub New()

        'Initializing object savings
        SavingsCustomers(0) = New SavingsAccount
        SavingsCustomers(1) = New SavingsAccount
        SavingsCustomers(2) = New SavingsAccount

        'Opening Savings account for 3 customers
        SavingsCustomers(0).OpenAccount(1, 2000)
        SavingsCustomers(1).OpenAccount(2, 5000)
        SavingsCustomers(2).OpenAccount(5, 9000)

        'Initializing object current account
        CurrentCustomers(0) = New CurrentAccount
        CurrentCustomers(1) = New CurrentAccount
        CurrentCustomers(2) = New CurrentAccount

        'Opening Current account for 3 customers
        CurrentCustomers(0).openAccount(3)
        CurrentCustomers(1).openAccount(4)
        CurrentCustomers(2).openAccount(6)

        CurrentCustomers(0).Balance = 1000
        CurrentCustomers(1).Balance = -5000
        CurrentCustomers(2).Balance = 50000

        CurrentCustomers(0).setOverdraft = 10000
        CurrentCustomers(1).setOverdraft = 20000
        CurrentCustomers(2).setOverdraft = 30000

    End Sub

    Public Sub TestOverdraft()
        'Input variables for class method parameter
        Dim CustomerNum As Integer = 4
        Dim AmountToWithdraw As Decimal = 2150

        'For loop, looping through the array object
        For i = 0 To CurrentCustomers.Length - 1
            Console.WriteLine("")
            Console.WriteLine("THESE ARE CURRENT ACCOUNT DETAILS FOR CUSTOMER NUMBER: " & CustomerNum)
            Console.WriteLine(CurrentCustomers(i).Withdraw(CustomerNum, AmountToWithdraw))
            CustomerNum += 1
            AmountToWithdraw *= 2
        Next
    End Sub

    Public Sub TestCurrentDeposit()
        'Input variables for class method parameter
        Dim CustomerNum As Integer = 4
        Dim AmountToWithdraw As Decimal = 1500

        'For loop, looping through the array object
        For i = 0 To CurrentCustomers.Length - 1
            Console.WriteLine("")
            Console.WriteLine("THESE ARE CURRENT ACCOUNT DETAILS FOR CUSTOMER NUMBER: " & CustomerNum)
            Console.WriteLine(CurrentCustomers(i).Deposit(CustomerNum, AmountToWithdraw))
            CustomerNum += 1
            AmountToWithdraw *= 2
        Next
    End Sub


    Public Sub TestAcountExist()
        'Input variables for class method parameter
        Dim CustomerNum As Integer = 1
        Dim AmountToDeposit As Decimal = 5000.0

        'For loop, looping through the array object
        For i = 0 To SavingsCustomers.Length - 1
            Console.WriteLine("")
            Console.WriteLine("THESE ARE SAVINGS ACCOUNT DETAILS FOR CUSTOMER NUMBER: " & CustomerNum & " AND AMOUNT TO DEPOSIT IS: " & AmountToDeposit)
            Console.WriteLine(SavingsCustomers(i).Deposit(CustomerNum, AmountToDeposit))
            CustomerNum += 3
            AmountToDeposit *= 2
        Next
    End Sub

    Public Sub WithdrawSavingsTest()
        'Input variables for class method parameter
        Dim CustomerNum As Integer = 1
        Dim amountTowithdraw As Decimal = 2000

        'For loop, looping through the array object
        For i = 0 To SavingsCustomers.Length - 1
            Console.WriteLine("")
            Console.WriteLine("SAVINGS ACCOUNT DETAILS FOR CUSTOMER: " & CustomerNum)
            Console.WriteLine(SavingsCustomers(i).Withdraw(CustomerNum, amountTowithdraw))
            CustomerNum += 1
            amountTowithdraw *= 2
        Next
    End Sub

    Public Sub getCustNum_Balance()
        'Input variables for class method parameter


        'For loop, looping through the array object
        For i = 0 To SavingsCustomers.Length - 1
            Console.WriteLine("Customer Number: " & SavingsCustomers(i).getCustomerNum & " Balance of: " & SavingsCustomers(i).Balance.ToString("C2"))
        Next

        For e = 0 To CurrentCustomers.Length - 1
            Console.WriteLine("Customer Number: " & CurrentCustomers(e).getCustomerNum & " Balance of: " & CurrentCustomers(e).Balance.ToString("C2"))
        Next

    End Sub

End Class
