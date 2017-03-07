using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Repository
{


    /// <summary>
    /// XuanTrang
    /// </summary>
    public interface ITriggerAfterChangeProduct
    {
        void SendProduct(Entities.ChangeInfo changeInfo,string typeChange);
    }
}
