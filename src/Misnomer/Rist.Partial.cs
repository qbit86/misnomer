﻿using System;

namespace Misnomer
{
    // https://github.com/dotnet/corert/blob/master/src/System.Private.CoreLib/shared/System/Collections/Generic/List.cs
    public partial class Rist<T> : IDisposable
    {
        private const int MaxArrayLength = 0X7FEFFFFF;

        private System.Buffers.ArrayPool<T> Pool { get; } = System.Buffers.ArrayPool<T>.Shared;

        public void Dispose()
        {
            T[] oldItems = _items;
            _items = s_emptyArray;
            Pool.Return(oldItems);
        }
    }
}
