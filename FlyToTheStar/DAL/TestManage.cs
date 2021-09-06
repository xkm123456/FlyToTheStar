using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DAL
{
    public class TestManage
    {
        /// <summary>
         /// 根据试卷id删除考试
         /// </summary>
         /// <param name="examid">考试id</param>
         /// <returns></returns>
        public static bool DelTestByExamId(int examid)
        {
            // 先查询是否有这个考试，如果没有就不删除
            string findexamsql = $"select * from TestInfo where TopicId = {examid}";
            DataTable dt = DBHelper.Find(findexamsql);

            // 有考试再删除此考试
            if(dt.Rows.Count > 0)
            {
                string sql = $"delete from TestInfo where TopicId = {examid}";
                return DBHelper.Execute(sql);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取所有的考试
        /// </summary>
        /// <returns>所有考试对象的集合</returns>
        public static List<TestInfo> GetAllTestInfo()
        {
            // 保存所有考试对象
            List<TestInfo> testinfolist = new List<TestInfo>();
            string sql = "select * from TestInfo";
            DataTable dt = DBHelper.Find(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TestInfo testInfo = new TestInfo()
                {
                    TestId = int.Parse(dt.Rows[i]["TestId"].ToString()),
                    TestName = dt.Rows[i]["TestName"].ToString(),
                    TopicId = int.Parse(dt.Rows[i]["TopicId"].ToString()),
                    TestTime = int.Parse(dt.Rows[i]["TestTime"].ToString()),
                    TestPassScore = int.Parse(dt.Rows[i]["TestPassScore"].ToString()),
                    TestScore = int.Parse(dt.Rows[i]["TestScore"].ToString())
                };
                testinfolist.Add(testInfo);
            }
            return testinfolist;
        }

        /// <summary>
        /// 插入考试信息到数据库的TestInfo表中
        /// </summary>
        /// <param name="testInfo"></param>
        /// <returns></returns>
        public static bool InsertTestInfo(TestInfo testInfo)
        {
            string sql = $"insert into TestInfo values('{testInfo.TestName}'," +
                $"{testInfo.TopicId},{testInfo.TestTime},{testInfo.TestPassScore},{testInfo.TestScore})";
            
            return DBHelper.Execute(sql);
        }

        /// <summary>
        /// 根据考试名称查询考试
        /// </summary>
        /// <param name="testname">考试名称</param>
        /// <returns></returns>
        public static DataTable FindTestByTestName(string testname)
        {
            
            string sql = $"select * from TestInfo where TestName = '{testname}'";
            
            return DBHelper.Find(sql);
        }

        /// <summary>
        /// 根据考试id删除对应考试
        /// </summary>
        /// <param name="testid"></param>
        /// <returns></returns>
        public static bool DelTestByTestId(int testid)
        {
            string sql = $"delete from TestInfo where TestId = {testid}";

            return DBHelper.Execute(sql);
        }
    }
}
