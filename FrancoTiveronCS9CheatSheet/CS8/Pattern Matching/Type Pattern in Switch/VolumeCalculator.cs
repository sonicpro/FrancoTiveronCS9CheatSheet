using System;

namespace FrancoTiveronCS9CheatSheet.Pattern_Matching.Type_Pattern_in_Switch
{
	public static class VolumeCalculator
	{
		public static double GetVolumeWithIsStatement(object solid)
		{
			if (solid is Cube cube && cube.Side >= 0.0)
				return Math.Pow(cube.Side, 3);
			else if (solid is Cone cone && cone.Radius >= 0.0 && cone.Height >= 0.0)
				return Math.PI * Math.Pow(cone.Radius, 2) * cone.Height / 3.0;
			return double.NaN;
		}

		// Since C# 7 you a no longer restricted with integral types in switch statement.
		public static double GetVolumeSwitchStatementWithTypePattern(object solid)
		{
			switch (solid)
			{
				case Cube cube when cube.Side >= 0.0:
					return Math.Pow(cube.Side, 3);
				case Cone cone when cone.Radius >= 0.0 && cone.Height >= 0.0:
					return Math.PI * Math.Pow(cone.Radius, 2) * cone.Height / 3.0;
				default:
					return double.NaN;
			}
		}

		// C# 8+. Switch statement.
		public static double GetVolumeSwithExpressionWithTypePattern(object solid) => solid switch
		{
			Cube cube when cube.Side >= 0.0 => Math.Pow(cube.Side, 3),
			Cone cone when cone.Radius >= 0.0 && cone.Height >= 0.0 => Math.PI * Math.Pow(cone.Radius, 2) * cone.Height / 3.0,
			_ => double.NaN
		};
	}
}
