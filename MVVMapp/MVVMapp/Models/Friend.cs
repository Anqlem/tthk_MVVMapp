using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MVVMapp.Models
{
    [Table("Friends")]
    public class Friend
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}
