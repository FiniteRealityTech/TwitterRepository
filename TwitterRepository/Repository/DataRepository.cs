namespace TwitterRepository.Repository
{
    public class DataRepository : IDataRepository
    {
        public Task<TwitterSampleStream> DequeueTwitterFeedMessageAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTwitterApiTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task QueueTwitterFeedMessageAsync(string message)
        {
            throw new NotImplementedException();
        }

        public Task<TwitterStatModel> ReadTwitterStatsAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveTwitterStatsAsync(TwitterStatModel stats)
        {
            throw new NotImplementedException();
        }
    }
}