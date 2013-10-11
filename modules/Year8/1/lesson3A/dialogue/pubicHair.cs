//======	Dialogue Tree    ======//
new ScriptObject(L3A_PubicHairDialogueTree)	{	class = DialogueTree;	};
L3A_PubicHairDialogueTree.Setup(L3A_PubicHairPerson);

//======	Dialogue    ======//
//==	Beginning    ==//
//	First time talking to player
%text = "Excuse me. You wouldn't happen to have anything to treat spots would ya?";
new ScriptObject(L3A_PubicHairDialogueInitGreeting)	{	class = Dialogue;	};
L3A_PubicHairDialogueInitGreeting.Setup(%text);
L3A_PubicHairDialogueInitGreeting.canEnd = false;
L3A_PubicHairDialogueInitGreeting.canRepeat = false;

//	"What spots?"
%text = "Well... this is kinda awkward but I've got about a hundred small spots... down there. It's gotten so bad they've started sprouting hair!";
new ScriptObject(L3A_PubicHairDialogueInitExplainPart1)	{	class = Dialogue;	};
L3A_PubicHairDialogueInitExplainPart1.Setup(%text);
L3A_PubicHairDialogueInitExplainPart1.canEnd = false;
//L3A_PubicHairDialogueInitExplainPart1.canRepeat = false;

//	"Down there?"
%text = "Yes, 'down there' are lots of tiny hairy spots just above my genitals. Do you have anything to treat them?";
new ScriptObject(L3A_PubicHairDialogueInitExplainPart2)	{	class = Dialogue;	};
L3A_PubicHairDialogueInitExplainPart2.Setup(%text);
L3A_PubicHairDialogueInitExplainPart2.canEnd = false;
L3A_PubicHairDialogueInitExplainPart2.canRepeat = false;

//	Still needs help
%text = "Find anything to treat my spots down there?";
new ScriptObject(L3A_PubicHairDialogueRepeatGreeting)	{	class = Dialogue;	};
L3A_PubicHairDialogueRepeatGreeting.Setup(%text);
L3A_PubicHairDialogueRepeatGreeting.canEnd = false;

//	Been helped, explained
%text = "Thank you for explaining pubic hair to me. Good thing I didn't try to treat it.";
new ScriptObject(L3A_PubicHairDialogueHelpedGreeting)	{	class = Dialogue;	};
L3A_PubicHairDialogueHelpedGreeting.Setup(%text);

//	Been helped, told to see doctor
%text = "I'll go see the doctor as soon as I can. I hope they can help treat the spots.";
new ScriptObject(L3A_PubicHairDialogueHelpedDoctorGreeting)	{	class = Dialogue;	};
L3A_PubicHairDialogueHelpedDoctorGreeting.Setup(%text);

//==	Middle    ==//
//	"I think you're starting to grow pubic hair."
%text = "Wait. It's just hair? Why do I need hair down there?";
new ScriptObject(L3A_PubicHairDialogueMidAnswer0)	{	class = Dialogue;	};
L3A_PubicHairDialogueMidAnswer0.Setup(%text);
L3A_PubicHairDialogueMidAnswer0.canEnd = false;

//	"To prove you are an adult."
%text = "Really? There's got to be better ways of showing that. How much hair will I get?";
new ScriptObject(L3A_PubicHairDialogueMidAnswer1)	{	class = Dialogue;	};
L3A_PubicHairDialogueMidAnswer1.Setup(%text);
L3A_PubicHairDialogueMidAnswer1.canEnd = false;

//	"To keep your genitals warm and protected."
%text = "I don't recall my genitals needing warmth but I guess it can't hurt to have it. How much hair will I get?";
new ScriptObject(L3A_PubicHairDialogueMidAnswer2)	{	class = Dialogue;	};
L3A_PubicHairDialogueMidAnswer2.Setup(%text);
L3A_PubicHairDialogueMidAnswer2.canEnd = false;

//	"You don't, but you'll grow it anyway."
%text = "So it just happens for no reason... okay. How much hair will I get?";
new ScriptObject(L3A_PubicHairDialogueMidAnswer3)	{	class = Dialogue;	};
L3A_PubicHairDialogueMidAnswer3.Setup(%text);
L3A_PubicHairDialogueMidAnswer3.canEnd = false;

//==	End    ==//
//	"Too many."
%text = "I see. Thank you for explaining that to me.";
new ScriptObject(L3A_PubicHairDialogueEndHelped1)	{	class = Dialogue;	};
L3A_PubicHairDialogueEndHelped1.Setup(%text);

//	"Enough to cover genitals."
%text = "Woah. Sounds like it could get too bushy. Thank you for explaining that to me.";
new ScriptObject(L3A_PubicHairDialogueEndHelped2)	{	class = Dialogue;	};
L3A_PubicHairDialogueEndHelped2.Setup(%text);

//	"I would see a doctor about that."
%text = "Sounds like a good idea. Thank you.";
new ScriptObject(L3A_PubicHairDialogueEndHelpedDoctor)	{	class = Dialogue;	};
L3A_PubicHairDialogueEndHelpedDoctor.Setup(%text);

//	Not helped
%text = "Damn. If you find anything that could help please bring it to me. I think the spots are spreading!";
new ScriptObject(L3A_PubicHairDialogueEndNotHelped)	{	class = Dialogue;	};
L3A_PubicHairDialogueEndNotHelped.Setup(%text);

//======	Assemble Tree    ======//
//==	Beginning    ==//
L3A_PubicHairDialogueTree.rootDialogue[0] = L3A_PubicHairDialogueInitGreeting;
L3A_PubicHairDialogueTree.rootDialogue[1] = L3A_PubicHairDialogueRepeatGreeting;
L3A_PubicHairDialogueTree.rootDialogue[2] = L3A_PubicHairDialogueHelpedGreeting;
L3A_PubicHairDialogueTree.rootDialogue[3] = L3A_PubicHairDialogueHelpedDoctorGreeting;

//	Link to Part 1 Explaination
%text = "What spots?";
L3A_PubicHairDialogueInitGreeting.AddResponse(%text, L3A_PubicHairDialogueInitExplainPart1);
%text = "No I haven't got anything. Where are your spots?";
L3A_PubicHairDialogueInitGreeting.AddResponse(%text, L3A_PubicHairDialogueInitExplainPart1);

//	Link to Part 2 Explaination
%text = "Down there?";
L3A_PubicHairDialogueInitExplainPart1.AddResponse(%text, L3A_PubicHairDialogueInitExplainPart2);
L3A_PubicHairDialogueRepeatGreeting.AddResponse(%text, L3A_PubicHairDialogueInitExplainPart2);

//==	Middle    ==//
//	Link to Answer
%text = "I think you're starting to grow pubic hair.";
L3A_PubicHairDialogueInitExplainPart1.AddResponse(%text, L3A_PubicHairDialogueMidAnswer0);
L3A_PubicHairDialogueInitExplainPart2.AddResponse(%text, L3A_PubicHairDialogueMidAnswer0);
L3A_PubicHairDialogueRepeatGreeting.AddResponse(%text, L3A_PubicHairDialogueMidAnswer0);

//	Link to prove adult
%text = "To prove you are an adult.";
L3A_PubicHairDialogueMidAnswer0.AddResponse(%text, L3A_PubicHairDialogueMidAnswer1);

//	Link to warmth and protection
%text = "To keep your genitals warm and protected.";
L3A_PubicHairDialogueMidAnswer0.AddResponse(%text, L3A_PubicHairDialogueMidAnswer2);

//	Link to grow anyway
%text = "You don't, but you'll grow it anyway.";
L3A_PubicHairDialogueMidAnswer0.AddResponse(%text, L3A_PubicHairDialogueMidAnswer3);

//==	End    ==//
//	Link to Helped 1
%text = "Too many to count.";
L3A_PubicHairDialogueMidAnswer1.AddResponse(%text, L3A_PubicHairDialogueEndHelped1);
L3A_PubicHairDialogueMidAnswer2.AddResponse(%text, L3A_PubicHairDialogueEndHelped1);
L3A_PubicHairDialogueMidAnswer3.AddResponse(%text, L3A_PubicHairDialogueEndHelped1);
%text = "It depends on your genetics.";
L3A_PubicHairDialogueMidAnswer1.AddResponse(%text, L3A_PubicHairDialogueEndHelped1);
L3A_PubicHairDialogueMidAnswer2.AddResponse(%text, L3A_PubicHairDialogueEndHelped1);
L3A_PubicHairDialogueMidAnswer3.AddResponse(%text, L3A_PubicHairDialogueEndHelped1);

//	Link to Helped 2
%text = "Enough to cover your genitals.";
L3A_PubicHairDialogueMidAnswer1.AddResponse(%text, L3A_PubicHairDialogueEndHelped2);
L3A_PubicHairDialogueMidAnswer2.AddResponse(%text, L3A_PubicHairDialogueEndHelped2);
L3A_PubicHairDialogueMidAnswer3.AddResponse(%text, L3A_PubicHairDialogueEndHelped2);

//	Link to Helped mentioning Doctor
%text = "I would see a doctor about that.";
L3A_PubicHairDialogueInitExplainPart1.AddResponse(%text, L3A_PubicHairDialogueEndHelpedDoctor);
L3A_PubicHairDialogueInitExplainPart2.AddResponse(%text, L3A_PubicHairDialogueEndHelpedDoctor);
L3A_PubicHairDialogueRepeatGreeting.AddResponse(%text, L3A_PubicHairDialogueEndHelpedDoctor);

//	Link to Not Helped
%text = "Sorry, I can't help you with that.";
L3A_PubicHairDialogueInitExplainPart1.AddResponse(%text, L3A_PubicHairDialogueEndNotHelped);
L3A_PubicHairDialogueInitExplainPart2.AddResponse(%text, L3A_PubicHairDialogueEndNotHelped);
%text = "No I haven't.";
L3A_PubicHairDialogueRepeatGreeting.AddResponse(%text, L3A_PubicHairDialogueEndNotHelped);

//======	Callbacks    ======//
function L3A_PubicHairDialogueTree::onOpen(%this)
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
function L3A_PubicHairDialogueTree::onClose(%this)
{
	if (%this.currentDialogue $= L3A_PubicHairDialogueEndHelped1 ||
		%this.currentDialogue $= L3A_PubicHairDialogueEndHelped2 ||
		%this.currentDialogue $= L3A_PubicHairDialogueEndHelpedDoctor)
	{
	   if (%this.currentDialogue $= L3A_PubicHairDialogueEndHelpedDoctor)
		   %this.owner.doctor = true; // Told they should see a doctor
	   
		%this.owner.helped = true;
		Lesson3A.UpdateStatus();
	}

	return true;
}
function L3A_PubicHairDialogueTree::onNext(%this)
{
	return true;
}