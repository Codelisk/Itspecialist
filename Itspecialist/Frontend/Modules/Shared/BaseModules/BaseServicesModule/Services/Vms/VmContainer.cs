using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace BaseServicesModule.Services.Vms
{
    public class VmContainer
    {
        public IDisposable DestroyWith { get; set; }
    }
}
