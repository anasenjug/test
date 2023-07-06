using System;

public class Krava : Zivotinja, IZivotinja
{
    public Krava(string ime, string pasmina, int stupanjSrece)
    {
        this.ime = ime;
        this.pasmina = pasmina;
        this.stupanjSrece = stupanjSrece;
    }
    public override void Glasanje()
    {
        Console.WriteLine("moo\n");

    }
    public override void Crtez()
    {
        Console.Write("\\|/          (__)    \r\n     `\\------(oo)\r\n       ||    (__)\r\n       ||w--||     \\|/\r\n   \\|/");
    }
}
