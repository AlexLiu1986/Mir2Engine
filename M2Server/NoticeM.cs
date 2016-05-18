using System;
using System.Collections.Generic;
using System.IO;
using GameFramework;

namespace M2Server
{
    public class TNoticeMsg
    {
        public string sMsg;
        // 公告文件路径
        public TStringList sList;
    }

    public class TNoticeManager
    {
        private TNoticeMsg[] NoticeList;

        public TNoticeManager()
        {
            NoticeList = new TNoticeMsg[10];
            for (int I = NoticeList.GetLowerBound(0); I <= NoticeList.GetUpperBound(0); I ++ )
            {
                NoticeList[I] = new TNoticeMsg();
                NoticeList[I].sMsg = "";
                NoticeList[I].sList = new TStringList();
            }
        }
        
        ~TNoticeManager()
        {
            if (NoticeList != null)
            {
                //for (int I = NoticeList.GetLowerBound(0); I <= NoticeList.GetUpperBound(0); I++)
                //{
                    //if (NoticeList[I].sList != null)
                    //{
                        //NoticeList[I].sList.Free;
                    //}
                //}
            }
        }

        /// <summary>
        /// 加载公告
        /// </summary>
        public void LoadingNotice()
        {
            string sFileName;
            for (int I = NoticeList.GetLowerBound(0); I <= NoticeList.GetUpperBound(0); I ++ )
            {
                if (NoticeList[I].sMsg == "")
                {
                    continue;
                }
                sFileName = M2Share.g_Config.sNoticeDir + NoticeList[I].sMsg + ".txt";
                if (File.Exists(sFileName))
                {
                    try {
                        if (NoticeList[I].sList == null)
                        {
                            NoticeList[I].sList = new TStringList();
                        }
                        NoticeList[I].sList.LoadFromFile(sFileName);
                    }
                    catch {
                        M2Share.MainOutMessage("读取文本内容错误,文件名:" + sFileName);
                    }
                }
            }
        }

        /// <summary>
        /// 取公告内容
        /// </summary>
        /// <param name="sStr"></param>
        /// <param name="LoadList"></param>
        /// <returns></returns>
        public bool GetNoticeMsg(string sStr, List<string> LoadList)
        {
            bool result = false;
            int n14;
            string sFileName;
            for (n14 = NoticeList.GetLowerBound(0); n14 <= NoticeList.GetUpperBound(0); n14 ++ )
            {
                if ((NoticeList[n14].sMsg).ToLower().CompareTo((sStr).ToLower()) == 0)
                {
                    if (NoticeList[n14].sList != null)
                    {
                        for (int i = 0; i < NoticeList[n14].sList.Count; i++)
                        {
                            LoadList.Add(NoticeList[n14].sList[i]);
                        }
                        result = true;
                    }
                    return result;
                }
            }
            for (n14 = NoticeList.GetLowerBound(0); n14 <= NoticeList.GetUpperBound(0); n14 ++ )
            {
                if (NoticeList[n14].sMsg == "")
                {
                    sFileName = M2Share.g_Config.sNoticeDir + sStr + ".txt";
                    if (File.Exists(sFileName))
                    {
                        try {
                            if (NoticeList[n14].sList == null)
                            {
                                NoticeList[n14].sList = new TStringList();
                            }
                            NoticeList[n14].sList.LoadFromFile(sFileName,true);
                            for (int i = 0; i < NoticeList[n14].sList.Count; i++)
                            {
                                LoadList.Add(NoticeList[n14].sList[i]);
                            }
                        }
                        catch {
                            M2Share.MainOutMessage("读取文本内容错误,文件名为: " + sFileName);
                        }
                        NoticeList[n14].sMsg = sStr;
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
    }
}

