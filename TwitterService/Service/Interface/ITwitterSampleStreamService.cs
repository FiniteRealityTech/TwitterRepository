namespace TwitterService.Service.Interface;

[ScopedService]
public interface ITwitterSampleStreamService
{
    Task StartTwitterSampleStreamAsync();
}