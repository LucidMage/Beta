function SetupPlayer(%scene, %position, %layer)
{
	if (!isObject(Player))
	{
		// Create Default Player Character
		new CompositeSprite(Player)
		{
			class = "Character";
		};

		// Must be different than other characters to stop the player from pushing other characters
		Player.setDefaultDensity(0);
	}
	
	Player.displayName = Profile.displayName;
	Player.direction = $SpriteDirectionDown;
	Player.state = $SpriteStateIdle;
	Player.inDialogue = false; // Used in toggling controls
	
	Player.gender = Profile.gender;
	Player.ethnicity = Profile.ethnicity;

	Player.hairColour = Profile.hairColour;
	Player.hairStyle = Profile.hairStyle;
	Player.torso = Profile.torso;
	Player.legs = Profile.legs;
	Player.accessory = Profile.accessory;

	Profile.character = Player;

	Player.setPosition(%position);
	Player.setSceneLayer(%layer);

	// Set Behaviours
	%controls = PlayerControlsBehaviour.createInstance();
	Player.addBehavior(%controls);

	%controls = InteractBehaviour.createInstance();
	Player.addBehavior(%controls);
	
	%controls = DialogueBehaviour.createInstance();
	Player.addBehavior(%controls);
	
	Player.Setup(%scene);
	//Player.interactionZone.setEnabled(false);
	Player.setDefaultDensity(100);	//	So player cannot push characters

	// Inventory
	//%inventory = new ScriptObject(Inventory);

	// Add to Scene
	%scene.add(Player);
	//addInteractionZone(%player, %scene);
}

//	Character shown during customization
function SetupPlayerPreview()
{
	if (!isObject(PlayerPreview))
	{
		new CompositeSprite(PlayerPreview)
		{
			class = Character;
			
			direction = $SpriteDirectionDown;
			state = $SpriteStateIdle;
		};
	   
      PlayerPreview.imageSize = 5;
      PlayerPreview.setBodyType(static);
      
      PlayerPreview.addSprite();
      PlayerPreview.setSpriteName("legs");
      PlayerPreview.setSpriteSize(PlayerPreview.imageSize);
      
      PlayerPreview.addSprite();
      PlayerPreview.setSpriteName("torso");
      PlayerPreview.setSpriteSize(PlayerPreview.imageSize);
      
      PlayerPreview.addSprite();
      PlayerPreview.setSpriteName("head");
      PlayerPreview.setSpriteSize(PlayerPreview.imageSize);
      
      PlayerPreview.addSprite();
      PlayerPreview.setSpriteName("hair");
      PlayerPreview.setSpriteSize(PlayerPreview.imageSize);
      
      PlayerPreview.addSprite();
      PlayerPreview.setSpriteName("accessory");
      PlayerPreview.setSpriteSize(PlayerPreview.imageSize);
	}
	
	PlayerPreview.gender = Profile.gender;
	PlayerPreview.ethnicity = Profile.ethnicity;

	PlayerPreview.hairColour = Profile.hairColour;
	PlayerPreview.hairStyle = Profile.hairStyle;
	PlayerPreview.torso = Profile.torso;
	PlayerPreview.legs = Profile.legs;
	PlayerPreview.accessory = Profile.accessory;
	
	PlayerPreview.UpdateImages();
}

function Player::toggleInDialogue(%this)  {   %this.inDialogue = !%this.inDialogue; }