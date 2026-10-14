using System;
using System.IO;
using System.Media;
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

        // SoundPlayer phát trực tiếp từ RAM, không gây giật/delay khi ăn mồi
        private static SoundPlayer playerEat;
        private static SoundPlayer playerDie;
        private static SoundPlayer playerBtn;

        public static int MusicVolume { get; set; } = 400;
        public static int SfxVolume { get; set; } = 700;
        public static int ButtonVolume { get; set; } = 650;

        static SoundManager()
        {
            PreloadSfx();
        }

        private static void PreloadSfx()
        {
            try
            {
                string eatPath = GetSoundPath("eatsnake.wav");
                if (File.Exists(eatPath))
                {
                    playerEat = new SoundPlayer(eatPath);
                    playerEat.LoadAsync();
                }

                string diePath = GetSoundPath("eatdie.wav");
                if (File.Exists(diePath))
                {
                    playerDie = new SoundPlayer(diePath);
                    playerDie.LoadAsync();
                }

                string btnPath = GetSoundPath("nutbam.wav");
                if (File.Exists(btnPath))
                {
                    playerBtn = new SoundPlayer(btnPath);
                    playerBtn.LoadAsync();
                }
            }
            catch
            {
            }
        }

        private static string GetSoundPath(string fileName)
        {
            // 1. Tìm trong thư mục chạy của ứng dụng (bin/Debug/Sounds/...)
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds", fileName);
            if (File.Exists(path)) return path;

            // 2. Tìm trong thư mục gốc project (D:\phucbui2409\SnackGame3\Sounds\...)
            string parentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Sounds", fileName);
            if (File.Exists(parentPath)) return Path.GetFullPath(parentPath);

            string projectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Sounds", fileName);
            if (File.Exists(projectPath)) return Path.GetFullPath(projectPath);

            // 3. Đường dẫn cố định trong project
            string hardcodedPath = Path.Combine(@"D:\phucbui2409\SnackGame3\Sounds", fileName);
            if (File.Exists(hardcodedPath)) return hardcodedPath;

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
            }
        }

        /// <summary>
        /// Phát nhạc nền game (gamemusic.mp3) lặp vô tận ở sảnh menu
        /// </summary>
        public static void PlayBackgroundMusic()
        {
            if (!IsSoundEnabled) return;

            try
            {
                string musicFile = GetSoundPath("gamemusic.mp3");
                if (!File.Exists(musicFile)) return;

                // Đóng trước nếu đang mở để tránh xung đột
                SendMci("stop bgm");
                SendMci("close bgm");

                SendMci($"open \"{musicFile}\" type mpegvideo alias bgm");
                SendMci($"setaudio bgm volume to {MusicVolume}");
                SendMci("play bgm repeat");

                isMusicLoaded = true;
                isMusicPlaying = true;
            }
            catch
            {
            }
        }

        /// <summary>
        /// Dừng hẳn nhạc nền
        /// </summary>
        public static void StopBackgroundMusic()
        {
            try
            {
                SendMci("stop bgm");
                SendMci("close bgm");
                isMusicLoaded = false;
                isMusicPlaying = false;
            }
            catch
            {
            }
        }

        /// <summary>
        /// Tạm dừng nhạc nền
        /// </summary>
        public static void PauseBackgroundMusic()
        {
            try
            {
                if (isMusicPlaying)
                {
                    SendMci("pause bgm");
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Tiếp tục phát nhạc nền
        /// </summary>
        public static void ResumeBackgroundMusic()
        {
            if (!IsSoundEnabled) return;

            try
            {
                if (isMusicLoaded)
                {
                    SendMci("resume bgm");
                    isMusicPlaying = true;
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
        /// Phát âm thanh khi ăn mồi (eatsnake.wav) - Bằng SoundPlayer siêu nhanh, không delay
        /// </summary>
        public static void PlayEat()
        {
            if (!IsSoundEnabled) return;

            try
            {
                if (playerEat != null)
                {
                    playerEat.Play();
                }
                else
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
                if (playerDie != null)
                {
                    playerDie.Play();
                }
                else
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
            }
            catch
            {
            }
        }

        /// <summary>
        /// Phát âm thanh khi bấm nút (nutbam.wav)
        /// </summary>
        public static void PlayButtonClick()
        {
            if (!IsSoundEnabled) return;

            try
            {
                if (playerBtn != null)
                {
                    playerBtn.Play();
                }
                else
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
                playerEat?.Dispose();
                playerDie?.Dispose();
                playerBtn?.Dispose();

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
