using System;
using System.Collections.Generic;
using System.Text;

namespace Superi.Features
{
    public class Country
    {
        private int id = int.MinValue;
        private string name = "";
        private int nameTextId = int.MinValue;
        private string isoCode2 = "";
        private string isoCode3 = "";

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NameTextId
        {
            get { return nameTextId; }
            set { nameTextId = value; }
        }

        public string IsoCode2
        {
            get { return isoCode2; }
            set { isoCode2 = value; }
        }

        public string IsoCode3
        {
            get { return isoCode3; }
            set { isoCode3 = value; }
        }
    }
}
