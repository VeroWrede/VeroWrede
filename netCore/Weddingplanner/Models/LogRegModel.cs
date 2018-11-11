using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Weddingplanner.Models
{
    public class LogRegModel
    {
        public Person Register { get; set; }

        public LoginUser Login { get; set; }
    }
}