namespace Nadam.FlatRockTest.Models
{
    public class MultyChooseQuoteTask
    {
        public Quote Quote { get; set; }
        public IList<string> PossibleAnswers { get; set; }
    }
}
