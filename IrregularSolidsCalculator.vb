Imports System.Math

Public Class IrregularSolidsCalculator
    
    Private calculations As New List(Of CalculationRecord)
    
    ''' Truncated Ellipsoidal Wedge Calculation
    Public Sub CalculateTEW()
        Console.Clear()
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine("TRUNCATED ELLIPSOIDAL WEDGE CALCULATOR")
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine()
        
        Try
            Dim a = InputDouble("Semi-axis a (X-direction): ")
            Dim b = InputDouble("Semi-axis b (Y-direction): ")
            Dim c = InputDouble("Semi-axis c (Z-direction): ")
            Dim h = InputDouble("Wedge Height h: ")
            Dim theta = InputAngle("Wedge Angle θ (0-90 degrees): ")
            
            Console.WriteLine()
            Console.WriteLine("⏳ Calculating...")
            System.Threading.Thread.Sleep(500)
            
            ' Convert angle to radians
            Dim thetaRad = theta * PI / 180
            
            ' Calculate volume: V = (4/3)πabc × [1 - (h/c)² × sin²(θ)]
            Dim baseVolume = (4 / 3) * PI * a * b * c
            Dim heightRatio = h / c
            Dim reductionFactor = 1 - (heightRatio ^ 2) * (Sin(thetaRad) ^ 2)
            Dim volume = baseVolume * Max(0, reductionFactor)
            
            ' Store calculation
            Dim record = New CalculationRecord With {
                .Name = "Truncated Ellipsoidal Wedge",
                .Volume = volume,
                .Timestamp = DateTime.Now
            }
            calculations.Add(record)
            
            ' Display result
            Console.WriteLine()
            Console.WriteLine(StrDup(70, "═"))
            Console.WriteLine("✓ CALCULATION COMPLETE")
            Console.WriteLine(StrDup(70, "═"))
            Console.WriteLine()
            Console.WriteLine($"Volume: {volume:F8} cubic units")
            Console.WriteLine()
            Console.WriteLine("Formula: V = (4/3)πabc × [1 - (h/c)² × sin²(θ)]")
            Console.WriteLine()
            Console.WriteLine("Parameters:")
            Console.WriteLine($"  • Semi-axis a: {a:F4}")
            Console.WriteLine($"  • Semi-axis b: {b:F4}")
            Console.WriteLine($"  • Semi-axis c: {c:F4}")
            Console.WriteLine($"  • Wedge Height h: {h:F4}")
            Console.WriteLine($"  • Wedge Angle θ: {theta:F2}°")
            Console.WriteLine()
            Console.WriteLine(StrDup(70, "═"))
            Console.WriteLine()
            Console.Write("Press any key to continue...")
            Console.ReadKey(True)
            
        Catch ex As Exception
            Console.WriteLine($"❌ Error: {ex.Message}")
            Console.ReadKey(True)
        End Try
    End Sub
    
    ''' Hyper-Toroid Calculation
    Public Sub CalculateHyperToroid()
        Console.Clear()
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine("HYPER-TOROID CALCULATOR")
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine()
        
        Try
            Dim R0 = InputDouble("Major Radius Base R₀: ")
            Dim r0 = InputDouble("Minor Radius Base r₀: ")
            Dim variation = InputDouble("Variation Factor (0-1): ")
            Dim pathLength = InputDouble("Path Length Parameter L: ")
            
            If variation < 0 OrElse variation > 1 Then
                Throw New Exception("Variation factor must be between 0 and 1!")
            End If
            
            Console.WriteLine()
            Console.WriteLine("⏳ Calculating...")
            System.Threading.Thread.Sleep(500)
            
            ' Numerical integration using Simpson's Rule
            Dim segments = 1000
            Dim integral = 0.0
            Dim deltaS = pathLength / segments
            
            For i As Integer = 0 To segments - 1
                Dim s = i * deltaS
                Dim rS = r0 * (1 + variation * Sin(2 * PI * s / pathLength))
                Dim RS = R0 * (1 + variation * Cos(2 * PI * s / pathLength))
                integral += (rS * rS * RS) * deltaS
            Next
            
            Dim volume = 2 * PI * PI * integral
            
            ' Store calculation
            Dim record = New CalculationRecord With {
                .Name = "Hyper-Toroid",
                .Volume = volume,
                .Timestamp = DateTime.Now
            }
            calculations.Add(record)
            
            ' Display result
            Console.WriteLine()
            Console.WriteLine(StrDup(70, "═"))
            Console.WriteLine("✓ CALCULATION COMPLETE")
            Console.WriteLine(StrDup(70, "═"))
            Console.WriteLine()
            Console.WriteLine($"Volume: {volume:F8} cubic units")
            Console.WriteLine()
            Console.WriteLine("Formula: V = 2π² ∫ r(s)² × R(s) ds")
            Console.WriteLine()
            Console.WriteLine("Parameters:")
            Console.WriteLine($"  • Major Radius Base R₀: {R0:F4}")
            Console.WriteLine($"  • Minor Radius Base r₀: {r0:F4}")
            Console.WriteLine($"  • Variation Factor: {variation:F4}")
            Console.WriteLine($"  • Path Length Parameter: {pathLength:F4}")
            Console.WriteLine()
            Console.WriteLine(StrDup(70, "═"))
            Console.WriteLine()
            Console.Write("Press any key to continue...")
            Console.ReadKey(True)
            
        Catch ex As Exception
            Console.WriteLine($"❌ Error: {ex.Message}")
            Console.ReadKey(True)
        End Try
    End Sub
    
    ''' Stellated Octahedron Calculation
    Public Sub CalculateStellatedOctahedron()
        Console.Clear()
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine("STELLATED OCTAHEDRON CALCULATOR")
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine()
        
        Try
            Dim a = InputDouble("Edge Length a: ")
            Dim k = InputDouble("Stellation Factor (0-1): ")
            Dim h = InputDouble("Pyramid Height Factor: ")
            
            If k < 0 OrElse k > 1 Then
                Throw New Exception("Stellation factor must be between 0 and 1!")
            End If
            
            Console.WriteLine()
            Console.WriteLine("⏳ Calculating...")
            System.Threading.Thread.Sleep(500)
            
            ' Base octahedron volume: V = (√2/3)a³
            Dim baseVolume = (Sqrt(2) / 3) * (a ^ 3)
            
            ' Calculate volume of 8 pyramids
            Dim pyramidVolume = 0.0
            For i As Integer = 1 To 8
                Dim pyramidHeight = a * h * (1 + k / 10)
                Dim pyramidBase = (a * a * Sqrt(3)) / 4
                pyramidVolume += (1 / 3) * pyramidBase * pyramidHeight
            Next
            
            Dim volume = baseVolume * (1 + k) + pyramidVolume
            
            ' Store calculation
            Dim record = New CalculationRecord With {
                .Name = "Stellated Octahedron",
                .Volume = volume,
                .Timestamp = DateTime.Now
            }
            calculations.Add(record)
            
            ' Display result
            Console.WriteLine()
            Console.WriteLine(StrDup(70, "═"))
            Console.WriteLine("✓ CALCULATION COMPLETE")
            Console.WriteLine(StrDup(70, "═"))
            Console.WriteLine()
            Console.WriteLine($"Volume: {volume:F8} cubic units")
            Console.WriteLine()
            Console.WriteLine("Formula: V = (√2/3)a³ × (1 + k) + 8×Pyramids")
            Console.WriteLine()
            Console.WriteLine("Parameters:")
            Console.WriteLine($"  • Edge Length a: {a:F4}")
            Console.WriteLine($"  • Stellation Factor k: {k:F4}")
            Console.WriteLine($"  • Pyramid Height Factor: {h:F4}")
            Console.WriteLine()
            Console.WriteLine(StrDup(70, "═"))
            Console.WriteLine()
            Console.Write("Press any key to continue...")
            Console.ReadKey(True)
            
        Catch ex As Exception
            Console.WriteLine($"❌ Error: {ex.Message}")
            Console.ReadKey(True)
        End Try
    End Sub
    
    ''' Show Calculation History
    Public Sub ShowHistory()
        Console.Clear()
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine("CALCULATION HISTORY")
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine()
        
        If calculations.Count = 0 Then
            Console.WriteLine("No calculations yet.")
        Else
            For Each calc In calculations
                Console.WriteLine($"[{calc.Name}]")
                Console.WriteLine($"  Volume: {calc.Volume:F8} cubic units")
                Console.WriteLine($"  Time: {calc.Timestamp}")
                Console.WriteLine()
            Next
        End If
        
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine()
        Console.Write("Press any key to continue...")
        Console.ReadKey(True)
    End Sub
    
    ''' Show Statistics
    Public Sub ShowStatistics()
        Console.Clear()
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine("STATISTICS")
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine()
        
        If calculations.Count = 0 Then
            Console.WriteLine("No calculations yet.")
        Else
            Console.WriteLine($"Total Calculations: {calculations.Count}")
            Console.WriteLine($"Average Volume: {calculations.Average(Function(c) c.Volume):F8}")
            Console.WriteLine($"Maximum Volume: {calculations.Max(Function(c) c.Volume):F8}")
            Console.WriteLine($"Minimum Volume: {calculations.Min(Function(c) c.Volume):F8}")
            Console.WriteLine()
            
            ' Group by type
            Dim grouped = calculations.GroupBy(Function(c) c.Name)
            Console.WriteLine("By Solid Type:")
            For Each group In grouped
                Console.WriteLine($"  • {group.Key}: {group.Count()} calculations")
            Next
        End If
        
        Console.WriteLine()
        Console.WriteLine(StrDup(70, "═"))
        Console.WriteLine()
        Console.Write("Press any key to continue...")
        Console.ReadKey(True)
    End Sub
    
    ''' Input helper for Double
    Private Function InputDouble(prompt As String) As Double
        Do
            Console.Write(prompt)
            Dim input As Double
            If Double.TryParse(Console.ReadLine(), input) AndAlso input > 0 Then
                Return input
            End If
            Console.WriteLine("❌ Please enter a positive number.")
        Loop
    End Function
    
    ''' Input helper for Angle
    Private Function InputAngle(prompt As String) As Double
        Do
            Console.Write(prompt)
            Dim input As Double
            If Double.TryParse(Console.ReadLine(), input) AndAlso input >= 0 AndAlso input <= 90 Then
                Return input
            End If
            Console.WriteLine("❌ Please enter a number between 0 and 90.")
        Loop
    End Function
    
End Class

''' Record class for storing calculations
Public Class CalculationRecord
    Public Property Name As String
    Public Property Volume As Double
    Public Property Timestamp As DateTime
End Class
