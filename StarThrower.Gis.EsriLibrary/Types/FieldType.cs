// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

namespace StarThrower.Gis.EsriLibrary.Types
{
    /// <summary>
    /// Base type for the Esri field-type classes (<see cref="BooleanField"/>,
    /// <see cref="DateField"/>, <see cref="FloatField"/>, <see cref="MemoField"/>,
    /// <see cref="NumericField"/>, <see cref="StringField"/>, and
    /// <see cref="UndefinedField"/>) used by <see cref="StarThrower.Gis.EsriLibrary.Field.Type"/>.
    /// Exists so that the public <see cref="StarThrower.Gis.EsriLibrary"/> API surface is
    /// expressed in terms of this namespace rather than directly exposing
    /// <see cref="StarThrower.XBase.FieldType"/>.
    /// </summary>
    public abstract class FieldType : StarThrower.XBase.FieldType
    {
    }
}
