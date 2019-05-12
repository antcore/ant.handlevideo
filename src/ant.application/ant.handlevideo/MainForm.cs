using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using YouTubeApiRestClient.Views;
using System.Text.RegularExpressions;

namespace ant.handlevideo
{
    public partial class MainForm : Form
    {
        const string VIDEO_CUT = "VIDEO_CUT_";
        const string VIDEO_SPLICE = "VIDEO_SPLICE_";

        string videoPathHeader
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "videoHeader.mp4"; }
        }
        string videoPathFloor
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "videoFloor.mp4"; }
        }
        string pathConf
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "Conf.txt"; }
        }

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            cboIsAutoCutVideo.Checked = true;

            //txtVideoPath.Text = @"C:\QLDownload\听雪楼";
        }

        private void btnHandleVideo_Click(object sender, EventArgs e)
        {
            string pathHandleVideo = string.Empty;
            pathHandleVideo = txtVideoPath.Text;
            if (!Directory.Exists(pathHandleVideo))
            {
                HandleMessage.Show(string.Format(@"处理文件路径 {0} 不存在", pathHandleVideo));
                return;
            }
            if (ContainChinese(pathHandleVideo))
            {
                HandleMessage.Show(string.Format(@"处理文件路径 {0} 包含了中文", pathHandleVideo));
                return;
            }
            var fitterExtensions = new List<string>()
            {
                ".mp4",
            };

            var dir = new DirectoryInfo(pathHandleVideo);
            var files = dir.GetFiles();
            var filePath = string.Empty;
            foreach (var item in files)
            {
                if (item.Name.Contains(VIDEO_CUT) || item.Name.Contains(VIDEO_SPLICE))
                {
                    File.Delete(item.FullName);
                    continue;
                }

                filePath = PingYinHelper.ConvertToAllSpell(item.Name);
                filePath = filePath.Replace(" ", "");
                filePath = filePath.Replace("(", "").Replace(")", "");
                filePath = filePath.Replace("（", "").Replace("）", "");
                filePath = filePath.Replace(".qlv", "");
                item.MoveTo(Path.Combine(item.DirectoryName, filePath));
            }

            dir = new DirectoryInfo(pathHandleVideo);
            files = dir.GetFiles();
            foreach (var item in files)
                if (fitterExtensions.Contains(item.Extension) && !ContainChinese(item.FullName))
                    if (!(item.Name.Contains(VIDEO_CUT) || item.Name.Contains(VIDEO_SPLICE)))
                        HandleVideo(item);
        }

        bool ContainChinese(string input)
        {
            string pattern = "[\u4e00-\u9fbb]";
            return Regex.IsMatch(input, pattern);
        }

        public void HandleVideo(FileInfo file)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            HandleMessage.Show("================================== START ==================================");
            HandleMessage.Show(string.Format("开始文件处理 {0}", file.FullName));

            string filePath = file.FullName;
            string filePathOutCut = string.Empty;
            string filePathOutSplice = string.Empty;
            filePathOutCut = string.Format(@"{0}\{1}{2}", file.DirectoryName, VIDEO_CUT, file.Name);
            filePathOutSplice = string.Format(@"{0}\{1}{2}", file.DirectoryName, VIDEO_SPLICE, file.Name);
       
            #region 剪辑
            if (cboIsAutoCutVideo.Checked)
            {
                string dateTime = string.Empty;
                string videoTimeTotal = string.Empty;
                string videoTimeStart = string.Empty;
                string videoTimeEnd = string.Empty;
                DateTime handleDate;

                dateTime = "1970-01-01";

                int SencodStart = (int)txtCurVideoSencodStart.Value;
                int SencodEnd = (int)txtCurVideoSencodEnd.Value;

                videoTimeStart = "00:00:00";
                if (SencodStart > 0)
                {
                    handleDate = DateTime.Parse(dateTime);
                    handleDate = handleDate.AddSeconds(SencodStart);
                    videoTimeStart = handleDate.ToString("HH:mm:ss");
                }
                //videoTimeTotal = ffmpegHelper.GetVideoTotalTime(filePath.Replace(".mp4",""));
                videoTimeTotal = ffmpegHelper.GetVideoTotalTime(filePath);
                if (!string.IsNullOrEmpty(videoTimeTotal))
                {
                    try
                    {
                        videoTimeEnd = videoTimeTotal;
                        if (SencodEnd > 0)
                        {
                            handleDate = DateTime.Parse(string.Format(@"{0} {1}", dateTime, videoTimeTotal));
                            handleDate = handleDate.AddSeconds(-SencodEnd);
                            videoTimeEnd = handleDate.ToString("HH:mm:ss");
                        }
                    }
                    catch
                    {
                        videoTimeEnd = string.Empty;
                    }
                }

                if (string.IsNullOrEmpty(videoTimeEnd))
                {
                    HandleMessage.Show("未找到视频时长信息,仅截取开头");
                    HandleMessage.Show(string.Format("开启执行剪辑 {0}~视频结尾 ...",videoTimeStart));
                }
                else
                    HandleMessage.Show(string.Format("开启执行剪辑 {0}~{1} ...", videoTimeStart, videoTimeEnd));

                ffmpegHelper.Cut(filePath, videoTimeStart, videoTimeEnd, filePathOutCut);

                HandleMessage.Show(string.Format("完成文件剪辑 {0}", filePathOutCut));
                HandleMessage.Show(string.Format("用时 {0} 秒。", stopwatch.Elapsed.TotalSeconds));
            }
            #endregion

            #region 拼接 头部尾部 片头尾

            //string pathFlvHeader = @"C:\Users\admin\Desktop\a1\videoHeader.flv";
            //string pathFlvFloor = @"C:\Users\admin\Desktop\a1\videoFloor.flv";
            //string pathMP4Header = pathFlvHeader.Replace(".flv", ".mp4");
            //string pathMP4Floor = pathFlvFloor.Replace(".flv", ".mp4");
            //ffmpegHelper.FlvToMp4(pathFlvHeader, pathMP4Header);
            //ffmpegHelper.FlvToMp4(pathFlvFloor, pathMP4Floor);

            var sourcePaths = new List<string>();

            if (cboVideoHeader.Checked)
                if (File.Exists(videoPathHeader))
                    sourcePaths.Add(videoPathHeader);

            if (cboIsAutoCutVideo.Checked)
                sourcePaths.Add(filePathOutCut);
            else
                sourcePaths.Add(filePath);

            if (cboVideoFloor.Checked)
                if (File.Exists(videoPathFloor))
                    sourcePaths.Add(videoPathFloor);

            ffmpegHelper.Splice(sourcePaths, filePathOutSplice);

            stopwatch.Stop();
            HandleMessage.Show(string.Format("完成文件合成 {0}", filePathOutSplice));
            HandleMessage.Show(string.Format("用时 {0} 秒。", stopwatch.Elapsed.TotalSeconds));
            HandleMessage.Show("=================================== END ===================================");
            HandleMessage.Show("");

            #endregion

            System.Threading.Thread.Sleep(1110);

            if (cboIsAutoCutVideo.Checked)
                if (File.Exists(filePathOutCut))
                    File.Delete(filePathOutCut);

            if (cboDeleteResourceFile.Checked)
                File.Delete(filePath);
        }



        public void up()
        {
            string apiKey = @"AIzaSyCX0As8mlZ18e4aqIyproKLXzvVfBs5g84";
            string clientId = @"222252918947-iid9u363jgp10b22m8ue8rg94n99roia.apps.googleusercontent.com";
            string clientSecret = @"r910yCk1gF6Kedn0HG-hy6sT";

            string refreshToken = @"1/UiEcrF6G_Aa7pLTNOImKexg1hJHUou_nFLf_sxi9W6oXh4EiMLan8fkpCLvFYxLj";

            var youTubeApiRestClient = new YouTubeApiRestClient.YouTubeApiRestClient(apiKey);

            //var youTubeApiRestClient = new YouTubeApiRestClient.YouTubeApiRestClient(
            //    clientId: clientId,
            //    clientSecret: clientSecret,
            //    refreshToken: refreshToken
            //);
            youTubeApiRestClient = new YouTubeApiRestClient.YouTubeApiRestClient(clientId, clientSecret, refreshToken);

            var video = new Video
            {
                Snippet = new VideoSnippet
                {
                    Title = "最好的戒烟方式",
                    Description = "最好的戒烟方式",
                    Tags = new[] { "戒烟" },
                    CategoryId = "22"
                    //CategoryId = "PL-S1JcRDBHbTT2GuGy8ehjiaQggFhTRg4" // See https://developers.google.com/youtube/v3/docs/videoCategories/list
                },
                Status = new VideoStatus
                {
                    PrivacyStatus = "public" // or "private" or "public"
                }
            };
            var filePath = string.Empty;
            filePath = @"C:\Users\admin\Desktop\a1\01.mp4";

            //filePath = AppDomain.CurrentDomain.BaseDirectory + "01.mp4";

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                try
                {
                    video = youTubeApiRestClient.UploadVideo(video, "snippet,status", fileStream, "video/*");
                    Console.WriteLine(string.Format("Video id '{0}' was successfully uploaded.", video.Id));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }



        private void btnHandleTestUp_Click(object sender, EventArgs e)
        {


            up();
        }


    }
}
