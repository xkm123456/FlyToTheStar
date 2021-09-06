using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    /// <summary>
    /// 题库练习管理类
    /// </summary>
    public class TopicsManage
    {
        /// <summary>
        /// 根据试卷名称删除题库
        /// </summary>
        /// <param name="examName">考试名称</param>
        /// <returns></returns>
        public static bool DelTopicsByExamName(string examName)
        {
            string sql = $"drop table {examName}";
            return DBHelper.DelTable(sql,examName);
        }

        /// <summary>
        /// 向TopicInfo表中插入题目
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool InsertTopic(string sql)
        {
            return DBHelper.Execute(sql);
        }

        /// <summary>
        /// 向TopicsInfo表中插入TopicInfo表的信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool InsertTopics(string sql)
        {
            return DBHelper.Execute(sql);
        }

        /// <summary>
        /// 根据试卷id查找对应表名
        /// </summary>
        /// <param name="examid"></param>
        /// <returns></returns>
        public static DataTable GetTopicsTabNameByExamId(int examid)
        {
            string sql = $"select ExamTabName from TopicsInfo where ExamId = {examid}";
            return DBHelper.Find(sql);
        }
    }
}
