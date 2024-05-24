namespace AggregateReader.BlueriqObjects
{
    public class BlueriqAggregate
    {
        public required string Type { get; set; }
        public List<BlueriqEntity> Entities { get; set; }

        public BlueriqAggregate()
        {
            Entities = [];
        }

        public override string ToString() { return Type; }
    }
}
