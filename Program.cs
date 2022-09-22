// Tic-Tac-Toe By Joseph Gaunt
using System;
using System.Collections.Generic;

namespace cse210_01
{
    class program
    {
        static void Main(string[] args)
        {
            List<string> currentBoard = newBoard();
            string currentPlayer = "x";
            while(!isGameOver(currentBoard))
            {
                showBoard(currentBoard);
                int playerChoice = receivePlayerMove(currentPlayer);
                makePlayerMove(currentBoard, playerChoice, currentPlayer);
                currentPlayer = playerTurn(currentPlayer);
            }
            showBoard(currentBoard);
            Console.Write("Thank you for playing Tic-Tac-Toe");
        }

        static List<string> newBoard()
        {
            List<string> gameBoard = new List<string>();
            for (int i=1; i <= 9; i++)
            {
                gameBoard.Add(i.ToString());
            }
            return gameBoard;
        }
        static bool isGameOver(List<string> gameBoard)
        {
            bool gameDecision = false;
            if (whoWon(gameBoard, "x") || whoWon(gameBoard, "o") || isGameTied(gameBoard))
            {
                gameDecision = true;
            }
            return gameDecision;
        }
        static bool isGameTied(List<string> gameBoard)
        {
            bool foundDigit = false;

            foreach(string value in gameBoard)
            {
                if(char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }
            if(foundDigit == false)
            {
                Console.WriteLine("The game is a Tie");
            }
            return !foundDigit;
        }
        static bool whoWon(List<string> gameBoard, string player)
        {
            bool isWinner = false;

            if ((gameBoard[0] == player && gameBoard[1] == player && gameBoard[2] == player)
                || (gameBoard[3] == player && gameBoard[4] == player && gameBoard[5] == player)
                || (gameBoard[6] == player && gameBoard[7] == player && gameBoard[8] == player)
                || (gameBoard[0] == player && gameBoard[3] == player && gameBoard[6] == player)
                || (gameBoard[1] == player && gameBoard[4] == player && gameBoard[7] == player)
                || (gameBoard[2] == player && gameBoard[5] == player && gameBoard[8] == player)
                || (gameBoard[0] == player && gameBoard[4] == player && gameBoard[8] == player)
                || (gameBoard[2] == player && gameBoard[4] == player && gameBoard[6] == player)
                )
            {
                isWinner = true;
                Console.WriteLine($"The winner is {player}");
            }

            return isWinner; 
        }
        static string playerTurn(string player)
        {
            string nextPlayer = "x";
            if (player == "x")
            {
                nextPlayer = "o";
            }
            return nextPlayer;
        }
        static void showBoard(List<string> board)
        {
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        }
        static int receivePlayerMove(string player)
        {
            Console.Write($"{player}'s turn to choose a square (1-9):");
            string moveInput = Console.ReadLine();
            int choice = int.Parse(moveInput);
            return choice;
        }
        static void makePlayerMove(List<string> board, int move, string player)
        {
            int index = move - 1;
            board[index] = player;
        }
    }
}
