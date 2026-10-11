using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace SnackGame3.Models
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    internal class Snake
    {
            public List<Point> Body { get; private set; }

            public Direction CurrentDirection { get; private set; }

            private bool growNextMove;

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
                    throw;
                }
            }

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
                        Debug.WriteLine($"[Lỗi khởi tạo rắn]: {ex.Message}");
                        throw;
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
                    Debug.WriteLine($"[Lỗi khởi tạo rắn]: {ex.Message}");
                    throw;
                }
            }

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
                    return false; 
                }
            }
    }
}