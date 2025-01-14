﻿using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Painter
    {
        static float x, y;
        static IGraphics graphic;

        public static void Initialization ( IGraphics newgraphic )
        {
            graphic = newgraphic;
            //grafika.SmoothingMode = SmoothingMode.None;
            graphic.Clear(Colors.Black);
        }

        public static void Set_position(float x0, float y0)
        {x = x0; y = y0;}

        public static void MakeIt(Pen pen, double length, double angle)
        {
        //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
        var x1 = (float)(x + length * Math.Cos(angle));
        var y1 = (float)(y + length * Math.Sin(angle));
        graphic.DrawLine(pen, x, y, x1, y1);
        x = x1;
        y = y1;
        }

        public static void Change(double lenght, double angle)
        {
            x = (float)(x + lenght * Math.Cos(angle)); 
           y = (float)(y + lenght * Math.Sin(angle));
           }
    }
    
    public class ImpossibleSquare
{
    public static void Draw(int shirina, int visota, double ugolPovorota, IGraphics grafika)
    {
        // ugolPovorota пока не используется, но будет использоваться в будущем
        Painter.Initialization(grafika);

        var sz = Math.Min(shirina, visota);

        var diagonal_length = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
        var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + shirina / 2f;
        var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + visota / 2f;

        Painter.Set_position(x0, y0);
        //Рисуем 1-ую сторону
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f, 0);
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI / 4);
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI);
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI / 2);

        Painter.Change(sz * 0.04f, -Math.PI);
        Painter.Change(sz * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);

        //Рисуем 2-ую сторону
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f, -Math.PI / 2);
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f, -Math.PI / 2 + Math.PI);
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, -Math.PI / 2 + Math.PI / 2);

        Painter.Change(sz * 0.04f, -Math.PI / 2 - Math.PI);
        Painter.Change(sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);

        //Рисуем 3-ю сторону
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI);
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI + Math.PI / 4);
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI + Math.PI);
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI + Math.PI / 2);

        Painter.Change(sz * 0.04f, Math.PI - Math.PI);
        Painter.Change(sz * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);

        //Рисуем 4-ую сторону
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI / 2);
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI / 2 + Math.PI);
        Painter.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI / 2 + Math.PI / 2);

        Painter.Change(sz * 0.04f, Math.PI / 2 - Math.PI);
        Painter.Change(sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
    }
}
}