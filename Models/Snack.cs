using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

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
            public List<Point> Body { get; private set; }
            public Direction CurrentDirection { get; private set; }
            private bool growNextMove;

            // 1. Bẫy lỗi ở khởi tạo (Tránh trường hợp truyền chiều dài âm hoặc bằng 0)
            public Snake(int startX, int startY, int initialLength = 3)
            {
                try
                {
                    if (initialLength <= 0)
                    {
                        throw new ArgumentException("Chiều dài khởi tạo phải lớn hơn 0.");
                    }

                    Body = new List<Point>();
                    CurrentDirection = Direction.Right;
                    growNextMove = false;

                    for (int i = 0; i < initialLength; i++)
                    {
                        Body.Add(new Point(startX - i, startY));
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[Lỗi khởi tạo rắn]: {ex.Message}");
                    // Fallback: Tạo ít nhất 1 đốt để game không bị crash toàn tập
                    Body = new List<Point> { new Point(startX, startY) };
                    CurrentDirection = Direction.Right;
                }
            }

            // 2. Bẫy lỗi khi lấy đầu rắn (Tránh lỗi InvalidOperationException khi List rỗng)
            public Point Head
            {
                get
                {
                    try
                    {
                        if (Body == null || Body.Count == 0)
                        {
                            throw new Exception("Danh sách thân rắn bị rỗng (null hoặc count = 0).");
                        }
                        return Body.First();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[Lỗi lấy đầu rắn]: {ex.Message}");
                        return new Point(0, 0); // Trả về giá trị mặc định để tránh crash
                    }
                }
            }

            public void ChangeDirection(Direction newDirection)
            {
                try
                {
                    if ((CurrentDirection == Direction.Up && newDirection == Direction.Down) ||
                        (CurrentDirection == Direction.Down && newDirection == Direction.Up) ||
                        (CurrentDirection == Direction.Left && newDirection == Direction.Right) ||
                        (CurrentDirection == Direction.Right && newDirection == Direction.Left))
                    {
                        return;
                    }
                    CurrentDirection = newDirection;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[Lỗi đổi hướng]: {ex.Message}");
                }
            }

            // 3. Bẫy lỗi khi di chuyển (Tránh lỗi OutOfRange khi xóa đuôi List)
            public void Move()
            {
                try
                {
                    Point currentHead = Head;
                    Point newHead = currentHead;

                    switch (CurrentDirection)
                    {
                        case Direction.Up: newHead.Y -= 1; break;
                        case Direction.Down: newHead.Y += 1; break;
                        case Direction.Left: newHead.X -= 1; break;
                        case Direction.Right: newHead.X += 1; break;
                    }

                    Body.Insert(0, newHead);

                    if (growNextMove)
                    {
                        growNextMove = false;
                    }
                    else
                    {
                        // Kiểm tra an toàn trước khi xóa đuôi
                        if (Body.Count > 0)
                        {
                            Body.RemoveAt(Body.Count - 1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[Lỗi di chuyển]: {ex.Message}");
                }
            }

            public void Grow()
            {
                growNextMove = true;
            }

            // 4. Bẫy lỗi khi kiểm tra va chạm
            public bool CheckSelfCollision()
            {
                try
                {
                    if (Body == null || Body.Count <= 1) return false;

                    Point head = Head;

                    for (int i = 1; i < Body.Count; i++)
                    {
                        if (head == Body[i])
                        {
                            return true;
                        }
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[Lỗi kiểm tra va chạm]: {ex.Message}");
                    return false; // Trả về false để game không bị dừng đột ngột do code lỗi
                }
            }
        }
    }
}