using System.Collections.Generic;

namespace FreeRoamProject.Shared.Core.Character
{
    public class DressingShared
    {
        public class Suit : Dressing
        {
            public int Price { get; set; }

            public Suit() : base() { }
            public Suit(string name, string desc, int price, ComponentDrawables componentDrawables, ComponentDrawables componentTextures, PropIndices propIndices, PropIndices propTextures) :
                base(name, desc, componentDrawables, componentTextures, propIndices, propTextures)
            {
                Price = price;
            }
        }


        public class Single
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public int Model { get; set; }
            public int Price { get; set; }
            public List<int> Text { get; set; } = new List<int>();
        }


        public class Accessories
        {
            public List<Single> Bags { get; set; } = new List<Single>();
            public Head Head { get; set; } = new Head();
            public List<Single> Watches { get; set; } = new List<Single>();
            public List<Single> Bracelets { get; set; } = new List<Single>();
        }

        public class Head
        {
            public List<Single> Earpieces { get; set; } = new List<Single>();
            public List<Single> Earphones { get; set; } = new List<Single>();
            public List<Single> Hats { get; set; } = new List<Single>();
        }
    }
}
