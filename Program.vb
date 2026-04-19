Module Program
    Sub Main()
        Console.OutputEncoding = System.Text.Encoding.UTF8
        
        Dim calculator = New IrregularSolidsCalculator()
        Dim exitApp = False
        
        Do Until exitApp
            ShowMenu()
            Dim choice = Console.ReadLine()
            
            Select Case choice
                Case "1"
                    calculator.CalculateTEW()
                Case "2"
                    calculator.CalculateHyperToroid()
                Case "3"
                    calculator.CalculateStellatedOctahedron()
                Case "4"
                    calculator.ShowHistory()
                Case "5"
                    calculator.ShowStatistics()
                Case "6"
                    exitApp = True
                    Console.WriteLine(vbCrLf & "Thank you! Goodbye! 👋" & vbCrLf)
                Case Else
                    Console.WriteLine("❌ Invalid option. Try again." & vbCrLf)
            End Select
        Loop
    End Sub
    
    Sub ShowMenu()
        Console.Clear()
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine("     IRREGULAR SOLIDS VOLUME CALCULATOR")
        Console.WriteLine("     Visual Basic Application")
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine()
        Console.WriteLine("1. Truncated Ellipsoidal Wedge")
        Console.WriteLine("2. Hyper-Toroid")
        Console.WriteLine("3. Stellated Octahedron")
        Console.WriteLine("4. View History")
        Console.WriteLine("5. View Statistics")
        Console.WriteLine("6. Exit")
        Console.WriteLine()
        Console.Write("Select option (1-6): ")
    End Sub
End Module
