using System;
using System.Collections.Generic;
using System.Text;
namespace groundObstacle
{
	public class obstacles
	{
		//An obstacle ("l") will have a random chance to spawn every tick after 6 ticks from the last obstacle. 
		//If no obstacle has spawned yet then it can randomly spawn immediatly. 
		//This will be done when an obstacle can spawn on the right of the grid view and move to the left at tick speed.

		int designChoice = 223;
		public obstacles()
		{
			System.Console.WriteLine("{0} = {1}", designChoice, (char)designChoice);
		}
	}
}
