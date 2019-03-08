using System;
using System.Collections.Generic;
using System.Text;

namespace SharedFitness.Interfaces
{
    public interface ICopyable
    {
		object Copy(object destination);
    }
}
