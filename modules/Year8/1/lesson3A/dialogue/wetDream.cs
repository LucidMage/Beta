//======	Dialogue Tree    ======//
new ScriptObject(L3A_WetDreamDialogueTree)	{	class = DialogueTree;	};
L3A_WetDreamDialogueTree.Setup(L3A_WetDreamBoy);

//======	Dialogue    ======//
//==	Beginning    ==//
//	First time talking to player
%text = "Woah! You scared me. Um... hi.";
new ScriptObject(L3A_WetDreamDialogueInitGreeting)	{	class = Dialogue;	};
L3A_WetDreamDialogueInitGreeting.Setup(%text);
L3A_WetDreamDialogueInitGreeting.canEnd = false;
L3A_WetDreamDialogueInitGreeting.canRepeat = false;

//	"What are doing by the water?"
%text = "Oh, you know, just washing some clothes. Nothing to worry about.";
new ScriptObject(L3A_WetDreamDialogueInitExplain1Part1)	{	class = Dialogue;	};
L3A_WetDreamDialogueInitExplain1Part1.Setup(%text);
L3A_WetDreamDialogueInitExplain1Part1.canEnd = false;
//L3A_WetDreamDialogueInitExplain1Part1.canRepeat = false;

//	"Are you okay?"
%text = "Yeah yeah I'm fine. Just doing what any boy in the forest would do and wash their clothes, right.";
new ScriptObject(L3A_WetDreamDialogueInitExplain2Part1)	{	class = Dialogue;	};
L3A_WetDreamDialogueInitExplain2Part1.Setup(%text);
L3A_WetDreamDialogueInitExplain2Part1.canEnd = false;
//L3A_WetDreamDialogueInitExplain2Part1.canRepeat = false;

//	Explanation Part 2
%text = "Well uh... because um... I... I don't want to tell you, it's kinda embarassing.";
new ScriptObject(L3A_WetDreamDialogueInitExplainPart2)	{	class = Dialogue;	};
L3A_WetDreamDialogueInitExplainPart2.Setup(%text);
L3A_WetDreamDialogueInitExplainPart2.canEnd = false;
//L3A_WetDreamDialogueInitExplainPart2.canRepeat = false;

//	"It's okay, you can trust me."
%text = "Okay, fine, I guess I gotta tell someone at some point, right.";
new ScriptObject(L3A_WetDreamDialogueInitExplain1Part3)	{	class = Dialogue;	};
L3A_WetDreamDialogueInitExplain1Part3.Setup(%text);
L3A_WetDreamDialogueInitExplain1Part3.canEnd = false;
//L3A_WetDreamDialogueInitExplain1Part3.canRepeat = false;

//	"Aw c'mon, the others are telling me their problems."
%text = "Really? I guess they trust strangers too easily. Okay, fine, I guess I gotta tell someone at some point, right.";
new ScriptObject(L3A_WetDreamDialogueInitExplain2Part3)	{	class = Dialogue;	};
L3A_WetDreamDialogueInitExplain2Part3.Setup(%text);
L3A_WetDreamDialogueInitExplain2Part3.canEnd = false;
//L3A_WetDreamDialogueInitExplain2Part3.canRepeat = false;

//	Explanation Part 4
%text = "I... wet them in my sleep. But instead of pee it's some whitish, watery, stuff. Any idea what's going on?";
new ScriptObject(L3A_WetDreamDialogueInitExplainPart4)	{	class = Dialogue;	};
L3A_WetDreamDialogueInitExplainPart4.Setup(%text);
L3A_WetDreamDialogueInitExplainPart4.canEnd = false;
//L3A_WetDreamDialogueInitExplainPart4.canRepeat = false;

//	Still needs help
%text = "Oh... hi again. Have you figured out why I've wet myself with white stuff in my sleep?";
new ScriptObject(L3A_WetDreamDialogueRepeatGreeting)	{	class = Dialogue;	};
L3A_WetDreamDialogueRepeatGreeting.Setup(%text);
L3A_WetDreamDialogueRepeatGreeting.canEnd = false;

//	Been helped, explained
%text = "Hey thanks for explaining the wet dreams to me. Just, please don't tell anyone about it, okay.";
new ScriptObject(L3A_WetDreamDialogueHelpedGreeting)	{	class = Dialogue;	};
L3A_WetDreamDialogueHelpedGreeting.Setup(%text);

//==	Middle    ==//
//	"Sounds like sperm."
%text = "Is that what that stuff is? Is there anything I should know about it?";
new ScriptObject(L3A_WetDreamDialogueMidAnswer1Part1)	{	class = Dialogue;	};
L3A_WetDreamDialogueMidAnswer1Part1.Setup(%text);
L3A_WetDreamDialogueMidAnswer1Part1.canEnd = false;

//	"They are made by your testicles."
%text = "My testicles are making sperm. Okay, is there anything else?";
new ScriptObject(L3A_WetDreamDialogueMidAnswer11Part2)	{	class = Dialogue;	};
L3A_WetDreamDialogueMidAnswer11Part2.Setup(%text);
L3A_WetDreamDialogueMidAnswer11Part2.canEnd = false;
L3A_WetDreamDialogueMidAnswer11Part2.canRepeat = false;

//	"They contain half the genes needed to make babies."
%text = "So sperm is involved in making babies. Alright, anything else?";
new ScriptObject(L3A_WetDreamDialogueMidAnswer12Part2)	{	class = Dialogue;	};
L3A_WetDreamDialogueMidAnswer12Part2.Setup(%text);
L3A_WetDreamDialogueMidAnswer12Part2.canEnd = false;
L3A_WetDreamDialogueMidAnswer12Part2.canRepeat = false;

//	"Wet Dream."
%text = "A 'wet' dream. I can get the wet part but why is this happening to me?";
new ScriptObject(L3A_WetDreamDialogueMidAnswer2Part1)	{	class = Dialogue;	};
L3A_WetDreamDialogueMidAnswer2Part1.Setup(%text);
L3A_WetDreamDialogueMidAnswer2Part1.canEnd = false;

//	"Your body is getting used to making sperm."
%text = "Oh. So this will stop happening at some point?";
new ScriptObject(L3A_WetDreamDialogueMidAnswer21Part2)	{	class = Dialogue;	};
L3A_WetDreamDialogueMidAnswer21Part2.Setup(%text);
L3A_WetDreamDialogueMidAnswer21Part2.canEnd = false;

//	"You had an erection and then ejaculated."
%text = "Oh... is that it? So this will happen every time I fall asleep?";
new ScriptObject(L3A_WetDreamDialogueMidAnswer22Part2)	{	class = Dialogue;	};
L3A_WetDreamDialogueMidAnswer22Part2.Setup(%text);
L3A_WetDreamDialogueMidAnswer22Part2.canEnd = false;

//	"You had a naughty dream."
%text = "I... I did? ...so this is going to keep happening to me when I fall asleep?";
new ScriptObject(L3A_WetDreamDialogueMidAnswer23Part2)	{	class = Dialogue;	};
L3A_WetDreamDialogueMidAnswer23Part2.Setup(%text);
L3A_WetDreamDialogueMidAnswer23Part2.canEnd = false;

//==	End    ==//
//	Helped
%text = "Oh phew. So eventually I won't have to keep washing my clothes like this. Thank you for telling me.";
new ScriptObject(L3A_WetDreamDialogueEndHelped)	{	class = Dialogue;	};
L3A_WetDreamDialogueEndHelped.Setup(%text);

//	Not helped
%text = "Dang. I guess I'll just keep washing my clothes then.";
new ScriptObject(L3A_WetDreamDialogueEndNotHelped)	{	class = Dialogue;	};
L3A_WetDreamDialogueEndNotHelped.Setup(%text);

//======	Assemble Tree    ======//
//==	Beginning    ==//
L3A_WetDreamDialogueTree.rootDialogue[0] = L3A_WetDreamDialogueInitGreeting;
L3A_WetDreamDialogueTree.rootDialogue[1] = L3A_WetDreamDialogueRepeatGreeting;
L3A_WetDreamDialogueTree.rootDialogue[2] = L3A_WetDreamDialogueHelpedGreeting;

//	Link to Part 1 Explaination
%text = "What are you doing by the water?";
L3A_WetDreamDialogueInitGreeting.AddResponse(%text, L3A_WetDreamDialogueInitExplain1Part1);
%text = "Are you okay?";
L3A_WetDreamDialogueInitGreeting.AddResponse(%text, L3A_WetDreamDialogueInitExplain2Part1);

//	Link to Part 2 Explaination
%text = "Why do you need to wash your clothes?";
L3A_WetDreamDialogueInitExplain1Part1.AddResponse(%text, L3A_WetDreamDialogueInitExplainPart2);
L3A_WetDreamDialogueInitExplain2Part1.AddResponse(%text, L3A_WetDreamDialogueInitExplainPart2);
%text = "Why not wash them at home?";
L3A_WetDreamDialogueInitExplain1Part1.AddResponse(%text, L3A_WetDreamDialogueInitExplainPart2);
L3A_WetDreamDialogueInitExplain2Part1.AddResponse(%text, L3A_WetDreamDialogueInitExplainPart2);

//	Link to Part 3 Explaination
%text = "It's okay, you can trust me.";
L3A_WetDreamDialogueInitExplainPart2.AddResponse(%text, L3A_WetDreamDialogueInitExplain1Part3);
%text = "I promise I won't tell anyone.";
L3A_WetDreamDialogueInitExplainPart2.AddResponse(%text, L3A_WetDreamDialogueInitExplain1Part3);
%text = "Aw c'mon, the others are telling me their problems.";
L3A_WetDreamDialogueInitExplainPart2.AddResponse(%text, L3A_WetDreamDialogueInitExplain2Part3);

//	Link to Part 4 Explaination
%text = "[Continue]";
L3A_WetDreamDialogueInitExplain1Part3.AddResponse(%text, L3A_WetDreamDialogueInitExplainPart4);
L3A_WetDreamDialogueInitExplain2Part3.AddResponse(%text, L3A_WetDreamDialogueInitExplainPart4);

//L3A_WetDreamDialogueRepeatGreeting.AddResponse(%text, L3A_WetDreamDialogueInitExplainPart2);

//==	Middle    ==//
//	Link to Sperm
%text = "Sounds like sperm.";
L3A_WetDreamDialogueInitExplainPart4.AddResponse(%text, L3A_WetDreamDialogueMidAnswer1Part1);
L3A_WetDreamDialogueRepeatGreeting.AddResponse(%text, L3A_WetDreamDialogueMidAnswer1Part1);

//	Link to explaning sperm
%text = "They are made by your testicles.";
L3A_WetDreamDialogueMidAnswer1Part1.AddResponse(%text, L3A_WetDreamDialogueMidAnswer11Part2);
L3A_WetDreamDialogueMidAnswer12Part2.AddResponse(%text, L3A_WetDreamDialogueMidAnswer11Part2);
%text = "They contain half the genes needed to make babies.";
L3A_WetDreamDialogueMidAnswer1Part1.AddResponse(%text, L3A_WetDreamDialogueMidAnswer12Part2);
L3A_WetDreamDialogueMidAnswer11Part2.AddResponse(%text, L3A_WetDreamDialogueMidAnswer12Part2);

//	Link to Wet Dream
%text = "I think you had a wet dream.";
L3A_WetDreamDialogueInitExplainPart4.AddResponse(%text, L3A_WetDreamDialogueMidAnswer2Part1);
L3A_WetDreamDialogueRepeatGreeting.AddResponse(%text, L3A_WetDreamDialogueMidAnswer2Part1);
%text = "They came from having a wet dream.";
L3A_WetDreamDialogueMidAnswer1Part1.AddResponse(%text, L3A_WetDreamDialogueMidAnswer2Part1);
L3A_WetDreamDialogueMidAnswer11Part2.AddResponse(%text, L3A_WetDreamDialogueMidAnswer2Part1);
L3A_WetDreamDialogueMidAnswer12Part2.AddResponse(%text, L3A_WetDreamDialogueMidAnswer2Part1);

//	Link to explaning wet dreams
%text = "Your body is getting used to making sperm.";
L3A_WetDreamDialogueMidAnswer2Part1.AddResponse(%text, L3A_WetDreamDialogueMidAnswer21Part2);
%text = "You had an erection and then ejaculated.";
L3A_WetDreamDialogueMidAnswer2Part1.AddResponse(%text, L3A_WetDreamDialogueMidAnswer22Part2);
%text = "You had a naughty dream.";
L3A_WetDreamDialogueMidAnswer2Part1.AddResponse(%text, L3A_WetDreamDialogueMidAnswer23Part2);

//==	End    ==//
//	Link to Helped
%text = "It'll happen on some nights but it will soon stop happening.";
L3A_WetDreamDialogueMidAnswer21Part2.AddResponse(%text, L3A_WetDreamDialogueEndHelped);
L3A_WetDreamDialogueMidAnswer22Part2.AddResponse(%text, L3A_WetDreamDialogueEndHelped);
L3A_WetDreamDialogueMidAnswer23Part2.AddResponse(%text, L3A_WetDreamDialogueEndHelped);
%text = "It happens less as you get older.";
L3A_WetDreamDialogueMidAnswer21Part2.AddResponse(%text, L3A_WetDreamDialogueEndHelped);
L3A_WetDreamDialogueMidAnswer22Part2.AddResponse(%text, L3A_WetDreamDialogueEndHelped);
L3A_WetDreamDialogueMidAnswer23Part2.AddResponse(%text, L3A_WetDreamDialogueEndHelped);

//	Link to Not Helped
%text = "Nope.";
L3A_WetDreamDialogueInitExplainPart4.AddResponse(%text, L3A_WetDreamDialogueEndNotHelped);
L3A_WetDreamDialogueRepeatGreeting.AddResponse(%text, L3A_WetDreamDialogueEndNotHelped);

//======	Callbacks    ======//
function L3A_WetDreamDialogueTree::onOpen(%this)
{
	if (%this.owner.helped)
	{
		%this.selectedRootDialogue = 2;
	}
	else if (%this.rootDialogue[0].beenRead)
		%this.selectedRootDialogue = 1;
	
	return true;
}
function L3A_WetDreamDialogueTree::onClose(%this)
{
	if (%this.currentDialogue $= L3A_WetDreamDialogueEndHelped)
	{
		%this.owner.helped = true;
		Lesson3A.UpdateStatus();
	}

	return true;
}
function L3A_WetDreamDialogueTree::onNext(%this)
{
	return true;
}