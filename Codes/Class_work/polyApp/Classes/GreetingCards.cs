using System.Collections.Generic;
using System.Linq;

namespace polyApp.Classes
{
    public class GreetingCards//Singleton design patten, the class is global and has only one instance
    {
        private static GreetingCards _instance;
        private List<GreetingCard> cards;

        private GreetingCards()
        {
            cards = new List<GreetingCard>();
        }

        public static GreetingCards GetInstance()
        {
            if (_instance == null)
                _instance = new GreetingCards();
            return _instance;
        }

        public bool IsEmpty() => cards.Count == 0;
        public void Add(GreetingCard card) => cards.Add(card);
        public List<GreetingCard> Filter<T>() where T : GreetingCard => !IsEmpty() ? cards.Where(card => card is T).ToList() as List<GreetingCard> : new List<GreetingCard>();
    }
}