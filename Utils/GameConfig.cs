using System.Drawing;

namespace SnackGame3.Utils
{
    public enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }

    class GameConfig
    {
        // kich thuoc ban co
        public static int CELL_SIZE = 20; 
        public static int COLS = 25;      
        public static int ROWS = 20;      
        
        // toc do game (ms moi nhip di chuyen cua ran)
        public static int SPEED_EASY = 200;   // Ran chay cham
        public static int SPEED_MEDIUM = 120; // Ran chay vua
        public static int SPEED_HARD = 70;    // Ran chay nhanh

        // Do kho hien tai mac dinh
        public static GameDifficulty CurrentDifficulty = GameDifficulty.Medium;

        public static int GetSpeed(GameDifficulty difficulty)
        {
            switch (difficulty)
            {
                case GameDifficulty.Easy: return SPEED_EASY;
                case GameDifficulty.Hard: return SPEED_HARD;
                case GameDifficulty.Medium:
                default:
                    return SPEED_MEDIUM;
            }
        }

        public static string GetDifficultyDisplayName(GameDifficulty difficulty)
        {
            switch (difficulty)
            {
                case GameDifficulty.Easy: return "Dễ (Chậm)";
                case GameDifficulty.Hard: return "Khó (Nhanh)";
                case GameDifficulty.Medium:
                default:
                    return "Vừa (Bình thường)";
            }
        }

        // mau nen chung
        public static Color BgColor = Color.FromArgb(20, 20, 40);
    }
}

