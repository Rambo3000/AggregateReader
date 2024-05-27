﻿namespace AggregateReader.BlueriqObjects
{
    public class BlueriqEntity :IEquatable<BlueriqEntity> , IComparable<BlueriqEntity>
    {
        public required string Type { get; set; }
        public required string Id { get; set; }
        public List<BlueriqRelation> ParentRelations { get; set; }

        public BlueriqEntity()
        {
            ParentRelations = [];
        }

        public required List<BlueriqAttribute> Attributes { get; set; }
        public required List<BlueriqRelation> Relations { get; set; }
        public int Index { get; set; }
        public bool OnlyOneInstanceOfThisTypeExists { get; set; }
        public override string ToString() {
            string indexString = OnlyOneInstanceOfThisTypeExists ? string.Empty : $" #{Index}";
            return Type + indexString; }

        public bool Equals(BlueriqEntity? other)
        {
            if (other == null) { return false; }
            return Type == other.Type;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            return Equals(obj as BlueriqEntity);
        }

        public override int GetHashCode()
        {
            return GetHashCode();
        }

        public int CompareTo(BlueriqEntity? other)
        {
            if (other == null) return 1;

            return string.Compare(Type, other.Type, StringComparison.Ordinal);
        }
    }
}