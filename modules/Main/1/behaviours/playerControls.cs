if (!isObject(PlayerControlsBehaviour))
{
   %template = new BehaviorTemplate(PlayerControlsBehaviour);
   
   %template.friendlyName = "Player Controls";
   %template.behaviorType = "Input";
   //%template.description = "Player Controls";
   
   // addBehaviorField(function name, description of function, keybind, input e.g. "keyboard up" = up arrow key)
   %template.addBehaviorField(upKey, "Key to bind to upward movement", keybind, "keyboard up");
   %template.addBehaviorField(downKey, "Key to bind to downward movement", keybind, "keyboard down");
   %template.addBehaviorField(leftKey, "Key to bind to left movement", keybind, "keyboard left");
   %template.addBehaviorField(rightKey, "Key to bind to right movement", keybind, "keyboard right");
}

function PlayerControlsBehaviour::onBehaviorAdd(%this)
{
   if (!isObject(GlobalActionMap))
      return;

   // bindObj(getWord(object.behaviour field, [function parameters excluding %this]), "function name", object)
   GlobalActionMap.bindObj(getWord(%this.upKey, 0), getWord(%this.upKey, 1), "moveUp", %this);
   GlobalActionMap.bindObj(getWord(%this.downKey, 0), getWord(%this.downKey, 1), "moveDown", %this);
   GlobalActionMap.bindObj(getWord(%this.leftKey, 0), getWord(%this.leftKey, 1), "moveLeft", %this);
   GlobalActionMap.bindObj(getWord(%this.rightKey, 0), getWord(%this.rightKey, 1), "moveRight", %this);

   %this.up = 0;
   %this.down = 0;
   %this.left = 0;
   %this.right = 0;
}

function PlayerControlsBehaviour::onBehaviorRemove(%this)
{
   if (!isObject(GlobalActionMap))
      return;

   //%this.owner.disableUpdateCallback();

   GlobalActionMap.unbindObj(getWord(%this.upKey, 0), getWord(%this.upKey, 1), %this);
   GlobalActionMap.unbindObj(getWord(%this.downKey, 0), getWord(%this.downKey, 1), %this);
   GlobalActionMap.unbindObj(getWord(%this.leftKey, 0), getWord(%this.leftKey, 1), %this);
   GlobalActionMap.unbindObj(getWord(%this.rightKey, 0), getWord(%this.rightKey, 1), %this);

   %this.up = 0;
   %this.down = 0;
   %this.left = 0;
   %this.right = 0;
}

function PlayerControlsBehaviour::updateMovement(%this)
{
	// Set animation group
	if (%this.up > 0 || %this.down > 0 || %this.left > 0 || %this.right > 0)
	{
		%this.owner.state = $SpriteStateWalk;
		%this.owner.setLinearDamping(0);	//	So character will continue moving without slowing down
	}
	else
	{
		%this.owner.state = $SpriteStateIdle;
		%this.owner.setLinearDamping(%this.owner.damping);	//	Slows down
	}
   
   // Set direction
   if (%this.up > 0)
      %this.owner.direction = $SpriteDirectionUp;
   if (%this.down > 0)
      %this.owner.direction = $SpriteDirectionDown;
   
   if (%this.left > 0)
      %this.owner.direction = $SpriteDirectionLeft;
   if (%this.right > 0)
      %this.owner.direction = $SpriteDirectionRight;
   
   // Set animation
   //%count = %this.owner.getSpriteCount();
   //for (%i = 0; %i < %count; %i++)
      //%this.owner.selectSpriteId(%i).animation = %this.owner.imageName @ %this.owner.direction;
   //%this.owner.setSpriteAnimation(%this.owner.getSpriteImage() @ %this.owner.state @ %this.owner.direction);
   %this.owner.updateImages();
   //%this.owner.setSpriteAnimation(%this.owner.imageName @ %this.owner.state @ %this.owner.direction);
   	
	if (%this.up > 0 || %this.down > 0 || %this.left > 0 || %this.right > 0)
	{
		%this.owner.setLinearVelocityX((%this.right - %this.left) * %this.owner.speed);
		%this.owner.setLinearVelocityY((%this.up - %this.down) * %this.owner.speed);
	}
}

function PlayerControlsBehaviour::moveUp(%this, %val)
{
   %this.up = %val;
   %this.updateMovement();
}

function PlayerControlsBehaviour::moveDown(%this, %val)
{
   %this.down = %val;
   %this.updateMovement();
}

function PlayerControlsBehaviour::moveLeft(%this, %val)
{
   %this.left = %val;
   %this.updateMovement();
}

function PlayerControlsBehaviour::moveRight(%this, %val)
{
   %this.right = %val;
   %this.updateMovement();
}