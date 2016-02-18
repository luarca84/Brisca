using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BriscaWPF
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        Carta palo = null;
        Mano manoOrdenador = null;
        Mano manoHumano = null;
        Jugada jugada = null;
        Turno turno = Turno.Humano;
        List<Carta> cartasGanadasHumano = new List<Carta>();
        List<Carta> cartasGanadasOrdenador = new List<Carta>();
        Baraja baraja = new Baraja();

        public ViewModelBase()
        {
            baraja = new Baraja();
            baraja.InicializarCartas();
            baraja.Embarajar();

            palo = baraja.DameCarta();

            ManoOrdenador = new Mano();
            ManoOrdenador.RecibeCarta(baraja.DameCarta());
            ManoOrdenador.RecibeCarta(baraja.DameCarta());
            ManoOrdenador.RecibeCarta(baraja.DameCarta());

            ManoHumano = new Mano();
            ManoHumano.RecibeCarta(baraja.DameCarta());
            ManoHumano.RecibeCarta(baraja.DameCarta());
            ManoHumano.RecibeCarta(baraja.DameCarta());

            turno = Turno.Humano;

            cartasGanadasHumano = new List<Carta>();
            cartasGanadasOrdenador = new List<Carta>();
        }

        internal void SeleccionarCarta(int v)
        {
            if (turno == Turno.Humano)
            {
                Jugada = new Jugada();
                Jugada.CartaHumano = manoHumano.TirarCartaHumano(v);
                Jugada.CartaOrdenador = ManoOrdenador.TirarCartaOrdenador();
            }
            else
            {
                Jugada.CartaHumano = manoHumano.TirarCartaHumano(v);
            }
            turno = Jugada.EvaluarJugada(turno, palo);
            if (turno == Turno.Humano)
            {
                MessageBox.Show("Ganaste");
                cartasGanadasHumano.AddRange(Jugada.RecogerCartas());
            }
            else
            {
                MessageBox.Show("Perdiste");
                cartasGanadasOrdenador.AddRange(Jugada.RecogerCartas());
            }

            if (baraja.HayCartas())
            {
                if (turno == Turno.Humano)
                {
                    ManoHumano.RecibeCarta(baraja.DameCarta());
                    if (baraja.HayCartas())
                        ManoOrdenador.RecibeCarta(baraja.DameCarta());
                    else
                        ManoOrdenador.RecibeCarta(Palo);
                }
                else
                {
                    ManoOrdenador.RecibeCarta(baraja.DameCarta());
                    if (baraja.HayCartas())
                        ManoHumano.RecibeCarta(baraja.DameCarta());
                    else
                        ManoHumano.RecibeCarta(Palo);

                    Jugada = new Jugada();
                    Jugada.CartaOrdenador = ManoOrdenador.TirarCartaOrdenador();
                }
            }

            if (!baraja.HayCartas()  && manoHumano.LstCartas.Count ==0 && ManoOrdenador.LstCartas.Count ==0)
            {
                //Fin
                int puntosOrdenador = ContarPuntosCartasGanadas(cartasGanadasOrdenador);
                int puntosHumano = ContarPuntosCartasGanadas(cartasGanadasHumano);

                if (puntosHumano == puntosOrdenador)
                    MessageBox.Show("Hay empate a " + puntosOrdenador + " puntos");
                else if (puntosHumano > puntosOrdenador)
                    MessageBox.Show("Ganaste " + puntosHumano + "-" + puntosOrdenador);
                else
                    MessageBox.Show("Perdiste " + puntosHumano + "-" + puntosOrdenador);
            }
        }

        private int ContarPuntosCartasGanadas(List<Carta> cartasGanadas)
        {
            int total = 0;
            foreach (Carta c in cartasGanadas)
                total += c.Puntos;
            return total;
        }

        public Carta Palo
        {
            get
            {
                return palo;
            }

            set
            {
                palo = value;
                RaisePropertyChanged("Palo");
            }
        }

        public Mano ManoOrdenador
        {
            get
            {
                return manoOrdenador;
            }

            set
            {
                manoOrdenador = value;
                RaisePropertyChanged("ManoOrdenador");
            }
        }

        public Mano ManoHumano
        {
            get
            {
                return manoHumano;
            }

            set
            {
                manoHumano = value;
                RaisePropertyChanged("ManoHumano");
            }
        }

        public Jugada Jugada
        {
            get
            {
                return jugada;
            }

            set
            {
                jugada = value;
                RaisePropertyChanged("Jugada");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            var handlers = PropertyChanged;
            if (handlers != null)
            {
                var args = new PropertyChangedEventArgs(property);
                handlers(this, args);
            }
        }
    }
}
