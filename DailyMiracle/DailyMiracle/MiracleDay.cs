using System;
using System.Collections.Generic;
using System.Text;

namespace DailyMiracle
{
    public class MiracleDay
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"({Id}), {Date:dd-MM-yy}";
        }
    }
}
