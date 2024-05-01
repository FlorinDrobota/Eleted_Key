using Eleted_Key.Models;
using System;
using System.Collections.Generic;

namespace Eleted_Key.Controllers.Models;

public class Cart
{
    private List<Game> products = new List<Game>();

    public void AddProduct(Game product)
    {
        products.Add(product);
    }

    public void RemoveProduct(Game product)
    {
        products.Remove(product);
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            // total += product.Price * product.Quantity; //
        }
        return total;
    }
}