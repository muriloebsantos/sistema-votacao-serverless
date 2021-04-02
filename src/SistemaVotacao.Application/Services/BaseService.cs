namespace SistemaVotacao.Application.Services
{
    public abstract class BaseService
    {
        private readonly NotificationService _notificationService;

        protected BaseService(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public bool HasError => _notificationService?.Message != null;
        public string Error => _notificationService?.Message;
        public int StatusCode => _notificationService?.StatusCode ?? 0;

        public void AddError(int status, string message)
        {
            _notificationService.StatusCode = status;
            _notificationService.Message = message;
        }
    }
}
