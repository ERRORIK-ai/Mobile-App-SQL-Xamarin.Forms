using SQLite;
using System;

namespace M335.Models
{
    public class Item
    {
        //Primariy Key für die DB ist immer Unique
        [PrimaryKey, SQLite.Unique, SQLite.AutoIncrement]
        public int Id
        {
            get; set;
        }


        [SQLite.NotNull, SQLite.MaxLength(100)]
        public string Title
        {
            get; set;
        }

        [SQLite.NotNull, SQLite.MaxLength(100)]
        public string Name
        {
            get; set;
        }

        [SQLite.NotNull, SQLite.MaxLength(4)]
        public int Year
        {
            get; set;
        }
    }
}