function Readable::setup(%this, %image)
{
	error("Readable setup");
	%this.setBodyType(static);
	%this.createPolygonBoxCollisionShape(%this.getSize());
	
	//	Dialogue Tree
	%this.dialogueTree = new ScriptObject()
	{
		class = DialogueTree;
	};
	%this.dialogueTree.Setup(%this);
	
	%this.addSprite();
	%this.setSpriteSize(2);
	%this.setSpriteImage(%image);
}

function Readable::Use(%this, %user)
{
   //echo("Readable" SPC %this SPC "being used");
   %this.dialogueTree.OpenDialogue(%user);
}

function Readable::DisplayUse()
{
	return "Read" SPC %this.displayName @ ".";
}