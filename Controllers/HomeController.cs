////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Web;
////using System.Xml;
////using System.ServiceModel.Syndication;
////using System.Security;
////using System.IO;
////using Microsoft.AspNetCore.Mvc;
////using System.Text;

////namespace RssExample.Controllers
////{
////    public class HomeController : Controller
////    {
////        // URLs for the RSS feeds
////        string feedUrl1 = "http://feeds.feedburner.com/techulator/articles";
////        string feedUrl2 = "https://www.globenewswire.com/RssFeed/subjectcode/1-Advisory/feedTitle/GlobeNewswire%20-%20Advisory"; // Add your second feed here

////        public ActionResult Index(string feed)
////        {
////            string errorString = "";

////            try
////            {
////                StringBuilder rssContent = new StringBuilder();

////                // Load and combine RSS feeds
////                rssContent.Append(LoadRssFeed(feedUrl1, 1));  // Load first RSS feed
////                rssContent.Append(LoadRssFeed(feedUrl2, 2));  // Load second RSS feed

////                ViewData["strArticle"] = rssContent.ToString();
////                return View(ViewData["strArticle"]);
////            }
////            catch (ArgumentNullException)
////            {
////                errorString = "No url for Rss feed specified.";
////            }
////            catch (SecurityException)
////            {
////                errorString = "You do not have permission to access the specified Rss feed.";
////            }
////            catch (FileNotFoundException)
////            {
////                errorString = "The Rss feed was not found.";
////            }
////            catch (UriFormatException)
////            {
////                errorString = "The Rss feed specified was not a valid URI.";
////            }
////            catch (Exception)
////            {
////                errorString = "An error occurred accessing the RSS feed.";
////            }

////            var errorResult = new ContentResult();
////            errorResult.Content = errorString;
////            return errorResult;
////        }

////        private string LoadRssFeed(string feedUrl, int feedNumber)
////        {
////            XmlDocument rssXmlDoc = new XmlDocument();

////            // Load the RSS file from the RSS URL
////            rssXmlDoc.Load(feedUrl);

////            // Parse the Items in the RSS file
////            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

////            StringBuilder rssContent = new StringBuilder();
////            int i = 0;

////            // Iterate through the items in the RSS file
////            foreach (XmlNode rssNode in rssNodes)
////            {
////                i++;
////                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
////                string title = rssSubNode != null ? rssSubNode.InnerText : "";

////                rssSubNode = rssNode.SelectSingleNode("link");
////                string link = rssSubNode != null ? rssSubNode.InnerText : "";

////                rssSubNode = rssNode.SelectSingleNode("description");
////                string description = rssSubNode != null ? rssSubNode.InnerText : "";

////                // Alternate background color for different feed entries
////                string backgroundColor = (i % 2 == 0) ? "#fffff3" : "white";

////                rssContent.Append($"<div style='background: {backgroundColor}'>");
////                rssContent.Append($"<h4>Feed {feedNumber}: <a href='{link}'>{title}</a></h4>");
////                rssContent.Append($"<p>{description}</p>");
////                rssContent.Append("</div>");
////            }

////            return rssContent.ToString();
////        }
////    }
////}

//using System;
//using System.Xml;
//using System.Security;
//using System.IO;
//using Microsoft.AspNetCore.Mvc;
//using System.Text;

//namespace RssExample.Controllers
//{
//    public class HomeController : Controller
//    {
//        // URLs for the RSS feeds
//        string feedUrl1 = "https://www.globenewswire.com/RssFeed/subjectcode/1-Advisory/feedTitle/GlobeNewswire%20-%20Advisory";
//        string feedUrl2 = "https://www.globenewswire.com/RssFeed/subjectcode/3-Analyst%20Recommendations/feedTitle/GlobeNewswire%20-%20Analyst%20Recommendations"; // Add your second feed here
//        string feedUrl3 = "https://www.globenewswire.com/RssFeed/subjectcode/2-Annual%20Meetings%2026%20Shareholder%20Rights/feedTitle/GlobeNewswire%20-%20Annual%20Meetings%20and%20Shareholder%20Rights";
//        string feedUrl4 = "https://www.globenewswire.com/RssFeed/subjectcode/65-Annual%20Report/feedTitle/GlobeNewswire%20-%20Annual%20Report";
//        string feedUrl5 = "https://www.globenewswire.com/RssFeed/subjectcode/4-Arts%2026%20Entertainment/feedTitle/GlobeNewswire%20-%20Arts%20and%20Entertainment";
//        string feedUrl6 = "https://www.globenewswire.com/RssFeed/subjectcode/5-Bankruptcy/feedTitle/GlobeNewswire%20-%20Bankruptcy";
//        string feedUrl7 = "https://www.globenewswire.com/RssFeed/subjectcode/6-Bond%20Market%20News/feedTitle/GlobeNewswire%20-%20Bond%20Market%20News";
//        string feedUrl8 = "https://www.globenewswire.com/RssFeed/subjectcode/74-Bonds%20Market%20Information/feedTitle/GlobeNewswire%20-%20Bonds%20Market%20Information";
//        string feedUrl9 = "https://www.globenewswire.com/RssFeed/subjectcode/7-Business%20Contracts/feedTitle/GlobeNewswire%20-%20Business%20Contracts";
//        string feedUrl10 = "https://www.globenewswire.com/RssFeed/subjectcode/8-Calendar%20Of%20Events/feedTitle/GlobeNewswire%20-%20Calendar%20Of%20Events";
//        string feedUrl11 = "https://www.globenewswire.com/RssFeed/subjectcode/58-Changes%20In%20Company%2027s%20Own%20Shares/feedTitle/GlobeNewswire%20-%20Changes%20In%20Company%20s%20Own%20Shares";
//        string feedUrl12 = "https://www.globenewswire.com/RssFeed/subjectcode/57-Changes%20In%20Share%20Capital%20And%20Votes/feedTitle/GlobeNewswire%20-%20Changes%20In%20Share%20Capital%20And%20Votes";
//        string feedUrl13 = "https://www.globenewswire.com/RssFeed/subjectcode/71-Changes%20To%20Observation%20Segment/feedTitle/GlobeNewswire%20-%20Changes%20To%20Observation%20Segment";
//        string feedUrl14 = "https://www.globenewswire.com/RssFeed/subjectcode/84-Class%20Action/feedTitle/GlobeNewswire%20-%20Class%20Action";
//        string feedUrl15 = "https://www.globenewswire.com/RssFeed/subjectcode/90-Clinical%20Study/feedTitle/GlobeNewswire%20-%20Clinical%20Study";
//        string feedUrl16 = "https://www.globenewswire.com/RssFeed/subjectcode/9-Company%20Announcement/feedTitle/GlobeNewswire%20-%20Company%20Announcement";
//        string feedUrl17 = "https://www.globenewswire.com/RssFeed/subjectcode/10-Company%20Regulatory%20Filings/feedTitle/GlobeNewswire%20-%20Company%20Regulatory%20Filings";
//        string feedUrl18 = "https://www.globenewswire.com/RssFeed/subjectcode/89-Conference%20Calls%202f%20Webcasts/feedTitle/GlobeNewswire%20-%20Conference%20Calls,%20Webcasts";
//        string feedUrl19 = "https://www.globenewswire.com/RssFeed/subjectcode/88-Contests%202fAwards/feedTitle/GlobeNewswire%20-%20Contests,%20Awards";
//        string feedUrl20 = "https://www.globenewswire.com/RssFeed/subjectcode/61-Corporate%20Action/feedTitle/GlobeNewswire%20-%20Corporate%20Action";
//        string feedUrl21 = "https://www.globenewswire.com/RssFeed/subjectcode/75-Derivative%20Market%20Information/feedTitle/GlobeNewswire%20-%20Derivative%20Market%20Information";
//        string feedUrl22 = "https://www.globenewswire.com/RssFeed/subjectcode/11-Directors%20And%20Officers/feedTitle/GlobeNewswire%20-%20Directors%20And%20Officers";
//        string feedUrl23 = "https://www.globenewswire.com/RssFeed/subjectcode/12-Dividend%20Reports%20And%20Estimates/feedTitle/GlobeNewswire%20-%20Dividend%20Reports%20And%20Estimates";
//        string feedUrl24 = "https://www.globenewswire.com/RssFeed/subjectcode/13-Earnings%20Releases%20And%20Operating%20Results/feedTitle/GlobeNewswire%20-%20Earnings%20Releases%20And%20Operating%20Results";
//        string feedUrl25 = "https://www.globenewswire.com/RssFeed/subjectcode/14-Economic%20Research%20And%20Reports/feedTitle/GlobeNewswire%20-%20Economic%20Research%20And%20Reports";
//        string feedUrl26 = "https://www.globenewswire.com/RssFeed/subjectcode/91-Environmental%202c%20Social%202c%20And%20Governance%20Criteria/feedTitle/GlobeNewswire%20-%20Environmental,%20Social,%20And%20Governance%20Criteria";
//        string feedUrl27 = "https://www.globenewswire.com/RssFeed/subjectcode/76-Equity%20Market%20Information/feedTitle/GlobeNewswire%20-%20Equity%20Market%20Information";
//        string feedUrl28 = "https://www.globenewswire.com/RssFeed/subjectcode/85-European%20Regulatory%20News/feedTitle/GlobeNewswire%20-%20European%20Regulatory%20News";
//        string feedUrl29 = "https://www.globenewswire.com/RssFeed/subjectcode/70-Exchange%20Announcement/feedTitle/GlobeNewswire%20-%20Exchange%20Announcement";
//        string feedUrl30 = "https://www.globenewswire.com/RssFeed/subjectcode/77-Exchange%20Members/feedTitle/GlobeNewswire%20-%20Exchange%20Members";
//        string feedUrl31 = "https://www.globenewswire.com/RssFeed/subjectcode/78-Exchange%20News/feedTitle/GlobeNewswire%20-%20Exchange%20News";
//        string feedUrl32 = "https://www.globenewswire.com/RssFeed/subjectcode/15-Fashion/feedTitle/GlobeNewswire%20-%20Fashion";
//        string feedUrl33 = "https://www.globenewswire.com/RssFeed/subjectcode/16-Feature%20Article/feedTitle/GlobeNewswire%20-%20Feature%20Article";
//        string feedUrl34 = "https://www.globenewswire.com/RssFeed/subjectcode/17-Financing%20Agreements/feedTitle/GlobeNewswire%20-%20Financing%20Agreements";
//        string feedUrl35 = "https://www.globenewswire.com/RssFeed/subjectcode/69-First%20North%20Announcement/feedTitle/GlobeNewswire%20-%20First%20North%20Announcement";
//        string feedUrl36 = "https://www.globenewswire.com/RssFeed/subjectcode/79-First%20North%20Information/feedTitle/GlobeNewswire%20-%20First%20North%20Information";
//        string feedUrl37 = "https://www.globenewswire.com/RssFeed/subjectcode/18-Food/feedTitle/GlobeNewswire%20-%20Food";
//        string feedUrl38 = "https://www.globenewswire.com/RssFeed/subjectcode/19-Government%20News/feedTitle/GlobeNewswire%20-%20Government%20News";
//        string feedUrl39 = "https://www.globenewswire.com/RssFeed/subjectcode/20-Health/feedTitle/GlobeNewswire%20-%20Health";
//        string feedUrl40 = "https://www.globenewswire.com/RssFeed/subjectcode/21-Initial%20Public%20Offerings/feedTitle/GlobeNewswire%20-%20Initial%20Public%20Offerings";
//        string feedUrl41 = "https://www.globenewswire.com/RssFeed/subjectcode/22-Insider%2027s%20Buy%202fSell/feedTitle/GlobeNewswire%20-%20Insider%20s%20Buy,%20Sell";
//        string feedUrl42 = "https://www.globenewswire.com/RssFeed/subjectcode/66-Interim%20Information/feedTitle/GlobeNewswire%20-%20Interim%20Information";
//        string feedUrl43 = "https://www.globenewswire.com/RssFeed/subjectcode/80-Investment%20Fund%20Information/feedTitle/GlobeNewswire%20-%20Investment%20Fund%20Information";
//        string feedUrl44 = "https://www.globenewswire.com/RssFeed/subjectcode/83-Investment%20Opinion/feedTitle/GlobeNewswire%20-%20Investment%20Opinion";
//        string feedUrl45 = "https://www.globenewswire.com/RssFeed/subjectcode/23-Joint%20Venture/feedTitle/GlobeNewswire%20-%20Joint%20Venture";
//        string feedUrl46 = "https://www.globenewswire.com/RssFeed/subjectcode/24-Law%2026%20Legal%20Issues/feedTitle/GlobeNewswire%20-%20Law%20and%20Legal%20Issues";
//        string feedUrl47 = "https://www.globenewswire.com/RssFeed/subjectcode/25-Licensing%20Agreements/feedTitle/GlobeNewswire%20-%20Licensing%20Agreements";
//        string feedUrl48 = "https://www.globenewswire.com/RssFeed/subjectcode/26-Lifestyle/feedTitle/GlobeNewswire%20-%20Lifestyle";
//        string feedUrl49 = "https://www.globenewswire.com/RssFeed/subjectcode/59-Major%20Shareholder%20Announcements/feedTitle/GlobeNewswire%20-%20Major%20Shareholder%20Announcements";        
//        string feedUrl50 = "https://www.globenewswire.com/RssFeed/subjectcode/86-Management%20Changes/feedTitle/GlobeNewswire%20-%20Management%20Changes";
//        string feedUrl51 = "https://www.globenewswire.com/RssFeed/subjectcode/67-Management%20Statements/feedTitle/GlobeNewswire%20-%20Management%20Statements";
//        string feedUrl52 = "https://www.globenewswire.com/RssFeed/subjectcode/81-Market%20Research%20Reports/feedTitle/GlobeNewswire%20-%20Market%20Research%20Reports";
//        string feedUrl53 = "https://www.globenewswire.com/RssFeed/subjectcode/27-Mergers%20And%20Acquisitions/feedTitle/GlobeNewswire%20-%20Mergers%20And%20Acquisitions";
//        string feedUrl54 = "https://www.globenewswire.com/RssFeed/subjectcode/64-Mutual%20Fund%20Information/feedTitle/GlobeNewswire%20-%20Mutual%20Fund%20Information";
//        string feedUrl55 = "https://www.globenewswire.com/RssFeed/subjectcode/62-Net%20Asset%20Value/feedTitle/GlobeNewswire%20-%20Net%20Asset%20Value";
//        string feedUrl56 = "https://www.globenewswire.com/RssFeed/subjectcode/28-Other%20News/feedTitle/GlobeNewswire%20-%20Other%20News";
//        string feedUrl57 = "https://www.globenewswire.com/RssFeed/subjectcode/29-Partnerships/feedTitle/GlobeNewswire%20-%20Partnerships";
//        string feedUrl58 = "https://www.globenewswire.com/RssFeed/subjectcode/30-Patents/feedTitle/GlobeNewswire%20-%20Patents";
//        string feedUrl59 = "https://www.globenewswire.com/RssFeed/subjectcode/87-Philanthropy/feedTitle/GlobeNewswire%20-%20Philanthropy";
//        string feedUrl60 = "https://www.globenewswire.com/RssFeed/subjectcode/34-Politics/feedTitle/GlobeNewswire%20-%20Politics";
//        string feedUrl61 = "https://www.globenewswire.com/RssFeed/subjectcode/31-Pre%20Release%20Comments/feedTitle/GlobeNewswire%20-%20Pre%20Release%20Comments";
//        string feedUrl62 = "https://www.globenewswire.com/RssFeed/subjectcode/72-Press%20Releases/feedTitle/GlobeNewswire%20-%20Press%20Releases";
//        string feedUrl63 = "https://www.globenewswire.com/RssFeed/subjectcode/32-Product%202f%20Services%20Announcement/feedTitle/GlobeNewswire%20-%20Product%20,%20Services%20Announcement";
//        string feedUrl64 = "https://www.globenewswire.com/RssFeed/subjectcode/63-Prospectus%202fAnnouncement%20Of%20Prospectus/feedTitle/GlobeNewswire%20-%20Prospectus,%20Announcement%20Of%20Prospectus";
//        string feedUrl65 = "https://www.globenewswire.com/RssFeed/subjectcode/33-Proxy%20Statements%20And%20Analysis/feedTitle/GlobeNewswire%20-%20Proxy%20Statements%20And%20Analysis";
//        string feedUrl66 = "https://www.globenewswire.com/RssFeed/subjectcode/73-Regulatory%20Information/feedTitle/GlobeNewswire%20-%20Regulatory%20Information";
//        string feedUrl67 = "https://www.globenewswire.com/RssFeed/subjectcode/35-Religion/feedTitle/GlobeNewswire%20-%20Religion";
//        string feedUrl68 = "https://www.globenewswire.com/RssFeed/subjectcode/36-Research%20Analysis%20And%20Reports/feedTitle/GlobeNewswire%20-%20Research%20Analysis%20And%20Reports";       
//        string feedUrl69 = "https://www.globenewswire.com/RssFeed/subjectcode/37-Restructuring%202f%20Recapitalization/feedTitle/GlobeNewswire%20-%20Restructuring%20,%20Recapitalization";
//        string feedUrl70 = "https://www.globenewswire.com/RssFeed/subjectcode/38-Sports/feedTitle/GlobeNewswire%20-%20Sports";
//        string feedUrl71 = "https://www.globenewswire.com/RssFeed/subjectcode/39-Stock%20Market%20News/feedTitle/GlobeNewswire%20-%20Stock%20Market%20News";
//        string feedUrl72 = "https://www.globenewswire.com/RssFeed/subjectcode/40-Tax%20Issues%202fAccounting/feedTitle/GlobeNewswire%20-%20Tax%20Issues,%20Accounting";
//        string feedUrl73 = "https://www.globenewswire.com/RssFeed/subjectcode/43-Technical%20Analysis/feedTitle/GlobeNewswire%20-%20Technical%20Analysis";
//        string feedUrl74 = "https://www.globenewswire.com/RssFeed/subjectcode/41-Trade%20Show/feedTitle/GlobeNewswire%20-%20Trade%20Show";
//        string feedUrl75 = "https://www.globenewswire.com/RssFeed/subjectcode/68-Trading%20Information/feedTitle/GlobeNewswire%20-%20Trading%20Information";
//        string feedUrl76 = "https://www.globenewswire.com/RssFeed/subjectcode/42-Travel/feedTitle/GlobeNewswire%20-%20Travel";
//        string feedUrl77 = "https://www.globenewswire.com/RssFeed/subjectcode/82-Warrants%20And%20Certificates/feedTitle/GlobeNewswire%20-%20Warrants%20And%20Certificates";

//        public ActionResult Index(int feedId = 1) // Default to feedUrl1 if no feedId is passed
//        {
//            string errorString = "";
//            string feedUrl = (feedId == 2) ? feedUrl2 : feedUrl1; // Load feedUrl2 if feedId is 2, otherwise feedUrl1

//            try
//            {
//                StringBuilder rssContent = new StringBuilder();

//                // Load the selected RSS feed
//                rssContent.Append(LoadRssFeed(feedUrl, feedId));

//                ViewData["strArticle"] = rssContent.ToString();
//                return View(ViewData["strArticle"]);
//            }
//            catch (Exception ex)
//            {
//                errorString = "An error occurred: " + ex.Message;
//            }

//            var errorResult = new ContentResult();
//            errorResult.Content = errorString;
//            return errorResult;
//        }

//        private string LoadRssFeed(string feedUrl, int feedNumber)
//        {
//            XmlDocument rssXmlDoc = new XmlDocument();

//            // Load the RSS file from the RSS URL
//            rssXmlDoc.Load(feedUrl);

//            // Parse the Items in the RSS file
//            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

//            StringBuilder rssContent = new StringBuilder();
//            int i = 0;

//            // Iterate through the items in the RSS file
//            foreach (XmlNode rssNode in rssNodes)
//            {
//                i++;
//                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
//                string title = rssSubNode != null ? rssSubNode.InnerText : "";

//                rssSubNode = rssNode.SelectSingleNode("link");
//                string link = rssSubNode != null ? rssSubNode.InnerText : "";

//                rssSubNode = rssNode.SelectSingleNode("description");
//                string description = rssSubNode != null ? rssSubNode.InnerText : "";

//                // Alternate background color for different feed entries
//                string backgroundColor = (i % 2 == 0) ? "#fffff3" : "white";

//                rssContent.Append($"<div style='background: {backgroundColor}'>");
//                rssContent.Append($"<h4> <a href='{link}'>{title}</a></h4>");
//                rssContent.Append($"<p>{description}</p>");
//                rssContent.Append("</div>");
//            }

//            return rssContent.ToString();
//        }
//    }
//}

using System;
using System.Xml;
using System.Security;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using static System.Net.WebRequestMethods;

namespace RssExample.Controllers
{
    public class HomeController : Controller
    {
        // Array containing all the RSS feed URLs
        string[] feedUrls = new string[]
        {
           
            "https://www.globenewswire.com/RssFeed/subjectcode/1-Advisory/feedTitle/GlobeNewswire%20-%20Advisory",
            "https://www.globenewswire.com/RssFeed/subjectcode/3-Analyst%20Recommendations/feedTitle/GlobeNewswire%20-%20Analyst%20Recommendations",
            "https://www.globenewswire.com/RssFeed/subjectcode/2-Annual%20Meetings%2026%20Shareholder%20Rights/feedTitle/GlobeNewswire%20-%20Annual%20Meetings%20and%20Shareholder%20Rights",
            "https://www.globenewswire.com/RssFeed/subjectcode/65-Annual%20Report/feedTitle/GlobeNewswire%20-%20Annual%20Report",
        "https://www.globenewswire.com/RssFeed/subjectcode/4-Arts%2026%20Entertainment/feedTitle/GlobeNewswire%20-%20Arts%20and%20Entertainment",
        "https://www.globenewswire.com/RssFeed/subjectcode/5-Bankruptcy/feedTitle/GlobeNewswire%20-%20Bankruptcy",
        "https://www.globenewswire.com/RssFeed/subjectcode/6-Bond%20Market%20News/feedTitle/GlobeNewswire%20-%20Bond%20Market%20News",
        "https://www.globenewswire.com/RssFeed/subjectcode/74-Bonds%20Market%20Information/feedTitle/GlobeNewswire%20-%20Bonds%20Market%20Information",
        "https://www.globenewswire.com/RssFeed/subjectcode/7-Business%20Contracts/feedTitle/GlobeNewswire%20-%20Business%20Contracts",
        "https://www.globenewswire.com/RssFeed/subjectcode/8-Calendar%20Of%20Events/feedTitle/GlobeNewswire%20-%20Calendar%20Of%20Events",
        "https://www.globenewswire.com/RssFeed/subjectcode/58-Changes%20In%20Company%2027s%20Own%20Shares/feedTitle/GlobeNewswire%20-%20Changes%20In%20Company%20s%20Own%20Shares",
       "https://www.globenewswire.com/RssFeed/subjectcode/57-Changes%20In%20Share%20Capital%20And%20Votes/feedTitle/GlobeNewswire%20-%20Changes%20In%20Share%20Capital%20And%20Votes",
        "https://www.globenewswire.com/RssFeed/subjectcode/71-Changes%20To%20Observation%20Segment/feedTitle/GlobeNewswire%20-%20Changes%20To%20Observation%20Segment",
        "https://www.globenewswire.com/RssFeed/subjectcode/84-Class%20Action/feedTitle/GlobeNewswire%20-%20Class%20Action",
        "https://www.globenewswire.com/RssFeed/subjectcode/90-Clinical%20Study/feedTitle/GlobeNewswire%20-%20Clinical%20Study",
        "https://www.globenewswire.com/RssFeed/subjectcode/9-Company%20Announcement/feedTitle/GlobeNewswire%20-%20Company%20Announcement",
        "https://www.globenewswire.com/RssFeed/subjectcode/10-Company%20Regulatory%20Filings/feedTitle/GlobeNewswire%20-%20Company%20Regulatory%20Filings",
        "https://www.globenewswire.com/RssFeed/subjectcode/89-Conference%20Calls%202f%20Webcasts/feedTitle/GlobeNewswire%20-%20Conference%20Calls,%20Webcasts",
        "https://www.globenewswire.com/RssFeed/subjectcode/88-Contests%202fAwards/feedTitle/GlobeNewswire%20-%20Contests,%20Awards",
        "https://www.globenewswire.com/RssFeed/subjectcode/61-Corporate%20Action/feedTitle/GlobeNewswire%20-%20Corporate%20Action",
        "https://www.globenewswire.com/RssFeed/subjectcode/75-Derivative%20Market%20Information/feedTitle/GlobeNewswire%20-%20Derivative%20Market%20Information",
        "https://www.globenewswire.com/RssFeed/subjectcode/11-Directors%20And%20Officers/feedTitle/GlobeNewswire%20-%20Directors%20And%20Officers",
        "https://www.globenewswire.com/RssFeed/subjectcode/12-Dividend%20Reports%20And%20Estimates/feedTitle/GlobeNewswire%20-%20Dividend%20Reports%20And%20Estimates",
        "https://www.globenewswire.com/RssFeed/subjectcode/13-Earnings%20Releases%20And%20Operating%20Results/feedTitle/GlobeNewswire%20-%20Earnings%20Releases%20And%20Operating%20Results",
        "https://www.globenewswire.com/RssFeed/subjectcode/14-Economic%20Research%20And%20Reports/feedTitle/GlobeNewswire%20-%20Economic%20Research%20And%20Reports",
        "https://www.globenewswire.com/RssFeed/subjectcode/91-Environmental%202c%20Social%202c%20And%20Governance%20Criteria/feedTitle/GlobeNewswire%20-%20Environmental,%20Social,%20And%20Governance%20Criteria",
        "https://www.globenewswire.com/RssFeed/subjectcode/76-Equity%20Market%20Information/feedTitle/GlobeNewswire%20-%20Equity%20Market%20Information",
        "https://www.globenewswire.com/RssFeed/subjectcode/85-European%20Regulatory%20News/feedTitle/GlobeNewswire%20-%20European%20Regulatory%20News",
        "https://www.globenewswire.com/RssFeed/subjectcode/70-Exchange%20Announcement/feedTitle/GlobeNewswire%20-%20Exchange%20Announcement",
        "https://www.globenewswire.com/RssFeed/subjectcode/77-Exchange%20Members/feedTitle/GlobeNewswire%20-%20Exchange%20Members",
        "https://www.globenewswire.com/RssFeed/subjectcode/78-Exchange%20News/feedTitle/GlobeNewswire%20-%20Exchange%20News",
        "https://www.globenewswire.com/RssFeed/subjectcode/15-Fashion/feedTitle/GlobeNewswire%20-%20Fashion",
        "https://www.globenewswire.com/RssFeed/subjectcode/16-Feature%20Article/feedTitle/GlobeNewswire%20-%20Feature%20Article",
        "https://www.globenewswire.com/RssFeed/subjectcode/17-Financing%20Agreements/feedTitle/GlobeNewswire%20-%20Financing%20Agreements",
        "https://www.globenewswire.com/RssFeed/subjectcode/69-First%20North%20Announcement/feedTitle/GlobeNewswire%20-%20First%20North%20Announcement",
        "https://www.globenewswire.com/RssFeed/subjectcode/79-First%20North%20Information/feedTitle/GlobeNewswire%20-%20First%20North%20Information",
        "https://www.globenewswire.com/RssFeed/subjectcode/18-Food/feedTitle/GlobeNewswire%20-%20Food",
        "https://www.globenewswire.com/RssFeed/subjectcode/19-Government%20News/feedTitle/GlobeNewswire%20-%20Government%20News",
        "https://www.globenewswire.com/RssFeed/subjectcode/20-Health/feedTitle/GlobeNewswire%20-%20Health",
        "https://www.globenewswire.com/RssFeed/subjectcode/21-Initial%20Public%20Offerings/feedTitle/GlobeNewswire%20-%20Initial%20Public%20Offerings",
        "https://www.globenewswire.com/RssFeed/subjectcode/22-Insider%2027s%20Buy%202fSell/feedTitle/GlobeNewswire%20-%20Insider%20s%20Buy,%20Sell",
        "https://www.globenewswire.com/RssFeed/subjectcode/66-Interim%20Information/feedTitle/GlobeNewswire%20-%20Interim%20Information",
        "https://www.globenewswire.com/RssFeed/subjectcode/80-Investment%20Fund%20Information/feedTitle/GlobeNewswire%20-%20Investment%20Fund%20Information",
        "https://www.globenewswire.com/RssFeed/subjectcode/83-Investment%20Opinion/feedTitle/GlobeNewswire%20-%20Investment%20Opinion",
        "https://www.globenewswire.com/RssFeed/subjectcode/23-Joint%20Venture/feedTitle/GlobeNewswire%20-%20Joint%20Venture",
        "https://www.globenewswire.com/RssFeed/subjectcode/24-Law%2026%20Legal%20Issues/feedTitle/GlobeNewswire%20-%20Law%20and%20Legal%20Issues",
        "https://www.globenewswire.com/RssFeed/subjectcode/25-Licensing%20Agreements/feedTitle/GlobeNewswire%20-%20Licensing%20Agreements",
        "https://www.globenewswire.com/RssFeed/subjectcode/26-Lifestyle/feedTitle/GlobeNewswire%20-%20Lifestyle",
        "https://www.globenewswire.com/RssFeed/subjectcode/59-Major%20Shareholder%20Announcements/feedTitle/GlobeNewswire%20-%20Major%20Shareholder%20Announcements",        
        "https://www.globenewswire.com/RssFeed/subjectcode/86-Management%20Changes/feedTitle/GlobeNewswire%20-%20Management%20Changes",
        "https://www.globenewswire.com/RssFeed/subjectcode/67-Management%20Statements/feedTitle/GlobeNewswire%20-%20Management%20Statements",
        "https://www.globenewswire.com/RssFeed/subjectcode/81-Market%20Research%20Reports/feedTitle/GlobeNewswire%20-%20Market%20Research%20Reports",
        "https://www.globenewswire.com/RssFeed/subjectcode/27-Mergers%20And%20Acquisitions/feedTitle/GlobeNewswire%20-%20Mergers%20And%20Acquisitions",
        "https://www.globenewswire.com/RssFeed/subjectcode/64-Mutual%20Fund%20Information/feedTitle/GlobeNewswire%20-%20Mutual%20Fund%20Information",
        "https://www.globenewswire.com/RssFeed/subjectcode/62-Net%20Asset%20Value/feedTitle/GlobeNewswire%20-%20Net%20Asset%20Value",
        "https://www.globenewswire.com/RssFeed/subjectcode/28-Other%20News/feedTitle/GlobeNewswire%20-%20Other%20News",
        "https://www.globenewswire.com/RssFeed/subjectcode/29-Partnerships/feedTitle/GlobeNewswire%20-%20Partnerships",
        "https://www.globenewswire.com/RssFeed/subjectcode/30-Patents/feedTitle/GlobeNewswire%20-%20Patents",
        "https://www.globenewswire.com/RssFeed/subjectcode/87-Philanthropy/feedTitle/GlobeNewswire%20-%20Philanthropy",
        "https://www.globenewswire.com/RssFeed/subjectcode/34-Politics/feedTitle/GlobeNewswire%20-%20Politics",
        "https://www.globenewswire.com/RssFeed/subjectcode/31-Pre%20Release%20Comments/feedTitle/GlobeNewswire%20-%20Pre%20Release%20Comments",
        "https://www.globenewswire.com/RssFeed/subjectcode/72-Press%20Releases/feedTitle/GlobeNewswire%20-%20Press%20Releases",
        "https://www.globenewswire.com/RssFeed/subjectcode/32-Product%202f%20Services%20Announcement/feedTitle/GlobeNewswire%20-%20Product%20,%20Services%20Announcement",
        "https://www.globenewswire.com/RssFeed/subjectcode/63-Prospectus%202fAnnouncement%20Of%20Prospectus/feedTitle/GlobeNewswire%20-%20Prospectus,%20Announcement%20Of%20Prospectus",
        "https://www.globenewswire.com/RssFeed/subjectcode/33-Proxy%20Statements%20And%20Analysis/feedTitle/GlobeNewswire%20-%20Proxy%20Statements%20And%20Analysis",
        "https://www.globenewswire.com/RssFeed/subjectcode/73-Regulatory%20Information/feedTitle/GlobeNewswire%20-%20Regulatory%20Information",
        "https://www.globenewswire.com/RssFeed/subjectcode/35-Religion/feedTitle/GlobeNewswire%20-%20Religion",
        "https://www.globenewswire.com/RssFeed/subjectcode/36-Research%20Analysis%20And%20Reports/feedTitle/GlobeNewswire%20-%20Research%20Analysis%20And%20Reports",       
        "https://www.globenewswire.com/RssFeed/subjectcode/37-Restructuring%202f%20Recapitalization/feedTitle/GlobeNewswire%20-%20Restructuring%20,%20Recapitalization",
        "https://www.globenewswire.com/RssFeed/subjectcode/38-Sports/feedTitle/GlobeNewswire%20-%20Sports",
        "https://www.globenewswire.com/RssFeed/subjectcode/39-Stock%20Market%20News/feedTitle/GlobeNewswire%20-%20Stock%20Market%20News",
        "https://www.globenewswire.com/RssFeed/subjectcode/40-Tax%20Issues%202fAccounting/feedTitle/GlobeNewswire%20-%20Tax%20Issues,%20Accounting",
        "https://www.globenewswire.com/RssFeed/subjectcode/43-Technical%20Analysis/feedTitle/GlobeNewswire%20-%20Technical%20Analysis",
        "https://www.globenewswire.com/RssFeed/subjectcode/41-Trade%20Show/feedTitle/GlobeNewswire%20-%20Trade%20Show",
        "https://www.globenewswire.com/RssFeed/subjectcode/68-Trading%20Information/feedTitle/GlobeNewswire%20-%20Trading%20Information",
        "https://www.globenewswire.com/RssFeed/subjectcode/42-Travel/feedTitle/GlobeNewswire%20-%20Travel",
        "https://www.globenewswire.com/RssFeed/subjectcode/82-Warrants%20And%20Certificates/feedTitle/GlobeNewswire%20-%20Warrants%20And%20Certificates",
         "https://www.globenewswire.com/RssFeed/industry/1000-Basic%20Materials/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Basic%20Materials",
         "https://www.globenewswire.com/RssFeed/industry/1753-Aluminum/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Aluminum",
         "https://www.globenewswire.com/RssFeed/industry/55201010-Chemicals%20and%20Synthetic%20Fibers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Chemicals%20and%20Synthetic%20Fibers",
         "https://www.globenewswire.com/RssFeed/industry/55201000-Chemicals%203a%20Diversified/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Chemicals%20Diversified",
         "https://www.globenewswire.com/RssFeed/industry/1353-Commodity%20Chemicals/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Commodity%20Chemicals",
         "https://www.globenewswire.com/RssFeed/industry/55102040-Copper/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Copper",
         "https://www.globenewswire.com/RssFeed/industry/1773-Diamonds%2026%20Gemstones/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Diamonds%20and%20Gemstones",
         "https://www.globenewswire.com/RssFeed/industry/55101000-Diversified%20Materials/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Diversified%20Materials",
         "https://www.globenewswire.com/RssFeed/industry/55201015-Fertilizers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Fertilizers",
         "https://www.globenewswire.com/RssFeed/industry/1733-Forestry/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Forestry",
         "https://www.globenewswire.com/RssFeed/industry/1775-General%20Mining/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20General%20Mining",
         "https://www.globenewswire.com/RssFeed/industry/1777-Gold%20Mining/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Gold%20Mining",
         "https://www.globenewswire.com/RssFeed/industry/1757-Iron%2026%20Steel/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Iron%20and%20Steel",
         "https://www.globenewswire.com/RssFeed/industry/55102015-Metal%20Fabricating/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Metal%20Fabricating",
         "https://www.globenewswire.com/RssFeed/industry/1755-Nonferrous%20Metals/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Nonferrous%20Metals",
         "https://www.globenewswire.com/RssFeed/industry/1737-Paper/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Paper",
         "https://www.globenewswire.com/RssFeed/industry/1779-Platinum%2026%20Precious%20Metals/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Platinum%20and%20Precious%20Metals",
         "https://www.globenewswire.com/RssFeed/industry/1357-Specialty%20Chemicals/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Specialty%20Chemicals",
         "https://www.globenewswire.com/RssFeed/industry/55101020-Textile%20Products/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Textile%20Products",
         "https://www.globenewswire.com/RssFeed/industry/3000-Consumer%20Goods/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Consumer%20Goods",
         "https://www.globenewswire.com/RssFeed/industry/3355-Auto%20Parts/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Auto%20Parts",
         "https://www.globenewswire.com/RssFeed/industry/40101010-Auto%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Auto%20Services",
         "https://www.globenewswire.com/RssFeed/industry/3353-Automobiles/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Automobiles",
         "https://www.globenewswire.com/RssFeed/industry/3533-Brewers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Brewers",
         "https://www.globenewswire.com/RssFeed/industry/3763-Clothing%2026%20Accessories/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Clothing%20and%20Accessories",
         "https://www.globenewswire.com/RssFeed/industry/3743-Consumer%20Electronics/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Consumer%20Electronics",
         "https://www.globenewswire.com/RssFeed/industry/3535-Distillers%2026%20Vintners/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Distillers%20and%20Vintners",
         "https://www.globenewswire.com/RssFeed/industry/3722-Durable%20Household%20Products/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Durable%20Household%20Products",
         "https://www.globenewswire.com/RssFeed/industry/3573-Farming%2026%20Fishing/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Farming%20and%20Fishing",
         "https://www.globenewswire.com/RssFeed/industry/3577-Food%20Products/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Food%20Products",
         "https://www.globenewswire.com/RssFeed/industry/3765-Footwear/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Footwear",
         "https://www.globenewswire.com/RssFeed/industry/3726-Furnishings/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Furnishings",
         "https://www.globenewswire.com/RssFeed/industry/3728-Home%20Construction/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Home%20Construction",
         "https://www.globenewswire.com/RssFeed/industry/3724-Nondurable%20Household%20Products/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Nondurable%20Household%20Products",
         "https://www.globenewswire.com/RssFeed/industry/3767-Personal%20Products/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Personal%20Products",
         "https://www.globenewswire.com/RssFeed/industry/3745-Recreational%20Products/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Recreational%20Products",
         "https://www.globenewswire.com/RssFeed/industry/3537-Soft%20Drinks/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Soft%20Drinks",
         "https://www.globenewswire.com/RssFeed/industry/3357-Tires/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Tires",
         "https://www.globenewswire.com/RssFeed/industry/3785-Tobacco/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Tobacco",
         "https://www.globenewswire.com/RssFeed/industry/3747-Toys/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Toys",
         "https://www.globenewswire.com/RssFeed/industry/5000-Consumer%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Consumer%20Services",
         "https://www.globenewswire.com/RssFeed/industry/5751-Airlines/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Airlines",
         "https://www.globenewswire.com/RssFeed/industry/5371-Apparel%20Retailers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Apparel%20Retailers",
         "https://www.globenewswire.com/RssFeed/industry/5553-Broadcasting%2026%20Entertainment/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Broadcasting%20and%20Entertainment",
         "https://www.globenewswire.com/RssFeed/industry/5373-Broadline%20Retailers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Broadline%20Retailers",
         "https://www.globenewswire.com/RssFeed/industry/5333-Drug%20Retailers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Drug%20Retailers",
         "https://www.globenewswire.com/RssFeed/industry/5337-Food%20Retailers%2026%20Wholesalers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Food%20Retailers%20and%20Wholesalers",
         "https://www.globenewswire.com/RssFeed/industry/5752-Gambling/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Gambling",
         "https://www.globenewswire.com/RssFeed/industry/5375-Home%20Improvement%20Retailers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Home%20Improvement%20Retailers",
         "https://www.globenewswire.com/RssFeed/industry/5753-Hotels/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Hotels",
         "https://www.globenewswire.com/RssFeed/industry/5555-Media%20Agencies/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Media%20Agencies",
         "https://www.globenewswire.com/RssFeed/industry/5557-Publishing/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Publishing",
         "https://www.globenewswire.com/RssFeed/industry/5755-Recreational%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Recreational%20Services",
         "https://www.globenewswire.com/RssFeed/industry/5757-Restaurants%2026%20Bars/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Restaurants%20and%20Bars",
         "https://www.globenewswire.com/RssFeed/industry/5377-Specialized%20Consumer%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Specialized%20Consumer%20Services",
         "https://www.globenewswire.com/RssFeed/industry/5379-Specialty%20Retailers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Specialty%20Retailers",
         "https://www.globenewswire.com/RssFeed/industry/5759-Travel%2026%20Tourism/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Travel%20and%20Tourism",
         "https://www.globenewswire.com/RssFeed/industry/1-Energy/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Energy",
         "https://www.globenewswire.com/RssFeed/industry/587-Alternative%20Fuels/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Alternative%20Fuels",
         "https://www.globenewswire.com/RssFeed/industry/1771-Coal/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Coal",
         "https://www.globenewswire.com/RssFeed/industry/533-Exploration%2026%20Production/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Exploration%20and%20Production",
         "https://www.globenewswire.com/RssFeed/industry/537-Integrated%20Oil%2026%20Gas/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Integrated%20Oil%20and%20Gas",
         "https://www.globenewswire.com/RssFeed/industry/573-Oil%20Equipment%2026%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Oil%20Equipment%20and%20Services",
         "https://www.globenewswire.com/RssFeed/industry/577-Pipelines/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Pipelines",
         "https://www.globenewswire.com/RssFeed/industry/583-Renewable%20Energy%20Equipment/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Renewable%20Energy%20Equipment",
         "https://www.globenewswire.com/RssFeed/industry/8000-Financials/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Financials",
         "https://www.globenewswire.com/RssFeed/industry/8771-Asset%20Managers%2026%20Custodians/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Asset%20Managers%20and%20Custodians",
         "https://www.globenewswire.com/RssFeed/industry/8355-Banks/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Banks",
         "https://www.globenewswire.com/RssFeed/industry/30204000-Closed%20End%20Investments/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Closed%20End%20Investments",
         "https://www.globenewswire.com/RssFeed/industry/8773-Consumer%20Finance/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Consumer%20Finance",
         "https://www.globenewswire.com/RssFeed/industry/30202000-Diversified%20Financial%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Diversified%20Financial%20Services",
         "https://www.globenewswire.com/RssFeed/industry/8985-Equity%20Investment%20Instruments/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Equity%20Investment%20Instruments",
         "https://www.globenewswire.com/RssFeed/industry/30201030-Financial%20Data%20Providers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Financial%20Data%20Providers",
         "https://www.globenewswire.com/RssFeed/industry/8532-Full%20Line%20Insurance/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Full%20Line%20Insurance",
         "https://www.globenewswire.com/RssFeed/industry/8534-Insurance%20Brokers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Insurance%20Brokers",
         "https://www.globenewswire.com/RssFeed/industry/8777-Investment%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Investment%20Services",
         "https://www.globenewswire.com/RssFeed/industry/8575-Life%20Insurance/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Life%20Insurance",
         "https://www.globenewswire.com/RssFeed/industry/8779-Mortgage%20Finance/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Mortgage%20Finance",
         "https://www.globenewswire.com/RssFeed/industry/8995-Nonequity%20Investment%20Instruments/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Nonequity%20Investment%20Instruments",
         "https://www.globenewswire.com/RssFeed/industry/30205000-Open%20End%20and%20Miscellaneous%20Investment%20Vehicles/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Open%20End%20and%20Miscellaneous%20Investment%20Vehicles",
         "https://www.globenewswire.com/RssFeed/industry/8536-Property%2026%20Casualty%20Insurance/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Property%20and%20Casualty%20Insurance",
         "https://www.globenewswire.com/RssFeed/industry/8538-Reinsurance/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Reinsurance",
         "https://www.globenewswire.com/RssFeed/industry/8775-Specialty%20Finance/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Specialty%20Finance",
         "https://www.globenewswire.com/RssFeed/industry/4000-Health%20Care/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Health%20Care",
         "https://www.globenewswire.com/RssFeed/industry/4573-Biotechnology/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Biotechnology",
         "https://www.globenewswire.com/RssFeed/industry/20103020-Cannabis%20Producers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Cannabis%20Producers",
         "https://www.globenewswire.com/RssFeed/industry/4533-Health%20Care%20Providers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Health%20Care%20Providers",
         "https://www.globenewswire.com/RssFeed/industry/4535-Medical%20Equipment/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Medical%20Equipment",
         "https://www.globenewswire.com/RssFeed/industry/20102020-Medical%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Medical%20Services",
         "https://www.globenewswire.com/RssFeed/industry/4537-Medical%20Supplies/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Medical%20Supplies",
         "https://www.globenewswire.com/RssFeed/industry/4577-Pharmaceuticals/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Pharmaceuticals",
         "https://www.globenewswire.com/RssFeed/industry/2000-Industrials/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Industrials",
         "https://www.globenewswire.com/RssFeed/industry/2713-Aerospace/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Aerospace",
         "https://www.globenewswire.com/RssFeed/industry/2353-Building%20Materials%2026%20Fixtures/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Building%20Materials%20and%20Fixtures",
         "https://www.globenewswire.com/RssFeed/industry/50101035-Building%20Materials%203a%20Other/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Building%20Materials%20Other",
         "https://www.globenewswire.com/RssFeed/industry/50101020-Building%202c%20Roofing%202fWallboard%20and%20Plumbing/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Building,%20Roofing,%20Wallboard%20and%20Plumbing",
         "https://www.globenewswire.com/RssFeed/industry/50101025-Building%203a%20Climate%20Control/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Building%20Climate%20Control",
         "https://www.globenewswire.com/RssFeed/industry/2791-Business%20Support%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Business%20Support%20Services",
         "https://www.globenewswire.com/RssFeed/industry/2793-Business%20Training%2026%20Employment%20Agencies/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Business%20Training%20and%20Employment%20Agencies",
         "https://www.globenewswire.com/RssFeed/industry/50205025-Business%20Training%20and%20Employment%20Agencies/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Business%20Training%20and%20Employment%20Agencies",
         "https://www.globenewswire.com/RssFeed/industry/50101030-Cement/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Cement",
         "https://www.globenewswire.com/RssFeed/industry/50206050-Commercial%20Vehicle%20Equipment%20Leasing/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Commercial%20Vehicle%20Equipment%20Leasing",
         "https://www.globenewswire.com/RssFeed/industry/2753-Commercial%20Vehicles%2026%20Trucks/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Commercial%20Vehicles%20and%20Trucks",
         "https://www.globenewswire.com/RssFeed/industry/50206015-Commercial%20Vehicles%20and%20Parts/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Commercial%20Vehicles%20and%20Parts",
         "https://www.globenewswire.com/RssFeed/industry/50101010-Construction/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Construction",
         "https://www.globenewswire.com/RssFeed/industry/2723-Containers%2026%20Packaging/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Containers%20and%20Packaging",
         "https://www.globenewswire.com/RssFeed/industry/2717-Defense/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Defense",
         "https://www.globenewswire.com/RssFeed/industry/2771-Delivery%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Delivery%20Services",
         "https://www.globenewswire.com/RssFeed/industry/2727-Diversified%20Industrials/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Diversified%20Industrials",
         "https://www.globenewswire.com/RssFeed/industry/50202010-Electrical%20Components/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Electrical%20Components",
         "https://www.globenewswire.com/RssFeed/industry/2733-Electrical%20Components%2026%20Equipment/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Electrical%20Components%20and%20Equipment",
         "https://www.globenewswire.com/RssFeed/industry/2737-Electronic%20Equipment/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Electronic%20Equipment",
         "https://www.globenewswire.com/RssFeed/industry/50202020-Electronic%20Equipment%203a%20Control%20and%20Filter/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Electronic%20Equipment%20Control%20and%20Filter",
         "https://www.globenewswire.com/RssFeed/industry/50202025-Electronic%20Equipment%203a%20Gauges%20and%20Meters/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Electronic%20Equipment%20Gauges%20and%20Meters",
         "https://www.globenewswire.com/RssFeed/industry/50202040-Electronic%20Equipment%203a%20Other/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Electronic%20Equipment%20Other",
         "https://www.globenewswire.com/RssFeed/industry/50202030-Electronic%20Equipment%203a%20Pollution%20Control/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Electronic%20Equipment%20Pollution%20Control",
         "https://www.globenewswire.com/RssFeed/industry/50101015-Engineering%20and%20Contracting%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Engineering%20and%20Contracting%20Services",
         "https://www.globenewswire.com/RssFeed/industry/2795-Financial%20Administration/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Financial%20Administration",
         "https://www.globenewswire.com/RssFeed/industry/50205030-Forms%20and%20Bulk%20Printing%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Forms%20and%20Bulk%20Printing%20Services",
         "https://www.globenewswire.com/RssFeed/industry/50203020-Glass/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Glass",
         "https://www.globenewswire.com/RssFeed/industry/2357-Heavy%20Construction/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Heavy%20Construction",
         "https://www.globenewswire.com/RssFeed/industry/2757-Industrial%20Machinery/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Industrial%20Machinery",
         "https://www.globenewswire.com/RssFeed/industry/2797-Industrial%20Suppliers/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Industrial%20Suppliers",
         "https://www.globenewswire.com/RssFeed/industry/50204010-Machinery%203a%20Agricultural/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Machinery%20Agricultural",
         "https://www.globenewswire.com/RssFeed/industry/50204020-Machinery%203a%20Construction%20and%20Handling/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Machinery%20Construction%20and%20Handling",
         "https://www.globenewswire.com/RssFeed/industry/50204030-Machinery%203a%20Engines/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Machinery%20Engines",
         "https://www.globenewswire.com/RssFeed/industry/50204000-Machinery%203a%20Industrial/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Machinery%20Industrial",
         "https://www.globenewswire.com/RssFeed/industry/50204050-Machinery%203a%20Specialty/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Machinery%20Specialty",
         "https://www.globenewswire.com/RssFeed/industry/50204040-Machinery%203a%20Tools/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Machinery%20Tools",
         "https://www.globenewswire.com/RssFeed/industry/2773-Marine%20Transportation/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Marine%20Transportation",
         "https://www.globenewswire.com/RssFeed/industry/50203010-Paints%20and%20Coatings/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Paints%20and%20Coatings",
         "https://www.globenewswire.com/RssFeed/industry/50203015-Plastics/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Plastics",
         "https://www.globenewswire.com/RssFeed/industry/50205020-Professional%20Business%20Support%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Professional%20Business%20Support%20Services",
         "https://www.globenewswire.com/RssFeed/industry/50206025-Railroad%20Equipment/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Railroad%20Equipment",
         "https://www.globenewswire.com/RssFeed/industry/2775-Railroads/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Railroads",
         "https://www.globenewswire.com/RssFeed/industry/50205040-Security%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Security%20Services",
         "https://www.globenewswire.com/RssFeed/industry/50205015-Transaction%20Processing%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Transaction%20Processing%20Services",
         "https://www.globenewswire.com/RssFeed/industry/2777-Transportation%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Transportation%20Services",
         "https://www.globenewswire.com/RssFeed/industry/2779-Trucking/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Trucking",
         "https://www.globenewswire.com/RssFeed/industry/2799-Waste%2026%20Disposal%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Waste%20and%20Disposal%20Services",
         "https://www.globenewswire.com/RssFeed/industry/35-Real%20Estate/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Real%20Estate",
         "https://www.globenewswire.com/RssFeed/industry/8674-Diversified%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Diversified%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/35102010-Health%20Care%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Health%20Care%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/8677-Hotel%2026%20Lodging%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Hotel%20and%20Lodging%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/8671-Industrial%2026%20Office%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Industrial%20and%20Office%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/35102020-Industrial%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Industrial%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/35102025-Infrastructure%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Infrastructure%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/8676-Mortgage%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Mortgage%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/35102030-Office%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Office%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/35102070-Other%20Specialty%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Other%20Specialty%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/8633-Real%20Estate%20Holding%2026%20Development/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Real%20Estate%20Holding%20and%20Development",
         "https://www.globenewswire.com/RssFeed/industry/35101010-Real%20Estate%20Holding%20and%20Development/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Real%20Estate%20Holding%20and%20Development",
         "https://www.globenewswire.com/RssFeed/industry/8637-Real%20Estate%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Real%20Estate%20Services",
         "https://www.globenewswire.com/RssFeed/industry/8673-Residential%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Residential%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/8672-Retail%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Retail%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/8675-Specialty%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Specialty%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/35102050-Storage%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Storage%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/35102060-Timber%20REITs/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Timber%20REITs",
         "https://www.globenewswire.com/RssFeed/industry/9000-Technology/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Technology",
         "https://www.globenewswire.com/RssFeed/industry/9572-Computer%20Hardware/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Computer%20Hardware",
         "https://www.globenewswire.com/RssFeed/industry/9533-Computer%20Services/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Computer%20Services",
         "https://www.globenewswire.com/RssFeed/industry/9574-Electronic%20Office%20Equipment/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Electronic%20Office%20Equipment",
         "https://www.globenewswire.com/RssFeed/industry/9535-Internet/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Internet",
         "https://www.globenewswire.com/RssFeed/industry/10102020-Production%20Technology%20Equipment/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Production%20Technology%20Equipment",
         "https://www.globenewswire.com/RssFeed/industry/9576-Semiconductors/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Semiconductors",
         "https://www.globenewswire.com/RssFeed/industry/9537-Software/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Software",
         "https://www.globenewswire.com/RssFeed/industry/9578-Telecommunications%20Equipment/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Telecommunications%20Equipment",
         "https://www.globenewswire.com/RssFeed/industry/6000-Telecommunications/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Telecommunications",
         "https://www.globenewswire.com/RssFeed/industry/6535-Fixed%20Line%20Telecommunications/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Fixed%20Line%20Telecommunications",
         "https://www.globenewswire.com/RssFeed/industry/6575-Mobile%20Telecommunications/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Mobile%20Telecommunications",
         "https://www.globenewswire.com/RssFeed/industry/7000-Utilities/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Utilities",
         "https://www.globenewswire.com/RssFeed/industry/7537-Alternative%20Electricity/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Alternative%20Electricity",
         "https://www.globenewswire.com/RssFeed/industry/7535-Conventional%20Electricity/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Conventional%20Electricity",
         "https://www.globenewswire.com/RssFeed/industry/7573-Gas%20Distribution/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Gas%20Distribution",
         "https://www.globenewswire.com/RssFeed/industry/7575-Multiutilities/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Multiutilities",
         "https://www.globenewswire.com/RssFeed/industry/7577-Water/feedTitle/GlobeNewswire%20-%20Industry%20News%20on%20Water",


















































};

        //string feedUrl1 = "http://feeds.feedburner.com/techulator/articles";
        //string feedUrl2 = "http://feeds.feedburner.com/anotherfeed"; // Add your second feed here

        public ActionResult Index(int feedId) // Default to feedUrl1 if no feedId is passed
        {
            
            
            string feedUrl = feedUrls[feedId];

            

            
            

                StringBuilder rssContent = new StringBuilder();

                    // Load the selected RSS feed
                    rssContent.Append(LoadRssFeed(feedUrl, feedId));

                    ViewData["strArticle"] = rssContent.ToString();
                    
                    
          


            //try
            //{
            //    StringBuilder rssContent = new StringBuilder();

            //    // Load the selected RSS feed
            //    rssContent.Append(LoadRssFeed(feedUrl, feedId));

            //    ViewData["strArticle"] = rssContent.ToString();
            //    return View(ViewData["strArticle"]);
            //}
            //catch (Exception ex)
            //{
            //    errorString = "An error occurred: " + ex.Message;
            //}

            //var errorResult = new ContentResult();
            //errorResult.Content = errorString;
            //return errorResult;
            return View(ViewData["strArticle"]);
        }

        private string LoadRssFeed(string feedUrl, int feedNumber)
        {
            XmlDocument rssXmlDoc = new XmlDocument();

            // Load the RSS file from the RSS URL
            rssXmlDoc.Load(feedUrl);

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            StringBuilder rssContent = new StringBuilder();
            int i = 0;

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";

                // Alternate background color for different feed entries
                string backgroundColor = (i % 2 == 0) ? "#fffff3" : "white";

                rssContent.Append($"<div style='background: {backgroundColor}'>");
                rssContent.Append($"<h4> <a href='{link}'>{title}</a></h4>");
                rssContent.Append($"<p>{description}</p>");
                rssContent.Append("</div>");
                i++;
            }

            return rssContent.ToString();
        }
    }
}

