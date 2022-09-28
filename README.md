# TwitterAPI

This TwitterAPI solution for self-education/training is a Proof of Concept of how to combine different .NET technologies (Azure, .NET 6, Worker Service, API, Event Bus, Web App, SQL Database...) for processing transactions concurrently within a high-volume transaction environment.

It is also meant to illustrate how to follow good development patterns such as:
Markup : *-SOLID
			*Single-Responsibility Principle
			*Open-Closed Principle
			*Liskov Substitution Principle
			*Interface Segregation Principle
			*Dependency Inversion Principle
		*-Use of patterns that could scale applications and are loosely coupled to external systems
		*-Good use of error handling, logging, and unit testing

The solution uses the Twitter API which provides a sampled stream endpoint that delivers a roughly 1% random sample of publicly available Tweets in real-time.
The Twitter API v2 sampled stream endpoint provides a random sample of approximately 1% of the full tweet stream. This solution consumes the sample stream and keep track of the following:  
• Total number of tweets received  
• Top 10 Hashtags 

Below you can see a High-Level Architecture diagram for the solution.

![My Image](TwitterAPIDiagram.png)
