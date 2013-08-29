// Treat this as a class constructor for the lesson
function Lesson1::onAdd( %this )
{
	PreSetupActivity(%this);
	%this.setup();
	PostSetupActivity(%this);
}

function Lesson1::setup(%this)
{
	// Load Scenes
	exec("./scenes/testtown.cs");
	exec("./scenes/garden.cs");
	exec("./scenes/testart.cs");

	//CreateScene(testtown);
	//CreateScene(garden);
	//CreateScene(testart);

	//	Set Starting Scene
	%startScene = testart;

	//	Setup Objectives
	%this.objective[0] = "Explore the town";
	%this.objective[1] = "Find the three gems";

	//SetScene(new Scene());
	//new ScriptObject("testtown");
	LoadScene(%startScene);
}