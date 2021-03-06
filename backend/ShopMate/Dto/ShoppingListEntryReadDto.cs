﻿#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

namespace ShopMate.Dto
{
    public class ShoppingListEntryReadDto
    {
        public int Quantity { get; internal set; }

        public decimal TotalPrice { get; internal set; }

        public ProductReadDto Item { get; internal set; }
    }
}
