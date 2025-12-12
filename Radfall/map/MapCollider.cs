using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radfall.map
{
    /// <summary>
    /// Class pour stocker les collisions dans un fichier a part
    /// </summary>
    class MapCollider
    {

        // Je veux un tableau de tableau 2d pas un tableau 3d
        public static bool[][,] MapColliders = new bool[][,]
{
new bool[,]
{
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, true, true, true, true, true, true, true},
  {false, false, true, true, false, false, false, false, false, false},
  {false, false, true, false, false, false, false, false, false, false},
  {false, false, true, false, false, false, false, false, false, false},
  {false, false, true, false, false, false, false, false, false, false},
  {false, false, true, false, false, false, false, false, false, false},
  {false, false, true, false, false, false, false, false, false, false},
  {false, false, true, false, false, false, false, false, false, false},
  {false, false, true, false, false, false, false, false, false, false}
},
new bool[,]
{
  {false, false, false, false, false, false, false, false, false, false},
  {true, true, true, true, true, true, true, true, true, true},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false}
},
new bool[,]
{
  {false, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false}
},
new bool[,]
{
  {false, false, true, false, false, false, false, false, false, false},
  {false, false, true, false, false, false, false, false, false, false},
  {false, false, true, false, false, false, false, false, false, false},
  {false, false, true, false, false, false, false, false, false, false},
  {false, false, true, true, false, false, false, false, false, false},
  {false, false, false, true, false, false, false, false, false, false},
  {false, false, false, true, false, false, false, false, false, false},
  {false, false, false, true, false, false, false, false, false, false},
  {false, false, false, true, false, false, false, false, false, false},
  {false, false, false, true, true, true, true, true, true, false}
},
new bool[,]
{
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, true, true, true, true, true, true, true, true, true}
},
new bool[,]
{
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, true, true, true, true, true, true, true, true, true},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {true, true, true, true, true, true, true, true, true, true}
},
new bool[,]
{
  {false, false, false, false, false, false, false, true, true, false},
  {false, false, false, false, false, false, false, true, false, false},
  {false, false, false, false, false, false, false, true, false, false},
  {false, false, true, true, true, true, true, true, false, false},
  {false, false, true, false, false, false, false, false, false, false},
  {false, false, true, false, false, false, false, false, false, false},
  {false, false, true, false, false, false, false, false, false, true},
  {false, false, true, true, true, true, true, true, true, true},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false}
},
new bool[,]
{
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, true, true, false, false, false, false, false, false, false},
  {true, true, true, true, true, true, true, true, true, true},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, true},
  {true, true, true, true, true, true, true, true, true, true},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false}
},
new bool[,]
{
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, false, false, false, false, false, false, false, false, false},
  {true, true, true, true, true, true, true, true, true, true},
  {false, false, false, false, false, false, false, false, false, true},
  {false, false, false, false, false, false, false, false, false, true},
  {false, false, false, false, false, false, false, false, false, true},
  {true, true, true, true, true, true, true, true, true, true},
  {false, false, false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false, false, false}
}
};

    }
}
