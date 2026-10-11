using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace SnackGame3.Models
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

        public Snake(int startX, int startY, int initialLength = 3)
        {
            if (initialLength <= 0)
            {
                throw new ArgumentException(
                    "Chiều dài khởi tạo phải lớn hơn 0.",
                    nameof(initialLength));
            }

            try
            {
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
                Debug.WriteLine(
                    $"[Lỗi khởi tạo rắn]: {ex.Message}");

                throw;
            }
        }

        public Point Head
        {
            get
            {
                if (Body == null || Body.Count == 0)
                {
                    throw new InvalidOperationException(
                        "Không thể lấy đầu rắn vì thân rắn đang rỗng.");
                }

                return Body[0];
            }
        }

        public void ChangeDirection(Direction newDirection)
        {
            try
            {
                if (!Enum.IsDefined(typeof(Direction), newDirection))
                {
                    throw new ArgumentException(
                        "Hướng di chuyển không hợp lệ.",
                        nameof(newDirection));
                }

                if ((CurrentDirection == Direction.Up &&
                     newDirection == Direction.Down) ||

                    (CurrentDirection == Direction.Down &&
                     newDirection == Direction.Up) ||

                    (CurrentDirection == Direction.Left &&
                     newDirection == Direction.Right) ||

                    (CurrentDirection == Direction.Right &&
                     newDirection == Direction.Left))
                {
                    return;
                }

                CurrentDirection = newDirection;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"[Lỗi đổi hướng rắn]: {ex.Message}");

                throw;
            }
        }

        public void Move()
        {
            try
            {
                if (Body == null || Body.Count == 0)
                {
                    throw new InvalidOperationException(
                        "Không thể di chuyển vì thân rắn đang rỗng.");
                }

                Point newHead = Head;

                switch (CurrentDirection)
                {
                    case Direction.Up:
                        newHead.Y--;
                        break;

                    case Direction.Down:
                        newHead.Y++;
                        break;

                    case Direction.Left:
                        newHead.X--;
                        break;

                    case Direction.Right:
                        newHead.X++;
                        break;

                    default:
                        throw new InvalidOperationException(
                            "Hướng di chuyển hiện tại không hợp lệ.");
                }

                Body.Insert(0, newHead);

                if (growNextMove)
                {
                    growNextMove = false;
                }
                else
                {
                    Body.RemoveAt(Body.Count - 1);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"[Lỗi di chuyển rắn]: {ex.Message}");

                throw;
            }
        }

        public void Grow()
        {
            if (Body == null || Body.Count == 0)
            {
                throw new InvalidOperationException(
                    "Không thể tăng chiều dài khi thân rắn đang rỗng.");
            }

            growNextMove = true;
        }

        public bool CheckSelfCollision()
        {
            try
            {
                if (Body == null || Body.Count <= 1)
                {
                    return false;
                }

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
                Debug.WriteLine(
                    $"[Lỗi kiểm tra va chạm thân rắn]: {ex.Message}");

                throw;
            }
        }
    }
}
