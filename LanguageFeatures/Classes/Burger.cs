using LanguageFeatures.Builders;

namespace LanguageFeatures.Classes
{
    public class Burger
    {
        public int Size { get; }
        public bool Cheese { get; }
        public bool Pepperoni { get; }
        public bool Lettuce { get; }
        public bool Tomato { get; }

        public Burger(BurgerBuilder builder)
        {
            Size = builder.Size;
            Cheese = builder.Cheese;
            Pepperoni = builder.Pepperoni;
            Lettuce = builder.Lettuce;
            Tomato = builder.Tomato;
        }
    }
}
