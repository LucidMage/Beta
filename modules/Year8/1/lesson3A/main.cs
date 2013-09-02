// Treat this as a class constructor for the lesson
function Lesson3A::onAdd( %this )
{
	PreSetupActivity(%this);
	%this.setup();
	PostSetupActivity(%this);
}

function Lesson3A::setup(%this)
{
	// Load Scenes
	exec("./scenes/testart.cs");

	//	Set Starting Scene
	%startScene = testart;

	//	Setup Objectives
	%this.objective[0] = "Continue down the road";
	%this.objective[1] = "Find a way out of the forest";
	%this.objective[2] = "Help the lost travellers. Helped:" SPC %helped @ ", of" SPC %totalLost;

	LoadScene(%startScene);
}