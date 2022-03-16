# ChangHur_TapBlaze_Wheel
Tapblaze_interview_task
Overview of Project Structure

	The project was to create a simple Wheel of Fortune type game for either Android or iOS. Android was chosen as the build, due to my ownership of an Android.

	This was a simple game with very few states, so the use of a singleton pattern through ‘StateManager’ was used to keep the flow of the game together as opposed to a finite state machine. The enums were named Main, Spin, and Reward, with the OnGameStateChanged event every time the game state changed through an update method.
	The use of enums is also helpful for future updates to the game as it should be easy to introduce new states to the game with minimal effort.
Player input through the button presses is what mainly drove the change states, with easy access to the StateManager through its static instance making this easy to code for.

	A UI manager (UIActiveManager) and the main reward script (RewardSpin) were subscribed to  the OnGameStateChanged event.
The UI manager mainly activated and deactivated various UI elements on the screen depending on the state the game is currently in.
	The RewardSpin class runs both the methods that eventually calculates the reward while also running the method to start the wheel spinning and leading onto the next state.

Reward Calculation

	I have used a static RewardAarryNM class to create an array of prize results based on the project guidelines. The main reason for making a separate class for this is that it could be the case that the prize parameters might change in the future (perhaps in a csv file or text file), and having a class that can deal with this incoming data in the future seemed useful.

	On top of this RewardArrayNM class is the RewardListNM class, whose main function is to create a list of rewards based on the information from the array. The Reward class contains basic information such as a prize, amount, and a specified ID. The percentage chances of the rewards were turned into a range by summing the given percents. This was done to allow to allow both for the possibility of changing the drop chances, as well as changing the number of awards available.

	The RewardDecideNM is the main output class where the prize is actually determined. It uses a random number from 0~100 and uses the ranges acquired above to determine the prize, and outputs an ID. This is passed by the RewardSpin class to spin the wheel.
	This was done in two steps, with one method providing the random number, and the other determining which prize this number would land on just to keep things nice and modular.

	The NM nomenclature is just a personal habit of recording which scripts are non-monobehavior.

The Wheel

	The wheel spinning was also done in the flexible way. The location to land on was calculated by dividing the circle by the number of rewards on the list. So this method can handle any increases or decreases to the number of prizes.

	The reward icons on the wheel sprite itself are not just simple objects, but take in scriptable objects to change their sprite and text. This is makes it possible to change the reward type and number during runtime.


Unit Tests

Unit tests were done with the Unity unit testing package, and can be accessed through the Test Runner. 

	The RewardChances script will run the rewards a thousand times, output the results into the console, and inform the programmer of how many times each reward was gotten.

	The RewardSnipe script requires the programmer to edit the file itself and edit both the number being put in (0~100), as well as the expected id output. The ranges for the expected ids are written in as comments above. 

To-dos

	I feature that I wanted to add, but ultimately decided to skip due to time constrains is the automatic placement of the reward icon on the wheel. This is a feature is essential to making this game be able to change the number of rewards. Like-wise, the wheel and border were hand placed too, and no code currently exists to change them on the fly.

	The game came out quite blurry, and given more time I would have been able to determine the cause of this.
