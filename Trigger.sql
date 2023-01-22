--Create Trigger AddBlogInRatingTable
--on Blogs
--After Insert
--As
--Declare @ID int
--Select @ID=BlogId from inserted
--Insert into BlogRatings(BlogID,BlogRatingCount,BlogTotalScore)
--Values (@ID,0,0)


--Create Trigger AddScoreInComment
--on Comments
--After Insert
--As
--Declare @ID int
--Declare @Score int
--Declare @RatingCount int
--Select @ID=BlogId,@Score=BlogScore from inserted
--Update BlogRatings set BlogTotalScore=BlogTotalScore+@Score,BlogRatingCount+=1
--where BlogId=@ID

