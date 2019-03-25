# Forked Version README:
This is a fork of the original ConeCastAll extension with added support to specify a starting radius. The difference is displayed here:

![ConeCast Difference](Comparison.png)

The original functionality is still there and the new functionality is added as an overload of the original ConeCastAll method. I am still experimenting a little bit with the new method because occasionally it does not behave as expected, so keep that in mind if you try to use this.

The original project README is below.

#   

![ConeCast](ConeCast.gif)
# ConeCastAll extension method
A Unity3d ConeCastAll extension method for the Physics class.

Use this to find colliders within a cone-shaped volume.

It uses SphereCastAll, which is like a RayCast tube, but then it uses Vector3.Angle to filter out hitpoints according to a cone.

Using it is very similar to using SphereCastAll.

Variables:
  Vector3 origin,
  float maxRadius,
  Vector3 direction,
  float maxDistance,
  float coneAngle
