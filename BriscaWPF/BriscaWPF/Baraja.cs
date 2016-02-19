using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriscaWPF
{
    

    class Baraja
    {
        const string PALO_BASTOS = "Bastos";
        const string PALO_COPAS = "Copas";
        const string PALO_ESPADAS = "Espadas";
        const string PALO_OROS = "Oros";

        List<Carta> cartas = new List<Carta>();

        internal List<Carta> Cartas
        {
            get
            {
                return cartas;
            }

            set
            {
                cartas = value;
            }
        }

        public void InicializarCartas()
        {
            cartas = new List<Carta>();
            foreach (string palo in GetPalos())
            {
                for (int i = 1; i <= 12; i++)
                {
                    string path = @".\Images\"+palo + i+".gif";
                    path = Path.GetFullPath(path);
                    string pathBocaAbajo = @".\Images\0.png";
                    pathBocaAbajo = Path.GetFullPath(pathBocaAbajo);
                    int puntos = 0;
                    if (i == 1)
                        puntos = 11;
                    if (i == 3)
                        puntos = 10;
                    if (i == 10)
                        puntos = 2;
                    if (i == 11)
                        puntos = 3;
                    if (i == 12)
                        puntos = 4;

                    Carta c = new Carta(palo, i, puntos, path, pathBocaAbajo);
                    cartas.Add(c);
                }
            }
        }

        public List<string> GetPalos()
        {
            List<string> lst = new List<string>();
            lst.Add(PALO_BASTOS);
            lst.Add(PALO_ESPADAS);
            lst.Add(PALO_COPAS);
            lst.Add(PALO_OROS);
            return lst;
        }

        public void Embarajar()
        {
            Random r = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int a = r.Next(0, cartas.Count);
                int b = r.Next(0, cartas.Count);
                if (a != b)
                {
                    Carta aux = cartas[a];
                    cartas[a] = cartas[b];
                    cartas[b] = aux;
                }
            }
        }

        public bool HayCartas() { return cartas.Count > 0; }

        public Carta DameCarta() {
            Carta aux = cartas[0];
            cartas.RemoveAt(0);
            return aux;
        }


    }
}
