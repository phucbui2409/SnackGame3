using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private Random random;

        public Game(int boardWidth, int boardHeight, int cellSize)
        {
            if (boardWidth <= 0 || boardHeight <= 0 || cellSize <= 0)
                throw new ArgumentException(
                    "Kích thước bản đồ và ô phải lớn hơn 0.");

            if (boardWidth < cellSize || boardHeight < cellSize)
                throw new ArgumentException(
                    "Bản đồ phải có kích thước tối thiểu bằng một ô.");

            BoardWidth = boardWidth / cellSize * cellSize;
            BoardHeight = boardHeight / cellSize * cellSize;
            CellSize = cellSize;

            random = new Random();

            Start();
        }

        public void Start()
        {
            try
            {
                Score = 0;
                IsGameOver = false;

                int centerX = (BoardWidth / CellSize / 2) * CellSize;
                int centerY = (BoardHeight / CellSize / 2) * CellSize;

                int initialLength = Math.Min(
                    3, BoardWidth / CellSize);

                Snake = new Snake(centerX, centerY, initialLength);
                Food = new Food(0, 0);

                if (!SpawnFood())
                    IsGameOver = true;
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
                    return;

                Snake.ChangeDirection(direction);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"[Lỗi đổi hướng]: {ex.Message}");

                IsGameOver = true;
            }
        }

        public void Update()
        {
            try
            {
                if (IsGameOver || Snake == null || Food == null)
                    return;

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
                        IsGameOver = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"[Lỗi xử lý luật game]: {ex.Message}");

                IsGameOver = true;
            }
        }

        public bool CheckWallCollision()
        {
            Point head = Snake.Head;

            return head.X < 0
                || head.Y < 0
                || head.X >= BoardWidth
                || head.Y >= BoardHeight;
        }

        private bool SpawnFood()
        {
            try
            {
                int columns = BoardWidth / CellSize;
                int rows = BoardHeight / CellSize;
                int totalCells = columns * rows;

                if (Snake.Body.Count >= totalCells)
                    return false;

                for (int i = 0; i < totalCells; i++)
                {
                    Food.GenerateRandomPosition(
                        BoardWidth,
                        BoardHeight,
                        CellSize,
                        random);

                    if (!Food.IsOnSnake(Snake))
                        return true;
                }

                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < columns; x++)
                    {
                        Point position = new Point(
                            x * CellSize,
                            y * CellSize);

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
                            Food = new Food(position.X, position.Y);
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"[Lỗi sinh thức ăn]: {ex.Message}");

                return false;
            }
        }
    }
}
