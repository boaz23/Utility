using System;

namespace Utility
{
    /// <summary>
    /// Indicates the possibles types that this member can take.
    /// For example, it can be used when a target that takes an '<see cref="object"/>' or an '<see cref="IntPtr"/>'
    /// that can represent multiple types, interfaces or structures.
    /// 
    /// NOTE: This has no effect whatsoever on behaviors, marshaling or anything at all.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Parameter |
        AttributeTargets.ReturnValue |
        AttributeTargets.Field,
        Inherited = false,
        AllowMultiple = false
    )]
    public class PossibleTypesAttribute : Attribute
    {
        public PossibleTypesAttribute(params Type[] types)
        {
            if (types == null || types.Length == 0)
            {
                throw new ArgumentNullOrEmptyException(nameof(types));
            }

            Types = types;
        }
        public PossibleTypesAttribute(string types)
        {
            if (string.IsNullOrWhiteSpace(types))
            {
                throw new StringArgumentNullOrWhiteSpaceException(nameof(types));
            }

            TypesString = types;
        }

        public Type[] Types { get; }
        public string TypesString { get; }
    }
}