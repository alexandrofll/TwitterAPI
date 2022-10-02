﻿using System.ComponentModel.DataAnnotations;

namespace TwitterAPI.Application.Models.APIModels
{
    /// <summary>
    /// It is used as api model for tweets
    /// </summary>
    public class TweetAPIModel
    {
        /// <summary>
        /// It gets or sets the tweet primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// It gets or sets the tweet title
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// It gets or sets the tweet date
        /// </summary>
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// It gets or sets the twitter hashtag
        /// </summary>
        [Required]
        public string Hashtag { get; set; }
    }
}
