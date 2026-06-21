// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace StarThrower.Collections
{
    /// <summary>
    /// A read-only wrapper over a dictionary of keys and values.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <remarks>
    /// This class is a thin subclass of the BCL's own
    /// <see cref="System.Collections.ObjectModel.ReadOnlyDictionary{TKey, TValue}"/>, retained
    /// only for source/binary compatibility with existing consumers of this library.
    /// </remarks>
    [Obsolete("Use System.Collections.ObjectModel.ReadOnlyDictionary<TKey, TValue> instead.")]
    public class ReadOnlyDictionary<TKey, TValue> : System.Collections.ObjectModel.ReadOnlyDictionary<TKey, TValue>
        where TKey : notnull
    {
        /// <summary>
        /// Initializes a new, empty instance of the <see cref="ReadOnlyDictionary{TKey, TValue}"/> class.
        /// </summary>
        public ReadOnlyDictionary() : base(new Dictionary<TKey, TValue>()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyDictionary{TKey, TValue}"/> class
        /// that wraps the specified dictionary.
        /// </summary>
        /// <param name="dictionary">The dictionary to wrap.</param>
        public ReadOnlyDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary) { }
    }
}
