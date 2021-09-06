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
    public class TestSerivce
    {

        /// <summary>
        /// 根据试卷id删除考试
        /// </summary>
        /// <param name="examid">考试id</param>
        /// <returns></returns>
        public static bool DelTestByExamId(int examid)
        {
            return TestManage.DelTestByExamId(examid);
        }

        /// <summary>
        /// 获取所有的考试
        /// </summary>
        /// <returns>所有考试对象的集合</returns>
        public static List<TestInfo> GetAllTestInfo()
        {
            return TestManage.GetAllTestInfo();
        }

        /// <summary>
        /// 插入考试信息到数据库的TestInfo表中
        /// </summary>
        /// <param name="testInfo"></param>
        /// <returns></returns>
        public static bool InsertTestInfo(TestInfo testInfo)
        {
            return TestManage.InsertTestInfo(testInfo);
        }


        /// <summary>
        /// 根据考试名称查询考试
        /// </summary>
        /// <param name="testname">考试名称</param>
        /// <returns></returns>
        public static DataTable FindTestByTestName(string testname)
        {
            return TestManage.FindTestByTestName(testname);
        }

        /// <summary>
        /// 根据考试id删除对应考试
        /// </summary>
        /// <param name="testid"></param>
        /// <returns></returns>
        public static bool DelTestByTestId(int testid)
        {
            return TestManage.DelTestByTestId(testid);
        }
    }
}
