﻿using SQLite;
using SQLiteDemo.Abstractions;
using SQLiteNetExtensions.Attributes;
using System.Reflection.Metadata.Ecma335;

namespace SQLiteDemo.MVVM.Models
{
    [Table("Customers")]
    public class Customer : TableData
    {
        
        [Column("name"), Indexed, NotNull]
        public string Name { get; set; }
        [Unique]
        public string Phone { get; set; }
        public int Age { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [Ignore]
        public bool IsYoung => Age > 50 ? true : false;

        [ManyToMany(typeof(Passport),  CascadeOperations = CascadeOperation.All)]
        public List<Passport> Passport { get; set; }
    }
}
