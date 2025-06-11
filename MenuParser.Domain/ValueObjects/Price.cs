namespace MenuParser.Domain.ValueObjects
{

    public record Price(decimal Amount, string Currecny)
    {
        public override string ToString() => "${Amount} {Currency}";
    }

}
