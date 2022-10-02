--INSERT INTO TweetAggregatedStatistics (NumberOfTweets, UpToDate, AggregationGuid)
--SELECT COUNT(*), GETUTCDATE(), '54f67567-a90b-4e68-a66e-52e8d3c628c5' FROM Tweets
SELECT * FROM TweetAggregatedStatistics
---DELETE FROM TweetAggregatedStatistics

--INSERT INTO TweetHashtagsAggregatedStatistics (Hashtag, HashtagCount, TweetAggregatedStatisticId)
--SELECT TOP 10 Hashtag, COUNT(Hashtag) AS HashtagCount, 1 FROM Tweets GROUP BY Hashtag ORDER BY HashtagCount DESC 
SELECT * FROM TweetHashtagsAggregatedStatistics
