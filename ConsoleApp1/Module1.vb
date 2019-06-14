Module Module1

    Sub Main()
        Dim handle As IntPtr = Process.GetCurrentProcess().MainWindowHandle
        Console.WriteLine(handle)
        Console.ReadLine()
    End Sub

End Module
