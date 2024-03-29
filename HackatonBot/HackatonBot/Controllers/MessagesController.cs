﻿namespace HackatonBot
{
   using System;
   using System.Net;
   using System.Net.Http;
   using System.Threading.Tasks;
   using System.Web.Http;
   using Microsoft.Bot.Connector;

   [BotAuthentication]
   public class MessagesController : ApiController
   {
      #region Public members

      /// <summary>
      /// POST: api/Messages
      /// Receive a message from a user and reply to it
      /// </summary>
      public async Task<HttpResponseMessage> Post([FromBody] Activity activity)
      {
         if (activity.Type == ActivityTypes.Message)
         {
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;
            // return our reply to the user
            Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
            await connector.Conversations.ReplyToActivityAsync(reply);
         }
         else
            HandleSystemMessage(activity);
         HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
         return response;
      }

      #endregion

      #region Non-public members

      private Activity HandleSystemMessage(Activity message)
      {
         if (message.Type == ActivityTypes.DeleteUserData)
         {
            // Implement user deletion here
            // If we handle user deletion, return a real message
         }
         else if (message.Type == ActivityTypes.ConversationUpdate)
         {
            // Handle conversation state changes, like members being added and removed
            // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
            // Not available in all channels
         }
         else if (message.Type == ActivityTypes.ContactRelationUpdate)
         {
            // Handle add/remove from contact lists
            // Activity.From + Activity.Action represent what happened
         }
         else if (message.Type == ActivityTypes.Typing)
         {
            // Handle knowing tha the user is typing
         }
         else if (message.Type == ActivityTypes.Ping)
         {
         }

         return null;
      }

      #endregion
   }
}