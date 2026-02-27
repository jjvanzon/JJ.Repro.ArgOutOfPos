// Works (1st overload)
bool a = "B \t".In(caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]);
bool b = "B \t".In(             false, spaceMatters: false, [ "A", "B", "C" ]);
bool c = "B \t".In(caseMatters: false,               false, [ "A", "B", "C" ]);
bool d = "B \t".In(             false,               false, [ "A", "B", "C" ]);

// Parameters swapped:

// IDE => 1st overload (error)
// Runtime => 2nd overload (works)
bool e = "B \t".In(spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]);

static class Impl
{
    public static bool In(this string? value, bool caseMatters, bool spaceMatters, params IEnumerable<string?>? coll)
    {
        return value != default && caseMatters && spaceMatters && coll != default;
    }

    // Parameter names swapped
    public static bool In(this string? value, bool spaceMatters, bool caseMatters, IEnumerable<string?>? coll,
        object? overload = default)
    {
        return value != default && caseMatters && spaceMatters && coll != default && overload != default;
    }
}