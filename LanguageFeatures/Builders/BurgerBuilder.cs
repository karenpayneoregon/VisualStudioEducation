using LanguageFeatures.Classes;

namespace LanguageFeatures.Builders
{
    public class BurgerBuilder
    {
        public int Size { get; }

        private bool _mCheese;
        public bool Cheese
        {
            get => _mCheese;
            private set => _mCheese = value;
        }
        private bool _mPepperoni;
        public bool Pepperoni
        {
            get => _mPepperoni;
            private set => _mPepperoni = value;
        }
        private bool _mLettuce;
        public bool Lettuce
        {
            get => _mLettuce;
            private set => _mLettuce = value;
        }
        private bool _mTomato;
        public bool Tomato
        {
            get => _mTomato;
            private set => _mTomato = value;
        }

        public BurgerBuilder(int size) => Size = size;

        public BurgerBuilder AddPepperoni()
        {
            Pepperoni = true;
            return this;
        }

        public BurgerBuilder AddLettuce()
        {
            Lettuce = true;
            return this;
        }

        public BurgerBuilder AddCheese()
        {
            Cheese = true;
            return this;
        }

        public BurgerBuilder AddTomato()
        {
            Tomato = true;
            return this;
        }

        public Burger Build()
        {
            return new Burger(this);
        }
    }
}