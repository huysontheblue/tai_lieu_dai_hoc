using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace SysBasicClass
{
    /// <summary>
    /// 带进度条等待方法--by hs ke 2017-3-10  
    /// 调用方法--》SysBasicClass.WaitFormService.CreateWaitForm("等待中...");......begin这里做数据操作end......SysBasicClass.WaitFormService.CloseWaitForm()
    /// </summary>
       public class WaitFormService
        {
           /// <summary>
           /// 创建等待窗口并写入提示文字
           /// </summary>
           /// <param name="str">提示文字</param>
           public static void CreateWaitForm(string text)
            {
                WaitFormService.Instance.CreateForm(text);
            }
           /// <summary>
           /// 创建等待窗口并写入提示文字
           /// </summary>
           /// <param name="str">提示文字</param>
           public static void CreateWaitForm()
           {
               WaitFormService.Instance.CreateForm("");
           }
            public static void CloseWaitForm()
            {
                WaitFormService.Instance.CloseForm();
            }
           /// <summary>
           /// 提示文字
           /// </summary>
           /// <param name="text">提示文字</param>
            public static void SetWaitFormCaption(string text)
            {
                WaitFormService.Instance.SetFormCaption(text);
            }
           
            private static WaitFormService _instance;
            private static readonly Object syncLock = new Object();

            public static WaitFormService Instance
            {
                get
                {
                    if (WaitFormService._instance == null)
                    {
                        lock (syncLock)
                        {
                            if (WaitFormService._instance == null)
                            {
                                WaitFormService._instance = new WaitFormService();
                            }
                        }
                    }
                    return WaitFormService._instance;
                }
            }

            private WaitFormService()
            {
            }

            private Thread waitThread;
            private waitForm waitFM;

            public void CreateForm(string text)
            {
                if (waitThread != null)
                {
                    try
                    {
                        //waitThread.Abort();
                        waitThread = null;
                        waitFM = null;
                    }
                    catch (Exception)
                    {
                    }
                }

                waitThread = new Thread(new ThreadStart(delegate()
                {
                    waitFM = new waitForm(text);
                    System.Windows.Forms.Application.Run(waitFM);
                }));
                waitThread.Start();
            }

            public void CloseForm()
            {                
                if (waitThread != null  )
                {
                    try
                    {
                        ////
                        waitFM.SetText("close");
                        //waitThread.Abort();
                        waitThread = null;
                        waitFM = null;
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(800);
                        waitFM.SetText("close");
                        waitThread = null;
                        waitFM = null;

                    }
                }
            }

            public void SetFormCaption(string text)
            {
                if (waitFM != null)
                {
                    try
                    {
                        waitFM.SetText(text);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
