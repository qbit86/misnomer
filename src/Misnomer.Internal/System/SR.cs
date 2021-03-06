// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System
{
    internal static partial class SR
    {
        // This method is used to decide if we need to append the exception message parameters to the message when calling SR.Format.
        // by default it returns false.
        // Native code generators can replace the value this returns based on user input at the time of native code generation.
        // Marked as NoInlining because if this is used in an AoT compiled app that is not compiled into a single file, the user
        // could compile each module with a different setting for this. We want to make sure there's a consistent behavior
        // that doesn't depend on which native module this method got inlined into.
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool UsingResourceKeys()
        {
            return false;
        }

        internal static string Format(string resourceFormat, object? p1)
        {
            if (UsingResourceKeys())
            {
                return string.Join(", ", resourceFormat, p1);
            }

            return string.Format(CultureInfo.InvariantCulture, resourceFormat, p1);
        }

        internal static string Format(string resourceFormat, object? p1, object? p2)
        {
            if (UsingResourceKeys())
            {
                return string.Join(", ", resourceFormat, p1, p2);
            }

            return string.Format(CultureInfo.InvariantCulture, resourceFormat, p1, p2);
        }

        internal static string Format(string resourceFormat, object? p1, object? p2, object? p3)
        {
            if (UsingResourceKeys())
            {
                return string.Join(", ", resourceFormat, p1, p2, p3);
            }

            return string.Format(CultureInfo.InvariantCulture, resourceFormat, p1, p2, p3);
        }

        internal static string Format(string resourceFormat, params object?[]? args)
        {
            if (args != null)
            {
                if (UsingResourceKeys())
                {
                    return resourceFormat + ", " + string.Join(", ", args);
                }

                return string.Format(CultureInfo.InvariantCulture, resourceFormat, args);
            }

            return resourceFormat;
        }
    }
}
