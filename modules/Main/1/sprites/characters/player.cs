function SetupPlayer(%scene, %position, %layer)
{
	error("Setup Player");
	
	/*
	%player = new CompositeSprite(Player)
	{
		displayName = "Test Player";
		class = "Character";
		imageName = "Assets:TD_Wizard_";  // temporary

		Position = %position;
		SceneLayer = %layer;
		// Graphics are defined by the sprites added below
		//Animation = "Assets:TD_Wizard_WalkSouth";
		//Image = "Assets:TD_Wizard_CompSprite";
	};

	// Must be different than other characters to stop the player from pushing other characters
	%player.setDefaultDensity(0);
	*/
	
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
	
	Player.gender = Profile.gender;
	Player.ethnicity = Profile.ethnicity;

	Player.hairColour = Profile.hairColour;
	Player.hairStyle = Profile.hairStyle;
	Player.torso = Profile.torso;
	Player.legs = Profile.legs;
	Player.accessory = Profile.accessory;

	Profile.character = Player;
	
	Player.Setup();
	Player.setDefaultDensity(100);	//	So player cannot push characters

	Player.setPosition(%position);
	Player.setSceneLayer(%layer);

	// Set Behaviours
	Player.setGeneralBehaviours();
	/*%controls = PlayerControlsBehaviour.createInstance();
	%player.addBehavior(%controls);

	%controls = InteractBehaviour.createInstance();
	%player.addBehavior(%controls);*/

	// Inventory
	//%inventory = new ScriptObject(Inventory);

	// Add to Scene
	%scene.add(Player);
	//addInteractionZone(%player, %scene);
	error("End of Setup Player");
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
	}
	PlayerPreview.gender = Profile.gender;
	PlayerPreview.ethnicity = Profile.ethnicity;

	PlayerPreview.hairColour = Profile.hairColour;
	PlayerPreview.hairStyle = Profile.hairStyle;
	PlayerPreview.torso = Profile.torso;
	PlayerPreview.legs = Profile.legs;
	PlayerPreview.accessory = Profile.accessory;
	
	%size = 5;
	
	PlayerPreview.setBodyType(static);
	
	PlayerPreview.addSprite();
	PlayerPreview.setSpriteName("legs");
	PlayerPreview.setSpriteSize(%size);
	
	PlayerPreview.addSprite();
	PlayerPreview.setSpriteName("torso");
	PlayerPreview.setSpriteSize(%size);
	
	PlayerPreview.addSprite();
	PlayerPreview.setSpriteName("head");
	PlayerPreview.setSpriteSize(%size);
	
	PlayerPreview.addSprite();
	PlayerPreview.setSpriteName("hair");
	PlayerPreview.setSpriteSize(%size);
	
	PlayerPreview.addSprite();
	PlayerPreview.setSpriteName("accessory");
	PlayerPreview.setSpriteSize(%size);
	
	PlayerPreview.UpdateImages();
}

function Player::setGeneralBehaviours(%this)
{
	echo("Setting General Behaviour");
	%this.clearBehaviors();

	echo("Create Instance of Player Controls");
	%controls = PlayerControlsBehaviour.createInstance();
	echo("Adding Behaviour");
	%this.addBehavior(%controls);

	echo("Create Instance of Interaction");
	%controls = InteractBehaviour.createInstance();
	echo("Adding Behaviour");
	%this.addBehavior(%controls);
	echo("General Behaviour Set");
}

function Player::setDialogueBehaviours(%this)
{
	echo("Setting Dialogue Behaviour");
	%this.clearBehaviors();
	
	%controls = DialogueBehaviour.createInstance();
	%this.addBehavior(%controls);
	echo("Dialogue Behaviour Set");
}
/*
function Player::onCollision(%this, %sceneobject, %collisiondetails)
{
   //%this.setBodyType(static);
   %this.setLinearVelocity("0 0");
   %this.setAngularVelocity("0");
}*/
/*
function Player::PickUpItem(%this, %item)
{
   %inventory.AddItem(%item);
   Player.inventory[Player.inventoryCount] = %item;
   Player.inventoryCount++;
   
   echo("New Item" SPC %item.getId());
   echo("Item at slot" SPC Player.inventoryCount-- SPC ":" SPC Player.inventory[Player.inventoryCount--]);
   echo("Inventory Count" SPC Player.inventoryCount);
}*/