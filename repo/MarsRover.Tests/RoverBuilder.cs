namespace MarsRover.Tests
{
	internal class RoverBuilder
	{
		private int _x = 0;
		private int _y = 0;
		private char _direction = 'E';

		public RoverBuilder StartingAt(int x, int y)
		{
			_x = x;
			_y = y;
			return this;
		}

		public RoverBuilder FacingDirection(char diraction)
		{
			_direction = diraction;
			return this;
		}

		public Rover Build()
		{
			return new Rover(_x, _y, _direction);
		}
	}
}