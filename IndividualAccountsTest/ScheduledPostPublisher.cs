using TheOutsiderPost.Domain.Enums;

namespace IndividualAccountsTest
{
    public class ScheduledPostPublisher : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ScheduledPostPublisher(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<Data.ApplicationDbContext>();

                var now = DateTimeOffset.UtcNow;

                //var posts = await dbContext.Posts
                //    .Where(p => p.Status == PostStatus.Approved &&
                //                p.ScheduledPublishAt != null &&
                //                p.ScheduledPublishAt <= now)
                //    .ToListAsync(stoppingToken);

                //foreach (var post in posts)
                //{
                //    post.Publish("SYSTEM");
                //}

                //await dbContext.SaveChangesAsync(stoppingToken);

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
