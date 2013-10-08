//======	Dialogue Tree    ======//
new ScriptObject(L2_StoneSignDialogueTree)	{	class = DialogueTree;	};
L2_StoneSignDialogueTree.Setup(L2_StoneSign);

//======	Dialogue    ======//
%text = "Find the orbs and match the orb statements to the correct slot to open the gate." NL "Left slot = true orbs. Right slot = false orbs";
new ScriptObject(L2_StoneSignGreeting)	{	class = Dialogue;	};
L2_StoneSignGreeting.Setup(%text);
L2_StoneSignGreeting.faceTarget = false;

//======	Assemble Tree    ======//
L2_StoneSignDialogueTree.rootDialogue[0] = L2_StoneSignGreeting;

//======	Callbacks    ======//
function L2_StoneSignDialogueTree::onOpen(%this)
{
	Lesson2.UpdateStatus();
	return true;
}
function L2_StoneSignDialogueTree::onClose(%this)
{
	return true;
}
function L2_StoneSignDialogueTree::onNext(%this)
{
	return true;
}