namespace CleanArcNetBackendBoilerplate.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("Invalid email", nameof(value));

            Value = value;
        }

        public override bool Equals(object? obj)
        {
            return obj is Email other && Value == other.Value;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;
    }
}
