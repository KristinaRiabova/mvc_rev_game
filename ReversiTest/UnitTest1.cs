using NUnit.Framework;
using ReversiGame;
using ReversiGame.Controllers;
using ReversiGame.Models;
using ReversiGame.Views;

namespace ReversiTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestInValidMove()
        {
            Board board = new Board();
            Assert.That(board.IsValidMove(0,0,'X'),Is.EqualTo(false));

        }
        [Test]
        public void TestInValidMoveOutRange()
        {
            Board board = new Board();
            Assert.That(board.IsValidMove(0, 8, 'X'), Is.EqualTo(false));

        }
        [Test]
        public void TestValidMove()
        {
            Board board = new Board();
            Assert.That(board.IsValidMove(2, 3, 'X'), Is.EqualTo(true));
        }
        [Test]
        public void TestMove()
        {
            Board board = new Board();
            board.MakeMove(2, 3, 'X');
            Assert.That(board.GetGrid()[2,3], Is.EqualTo('X'));
            Assert.That(board.GetGrid()[3,3], Is.EqualTo('X'));
            Assert.That(board.GetGrid()[4,3], Is.EqualTo('X'));
            Assert.That(board.GetGrid()[3,4], Is.EqualTo('X'));
            Assert.That(board.GetGrid()[4,4], Is.EqualTo('O'));
        }

        [Test]
        public void TestGameScore()
        {
            Board board = new Board();
            Assert.That(board.GameScore('X'), Is.EqualTo(2));
            Assert.That(board.GameScore('O'), Is.EqualTo(2));
        }
        [Test]
        public void TestGameScoreAfterMoving()
        {
            Board board = new Board();
            board.MakeMove(2,3,'X');
            Assert.That(board.GameScore('X'), Is.EqualTo(4));
            Assert.That(board.GameScore('O'), Is.EqualTo(1));
        }
        [Test]
        public void TestHasMoveForPlayer()
        {
            Board board = new Board();
            board.MakeMove(2, 3, 'X');
            Assert.That(board.HasMoveForPlayer('X'), Is.EqualTo(true));
            Assert.That(board.HasMoveForPlayer('O'), Is.EqualTo(true));  
        }
        [Test]
        public void TestHasMoveForPlayerFalse()
        {
            Board board = new Board();
            board.MakeMove(2, 3, 'X');
            board.MakeMove(4, 5, 'X');
            Assert.That(board.HasMoveForPlayer('X'), Is.EqualTo(false));
            Assert.That(board.HasMoveForPlayer('O'), Is.EqualTo(false));
        }
        [Test]
        public void TestGameEndedFalse()
        {
            IGameController gc = new GameController(new SimpleView());
            gc.MakeMove("D3");
            gc.SwitchPlayer();
            gc.MakeMove("F5");
            Assert.That(gc.IsGameEnded(), Is.EqualTo(true));
        }
        [Test]
        public void TestGameEnded()
        {
            IGameController gc = new GameController(new SimpleView());
            gc.MakeMove("D3");
            Assert.That(gc.IsGameEnded(), Is.EqualTo(false));
            
        }
        [Test]
        public void TestWinner()
        {
            IGameController gc = new GameController(new SimpleView());
            gc.MakeMove("D3");
            gc.SwitchPlayer();
            gc.MakeMove("F5");
            Assert.That(gc.Winner(), Is.EqualTo('X'));

        }
        [Test]
        public void TestWinnerNull()
        {
            IGameController gc = new GameController(new SimpleView());
            gc.MakeMove("D3");
            
            Assert.That(gc.Winner(), Is.EqualTo(null));

        }
 
    }
}