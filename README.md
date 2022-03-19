### GameTweet
#### Introduction
#### GameTweet is a social media platform moccing user with tweets, comments and replies.

### Getting Started
##### Fetch solution to local visual studio repo
##### download all dependency packages and build the application
##### In VS Package Manager Console run command "update-database" to add the DB to local sql server

##### db exported as data-tier application in folder DB

#### Packages Used
#### Domain Layer
###### Microsoft.EntityFrameworkCore.Relational
###### Microsoft.EntityFrameworkCore

#### GameTweet Layer (App Layer)
###### Microsoft.EntityFrameworkCore (v 50.15)
###### Microsoft.EntityFrameworkCore.Design (v 50.15)
###### Microsoft.EntityFrameworkCore.SqlServer (v 50.15)
###### Microsoft.EntityFrameworkCore.Tools (v 50.15)
###### Microsoft.AspNetCore.Mvc.NewtonsoftJson (v 50.15)

#### GameTweet Layer (App Layer)
###### NewtonsoftJson (v 5.0.15)
###### MongoDB.Driver (v 2.15.0)
###### NSwag.ASPNetCore(v 13.15.10)
###### AutoMapper (V 11.0.0)

#### Repository Layer
###### Microsoft.AspNetCore.Mvc.Formatters.Json

##### Service Layer
###### Microsoft.AspNetCore.Mvc.Formatters.Json
###### AutoMapper.Extensions.Microsoft.DependencyInjection


### API references
###### GetAllTweet
###### Verb 		 [HttpGet]
###### Input [_userId]   optional string represent UserId
###### Output [userTweets]	 list of user’s tweets along with related comments on the tweet,fl

#### AddTweet
###### Verb		 [HtpPost]
###### Input [tweet]	 tweet that will be added
###### Output [JsonResult]	 Feedback message represent request status.
###### Acceptance criteria
###### User can post maximum 140 characters per tweet.
###### Single tweet can receive multiple comments.

#### AddComment
###### Verb		 [HtpPost]
###### Input [Commment]	 comment that will be added to specific tweet In case that have a comment Id it will be considered as a reply.
###### Output [JsonResult]	 Feedback message represent request status. 
###### Acceptance criteria
###### Comment could receive multiple replies.
###### Total replies field indicate the comment if have any replies or not, so if it has any replies it can be shown in the UI to load its replies.



### contribute
##### Pagination response.
##### Use loggers libraries ex. Serilog.
##### Generic methods classes to avoid repeated functions.
##### Indexing DB.
##### Integration & Unit testing
