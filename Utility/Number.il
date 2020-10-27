.class public abstract auto ansi sealed beforefieldinit Utility.Numbers extends [netstandard]System.Object
{
     .method public hidebysig static !!T And<valuetype .ctor T>(!!T 'value', !!T 'flags') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        and
        ret
    }

    .method public hidebysig static !!T Or<valuetype .ctor T>(!!T 'value', !!T 'flags') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        or
        ret
    }

    .method public hidebysig static !!T Not<valuetype .ctor T>(!!T 'value') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        ldarg.0
        not
        ret
    }

    .method public hidebysig static !!T Xor<valuetype .ctor T>(!!T 'value', !!T 'flags') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        xor
        ret
    }

     .method public hidebysig static !!T LeftShift<valuetype .ctor T>(!!T 'value', int32 'amount') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        shl
        ret
    }

     .method public hidebysig static !!T RightShift<valuetype .ctor T>(!!T 'value', int32 'amount') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        shr
        ret
    }

    .method public hidebysig static !!T RemoveFlags<valuetype .ctor T>(!!T 'value', !!T 'flags') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        not
        and
        ret
    }

    .method public hidebysig static bool HasAllOfFlags<valuetype .ctor T>(!!T 'value', !!T 'flags') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        and
        ldarg.1
        ceq
        ret
    }

    .method public hidebysig static bool HasAnyOfFlags<valuetype .ctor T>(!!T 'value', !!T 'flags') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        and
        ldc.i4.0
        ceq
        ldc.i4.0
        ceq
        ret
    }

    .method public hidebysig static bool IsEmpty<valuetype .ctor T>(!!T 'value') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldc.i4.0
        ceq
        ret
    }

    .method public hidebysig static int32 CompareTo<valuetype .ctor T>(!!T 'value', !!T 'number') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        IL_0000: ldarg.0
        IL_0001: ldarg.1
        IL_0002: bne.un.s IL_0006
        IL_0004: ldc.i4.0
        IL_0005: ret
        IL_0006: ldarg.0
        IL_0007: ldarg.1
        IL_0008: blt.s IL_000c
        IL_000a: ldc.i4.1
        IL_000b: ret
        IL_000c: ldc.i4.m1
        IL_000d: ret
    }

    .method public hidebysig static bool Equals<valuetype .ctor T>(!!T 'value', !!T 'number') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        ceq
        ret
    }

    .method public hidebysig static bool IsLessThan<valuetype .ctor T>(!!T 'value', !!T 'number') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        clt
        ret
    }

    .method public hidebysig static bool IsLessThanOrEqualTo<valuetype .ctor T>(!!T 'value', !!T 'number') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        cgt
        ldc.i4.0
        ceq
        ret
    }

    .method public hidebysig static bool IsGreaterThan<valuetype .ctor T>(!!T 'value', !!T 'number') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        cgt
        ret
    }

    .method public hidebysig static bool IsGreaterThanOrEqualTo<valuetype .ctor T>(!!T 'value', !!T 'number') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        clt
        ldc.i4.0
        ceq
        ret
    }

    .method public hidebysig static !!T Add<valuetype .ctor T>(!!T 'value', !!T 'number') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        add
        ret
    }

    .method public hidebysig static !!T Subtract<valuetype .ctor T>(!!T 'value', !!T 'number') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        sub
        ret
    }

    .method public hidebysig static !!T Multiply<valuetype .ctor T>(!!T 'value', !!T 'number') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        mul
        ret
    }

    .method public hidebysig static !!T Divide<valuetype .ctor T>(!!T 'value', !!T 'number') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        div
        ret
    }

    .method public hidebysig static !!T Modulus<valuetype .ctor T>(!!T 'value', !!T 'number') cil managed aggressiveinlining
    {
        .custom instance void [netstandard]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        rem
        ret
    }
}