//======	Dialogue Tree    ======//
new ScriptObject(L3A_UnderarmHairDialogueTree)	{	class = DialogueTree;	};
L3A_UnderarmHairDialogueTree.Setup(L3A_UnderarmHairPerson);

//======	Dialogue    ======//
//==	Beginning    ==//
//	First time talking to player
%text = "Do you see this? Do you see whats happening?";
new ScriptObject(L3A_UnderarmHairDialogueInitGreeting)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueInitGreeting.Setup(%text);
L3A_UnderarmHairDialogueInitGreeting.canEnd = false;
L3A_UnderarmHairDialogueInitGreeting.canRepeat = false;

//	"Under your arms?"
%text = "Yes! There's hair under my arms! Why do I have hair under my arms?";
new ScriptObject(L3A_UnderarmHairDialogueInitExplain1)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueInitExplain1.Setup(%text);
L3A_UnderarmHairDialogueInitExplain1.canEnd = false;
//%L3A_UnderarmHairDialogueInitExplain1.canRepeat = false;

//	"No I can't"
%text = "You can't see the hair under my arms! Why do I have hair under my arms?";
new ScriptObject(L3A_UnderarmHairDialogueInitExplain2)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueInitExplain2.Setup(%text);
L3A_UnderarmHairDialogueInitExplain2.canEnd = false;
//%L3A_UnderarmHairDialogueInitExplain2.canRepeat = false;

//	Asked to lower arms
%text = "I don't want to lower my arms! I'm afraid something bad is gonna happen if I do. Please, do you know why this is happening?";
new ScriptObject(L3A_UnderarmHairDialogueDistracted)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueDistracted.Setup(%text);
L3A_UnderarmHairDialogueDistracted.canEnd = false;
L3A_UnderarmHairDialogueDistracted.canRepeat = false;

//	Still needs help
%text = "Have you figured out why I've got armpit hair?";
new ScriptObject(L3A_UnderarmHairDialogueRepeatGreeting)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueRepeatGreeting.Setup(%text);
L3A_UnderarmHairDialogueRepeatGreeting.canEnd = false;

//	Been helped
%text = "Thanks for explaining the armpit hair. Good luck on your journey.";
new ScriptObject(L3A_UnderarmHairDialogueHelpedGreeting)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueHelpedGreeting.Setup(%text);

//==	Middle - Part 1    ==//
//	"Because of hormones"
%text = "Why would hormones make my armpits grow hair?";
new ScriptObject(L3A_UnderarmHairDialogueMidAnswer1Part1)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueMidAnswer1Part1.Setup(%text);
L3A_UnderarmHairDialogueMidAnswer1Part1.canEnd = false;

//	"For warmth and protection"
%text = "Protection? From what?";
new ScriptObject(L3A_UnderarmHairDialogueMidAnswer2Part1)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueMidAnswer2Part1.Setup(%text);
L3A_UnderarmHairDialogueMidAnswer2Part1.canEnd = false;

//	"To get in the way of deodorant"
%text = "Huh, stupid hair. So will there be any problems if I remove it?";
new ScriptObject(L3A_UnderarmHairDialogueMidAnswer3)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueMidAnswer3.Setup(%text);
L3A_UnderarmHairDialogueMidAnswer3.canEnd = false;

//	"To catch sweat"
%text = "Sweat. So if I remove it will sweat build up in my armpits?";
new ScriptObject(L3A_UnderarmHairDialogueMidAnswer4)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueMidAnswer4.Setup(%text);
L3A_UnderarmHairDialogueMidAnswer4.canEnd = false;

//==	Middle - Part 2    ==//
//	"Bacteria"
%text = "Bacteria? Really? So if I remove it my armpits will be infected by bacteria?";
new ScriptObject(L3A_UnderarmHairDialogueMidAnswer1Part2)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueMidAnswer1Part2.Setup(%text);
L3A_UnderarmHairDialogueMidAnswer1Part2.canEnd = false;

//	"Dirt and sweat"
%text = "Huh. So if I remove it my armpits will just get dirty and sweaty?";
new ScriptObject(L3A_UnderarmHairDialogueMidAnswer2Part2)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueMidAnswer2Part2.Setup(%text);
L3A_UnderarmHairDialogueMidAnswer2Part2.canEnd = false;

//	"I don't know"
%text = "Well... okay. But I don't want armpit hair. Will something bad happen if I remove it?";
new ScriptObject(L3A_UnderarmHairDialogueMidAnswer3Part2)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueMidAnswer3Part2.Setup(%text);
L3A_UnderarmHairDialogueMidAnswer3Part2.canEnd = false;

//==	End    ==//
//	Helped
%text = "Okay, thank you for explaining armpit hair to me";
new ScriptObject(L3A_UnderarmHairDialogueEndHelped)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueEndHelped.Setup(%text);

//	Not helped
%text = "Crap! I don't know what to do about it. If you think of anything, please tell me.";
new ScriptObject(L3A_UnderarmHairDialogueEndNotHelped)	{	class = Dialogue;	};
L3A_UnderarmHairDialogueEndNotHelped.Setup(%text);

//======	Assemble Tree    ======//
//==	Beginning    ==//
L3A_UnderarmHairDialogueTree.rootDialogue[0] = L3A_UnderarmHairDialogueInitGreeting;
L3A_UnderarmHairDialogueTree.rootDialogue[1] = L3A_UnderarmHairDialogueRepeatGreeting;
L3A_UnderarmHairDialogueTree.rootDialogue[2] = L3A_UnderarmHairDialogueHelpedGreeting;

//	Link to Explaination 1
%text = "Under your arms?";
L3A_UnderarmHairDialogueInitGreeting.AddResponse(%text, L3A_UnderarmHairDialogueInitExplain1);
//	Link to Explaination 2
%text = "No I can't";
L3A_UnderarmHairDialogueInitGreeting.AddResponse(%text, L3A_UnderarmHairDialogueInitExplain2);

//	Initial Explaination 1 Responses
//	Link to Distracted
%text = "Can you lower your arms, its distracting me.";
L3A_UnderarmHairDialogueInitExplain1.AddResponse(%text, L3A_UnderarmHairDialogueDistracted);
L3A_UnderarmHairDialogueInitExplain2.AddResponse(%text, L3A_UnderarmHairDialogueDistracted);
L3A_UnderarmHairDialogueRepeatGreeting.AddResponse(%text, L3A_UnderarmHairDialogueDistracted);

//==	Middle - Part 1    ==//
//	Link to "Because of hormones"
%text = "Because of hormones";
L3A_UnderarmHairDialogueInitExplain1.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer1Part1);
L3A_UnderarmHairDialogueInitExplain2.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer1Part1);
L3A_UnderarmHairDialogueRepeatGreeting.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer1Part1);
L3A_UnderarmHairDialogueDistracted.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer1Part1);

//	Link to "For warmth and protection"
%text = "For warmth and protection";
L3A_UnderarmHairDialogueInitExplain1.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer2Part1);
L3A_UnderarmHairDialogueInitExplain2.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer2Part1);
L3A_UnderarmHairDialogueRepeatGreeting.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer2Part1);
L3A_UnderarmHairDialogueDistracted.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer2Part1);
L3A_UnderarmHairDialogueMidAnswer1Part1.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer2Part1);

//	Link to "To get in the way of deodorant"
%text = "To get in the way of deodorant";
L3A_UnderarmHairDialogueInitExplain1.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer3);
L3A_UnderarmHairDialogueInitExplain2.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer3);
L3A_UnderarmHairDialogueRepeatGreeting.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer3);
L3A_UnderarmHairDialogueDistracted.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer3);
L3A_UnderarmHairDialogueMidAnswer1Part1.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer3);

//	Link to "To catch sweat"
%text = "To catch sweat";
L3A_UnderarmHairDialogueInitExplain1.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer4);
L3A_UnderarmHairDialogueInitExplain2.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer4);
L3A_UnderarmHairDialogueRepeatGreeting.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer4);
L3A_UnderarmHairDialogueDistracted.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer4);
L3A_UnderarmHairDialogueMidAnswer1Part1.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer4);

//==	Middle - Part 2    ==//
//	Link to "Bacteria"
%text = "Bacteria";
L3A_UnderarmHairDialogueMidAnswer2Part1.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer1Part2);

//	Link to "Dirt and sweat"
%text = "Dirt and sweat";
L3A_UnderarmHairDialogueMidAnswer2Part1.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer2Part2);

//	Link to "I don't know"
%text = "I don't know";
L3A_UnderarmHairDialogueMidAnswer1Part1.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer3Part2);
L3A_UnderarmHairDialogueMidAnswer2Part1.AddResponse(%text, L3A_UnderarmHairDialogueMidAnswer3Part2);

//==	End    ==//
//	Link to Helped
%text = "No but its your choice what you do with it";
L3A_UnderarmHairDialogueMidAnswer3.AddResponse(%text, L3A_UnderarmHairDialogueEndHelped);
L3A_UnderarmHairDialogueMidAnswer4.AddResponse(%text, L3A_UnderarmHairDialogueEndHelped);
L3A_UnderarmHairDialogueMidAnswer1Part2.AddResponse(%text, L3A_UnderarmHairDialogueEndHelped);
L3A_UnderarmHairDialogueMidAnswer2Part2.AddResponse(%text, L3A_UnderarmHairDialogueEndHelped);
L3A_UnderarmHairDialogueMidAnswer3Part2.AddResponse(%text, L3A_UnderarmHairDialogueEndHelped);
%text = "Nothing bad will happen. You'll just feel a bit colder";
L3A_UnderarmHairDialogueMidAnswer3.AddResponse(%text, L3A_UnderarmHairDialogueEndHelped);
L3A_UnderarmHairDialogueMidAnswer4.AddResponse(%text, L3A_UnderarmHairDialogueEndHelped);
L3A_UnderarmHairDialogueMidAnswer1Part2.AddResponse(%text, L3A_UnderarmHairDialogueEndHelped);
L3A_UnderarmHairDialogueMidAnswer2Part2.AddResponse(%text, L3A_UnderarmHairDialogueEndHelped);
L3A_UnderarmHairDialogueMidAnswer3Part2.AddResponse(%text, L3A_UnderarmHairDialogueEndHelped);

//	Link to Not Helped
%text = "I don't know";
L3A_UnderarmHairDialogueInitExplain1.AddResponse(%text, L3A_UnderarmHairDialogueEndNotHelped);
L3A_UnderarmHairDialogueInitExplain2.AddResponse(%text, L3A_UnderarmHairDialogueEndNotHelped);
%text = "No";
L3A_UnderarmHairDialogueDistracted.AddResponse(%text, L3A_UnderarmHairDialogueEndNotHelped);
L3A_UnderarmHairDialogueRepeatGreeting.AddResponse(%text, L3A_UnderarmHairDialogueEndNotHelped);

//======	Callbacks    ======//
function L3A_UnderarmHairDialogueTree::onOpen(%this)
{
	if (%this.owner.helped)
		%this.selectedRootDialogue = 2;
	else if (%this.rootDialogue[0].beenRead)
		%this.selectedRootDialogue = 1;
	
	return true;
}
function L3A_UnderarmHairDialogueTree::onClose(%this)
{
	if (%this.currentDialogue $= L3A_UnderarmHairDialogueEndHelped)
	{
		%this.owner.helped = true;
		Lesson3A.helped++;
		Lesson3A.UpdateStatus();
	}

	return true;
}
function L3A_UnderarmHairDialogueTree::onNext(%this)
{
	return true;
}