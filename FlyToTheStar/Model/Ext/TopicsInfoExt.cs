using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 试卷扩展类（即多表查询之后的类）
    /// </summary>
    public class TopicsInfoExt
    {
        public int ExamId { get; set; }
        public string ExamTabName { get; set; }
        public string ExamClass { get; set; }
        public int TopicCount { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
