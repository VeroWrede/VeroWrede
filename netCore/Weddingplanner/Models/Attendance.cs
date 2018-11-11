using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Weddingplanner.Models
{
    public class Attendance
    {
        public int AttendanceId {get; set;}

        public int PersonId {get; set;}

        public int WeddingId {get; set;}

        public Person Person {get; set;}

        public Wedding Wedding {get; set;}
    }
}