﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriscaWPF
{
    public class Carta : INotifyPropertyChanged
    {
        string palo;
        int num;
        int puntos;
        string path;
        string pathBocaAbajo;

        public Carta(string palo, int num, int puntos, string path, string pathBocaAbajo)
        {
            this.palo = palo;
            this.num = num;
            this.puntos = puntos;
            this.path = path;
            this.pathBocaAbajo = pathBocaAbajo;
        }

        public string Palo
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

        public int Num
        {
            get
            {
                return num;
            }

            set
            {
                num = value;
                RaisePropertyChanged("Num");
            }
        }

        public int Puntos
        {
            get
            {
                return puntos;
            }

            set
            {
                puntos = value;
                RaisePropertyChanged("Puntos");
            }
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
                RaisePropertyChanged("Path");
            }
        }

        public string PathBocaAbajo
        {
            get
            {
                return pathBocaAbajo;
            }

            set
            {
                pathBocaAbajo = value;
                RaisePropertyChanged("PathBocaAbajo");
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
