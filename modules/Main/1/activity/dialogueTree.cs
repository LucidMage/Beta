//	Default constructor
function DialogueTree::Setup(%this, %owner)
{
	//	Link the dialogue tree to it's owner
	%this.owner = %owner;
	%this.owner.dialogueTree = %this;
	
	if (!isObject(%this.rootDialogue[0]))
	{
      %this.rootDialogue[0] = new ScriptObject()
      {
         class = Dialogue;
      };
      %this.rootDialogue[0].Setup("TEST DIALOGUE, SHOULD DISPLAY IN THE DIALOGUE BOX. THIS DIALOGUE TREE BELONGS TO" SPC %this.owner.displayName @ ". THE CURRENT TARGET IS" SPC %this.target.displayName);
	}
	
	%this.selectedRootDialogue = 0;	//	Used for deciding the dialogue to open with
}

//	Initialize dialogue with the owner
//	Target = who the owner is talking to
function DialogueTree::OpenDialogue(%this, %target)
{
	%this.target = %target;
	
	//	Continue if no scripting is set for the dialogue to not open
	//	e.g. simple pop-up saying "I'm busy, go away"
	if (%this.onOpen())
	{
		DialogueContainer.setVisible(true);
		ResponseContainer.setVisible(true);
		
		//	Should be overwritten unless no dialogue could be fetched
		DialogueLabel.setText("ERROR");
		DialogueText.setText("No opening dialogue to select.");
		
		//	Fetch selected opening dialogue
		%this.currentDialogue = %this.rootDialogue[%this.selectedRootDialogue];
		
		%this.currentDialogue.Display(%this.owner, %this.target);
		
		if (%this.currentDialogue.faceTarget)
			%this.owner.faceTarget(%this.target);
		
		//	Disable regular controls and change to dialogue controls
		Player.inDialogue = true;//setDialogueBehaviours();
	}
}

//	Close dialogue
function DialogueTree::CloseDialogue(%this)
{
	DialogueContainer.setVisible(false);
	ResponseContainer.setVisible(false);
	
	//	Continue if no scripting is set for the player to remain immobile
	if (%this.onClose())
	{
		Player.inDialogue = false;
	}
}

function DialogueTree::NextDialogue(%this, %i)
{
	//	Error checking - is %i an index number
	if (%i > 0 && %i <= $DialogueResponseMax)
	{
		//	Is there a response for that index
		if (%this.currentDialogue.responseDialogue[%i] !$= "")
		{
			%this.currentDialogue = %this.currentDialogue.responseDialogue[%i];
			
			//	Continue if no scripting is set to interrupt the dialogue
			if (%this.onNext())
			{
				%this.currentDialogue.Display(%this.owner, %this.target);
				
				if (%this.currentDialogue.faceTarget)
					%this.owner.faceTarget(%this.target);
			}
		}
		else
			error("No dialogue set for response" SPC %i);
	}
	else
		error(%i SPC "is not a dialogue index for" SPC %this.owner.getName());
}

//	Callbacks
function DialogueTree::onOpen(%this)	{	return true;	}
function DialogueTree::onClose(%this)	{	return true;	}
function DialogueTree::onNext(%this)	{	return true;	}