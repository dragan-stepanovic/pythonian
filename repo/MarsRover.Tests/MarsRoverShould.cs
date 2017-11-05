using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
	public class MarsRoverShould
	{
		[Theory]
		[InlineData(-1, 1)]
		[InlineData(1, -1)]
		[InlineData(-1, -1)]
		public void NotAcceptNegativeStartingPoint(int x, int y)
		{
			Assert.Throws<StartingPointMustBeNonNegativeException>(() => ARover().StartingAt(x, y).Build());
		}

		[Theory]
		[InlineData(1, 1)]
		public void AcceptNonNegativeStartingPoint(int x, int y)
		{
			ARover().StartingAt(x, y).Build();
		}

		[Fact]
		public void NotAcceptInvalidDirection()
		{
			Assert.Throws<InvalidDirectionException>(() => ARover().FacingDirection('P').Build());
		}

		[Theory]
		[InlineData('n')]
		[InlineData('N')]
		[InlineData('s')]
		[InlineData('S')]
		[InlineData('e')]
		[InlineData('E')]
		[InlineData('w')]
		[InlineData('W')]
		public void AcceptValidDirection(char direction)
		{
			ARover().FacingDirection(direction).Build();
		}

		[Theory]
		[InlineData("")]
		[InlineData("f")]
		[InlineData("F")]
		[InlineData("ff")]
		[InlineData("fF")]
		[InlineData("FF")]
		[InlineData("b")]
		[InlineData("B")]
		[InlineData("bb")]
		[InlineData("bB")]
		[InlineData("BB")]
		public void AcceptValidCommands(string commands)
		{
			ARover().Build().Explore(commands);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("x")]
		[InlineData("y")]
		[InlineData("xy")]
		[InlineData("fx")]
		[InlineData("by")]
		public void NotAcceptInvalidCommands(string commands)
		{
			Assert.Throws<InvalidCommandException>(() => ARover().Build().Explore(commands));
		}

		private static RoverBuilder ARover()
		{
			return new RoverBuilder();
		}

		[Theory]
		[InlineData(0, 0, 'E', "f", 1, 0)]
		[InlineData(0, 0, 'N', "f", 0, 1)]
		[InlineData(0, 0, 'W', "f", -1, 0)]
		[InlineData(0, 0, 'S', "f", 0, -1)]
		[InlineData(0, 0, 'E', "ff", 2, 0)]
		[InlineData(0, 0, 'N', "ff", 0, 2)]
		[InlineData(0, 0, 'W', "ff", -2, 0)]
		[InlineData(0, 0, 'S', "ff", 0, -2)]
		[InlineData(0, 0, 'E', "b", -1, 0)]
		[InlineData(0, 0, 'N', "b", 0, -1)]
		[InlineData(0, 0, 'W', "b", 1, 0)]
		[InlineData(0, 0, 'S', "b", 0, 1)]
		[InlineData(0, 0, 'E', "bb", -2, 0)]
		[InlineData(0, 0, 'N', "bb", 0, -2)]
		[InlineData(0, 0, 'W', "bb", 2, 0)]
		[InlineData(0, 0, 'S', "bb", 0, 2)]
		[InlineData(0, 0, 'S', "fb", 0, 0)]
		[InlineData(0, 0, 'S', "fbbbbbfbbfffff", 0, 0)]
		public void BeAbleToMoveForwardAndBackwards(int x1, int y1, char direction, string commands, int x2, int y2)
		{
			var rover = ARover().StartingAt(x1, y1).FacingDirection(direction).Build();

			rover.Explore(commands);

			rover.IsAt(x2, y2).Should().BeTrue();
		}

		[Theory]
		[InlineData('S', "L", 'E')]
		[InlineData('S', "LL", 'N')]
		[InlineData('S', "LLL", 'W')]
		[InlineData('S', "LLLL", 'S')]
		[InlineData('S', "R", 'W')]
		[InlineData('S', "RR", 'N')]
		[InlineData('S', "RRR", 'E')]
		[InlineData('S', "RRRR", 'S')]
		[InlineData('W', "RRLRLRRL", 'E')]
		public void BeAbleToTurn(char direction1, string commands, char direction2)
		{
			var rover = ARover().FacingDirection(direction1).Build();

			rover.Explore(commands);

			rover.IsFacing(direction2).Should().BeTrue();
		}

		[Fact]
		public void BeAbleToReportPosition()
		{
			ARover().StartingAt(0, 0).Build().IsAt(0, 0).Should().BeTrue();
			ARover().StartingAt(0, 0).Build().IsAt(1, 1).Should().BeFalse();
		}

	}
}