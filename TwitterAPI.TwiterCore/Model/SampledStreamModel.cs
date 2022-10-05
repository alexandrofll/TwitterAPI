using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAPI.TwiterCore.Model
{
    public class SampleStreamModel
    {
        public DataModel? data { get; set; }
    }

    public class ReferencedTweetModel
    {
        public string? type { get; set; }
        public string? id { get; set; }
    }

    public class UrlModel
    {
        public int start { get; set; }
        public int end { get; set; }
        public string? url { get; set; }
        public string? expanded_url { get; set; }
        public string? display_url { get; set; }
        public int status { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class AnnotationModel
    {
        public int start { get; set; }
        public int end { get; set; }
        public double probability { get; set; }
        public string? type { get; set; }
        public string? normalized_text { get; set; }
    }

    public class EntitiesModel
    {
        public List<UrlModel> urls { get; set; } = new List<UrlModel>();
        public List<AnnotationModel> annotations { get; set; } = new List<AnnotationModel>();
        public List<HashtagModel> hashtags { get; set; } = new List<HashtagModel>();
    }

    public class HashtagModel
    {
        public int start { get; set; }
        public int end { get; set; }
        public string tag { get; set; }
    }

    public class StatsModel
    {
        public int retweet_count { get; set; }
        public int reply_count { get; set; }
        public int like_count { get; set; }
        public int quote_count { get; set; }
    }

    public class DomainModel
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }

    public class EntityModel
    {
        public object? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }

    public class ContextAnnotationModel
    {
        public DomainModel? domain { get; set; }
        public EntityModel? entity { get; set; }
    }

    public class DataModel
    {
        public string? id { get; set; }
        public DateTime created_at { get; set; }
        public string? text { get; set; }
        public string? author_id { get; set; }
        public string? in_reply_to_user_id { get; set; }
        public List<ReferencedTweetModel> referenced_tweets { get; set; } = new List<ReferencedTweetModel>();
        public EntitiesModel? entities { get; set; }
        public StatsModel? stats { get; set; }
        public bool possibly_sensitive { get; set; }
        public string? lang { get; set; }
        public string? source { get; set; }
        public List<ContextAnnotationModel> context_annotations { get; set; } = new List<ContextAnnotationModel>();
        public string? format { get; set; }
    }
}
