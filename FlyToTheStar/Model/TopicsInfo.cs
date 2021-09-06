using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TopicsInfo
    {
        public int ExamId { get; set; }
        public string ExamTabName { get; set; }
        public int ExamClass { get; set; }
        public int TopicCount { get; set; }
        public int Creator { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
