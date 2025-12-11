using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radfall.map
{
    class MapCollider
    {

        public static bool[,] colliderMap_1 = new bool[,]
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
};
        public static bool[,] colliderMap_2 = new bool[,]
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
        };
        public static bool[,] colliderMap_3 = new bool[,]
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
        };
        public static bool[,] colliderMap_4 = new bool[,]
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
        };
        public static bool[,] colliderMap_5 = new bool[,]
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
        };
        public static bool[,] colliderMap_6 = new bool[,]
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
        };
        public static bool[,] colliderMap_7 = new bool[,]
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
        };
        public static bool[,] colliderMap_8 = new bool[,]
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
        };
        public static bool[,] colliderMap_9 = new bool[,]
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
        };
    }
}
