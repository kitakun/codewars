namespace CodeWarrior.Wars
{
    using System;

    /// <summary>5 kyu</summary>

    /// <summary>
    /// If we were to set up a Tic-Tac-Toe game, we would want to know whether the board's current state is
    /// solved, wouldn't we? Our goal is to create a function that will check that for us!
    /// 
    /// Assume that the board comes in the form of a 3x3 array, where the value is 0 if a spot is empty, 1 if it
    /// is an "X", or 2 if it is an "O", like so:
    /// [[0, 0, 1],
    ///  [0, 1, 2],
    ///  [2, 1, 0]]
    ///  We want our function to return:
    ///  -1 if the board is not yet finished (there are empty spots),
    ///  1 if "X" won,
    /// 2 if "O" won,
    /// 0 if it's a cat's game (i.e. a draw).
    /// You may assume that the board passed in is valid in the context of a game of Tic-Tac-Toe.
    /// </summary>
    public class TickTacToeChecker_11 : IWar
    {
        private const int ELEMENTS_IN_ROW = 3;

        // Board filled data
        private const int NOT_SET_OWNER = 0;
        private const int X_OWNER = 1;
        private const int O_OWNER = 2;

        // checking
        private static readonly (int fromX, int fromY, Direction direction)[] _directions = new[]
        {
            // [→] [ ] [ ]
            (0, 0, Direction.Right),
            // [ ] [↓] [ ]
            (1, 0, Direction.Down),
            // [ ] [ ] [↙]
            (2, 0, Direction.RightDiagonally),
            // [ ] [ ] [ ]
            // [→] [ ] [ ]
            (0, 1, Direction.Right),
            // [ ] [ ] [ ]
            // [ ] [ ] [ ]
            // [→] [ ] [ ]
            (0, 2, Direction.Right),
            // [↘] [ ] [ ]
            (0, 0, Direction.LeftDiagonally),
        };

        public void Launch()
        {
            int[,] board = new int[,] {
                { 0, 0, 2 },
                { 0, 0, 0 },
                { 1, 0, 1 }
            };
            var result = new TickTacToeChecker_11().IsSolved(board);

            Console.WriteLine(result.ToString());
        }

        public int IsSolved(int[,] board)
        {
            if (!IsBoardFilled(board))
            {
                return (int)WinType.NOT_FINISHED;
            }

            var isNotFinished = false;

            for (var i = 0; i < _directions.Length; i++)
            {
                var direction = DirectionToVector(_directions[i].direction);
                var currentResult = GetWinConditionByDirection((_directions[i].fromX, _directions[i].fromY), board, direction);
                if (currentResult == WinType.X_WON || currentResult == WinType.O_WON)
                {
                    return (int)currentResult;
                }

                if (currentResult == WinType.NOT_FINISHED)
                {
                    isNotFinished = true;
                }
            }

            return isNotFinished
                ? (int)WinType.NOT_FINISHED
                : (int)WinType.CAT_WON;
        }

        private static bool IsBoardFilled(int[,] board)
        {
            if (board.Length != ELEMENTS_IN_ROW * ELEMENTS_IN_ROW)
                return false;

            return true;
        }

        private static WinType GetWinConditionByDirection(
            (int x, int y) startFrom,
            int[,] board,
            (int x, int y) direction)
        {
            var curX = startFrom.x;
            var curY = startFrom.y;

            var itsCat = false;

            var curOwner = board[curY, curX];
            if (curOwner != NOT_SET_OWNER)
            {
                for (var i = 1; i < ELEMENTS_IN_ROW; i++)
                {
                    curX += direction.x;
                    curY += direction.y;

                    var nextOwner = board[curY, curX];
                    // conditions
                    if (nextOwner != curOwner || nextOwner == NOT_SET_OWNER)
                    {
                        itsCat = true;
                    }

                    if (nextOwner == NOT_SET_OWNER)
                        return WinType.NOT_FINISHED;
                }
                if (itsCat)
                {
                    return WinType.CAT_WON;
                }
                else
                {
                    switch (curOwner)
                    {
                        case X_OWNER:
                            return WinType.X_WON;
                        case O_OWNER:
                            return WinType.O_WON;
                        default:
                            return WinType.CAT_WON;
                    }
                }
            }

            return WinType.NOT_FINISHED;
        }

        private static (int, int) DirectionToVector(Direction dir)
        {
            switch (dir)
            {
                case Direction.Down:
                    return (0, 1);
                case Direction.LeftDiagonally:
                    return (1, 1);
                case Direction.Right:
                    return (1, 0);
                case Direction.RightDiagonally:
                    return (-1, 1);
                default:
                    return (0, 0);
            }
        }

        internal enum Direction
        {
            Right = 1,
            Down = 2,
            LeftDiagonally = 3,
            RightDiagonally = 4,
        }

        internal enum WinType
        {
            X_WON = 1,
            O_WON = 2,
            CAT_WON = 0,
            NOT_FINISHED = -1,
        }
    }
}

