using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppMitAlles
{
    class AutoModel
    {
        // nuget: sqlite-net-pcl 
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Typ { get; set; }
        public string Name { get; set; }
    }
}
