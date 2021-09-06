using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TestInfo
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int TopicId { get; set; }
        public int TestTime { get; set; }
        public int TestPassScore { get; set; }
        public int TestScore { get; set; }
    }
}
