using System;

namespace ReversiBot
{
	public struct Vector2 : IComparable
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Vector2(int x, int y)
		{
			X = x;
			Y = y;
		}
		public static Vector2 Zero()
		{
			return new Vector2(0, 0);
		}

		/// <sumary>
		/// Algebraic Notation
		/// </sumary>
		public string AN()
		{
			char letter = (char)((int)'A' + Y);
			return letter + "" + (X+1);
		}

		public override string ToString() => "( " + X + "," + Y + " )";

		public override bool Equals(object obj) => obj is Vector2 other && this.Equals(other);

		public bool Equals(Vector2 p) => X == p.X && Y == p.Y;

		public override int GetHashCode() => (X, Y).GetHashCode();

		public int CompareTo(object obj)
		{	
			Vector2 other = (Vector2)obj;
			
			int x = X.CompareTo(other.X);
			if(x == 0)
			{
				int y = Y.CompareTo(other.Y);
				return y;
			}
			else
				return x;
		}

		public static bool operator ==(Vector2 lhs, Vector2 rhs) => lhs.Equals(rhs);
		public static bool operator !=(Vector2 lhs, Vector2 rhs) => !(lhs == rhs);
		public static bool operator <(Vector2 lhs, Vector2 rhs) => lhs.X < rhs.X || lhs.Y < rhs.Y;
		public static bool operator >(Vector2 lhs, Vector2 rhs) => lhs.X > rhs.X || lhs.Y > rhs.Y;

	}
}
