using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;


namespace SnackGame3.Models
{
    internal class Food
    {
        public Point Position { get; private set; }

        public Food(int x, int y)
        {
            try
            {
                Position = new Point(x, y);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Lỗi khởi tạo thức ăn]: {ex.Message}");
                throw;
            }
        }

        public void GenerateRandomPosition(
            int boardWidth,
            int boardHeight,
            int cellSize,
            Random random)
        {
            try
            {
                if (boardWidth <= 0 || boardHeight <= 0)
                    throw new ArgumentException(
                        "Kích thước bản đồ phải lớn hơn 0.");

                if (cellSize <= 0)
                    throw new ArgumentException(
                        "Kích thước mỗi ô phải lớn hơn 0.");

                if (random == null)
                    throw new ArgumentNullException(
                        nameof(random), "Đối tượng Random không được null.");

                int columns = boardWidth / cellSize;
                int rows = boardHeight / cellSize;

                if (columns <= 0 || rows <= 0)
                    throw new ArgumentException(
                        "Bản đồ không đủ lớn để tạo thức ăn.");

                int x = random.Next(0, columns) * cellSize;
                int y = random.Next(0, rows) * cellSize;

                Position = new Point(x, y);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"[Lỗi tạo vị trí thức ăn]: {ex.Message}");
                throw;
            }
        }

        public bool IsOnSnake(Snake snake)
        {
            try
            {
                if (snake == null)
                    throw new ArgumentNullException(
                        nameof(snake), "Đối tượng rắn không được null.");

                if (snake.Body == null)
                    throw new InvalidOperationException(
                        "Danh sách thân rắn chưa được khởi tạo.");

                foreach (Point segment in snake.Body)
                {
                    if (Position == segment)
                        return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"[Lỗi kiểm tra vị trí thức ăn]: {ex.Message}");
                throw;
            }
        }
    }
}
