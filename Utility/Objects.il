.class public abstract auto ansi sealed beforefieldinit Utility.Objects extends [System.Runtime]System.Object
{
    .method public hidebysig static !!TResult UnsafeCast<T, TResult>(!!T obj) cil managed aggressiveinlining
    {
        .custom instance void [System.Runtime]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .custom instance void [System.Runtime]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        ldarg.0
        ret
    }

    .method public hidebysig static !!TResult UnsafeUnbox<class T, valuetype .ctor TResult>(!!T obj) cil managed aggressiveinlining
    {
        .custom instance void [System.Runtime]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
        .custom instance void [System.Runtime]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        ldarg.0
        unbox.any !!TResult
        ret
    }

    .method public hidebysig static int32 SizeOf<valuetype .ctor T>() cil managed aggressiveinlining
    {
        .custom instance void [System.Runtime]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        sizeof !!T
        ret
    }
}