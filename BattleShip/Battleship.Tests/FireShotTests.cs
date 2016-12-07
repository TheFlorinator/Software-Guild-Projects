using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class FireShotTests
    {
        [Test]
        public void CoordinateEquality()
        {
            Coordinate coordinate1 = new Coordinate(5, 10);
            Coordinate coordinate2 = new Coordinate(5, 10);

            Assert.AreEqual(coordinate1, coordinate2);
        }

        [Test]
        public void CanNotFireOffBoard()
        {
            Board board = SetupBoard();

            Coordinate coordinate = new Coordinate(15, 20);

            FireShotResponse response = board.FireShot(coordinate);

            Assert.AreEqual(ShotStatus.Invalid, response.ShotStatus);
        }

        [Test]
        public void CanNotFireDuplicateShot()
        {
            Board board = SetupBoard();

            Coordinate coordinate = new Coordinate(5, 5);
            FireShotResponse response = board.FireShot(coordinate);

            Assert.AreEqual(ShotStatus.Miss, response.ShotStatus);

            // fire same shot
            response = board.FireShot(coordinate);
            Assert.AreEqual(ShotStatus.Duplicate, response.ShotStatus);
        }

        [Test]
        public void CanMissShip()
        {
            Board board = SetupBoard();

            Coordinate coordinate = new Coordinate(5, 5);
            FireShotResponse response = board.FireShot(coordinate);

            Assert.AreEqual(ShotStatus.Miss, response.ShotStatus);
        }

        [Test]
        public void CanHitShip()
        {
            Board board = SetupBoard();

            Coordinate coordinate = new Coordinate(1, 3);
            FireShotResponse response = board.FireShot(coordinate);

            Assert.AreEqual(ShotStatus.Hit, response.ShotStatus);
            Assert.AreEqual("Cruiser", response.ShipImpacted);
        }

        [Test]
        public void CanSinkShip()
        {
            Board board = SetupBoard();

            Coordinate coordinate = new Coordinate(6, 10);
            FireShotResponse response = board.FireShot(coordinate);

            Assert.AreEqual(ShotStatus.Hit, response.ShotStatus);
            Assert.AreEqual("Battleship", response.ShipImpacted);

            coordinate = new Coordinate(7, 10);
            response = board.FireShot(coordinate);

            Assert.AreEqual(ShotStatus.Hit, response.ShotStatus);
            Assert.AreEqual("Battleship", response.ShipImpacted);

            coordinate = new Coordinate(8, 10);
            response = board.FireShot(coordinate);

            Assert.AreEqual(ShotStatus.Hit, response.ShotStatus);
            Assert.AreEqual("Battleship", response.ShipImpacted);

            coordinate = new Coordinate(9, 10);
            response = board.FireShot(coordinate);

            Assert.AreEqual(ShotStatus.HitAndSunk, response.ShotStatus);
            Assert.AreEqual("Battleship", response.ShipImpacted);
        }

        [Test]
        public void CanWinGame()
        {
            Board board = SetupBoard();

            Assert.AreEqual(ShotStatus.HitAndSunk, SinkDestroyer(board).ShotStatus);
            Assert.AreEqual(ShotStatus.HitAndSunk, SinkCruiser(board).ShotStatus);
            Assert.AreEqual(ShotStatus.HitAndSunk, SinkSubmarine(board).ShotStatus);
            Assert.AreEqual(ShotStatus.HitAndSunk, SinkBattleship(board).ShotStatus);
            Assert.AreEqual(ShotStatus.Victory, SinkCarrier(board).ShotStatus);
        }

        private FireShotResponse SinkCarrier(Board board)
        {
            Coordinate coordinate = new Coordinate(4, 4);
            board.FireShot(coordinate);

            coordinate = new Coordinate(4, 5);
            board.FireShot(coordinate);

            coordinate = new Coordinate(4, 6);
            board.FireShot(coordinate);

            coordinate = new Coordinate(4, 7);
            board.FireShot(coordinate);

            coordinate = new Coordinate(4, 8);
            return board.FireShot(coordinate);
        }

        private FireShotResponse SinkBattleship(Board board)
        {
            Coordinate coordinate = new Coordinate(6, 10);
            board.FireShot(coordinate);

            coordinate = new Coordinate(7, 10);
            board.FireShot(coordinate);

            coordinate = new Coordinate(8, 10);
            board.FireShot(coordinate);

            coordinate = new Coordinate(9, 10);
            return board.FireShot(coordinate);
        }

        private FireShotResponse SinkSubmarine(Board board)
        {
            Coordinate coordinate = new Coordinate(5, 1);
            board.FireShot(coordinate);

            coordinate = new Coordinate(5, 2);
            board.FireShot(coordinate);

            coordinate = new Coordinate(5, 3);
            return board.FireShot(coordinate);
        }

        private FireShotResponse SinkCruiser(Board board)
        {
            Coordinate coordinate = new Coordinate(1, 3);
            board.FireShot(coordinate);

            coordinate = new Coordinate(2, 3);
            board.FireShot(coordinate);

            coordinate = new Coordinate(3, 3);
            return board.FireShot(coordinate);
        }

        private FireShotResponse SinkDestroyer(Board board)
        {
            Coordinate coordinate = new Coordinate(8, 1);
            board.FireShot(coordinate);

            coordinate = new Coordinate(8, 2);
            return board.FireShot(coordinate);
        }

        /// <summary>
        /// Let's set up a board as follows:
        /// Destroyer: (1,8) (2,8)
        /// Cruiser: (3,1) (3,2) (3,3)
        /// Sub: (1,5) (2,5) (3,5)
        /// Battleship: (10,6) (10,7) (10,8) (10, 9)
        /// Carrier: (4,4) (5,4) (6,4) (7,4) (8,4)
        /// 
        ///    1 2 3 4 5 6 7 8 9 10
        ///  1     R
        ///  2     R
        ///  3     R
        ///  4       C C C C C
        ///  5 S S S
        ///  6                   B
        ///  7                   B
        ///  8 D D               B
        ///  9                   B
        /// 10
        /// </summary>
        /// <returns>A board that is ready to play</returns>
        private Board SetupBoard()
        {
            Board board = new Board();

            PlaceDestroyer(board);
            PlaceCruiser(board);
            PlaceSubmarine(board);
            PlaceBattleship(board);
            PlaceCarrier(board);

            return board;
        }

        private void PlaceCarrier(Board board)
        {
            PlaceShipRequest request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(4, 4),
                Direction = ShipDirection.Right,
                ShipType = ShipType.Carrier
            };

            board.PlaceShip(request);
        }

        private void PlaceBattleship(Board board)
        {
            PlaceShipRequest request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(6, 10),
                Direction = ShipDirection.Down,
                ShipType = ShipType.Battleship
            };

            board.PlaceShip(request);
        }

        private void PlaceSubmarine(Board board)
        {
            PlaceShipRequest request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(5, 3),
                Direction = ShipDirection.Left,
                ShipType = ShipType.Submarine
            };

            board.PlaceShip(request);
        }

        private void PlaceCruiser(Board board)
        {
            PlaceShipRequest request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(3, 3),
                Direction = ShipDirection.Up,
                ShipType = ShipType.Cruiser
            };

            board.PlaceShip(request);
        }

        private void PlaceDestroyer(Board board)
        {
            PlaceShipRequest request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(8, 1),
                Direction = ShipDirection.Right,
                ShipType = ShipType.Destroyer
            };

            board.PlaceShip(request);
        }
    }
}
