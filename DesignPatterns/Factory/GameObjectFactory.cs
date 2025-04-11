using DesignPatterns.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public abstract class GameObjectFactory
    {
        public abstract GameObject Create();
    }
}
