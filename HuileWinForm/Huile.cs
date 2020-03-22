using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuileWinForm
{
    [Serializable]
    class Huile
    {
        private string nom;
        private int vf;
        private int vc;
        private double prix;
        private int stock;
        private string petrolier;

        public class HuileComparator : IComparer
        {
            public int Compare(object a, object b)
            {
                if (a == b) return 0;
                if (a == null) return 1;
                if (b == null) return -1;

                Huile h1 = a as Huile;
                Huile h2 = b as Huile;

                if (h1.Stock == h2.Stock) return 0;
                else if (h1.Stock < h2.Stock) return 1;
                else return -1;

                // return -string.Compare(h1.Stock.ToString(), h2.Stock.ToString());
            }
        }

        public Huile()
        {
            nom = "";
            vf = 0;
            vc = 0;
            prix = 0;
            stock = 0;
            petrolier = "";
        }

        public Huile(string nom, int vf, int vc, double prix, int stock, string petrolier)
        {
            this.nom = nom;
            this.vf = vf;
            this.vc = vc;
            this.prix = prix;
            this.stock = stock;
            this.petrolier = petrolier;
        }

        internal string Nom
        {
            get
            {
                return this.nom;
            }
            set
            {
                this.nom = value;
            }
        }

        internal int VF
        {
            get
            {
                return this.vf;
            }
            set
            {
                if (value == 0 || value == 5 || value == 10 || value == 15 || value == 20)
                {
                    this.vf = value;
                }
                else
                {
                    throw new Exception("Valeur incorrecte de la Viscocité à Froid");
                }
            }
        }

        internal int VC
        {
            get
            {
                return this.vc;
            }
            set
            {
                if (value == 30 || value == 40 || value == 50)
                {
                    this.vc = value;
                }
                else
                {
                    throw new Exception("Valeur incorrecte de la Viscocité à Chaud");
                }
            }
        }

        internal double Prix
        {
            get
            {
                return this.prix;
            }
            set
            {
                if (value >= 0)
                {
                    prix = value;
                }
                else
                {
                    throw new Exception("Prix ne doit pas etre négatif");
                }
            }
        }

        internal int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                if (value >= 0)
                {
                    stock = value;
                }
                else
                {
                    throw new Exception("Stock ne doit pas etre négatif");
                }
            }
        }

        internal string Petrolier
        {
            get
            {
                return petrolier;
            }
            set
            {
                petrolier = value;
            }
        }

        public override string ToString()
        {
            return "\tNom d'huile: " + nom + "\n" +
                   "\t\t|Pétrolier: " + petrolier + "\n" +
                   "\t\t|VF = " + vf + "\n" +
                   "\t\t|VC = " + vc + "\n" +
                   "\t\t|Prix = " + prix + "\n" +
                   "\t\t|Stock = " + stock + "\n";

        }

    }
}
