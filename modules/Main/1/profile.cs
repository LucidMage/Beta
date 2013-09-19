function CreateProfile()
{
   new ScriptObject(Profile)
   {
      //password = "guest";
      year = 8;
      gender = $SpriteGenderFemale;
      ethnicity = $SpriteEthnicityMaori;
	  
	  torso = $SpriteTorsoPlaid;
	  legs = $SpriteLegsDress;
   };
   
   // Create Default Player Character
   %player = new CompositeSprite(Player)
   {
      displayName = "Test";
      class = "Character";
      gender = Profile.gender;
      ethnicity = Profile.ethnicity;
	  
	  torso = Profile.torso;
	  legs = Profile.legs;
   };
   
   // Must be different than other characters to stop the player from pushing other characters
   %player.setDefaultDensity(0);
   
   Profile.character = %player;
}

function OpenProfileGUI()
{
	Canvas.pushDialog(ProfileGUI);
	
    //==	Gender    ==//
    //	Populate gender list
    %count = $SpriteGenderCount;
	
    for (%i = 0; %i < $SpriteGenderCount; %i++)
    {
        //	Add to the list.  
        GenderList.add($SpriteGenderArray[%i], %i);
        
        if (%i == 0)
            GenderList.setSelected( %i );
			
        //	Select if it's the default one.
		if (Profile.gender $= $SpriteGenderArray[%i])
            GenderList.setSelected( %i );
    }
    GenderList.sort();
	
    //==	Ethnicity    ==//
    //	Populate enthnicity list
    %count = $SpriteEthnicityCount;
	
    for (%i = 0; %i < $SpriteEthnicityCount; %i++)
    {
        //	Add to the list.  
        EthnicityList.add($SpriteEthnicityArray[%i], %i);
        
        if (%i == 0)
            EthnicityList.setSelected( %i );
			
        //	Select if it's the default one.
		if (Profile.ethnicity $= $SpriteEthnicityArray[%i])
            EthnicityList.setSelected( %i );
    }
    EthnicityList.sort();
	
    //==	Hair    ==//
    //	Populate hair list
    %colourCount = $SpriteEthnicityCount;
	
    for (%i = 0; %i < $SpriteEthnicityCount; %i++)
    {
        //	Add to the list.  
        EthnicityList.add($SpriteEthnicityArray[%i], %i);
        
        if (%i == 0)
            EthnicityList.setSelected( %i );
			
        //	Select if it's the default one.
		if (Profile.ethnicity $= $SpriteEthnicityArray[%i])
            EthnicityList.setSelected( %i );
    }
    EthnicityList.sort();
}

function CloseProfileGUI()
{
	Canvas.popDialog(ProfileGUI);
}