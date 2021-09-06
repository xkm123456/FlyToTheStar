using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class TopicService
    {
        /// <summary>
        /// 根据表名查找所有题目
        /// </summary>
        /// <param name="tabname">表名</param>
        /// <returns></returns>
        public static DataTable GetTopicByTabName(string tabname)
        {
            return TopicManage.GetTopicByTabName(tabname);
        }

        /// <summary>
        /// 根据表名获取题目总数
        /// </summary>
        /// <param name="tabname"></param>
        /// <returns></returns>
        public static DataTable GetTopicTotal(string tabname)
        {
            return TopicManage.GetTopicTotal(tabname);
        }

        /// <summary>
        /// 根据表名获取随机题目
        /// </summary>
        /// <param name="tabname"></param>
        /// <returns></returns>
        public static DataTable GetRandomTopic(string tabname)
        {
            return TopicManage.GetRandomTopic(tabname);
        }

        /// <summary>
        /// 根据题目id
        /// </summary>
        /// <param name="topicid"></param>
        /// <returns></returns>
        public static DataTable GetTopicAnswareById(string tabname, int topicid)
        {
            return TopicManage.GetTopicAnswareById(tabname,topicid);
        }

        /// <summary>
        /// 获取单选或者多选题
        /// </summary>
        /// <param name="tabname">表名</param>
        /// <param name="isdanxuan">是否是单选</param>
        /// <returns></returns>
        public static DataTable GetTopic(string tabname, string isdanxuan)
        {
            return TopicManage.GetTopic(tabname,isdanxuan);
        }

        /// <summary>
        /// 根据对应的题目id更新是否此题目是否答对
        /// </summary>
        /// <param name="tabname">题目表名称</param>
        /// <param name="TopicId">题目Id</param>
        /// <returns></returns>
        public static bool UpdateTopicIsRight(string tabname, int TopicId, string topicstatu)
        {
            return TopicManage.UpdateTopicIsRight(tabname,TopicId,topicstatu);
        }

        /// <summary>
        /// 更新试卷状态为重做
        /// </summary>
        /// <param name="tabname">试卷名称</param>
        /// <returns></returns>
        public static bool UpdateTopicStatus(string tabname)
        {
            return TopicManage.UpdateTopicStatus(tabname);
        }
    }
}
