using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class TopicManage
    {
        /// <summary>
        /// 根据表名查找所有题目
        /// </summary>
        /// <param name="tabname">表名</param>
        /// <returns></returns>
        public static DataTable GetTopicByTabName(string tabname)
        {
            string sql = $"select * from {tabname}";

            return DBHelper.Find(sql);
        }

        /// <summary>
        /// 根据表名获取题目总数
        /// </summary>
        /// <param name="tabname"></param>
        /// <returns></returns>
        public static DataTable GetTopicTotal(string tabname)
        {
            string sql = $"select topicid from {tabname}";

            return DBHelper.Find(sql);
        }

        /// <summary>
        /// 根据表名获取随机题目
        /// </summary>
        /// <param name="tabname"></param>
        /// <returns></returns>
        public static DataTable GetRandomTopic(string tabname)
        {
            string sql = $"select * from {tabname} order by newid()";

            return DBHelper.Find(sql);
        }

        /// <summary>
        /// 根据题目id
        /// </summary>
        /// <param name="topicid"></param>
        /// <returns></returns>
        public static DataTable GetTopicAnswareById(string tabname,int topicid)
        {
            string sql = $"select Rig from {tabname} where TopicId = {topicid}";

            return DBHelper.Find(sql);
        }

        /// <summary>
        /// 获取单选或者多选题
        /// </summary>
        /// <param name="tabname">表名</param>
        /// <param name="isdanxuan">是否是单选</param>
        /// <returns></returns>
        public static DataTable GetTopic(string tabname,string isdanxuan)
        {
            // 单选
            if (isdanxuan == "1")
            {
                string sql = $" select * from {tabname} where DATALENGTH(rig) = 2";
                return DBHelper.Find(sql);
            }
            else
            {
                string sql = $" select * from {tabname} where DATALENGTH(rig) > 2";
                return DBHelper.Find(sql);
            }
        }

        /// <summary>
        /// 根据对应的题目id更新是否此题目是否答对
        /// </summary>
        /// <param name="tabname">题目表名称</param>
        /// <param name="TopicId">题目Id</param>
        /// <returns></returns>
        public static bool UpdateTopicIsRight(string tabname,int TopicId,string topicstatu)
        {
            string sql = $"update {tabname} set IsRight = '{topicstatu}' where TopicId = {TopicId}";
            return DBHelper.Execute(sql);
        }

        /// <summary>
        /// 更新试卷状态为重做
        /// </summary>
        /// <param name="tabname">试卷名称</param>
        /// <returns></returns>
        public static bool UpdateTopicStatus(string tabname)
        {
            // 将每个试题状态全部重置为0
            string sql = $"update {tabname} set IsRight = '0'";
            return DBHelper.Execute(sql);
        }
    }
}
