using Assignment25.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Assignment25.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(TblTweetuser user)
        {
            DemoEntities usersEntities = new DemoEntities();
            TblTweetuser userresult = usersEntities.ValidateTweetUser(user.UserName, user.Password).FirstOrDefault();
            string message = string.Empty;
            List<TblTweet> result = new List<TblTweet>();
            Tweets tuser = new Tweets();
            switch (userresult.UserId)
            {
                case -1:
                    message = "Username and/or password is incorrect.";
                    ViewBag.Message = message;
                    return View();
                case -2:
                    message = "Account has not been activated.";
                    ViewBag.Message = message;
                    return View();
                default:
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddMinutes(2880), 
                        false, "user", FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    Session["userid"] = userresult.UserId;
                    Session["username"] = userresult.UserName;
                    if (ticket.IsPersistent)
                    {
                        cookie.Expires = ticket.Expiration;
                    }
                    Response.Cookies.Add(cookie);
                    // usersEntities.dis
                    ObjectResult<TblTweet> list =usersEntities.DisplayTweets("%,"+userresult.UserId.ToString()+",%");
                    result = list.Select(x => new TblTweet
                    {
                        TweetId =x.TweetId,
                        TweetUserId=x.TweetUserId,
                        TweetUserName = x.TweetUserName,
                        TweetDeleted = x.TweetDeleted,
                        TweetModifiedDate=x.TweetModifiedDate,
                        TweetText=x.TweetText
                    }).ToList();
                    tuser.tweetslists = result;
                    tuser.UserName = userresult.UserName;
                    tuser.UserId = userresult.UserId.ToString();
                    break;
            }
            ViewBag.UserName = userresult.UserName;
            ViewBag.UserId = userresult.UserId.ToString();
            return View("Home", tuser);
        }
         

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(TblTweetuser user)
        {
            DemoEntities demo = new DemoEntities();
            demo.TblTweetusers.Add(user);
            demo.SaveChanges();
            string message = string.Empty;
            switch (user.UserId)
            {
                case -1:
                    message = "Username already exists.\\nPlease choose a different username.";
                    break;
                case -2:
                    message = "Supplied email address has already been used.";
                    break;
                default:
                    message = "Registration successful.\\nUser Id: " + user.UserId.ToString();
                    break;
            }
            ViewBag.Message = message;
            // usersEntities.dis
            ObjectResult<TblTweet> list = demo.DisplayTweets("%," + user.UserId.ToString() + ",%");
            Tweets tuser = TweetLists(user.UserId.ToString(), user.UserName, list);
            ViewBag.UserName = user.UserName;
            ViewBag.UserId = user.UserId.ToString();
            return View("Home", tuser);
        }user_id

        private static Tweets TweetLists(string userId,string username, ObjectResult<TblTweet> list)
        {
            List<TblTweet> result = new List<TblTweet>();
            Tweets tuser = new Tweets();
            result = list.Select(x => new TblTweet
            {
                TweetId = x.TweetId,
                TweetUserId = x.TweetUserId,
                TweetUserName = x.TweetUserName,
                TweetDeleted = x.TweetDeleted,
                TweetModifiedDate = x.TweetModifiedDate,
                TweetText = x.TweetText
            }).ToList();
            tuser.tweetslists = result;
            tuser.UserName = username;
            tuser.UserId = userId;
            return tuser;
        }

        [Authorize]
        public ActionResult MyTweets(string id, string username)
        {
            ViewBag.Message = "My Tweets.";
            DemoEntities demo = new DemoEntities();
            ObjectResult<TblTweet> list = demo.DisplaySelfTweets(Convert.ToInt32(id));
            Tweets tuser = TweetLists(id, username, list);
            ViewBag.UserName = username;
            ViewBag.UserId = id;
            return View("MyTweets",tuser);
        }

        [Authorize]
        public ActionResult CreateTweet(string id, string username)
        {
            ViewBag.Message = "Create My Tweets."; 
            ViewBag.UserName = username;
            ViewBag.UserId = id;
            DemoEntities demo = new DemoEntities();
            TblTweet tweet = new TblTweet();
            tweet.TweetUserName = username;
            tweet.TweetUserId = Convert.ToInt32(id);
            tweet.TweetModifiedDate = DateTime.Now;
            tweet.TweetDeleted = false;
            demo.TblTweets.Add(tweet);
            return View(tweet);
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateTweet(TblTweet tweet)
        {
            ViewBag.Message = "My Tweets.";
            ViewBag.UserName = tweet.TweetUserName;
            ViewBag.UserId = tweet.TweetUserId;
            DemoEntities demo = new DemoEntities();
            tweet.TweetModifiedDate = DateTime.Now;
            tweet.TweetDeleted = false; 
            demo.TblTweets.Add(tweet);
            demo.SaveChanges();
            return MyTweets(tweet.TweetUserId.ToString(), tweet.TweetUserName);
        }

        [Authorize]
        public ActionResult UpdateTweet(int tweetid, string id, string username)
        {
            ViewBag.Message = "Update My Tweets.";
            ViewBag.UserName = username;
            ViewBag.UserId = id;
            DemoEntities demo = new DemoEntities();
            TblTweet tweet = demo.DisplaySelfTweetByTweetId(tweetid).FirstOrDefault();
            return View(tweet); 
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateTweet(TblTweet tweet)
        {
            ViewBag.Message = "My Tweets.";
            ViewBag.UserName = tweet.TweetUserName;
            ViewBag.UserId = tweet.TweetUserId;
            DemoEntities demo = new DemoEntities();
            ObjectResult<TblTweet> list = demo.UpdateTweet(tweet.TweetText, tweet.TweetId, tweet.TweetUserId);
            Tweets tuser = TweetLists(tweet.TweetUserId.ToString(), tweet.TweetUserName, list);
            ViewBag.UserName = tweet.TweetUserName;
            ViewBag.UserId = tweet.TweetUserId;
            return View("MyTweets",tuser);
        }

        [Authorize]
        public ActionResult DeleteTweet(int tweetid, string id, string username)
        {
            ViewBag.Message = "Delete My Tweets.";
            ViewBag.UserName = username;
            ViewBag.UserId = id;
            DemoEntities demo = new DemoEntities();
            TblTweet tweet= demo.DisplaySelfTweetByTweetId(tweetid).FirstOrDefault();
            return View(tweet);
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteTweet(TblTweet tweet)
        {
            ViewBag.Message = "My Tweets.";
            ViewBag.UserName = tweet.TweetUserName;
            ViewBag.UserId = tweet.TweetUserId;
            DemoEntities demo = new DemoEntities();
            ObjectResult<TblTweet> list = demo.DeleteTweet( tweet.TweetId, tweet.TweetUserId);
            Tweets tuser = TweetLists(tweet.TweetUserId.ToString(), tweet.TweetUserName, list);
            ViewBag.UserName = tweet.TweetUserName;
            ViewBag.UserId = tweet.TweetUserId;
            return MyTweets(tweet.TweetUserId.ToString(), tweet.TweetUserName);
           // return View("MyTweets", tuser);
        }


        [Authorize]
        public ActionResult MyProfile(string userid)
        {
            ViewBag.Message = "My Profile.";
            DemoEntities demo = new DemoEntities();
            TblTweetuser user = demo.GetUserByUserId(userid).FirstOrDefault();
            ViewBag.UserName = user.UserName;
            return View(user);
        }


        [Authorize]
        public ActionResult UpdateProfile(string id)
        {
            ViewBag.Message = "Update My Profile.";
            ViewBag.UserId = id;
            DemoEntities demo = new DemoEntities();
            TblTweetuser user = demo.GetUserByUserId(id).FirstOrDefault();
            ViewBag.UserName = user.UserName;
            return View(user);
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateProfile(TblTweetuser user)
        {
            ViewBag.Message = "Update My Profile.";
            DemoEntities demo = new DemoEntities();
            user = demo.UpdateUser(user.UserId.ToString(), user.Password, user.EmailId).FirstOrDefault();
            ViewBag.UserName = user.UserName;
            ViewBag.UserId = user.UserId;
            return View(user);
        }

        [Authorize]
        public ActionResult DeleteProfile(string id)
        {
            ViewBag.Message = "Delete My Profile.";
            ViewBag.UserId = id;
            DemoEntities demo = new DemoEntities();
            TblTweetuser user = demo.GetUserByUserId(id).FirstOrDefault();
            ViewBag.UserName = user.UserName;
            ViewBag.UserId = user.UserId;
            return View(user);
        }
        [Authorize] 
        public ActionResult DeleteProfile1(string userid)
        {
            ViewBag.Message = "Delete Profile.";
            DemoEntities demo = new DemoEntities();
            demo.delete_tweetuser(userid.ToString()); 
            return Logout();
        }


        [Authorize]
        public ActionResult About(string userid)
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.UserId = userid;

            return View();
        }
        [Authorize]
        public ActionResult Contact(string userid)
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.UserId = userid;
            return View();
        }
        [Authorize]
        public ActionResult Search(string text,string id,string username)
        {
            ViewBag.Message = "Search Page.";
            DemoEntities demo = new DemoEntities();
            string backupText = text;
            text = "%" + text + "%";

            ObjectResult<TblTweetuser> list = demo.SearchUsers(text, Convert.ToInt32(id));
           List<TblTweetuser> result = list.Select(x => new TblTweetuser
           { 
                UserId = x.UserId,
                UserName = x.UserName,
                Count = x.Count,
                ModifiedDate = x.ModifiedDate,
                EmailId = x.EmailId,
               Follwers =x.Follwers,
            }).ToList();
            ViewBag.UserId = id;
            ViewBag.UserName = username; 
            return View(result);
        }

        [Authorize]
        public ActionResult SearchIndex(string id)
        {
            DemoEntities demo = new DemoEntities();
            TblTweetuser user = demo.GetUserByUserId(id).FirstOrDefault(); 
            string message = string.Empty;
            Tweets tuser = new Tweets();     
            ObjectResult<TblTweet> list = demo.DisplayTweets("%" + user.UserId.ToString() + "%");
            List<TblTweet> result = list.Select(x => new TblTweet
            {
                TweetId = x.TweetId,
                TweetUserId = x.TweetUserId,
                TweetUserName = x.TweetUserName,
                TweetDeleted = x.TweetDeleted,
                TweetModifiedDate = x.TweetModifiedDate,
                TweetText = x.TweetText,
              
            }).ToList();
            tuser.tweetslists = result;
            tuser.UserName = user.UserName;
            tuser.UserId = user.UserId.ToString();

            ViewBag.UserName = user.UserName;
            ViewBag.UserId = user.UserId.ToString();
            return View("Home", tuser);
        }
        [Authorize]
        public ActionResult Follow(string id,string followid)
        {
            DemoEntities demo = new DemoEntities();
            int? rowCount =demo.FollowUser(Convert.ToInt32(id), followid).FirstOrDefault(); 
            return SearchIndex(id);

        }
        //[Authorize]
        //public ActionResult Profile1()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
    }
}