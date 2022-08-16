using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{

    [Table("CodingSession")]
    internal class CodingSession
    {

        private static CodingSession _codingSession;

         public CodingSession()
         {

         }

        public static CodingSession GetInstance()
        {
            if (_codingSession == null)
            {
                _codingSession = new CodingSession();
            }
            return _codingSession;
        }

        [Key]
        public int? Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public DateTime Duration { get; set; }
    }


}
