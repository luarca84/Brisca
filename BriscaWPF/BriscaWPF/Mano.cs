using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriscaWPF
{
    public class Mano : INotifyPropertyChanged
    {
        List<Carta> lstCartas = new List<Carta>();

        public List<Carta> LstCartas
        {
            get
            {
                return lstCartas;
            }

            set
            {
                lstCartas = value;
                RaisePropertyChanged("LstCartas");
            }
        }

        public Carta PrimeraCarta
        {
            get
            {
                if (lstCartas.Count > 0)
                    return lstCartas[0];
                return null;
            }
        }

        public Carta SegundaCarta
        {
            get
            {
                if (lstCartas.Count > 1)
                    return lstCartas[1];
                return null;
            }
        }


        public Carta TerceraCarta
        {
            get
            {
                if (lstCartas.Count > 2)
                    return lstCartas[2];
                return null;
            }
        }

        public void RecibeCarta(Carta c)
        {
            LstCartas.Add(c);
            RaisePropertyChanged("PrimeraCarta");
            RaisePropertyChanged("SegundaCarta");
            RaisePropertyChanged("TerceraCarta");
        }

        public Carta TirarCartaOrdenador()
        {
            Random r = new Random();
            int index = r.Next(0, LstCartas.Count);
            Carta c = LstCartas[index];
            LstCartas.RemoveAt(index);
            RaisePropertyChanged("PrimeraCarta");
            RaisePropertyChanged("SegundaCarta");
            RaisePropertyChanged("TerceraCarta");
            return c;
        }

        public Carta TirarCartaHumano(int i)
        {
            Carta c = LstCartas[i];
            LstCartas.RemoveAt(i);
            RaisePropertyChanged("PrimeraCarta");
            RaisePropertyChanged("SegundaCarta");
            RaisePropertyChanged("TerceraCarta");
            return c;
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
