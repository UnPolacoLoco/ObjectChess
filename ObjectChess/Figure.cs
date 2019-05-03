using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess
{
    public abstract class Figure
    {
        public abstract string FigureSymbol { get; set; }
        public abstract void Move(Figure figure, int targetX, int targetY);
        public abstract Player Owner { get; set; }
        
    }
}
