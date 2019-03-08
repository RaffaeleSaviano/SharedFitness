using System;
using System.Collections.Generic;
using System.Text;

namespace SharedFitness.test
{
    class Generics<T>
    {
        T Obj { get; set; }
        public Generics(T obj)
        {
            Obj = obj;
        }

        T GetT()
        {
            return Obj;
        }
    }
}
