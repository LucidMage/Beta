function Lesson3A::Setup(%this)
{
	PreSetupActivity(%this);
	
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
	%this.objective[1] = "Find a way out of the forest.";
	%this.objective[2] = "Help the lost people. Helped:" SPC %this.helped @ ", of" SPC %this.totalLost @ ".";
	
	%this.currentObjective = 1;
	
	PostSetupActivity(%this);
}

function Lesson3A::UpdateStatus(%this)
{
   %this.helped = Lesson3A_Forest.CountHelped();
   
	if (%this.HasHelpedPeople())
	{
		%this.currentObjective = 0;
		%this.OpenExit();
	}
	else
	{  // So the objective displays the current number
	   %this.objective[2] = "Help the lost people. Helped:" SPC %this.helped @ ", of" SPC %this.totalLost @ ".";
		%this.currentObjective = 2;
	}
	
	UpdateHelpBar(%this, 0);
	//%this.OpenExit();
}

//	Runs each time a person is helped
function Lesson3A::HasHelpedPeople(%this)
{
	if (%this.helped >= %this.totalToExit)
		return true;
	else
		return false;
}

function Lesson3A::OpenExit(%this)
{
   GameWindow.startCameraShake(10, 100);
   Lesson3A_Forest.remove(L3A_ExitObstacle);
   GameWindow.schedule(500, stopCameraShake);
}