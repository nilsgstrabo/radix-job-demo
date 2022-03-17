
using frontend.Controllers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
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
        Task TimeChanged(string time);

    }

    public class NotificationHub : Hub<INotificationHubClient>
    {
        private readonly ILogger _logger;
        protected NotificationHub(ILogger<NotificationHub> logger):base() {
            _logger=logger;
        }

        public override Task OnConnectedAsync() {
            _logger.LogInformation(0,"Connection to hub established");
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception) {
            _logger.LogWarning(exception, exception.Message);
            return Task.CompletedTask;
        }
 
    }

    public interface INotificationHubService
    {
        Task NotifyImageChanged(ImageChanged image);
        Task NotifyTimeChanged(string time);
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

        public Task NotifyTimeChanged(string time)
        {
            return _hub.Clients.All.TimeChanged(time);
        }
    }
}
