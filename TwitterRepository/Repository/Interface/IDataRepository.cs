namespace TwitterRepository.Repository.Interface
{
    [ScopedService]
    public interface IDataRepository
    {
        Task<TwitterSampleStream> DequeueTwitterFeedMessageAsync();
        Task<string> GetTwitterApiTokenAsync();

        Task QueueTwitterFeedMessageAsync(string message);

        Task<TwitterStatModel> ReadTwitterStatsAsync();
        Task SaveTwitterStatsAsync(TwitterStatModel stats);
    }
}