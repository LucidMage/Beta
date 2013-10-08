//======	Dialogue Tree    ======//
new ScriptObject(L3A_BroadShoulderDialogueTree)	{	class = DialogueTree;	};
L3A_BroadShoulderDialogueTree.Setup(L3A_BroadShoulderPerson);

//======	Dialogue    ======//
//==	Beginning    ==//
//	First time talking to player
%text = "Hi, are you lost as well?";
new ScriptObject(L3A_BroadShoulderDialogueInitGreeting)	{	class = Dialogue;	};
L3A_BroadShoulderDialogueInitGreeting.Setup(%text);
L3A_BroadShoulderDialogueInitGreeting.canEnd = false;
L3A_BroadShoulderDialogueInitGreeting.canRepeat = false;

//	"Do you need help?"
%text = "No I'm fine... Actually, there is one thing I'm curious about. I think my shoulders have become broader. I don't suppose you'd know why?";
new ScriptObject(L3A_BroadShoulderDialogueInitExplain1)	{	class = Dialogue;	};
L3A_BroadShoulderDialogueInitExplain1.Setup(%text);
L3A_BroadShoulderDialogueInitExplain1.canEnd = false;
//L3A_BroadShoulderDialogueInitExplain1.canRepeat = false;

//	"I guess you have a bodily change you are worried about."
%text = "What? No. Well, yes part of my body has changed but I'm more curious than worried. I think my shoulders have become broader. I don't suppose you'd know why?";
new ScriptObject(L3A_BroadShoulderDialogueInitExplain2)	{	class = Dialogue;	};
L3A_BroadShoulderDialogueInitExplain2.Setup(%text);
L3A_BroadShoulderDialogueInitExplain2.canEnd = false;
//L3A_BroadShoulderDialogueInitExplain2.canRepeat = false;
/*
//	 [Continue]
%text = "";
new ScriptObject(L3A_BroadShoulderDialogueInitExplainContinue)	{	class = Dialogue;	};
L3A_BroadShoulderDialogueInitExplainContinue.Setup(%text);
L3A_BroadShoulderDialogueInitExplainContinue.canEnd = false;
//L3A_BroadShoulderDialogueInitExplainContinue.canRepeat = false;
*/
//	Still needs help
%text = "I'm still curious about why my shoulders are becoming broader.";
new ScriptObject(L3A_BroadShoulderDialogueRepeatGreeting)	{	class = Dialogue;	};
L3A_BroadShoulderDialogueRepeatGreeting.Setup(%text);
L3A_BroadShoulderDialogueRepeatGreeting.canEnd = false;

//	Been helped
%text = "Thanks again for the info. I guess I'll see you outside the forest";
new ScriptObject(L3A_BroadShoulderDialogueHelpedGreeting)	{	class = Dialogue;	};
L3A_BroadShoulderDialogueHelpedGreeting.Setup(%text);

//==	Middle    ==//
//	"Your muscles have started developing."
%text = "Sweet! So I'll end up looking like a body builder?";
new ScriptObject(L3A_BroadShoulderDialogueMidAnswer)	{	class = Dialogue;	};
L3A_BroadShoulderDialogueMidAnswer.Setup(%text);
L3A_BroadShoulderDialogueMidAnswer.canEnd = false;

//==	End    ==//
//	"No."
//	"You'll still need to exercise and eat healthy."
//	"Only if you start bodybuilding."
%text = "Damn. Aw well, some muscle is better than no muscle right. Thanks for the info.";
new ScriptObject(L3A_BroadShoulderDialogueEndHelped1)	{	class = Dialogue;	};
L3A_BroadShoulderDialogueEndHelped1.Setup(%text);

//	"Its from stretching a lot."
%text = "Can stretching really do that? Can't say I've been stretching much though. Anyway, thanks for the info.";
new ScriptObject(L3A_BroadShoulderDialogueEndHelped2)	{	class = Dialogue;	};
L3A_BroadShoulderDialogueEndHelped2.Setup(%text);

//	Not helped
%text = "Meh, worth a shot. If anything comes to mind, let me know.";
new ScriptObject(L3A_BroadShoulderDialogueEndNotHelped)	{	class = Dialogue;	};
L3A_BroadShoulderDialogueEndNotHelped.Setup(%text);

//======	Assemble Tree    ======//
//==	Beginning    ==//
L3A_BroadShoulderDialogueTree.rootDialogue[0] = L3A_BroadShoulderDialogueInitGreeting;
L3A_BroadShoulderDialogueTree.rootDialogue[1] = L3A_BroadShoulderDialogueRepeatGreeting;
L3A_BroadShoulderDialogueTree.rootDialogue[2] = L3A_BroadShoulderDialogueHelpedGreeting;

//	Link to Explaination 1
%text = "Do you need help?";
L3A_BroadShoulderDialogueInitGreeting.AddResponse(%text, L3A_BroadShoulderDialogueInitExplain1);
//	Link to Explaination 2
%text = "I guess you have a bodily change you are worried about.";
L3A_BroadShoulderDialogueInitGreeting.AddResponse(%text, L3A_BroadShoulderDialogueInitExplain2);
/*
//	Link to Continued Explaination
%text = "[Continue]";
L3A_BroadShoulderDialogueInitExplain1.AddResponse(%text, L3A_BroadShoulderDialogueInitExplainContinue);
L3A_BroadShoulderDialogueInitExplain2.AddResponse(%text, L3A_BroadShoulderDialogueInitExplainContinue);
*/
//==	Middle    ==//
//	Link to "Sweet! So I'll end up looking like a body builder?"
%text = "Your muscles have started developing.";
L3A_BroadShoulderDialogueInitExplain1.AddResponse(%text, L3A_BroadShoulderDialogueMidAnswer);
L3A_BroadShoulderDialogueInitExplain2.AddResponse(%text, L3A_BroadShoulderDialogueMidAnswer);
L3A_BroadShoulderDialogueRepeatGreeting.AddResponse(%text, L3A_BroadShoulderDialogueMidAnswer);

//==	End    ==//
//	Link to Helped 1
%text = "No.";
L3A_BroadShoulderDialogueMidAnswer.AddResponse(%text, L3A_BroadShoulderDialogueEndHelped1);
%text = "You'll still need to exercise and eat healthy.";
L3A_BroadShoulderDialogueMidAnswer.AddResponse(%text, L3A_BroadShoulderDialogueEndHelped1);
%text = "Only if you start bodybuilding.";
L3A_BroadShoulderDialogueMidAnswer.AddResponse(%text, L3A_BroadShoulderDialogueEndHelped1);

//	Link to Helped 2
%text = "Its from stretching a lot.";
L3A_BroadShoulderDialogueInitExplain1.AddResponse(%text, L3A_BroadShoulderDialogueEndHelped2);
L3A_BroadShoulderDialogueInitExplain2.AddResponse(%text, L3A_BroadShoulderDialogueEndHelped2);
L3A_BroadShoulderDialogueRepeatGreeting.AddResponse(%text, L3A_BroadShoulderDialogueEndHelped2);

//	Link to Not Helped
%text = "No.";
L3A_BroadShoulderDialogueInitExplain1.AddResponse(%text, L3A_BroadShoulderDialogueEndNotHelped);
L3A_BroadShoulderDialogueInitExplain2.AddResponse(%text, L3A_BroadShoulderDialogueEndNotHelped);
%text = "I still don't know.";
L3A_BroadShoulderDialogueRepeatGreeting.AddResponse(%text, L3A_BroadShoulderDialogueEndNotHelped);

//======	Callbacks    ======//
function L3A_BroadShoulderDialogueTree::onOpen(%this)
{
	if (%this.owner.helped)
		%this.selectedRootDialogue = 2;
	else if (%this.rootDialogue[0].beenRead)
		%this.selectedRootDialogue = 1;
	
	return true;
}
function L3A_BroadShoulderDialogueTree::onClose(%this)
{
	if (%this.currentDialogue $= L3A_BroadShoulderDialogueEndHelped1 ||
		%this.currentDialogue $= L3A_BroadShoulderDialogueEndHelped2)
	{
		%this.owner.helped = true;
		Lesson3A.UpdateStatus();
	}

	return true;
}
function L3A_BroadShoulderDialogueTree::onNext(%this)
{
	return true;
}