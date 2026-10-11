using System.Drawing;

namespace SnackGame3.Utils
{
    class GameConfig
    {
        // kich thuoc ban co
        public static int CELL_SIZE = 20; 
        public static int COLS = 25;      
        public static int ROWS = 20;      
        
        // toc do game
        public static int SPEED_EASY = 200;   
        public static int SPEED_MEDIUM = 120; 
        public static int SPEED_HARD = 70;    

        // mau nen chung
        public static Color BgColor = Color.FromArgb(20, 20, 40);
    }
}
