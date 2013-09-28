if (!isObject(InteractBehaviour))
{
   %template = new BehaviorTemplate(InteractBehaviour);
   
   %template.friendlyName = "Interact";
   %template.behaviorType = "Input";
   %template.description = "Interact with sprite";
   
   // addBehaviorField(function name, description of function, keybind, input e.g. "keyboard up" = up arrow key)
   %template.addBehaviorField(useKey, "Key to bind for interacting with a sprite", keybind, "keyboard space");
}

function InteractBehaviour::onBehaviorAdd(%this)
{
   if (!isObject(GlobalActionMap))
      return;

   // bindObj(getWord(object.behaviour field, [function parameters excluding %this]), "function name", object)
   GlobalActionMap.bindObj(getWord(%this.useKey, 0), getWord(%this.useKey, 1), "Use", %this);
}

function InteractBehaviour::onBehaviorRemove(%this)
{
   if (!isObject(GlobalActionMap))
      return;

   //%this.owner.disableUpdateCallback();

   GlobalActionMap.unbindObj(getWord(%this.useKey, 0), getWord(%this.useKey, 1), %this);
}

//	Run the use function of whatever sprite is within range
function InteractBehaviour::Use(%this, %val)
{
	//echo("Val is " @ %val);
	if (%val > 0)
	{
		echo("Val is greater than 0");
		
		%direction = %this.owner.direction;
		%range = "0 0";
		%startPos = %this.owner.getPosition(); // Starting point of pickRay
		%startPos.x += %this.owner.positionAdjust.x;
		%startPos.y += %this.owner.positionAdjust.y;
		
		%scene = GameWindow.getScene();
		
		//	First select a sprite
		//	Should be in the direction the character is facing
		switch$(%direction)
		{
		   case $SpriteDirectionUp:
		      %range.y += %this.owner.useRange;
		   case $SpriteDirectionRight:
			   %range.x += %this.owner.useRange;
		   case $SpriteDirectionDown:
			   %range.y -= %this.owner.useRange;
		   case $SpriteDirectionLeft:
			   %range.x -= %this.owner.useRange;
		}
		
		// Get sprites within range
		%endPos = (%startPos.x + %range.x) SPC (%startPos.y + %range.y); // Ending point of pickRay
		%picked = %scene.pickRay(%startPos, %endPos, "", "", collision);
		
		// Iterate over list of picked objects
		%count = %picked.count;
		
		for (%i = 0; %i < %count; %i++)
		{
			%object = getWord(%picked, %i);
			echo("Object:" SPC %object);
			echo("Class:" SPC %object.class);

			if (%object.class $= InteractionZone)
			{
				echo("Owner:" SPC %object.owner);
				%object.owner.Use(%this.owner);
			}
			else
				%object.Use(%this.owner);
		}
		
		// For debugging
		%this.RangeOverlay.PolyList = %startPos SPC %endPos;
	}
}

//	Scheduled method to display description of what will happen when they use an object in range
function InteractBehaviour::DisplayUsable()
{
	%direction = %this.owner.direction;
	%range = "0 0";
	%startPos = %this.owner.getPosition(); // Starting point of pickRay
	%startPos.x += %this.owner.positionAdjust.x;
	%startPos.y += %this.owner.positionAdjust.y;
	
	%scene = GameWindow.getScene();
	
	//	First select a sprite
	//	Should be in the direction the character is facing
	switch$(%direction)
	{
		case $SpriteDirectionUp:
			%range.y += %this.owner.useRange;
		case $SpriteDirectionRight:
			%range.x += %this.owner.useRange;
		case $SpriteDirectionDown:
			%range.y -= %this.owner.useRange;
		case $SpriteDirectionLeft:
			%range.x -= %this.owner.useRange;
	}
	
	// Get sprites within range
	%endPos = (%startPos.x + %range.x) SPC (%startPos.y + %range.y); // Ending point of pickRay
	%picked = %scene.pickRay(%startPos, %endPos, "", "", collision);
	
	// Iterate over list of picked objects
	%count = %picked.count;
	
	for (%i = 0; %i < %count; %i++)
	{
		%object = getWord(%picked, %i);
		UpdateHelpBar(%this, %object.DisplayUse());
	}
}

//	Interaction Zone class functions
function addInteractionZone(%sprite, %scene)
{
	error("Add Interaction Zone");
	
	%sprite.interactionZone = new Trigger()
	{
		class = InteractionZone;
		owner = %sprite;
		BodyType = dynamic;
		Position = %sprite.getPosition();
		SceneLayer = %sprite.getSceneLayer();
	};
	%sprite.interactionZone.setDefaultDensity(1);   // Made ridiculously high so characters will not budge
	/*%sprite.interactionZone.setDefaultRestitution(0);	//	Bounciness
	%sprite.interactionZone.setDefaultFriction(0);
	%sprite.interactionZone.setLinearDamping(0);*/	//	How quickly it slows down
	%sprite.interactionZone.setCollisionSuppress(true);   // So onCollision will be called
	
	echo(%sprite.collisionSize);
	%radius = %sprite.collisionSize.x * 2;
	%sprite.interactionZone.createCircleCollisionShape(%radius);
	
	echo("Scene" SPC %scene);
	%scene.add(%sprite.interactionZone);
	%sprite.interactionJoin = %scene.createWeldJoint(%sprite, %sprite.interactionZone, "0 0", "0 0", 0, 0, false);
}

function InteractionZone::onStay(%this, %object)
{
	if (%object.getName() $= Player)
	{
		UpdateHelpBar(%this, %object.DisplayUse());
	}
}