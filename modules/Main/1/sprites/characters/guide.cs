// The closest thing I can find to a class constructor.
// Anything here will overwrite previously defined fields
/*
function Guide::onAdd(%this)
{
	%this.setup();
}*/

function Guide::Setup(%this)
{
	SetupCharacter(%this);
	%this.setSize(2);
	%this.UpdateImages();
}

// Change the images to match the current state
function Guide::UpdateImages(%this)
{
	%image = %this.imageName;
	%animation = %image @ %this.state @ %this.direction;
	%this.playAnimation(%animation);
}

//	Default action when Player interacts with Guide
function Guide::Use(%this, %user)
{
	%this.dialogueTree.OpenDialogue(%user);
}

//	Set the character to look at the target
function Guide::FaceTarget(%this, %target)
{
	//	Find the angle of the two positions
	%angle = Vector2AngleToPoint(%this.getPosition(), %target.getPosition());

	if (%angle < 135 && %angle > 45)
		%this.direction = $SpriteDirectionRight;
	else if (%angle > -135 && %angle < -45)
		%this.direction = $SpriteDirectionLeft;
	else if (%angle <= 45 && %angle >= -45)
		%this.direction = $SpriteDirectionDown;
	else
		%this.direction = $SpriteDirectionUp;
	
	%this.UpdateImages();
}