﻿namespace HackatonBot.AndysOrder.Models
{
    public class PizzaLuisModel
    {
        public string query { get; set; }
        public Topscoringintent topScoringIntent { get; set; }
        public Entity[] entities { get; set; }
    }

    public class Topscoringintent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public float score { get; set; }
    }

}