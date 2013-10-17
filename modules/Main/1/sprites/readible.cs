function Readable::Setup(%this, %scene)
{
	%this.setBodyType(static);
	%this.createPolygonBoxCollisionShape(%this.collisionSize);
	
	if (%this.useRange == 0)
	   %this.useRange = (0.5 * %this.collisionSize.x);//.5;	// How close does something have to be for the character to use it
	
	//	Dialogue Tree
	if (!isObject(%this.dialogueTree))
	{
		%this.dialogueTree = new ScriptObject()
		{
			class = DialogueTree;
		};
	}
	%this.dialogueTree.Setup(%this);
	
	//	Setup Image to appear behind Character torso
	%this.addSprite();
	
	if (%this.animationName !$= "")
		%this.setSpriteAnimation(%this.animationName);
	else if (%this.imageName !$= "")
		%this.setSpriteImage(%this.imageName);
		
	%this.setSpriteLocalPosition(%this.imagePos);
	%this.setSpriteSize(%this.imageSize);
	
	%scene.add(%this);
	addInteractionZone(%this, %scene);
}

function Readable::Use(%this, %user)   {   %this.dialogueTree.OpenDialogue(%user);  }
function Readable::DisplayUse(%this)   {	return "Read" SPC %this.displayName @ ".";   }