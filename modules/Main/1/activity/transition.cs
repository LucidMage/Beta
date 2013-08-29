/*function Transition::onAddToScene(%this)
{
   %this.setBodyType(static);
   %this.createPolygonBoxCollisionShape(%this.width, %this.height);
   
   %this.setCollisionCallback(true);   // So onCollision will be called
   %this.setFixedAngle(true); // Stop from rotating on collision
}

function Transition::onRemove(%this)
{
   if ($ActivityScene == %this.toScene)
      LoadActivity(Main.ActiveActivity);
}*/
function Transition::onAddToScene(%this)
{
   %this.setBodyType(static);
   %this.createPolygonBoxCollisionShape(%this.width, %this.height);
   
   %this.setCollisionCallback(true);   // So onCollision will be called
   %this.setFixedAngle(true); // Stop from rotating on collision
}

// Change to a different scene when player collides with transition
function Transition::onEnter (%this, %object)
{
	if (%object.getName() $= Player)
	{
		// Assign schedule to current scene to make sure it doesn't remain after transition
		%scene = GameWindow.getScene();

		// Pause Scene
		//%scene.setScenePause(true);
		/*
		// Transition 'Mask'
		%fadeTo = new Sprite()
		{
		  SceneLayer = 0;
		  Position = GameWindow.getCameraPosition();
		  Size = GameWindow.getCameraSize();
		};
		%fadeTo.setImage("Assets:Blocks", 7);

		%scene.add(%fadeTo);*/

		// New scenes cannot be called during onCollision else the game will crash
		%path = $DataSavePath @ Player.name @ "." @ Main.ActiveActivity @ "." @ %scene.getName() @ $DataSaveExtension;
		%scene.schedule(100, LoadScene(%this.toScene));
	}
}