using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        total += GetShippingCost();

        return total;
    }

    public double GetShippingCost()
    {
        if (_customer.LivesInGhana())
        {
            return 5.00;
        }
        else
        {
            return 35.00;
        }
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL:\n";

        foreach (Product product in _products)
        {
            label += $"  - {product.GetName()} (ID: {product.GetProductId()})\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        string label = "SHIPPING LABEL:\n";
        label += $"  {_customer.GetName()}\n";
        label += $"  {_customer.GetAddress().GetFullAddress()}\n";

        return label;
    }
}