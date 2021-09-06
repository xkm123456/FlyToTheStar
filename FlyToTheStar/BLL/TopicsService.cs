using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class TopicsService
    {

        /// <summary>
        /// 根据试卷名称删除题库
        /// </summary>
        /// <param name="examName">考试名称</param>
        /// <returns></returns>
        public static bool DelTopicsByExamName(string examName)
        {
            return TopicsManage.DelTopicsByExamName(examName);
        }

        /// <summary>
        /// 向TopicInfo表中插入题目
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool InsertTopic(string sql)
        {
            return TopicsManage.InsertTopic(sql);
        }

        /// <summary>
        /// 向TopicsInfo表中插入TopicInfo表的信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool InsertTopics(string sql)
        {
            return TopicsManage.InsertTopics(sql);
        }

        /// <summary>
        /// 根据试卷id查找对应表名
        /// </summary>
        /// <param name="examid"></param>
        /// <returns></returns>
        public static DataTable GetTopicsTabNameById(int examid)
        {
            return TopicsManage.GetTopicsTabNameByExamId(examid);
        }
    }
}
