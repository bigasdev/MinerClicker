using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int quantity;
    public int record;

    public virtual int Quantity{
        get{
            return quantity;
        }
    }

    public virtual int Record{
        get{
            return record;
        }
    }

    public virtual void IncreaseQuantity(){
        quantity++;
    }
}
