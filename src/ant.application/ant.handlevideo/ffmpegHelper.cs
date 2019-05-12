using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ant.handlevideo
{
    public class ffmpegHelper
    {
        public static string GetVideoTotalTime(string fileName)
        {
            string result = string.Empty;
            using (System.Diagnostics.Process pro = new System.Diagnostics.Process())
            {
                pro.StartInfo.UseShellExecute = false;
                pro.StartInfo.ErrorDialog = false;
                pro.StartInfo.CreateNoWindow = true;
                pro.StartInfo.RedirectStandardError = true;
                pro.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "ffmpeg.exe";
                pro.StartInfo.Arguments = " -i " + fileName;
                pro.Start();
                System.IO.StreamReader errorreader = pro.StandardError;
                pro.WaitForExit(1000);
                result = errorreader.ReadToEnd();
                if (!string.IsNullOrEmpty(result))
                    if (result.Contains("Duration: "))
                        result = result.Substring(result.IndexOf("Duration: ") + ("Duration: ").Length, ("00:00:00").Length);
            }
            return result;
        }

        public static void FlvToMp4(string filePathFlv, string filePathMP4)
        {
            string arguments = string.Empty;
            arguments = string.Format(" -i {0} {1} ", filePathFlv, filePathMP4);
            Tts(arguments);
        }
        public static void Cut(string filePath, string timeStart, string timeEnd, string filePathOut)
        {
            string arguments = string.Empty;
            if (string.IsNullOrEmpty(timeEnd))
                arguments = string.Format(" -i {0} -vcodec copy -acodec copy -ss {1} {2} -y", filePath, timeStart, filePathOut);
            else
                arguments = string.Format(" -i {0} -vcodec copy -acodec copy -ss {1} -to {2} {3} -y", filePath, timeStart, timeEnd, filePathOut);
            Tts(arguments);
        }

        public static void Splice(List<string> sourcePaths, string pathSplice)
        {
            //string pathSplice = string.Empty;
            var tsPaths = new List<string>() { };
            string tsPath = string.Empty;
            string arguments = string.Empty;
            foreach (var path in sourcePaths)
            {
                tsPath = path.Replace(".mp4", ".ts");
                tsPaths.Add(tsPath);

                arguments = string.Format(@" -i {0} -c copy -vbsf h264_mp4toannexb {1} -y ", path, tsPath);
                Tts(arguments);
            }
            arguments = string.Empty;
            arguments = string.Join("|", tsPaths.ToArray());
            arguments = string.Format("-i \"concat:{0}\" -c copy -absf aac_adtstoasc {1} -y ", arguments, pathSplice);
            Tts(arguments);

            tsPaths.ForEach(path =>
            {
                if (File.Exists(path))
                    File.Delete(path);
            });
        }



        static string pathFfmpeg
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "ffmpeg.exe"; }
        }

        static void Tts(string StrArg)
        {
            Process p = new Process();//建立外部调用线程
            p.StartInfo.FileName = pathFfmpeg;// Application.StartupPath + "\\ffmpeg.exe";//要调用外部程序的绝对路径

            p.StartInfo.Arguments = StrArg;

            p.StartInfo.UseShellExecute = false;//不使用操作系统外壳程序启动线程(一定为FALSE,详细的请看MSDN)
            p.StartInfo.RedirectStandardError = true;//把外部程序错误输出写到StandardError流中(这个一定要注意,FFMPEG的所有输出信息,都为错误输出流,用StandardOutput是捕获不到任何消息的...这是我耗费了2个多月得出来的经验...mencoder就是用standardOutput来捕获的)
            p.StartInfo.CreateNoWindow = true;//不创建进程窗口
            p.ErrorDataReceived += new DataReceivedEventHandler(Output);//外部程序(这里是FFMPEG)输出流时候产生的事件,这里是把流的处理过程转移到下面的方法中,详细请查阅MSDN
            p.Start();//启动线程
            p.BeginErrorReadLine();//开始异步读取
            p.WaitForExit();//阻塞等待进程结束
            p.Close();//关闭进程
            p.Dispose();//释放资源
        }
        private static void Output(object sendProcess, DataReceivedEventArgs output)
        {
            if (!String.IsNullOrEmpty(output.Data))
            {
                //处理方法...
                //Console.WriteLine(output.Data);
            }
        }


    }
}
