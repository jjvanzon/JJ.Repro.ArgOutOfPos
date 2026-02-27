JJ.Repro.ArgOutOfPos
====================

Minimal repro project demonstrating an overload resolution / argument-position issue observed when ReSharper is enabled in Visual Studio.

What it shows
- A tiny C# program that defines two `In` extension overloads where the boolean parameter names are swapped between overloads.
- Calling the method with named arguments in different orders behaves correctly for the compiler and at runtime, but ReSharper (in one configuration) reports a squiggly on one call.


```
C# language version: 14.0
Target framework: .NET 10
Visual Studio Community 2026 Version 18.3.2

JetBrains ReSharper 2025.3.3
Build 253.0.20260216.123800 built on 2026-02-16
ReSharper 2025.3.20260219.74449

```
