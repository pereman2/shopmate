﻿#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopMate.Models
{
    public class Category : IEquatable<Category>
    {
        public int Id { get; private set; }

        /// <summary>
        /// The name of this category.
        /// </summary>
        [MaxLength(50)]
        public string Name { get; internal set; }

        public Category? Parent { get; internal set; }
        public ICollection<Category> Children { get; internal set; }

        /// <summary>
        /// The products tagged with this category.
        /// </summary>
        public ICollection<Product> Products { get; internal set; } = new HashSet<Product>();

        public Category(string name)
        {
            Name = name;
        }

        public override bool Equals(object? other) => other is Category category && Equals(category);

        public bool Equals(Category? other) => Name == other?.Name;

        public static bool operator ==(Category lhs, Category rhs) => lhs.Equals(rhs);
        public static bool operator !=(Category lhs, Category rhs) => !lhs.Equals(rhs);

        public override int GetHashCode() => Name.GetHashCode();
    }
}
