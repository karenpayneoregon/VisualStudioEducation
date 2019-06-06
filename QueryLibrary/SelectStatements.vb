Public Class SelectStatements
    Public ReadOnly Property SelectCustomerByCustomerIdentifier() As String
        Get
            Return <SQL>
                    SELECT Cust.CustomerIdentifier,
                           Cust.CompanyName, Cust.ContactId,
                           Contacts.FirstName,
                           Contacts.LastName,
                           CT.ContactTitle,
                           Cust.CountryIdentifier,
                           Countries.Name AS CountryName
                    FROM Customers AS Cust
                         INNER JOIN ContactType AS CT ON Cust.ContactTypeIdentifier = CT.ContactTypeIdentifier
                         INNER JOIN Contacts ON Cust.ContactId = Contacts.ContactId
                         INNER JOIN Countries ON Cust.CountryIdentifier = Countries.CountryIdentifier
                    WHERE Cust.CustomerIdentifier = @CustomerIdentifier;
                   </SQL>.Value
        End Get
    End Property
End Class
