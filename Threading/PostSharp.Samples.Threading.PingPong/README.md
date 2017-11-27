This example implements the classic ping-pong game between two players using *actors*.

The players are represented by the `Player` class. Each player has a skill level between 0 and 1, equal to the probability to successfully
receive a ball. The `Ping` method evaluate this probability for the current player and, in case of success, calls the `Ping` method for the peer player.

To make the example more interesting and truly multi-threaded, we are introducing several balls in the game, each of a different color.

As an additional funny requirement, we want to display a colored message to the console every time a player handles the ball. Since writing a message in a given color using
`System.Console` take two calls (one to `Console.ForegroundColor` and one to `Console.WriteLine`), which must be done atomically, we would be tempted to use a `lock`. But the
whole point of threading models is to avoid using locks, so let's be more creative and do an API that wraps `System.Console` and makes it an actor too! This is actually
a very good idea: any intrinsically single-threaded device or "process" is a good candidate for an actor.
