//======	Dialogue Tree    ======//
new ScriptObject(L3A_MoodyDialogueTree)	{	class = DialogueTree;	};
L3A_MoodyDialogueTree.Setup(L3A_MoodyPerson);

//======	Dialogue    ======//
//==	Beginning    ==//
//	First time talking to player
%text = "Hey you! Tell me what's wrong with me!";
new ScriptObject(L3A_MoodyDialogueInitGreeting)	{	class = Dialogue;	};
L3A_MoodyDialogueInitGreeting.Setup(%text);
L3A_MoodyDialogueInitGreeting.canEnd = false;
L3A_MoodyDialogueInitGreeting.canRepeat = false;

//	"What?/Uh..."
%text = "I'm sorry, was I yelling at you? I didn't mean to yell at you. I'm sorry.";
new ScriptObject(L3A_MoodyDialogueInitExplainPart1)	{	class = Dialogue;	};
L3A_MoodyDialogueInitExplainPart1.Setup(%text);
L3A_MoodyDialogueInitExplainPart1.canEnd = false;
//L3A_MoodyDialogueInitExplainPart1.canRepeat = false;

//	"...are you okay?"
%text = "No. No I'm not okay! I randomly go from sad, then glad, THEN MAD! IT'S DRIVING ME CRAZY! WHY AM I SO MOODY?!";
new ScriptObject(L3A_MoodyDialogueInitExplain1Part2)	{	class = Dialogue;	};
L3A_MoodyDialogueInitExplain1Part2.Setup(%text);
L3A_MoodyDialogueInitExplain1Part2.canEnd = false;
//L3A_MoodyDialogueInitExplain1Part2.canRepeat = false;

//	"Did something happen?"
%text = "I think I've gone crazy. I keep changing moods. I was embarrassed but now I'm happy! Why am I changing emotions like this?";
new ScriptObject(L3A_MoodyDialogueInitExplain2Part2)	{	class = Dialogue;	};
L3A_MoodyDialogueInitExplain2Part2.Setup(%text);
L3A_MoodyDialogueInitExplain2Part2.canEnd = false;
//L3A_MoodyDialogueInitExplain2Part2.canRepeat = false;

//	Still needs help
%text = "Is there a reason for this crazy moodiness? Please, please, tell me.";
new ScriptObject(L3A_MoodyDialogueRepeatGreeting)	{	class = Dialogue;	};
L3A_MoodyDialogueRepeatGreeting.Setup(%text);
L3A_MoodyDialogueRepeatGreeting.canEnd = false;

//	Been helped, explained
%text = "Thank you for helping me with my moodiness. I'm feeling a bit more in control now.";
new ScriptObject(L3A_MoodyDialogueHelpedGreeting)	{	class = Dialogue;	};
L3A_MoodyDialogueHelpedGreeting.Setup(%text);

//==	Middle    ==//
//	"Food and drink can effect your emotions."
%text = "Ah. So I should watch what I eat. Anything else?";
new ScriptObject(L3A_MoodyDialogueMidAnswer1)	{	class = Dialogue;	};
L3A_MoodyDialogueMidAnswer1.Setup(%text);
L3A_MoodyDialogueMidAnswer1.canEnd = false;
L3A_MoodyDialogueMidAnswer1.canRepeat = false;

//	"Hormones can make you moody."
%text = "Hormones. Oh no! They're doing this to me? Is there anything else?";
new ScriptObject(L3A_MoodyDialogueMidAnswer2)	{	class = Dialogue;	};
L3A_MoodyDialogueMidAnswer2.Setup(%text);
L3A_MoodyDialogueMidAnswer2.canEnd = false;
L3A_MoodyDialogueMidAnswer2.canRepeat = false;

//	"You're having mood swings. Everyone goes through them."
%text = "Wait. There are others going through this? This is normal? Then, you would know what to do about the mood swings?!";
new ScriptObject(L3A_MoodyDialogueMidAnswer3)	{	class = Dialogue;	};
L3A_MoodyDialogueMidAnswer3.Setup(%text);
L3A_MoodyDialogueMidAnswer3.canEnd = false;

//==	End    ==//
//	Helped
%text = "I guess I can do that. Thank you for telling me this. I'm already feeling more settled now.";
new ScriptObject(L3A_MoodyDialogueEndHelped1)	{	class = Dialogue;	};
L3A_MoodyDialogueEndHelped1.Setup(%text);
%text = "Really? It's that easy? Oh thank you for telling me this. I'm already feeling more settled now.";
new ScriptObject(L3A_MoodyDialogueEndHelped2)	{	class = Dialogue;	};
L3A_MoodyDialogueEndHelped2.Setup(%text);
%text = "Crying. I might try that later. Thank you for telling me this. I'm already feeling more settled now.";
new ScriptObject(L3A_MoodyDialogueEndHelped3)	{	class = Dialogue;	};
L3A_MoodyDialogueEndHelped3.Setup(%text);

//	Not helped
%text = "Noooo! I don't want to go crazy! If ANYTHING comes to mind, tell me.";
new ScriptObject(L3A_MoodyDialogueEndNotHelped)	{	class = Dialogue;	};
L3A_MoodyDialogueEndNotHelped.Setup(%text);

//======	Assemble Tree    ======//
//==	Beginning    ==//
L3A_MoodyDialogueTree.rootDialogue[0] = L3A_MoodyDialogueInitGreeting;
L3A_MoodyDialogueTree.rootDialogue[1] = L3A_MoodyDialogueRepeatGreeting;
L3A_MoodyDialogueTree.rootDialogue[2] = L3A_MoodyDialogueHelpedGreeting;

//	Link to Part 1 Explaination
%text = "What?";
L3A_MoodyDialogueInitGreeting.AddResponse(%text, L3A_MoodyDialogueInitExplainPart1);
%text = "Uh...";
L3A_MoodyDialogueInitGreeting.AddResponse(%text, L3A_MoodyDialogueInitExplainPart1);

//	Link to Part 2 Explaination
%text = "...are you okay?";
L3A_MoodyDialogueInitExplainPart1.AddResponse(%text, L3A_MoodyDialogueInitExplain1Part2);
%text = "Did something happen?";
L3A_MoodyDialogueInitExplainPart1.AddResponse(%text, L3A_MoodyDialogueInitExplain2Part2);

//==	Middle    ==//
//	Link to watch what I eat
%text = "Food and drink can effect your emotions.";
L3A_MoodyDialogueInitExplain1Part2.AddResponse(%text, L3A_MoodyDialogueMidAnswer1);
L3A_MoodyDialogueInitExplain2Part2.AddResponse(%text, L3A_MoodyDialogueMidAnswer1);
L3A_MoodyDialogueRepeatGreeting.AddResponse(%text, L3A_MoodyDialogueMidAnswer1);
L3A_MoodyDialogueMidAnswer2.AddResponse(%text, L3A_MoodyDialogueMidAnswer1);

//	Link to "Hormones. Oh no!..."
%text = "Hormones can make you moody.";
L3A_MoodyDialogueInitExplain1Part2.AddResponse(%text, L3A_MoodyDialogueMidAnswer2);
L3A_MoodyDialogueInitExplain2Part2.AddResponse(%text, L3A_MoodyDialogueMidAnswer2);
L3A_MoodyDialogueRepeatGreeting.AddResponse(%text, L3A_MoodyDialogueMidAnswer2);
L3A_MoodyDialogueMidAnswer1.AddResponse(%text, L3A_MoodyDialogueMidAnswer2);

//	Link to this is normal?
%text = "You're having mood swings. Everyone goes through them.";
L3A_MoodyDialogueInitExplain1Part2.AddResponse(%text, L3A_MoodyDialogueMidAnswer3);
L3A_MoodyDialogueInitExplain2Part2.AddResponse(%text, L3A_MoodyDialogueMidAnswer3);
L3A_MoodyDialogueRepeatGreeting.AddResponse(%text, L3A_MoodyDialogueMidAnswer3);
L3A_MoodyDialogueMidAnswer1.AddResponse(%text, L3A_MoodyDialogueMidAnswer3);
L3A_MoodyDialogueMidAnswer2.AddResponse(%text, L3A_MoodyDialogueMidAnswer3);

//==	End    ==//
//	Link to Helped
%text = "Talk to someone you trust about your feelings.";
L3A_MoodyDialogueMidAnswer3.AddResponse(%text, L3A_MoodyDialogueEndHelped1);
%text = "Stop and take a deep breath.";
L3A_MoodyDialogueMidAnswer3.AddResponse(%text, L3A_MoodyDialogueEndHelped2);
%text = "Get some exercise.";
L3A_MoodyDialogueMidAnswer3.AddResponse(%text, L3A_MoodyDialogueEndHelped1);
%text = "Do something creative.";
L3A_MoodyDialogueMidAnswer3.AddResponse(%text, L3A_MoodyDialogueEndHelped1);
%text = "Sleep them off.";
L3A_MoodyDialogueMidAnswer3.AddResponse(%text, L3A_MoodyDialogueEndHelped2);
%text = "Just cry. There's nothing wrong with it.";
L3A_MoodyDialogueMidAnswer3.AddResponse(%text, L3A_MoodyDialogueEndHelped3);

//	Link to Not Helped
%text = "I don't know.";
L3A_MoodyDialogueInitExplain1Part2.AddResponse(%text, L3A_MoodyDialogueEndNotHelped);
L3A_MoodyDialogueInitExplain2Part2.AddResponse(%text, L3A_MoodyDialogueEndNotHelped);
L3A_MoodyDialogueMidAnswer1.AddResponse(%text, L3A_MoodyDialogueEndNotHelped);
L3A_MoodyDialogueMidAnswer2.AddResponse(%text, L3A_MoodyDialogueEndNotHelped);
L3A_MoodyDialogueRepeatGreeting.AddResponse(%text, L3A_MoodyDialogueEndNotHelped);

//======	Callbacks    ======//
function L3A_MoodyDialogueTree::onOpen(%this)
{
	if (%this.owner.helped)
	{
		%this.selectedRootDialogue = 2;
	}
	else if (%this.rootDialogue[0].beenRead)
		%this.selectedRootDialogue = 1;
	
	return true;
}
function L3A_MoodyDialogueTree::onClose(%this)
{
	if (%this.currentDialogue $= L3A_MoodyDialogueEndHelped1 ||
	   %this.currentDialogue $= L3A_MoodyDialogueEndHelped2 ||
	   %this.currentDialogue $= L3A_MoodyDialogueEndHelped3)
	{
		%this.owner.helped = true;
		Lesson3A.UpdateStatus();
	}

	return true;
}
function L3A_MoodyDialogueTree::onNext(%this)
{
	return true;
}