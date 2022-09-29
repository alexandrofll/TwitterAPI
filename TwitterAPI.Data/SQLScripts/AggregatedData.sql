SELECT TOP 10 Hashtag, COUNT(Hashtag) AS HashtagCount FROM Tweets GROUP BY Hashtag ORDER BY HashtagCount DESC 
