namespace MenuParser.Domain.ValueObjects
{
    public record Price(decimal Amount, string Currency)
    {
        public override string ToString() => "${Amount} {Currency}";
    }

}
