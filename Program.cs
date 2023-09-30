Carta carta = new Carta("Rey", "Corazones", 12);
carta.Print();

Mazo mazo = new Mazo();
mazo.PrintMazo();


Carta cartaEliminada = mazo.Reparto();
Console.WriteLine(cartaEliminada.Nombre);
Console.WriteLine(cartaEliminada.Pinta);
Console.WriteLine(cartaEliminada.Val);
mazo.PrintMazo();

mazo.Reinicio();
mazo.PrintMazo();

mazo.Barajado();
mazo.PrintMazo();

//player
Jugador jugador = new Jugador();
jugador.Robo(mazo);
jugador.Robo(mazo);
jugador.Robo(mazo);

foreach (var valor in jugador.Mano)
{
    Console.WriteLine(valor.Nombre);
    Console.WriteLine(valor.Pinta);
    Console.WriteLine(valor.Val);
}
Console.WriteLine("\nCarta descartada");
Carta? temp = jugador.Descarte(0);
if (temp == null)
{
    Console.WriteLine("Es null o  no existe en el índice");
}
else
{
    Console.WriteLine("El nombre de la carta descartada es : " + temp.Nombre);
}
class Carta
{
    public string Nombre;
    public string Pinta;
    public int Val;

    public Carta(string nombre, string pinta, int val)
    {
        Nombre = nombre;
        Pinta = pinta;
        Val = val;
    }
    public void Print()
    {
        Console.WriteLine("Carta : " + Nombre);
        Console.WriteLine("Valor : " + Val);
        Console.WriteLine("Pinta : " + Pinta + "\n");
    }
}

class Mazo
{
    public List<Carta> Cartas;

    public Mazo()
    {
        Cartas = new List<Carta>();
        DefinirMazo();
    }

    private void DefinirMazo()
    {
        //Tipos de pintas
        List<string> pintasValidas = new List<string>(){
            "Tréboles",
            "Picas",
            "Corazones",
            "Diamantes"
        };
        List<string> nombres = new List<string>() { "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jota", "Reina", "Rey" };
        for (int i = 0; i < 4; i++)
        {
            for (int ivalor = 0; ivalor < 13; ivalor++)
            {
                Cartas.Add(new Carta(pintasValidas[i], nombres[ivalor], ivalor));
            }
        }
    }

    public Carta Reparto()
    {
        int valorBase = Cartas[0].Val;
        int indexRemove = 0;
        for (int i = 1; i < Cartas.Count; i++)
        {
            if (Cartas[i].Val > valorBase)
            {
                valorBase = Cartas[i].Val;
                indexRemove = i;
            }
        }
        Carta Temp = Cartas[indexRemove];
        Cartas.RemoveAt(indexRemove);
        return Temp;
    }

    public void Reinicio()
    {
        Cartas = new List<Carta>();
        DefinirMazo();
        Console.WriteLine("Se han restablecido las cartas del mazo");
    }

    public void Barajado()
    {
        Random rand = new Random();
        for (int i = 0; i < Cartas.Count; i++)
        {
            int posicion1 = rand.Next(0, Cartas.Count);
            int posicion2 = rand.Next(0, Cartas.Count);
            while (posicion1 == posicion2)
            {
                posicion2 = rand.Next(0, Cartas.Count);
            }
            Console.WriteLine(posicion1 + " ---- " + posicion2 + "\n");
            Carta tempStore = Cartas[posicion1];
            Cartas[posicion1] = Cartas[posicion2];
            Cartas[posicion2] = tempStore;
        }
        Console.WriteLine("Se ha Barajado las cartas.");
    }
    public void PrintMazo()
    {
        foreach (var resultado in Cartas)
        {
            resultado.Print();
        }
    }
}

class Jugador
{
    public string nombre;
    public List<Carta> Mano;

    public Jugador()
    {
        nombre = "juan";
        Mano = new List<Carta>();
    }
    public Carta Robo(Mazo mazo)
    {
        Carta robada = mazo.Reparto();
        Mano.Add(robada);
        return robada;
    }

    public Carta? Descarte(int indice)
    {
        if (indice >= 0 && indice < Mano.Count)
        {
            Carta cartaDescartada = Mano[indice];
            Mano.RemoveAt(indice);
            return cartaDescartada;
        }
        else
        {
            return null;
        }
    }
}