//======	Dialogue Tree    ======//
new ScriptObject(L3A_StoneSignDialogueTree)	{	class = DialogueTree;	};
L3A_StoneSignDialogueTree.Setup(L3A_StoneSign);

//======	Dialogue    ======//
//	First time talking to player
%text = "Help the lost people and the forest will release you.";
new ScriptObject(L3A_StoneSignGreeting)	{	class = Dialogue;	};
L3A_StoneSignGreeting.Setup(%text);
L3A_StoneSignGreeting.faceTarget = false;

//======	Assemble Tree    ======//
L3A_StoneSignDialogueTree.rootDialogue[0] = L3A_StoneSignGreeting;

//======	Callbacks    ======//
function L3A_StoneSignDialogueTree::onOpen(%this)
{
	Lesson3A.UpdateStatus();
	return true;
}
function L3A_StoneSignDialogueTree::onClose(%this)
{
	return true;
}
function L3A_StoneSignDialogueTree::onNext(%this)
{
	return true;
}