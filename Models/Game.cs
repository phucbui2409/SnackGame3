using System;
using System.Diagnostics;
using System.Drawing;

namespace SnackGame3.Models
{
    internal class Game
    {
        public Snake Snake { get; private set; }

        public Food Food { get; private set; }

        public int Score { get; private set; }

        public bool IsGameOver { get; private set; }

        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set; }

        public int CellSize { get; private set; }

        public int Columns { get; private set; }
        public int Rows { get; private set; }

        private Random random;

        public Game(int boardWidth, int boardHeight, int cellSize)
        {
            if (boardWidth <= 0 || boardHeight <= 0 || cellSize <= 0)
            {
                throw new ArgumentException(
                    "Kích thước bàn chơi và ô phải lớn hơn 0.");
            }

            if (boardWidth < cellSize || boardHeight < cellSize)
            {
                throw new ArgumentException(
                    "Bàn chơi phải đủ lớn để chứa ít nhất một ô.");
            }

            CellSize = cellSize;

            Columns = boardWidth / cellSize;
            Rows = boardHeight / cellSize;

            BoardWidth = Columns * CellSize;
            BoardHeight = Rows * CellSize;

            random = new Random();

            Start();
        }

        public void Start()
        {
            try
            {
                Score = 0;
                IsGameOver = false;

                int centerX = Columns / 2;
                int centerY = Rows / 2;

                int initialLength = Math.Min(3, Columns);

                if (Columns < initialLength || Rows < 1)
                {
                    IsGameOver = true;
                    return;
                }

                Snake = new Snake(
                    centerX,
                    centerY,
                    initialLength);

                Food = new Food(0, 0);

                if (!SpawnFood())
                {
                    IsGameOver = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"[Lỗi bắt đầu game]: {ex.Message}");

                IsGameOver = true;
            }
        }
        public void ChangeDirection(Direction direction)
        {
            try
            {
                if (IsGameOver || Snake == null)
                {
                    return;
                }

                Snake.ChangeDirection(direction);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"[Lỗi đổi hướng]: {ex.Message}");
            }
        }

        public void Update()
        {
            try
            {
                if (IsGameOver || Snake == null || Food == null)
                {
                    return;
                }

                Snake.Move();

                if (CheckWallCollision())
                {
                    IsGameOver = true;
                    return;
                }

                if (Snake.CheckSelfCollision())
                {
                    IsGameOver = true;
                    return;
                }

                if (Snake.Head == Food.Position)
                {
                    Score += 10;

                    Snake.Grow();

                    if (!SpawnFood())
                    {
                        IsGameOver = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"[Lỗi cập nhật game]: {ex.Message}");

                IsGameOver = true;
            }
        }

        public bool CheckWallCollision()
        {
            if (Snake == null)
            {
                return true;
            }

            Point head = Snake.Head;

            return head.X < 0
                || head.Y < 0
                || head.X >= Columns
                || head.Y >= Rows;
        }

        private bool SpawnFood()
        {
            try
            {
                if (Snake == null || Food == null)
                {
                    return false;
                }

                int totalCells = Columns * Rows;

                if (Snake.Body.Count >= totalCells)
                {
                    return false;
                }

                for (int i = 0; i < totalCells; i++)
                {
                    int x = random.Next(0, Columns);
                    int y = random.Next(0, Rows);

                    Point position = new Point(x, y);

                    bool occupied = false;

                    foreach (Point segment in Snake.Body)
                    {
                        if (segment == position)
                        {
                            occupied = true;
                            break;
                        }
                    }

                    if (!occupied)
                    {
                        Food = new Food(x, y);
                        return true;
                    }
                }

                for (int y = 0; y < Rows; y++)
                {
                    for (int x = 0; x < Columns; x++)
                    {
                        Point position = new Point(x, y);

                        bool occupied = false;

                        foreach (Point segment in Snake.Body)
                        {
                            if (segment == position)
                            {
                                occupied = true;
                                break;
                            }
                        }

                        if (!occupied)
                        {
                            Food = new Food(x, y);
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"[Lỗi tạo thức ăn]: {ex.Message}");

                return false;
            }
        }
    }
}