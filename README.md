# 🧮 Irregular Solids Volume Calculator

A Visual Basic console application for calculating volumes of unique irregular geometric solids.

## 📐 Supported Solids

1. **Truncated Ellipsoidal Wedge**
   - Formula: V = (4/3)πabc × [1 - (h/c)² × sin²(θ)]
   - Parameters: Semi-axes a, b, c; Wedge height h; Angle θ

2. **Hyper-Toroid**
   - Formula: V = 2π² ∫ r(s)² × R(s) ds
   - Parameters: Major radius R₀, Minor radius r₀, Variation factor, Path length

3. **Stellated Octahedron**
   - Formula: V = (√2/3)a³ × (1 + k) + 8×Pyramids
   - Parameters: Edge length, Stellation factor, Pyramid height factor

## 🚀 How to Run

### Requirements
- .NET 6.0 SDK or later

### Run
```bash
dotnet run
