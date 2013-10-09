//======	Dialogue Tree    ======//
new ScriptObject(L3A_SweatyDialogueTree)	{	class = DialogueTree;	};
L3A_SweatyDialogueTree.Setup(L3A_SweatyPerson);

//======	Dialogue    ======//
//==	Beginning    ==//
//	First time talking to player
%text = "Hi there, did you come to the forest to excercise as well?";
new ScriptObject(L3A_SweatyDialogueInitGreeting)	{	class = Dialogue;	};
L3A_SweatyDialogueInitGreeting.Setup(%text);
L3A_SweatyDialogueInitGreeting.canEnd = false;
L3A_SweatyDialogueInitGreeting.canRepeat = false;

//	"No, I'm travelling the Sexuality Road"
%text = "Really, I bet you get a lot of exercise from walking everywhere.";
new ScriptObject(L3A_SweatyDialogueInitGreeting2)	{	class = Dialogue;	};
L3A_SweatyDialogueInitGreeting2.Setup(%text);
L3A_SweatyDialogueInitGreeting2.canEnd = false;
//L3A_SweatyDialogueInitGreeting2.canRepeat = false;

//	"Why are you sweaty?"
%text = "I've been pushing these rocks around, though usually it doesn't make me this sweaty, or smelly. I was hoping that a swim could help get rid of it.";
new ScriptObject(L3A_SweatyDialogueInitExplain1)	{	class = Dialogue;	};
L3A_SweatyDialogueInitExplain1.Setup(%text);
L3A_SweatyDialogueInitExplain1.canEnd = false;
//L3A_SweatyDialogueInitExplain1.canRepeat = false;

//	"Poo! You stink!"
%text = "Yeah I know. I don't know how to get rid of it. It seems like I'm getting sweaty and smelly even when I don't do anything.";
new ScriptObject(L3A_SweatyDialogueInitExplain2)	{	class = Dialogue;	};
L3A_SweatyDialogueInitExplain2.Setup(%text);
L3A_SweatyDialogueInitExplain2.canEnd = false;
//L3A_SweatyDialogueInitExplain2.canRepeat = false;

//	 [Continue]
%text = "You wouldn't happen to know why I'm getting more sweaty and smelly than usual would ya?";
new ScriptObject(L3A_SweatyDialogueInitExplainContinue)	{	class = Dialogue;	};
L3A_SweatyDialogueInitExplainContinue.Setup(%text);
L3A_SweatyDialogueInitExplainContinue.canEnd = false;
//L3A_SweatyDialogueInitExplainContinue.canRepeat = false;

//	 "Other than from exercising?"
%text = "Yes, other than exercising why am I sweating more?";
new ScriptObject(L3A_SweatyDialogueInitExplainContinue2)	{	class = Dialogue;	};
L3A_SweatyDialogueInitExplainContinue2.Setup(%text);
L3A_SweatyDialogueInitExplainContinue2.canEnd = false;
//L3A_SweatyDialogueInitExplainContinue2.canRepeat = false;

//	Still needs help
%text = "Hello again. I guess you've figured out why I might be sweating more.";
new ScriptObject(L3A_SweatyDialogueRepeatGreeting)	{	class = Dialogue;	};
L3A_SweatyDialogueRepeatGreeting.Setup(%text);
L3A_SweatyDialogueRepeatGreeting.canEnd = false;

//	Been helped
%text = "Hey you're back. Did my smell lead you here?";
new ScriptObject(L3A_SweatyDialogueHelpedGreeting)	{	class = Dialogue;	};
L3A_SweatyDialogueHelpedGreeting.Setup(%text);

//==	Middle - Part 1    ==//
//	"You might have a fever"
%text = "I don't think so. I'm not feeling sick. Any other ideas?";
new ScriptObject(L3A_SweatyDialogueMidAnswer0)	{	class = Dialogue;	};
L3A_SweatyDialogueMidAnswer0.Setup(%text);
L3A_SweatyDialogueMidAnswer0.canEnd = false;

//	"Your sweat glands have become more active"
%text = "Alright. That explains the sweat but what about the stench?";
new ScriptObject(L3A_SweatyDialogueMidAnswer1Part1)	{	class = Dialogue;	};
L3A_SweatyDialogueMidAnswer1Part1.Setup(%text);
L3A_SweatyDialogueMidAnswer1Part1.canEnd = false;

//	"This forest is warmer than other places"
%text = "Hmm... maybe. Doesn't explain why my sweat stinks though.";
new ScriptObject(L3A_SweatyDialogueMidAnswer2Part1)	{	class = Dialogue;	};
L3A_SweatyDialogueMidAnswer2Part1.Setup(%text);
L3A_SweatyDialogueMidAnswer2Part1.canEnd = false;

//==	Middle - Part 2    ==//
//	"Maybe its from being in this forest"
%text = "You could be right. There are some weird smells here. Anything I could do to get rid of the smell?";
new ScriptObject(L3A_SweatyDialogueMidAnswer1Part2)	{	class = Dialogue;	};
L3A_SweatyDialogueMidAnswer1Part2.Setup(%text);
L3A_SweatyDialogueMidAnswer1Part2.canEnd = false;

//	"Your sweat has pheromones which attract others"
%text = "Really! This smell is supposed to attract people. Anything I could do to get rid of the smell?";
new ScriptObject(L3A_SweatyDialogueMidAnswer2Part2)	{	class = Dialogue;	};
L3A_SweatyDialogueMidAnswer2Part2.Setup(%text);
L3A_SweatyDialogueMidAnswer2Part2.canEnd = false;

//==	End    ==//
//	"Keep it. It might bring you luck"
%text = "Hmm... never thought of it that way. I'll think about it, thank you.";
new ScriptObject(L3A_SweatyDialogueEndHelped1)	{	class = Dialogue;	};
L3A_SweatyDialogueEndHelped1.Setup(%text);

//	"Use deodorant"
//	"Just wash yourself"
%text = "Hah, of course. Glad to know its easy to get rid of, thank you.";
new ScriptObject(L3A_SweatyDialogueEndHelped2)	{	class = Dialogue;	};
L3A_SweatyDialogueEndHelped2.Setup(%text);

//	"Wear perfume"
%text = "I don't want to start wearing perfume but thanks for the suggestion. I think I'll swim it off instead. Thanks for the help.";
new ScriptObject(L3A_SweatyDialogueEndHelped3)	{	class = Dialogue;	};
L3A_SweatyDialogueEndHelped3.Setup(%text);

//	Not helped
%text = "Alright. I'll be resting here if anything comes to mind.";
new ScriptObject(L3A_SweatyDialogueEndNotHelped)	{	class = Dialogue;	};
L3A_SweatyDialogueEndNotHelped.Setup(%text);

//======	Assemble Tree    ======//
//==	Beginning    ==//
L3A_SweatyDialogueTree.rootDialogue[0] = L3A_SweatyDialogueInitGreeting;
L3A_SweatyDialogueTree.rootDialogue[1] = L3A_SweatyDialogueRepeatGreeting;
L3A_SweatyDialogueTree.rootDialogue[2] = L3A_SweatyDialogueHelpedGreeting;

//	Link to Extended Greeting
%text = "No, I'm travelling the Sexuality Road.";
L3A_SweatyDialogueInitGreeting.AddResponse(%text, L3A_SweatyDialogueInitGreeting2);
//	Link to Explaination 1
%text = "Why are you sweaty?";
L3A_SweatyDialogueInitGreeting.AddResponse(%text, L3A_SweatyDialogueInitExplain1);
L3A_SweatyDialogueInitGreeting2.AddResponse(%text, L3A_SweatyDialogueInitExplain1);
//	Link to Explaination 2
%text = "Poo! You stink!";
L3A_SweatyDialogueInitGreeting.AddResponse(%text, L3A_SweatyDialogueInitExplain2);
L3A_SweatyDialogueInitGreeting2.AddResponse(%text, L3A_SweatyDialogueInitExplain2);

//	Link to Continued Explaination
%text = "[Continue]";
L3A_SweatyDialogueInitExplain1.AddResponse(%text, L3A_SweatyDialogueInitExplainContinue);
L3A_SweatyDialogueInitExplain2.AddResponse(%text, L3A_SweatyDialogueInitExplainContinue);

//	Link to Continued Explaination 2
%text = "Other than from exercising?";
L3A_SweatyDialogueInitExplainContinue.AddResponse(%text, L3A_SweatyDialogueInitExplainContinue2);
L3A_SweatyDialogueRepeatGreeting.AddResponse(%text, L3A_SweatyDialogueInitExplainContinue2);

//==	Middle - Part 1    ==//
//	Link to "You might have a fever"
%text = "You might have a fever.";
L3A_SweatyDialogueInitExplainContinue.AddResponse(%text, L3A_SweatyDialogueMidAnswer0);
L3A_SweatyDialogueInitExplainContinue2.AddResponse(%text, L3A_SweatyDialogueMidAnswer0);
L3A_SweatyDialogueRepeatGreeting.AddResponse(%text, L3A_SweatyDialogueMidAnswer0);

//	Link to "Your sweat glands have become more active"
%text = "Your sweat glands have become more active.";
L3A_SweatyDialogueInitExplainContinue.AddResponse(%text, L3A_SweatyDialogueMidAnswer1Part1);
L3A_SweatyDialogueInitExplainContinue2.AddResponse(%text, L3A_SweatyDialogueMidAnswer1Part1);
L3A_SweatyDialogueRepeatGreeting.AddResponse(%text, L3A_SweatyDialogueMidAnswer1Part1);
L3A_SweatyDialogueMidAnswer0.AddResponse(%text, L3A_SweatyDialogueMidAnswer1Part1);

//	Link to "This forest is warmer than other places"
%text = "This forest is warmer than other places.";
L3A_SweatyDialogueInitExplainContinue.AddResponse(%text, L3A_SweatyDialogueMidAnswer2Part1);
L3A_SweatyDialogueInitExplainContinue2.AddResponse(%text, L3A_SweatyDialogueMidAnswer2Part1);
L3A_SweatyDialogueRepeatGreeting.AddResponse(%text, L3A_SweatyDialogueMidAnswer2Part1);
L3A_SweatyDialogueMidAnswer0.AddResponse(%text, L3A_SweatyDialogueMidAnswer2Part1);

//==	Middle - Part 2    ==//
//	Link to "Maybe its from being in this forest"
%text = "Maybe its from being in this forest.";
L3A_SweatyDialogueMidAnswer1Part1.AddResponse(%text, L3A_SweatyDialogueMidAnswer1Part2);
L3A_SweatyDialogueMidAnswer2Part1.AddResponse(%text, L3A_SweatyDialogueMidAnswer1Part2);

//	Link to "Your sweat has pheromones which attract others"
%text = "Your sweat has pheromones which attract others.";
L3A_SweatyDialogueMidAnswer1Part1.AddResponse(%text, L3A_SweatyDialogueMidAnswer2Part2);
L3A_SweatyDialogueMidAnswer2Part1.AddResponse(%text, L3A_SweatyDialogueMidAnswer2Part2);

//==	End    ==//
//	Link to Helped 1
%text = "Keep it. It might bring you luck.";
L3A_SweatyDialogueMidAnswer1Part2.AddResponse(%text, L3A_SweatyDialogueEndHelped1);
L3A_SweatyDialogueMidAnswer2Part2.AddResponse(%text, L3A_SweatyDialogueEndHelped1);

//	Link to Helped 2
%text = "Use deodorant.";
L3A_SweatyDialogueMidAnswer1Part2.AddResponse(%text, L3A_SweatyDialogueEndHelped2);
L3A_SweatyDialogueMidAnswer2Part2.AddResponse(%text, L3A_SweatyDialogueEndHelped2);
%text = "Just wash yourself.";
L3A_SweatyDialogueMidAnswer1Part2.AddResponse(%text, L3A_SweatyDialogueEndHelped2);
L3A_SweatyDialogueMidAnswer2Part2.AddResponse(%text, L3A_SweatyDialogueEndHelped2);

//	Link to Helped 3
%text = "Wear perfume.";
L3A_SweatyDialogueMidAnswer1Part2.AddResponse(%text, L3A_SweatyDialogueEndHelped3);
L3A_SweatyDialogueMidAnswer2Part2.AddResponse(%text, L3A_SweatyDialogueEndHelped3);

//	Link to Not Helped
%text = "I've got no idea.";
L3A_SweatyDialogueInitExplainContinue.AddResponse(%text, L3A_SweatyDialogueEndNotHelped);
L3A_SweatyDialogueInitExplainContinue2.AddResponse(%text, L3A_SweatyDialogueEndNotHelped);
L3A_SweatyDialogueMidAnswer0.AddResponse(%text, L3A_SweatyDialogueEndNotHelped);
%text = "Nope.";
L3A_SweatyDialogueRepeatGreeting.AddResponse(%text, L3A_SweatyDialogueEndNotHelped);

//======	Callbacks    ======//
function L3A_SweatyDialogueTree::onOpen(%this)
{
	if (%this.owner.helped)
		%this.selectedRootDialogue = 2;
	else if (%this.rootDialogue[0].beenRead)
		%this.selectedRootDialogue = 1;
	
	return true;
}
function L3A_SweatyDialogueTree::onClose(%this)
{
	if (%this.currentDialogue $= L3A_SweatyDialogueEndHelped1 ||
		%this.currentDialogue $= L3A_SweatyDialogueEndHelped2 ||
		%this.currentDialogue $= L3A_SweatyDialogueEndHelped3)
	{
		%this.owner.helped = true;
		Lesson3A.UpdateStatus();
	}

	return true;
}
function L3A_SweatyDialogueTree::onNext(%this)
{
	return true;
}