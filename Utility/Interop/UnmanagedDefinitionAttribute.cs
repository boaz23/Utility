using System;

namespace Utility.Interop
{
    /// <summary>
    /// Indicates the original definition of the parameter as specified in a P/Invoke or COM interface method (the unmanaged definition).
    /// If this is used on a return type, this also indicates that the parameter was moved to be the return type in the managed definition instead of the HRESULT.
    /// 
    /// Can also indicate the original definition of a field in a structure (a 'class' or a 'struct'), a structure, an interface or an enum.
    /// 
    /// NOTE: This has no effect whatsoever on behaviors, marshaling or anything at all.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Parameter |
        AttributeTargets.ReturnValue |
        AttributeTargets.Class |
        AttributeTargets.Struct |
        AttributeTargets.Interface |
        AttributeTargets.Enum |
        AttributeTargets.Field |
        AttributeTargets.Property,
        Inherited = false,
        AllowMultiple = false
    )]
    public class UnmanagedDefinitionAttribute : Attribute
    {
        public UnmanagedDefinitionAttribute(string unmanagedDefinition)
        {
            if (string.IsNullOrWhiteSpace(unmanagedDefinition))
            {
                throw new StringArgumentNullOrWhiteSpaceException(nameof(unmanagedDefinition));
            }

            UnmanagedDefinition = unmanagedDefinition;
        }

        public string UnmanagedDefinition { get; }

        /// <summary>
        /// Specifies any additional attributes applied in original definition
        /// </summary>
        public string Attributes { get; set; }

        /// <summary>
        /// When specified on return types,
        /// indicates whether it is defined as the last parameter in the method or
        /// it is defined as the actual return type of the method.
        /// 
        /// true to indicate it is defined as a parameter, otherwise false.
        /// </summary>
        public bool IsParameter { get; set; }
    }
}