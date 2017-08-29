using SQLite;
using System;

namespace PokeApp.Data.Models
{
    public class ResourceModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public string Url { get; set; }

        [Indexed]
        public DateTime CreatedAt { get; set; }

        public string Body { get; set; }
    }
}
