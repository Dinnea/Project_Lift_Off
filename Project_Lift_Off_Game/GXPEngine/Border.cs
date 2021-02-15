using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Border : Wall 
{
    public Border() //Invisible version of Wall class
    {
        this.visible = false;
    }
}