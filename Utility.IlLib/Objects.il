﻿.class public abstract auto ansi beforefieldinit Utility.ObjectsUnsafe extends [System.Runtime]System.Object
{
    .method family hidebysig specialname rtspecialname instance void .ctor() cil managed
    {
        .maxstack  1
        ldarg.0
        call instance void [System.Runtime]System.Object::.ctor()
        ret
    }

    .method public hidebysig static !!TResult UnsafeCast<T, TResult>(!!T obj) cil managed aggressiveinlining
    {
        .custom instance void [System.Runtime]System.Security.SecuritySafeCritical::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        ldarg.0
        ret
    }

    .method public hidebysig static !!TResult UnsafeUnbox<class T, valuetype .ctor TResult>(!!T obj) cil managed aggressiveinlining
    {
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
