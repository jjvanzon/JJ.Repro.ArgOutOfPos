// ReSharper disable UnusedParameter.Global
// ReSharper disable MethodOverloadWithOptionalParameter

using static System.Console;
using static Impl;

// ✔️ Several syntaxes => 1st overload (WORKS)
IsFalse("B \t".In(caseMatters: false, spaceMatters: false, [ "A", "B", "C" ] ));
IsFalse("B \t".In(caseMatters: false,               false, [ "A", "B", "C" ] ));
IsFalse("B \t".In(             false, spaceMatters: false, [ "A", "B", "C" ] ));
IsFalse("B \t".In(             false,               false, [ "A", "B", "C" ] ));
IsFalse("B \t".In(caseMatters: false, spaceMatters: false,   "A", "B", "C"   ));
IsFalse("B \t".In(caseMatters: false,               false,   "A", "B", "C"   ));
IsFalse("B \t".In(             false, spaceMatters: false,   "A", "B", "C"   ));
IsFalse("B \t".In(             false,               false,   "A", "B", "C"   ));

// ✔️ Swapped parameters => 2nd overload (WORKS)
IsTrue ("B \t".In(spaceMatters: false,              false, [ "A", "B", "C" ] ));
IsTrue ("B \t".In(              false, caseMatters: false, [ "A", "B", "C" ] ));

// 🐛 The trouble maker

// ✔️ Visual Studio 2026 (ReSharper disabled) => 2nd overload (WORKS)
// ❌ ReSharper enabled => 1st overload (ERROR squiggly)
// ✔️ Compiler/runtime => 2nd overload (WORKS)
IsTrue ("B \t".In(spaceMatters: false, caseMatters: false, [ "A", "B", "C" ] ));

WriteLine("Assertions Successful");



static class Impl
{
    public static bool In(this string? value, bool caseMatters, bool spaceMatters, params IEnumerable<string?>? coll) 
        => false;

    // Parameter names SWAPPED

    public static bool In(this string? value, bool spaceMatters, bool caseMatters, IEnumerable<string?>? coll, int dummy = default) 
        => true;

    public static void IsTrue(bool boo)
    {
        if (!boo) throw new Exception("boo is not true");
    }

    public static void IsFalse(bool boo)
    {
        if (boo) throw new Exception("boo is not false");
    }
}