namespace AggregateReader.BlueriqObjects
{
    public class BlueriqAttribute : IEquatable<BlueriqAttribute>, IComparable<BlueriqAttribute>
    {
        public required string Name { get; set; }
        public required string Multivalue { get; set; }
        public List<string>? Values { get; set; }
        public required BlueriqEntity ParentEntity { get; set; }
        public DerivationType? DerivationType { get; set; }

        public bool Equals(BlueriqAttribute? other)
        {
            if (other == null) { return false; }
            return Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            return Equals(obj as BlueriqAttribute);
        }

        public override string ToString() { return Name; }

        public override int GetHashCode()
        {
            return GetHashCode();
        }
        public int CompareTo(BlueriqAttribute? other)
        {
            if (other == null) return 1;

            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}
