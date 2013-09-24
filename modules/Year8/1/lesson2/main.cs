// Treat this as a class constructor for the lesson
function Lesson2::onAdd( %this )
{
	PreSetupActivity(%this);
	%this.Setup();
	PostSetupActivity(%this);
}

function Lesson2::Setup(%this)
{
	// Load Scenes
	exec("./scenes/loadList.cs");
	
	//	Objective tracking
	%this.found = 0;
	%this.orbsInGate = 0;
	//%this.totalOrbs = 0;

	//	Set Starting Scene
	%startScene = Lesson2_Gate;

	LoadScene(%startScene);
	
	%this.totalToExit = %this.totalOrbs;

	//	Setup Objectives
	%this.objective[1] = "Find a way out to open the gate";
	%this.objective[2] = "Find all of the orbs. Found " SPC %this.found @ ", of" SPC %this.totalOrbs SPC "orbs.";
	%this.objective[3] = "Use the orbs to open the gate.";
	
	%this.currentObjective = 0;
}

function Lesson2::UpdateStatus(%this)
{
	if (HasHelpedPeople())
		%this.currentObjective = 0;
	else
		%this.currentObjective = 2;
	
	UpdateHelpBar(%this, "");
}

//	Runs each time a orb is picked up
function Lesson2::FoundAllOrbs(%this)
{
	if (%this.found >= %this.totalOrbs)
		return true;
	else
		return false;
}

//	Runs each time an orb is inserted into the gate slot
function Lesson2::AllOrbsSlotted(%this)
{
	
	if (%this.orbsInGate >= %this.totalOrbs)
		return true;
	else
		return false;
}