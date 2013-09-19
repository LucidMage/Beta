// Treat this as a class constructor for the lesson
function Lesson3A::onAdd( %this )
{
	PreSetupActivity(%this);
	%this.Setup();
	PostSetupActivity(%this);
}

function Lesson3A::Setup(%this)
{
	// Load Scenes
	exec("./scenes/loadList.cs");
	exec("./dialogue/loadList.cs");
	//exec("./scripts/loadList.cs");
	
	//	Objective tracking
	%this.helped = 0;
	//%this.totalLost = 0;

	//	Set Starting Scene
	%startScene = Lesson3A_Forest;

	LoadScene(%startScene);
	
	%this.totalToExit = %this.totalLost;

	//	Setup Objectives
	%this.objective[1] = "Find a way out of the forest";
	%this.objective[2] = "Help the lost people. Helped:" SPC %this.helped @ ", of" SPC %this.totalLost;
	
	%this.currentObjective = 1;
}

function Lesson3A::UpdateStatus(%this)
{
	if (HasHelpedPeople())
		%this.currentObjective = 0;
	else
		%this.currentObjective = 2;
	
	UpdateHelpBar(%this, "");
}

//	Runs each time a person is helped
function Lesson3A::HasHelpedPeople(%this)
{
	if (%this.helped >= %this.totalToExit)
		return true;
	else
		return false;
}