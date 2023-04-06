using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Xml;
using System.ServiceModel.Syndication;
using System.Security;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace RssExample.Controllers
{
    public class HomeController : Controller
    {
        XmlReader reader = XmlReader.Create("http://feeds.feedburner.com/techulator/articles");
        public static string  strArticle;


        //SyndicationFeed feed = SyndicationFeed.Load("");
        public ActionResult Index(string feed)
        {
            string errorString = "";

            try
            {
                
               
                {
                    XmlDocument rssXmlDoc = new XmlDocument();

                    // Load the RSS file from the RSS URL
                    rssXmlDoc.Load("http://feeds.feedburner.com/techulator/articles");

                    // Parse the Items in the RSS file
                    XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

                    StringBuilder rssContent = new StringBuilder();
                    int i = 0;

                    // Iterate through the items in the RSS file
                   
                    foreach (XmlNode rssNode in rssNodes)
                    {
                        i++;
                        XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                        string title = rssSubNode != null ? rssSubNode.InnerText : "";

                        rssSubNode = rssNode.SelectSingleNode("link");
                        string link = rssSubNode != null ? rssSubNode.InnerText : "";

                        rssSubNode = rssNode.SelectSingleNode("description");
                        string description = rssSubNode != null ? rssSubNode.InnerText : "";
                        if (i%2==0)
                        {
                            
                             rssContent.Append("<div style = 'background: #fffff3'><a href='" + link + "'>" + title + "</a><br>" + description + "<br><p></div> ");

                        }
                        else
                        {
                            rssContent.Append("<div style = 'background: white'><a href='" + link + "'>" + title + "</a><br>" + description + "<br><p></div>");

                        }
                   
                    ViewData["strArticle"] = rssContent.ToString(); 
                    return View(ViewData["strArticle"]);
                }
            }
            catch (ArgumentNullException)
            {
                errorString = "No url for Rss feed specified.";
            }
            catch (SecurityException)
            {
                errorString = "You do not have permission to access the specified Rss feed.";
            }
            catch (FileNotFoundException)
            {
                errorString = "The Rss feed was not found.";
            }
            catch (UriFormatException)
            {
                errorString = "The Rss feed specified was not a valid URI.";
            }
            catch (Exception)
            {
                errorString = "An error occured accessing the RSS feed.";
            }

            var errorResult = new ContentResult();
            errorResult.Content = errorString;
            return errorResult;

        }
    }
}