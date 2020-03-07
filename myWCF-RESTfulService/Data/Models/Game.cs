using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace myWCF_RESTfulService.Data.Models
{

        [DataContract]
        public class Game
    {
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string Title { get; set; }
            [DataMember]
            public string Genre { get; set; }
            [DataMember]
            public string Developer { get; set; }
            [DataMember]
            public string Publisher { get; set; }
            [DataMember]
            public int Year { get; set; }

        }
    }

