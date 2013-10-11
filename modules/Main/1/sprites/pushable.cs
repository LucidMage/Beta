function Pushable::Setup(%this, %scene)
{
	//error("Pushable setup");
	%this.setBodyType(dynamic);
	%this.setAngle(%this.angle);
   
	// This effects how characters collide
	%this.setDefaultDensity(%this.density);
	%this.setDefaultRestitution(0.1);	//	Bounciness
	%this.setDefaultFriction(0);
	%this.setLinearDamping(2);	//	How quickly it slows down
	
	%this.createPolygonBoxCollisionShape(%this.collisionSize);
	
	if (%this.useRange == 0)
	   %this.useRange = (0.5 * %this.collisionSize.x);
	
	%this.setCollisionCallback(true);
	%this.setFixedAngle(true);
	
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

function Pushable::Use(%this, %user)
{
   //echo("Pushable" SPC %this SPC "being used by" SPC %user);
   %vel = %this.getLinearVelocity();
   %max = 1;
   
   switch$(%user.direction)
   {
      case $SpriteDirectionUp:
         if (%vel.y < %max)
            %this.setLinearVelocityY(%vel.y + 1);
      case $SpriteDirectionDown:
         if (%vel.y > -%max)
            %this.setLinearVelocityY(%vel.y - 1);
      case $SpriteDirectionLeft:
         if (%vel.x > -%max)
            %this.setLinearVelocityX(%vel.x - 1);
      case $SpriteDirectionRight:
         if (%vel.x < %max)
            %this.setLinearVelocityX(%vel.x + 1);
      default:
   }
}

function Pushable::DisplayUse(%this)
{
	return "Push" SPC %this.displayName @ ".";
}