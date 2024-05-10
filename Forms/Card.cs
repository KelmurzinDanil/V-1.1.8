using DB_993.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace design
{
    /// <summary>
    /// Класс используется для отображения информации о недвижимости, включая адрес, площадь, цену и этаж.
    /// </summary>
    public partial class Card : Form
    {
        public Card()
        {
            InitializeComponent();
        }
        public Card(Realty realties)
        {
            InitializeComponent();
            AddressText.Text = realties.Address;
            SquareText.Text = realties.Square.ToString() + " м^2";
            PriceText.Text = realties.Price.ToString() + " руб";
            FloorText.Text = realties.Floor.ToString();
        }
    }
}
