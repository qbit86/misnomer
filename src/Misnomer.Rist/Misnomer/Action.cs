// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Misnomer
{
    /// <summary>
    /// Represents a method that converts an object from one type to another type.
    /// </summary>
    /// <param name="input">The object to convert.</param>
    /// <typeparam name="TInput">The type of object that is to be converted.</typeparam>
    /// <typeparam name="TOutput">The type the input object is to be converted to.</typeparam>
    public delegate TOutput Converter<in TInput, out TOutput>(TInput input);
}
