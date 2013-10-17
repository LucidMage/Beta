//======	Dialogue Tree    ======//
new ScriptObject(L3A_IncreasedHairDialogueTree)	{	class = DialogueTree;	};
L3A_IncreasedHairDialogueTree.Setup(L3A_IncreasedHairPerson);

//======	Dialogue    ======//
//==	Beginning    ==//
//	First time talking to player
%text = "Ooh ooh hello. Welcome to my home.";
new ScriptObject(L3A_IncreasedHairDialogueInitGreeting)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueInitGreeting.Setup(%text);
L3A_IncreasedHairDialogueInitGreeting.canEnd = false;
L3A_IncreasedHairDialogueInitGreeting.canRepeat = false;

//	"You live in this forest?"
%text = "Ooh, you got to when you start turning into a monkey like I am. See all this hair growing on my body and face.";
new ScriptObject(L3A_IncreasedHairDialogueInitExplain1Part1)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueInitExplain1Part1.Setup(%text);
L3A_IncreasedHairDialogueInitExplain1Part1.canEnd = false;
//L3A_IncreasedHairDialogueInitExplain1Part1.canRepeat = false;

//	"Are you okay?"
%text = "Ah, because I'm turning into a monkey. Just look at all this hair I've started growing on my body and face.";
new ScriptObject(L3A_IncreasedHairDialogueInitExplain2Part1)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueInitExplain2Part1.Setup(%text);
L3A_IncreasedHairDialogueInitExplain2Part1.canEnd = false;
//L3A_IncreasedHairDialogueInitExplain2Part1.canRepeat = false;

//	Explanation Part 2
%text = "Ooh really? Then why am I becoming so hairy then, huh?";
new ScriptObject(L3A_IncreasedHairDialogueInitExplainPart2)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueInitExplainPart2.Setup(%text);
L3A_IncreasedHairDialogueInitExplainPart2.canEnd = false;
//L3A_IncreasedHairDialogueInitExplainPart2.canRepeat = false;

//	Still needs help
%text = "Soooo, you still don't think all this hair means I'm turning into a monkey?";
new ScriptObject(L3A_IncreasedHairDialogueRepeatGreeting)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueRepeatGreeting.Setup(%text);
L3A_IncreasedHairDialogueRepeatGreeting.canEnd = false;

//	Been helped, explained
%text = "Thanks for explaining the hair growth to me. I'm sorry I acted like that.";
new ScriptObject(L3A_IncreasedHairDialogueHelpedGreeting)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueHelpedGreeting.Setup(%text);

//==	Middle    ==//
//	"Monkeys have tails. You don't."
%text = "Ah... okay maybe not a monkey but a gorilla. They're hairy and don't have tails.";
new ScriptObject(L3A_IncreasedHairDialogueMidAnswer1)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueMidAnswer1.Setup(%text);
L3A_IncreasedHairDialogueMidAnswer1.canEnd = false;
L3A_IncreasedHairDialogueMidAnswer1.canRepeat = false;

//	"Hormones are causing the hair growth."
%text = "Ooh, hormones are causing this. But that doesn't mean I'm not turning into a monkey.";
new ScriptObject(L3A_IncreasedHairDialogueMidAnswer2)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueMidAnswer2.Setup(%text);
L3A_IncreasedHairDialogueMidAnswer2.canEnd = false;
L3A_IncreasedHairDialogueMidAnswer2.canRepeat = false;

//	"The hair is a sign you are becoming an adult."
%text = "Oooeerrr... really? That's what it is? I... feel pretty stupid. But, I'm confused, why am I hairier than everyone else?";
new ScriptObject(L3A_IncreasedHairDialogueMidAnswer3)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueMidAnswer3.Setup(%text);
L3A_IncreasedHairDialogueMidAnswer3.canEnd = false;
//L3A_IncreasedHairDialogueMidAnswer3.canRepeat = false;

//==	End    ==//
//	Helped
%text = "So I'm hairy because of my family. I guess that works. Thank you for snapping me out of the whole monkey thing.";
new ScriptObject(L3A_IncreasedHairDialogueEndHelped1)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueEndHelped1.Setup(%text);
%text = "I wouldn't say that. Anyway, thank you for snapping me out of the whole monkey thing.";
new ScriptObject(L3A_IncreasedHairDialogueEndHelped2)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueEndHelped2.Setup(%text);
%text = "Huh, I've never shaved before but I guess I could ask someone I trust about it. Thank you for snapping me out of the monkey thing.";
new ScriptObject(L3A_IncreasedHairDialogueEndHelped3)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueEndHelped3.Setup(%text);

//	Not helped
%text = "Ah, oookay. I'll just continue being a monkey then.";
new ScriptObject(L3A_IncreasedHairDialogueEndNotHelped)	{	class = Dialogue;	};
L3A_IncreasedHairDialogueEndNotHelped.Setup(%text);

//======	Assemble Tree    ======//
//==	Beginning    ==//
L3A_IncreasedHairDialogueTree.rootDialogue[0] = L3A_IncreasedHairDialogueInitGreeting;
L3A_IncreasedHairDialogueTree.rootDialogue[1] = L3A_IncreasedHairDialogueRepeatGreeting;
L3A_IncreasedHairDialogueTree.rootDialogue[2] = L3A_IncreasedHairDialogueHelpedGreeting;

//	Link to Part 1 Explaination
%text = "You live in this forest?";
L3A_IncreasedHairDialogueInitGreeting.AddResponse(%text, L3A_IncreasedHairDialogueInitExplain1Part1);
%text = "Why are you talking like that?";
L3A_IncreasedHairDialogueInitGreeting.AddResponse(%text, L3A_IncreasedHairDialogueInitExplain2Part1);

//	Link to Part 2 Explaination
%text = "You can't turn into a monkey.";
L3A_IncreasedHairDialogueInitExplain1Part1.AddResponse(%text, L3A_IncreasedHairDialogueInitExplainPart2);
L3A_IncreasedHairDialogueInitExplain2Part1.AddResponse(%text, L3A_IncreasedHairDialogueInitExplainPart2);
%text = "Growing body hair doesn't mean you're becoming a monkey.";
L3A_IncreasedHairDialogueInitExplain1Part1.AddResponse(%text, L3A_IncreasedHairDialogueInitExplainPart2);
L3A_IncreasedHairDialogueInitExplain2Part1.AddResponse(%text, L3A_IncreasedHairDialogueInitExplainPart2);

//==	Middle    ==//
//	Link to monkey tail
%text = "Monkeys have tails. You don't.";
L3A_IncreasedHairDialogueInitExplainPart2.AddResponse(%text, L3A_IncreasedHairDialogueMidAnswer1);
L3A_IncreasedHairDialogueMidAnswer2.AddResponse(%text, L3A_IncreasedHairDialogueMidAnswer1);
L3A_IncreasedHairDialogueRepeatGreeting.AddResponse(%text, L3A_IncreasedHairDialogueMidAnswer1);

//	Link to hormones
%text = "Hormones are causing the hair growth.";
L3A_IncreasedHairDialogueInitExplainPart2.AddResponse(%text, L3A_IncreasedHairDialogueMidAnswer2);
L3A_IncreasedHairDialogueMidAnswer1.AddResponse(%text, L3A_IncreasedHairDialogueMidAnswer2);
L3A_IncreasedHairDialogueRepeatGreeting.AddResponse(%text, L3A_IncreasedHairDialogueMidAnswer2);

//	Link to becoming adult
%text = "The hair is a sign you are becoming an adult.";
L3A_IncreasedHairDialogueInitExplainPart2.AddResponse(%text, L3A_IncreasedHairDialogueMidAnswer3);
L3A_IncreasedHairDialogueMidAnswer1.AddResponse(%text, L3A_IncreasedHairDialogueMidAnswer3);
L3A_IncreasedHairDialogueMidAnswer2.AddResponse(%text, L3A_IncreasedHairDialogueMidAnswer3);
L3A_IncreasedHairDialogueRepeatGreeting.AddResponse(%text, L3A_IncreasedHairDialogueMidAnswer3);

//==	End    ==//
//	Link to Helped
%text = "Your genes determines how much hair you have.";
L3A_IncreasedHairDialogueMidAnswer3.AddResponse(%text, L3A_IncreasedHairDialogueEndHelped1);
%text = "I guess you have hairy parents.";
L3A_IncreasedHairDialogueMidAnswer3.AddResponse(%text, L3A_IncreasedHairDialogueEndHelped2);
%text = "They probably shave it off.";
L3A_IncreasedHairDialogueMidAnswer3.AddResponse(%text, L3A_IncreasedHairDialogueEndHelped3);

//	Link to Not Helped
%text = "I can't think of anything.";
L3A_IncreasedHairDialogueInitExplainPart2.AddResponse(%text, L3A_IncreasedHairDialogueEndNotHelped);
L3A_IncreasedHairDialogueMidAnswer1.AddResponse(%text, L3A_IncreasedHairDialogueEndNotHelped);
L3A_IncreasedHairDialogueMidAnswer2.AddResponse(%text, L3A_IncreasedHairDialogueEndNotHelped);
L3A_IncreasedHairDialogueRepeatGreeting.AddResponse(%text, L3A_IncreasedHairDialogueEndNotHelped);

//======	Callbacks    ======//
function L3A_IncreasedHairDialogueTree::onOpen(%this)
{
	if (%this.owner.helped)
	{
		%this.selectedRootDialogue = 2;
	}
	else if (%this.rootDialogue[0].beenRead)
		%this.selectedRootDialogue = 1;
	
	return true;
}
function L3A_IncreasedHairDialogueTree::onClose(%this)
{
	if (%this.currentDialogue $= L3A_IncreasedHairDialogueEndHelped1 ||
	   %this.currentDialogue $= L3A_IncreasedHairDialogueEndHelped2 ||
	   %this.currentDialogue $= L3A_IncreasedHairDialogueEndHelped3)
	{
		%this.owner.helped = true;
		Lesson3A.UpdateStatus();
	}

	return true;
}
function L3A_IncreasedHairDialogueTree::onNext(%this)
{
	return true;
}