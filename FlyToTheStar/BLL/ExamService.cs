using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class ExamService
    {
        /// <summary>
        /// 返回所有试卷对象的集合
        /// </summary>
        /// <returns>试卷对象的集合</returns>
        public static List<TopicsInfoExt> GetAllExam()
        {
            return ExamManage.GetAllExam();
        }


        /// <summary>
        /// 根据试卷id删除试卷
        /// </summary>
        /// <param name="examid">试卷id</param>
        /// <returns></returns>
        public static bool DelExamById(int examid)
        {
            return ExamManage.DelExamById(examid);
        }

        /// <summary>
        /// 获取所有试卷的类型
        /// </summary>
        /// <returns></returns>
        public static List<TopicClass> GetAllTopicClass()
        {
            return ExamManage.GetAllTopicClass();
        }

        /// <summary>
        /// 根据试卷名称查找对应试卷
        /// </summary>
        /// <returns></returns>
        public static List<TopicsInfoExt> GetTopicsInfoByExamName(string examname)
        {
            return ExamManage.GetTopicsInfoByExamName(examname);
        }
    }
}
