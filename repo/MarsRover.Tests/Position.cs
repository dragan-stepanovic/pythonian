namespace MarsRover.Tests
{
	public class Position
	{
		private readonly int _x;
		private readonly int _y;
		private readonly char _direction;

		public Position(int x, int y, char direction)
		{
			_x = x;
			_y = y;
			_direction = direction;
		}

		public Position Forward()
		{
			var dy = 0;
			var dx = 0;

			if (_direction == 'E')
				dx = 1;
			else if (_direction == 'W')
				dx = -1;
			else if (_direction == 'N')
				dy = 1;
			else if (_direction == 'S')
				dy = -1;

			return new Position(_x + dx, _y + dy, _direction);
		}

		public Position Backwards()
		{
			var dy = 0;
			var dx = 0;

			if (_direction == 'E')
				dx = -1;
			else if (_direction == 'W')
				dx = 1;
			else if (_direction == 'N')
				dy = -1;
			else if (_direction == 'S')
				dy = 1;

			return new Position(_x + dx, _y + dy, _direction);
		}

		public Position TurnLeft()
		{
			var direction = _direction;

			if (_direction == 'S')
				direction = 'E';
			else if (_direction == 'E')
				direction = 'N';
			else if (_direction == 'N')
				direction = 'W';
			else if (_direction == 'W')
				direction = 'S';

			return new Position(_x, _y, direction);
		}

		public Position TurnRight()
		{
			var direction = _direction;

			if (_direction == 'S')
				direction = 'W';
			else if (_direction == 'W')
				direction = 'N';
			else if (_direction == 'N')
				direction = 'E';
			else if (_direction == 'E')
				direction = 'S';

			return new Position(_x, _y, direction);
		}

		public bool IsAt(int x, int y)
		{
			return _x == x && _y == y;
		}

		public bool IsFacing(char direction)
		{
			var directionAsCapital = direction.ToString().ToUpper();
			return _direction.ToString() == directionAsCapital;
		}
	}
}