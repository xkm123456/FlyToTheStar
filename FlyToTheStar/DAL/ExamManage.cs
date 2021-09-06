using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DAL
{
    public class ExamManage
    {
        /// <summary>
        /// 返回所有试卷对象的集合
        /// </summary>
        /// <returns>试卷对象的集合</returns>
        public static List<TopicsInfoExt> GetAllExam()
        {
            // 保存试卷对象的集合
            List<TopicsInfoExt> topicsList = new List<TopicsInfoExt>();
            string sql = "select t.ExamId,t.ExamTabName,ty.ClassName,t.TopicCount,u.UserName,t.CreateTime from TopicsInfo t,UserInfo u,TopicClass ty "+
                         "where t.Creator = u.UserId and t.ExamClass = ty.ClassId";
            DataTable dt = DBHelper.Find(sql);

            // 遍历查询到的试卷表的数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TopicsInfoExt topics = new TopicsInfoExt()
                {
                    ExamId = int.Parse(dt.Rows[i][0].ToString()),
                    ExamTabName = dt.Rows[i][1].ToString(),
                    ExamClass = dt.Rows[i][2].ToString(),
                    TopicCount = int.Parse(dt.Rows[i][3].ToString()),
                    Creator = dt.Rows[i][4].ToString(),
                    CreateTime = DateTime.Parse(dt.Rows[i][5].ToString())
                };
                topicsList.Add(topics);
            }
            return topicsList;
        }

        /// <summary>
        /// 根据试卷id删除试卷
        /// </summary>
        /// <param name="examid">试卷id</param>
        /// <returns></returns>
        public static bool DelExamById(int examid)
        {
            string sql = $"delete from TopicsInfo where ExamId = {examid}";
            return DBHelper.Execute(sql);
        }

        /// <summary>
        /// 获取所有试卷的类型
        /// </summary>
        /// <returns></returns>
        public static List<TopicClass> GetAllTopicClass()
        {
            List<TopicClass> topics = new List<TopicClass>();
            string sql = "select * from TopicClass";
            DataTable dt = DBHelper.Find(sql);
            // 遍历查询到的试卷表的数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TopicClass top = new TopicClass()
                {
                    ClassId = int.Parse(dt.Rows[i][0].ToString()),
                    ClassName = dt.Rows[i][1].ToString()
                };
                topics.Add(top);
            }
            return topics;
        }

        /// <summary>
        /// 根据试卷名称查找对应试卷
        /// </summary>
        /// <returns></returns>
        public static List<TopicsInfoExt> GetTopicsInfoByExamName(string examname)
        {
            List<TopicsInfoExt> topics = new List<TopicsInfoExt>();
            string sql = "select t.ExamId,t.ExamTabName,ty.ClassName,t.TopicCount,u.UserName,t.CreateTime from TopicsInfo t,UserInfo u,TopicClass ty " +
                         $"where t.Creator = u.UserId and t.ExamClass = ty.ClassId and t.ExamTabName like '%{examname}%'";
            
            DataTable dt = DBHelper.Find(sql);
            // 遍历查询到的试卷表的数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TopicsInfoExt tops = new TopicsInfoExt()
                {
                    ExamId = int.Parse(dt.Rows[i][0].ToString()),
                    ExamTabName = dt.Rows[i][1].ToString(),
                    ExamClass = dt.Rows[i][2].ToString(),
                    TopicCount = int.Parse(dt.Rows[i][3].ToString()),
                    Creator = dt.Rows[i][4].ToString(),
                    CreateTime =DateTime.Parse(dt.Rows[i][5].ToString())
                };
                topics.Add(tops);
            }
            return topics;
        }
    }
}
