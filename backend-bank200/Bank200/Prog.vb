Imports System

Module Prog

    Dim Bank200 As New SystemDB
    Dim input As String

    Sub Main(args As String())

        Load_Details()

        If input.ToUpper = "S" Then
            Console.Clear()
            Console.WriteLine("TEST IF WITHDRAW AMOUNT NOT MORE THAN MINIMUM BALANCE REQUIRED IN SAVINGS ACCOUNT . ")
            Bank200.WithdrawSavingsTest()
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("TEST IF ACCOUNT EXIST")
            Bank200.TestAcountExist()
            Console.WriteLine("")
            Console.WriteLine("")

        ElseIf input.ToUpper = "C" Then
            Console.Clear()
            Console.WriteLine("TEST IF WITHDRAW AMOUNT NOT MORE THAN MINIMUM BALANCE REQUIRED IN CURRENT ACCOUNT . ")
            Bank200.TestOverdraft()
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("TEST DEPOSIT FOR CURRENT ACCOUNT")
            Bank200.TestCurrentDeposit()
            Console.WriteLine("")
            Console.WriteLine("")

        End If

    End Sub

    Private Sub Load_Details() 'HEADLINE
        Console.WriteLine("")
        Console.WriteLine("DEAFULT CUSTOMER DETAILS")
        Bank200.getCustNum_Balance()
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("ENTER ""S"" TO SEE TEST RESULTS FOR SAVINGS ACOUNT") 'input
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("ENTER ""C"" TO SEE TEST RESULTS FOR CURRENT ACOUNT") 'input
        input = Console.ReadLine()
    End Sub



End Module
