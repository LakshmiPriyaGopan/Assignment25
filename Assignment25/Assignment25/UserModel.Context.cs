﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment25
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DemoEntities : DbContext
    {
        public DemoEntities()
            : base("name=DemoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblTweet> TblTweets { get; set; }
        public virtual DbSet<TblTweetuser> TblTweetusers { get; set; }
    
        public virtual int delete_tweet(Nullable<int> tweetId, Nullable<int> tweetUserId)
        {
            var tweetIdParameter = tweetId.HasValue ?
                new ObjectParameter("TweetId", tweetId) :
                new ObjectParameter("TweetId", typeof(int));
    
            var tweetUserIdParameter = tweetUserId.HasValue ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_tweet", tweetIdParameter, tweetUserIdParameter);
        }
    
        public virtual int delete_tweetuser(string userId)
        {
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_tweetuser", userIdParameter);
        }
    
        public virtual int follow_user(Nullable<int> userId, string followUserId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var followUserIdParameter = followUserId != null ?
                new ObjectParameter("FollowUserId", followUserId) :
                new ObjectParameter("FollowUserId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("follow_user", userIdParameter, followUserIdParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> insert_tweet(Nullable<int> tweetUserId, string tweetText)
        {
            var tweetUserIdParameter = tweetUserId.HasValue ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(int));
    
            var tweetTextParameter = tweetText != null ?
                new ObjectParameter("TweetText", tweetText) :
                new ObjectParameter("TweetText", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("insert_tweet", tweetUserIdParameter, tweetTextParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> insert_tweetuser(string userName, string password, string emailId, Nullable<System.DateTime> modifiedDate, Nullable<bool> deleted)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailIdParameter = emailId != null ?
                new ObjectParameter("EmailId", emailId) :
                new ObjectParameter("EmailId", typeof(string));
    
            var modifiedDateParameter = modifiedDate.HasValue ?
                new ObjectParameter("ModifiedDate", modifiedDate) :
                new ObjectParameter("ModifiedDate", typeof(System.DateTime));
    
            var deletedParameter = deleted.HasValue ?
                new ObjectParameter("Deleted", deleted) :
                new ObjectParameter("Deleted", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("insert_tweetuser", userNameParameter, passwordParameter, emailIdParameter, modifiedDateParameter, deletedParameter);
        }
    
        public virtual ObjectResult<select_follow_tweet_Result> select_follow_tweet(string tweetUserId)
        {
            var tweetUserIdParameter = tweetUserId != null ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<select_follow_tweet_Result>("select_follow_tweet", tweetUserIdParameter);
        }
    
        public virtual ObjectResult<select_self_tweet_Result> select_self_tweet(Nullable<int> tweetUserId)
        {
            var tweetUserIdParameter = tweetUserId.HasValue ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<select_self_tweet_Result>("select_self_tweet", tweetUserIdParameter);
        }
    
        public virtual ObjectResult<select_tweetuser_Result> select_tweetuser(string userName, Nullable<int> userId)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<select_tweetuser_Result>("select_tweetuser", userNameParameter, userIdParameter);
        }
    
        public virtual int update_tweetuser(string userId, string password, string emailId)
        {
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailIdParameter = emailId != null ?
                new ObjectParameter("EmailId", emailId) :
                new ObjectParameter("EmailId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_tweetuser", userIdParameter, passwordParameter, emailIdParameter);
        }
    
        public virtual ObjectResult<validate_tweetuser_Result> validate_tweetuser(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<validate_tweetuser_Result>("validate_tweetuser", usernameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<TblTweetuser> ValidateTweetUser(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweetuser>("ValidateTweetUser", usernameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<TblTweetuser> ValidateTweetUser(string username, string password, MergeOption mergeOption)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweetuser>("ValidateTweetUser", mergeOption, usernameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<TblTweet> DisplayTweets(string tweetUserId)
        {
            var tweetUserIdParameter = tweetUserId != null ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweet>("DisplayTweets", tweetUserIdParameter);
        }
    
        public virtual ObjectResult<TblTweet> DisplayTweets(string tweetUserId, MergeOption mergeOption)
        {
            var tweetUserIdParameter = tweetUserId != null ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweet>("DisplayTweets", mergeOption, tweetUserIdParameter);
        }
    
        public virtual ObjectResult<TblTweetuser> SearchUsers(string userName, Nullable<int> userId)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweetuser>("SearchUsers", userNameParameter, userIdParameter);
        }
    
        public virtual ObjectResult<TblTweetuser> SearchUsers(string userName, Nullable<int> userId, MergeOption mergeOption)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweetuser>("SearchUsers", mergeOption, userNameParameter, userIdParameter);
        }
    
        public virtual ObjectResult<select_tweetuserbyuserid_Result> select_tweetuserbyuserid(string userid)
        {
            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<select_tweetuserbyuserid_Result>("select_tweetuserbyuserid", useridParameter);
        }
    
        public virtual ObjectResult<TblTweetuser> GetUserByUserId(string userid)
        {
            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweetuser>("GetUserByUserId", useridParameter);
        }
    
        public virtual ObjectResult<TblTweetuser> GetUserByUserId(string userid, MergeOption mergeOption)
        {
            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweetuser>("GetUserByUserId", mergeOption, useridParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> FollowUser(Nullable<int> userId, string followUserId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var followUserIdParameter = followUserId != null ?
                new ObjectParameter("FollowUserId", followUserId) :
                new ObjectParameter("FollowUserId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("FollowUser", userIdParameter, followUserIdParameter);
        }
    
        public virtual ObjectResult<TblTweet> DisplaySelfTweets(Nullable<int> tweetUserId)
        {
            var tweetUserIdParameter = tweetUserId.HasValue ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweet>("DisplaySelfTweets", tweetUserIdParameter);
        }
    
        public virtual ObjectResult<TblTweet> DisplaySelfTweets(Nullable<int> tweetUserId, MergeOption mergeOption)
        {
            var tweetUserIdParameter = tweetUserId.HasValue ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweet>("DisplaySelfTweets", mergeOption, tweetUserIdParameter);
        }
    
        public virtual ObjectResult<TblTweet> DeleteTweet(Nullable<int> tweetId, Nullable<int> tweetUserId)
        {
            var tweetIdParameter = tweetId.HasValue ?
                new ObjectParameter("TweetId", tweetId) :
                new ObjectParameter("TweetId", typeof(int));
    
            var tweetUserIdParameter = tweetUserId.HasValue ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweet>("DeleteTweet", tweetIdParameter, tweetUserIdParameter);
        }
    
        public virtual ObjectResult<TblTweet> DeleteTweet(Nullable<int> tweetId, Nullable<int> tweetUserId, MergeOption mergeOption)
        {
            var tweetIdParameter = tweetId.HasValue ?
                new ObjectParameter("TweetId", tweetId) :
                new ObjectParameter("TweetId", typeof(int));
    
            var tweetUserIdParameter = tweetUserId.HasValue ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweet>("DeleteTweet", mergeOption, tweetIdParameter, tweetUserIdParameter);
        }
    
        public virtual ObjectResult<TblTweet> AddTweet(Nullable<int> tweetUserId, string tweetText)
        {
            var tweetUserIdParameter = tweetUserId.HasValue ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(int));
    
            var tweetTextParameter = tweetText != null ?
                new ObjectParameter("TweetText", tweetText) :
                new ObjectParameter("TweetText", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweet>("AddTweet", tweetUserIdParameter, tweetTextParameter);
        }
    
        public virtual ObjectResult<TblTweet> AddTweet(Nullable<int> tweetUserId, string tweetText, MergeOption mergeOption)
        {
            var tweetUserIdParameter = tweetUserId.HasValue ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(int));
    
            var tweetTextParameter = tweetText != null ?
                new ObjectParameter("TweetText", tweetText) :
                new ObjectParameter("TweetText", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweet>("AddTweet", mergeOption, tweetUserIdParameter, tweetTextParameter);
        }
    
        public virtual ObjectResult<TblTweet> UpdateTweet(string tweetText, Nullable<int> tweetId, Nullable<int> tweetUserId)
        {
            var tweetTextParameter = tweetText != null ?
                new ObjectParameter("TweetText", tweetText) :
                new ObjectParameter("TweetText", typeof(string));
    
            var tweetIdParameter = tweetId.HasValue ?
                new ObjectParameter("TweetId", tweetId) :
                new ObjectParameter("TweetId", typeof(int));
    
            var tweetUserIdParameter = tweetUserId.HasValue ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweet>("UpdateTweet", tweetTextParameter, tweetIdParameter, tweetUserIdParameter);
        }
    
        public virtual ObjectResult<TblTweet> UpdateTweet(string tweetText, Nullable<int> tweetId, Nullable<int> tweetUserId, MergeOption mergeOption)
        {
            var tweetTextParameter = tweetText != null ?
                new ObjectParameter("TweetText", tweetText) :
                new ObjectParameter("TweetText", typeof(string));
    
            var tweetIdParameter = tweetId.HasValue ?
                new ObjectParameter("TweetId", tweetId) :
                new ObjectParameter("TweetId", typeof(int));
    
            var tweetUserIdParameter = tweetUserId.HasValue ?
                new ObjectParameter("TweetUserId", tweetUserId) :
                new ObjectParameter("TweetUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweet>("UpdateTweet", mergeOption, tweetTextParameter, tweetIdParameter, tweetUserIdParameter);
        }
    
        public virtual ObjectResult<TblTweetuser> UpdateUser(string userId, string password, string emailId)
        {
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailIdParameter = emailId != null ?
                new ObjectParameter("EmailId", emailId) :
                new ObjectParameter("EmailId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweetuser>("UpdateUser", userIdParameter, passwordParameter, emailIdParameter);
        }
    
        public virtual ObjectResult<TblTweetuser> UpdateUser(string userId, string password, string emailId, MergeOption mergeOption)
        {
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailIdParameter = emailId != null ?
                new ObjectParameter("EmailId", emailId) :
                new ObjectParameter("EmailId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweetuser>("UpdateUser", mergeOption, userIdParameter, passwordParameter, emailIdParameter);
        }
    
        public virtual ObjectResult<select_self_tweet_byTweetId_Result> select_self_tweet_byTweetId(Nullable<int> tweetId)
        {
            var tweetIdParameter = tweetId.HasValue ?
                new ObjectParameter("TweetId", tweetId) :
                new ObjectParameter("TweetId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<select_self_tweet_byTweetId_Result>("select_self_tweet_byTweetId", tweetIdParameter);
        }
    
        public virtual ObjectResult<TblTweet> DisplaySelfTweetByTweetId(Nullable<int> tweetId)
        {
            var tweetIdParameter = tweetId.HasValue ?
                new ObjectParameter("TweetId", tweetId) :
                new ObjectParameter("TweetId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweet>("DisplaySelfTweetByTweetId", tweetIdParameter);
        }
    
        public virtual ObjectResult<TblTweet> DisplaySelfTweetByTweetId(Nullable<int> tweetId, MergeOption mergeOption)
        {
            var tweetIdParameter = tweetId.HasValue ?
                new ObjectParameter("TweetId", tweetId) :
                new ObjectParameter("TweetId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TblTweet>("DisplaySelfTweetByTweetId", mergeOption, tweetIdParameter);
        }
    }
}
