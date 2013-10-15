function Dialogue::Setup(%this, %text)
{
	%this.dialogue = %text;
	
	%this.responseText[0] = "[End Dialogue]";
	%this.responseCount = 0;
	
	%this.beenRead = false;		//	Used for tracking 
	%this.canEnd = true;		//	Is there an option to close dialogue
	%this.canRepeat = true;		//	Will this appear more than once
	%this.faceTarget = true;	//	Will the owner face the player
}

//	Display dialogue elements
function Dialogue::Display(%this, %owner, %target)
{
	%this.beenRead = true;
	
	DialogueLabel.setText(%owner.displayName);
	DialogueText.setText(%this.dialogue);
	
	%this.updateResponseArray(%owner);
}

//	Updates GUI to display responses from this dialogue
function Dialogue::UpdateResponseArray(%this, %owner)
{
	ResponseArray.clear();
	
	%width = ResponseArray.getExtent().x;
	%height = 0;//$GUIResponseHeight;
	
	//	Responses 1-9
	for (%i = 1; %i <= %this.responseCount; %i++)
	{
		if (!(%this.responseDialogue[%i].beenRead = true && %this.responseDialogue[%i].canRepeat = false))
		{
			%height += $GUIResponseHeight;
			ResponseArray.DisplayResponse(%owner, %this, %i);
		}
	}
	
	//	End Dialogue Response
	if (%this.canEnd)
	{
		%height += $GUIResponseHeight;
		ResponseArray.DisplayResponse(%owner, %this, 0);
	}
	
	ResponseArray.resize(0, 0, %width, %height);
}

//	Add a response for the player to select
//	Text = the text displayed for this response
//	Next Dialogue = the dialogue object this response will lead to when selected
function Dialogue::AddResponse(%this, %text, %nextDialogue)
{
	if (%this.responseCount <= $DialogueResponseMax)
	{
		%this.responseCount++;
		%i = %this.responseCount;
		
		%this.responseText[%i] = %text;
		%this.responseDialogue[%i] = %nextDialogue;
	}
	else
		warn("Cannot add response to" SPC %this.dialogue @ ". Max response number reached.");
}

//	Remove response by index
//	- or -
//	Remove all responses leading to a dialogue
/*	NOTE: Since there's no way to tell the difference
	between parameter "int" and "Dialogue", as
	parameter types aren't enforced, this means I'll
	have to combine them and do type checking.	*/
function Dialogue::RemoveResponse(%this, %input)
{
	//	For Dialogue
	if (%input.class $= "Dialogue")
	{
		for (%i = 1; %i <= %this.responseCount; %i++)
			if (%responseDialogue[%i] == %input)
				//	Recurse using index
				%this.removeDialogue(%i);
	}
	//	For index
	else if (%input > 0 && %input < $DialogueResponseMax)
	{
		//	Shift all responses after target response back one slot, overwriting the target
		for (%i = %input + 1; %i <= %this.responseCount; %i++)
		{
			%this.responseText[%i - 1] = %this.responseText[%i];
			%this.responseDialogue[%i - 1] = %this.responseDialogue[%i];
		}
		
		%this.responseCount--;
	}
	else
		error("Wrong input type given to removeResponse for" SPC %this.dialogue);
}

//	Display the response on the GUI
function ResponseArray::DisplayResponse(%this, %owner, %dialogue, %i)
{
	//	Button positioning. Response 1 at the top, response 0 at the bottom
	if (%i == 0)
		%vertOrder = %this.responseCount + 1;
	else
		%vertOrder = %i;
	
	//	Size of button
	%extent = %this.getExtent();
	
	//	Add resposne as a GUI button
    %button = new GuiButtonCtrl()
    {
        canSaveDynamicFields = "0";
        HorizSizing = "width";
        VertSizing = "top";
        isContainer = "0";
        Profile = "DialogueResponseProfile";
        Position = "0" SPC ($GUIResponseHeight * (%vertOrder - 1));
        Extent = %extent.x SPC $GUIResponseHeight;
        MinExtent = "80 15";
        Visible = "1";
        isContainer = "0";
        Active = "1";
        text = "" TAB %i @ "." TAB %dialogue.responseText[%i];
        groupNum = "-1";
        buttonType = "PushButton";
        useMouseEvents = "1";
    };
	
	//	Assign command to response button
	if (%i == 0)
		%command = %owner @ ".dialogueTree.closeDialogue();";
	else
		%command = %owner @ ".dialogueTree.nextDialogue(" @ %i @ ");";
	
    %button.command = %command;
    
    %this.add(%button);
}