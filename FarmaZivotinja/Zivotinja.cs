using System;

public abstract class Zivotinja : IZivotinja
{
    public string ime { get; set; }
    public string pasmina { get; set; }
    public int stupanjSrece { get; set; }

    public abstract void Glasanje();
    public abstract void Crtez();


}
