//======	Dialogue Tree    ======//
new ScriptObject(L3A_PeriodDialogueTree)	{	class = DialogueTree;	};
L3A_PeriodDialogueTree.Setup(L3A_PeriodGirl);

//======	Dialogue    ======//
//==	Beginning    ==//
//	First time talking to player
%text = "Have you got a 1st-aid kit, I'm bleeding!";
new ScriptObject(L3A_PeriodDialogueInitGreeting)	{	class = Dialogue;	};
L3A_PeriodDialogueInitGreeting.Setup(%text);
L3A_PeriodDialogueInitGreeting.canEnd = false;
L3A_PeriodDialogueInitGreeting.canRepeat = false;

//	"What happened to you?"
%text = "I... I don't know but blood has started coming out of my vagina! Something must've cut me some how! Or... or could this be something more serious?!";
new ScriptObject(L3A_PeriodDialogueInitExplain1)	{	class = Dialogue;	};
L3A_PeriodDialogueInitExplain1.Setup(%text);
L3A_PeriodDialogueInitExplain1.canEnd = false;
//L3A_PeriodDialogueInitExplain1.canRepeat = false;

//	"Where are you bleeding?"
%text = "Umm... I think it's coming from my vagina, blood has started coming out! Something must've cut me some how! Or... or could this be something more serious?!";
new ScriptObject(L3A_PeriodDialogueInitExplain2)	{	class = Dialogue;	};
L3A_PeriodDialogueInitExplain2.Setup(%text);
L3A_PeriodDialogueInitExplain2.canEnd = false;
L3A_PeriodDialogueInitExplain2.canRepeat = false;

//	Still needs help
%text = "You're back! I still need your help! Why is my vagina bleeding?!";
new ScriptObject(L3A_PeriodDialogueRepeatGreeting)	{	class = Dialogue;	};
L3A_PeriodDialogueRepeatGreeting.Setup(%text);
L3A_PeriodDialogueRepeatGreeting.canEnd = false;

//	Been helped, explained
%text = "Thank you so much for explaining the bleeding to me. Good luck on your journey.";
new ScriptObject(L3A_PeriodDialogueHelpedGreeting)	{	class = Dialogue;	};
L3A_PeriodDialogueHelpedGreeting.Setup(%text);

//	Been helped, told to see doctor
%text = "I'll go see the doctor as soon as I can about the bleeding. Thanks for the suggestion.";
new ScriptObject(L3A_PeriodDialogueHelpedDoctorGreeting)	{	class = Dialogue;	};
L3A_PeriodDialogueHelpedDoctorGreeting.Setup(%text);

//==	Middle    ==//
//	"You're just having a period."
%text = "A period? What's that?";
new ScriptObject(L3A_PeriodDialogueMidAnswerPart1)	{	class = Dialogue;	};
L3A_PeriodDialogueMidAnswerPart1.Setup(%text);
L3A_PeriodDialogueMidAnswerPart1.canEnd = false;

//	"It's when you bleed like this every month."
%text = "This will happen every month! I'll just keep bleeding out like this every month?!";
new ScriptObject(L3A_PeriodDialogueMidAnswer1Part2)	{	class = Dialogue;	};
L3A_PeriodDialogueMidAnswer1Part2.Setup(%text);
L3A_PeriodDialogueMidAnswer1Part2.canEnd = false;

//	"It's when the lining of your uterus breaks down."
%text = "Breaking down!!! You're saying my insides will continue to bleed out?!";
new ScriptObject(L3A_PeriodDialogueMidAnswer2Part2)	{	class = Dialogue;	};
L3A_PeriodDialogueMidAnswer2Part2.Setup(%text);
L3A_PeriodDialogueMidAnswer2Part2.canEnd = false;

//	"It's a sign that you can get pregnant."
%text = "This bleeding means I can get pregnant? So every woman has this happen to them? Is there a way to stop it?";
new ScriptObject(L3A_PeriodDialogueMidAnswer3Part2)	{	class = Dialogue;	};
L3A_PeriodDialogueMidAnswer3Part2.Setup(%text);
L3A_PeriodDialogueMidAnswer3Part2.canEnd = false;

//	Only extra tissue
%text = "Oh! Phew... okay then. But is there something I can do about the blood?";
new ScriptObject(L3A_PeriodDialogueMidAnswer1Part3)	{	class = Dialogue;	};
L3A_PeriodDialogueMidAnswer1Part3.Setup(%text);
L3A_PeriodDialogueMidAnswer1Part3.canEnd = false;

//	"Nah, you'll be fine. It's just part of growing up."
%text = "Huh. Well can I at least do something about the blood?";
new ScriptObject(L3A_PeriodDialogueMidAnswer2Part3)	{	class = Dialogue;	};
L3A_PeriodDialogueMidAnswer2Part3.Setup(%text);
L3A_PeriodDialogueMidAnswer2Part3.canEnd = false;

//==	End    ==//
//	"Tampons and pads can absorb the blood."
%text = "Tampons and pads, got it. Thank you so much for telling me all this, I feel a lot better now.";
new ScriptObject(L3A_PeriodDialogueEndHelped1)	{	class = Dialogue;	};
L3A_PeriodDialogueEndHelped1.Setup(%text);

//	"You could talk to someone you trust about it."
%text = "I guess I could do that. Thanks for the help, I feel a lot better now.";
new ScriptObject(L3A_PeriodDialogueEndHelped2)	{	class = Dialogue;	};
L3A_PeriodDialogueEndHelped2.Setup(%text);

//	"Wear extra layers of underwear."
%text = "It'll have to be pretty thick underwear to stop it. Thank you for your help, I feel a lot better now.";
new ScriptObject(L3A_PeriodDialogueEndHelped3)	{	class = Dialogue;	};
L3A_PeriodDialogueEndHelped3.Setup(%text);

//	"I would see a doctor about that."
%text = "Sounds like a good idea. Thank you.";
new ScriptObject(L3A_PeriodDialogueEndHelpedDoctor)	{	class = Dialogue;	};
L3A_PeriodDialogueEndHelpedDoctor.Setup(%text);

//	Not helped
%text = "Damn. If you find anything that could help please bring it to me. I think the spots are spreading!";
new ScriptObject(L3A_PeriodDialogueEndNotHelped)	{	class = Dialogue;	};
L3A_PeriodDialogueEndNotHelped.Setup(%text);

//======	Assemble Tree    ======//
//==	Beginning    ==//
L3A_PeriodDialogueTree.rootDialogue[0] = L3A_PeriodDialogueInitGreeting;
L3A_PeriodDialogueTree.rootDialogue[1] = L3A_PeriodDialogueRepeatGreeting;
L3A_PeriodDialogueTree.rootDialogue[2] = L3A_PeriodDialogueHelpedGreeting;
L3A_PeriodDialogueTree.rootDialogue[3] = L3A_PeriodDialogueHelpedDoctorGreeting;

//	Link to Explaination 1
%text = "What happened to you?";
L3A_PeriodDialogueInitGreeting.AddResponse(%text, L3A_PeriodDialogueInitExplain1);
//	Link to Explaination 2
%text = "Where are you bleeding?";
L3A_PeriodDialogueInitGreeting.AddResponse(%text, L3A_PeriodDialogueInitExplain2);

//==	Middle    ==//
//	Link to Answer
%text = "You're just having a period.";
L3A_PeriodDialogueInitExplain1.AddResponse(%text, L3A_PeriodDialogueMidAnswerPart1);
L3A_PeriodDialogueInitExplain2.AddResponse(%text, L3A_PeriodDialogueMidAnswerPart1);
L3A_PeriodDialogueRepeatGreeting.AddResponse(%text, L3A_PeriodDialogueMidAnswerPart1);

//	Link to bleed every month
%text = "It's when you bleed like this every month.";
L3A_PeriodDialogueMidAnswerPart1.AddResponse(%text, L3A_PeriodDialogueMidAnswer1Part2);
//	Link to break down
%text = "It's when the lining of your uterus breaks down.";
L3A_PeriodDialogueMidAnswerPart1.AddResponse(%text, L3A_PeriodDialogueMidAnswer2Part2);
//	Link to can get pregnant
%text = "It's a sign that you can get pregnant.";
L3A_PeriodDialogueMidAnswerPart1.AddResponse(%text, L3A_PeriodDialogueMidAnswer3Part2);

//	Link to "Oh! Phew... okay then. But is there something I can do about the blood?"
%text = "Only three tablespoons of blood over 3-7 days will come out.";
L3A_PeriodDialogueMidAnswer1Part2.AddResponse(%text, L3A_PeriodDialogueMidAnswer1Part3);
L3A_PeriodDialogueMidAnswer2Part2.AddResponse(%text, L3A_PeriodDialogueMidAnswer1Part3);
%text = "No, when the egg isn't fertilised only extra tissue bleeds out.";
L3A_PeriodDialogueMidAnswer1Part2.AddResponse(%text, L3A_PeriodDialogueMidAnswer1Part3);
L3A_PeriodDialogueMidAnswer2Part2.AddResponse(%text, L3A_PeriodDialogueMidAnswer1Part3);
//	Link to "Huh. Well can I at least do something about the blood?"
%text = "Nah, you'll be fine. It's just part of growing up.";
L3A_PeriodDialogueMidAnswer1Part2.AddResponse(%text, L3A_PeriodDialogueMidAnswer2Part3);
L3A_PeriodDialogueMidAnswer2Part2.AddResponse(%text, L3A_PeriodDialogueMidAnswer2Part3);

//==	End    ==//
//	Link to Helped 1
%text = "Tampons and pads can absorb the blood.";
L3A_PeriodDialogueMidAnswer3Part2.AddResponse(%text, L3A_PeriodDialogueEndHelped1);
L3A_PeriodDialogueMidAnswer1Part3.AddResponse(%text, L3A_PeriodDialogueEndHelped1);
L3A_PeriodDialogueMidAnswer2Part3.AddResponse(%text, L3A_PeriodDialogueEndHelped1);

//	Link to Helped 2
%text = "You could talk to someone you trust about it.";
L3A_PeriodDialogueMidAnswer3Part2.AddResponse(%text, L3A_PeriodDialogueEndHelped2);
L3A_PeriodDialogueMidAnswer1Part3.AddResponse(%text, L3A_PeriodDialogueEndHelped2);
L3A_PeriodDialogueMidAnswer2Part3.AddResponse(%text, L3A_PeriodDialogueEndHelped2);

//	Link to Helped 3
%text = "Wear extra layers of underwear.";
L3A_PeriodDialogueMidAnswer3Part2.AddResponse(%text, L3A_PeriodDialogueEndHelped3);
L3A_PeriodDialogueMidAnswer1Part3.AddResponse(%text, L3A_PeriodDialogueEndHelped3);
L3A_PeriodDialogueMidAnswer2Part3.AddResponse(%text, L3A_PeriodDialogueEndHelped3);

//	Link to Helped mentioning Doctor
%text = "You should see a doctor.";
L3A_PeriodDialogueInitExplain1.AddResponse(%text, L3A_PeriodDialogueEndHelpedDoctor);
L3A_PeriodDialogueInitExplain2.AddResponse(%text, L3A_PeriodDialogueEndHelpedDoctor);
L3A_PeriodDialogueRepeatGreeting.AddResponse(%text, L3A_PeriodDialogueEndHelpedDoctor);

//	Link to Not Helped
%text = "I don't know.";
L3A_PeriodDialogueInitExplain1.AddResponse(%text, L3A_PeriodDialogueEndNotHelped);
L3A_PeriodDialogueInitExplain2.AddResponse(%text, L3A_PeriodDialogueEndNotHelped);
L3A_PeriodDialogueRepeatGreeting.AddResponse(%text, L3A_PeriodDialogueEndNotHelped);

//======	Callbacks    ======//
function L3A_PeriodDialogueTree::onOpen(%this)
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
function L3A_PeriodDialogueTree::onClose(%this)
{
	if (%this.currentDialogue $= L3A_PeriodDialogueEndHelped1 ||
		%this.currentDialogue $= L3A_PeriodDialogueEndHelped2 ||
		%this.currentDialogue $= L3A_PeriodDialogueEndHelped3 ||
		%this.currentDialogue $= L3A_PeriodDialogueEndHelpedDoctor)
	{
	   if (%this.currentDialogue $= L3A_PeriodDialogueEndHelpedDoctor)
		   %this.owner.doctor = true; // Told they should see a doctor
	   
		%this.owner.helped = true;
		Lesson3A.UpdateStatus();
	}

	return true;
}
function L3A_PeriodDialogueTree::onNext(%this)
{
	return true;
}