using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackatonBot.BookBot
{

   public class BookLuis
   {
      public string query { get; set; }
      public Topscoringintent topScoringIntent { get; set; }
      public Entity[] entities { get; set; }
      public Dialog dialog { get; set; }
   }

   public class Entity
   {
      public string entity { get; set ; }

      public string startIndex { get; set; }

      public string endIndex { get; set; }
      public string type { get; set; }

      public float score { get; set; }
   }

   public class Topscoringintent
   {
      public string intent { get; set; }
      public float score { get; set; }
      public Action[] actions { get; set; }
   }

   public class Action
   {
      public bool triggered { get; set; }
      public string name { get; set; }
      public object[] parameters { get; set; }
   }

   public class Dialog
   {
      public string contextId { get; set; }
      public string status { get; set; }
   }

}