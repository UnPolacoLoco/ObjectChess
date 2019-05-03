using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess
{
    public class Blank : Figure
    {
        public override string FigureSymbol { get; set; }
        public override Player Owner { get; set; }

        public override void Move(Figure figure, int targetX, int targetY)
        {
            throw new NotImplementedException();
        }

        public Blank()
        {
            FigureSymbol = " ";
            
        }
    }
}
