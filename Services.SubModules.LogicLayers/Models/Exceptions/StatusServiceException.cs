using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Exceptions
{
    public enum StatusServiceException
    {
        Unknown = 0,

        Functional = 1000000,

        Identity = 2000000,
        UserExistsByLogin,
        UserExistsByEmail,
        AuthorizationFailed,

        Mailer = 3000000,

        Notifications = 4000000,

        Telegram = 5000000,

        Logger = 6000000,

        Metrics = 7000000,

        Storage = 8000000
    }
}
