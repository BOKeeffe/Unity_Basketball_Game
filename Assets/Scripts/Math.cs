using UnityEngine;
using System.Collections;

public static class Math
{
	public const float PI = 3.14159f;
	public const float EPSILON = 1e-005f;

	public static float Distance( Vector3 a, Vector3 b )
	{
		return sqrt( squared( b.x - a.x ) + squared( b.y - a.y ) +
			squared( b.z - a.z ) );
	}

	public static float Distance( Vector2 a, Vector2 b )
	{
		return sqrt( squared( b.x - a.x ) + squared( b.y - a.y ) );
	}

	public static float Magnitude( Vector3 a )
	{
		return sqrt( squared( a.x ) + squared( a.y ) + squared( a.z ) );
	}

	public static float Magnitude( Vector2 a )
	{
		return sqrt( squared( a.x ) + squared( a.y ) );
	}

	public static Vector3 Normalize( Vector3 a )
	{
		float mag = Magnitude( a );

		return new Vector3( a.x / mag, a.y / mag, a.z / mag );
	}

	public static Vector2 Normalize( Vector2 a )
	{
		float mag = Magnitude( a );

		return new Vector2( a.x / mag, a.y / mag );
	}

	public static float Dot( Vector3 a, Vector3 b )
	{
		return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
	}

	public static float Dot( Vector2 a, Vector2 b )
	{
		return (a.x * b.x) + (a.y * b.y);
	}

	public static float squared( float value )
	{
		return value * value;
	}

	public static Vector3 Cross(Vector3 a, Vector3 b)
	{
		return new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
	}

	public static float Abs(float value)
	{
		return value >= 0 ? value : -value;
	}

	public static float sqrt( float value )
	{
		float t;

		float squareRoot = value / 2;

		do
		{
			t = squareRoot;
			squareRoot = (t + (value / t)) / 2;
		} while ((t - squareRoot) != 0);

		return squareRoot;
	}
}

