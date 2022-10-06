using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAPI.Domain.Model
{
    public class TweetHashtag
    {
        /// <summary>
        /// It gets or sets the hashtag primary key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// It gets or set the tweet hashtags
        /// </summary>
        public string? Hashtag { get; set; }

        /// <summary>
        /// It gets or set the foreing key
        /// of the parent TweetId
        /// </summary>
        public int TweetId { get; set; }
    }
}
