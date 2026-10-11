using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackGame3.Models
{
    internal class Snack
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public class Snake
        {
            // 1. Tạo cấu trúc dữ liệu lưu các đoạn thân rắn
            public List<Point> Body { get; private set; }
            public Direction CurrentDirection { get; private set; }

            // Biến cờ để theo dõi việc rắn có ăn thức ăn hay không
            private bool growNextMove;

            // 2. Khởi tạo rắn
            public Snake(int startX, int startY, int initialLength = 3)
            {
                Body = new List<Point>();
                CurrentDirection = Direction.Right; // Mặc định di chuyển sang phải
                growNextMove = false;

                // Tạo các đốt thân rắn ban đầu (đầu rắn ở [0])
                for (int i = 0; i < initialLength; i++)
                {
                    Body.Add(new Point(startX - i, startY));
                }
            }

            // Lấy tọa độ đầu rắn
            public Point Head => Body.First();

            // 3. Đổi hướng bằng các phím mũi tên
            public void ChangeDirection(Direction newDirection)
            {
                // Rắn không thể quay đầu 180 độ (VD: đang đi lên không thể đi xuống ngay)
                if ((CurrentDirection == Direction.Up && newDirection == Direction.Down) ||
                    (CurrentDirection == Direction.Down && newDirection == Direction.Up) ||
                    (CurrentDirection == Direction.Left && newDirection == Direction.Right) ||
                    (CurrentDirection == Direction.Right && newDirection == Direction.Left))
                {
                    return;
                }
                CurrentDirection = newDirection;
            }

            // 4. Di chuyển rắn
            public void Move()
            {
                Point currentHead = Head;
                Point newHead = currentHead; // Tạo một bản sao của đầu hiện tại

                // Tính toán vị trí đầu mới dựa trên hướng hiện tại
                switch (CurrentDirection)
                {
                    case Direction.Up:
                        newHead.Y -= 1;
                        break;
                    case Direction.Down:
                        newHead.Y += 1;
                        break;
                    case Direction.Left:
                        newHead.X -= 1;
                        break;
                    case Direction.Right:
                        newHead.X += 1;
                        break;
                }

                // Thêm đầu mới vào vị trí đầu tiên của danh sách
                Body.Insert(0, newHead);

                // 5. Xử lý việc rắn dài thêm khi ăn thức ăn
                if (growNextMove)
                {
                    growNextMove = false; // Đã dài thêm, reset lại trạng thái
                                          // Không xóa đuôi để thân rắn tự động dài ra 1 đốt
                }
                else
                {
                    // Nếu không ăn thức ăn, xóa phần đuôi cuối cùng để rắn di chuyển tịnh tiến
                    Body.RemoveAt(Body.Count - 1);
                }
            }

            // Gọi hàm này từ bên ngoài (Form) khi phát hiện đầu rắn trùng với tọa độ thức ăn
            public void Grow()
            {
                growNextMove = true;
            }

            // 6. Kiểm tra rắn có tự cắn vào thân hay không
            public bool CheckSelfCollision()
            {
                Point head = Head;

                // Lặp từ đốt thứ 1 (bỏ qua đầu rắn ở index 0) để xem có trùng tọa độ không
                for (int i = 1; i < Body.Count; i++)
                {
                    if (head == Body[i])
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}