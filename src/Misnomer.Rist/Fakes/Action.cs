// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Misnomer
{
    public delegate TOutput Converter<in TInput, out TOutput>(TInput input);
}
