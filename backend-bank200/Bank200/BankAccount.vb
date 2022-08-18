Public MustInherit Class BankAccount

    'Protected Variables in Parent class
    Protected strCustomerNum As String
    Protected decAccountBalance As Decimal

    'Property procedures to get the customer number
    Public ReadOnly Property getCustomerNum() As Integer
        Get
            Return strCustomerNum
        End Get
    End Property

    'Property procedure to get and set the balance of the account
    Property Balance() As Decimal
        Get
            Return decAccountBalance
        End Get
        Set(value As Decimal)
            decAccountBalance = value
        End Set
    End Property

    'Skeleton procedure for opening an account
    Public Overridable Function OpenAccount(ByVal accountId As Long, ByRef AmountToDeposit As Long)
    End Function

    'Skeleton procedure for opening an account
    Public Overridable Function OpenAccount(ByVal accountId As Long)
    End Function

End Class
