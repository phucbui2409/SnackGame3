using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace SnackGame3.Utils
{
    public static class SoundManager
    {
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern int mciSendString(string command, StringBuilder returnString, int returnSize, IntPtr hwndCallback);

        public static bool IsSoundEnabled { get; set; } = true;

        private static bool isMusicLoaded = false;
        private static bool isMusicPlaying = false;
        private static bool isEatLoaded = false;
        private static bool isDieLoaded = false;
        private static bool isButtonLoaded = false;

        // Âm lượng (thang điểm 0 - 1000): điều chỉnh hài hòa
        // Nhạc nền êm dịu, không lấn át (300/1000 ~ 30%)
        // Hiệu ứng ăn mồi rõ ràng, vừa phải (700/1000 ~ 70%)
        // Hiệu ứng thua nổi bật (750/1000 ~ 75%)
        public static int MusicVolume { get; set; } = 300;
        public static int SfxVolume { get; set; } = 700;

        private static string GetSoundPath(string fileName)
        {
            // Tìm trong thư mục chạy của ứng dụng (bin/Debug/...)
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds", fileName);
            if (File.Exists(path)) return path;

            // Tìm ngược lên thư mục project nếu chưa copy
            string parentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Sounds", fileName);
            if (File.Exists(parentPath)) return Path.GetFullPath(parentPath);

            // Tìm ở thư mục gốc Downloads dự phòng
            string downloadPath = Path.Combine(@"C:\Users\vohon\Downloads\sound", fileName);
            if (File.Exists(downloadPath)) return downloadPath;

            return path;
        }

        private static void SendMci(string command)
        {
            try
            {
                mciSendString(command, null, 0, IntPtr.Zero);
            }
            catch
            {
                // Bỏ qua lỗi MCI nếu có
            }
        }

        /// <summary>
        /// Phát nhạc nền game (gamemusic.mp3) lặp vô tận
        /// </summary>
        public static void PlayBackgroundMusic()
        {
            if (!IsSoundEnabled) return;

            try
            {
                string musicFile = GetSoundPath("gamemusic.mp3");
                if (!File.Exists(musicFile)) return;

                if (!isMusicLoaded)
                {
                    SendMci("close bgm");
                    SendMci($"open \"{musicFile}\" type mpegvideo alias bgm");
                    SendMci($"setaudio bgm volume to {MusicVolume}");
                    isMusicLoaded = true;
                }

                SendMci("play bgm repeat");
                isMusicPlaying = true;
            }
            catch
            {
                // Phòng ngừa lỗi không mong muốn
            }
        }

        /// <summary>
        /// Dừng hẳn nhạc nền
        /// </summary>
        public static void StopBackgroundMusic()
        {
            try
            {
                if (isMusicLoaded)
                {
                    SendMci("stop bgm");
                    isMusicPlaying = false;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Tạm dừng nhạc nền (khi mở form con như Hướng dẫn, Điểm số, Game)
        /// </summary>
        public static void PauseBackgroundMusic()
        {
            try
            {
                if (isMusicLoaded && isMusicPlaying)
                {
                    SendMci("pause bgm");
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Tiếp tục phát nhạc nền (khi đóng form con quay lại menu)
        /// </summary>
        public static void ResumeBackgroundMusic()
        {
            if (!IsSoundEnabled) return;

            try
            {
                if (isMusicLoaded && isMusicPlaying)
                {
                    SendMci("resume bgm");
                }
                else
                {
                    PlayBackgroundMusic();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Phát âm thanh khi ăn mồi (eatsnake.wav)
        /// </summary>
        public static void PlayEat()
        {
            if (!IsSoundEnabled) return;

            try
            {
                string eatFile = GetSoundPath("eatsnake.wav");
                if (!File.Exists(eatFile)) return;

                if (!isEatLoaded)
                {
                    SendMci("close sfx_eat");
                    SendMci($"open \"{eatFile}\" alias sfx_eat");
                    SendMci($"setaudio sfx_eat volume to {SfxVolume}");
                    isEatLoaded = true;
                }

                SendMci("play sfx_eat from 0");
            }
            catch
            {
            }
        }

        /// <summary>
        /// Phát âm thanh khi đâm tường / cắn thân thua cuộc (eatdie.wav)
        /// </summary>
        public static void PlayDie()
        {
            if (!IsSoundEnabled) return;

            try
            {
                string dieFile = GetSoundPath("eatdie.wav");
                if (!File.Exists(dieFile)) return;

                if (!isDieLoaded)
                {
                    SendMci("close sfx_die");
                    SendMci($"open \"{dieFile}\" alias sfx_die");
                    SendMci($"setaudio sfx_die volume to 750");
                    isDieLoaded = true;
                }

                SendMci("play sfx_die from 0");
            }
            catch
            {
            }
        }

        public static int ButtonVolume { get; set; } = 650;

        /// <summary>
        /// Phát âm thanh khi bấm nút (nutbam.wav)
        /// </summary>
        public static void PlayButtonClick()
        {
            if (!IsSoundEnabled) return;

            try
            {
                string btnFile = GetSoundPath("nutbam.wav");
                if (!File.Exists(btnFile)) return;

                if (!isButtonLoaded)
                {
                    SendMci("close sfx_btn");
                    SendMci($"open \"{btnFile}\" alias sfx_btn");
                    SendMci($"setaudio sfx_btn volume to {ButtonVolume}");
                    isButtonLoaded = true;
                }

                SendMci("play sfx_btn from 0");
            }
            catch
            {
            }
        }

        /// <summary>
        /// Giải phóng tài nguyên âm thanh khi thoát ứng dụng
        /// </summary>
        public static void Cleanup()
        {
            try
            {
                SendMci("close bgm");
                SendMci("close sfx_eat");
                SendMci("close sfx_die");
                SendMci("close sfx_btn");
                isMusicLoaded = false;
                isMusicPlaying = false;
                isEatLoaded = false;
                isDieLoaded = false;
                isButtonLoaded = false;
            }
            catch
            {
            }
        }
    }
}
