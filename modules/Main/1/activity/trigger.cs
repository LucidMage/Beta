//	Triggers are areas in the TMX map that run a script when other sprites collide with them
function SetupTrigger(%trigger)
{
	echo("Setup Trigger");
   %trigger.setBodyType(static);
   %trigger.setCollisionCallback(true);	// So onCollision will be called
   %trigger.setFixedAngle(true);		// Stop from rotating on collision
   %trigger.setCollisionShapeIsSensor(0, true);	/*	Disables collision shape but still detects
									collisions - sprites can continue moving through them */
}