if (!isObject(WalkBehaviour))
{
   %template = new BehaviorTemplate(WalkBehaviour);
   
   %template.friendlyName = "Walk";
   %template.behaviorType = "Movement";
   %template.description = "Direction movement";
   
   // addBehaviorField(function name, description of function, keybind, input e.g. "keyboard up" = up arrow key)
   %template.addBehaviorField(upKey, "Key to bind to upward movement", keybind, "keyboard up");
}

function WalkBehaviour::onBehaviorAdd(%this)
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

function WalkBehaviour::onBehaviorRemove(%this)
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

function WalkBehaviour::update(%this)
{
   // Set animation group
   /*if (%this.up > 0 || %this.down > 0 || %this.left > 0 || %this.right > 0)
      %this.owner.state = $SpriteStateWalk;
   else
      %this.owner.state = $SpriteStateIdle;*/
   %this.owner.state = $SpriteStateWalk;
   
   // Set direction
   if (%this.up > 0)
      %this.owner.direction = $SpriteDirectionUp;
   if (%this.down > 0)
      %this.owner.direction = $SpriteDirectionDown;
   
   if (%this.left > 0)
      %this.owner.direction = $SpriteDirectionLeft;
   if (%this.right > 0)
      %this.owner.direction = $SpriteDirectionLeft;   // No right direction image frames
   
   // Set animation
   //%count = %this.owner.getSpriteCount();
   //for (%i = 0; %i < %count; %i++)
      //%this.owner.selectSpriteId(%i).animation = %this.owner.imageName @ %this.owner.direction;
   //%this.owner.setSpriteAnimation(%this.owner.getSpriteImage() @ %this.owner.state @ %this.owner.direction);
   %this.owner.setSpriteAnimation(%this.owner.imageName @ %this.owner.state @ %this.owner.direction);
   
   // Flip image if moving right
   if (%this.right > 0)
      %this.owner.setSpriteFlipX(true);
   // Must check all other directions else flipping will reset
   else if (%this.up > 0 || %this.down > 0 || %this.left > 0)
      %this.owner.setSpriteFlipX(false);
   
   %this.owner.setLinearVelocityX((%this.right - %this.left) * %this.owner.speed);
   %this.owner.setLinearVelocityY((%this.up - %this.down) * %this.owner.speed);
}

function WalkBehaviour::moveUp(%this, %val)
{
   %this.up = %val;
   %this.update();
}

function WalkBehaviour::moveDown(%this, %val)
{
   %this.down = %val;
   %this.update();
}

function WalkBehaviour::moveLeft(%this, %val)
{
   %this.left = %val;
   %this.update();
}

function WalkBehaviour::moveRight(%this, %val)
{
   %this.right = %val;
   %this.update();
}