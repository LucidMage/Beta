function Pushable::onAdd(%this)
{
   %this.SceneLayer = 14;
   %this.Size = 1;
   
   %this.setBodyType(dynamic);
   
   // This effects how characters collide
   %this.setDefaultDensity(350);   // Made ridiculously high so characters will not budge
   %this.setDefaultRestitution(0.1);	//	Bounciness
   %this.setDefaultFriction(0);
   %this.setLinearDamping(2);	//	How quickly it slows down
   
   %this.createPolygonBoxCollisionShape(1, 1);
   
   %this.setCollisionCallback(true);
   %this.setFixedAngle(true);
}