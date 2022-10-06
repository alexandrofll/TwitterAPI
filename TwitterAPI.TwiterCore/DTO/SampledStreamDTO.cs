using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAPI.TwiterCore.DTO
{
    public class SampleStreamDTO
    {
        public DataDTO? data { get; set; }
        public string? rawData { get; set; }
    }

    public class ReferencedTweetDTO
    {
        public string? type { get; set; }
        public string? id { get; set; }
    }

    public class UrlDTO
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

    public class AnnotationDTO
    {
        public int start { get; set; }
        public int end { get; set; }
        public double probability { get; set; }
        public string? type { get; set; }
        public string? normalized_text { get; set; }
    }

    public class EntitiesDTO
    {
        public List<UrlDTO> urls { get; set; } = new List<UrlDTO>();
        public List<AnnotationDTO> annotations { get; set; } = new List<AnnotationDTO>();
        public List<HashtagDTO> hashtags { get; set; } = new List<HashtagDTO>();
    }

    public class HashtagDTO
    {
        public int start { get; set; }
        public int end { get; set; }
        public string tag { get; set; }
    }

    public class StatsDTO
    {
        public int retweet_count { get; set; }
        public int reply_count { get; set; }
        public int like_count { get; set; }
        public int quote_count { get; set; }
    }

    public class DomainDTO
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }

    public class EntityDTO
    {
        public object? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }

    public class ContextAnnotationDTO
    {
        public DomainDTO? domain { get; set; }
        public EntityDTO? entity { get; set; }
    }

    public class DataDTO
    {
        public string? id { get; set; }
        public DateTime created_at { get; set; }
        public string? text { get; set; }
        public string? author_id { get; set; }
        public string? in_reply_to_user_id { get; set; }
        public List<ReferencedTweetDTO> referenced_tweets { get; set; } = new List<ReferencedTweetDTO>();
        public EntitiesDTO? entities { get; set; }
        public StatsDTO? stats { get; set; }
        public bool possibly_sensitive { get; set; }
        public string? lang { get; set; }
        public string? source { get; set; }
        public List<ContextAnnotationDTO> context_annotations { get; set; } = new List<ContextAnnotationDTO>();
        public string? format { get; set; }
    }
}
