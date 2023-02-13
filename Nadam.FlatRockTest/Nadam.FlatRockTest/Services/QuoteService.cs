using Nadam.FlatRockTest.Models;

namespace Nadam.FlatRockTest.Services
{
    public class QuoteService
    {
        private readonly IEnumerable<Quote> _quotes;
        private IList<QuoteAuthor> quoteAuthors;

        public QuoteService(IEnumerable<Quote> quotes)
        {
            _quotes = quotes;
            quoteAuthors = _quotes.Select(p => p.Author).ToList();
        }

        public int CalculateNumberOfPages(int pageSize)
            => (int)Math.Ceiling(_quotes.Count() / (double)pageSize);

        public IEnumerable<MultyChooseQuoteTask> GenerateMultiChooseTasks(int page, int taskCount = 10)
        {
            return _quotes.Skip((page - 1) * taskCount).Take(taskCount).Select(p =>
            {
                var possibleAnswers = GeneratePossibleAnswers(p.Author.Id, 2);
                possibleAnswers.Add(p.Author.Name);
                Shuffle(possibleAnswers);

                return new MultyChooseQuoteTask()
                {
                    Quote = p,
                    PossibleAnswers = possibleAnswers
                };
            });
        }

        private IEnumerable<BinaryQuoteTask> GenerateYesNoTasks(int page, int taskCount = 10)
        {
            var randomGenerator = new Random();
            return _quotes.Skip((page - 1)*taskCount).Take(taskCount).Select(p =>
            {
                var random = randomGenerator.Next();
                if(random % 2 == 0)
                {
                    return new BinaryQuoteTask()
                    {
                        Quote = p,
                        ISCorrect = true
                    };
                }
                else
                {
                    return new BinaryQuoteTask()
                    {
                        Quote = new Quote()
                        {
                            QuoteText = p.QuoteText,
                            Author = GetRandomAuthor(p.Author.Id)
                        },
                        ISCorrect = false
                    };
                }
            });
        }

        private QuoteAuthor GetRandomAuthor(Guid authorId)
        {
            var randomGenerator = new Random();
            var next = randomGenerator.Next(0, quoteAuthors.Count - 1);

            var nextAuthor = quoteAuthors[next];

            while(nextAuthor.Id == authorId)
            {
                next = randomGenerator.Next(0, quoteAuthors.Count - 1);
                nextAuthor = quoteAuthors[next];
            }

            return nextAuthor;
        }

        private List<string> GeneratePossibleAnswers(Guid authorId, int count)
        {
            var possibleAnswers = new List<string>(count + 1);

            for (int i = 0; i < count; i++)
            {
                var next = GetRandomAuthor(authorId);
                possibleAnswers.Add(next.Name);
            }

            return possibleAnswers;
        }

        public void Shuffle<T>(IList<T> array)
        {
            var rng = new Random();
            int n = array.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
