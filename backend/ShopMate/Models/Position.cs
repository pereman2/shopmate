﻿using System;

namespace ShopMate.Models
{
    public class Position : IEquatable<Position>
    {
        public int X { get; internal set; }
        public int Y { get; internal set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? other) => other is Position position && Equals(position);

        public bool Equals(Position? other)
            => X == other?.X && Y == other?.Y;

        public static bool operator ==(Position lhs, Position rhs) => lhs.Equals(rhs);
        public static bool operator !=(Position lhs, Position rhs) => !lhs.Equals(rhs);

        public override int GetHashCode() => (23 * 31 + X) * 31 + Y;
    }
}
