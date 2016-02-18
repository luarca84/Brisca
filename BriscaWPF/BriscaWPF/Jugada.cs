using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriscaWPF
{
    enum Turno { Humano, Ordenador};

    public class Jugada : INotifyPropertyChanged
    {
        Carta cartaOrdenador = null;
        Carta cartaHumano = null;

        public Carta CartaOrdenador
        {
            get
            {
                return cartaOrdenador;
            }

            set
            {
                cartaOrdenador = value;
                RaisePropertyChanged("CartaOrdenador");
            }
        }

        public Carta CartaHumano
        {
            get
            {
                return cartaHumano;
            }

            set
            {
                cartaHumano = value;
                RaisePropertyChanged("CartaHumano");
            }
        }

        internal Turno EvaluarJugada(Turno turno, Carta palo)
        {
            RaisePropertyChanged("CartaHumano");
            RaisePropertyChanged("CartaOrdenador");


            if (turno == Turno.Humano)
            {
                if (cartaHumano.Palo == cartaOrdenador.Palo)
                {
                    if (CompararCartasMismoPalo(cartaHumano, cartaOrdenador))
                        return Turno.Humano;
                    else
                        return Turno.Ordenador;
                }
                else if (cartaHumano.Palo == palo.Palo)
                    return Turno.Humano;
                else if (cartaOrdenador.Palo == palo.Palo)
                    return Turno.Ordenador;
                else
                    return Turno.Humano;
            }
            else
            {
                if (cartaHumano.Palo == cartaOrdenador.Palo)
                {
                    if (CompararCartasMismoPalo(cartaHumano, cartaOrdenador))
                        return Turno.Humano;
                    else
                        return Turno.Ordenador;
                }
                else if (cartaHumano.Palo == palo.Palo)
                    return Turno.Humano;
                else if (cartaOrdenador.Palo == palo.Palo)
                    return Turno.Ordenador;
                else
                    return Turno.Ordenador;
            }

        }

        private bool CompararCartasMismoPalo(Carta cartaHumano, Carta cartaOrdenador)
        {
            //Devuelve True si la primera carta es mejor que la segunda
            if (cartaHumano.Puntos > cartaOrdenador.Puntos)
                return true;
            if(cartaHumano.Puntos == cartaOrdenador.Puntos)
            {
                if (cartaHumano.Num > cartaOrdenador.Num)
                    return true;
            }
            return false;

        }

        public List<Carta> RecogerCartas()
        {
            List<Carta> lst = new List<Carta>();
            lst.Add(CartaHumano);
            lst.Add(CartaOrdenador);
            CartaHumano = null;
            CartaOrdenador = null;
            RaisePropertyChanged("CartaHumano");
            RaisePropertyChanged("CartaOrdenador");
            return lst;
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
