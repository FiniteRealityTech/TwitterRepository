namespace TwitterModel.Model;

public class StatTracker
{
    public int Count { get; set; }
    public string Value { get; set; }

    public override string ToString()
    {
        return $"{Value} has a count of {Count}";
    }
}