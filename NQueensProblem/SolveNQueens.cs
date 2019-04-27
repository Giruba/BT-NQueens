using System;
using System.Collections.Generic;
using System.Text;

namespace NQueensProblem
{
    class SolveNQueens
    {
        int numberOfQueens;
        int[,] board;

        public SolveNQueens(int numberOfQueens) {
            this.numberOfQueens = numberOfQueens;
            board = new int[numberOfQueens, numberOfQueens];
        }

        public void SetNumberOfQueens(int numberOfQueens) {
            this.numberOfQueens = numberOfQueens;
            board = new int[numberOfQueens, numberOfQueens];
        }

        public int GetNumberOfQueens() {
            return numberOfQueens;
        }

        public void PlaceQueens() {
            int boardDimension = numberOfQueens;
            if (AllQueensPlaced(0))
            {
                Console.WriteLine("All queens are placed");
                Console.WriteLine();
                PrintSolution();
            }
            else {
                Console.WriteLine("Solution does not exist!" +
                    " The queens cannot be placed in the board" +
                    " without collision!");
            }
        }

        public void PrintSolution() {
            for (int i = 0; i < numberOfQueens; i++) {
                for (int j = 0; j < numberOfQueens; j++) {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool AllQueensPlaced(int column) {

            /* The N Queens are placed in columns one by one
             * So if all queens are placed without collision,
             * we would be reaching the columns N, the ending
             * condition of the recursion
             */
            if (column >= board.GetLength(0)) {
                return true;
            }

            for (int rowIndex = 0; rowIndex < numberOfQueens; rowIndex++) {

                if (CanAQuenBePlaced(rowIndex, column)) {
                    board[rowIndex, column] = 1;

                    //If this recursion returns true, return
                    if (AllQueensPlaced(column + 1)) {
                        return true;
                    };
                    board[rowIndex, column] = 0;
                }
            }

            return false;
        }

        public bool CanAQuenBePlaced(int rowIndex, int column) {
            bool result = true;

            for (int sameRowColChecker = 0; sameRowColChecker < column; sameRowColChecker++) {
                if (board[rowIndex,sameRowColChecker ] == 1) {
                    return false;
                }
            }

            /*Since we will be placing a queen at (rowIndex, column),
             * we should check whether the upper diagonal above this
             * placement ON THE LEFT SIDE does not collide
             */
            for (int row = rowIndex, col = column; row >= 0 && col >= 0; row--, col--) {
                if (board[row, col] == 1) {
                    return false;
                }
            }


            /*Since we will be placing a queen at (rowIndex, column),
             * we should check whether the lower diagonal below this
             * placement ON THE LEFT SIDE does not collide
             */
            for (int row = rowIndex, col = column; row < numberOfQueens && col >=0; row++, col--)
            {
                if (board[row, col] == 1)
                {
                    return false;
                }
            }
            return result;
        }
    }
}
