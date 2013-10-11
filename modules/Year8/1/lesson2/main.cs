function Lesson2::Setup(%this)
{
	PreSetupActivity(%this);
	
	// Load Scenes
	exec("./scenes/loadList.cs");
	exec("./dialogue/loadList.cs");
	
	//	Objective tracking
	%this.found = 0;
	%this.orbsInGate = 0;
	//%this.totalOrbs = 0;

	//	Set Starting Scene
	%startScene = Lesson2_Gate;

	LoadScene(%startScene);
	
	%this.totalToExit = %this.totalOrbs;

	//	Setup Objectives
	%this.objective[1] = "Find a way to open the gate.";
	%this.objective[2] = "Find all of the orbs. Found" SPC %this.found SPC "of" SPC %this.totalOrbs SPC "orbs.";
	%this.objective[3] = "Use the orbs to open the gate." SPC %this.orbsInGate SPC "of" SPC %this.totalOrbs SPC "orbs slotted.";
	
	%this.currentObjective = 0;
	
	PostSetupActivity(%this);
}

function Lesson2::UpdateStatus(%this)
{
	if (%this.AllOrbsSlotted())
	{
		%this.currentObjective = 0;
		%this.MoveGates();
	}
	else if (%this.AllOrbsFound())
	{  // So the objective displays the current number
		%this.objective[3] = "Use the orbs to open the gate." SPC %this.orbsInGate SPC "of" SPC %this.totalOrbs SPC "orbs slotted.";
		%this.currentObjective = 3;
	}
	else
	{  // So the objective displays the current number
		%this.objective[2] = "Find all of the orbs. Found" SPC %this.found SPC "of" SPC %this.totalOrbs SPC "orbs.";
		%this.currentObjective = 2;
	}
	
	UpdateHelpBar(%this);
}

//	Check if all orbs have been found
function Lesson2::AllOrbsFound(%this)
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

//	Move gates
function Lesson2::MoveGates(%this)
{
   %position = GateWestOpenPos.getPosition();
   %position.y = L2_DoorWest.getPosition().y;
   L2_DoorWest.moveTo(%position, L2_DoorWest.speed, false, false);
   
   %position = GateEastOpenPos.getPosition();
   %position.y = L2_DoorEast.getPosition().y;
   L2_DoorEast.moveTo(%position, L2_DoorEast.speed, false, false);
}