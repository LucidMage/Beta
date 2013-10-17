//======	Dialogue Tree    ======//
new ScriptObject(L3A_PimpleDialogueTree)	{	class = DialogueTree;	};
L3A_PimpleDialogueTree.Setup(L3A_PimplePerson);

//======	Dialogue    ======//
//==	Beginning    ==//
//	First time talking to player
%text = "Help! I've got all of these red and yellowish bumps all over my face! What's going on?!";
new ScriptObject(L3A_PimpleDialogueInitGreeting)	{	class = Dialogue;	};
L3A_PimpleDialogueInitGreeting.Setup(%text);
L3A_PimpleDialogueInitGreeting.canEnd = false;
L3A_PimpleDialogueInitGreeting.canRepeat = false;

//	Still needs help
%text = "Please tell me what's happening? What are these red and yellowish bumps on my face?";
new ScriptObject(L3A_PimpleDialogueRepeatGreeting)	{	class = Dialogue;	};
L3A_PimpleDialogueRepeatGreeting.Setup(%text);
L3A_PimpleDialogueRepeatGreeting.canEnd = false;

//	Been helped, explained
%text = "Thank you for telling me about these pimples. I guess it's not as bad as I thought it was.";
new ScriptObject(L3A_PimpleDialogueHelpedGreeting)	{	class = Dialogue;	};
L3A_PimpleDialogueHelpedGreeting.Setup(%text);

//==	Middle    ==//
//	"It doesn't look as bad as you think it does."
%text = "Are you blind! These bumps are everywhere! What are they?!";
new ScriptObject(L3A_PimpleDialogueMidAnswer0Part1)	{	class = Dialogue;	};
L3A_PimpleDialogueMidAnswer0Part1.Setup(%text);
L3A_PimpleDialogueMidAnswer0Part1.canEnd = false;
L3A_PimpleDialogueMidAnswer0Part1.canRepeat = false;

//	"Those are pimples."
%text = "Pimples! Why do I have pimples on my face?!";
new ScriptObject(L3A_PimpleDialogueMidAnswer1Part1)	{	class = Dialogue;	};
L3A_PimpleDialogueMidAnswer1Part1.Setup(%text);
L3A_PimpleDialogueMidAnswer1Part1.canEnd = false;

//	"You have acne."
%text = "Acne! Why do I have acne?!";
new ScriptObject(L3A_PimpleDialogueMidAnswer2Part1)	{	class = Dialogue;	};
L3A_PimpleDialogueMidAnswer2Part1.Setup(%text);
L3A_PimpleDialogueMidAnswer2Part1.canEnd = false;

//	"Dirt and oil from your skin is forming them."
%text = "Dirt and oil huh? So they must be easy to get rid of right?";
new ScriptObject(L3A_PimpleDialogueMidAnswer1Part2)	{	class = Dialogue;	};
L3A_PimpleDialogueMidAnswer1Part2.Setup(%text);
L3A_PimpleDialogueMidAnswer1Part2.canEnd = false;

//	"Sebum has built up in your skin pores, forming pimples."
%text = "So the pimples are just built up sebum, whatever that is. How do I get rid of them?";
new ScriptObject(L3A_PimpleDialogueMidAnswer2Part2)	{	class = Dialogue;	};
L3A_PimpleDialogueMidAnswer2Part2.Setup(%text);
L3A_PimpleDialogueMidAnswer2Part2.canEnd = false;

//	"I have no idea."
%text = "You don't? But can you tell me how to get rid of them?";
new ScriptObject(L3A_PimpleDialogueMidAnswer3Part2)	{	class = Dialogue;	};
L3A_PimpleDialogueMidAnswer3Part2.Setup(%text);
L3A_PimpleDialogueMidAnswer3Part2.canEnd = false;

//	Washing or cream
%text = "Oh good. So will they keep coming back?";
new ScriptObject(L3A_PimpleDialogueMidAnswer1Part3)	{	class = Dialogue;	};
L3A_PimpleDialogueMidAnswer1Part3.Setup(%text);
L3A_PimpleDialogueMidAnswer1Part3.canEnd = false;

//	See a doctor
%text = "You think so. It looks pretty serious to me. Will they keep coming back?";
new ScriptObject(L3A_PimpleDialogueMidAnswer2Part3)	{	class = Dialogue;	};
L3A_PimpleDialogueMidAnswer2Part3.Setup(%text);
L3A_PimpleDialogueMidAnswer2Part3.canEnd = false;

//==	End    ==//
//	Helped
%text = "Great! Thank you for explaining the pimples to me.";
new ScriptObject(L3A_PimpleDialogueEndHelped1)	{	class = Dialogue;	};
L3A_PimpleDialogueEndHelped1.Setup(%text);
%text = "Oh I see. I'll just have to deal with them then. Thank you for explaining the pimples to me.";
new ScriptObject(L3A_PimpleDialogueEndHelped2)	{	class = Dialogue;	};
L3A_PimpleDialogueEndHelped2.Setup(%text);
%text = "Oh. So we can't be certain they'll be gone. Aw well, thank you for explaining the pimples to me.";
new ScriptObject(L3A_PimpleDialogueEndHelped3)	{	class = Dialogue;	};
L3A_PimpleDialogueEndHelped3.Setup(%text);

//	Not helped
%text = "I just want them to go away but I'm too afraid to touch them. Who knows what could happen if I do.";
new ScriptObject(L3A_PimpleDialogueEndNotHelped)	{	class = Dialogue;	};
L3A_PimpleDialogueEndNotHelped.Setup(%text);

//======	Assemble Tree    ======//
//==	Beginning    ==//
L3A_PimpleDialogueTree.rootDialogue[0] = L3A_PimpleDialogueInitGreeting;
L3A_PimpleDialogueTree.rootDialogue[1] = L3A_PimpleDialogueRepeatGreeting;
L3A_PimpleDialogueTree.rootDialogue[2] = L3A_PimpleDialogueHelpedGreeting;

//==	Middle    ==//
//	Link to "Are you blind!..."
%text = "It doesn't look as bad as you think it does.";
L3A_PimpleDialogueInitGreeting.AddResponse(%text, L3A_PimpleDialogueMidAnswer0Part1);
L3A_PimpleDialogueRepeatGreeting.AddResponse(%text, L3A_PimpleDialogueMidAnswer0Part1);

//	Link to "Pimples! Why do I have pimples on my face?!"
%text = "Those are pimples.";
L3A_PimpleDialogueInitGreeting.AddResponse(%text, L3A_PimpleDialogueMidAnswer1Part1);
L3A_PimpleDialogueRepeatGreeting.AddResponse(%text, L3A_PimpleDialogueMidAnswer1Part1);
L3A_PimpleDialogueMidAnswer0Part1.AddResponse(%text, L3A_PimpleDialogueMidAnswer1Part1);

//	Link to "Acne! Why do I have acne?!"
%text = "You have acne.";
L3A_PimpleDialogueInitGreeting.AddResponse(%text, L3A_PimpleDialogueMidAnswer2Part1);
L3A_PimpleDialogueRepeatGreeting.AddResponse(%text, L3A_PimpleDialogueMidAnswer2Part1);
L3A_PimpleDialogueMidAnswer0Part1.AddResponse(%text, L3A_PimpleDialogueMidAnswer2Part1);

//	Link to "Dirt and oil huh?..."
%text = "Dirt and oil from your skin is forming them.";
L3A_PimpleDialogueMidAnswer1Part1.AddResponse(%text, L3A_PimpleDialogueMidAnswer1Part2);
L3A_PimpleDialogueMidAnswer2Part1.AddResponse(%text, L3A_PimpleDialogueMidAnswer1Part2);

//	Link to just built up sebum...
%text = "Sebum has built up in your skin pores, forming pimples.";
L3A_PimpleDialogueMidAnswer1Part1.AddResponse(%text, L3A_PimpleDialogueMidAnswer2Part2);
L3A_PimpleDialogueMidAnswer2Part1.AddResponse(%text, L3A_PimpleDialogueMidAnswer2Part2);

//	Link to don't know
%text = "I have no idea.";
L3A_PimpleDialogueMidAnswer1Part1.AddResponse(%text, L3A_PimpleDialogueMidAnswer3Part2);
L3A_PimpleDialogueMidAnswer2Part1.AddResponse(%text, L3A_PimpleDialogueMidAnswer3Part2);

//	Link to "Oh good. So will they keep coming back?"
%text = "Regular washing can reduce them.";
L3A_PimpleDialogueMidAnswer1Part2.AddResponse(%text, L3A_PimpleDialogueMidAnswer1Part3);
L3A_PimpleDialogueMidAnswer2Part2.AddResponse(%text, L3A_PimpleDialogueMidAnswer1Part3);
L3A_PimpleDialogueMidAnswer3Part2.AddResponse(%text, L3A_PimpleDialogueMidAnswer1Part3);
%text = "Acne cream can help get rid of them.";
L3A_PimpleDialogueMidAnswer1Part2.AddResponse(%text, L3A_PimpleDialogueMidAnswer1Part3);
L3A_PimpleDialogueMidAnswer2Part2.AddResponse(%text, L3A_PimpleDialogueMidAnswer1Part3);
L3A_PimpleDialogueMidAnswer3Part2.AddResponse(%text, L3A_PimpleDialogueMidAnswer1Part3);

//	Link to see doctor
%text = "If it's serious, you should see a doctor.";
L3A_PimpleDialogueMidAnswer1Part2.AddResponse(%text, L3A_PimpleDialogueMidAnswer2Part3);
L3A_PimpleDialogueMidAnswer2Part2.AddResponse(%text, L3A_PimpleDialogueMidAnswer2Part3);
L3A_PimpleDialogueMidAnswer3Part2.AddResponse(%text, L3A_PimpleDialogueMidAnswer2Part3);

//==	End    ==//
//	Link to Helped
%text = "At first yes, but they should stop appearing soon.";
L3A_PimpleDialogueMidAnswer1Part3.AddResponse(%text, L3A_PimpleDialogueEndHelped1);
L3A_PimpleDialogueMidAnswer2Part3.AddResponse(%text, L3A_PimpleDialogueEndHelped1);
%text = "Yes but there should be less as you get older.";
L3A_PimpleDialogueMidAnswer1Part3.AddResponse(%text, L3A_PimpleDialogueEndHelped2);
L3A_PimpleDialogueMidAnswer2Part3.AddResponse(%text, L3A_PimpleDialogueEndHelped2);
%text = "You may still get them. It depends on your genes.";
L3A_PimpleDialogueMidAnswer1Part3.AddResponse(%text, L3A_PimpleDialogueEndHelped3);
L3A_PimpleDialogueMidAnswer2Part3.AddResponse(%text, L3A_PimpleDialogueEndHelped3);

//	Link to Not Helped
%text = "I don't know.";
L3A_PimpleDialogueInitGreeting.AddResponse(%text, L3A_PimpleDialogueEndNotHelped);
L3A_PimpleDialogueRepeatGreeting.AddResponse(%text, L3A_PimpleDialogueEndNotHelped);
L3A_PimpleDialogueMidAnswer0Part1.AddResponse(%text, L3A_PimpleDialogueEndNotHelped);

//======	Callbacks    ======//
function L3A_PimpleDialogueTree::onOpen(%this)
{
	if (%this.owner.helped)
	{
		%this.selectedRootDialogue = 2;
	}
	else if (%this.rootDialogue[0].beenRead)
		%this.selectedRootDialogue = 1;
	
	return true;
}
function L3A_PimpleDialogueTree::onClose(%this)
{
	if (%this.currentDialogue $= L3A_PimpleDialogueEndHelped1 ||
	   %this.currentDialogue $= L3A_PimpleDialogueEndHelped2 ||
	   %this.currentDialogue $= L3A_PimpleDialogueEndHelped3)
	{
		%this.owner.helped = true;
		Lesson3A.UpdateStatus();
	}

	return true;
}
function L3A_PimpleDialogueTree::onNext(%this)
{
	return true;
}