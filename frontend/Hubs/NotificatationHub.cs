
using frontend.Controllers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFP.Web.Hubs
{

    public class ImageChanged
    {
        public int ImageId { get; set; }
        public MandelbrotCoord Top { get; set; }
        public MandelbrotCoord Bottom { get; set; }
    }


    public interface INotificationHubClient
    {
        Task ImageChanged(ImageChanged image);

    }

    public class NotificationHub : Hub<INotificationHubClient>
    {

    }

    public interface INotificationHubService
    {
        Task NotifyImageChanged(ImageChanged image);
    }

    public class NotificationHubService : INotificationHubService
    {
        private readonly IHubContext<NotificationHub, INotificationHubClient> _hub;

        public NotificationHubService(IHubContext<NotificationHub, INotificationHubClient> hub)
        {
            _hub = hub;
        }

        public Task NotifyImageChanged(ImageChanged image)
        {
            return _hub.Clients.All.ImageChanged(image);
        }
    }
}