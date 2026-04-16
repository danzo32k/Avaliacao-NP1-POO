using System;
using System.Collections.Generic;

public interface IManutencao
{
    string RealizarManutencao();
}

public abstract class Veiculo
{
    protected string identificacao;
    protected double capacidadeCarga;
    protected string tipoCombustivel;

    public string Identificacao
    {
        get { return identificacao; }
        set { identificacao = value; }
    }

    public double CapacidadeCarga
    {
        get { return capacidadeCarga; }
        set { capacidadeCarga = value; }
    }

    public string TipoCombustivel
    {
        get { return tipoCombustivel; }
        set { tipoCombustivel = value; }
    }

    public abstract string RegistrarEntrega();
}

public class Caminhao : Veiculo, IManutencao
{
    public override string RegistrarEntrega()
    {
        return "Caminhão fez entrega pesada";
    }

    public string RealizarManutencao()
    {
        return "Caminhão passou por manutenção";
    }
}

public class Van : Veiculo, IManutencao
{
    public override string RegistrarEntrega()
    {
        return "Van fez entrega leve";
    }

    public string RealizarManutencao()
    {
        return "Van passou por manutenção";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Caminhao c = new Caminhao();
        c.Identificacao = "C1";
        c.CapacidadeCarga = 10000;
        c.TipoCombustivel = "Diesel";

        Van v = new Van();
        v.Identificacao = "V1";
        v.CapacidadeCarga = 2000;
        v.TipoCombustivel = "Gasolina";

        List<Veiculo> lista = new List<Veiculo>();
        lista.Add(c);
        lista.Add(v);

        foreach (Veiculo veiculo in lista)
        {
            Console.WriteLine("ID: " + veiculo.Identificacao);
            Console.WriteLine("Capacidade: " + veiculo.CapacidadeCarga);
            Console.WriteLine("Combustível: " + veiculo.TipoCombustivel);

            Console.WriteLine(veiculo.RegistrarEntrega());

            IManutencao m = (IManutencao)veiculo;
            Console.WriteLine(m.RealizarManutencao());

            Console.WriteLine("-------------------");
        }
    }
}