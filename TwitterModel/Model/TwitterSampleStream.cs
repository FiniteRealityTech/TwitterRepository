namespace TwitterModel.Model;
public class Attachments
{
}

public class Data
{
    public Attachments attachments { get; set; }
    public string author_id { get; set; }
    public string conversation_id { get; set; }
    public DateTime created_at { get; set; }
    public Entities entities { get; set; }
    public Geo geo { get; set; }
    public string id { get; set; }
    public string in_reply_to_user_id { get; set; }
    public string lang { get; set; }
    public bool possibly_sensitive { get; set; }
    public PublicMetrics public_metrics { get; set; }
    public List<ReferencedTweet> referenced_tweets { get; set; }
    public string source { get; set; }
    public string text { get; set; }
}

public class Description
{
    public List<Mention> mentions { get; set; }
}

public class Entities
{
    public List<Mention> mentions { get; set; }
    public Url url { get; set; }
    public Description description { get; set; }
    public List<Url> urls { get; set; }
}

public class Geo
{
}

public class Includes
{
    public List<User> users { get; set; }
    public List<Tweet> tweets { get; set; }
}

public class Mention
{
    public int start { get; set; }
    public int end { get; set; }
    public string username { get; set; }
    public string id { get; set; }
}

public class PublicMetrics
{
    public int retweet_count { get; set; }
    public int reply_count { get; set; }
    public int like_count { get; set; }
    public int quote_count { get; set; }
    public int followers_count { get; set; }
    public int following_count { get; set; }
    public int tweet_count { get; set; }
    public int listed_count { get; set; }
}

public class ReferencedTweet
{
    public string type { get; set; }
    public string id { get; set; }
}

public class TwitterSampleStream
{
    public Data data { get; set; }
    public Includes includes { get; set; }
}

public class Tweet
{
    public Attachments attachments { get; set; }
    public string author_id { get; set; }
    public string conversation_id { get; set; }
    public DateTime created_at { get; set; }
    public Entities entities { get; set; }
    public Geo geo { get; set; }
    public string id { get; set; }
    public string lang { get; set; }
    public bool possibly_sensitive { get; set; }
    public PublicMetrics public_metrics { get; set; }
    public List<ReferencedTweet> referenced_tweets { get; set; }
    public string source { get; set; }
    public string text { get; set; }
}

public class Url
{
    public List<Url> urls { get; set; }
}

public class Url2
{
    public int start { get; set; }
    public int end { get; set; }
    public string url { get; set; }
    public string expanded_url { get; set; }
    public string display_url { get; set; }
}

public class User
{
    public DateTime created_at { get; set; }
    public string description { get; set; }
    public Entities entities { get; set; }
    public string id { get; set; }
    public string location { get; set; }
    public string name { get; set; }
    public string profile_image_url { get; set; }
    public bool @protected { get; set; }
    public PublicMetrics public_metrics { get; set; }
    public string url { get; set; }
    public string username { get; set; }
    public bool verified { get; set; }
    public string pinned_tweet_id { get; set; }
}