using System.Linq;

namespace MarsRover.Tests
{
	public class Rover
	{
		private Position _position;

		public Rover(int x, int y, char direction)
		{
			_position = new Position(x, y, direction);

			if (x < 0 || y < 0)
				throw new StartingPointMustBeNonNegativeException();

			if (!IsValidDirection(direction))
				throw new InvalidDirectionException();
		}

		private static bool IsValidDirection(char direction)
		{
			var directionAsCapital = direction.ToString().ToUpper();

			return directionAsCapital == "N"
				   || directionAsCapital == "S"
				   || directionAsCapital == "W"
				   || directionAsCapital == "E";
		}

		private bool IsNotValid(char command)
		{
			return !IsValidCommand(command);
		}

		private bool IsValidCommand(char command)
		{
			return command == 'F'
				|| command == 'B'
				|| command == 'L'
				|| command == 'R';
		}

		public void Explore(string commands)
		{
			if (commands == null)
				throw new InvalidCommandException();

			commands = commands.ToUpper();
			if (commands.Any(IsNotValid))
				throw new InvalidCommandException();

			foreach (var command in commands)
			{
				if (command == 'F')
					_position = _position.Forward();
				else if (command == 'B')
					_position = _position.Backwards();
				else if (command == 'L')
					_position = _position.TurnLeft();
				else if (command == 'R')
					_position = _position.TurnRight();
			}
		}

		public bool IsAt(int x, int y)
		{
			return _position.IsAt(x, y);
		}

		public bool IsFacing(char direction)
		{
			return _position.IsFacing(direction);
		}
	}
}