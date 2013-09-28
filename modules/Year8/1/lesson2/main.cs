function Lesson2::Setup(%this)
{
	echo("Lesson2 onAdd");
	PreSetupActivity(%this);
	
	// Load Scenes
	exec("./scenes/loadList.cs");
	
	//	Objective tracking
	%this.found = 0;
	%this.orbsInGate = 0;
	//%this.totalOrbs = 0;

	//	Set Starting Scene
	%startScene = Lesson2_Gate;

	echo("Load Scene");
	LoadScene(%startScene);
	echo("After Load Scene");
	
	%this.totalToExit = %this.totalOrbs;

	//	Setup Objectives
	%this.objective[1] = "Find a way to open the gate";
	%this.objective[2] = "Find all of the orbs. Found" SPC %this.found SPC "of" SPC %this.totalOrbs SPC "orbs.";
	%this.objective[3] = "Use the orbs to open the gate." SPC %this.orbsInGate SPC "of" SPC %this.totalOrbs SPC "orbs slotted.";
	
	%this.currentObjective = 0;
	
	PostSetupActivity(%this);
}

function Lesson2::UpdateStatus(%this)
{
	echo("All Orbs Slotted" SPC AllOrbsSlotted());
	echo("All Orbs Found" SPC FoundAllOrbs());
	
	if (AllOrbsSlotted())
		%this.currentObjective = 0;
	else if (FoundAllOrbs())
	{
		%this.objective[3] = "Use the orbs to open the gate." SPC %this.orbsInGate SPC "of" SPC %this.totalOrbs SPC "orbs slotted.";
		%this.currentObjective = 3;
	}
	else
	{
		//	Must be reset to display current values
		%this.objective[2] = "Find all of the orbs. Found" SPC %this.found SPC "of" SPC %this.totalOrbs SPC "orbs.";
		%this.currentObjective = 2;
	}
	
	UpdateHelpBar(%this, 0);
}

//	Check if all orbs have been found
function Lesson2::FoundAllOrbs(%this)
{
	if (%this.found >= %this.totalOrbs)
		return true;
	else
		return false;
}

//	Check all orbs have been inserted into the gate slots
function Lesson2::AllOrbsSlotted(%this)
{
	if (%this.orbsInGate >= %this.totalOrbs)
		return true;
	else
		return false;
}

//	Runs each time a orb is picked up
function Lesson2::PickUpOrb(%this)
{
	%this.found++;
	%this.UpdateStatus();
}