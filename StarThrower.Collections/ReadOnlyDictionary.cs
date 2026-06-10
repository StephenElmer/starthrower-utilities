// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace StarThrower.Collections
{
    [Obsolete("Use System.Collections.ObjectModel.ReadOnlyDictionary<TKey, TValue> instead.")]
    public class ReadOnlyDictionary<TKey, TValue> : System.Collections.ObjectModel.ReadOnlyDictionary<TKey, TValue>
        where TKey : notnull
    {
        public ReadOnlyDictionary() : base(new Dictionary<TKey, TValue>()) { }

        public ReadOnlyDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary) { }
    }
}
