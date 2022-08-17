using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{


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

        public int? Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Duration { get; set; }
    }


}
