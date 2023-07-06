using System;

public class Konj : Zivotinja, IZivotinja
{
    public Konj(string ime, string pasmina, int stupanjSrece)
    {
        this.ime = ime;
        this.pasmina = pasmina;
        this.stupanjSrece = stupanjSrece;
    }
    public override void Glasanje()
    {
        Console.WriteLine("njiha\n");

    }

    public override void Crtez()
    {
        Console.Write("     _ ____\r\n     /( ) _   \\\r\n    / //   /\\` \\,  ||--||--||-\r\n      \\|   |/  \\|  ||--||--||-\r\n~^~^~^~~^~~~^~~^^~^^^^^^^^^^^^");
    }

}