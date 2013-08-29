//	Triggers are areas in the TMX map that run a script when other sprites collide with them
//echo("Loading Triggers");

function SetupTrigger(%trigger)
{
   %trigger.setBodyType(static);
   %trigger.setCollisionCallback(true);	// So onCollision will be called
   %trigger.setFixedAngle(true);		// Stop from rotating on collision
   %trigger.setCollisionShapeIsSensor(0, true);	/*	Disables collision shape but still detects
									collisions - sprites can continue moving through them */
}
/*
//	Trigger Types
function TriggerBox::onAddToScene(%this)
{
   %this.createPolygonBoxCollisionShape(%this.width, %this.height);
   SetupTrigger(%this);
}
function TriggerCircle::onAddToScene(%this)
{
   %this.createCircleCollisionShape(%this.width);
   SetupTrigger(%this);
}

// Run script for trigger
function TriggerBox::onCollision(%this, %sceneobject, %collisiondetails)
{
	%this.Trigger(%sceneobject, %collisiondetails);
}
function TriggerCircle::onCollision(%this, %sceneobject, %collisiondetails)
{
	%this.Trigger(%sceneobject, %collisiondetails);
}*/