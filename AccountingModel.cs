using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting;

public class AccountingModel : ModelBase
{
    private double price;
    private int nightsCount;
    private double discount;
    private double total;
    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("price cannot be less than 0", nameof(value));
            }
            price = value;
            Notify(nameof(Price));

            Notify(nameof(Total));
        }
    }

    public int NightsCount
    {
        get { return nightsCount; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("nigts count cannot be negative or zero", nameof(value));
            }
            nightsCount = value;
            Notify(nameof(NightsCount));

            Notify(nameof(Total));
        }
    }

    public double Discount
    {
        get { return discount; }
        set
        {
            if (value > 100)
            {
                throw new ArgumentException("discount should be in range 0 - 100", nameof(value));
            }
            discount = value;

            Notify(nameof(Discount));
            Notify(nameof(Total));
        }
    }

    public double Total
    {
        get { return total = price * nightsCount * (1 - discount / 100); }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("total cannot be less than 0", nameof (value));
            }
            total = value;
            discount = (1 - value / (price * nightsCount)) * 100;
            Notify(nameof(Total));
            Notify(nameof(Discount));
        }
    }
}