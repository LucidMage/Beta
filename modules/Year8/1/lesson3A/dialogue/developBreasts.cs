//======	Dialogue Tree    ======//
new ScriptObject(L3A_DevelopBreastDialogueTree)	{	class = DialogueTree;	};
L3A_DevelopBreastDialogueTree.Setup(L3A_DevelopBreastGirl);

//======	Dialogue    ======//
//==	Beginning    ==//
//	First time talking to player
%text = "Hey, I need your help and I don't know who to talk to!";
new ScriptObject(L3A_DevelopBreastDialogueInitGreeting)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueInitGreeting.Setup(%text);
L3A_DevelopBreastDialogueInitGreeting.canEnd = false;
L3A_DevelopBreastDialogueInitGreeting.canRepeat = false;

//	"What's the problem?"
%text = "I've got lumps growing on my chest!";
new ScriptObject(L3A_DevelopBreastDialogueInitExplain1)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueInitExplain1.Setup(%text);
L3A_DevelopBreastDialogueInitExplain1.canEnd = false;
//L3A_DevelopBreastDialogueInitExplain1.canRepeat = false;

//	"Sorry not right now."
%text = "What! But you gotta help me, I've got lumps growing on my chest!";
new ScriptObject(L3A_DevelopBreastDialogueInitExplain2)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueInitExplain2.Setup(%text);
L3A_DevelopBreastDialogueInitExplain2.canEnd = false;
//L3A_DevelopBreastDialogueInitExplain2.canRepeat = false;

//	Part 2 of explaination
%text = "A while ago I noticed lumps appearing, one at each of my nipples. Just recently one of them has started getting bigger. What's going on?";
new ScriptObject(L3A_DevelopBreastDialogueInitExplainPart2)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueInitExplainPart2.Setup(%text);
L3A_DevelopBreastDialogueInitExplainPart2.canEnd = false;

//	"Is there anything else you can tell me?"
%text = "The lumps feel a bit tender and uncomfortable.";
new ScriptObject(L3A_DevelopBreastDialogueInitExplainPart3)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueInitExplainPart3.Setup(%text);
L3A_DevelopBreastDialogueInitExplainPart3.canEnd = false;

//	Still needs help
%text = "Any idea what the lumps on my chest is?";
new ScriptObject(L3A_DevelopBreastDialogueRepeatGreeting)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueRepeatGreeting.Setup(%text);
L3A_DevelopBreastDialogueRepeatGreeting.canEnd = false;

//	Been helped, explained
%text = "Thank you again, I didn't realise I was growing breasts.";
new ScriptObject(L3A_DevelopBreastDialogueHelpedGreeting)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueHelpedGreeting.Setup(%text);

//	Been helped, told to see doctor
%text = "I'll be seeing a doctor as soon as I can. Thanks for the suggestion.";
new ScriptObject(L3A_DevelopBreastDialogueHelpedDoctorGreeting)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueHelpedDoctorGreeting.Setup(%text);

//==	Middle    ==//
//	"Sounds like your breasts have started developing."
%text = "Breasts? What do I need breasts for?";
new ScriptObject(L3A_DevelopBreastDialogueMidAnswerPart1)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueMidAnswerPart1.Setup(%text);
L3A_DevelopBreastDialogueMidAnswerPart1.canEnd = false;

//	Does know
%text = "Huh. But only one of them seems to be growing. Shouldn't both of them be growing at the same time?";
new ScriptObject(L3A_DevelopBreastDialogueMidAnswer2Part1)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueMidAnswer2Part1.Setup(%text);
L3A_DevelopBreastDialogueMidAnswer2Part1.canEnd = false;

//	Doesn't know
%text = "Okay. Well, do you know why only one of them seems to be growing. Shouldn't both of them be growing at the same time?";
new ScriptObject(L3A_DevelopBreastDialogueMidAnswer2Part2)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueMidAnswer2Part2.Setup(%text);
L3A_DevelopBreastDialogueMidAnswer2Part2.canEnd = false;

//==	End    ==//
//	"Probably."
%text = "Hmm... well thank you for the help.";
new ScriptObject(L3A_DevelopBreastDialogueEndHelped1)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueEndHelped1.Setup(%text);

//	"Its normal for one breast to be slightly bigger than the other."
%text = "So the other will start growing soon. Phew. Thank you for the explanation.";
new ScriptObject(L3A_DevelopBreastDialogueEndHelped2)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueEndHelped2.Setup(%text);

//	"Maybe you should see a doctor about it."
%text = "Sounds like a good idea. Thank you.";
new ScriptObject(L3A_DevelopBreastDialogueEndHelpedDoctor)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueEndHelpedDoctor.Setup(%text);

//	Not helped
%text = "Please try to think of something. I don't know who else to talk to.";
new ScriptObject(L3A_DevelopBreastDialogueEndNotHelped)	{	class = Dialogue;	};
L3A_DevelopBreastDialogueEndNotHelped.Setup(%text);

//======	Assemble Tree    ======//
//==	Beginning    ==//
L3A_DevelopBreastDialogueTree.rootDialogue[0] = L3A_DevelopBreastDialogueInitGreeting;
L3A_DevelopBreastDialogueTree.rootDialogue[1] = L3A_DevelopBreastDialogueRepeatGreeting;
L3A_DevelopBreastDialogueTree.rootDialogue[2] = L3A_DevelopBreastDialogueHelpedGreeting;
L3A_DevelopBreastDialogueTree.rootDialogue[3] = L3A_DevelopBreastDialogueHelpedDoctorGreeting;

//	Link to Explaination 1
%text = "What's the problem?";
L3A_DevelopBreastDialogueInitGreeting.AddResponse(%text, L3A_DevelopBreastDialogueInitExplain1);
//	Link to Explaination 2
%text = "Sorry not right now.";
L3A_DevelopBreastDialogueInitGreeting.AddResponse(%text, L3A_DevelopBreastDialogueInitExplain2);

//	Link to Part 2 Explaination
%text = "Calm down. When did this start happening?";
L3A_DevelopBreastDialogueInitExplain1.AddResponse(%text, L3A_DevelopBreastDialogueInitExplainPart2);
L3A_DevelopBreastDialogueInitExplain2.AddResponse(%text, L3A_DevelopBreastDialogueInitExplainPart2);
%text = "Woah! How did this happen?";
L3A_DevelopBreastDialogueInitExplain1.AddResponse(%text, L3A_DevelopBreastDialogueInitExplainPart2);
L3A_DevelopBreastDialogueInitExplain2.AddResponse(%text, L3A_DevelopBreastDialogueInitExplainPart2);
%text = "Can you explain what happened again?";
L3A_DevelopBreastDialogueRepeatGreeting.AddResponse(%text, L3A_DevelopBreastDialogueInitExplainPart2);

//	Link to Part 3 Explaination
%text = "Is there anything else you can tell me?";
L3A_DevelopBreastDialogueInitExplainPart2.AddResponse(%text, L3A_DevelopBreastDialogueInitExplainPart3);
L3A_DevelopBreastDialogueRepeatGreeting.AddResponse(%text, L3A_DevelopBreastDialogueInitExplainPart3);

//==	Middle    ==//
//	Link to "Breasts? What do I need breasts for?"
%text = "Sounds like your breasts have started developing.";
L3A_DevelopBreastDialogueInitExplainPart2.AddResponse(%text, L3A_DevelopBreastDialogueMidAnswerPart1);
L3A_DevelopBreastDialogueInitExplainPart3.AddResponse(%text, L3A_DevelopBreastDialogueMidAnswerPart1);
L3A_DevelopBreastDialogueRepeatGreeting.AddResponse(%text, L3A_DevelopBreastDialogueMidAnswerPart1);

//	Link to does know
%text = "They produce milk which is used to feed babies.";
L3A_DevelopBreastDialogueMidAnswerPart1.AddResponse(%text, L3A_DevelopBreastDialogueMidAnswer2Part1);
%text = "Nothing. It's just part of being a woman.";
L3A_DevelopBreastDialogueMidAnswerPart1.AddResponse(%text, L3A_DevelopBreastDialogueMidAnswer2Part1);

//	Link to doesn't know
%text = "I don't know.";
L3A_DevelopBreastDialogueMidAnswerPart1.AddResponse(%text, L3A_DevelopBreastDialogueMidAnswer2Part2);

//==	End    ==//
//	Link to Helped 1
%text = "Probably.";
L3A_DevelopBreastDialogueMidAnswer2Part1.AddResponse(%text, L3A_DevelopBreastDialogueEndHelped1);
L3A_DevelopBreastDialogueMidAnswer2Part2.AddResponse(%text, L3A_DevelopBreastDialogueEndHelped1);

//	Link to Helped 2
%text = "Its normal for one breast to be slightly bigger than the other.";
L3A_DevelopBreastDialogueMidAnswer2Part1.AddResponse(%text, L3A_DevelopBreastDialogueEndHelped2);
L3A_DevelopBreastDialogueMidAnswer2Part2.AddResponse(%text, L3A_DevelopBreastDialogueEndHelped2);

//	Link to Helped mentioning Doctor
%text = "Maybe you should see a doctor about it.";
L3A_DevelopBreastDialogueInitExplainPart2.AddResponse(%text, L3A_DevelopBreastDialogueEndHelpedDoctor);
L3A_DevelopBreastDialogueInitExplainPart3.AddResponse(%text, L3A_DevelopBreastDialogueEndHelpedDoctor);
L3A_DevelopBreastDialogueRepeatGreeting.AddResponse(%text, L3A_DevelopBreastDialogueEndHelpedDoctor);
L3A_DevelopBreastDialogueMidAnswer2Part1.AddResponse(%text, L3A_DevelopBreastDialogueEndHelpedDoctor);
L3A_DevelopBreastDialogueMidAnswer2Part2.AddResponse(%text, L3A_DevelopBreastDialogueEndHelpedDoctor);

//	Link to Not Helped
%text = "I don't know.";
L3A_DevelopBreastDialogueInitExplainPart2.AddResponse(%text, L3A_DevelopBreastDialogueEndNotHelped);
L3A_DevelopBreastDialogueInitExplainPart3.AddResponse(%text, L3A_DevelopBreastDialogueEndNotHelped);
//L3A_DevelopBreastDialogueRepeatGreeting.AddResponse(%text, L3A_DevelopBreastDialogueEndNotHelped);
%text = "I still don't know.";
L3A_DevelopBreastDialogueRepeatGreeting.AddResponse(%text, L3A_DevelopBreastDialogueEndNotHelped);

//======	Callbacks    ======//
function L3A_DevelopBreastDialogueTree::onOpen(%this)
{
	if (%this.owner.helped)
	{
	   if (%this.owner.doctor) // Told to see doctor
		   %this.selectedRootDialogue = 3;
	   else
		   %this.selectedRootDialogue = 2;
	}
	else if (%this.rootDialogue[0].beenRead)
		%this.selectedRootDialogue = 1;
	
	return true;
}
function L3A_DevelopBreastDialogueTree::onClose(%this)
{
	if (%this.currentDialogue $= L3A_DevelopBreastDialogueEndHelped1 ||
		%this.currentDialogue $= L3A_DevelopBreastDialogueEndHelped2 ||
		%this.currentDialogue $= L3A_DevelopBreastDialogueEndHelpedDoctor)
	{
	   if (%this.currentDialogue $= L3A_DevelopBreastDialogueEndHelpedDoctor)
		   %this.owner.doctor = true; // Told they should see a doctor
	   
		%this.owner.helped = true;
		Lesson3A.UpdateStatus();
	}

	return true;
}
function L3A_DevelopBreastDialogueTree::onNext(%this)
{
	return true;
}