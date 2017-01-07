﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InsaworldIHM.UnitView
{
    /// <summary>
    /// Logique d'interaction pour ViewUnitCentaurs.xaml
    /// </summary>

    partial class ViewUnitCentaurs : ViewUnit
    {
        Uri source;
        Uri sourceselected;
        SoundPlayer player;
        public ViewUnitCentaurs() : base()
        {
            source = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/centaur.png");
            sourceselected = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/centaurselected.jpg");
            Source = new BitmapImage(source);
            player = new SoundPlayer(InsaworldIHM.Properties.Resources.centaur);
        }
        override
        public void Select()
        {
            Source = new BitmapImage(sourceselected);
        }
        override
        public void Unselect()
        {
            Source = new BitmapImage(source);
        }

        public override void Play()
        {
            player.Play();
        }
    }
}



