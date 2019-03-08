using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedFitness.Interfaces
{
    public interface IRequest
    {
		IRequestResponse RequestResponse { get; set; }
		Task<IRequestResponse> Run();
    }
}
