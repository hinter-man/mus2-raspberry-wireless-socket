using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeApp.Client.Models
{
    public class IntertechnoWirelessSocket : BaseSocket
    {

        public override string Protocol { get; } = "intertechno_old";
        /// <summary>
        /// 0 - 3 corresponds to A - D on the wireless socket home code
        /// 0 = A
        /// 1 = B
        /// 2 = C
        /// 3 = D
        /// </summary>
        public override int Unit { get; set; }

        /// <summary>
        /// 0-3 corresponds to 1 - 4 on the wireless socket home code
        /// </summary>}
        public override int Id { get; set; }
    }
}
