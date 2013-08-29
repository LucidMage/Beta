function CreateProfile()
{
   new ScriptObject(Profile)
   {
      password = "guest";
      year = 8;
      gender = "female";
      ethnicity = "pakeha";
	  
	  torso = "plaid";
	  legs = "dress";
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